using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScripterNetDemo
{
    public partial class Form1 : Form//TODO credits
    {
        ScripterNet.ScripterVM vm;
        static List<object> pendingOutput;
        System.Threading.Thread executionThread;

        public Form1()
        {
            InitializeComponent();

            pendingOutput = new List<object>();

            vm = new ScripterNet.ScripterVM();
            vm.InfiniteLoopControl = 1000;
            vm.RegisterAssembly(typeof(Form));
            vm.RegisterAssembly(typeof(Point));
            vm.RegisterAssembly(typeof(System.Collections.Generic.List<int>));
            vm.RegisterFunction("print", GetType().GetMethod("print"));

            vm.onDebug += new ScripterNet.ScripterVM.DebugEventHandler(vm_onDebug);
            vm.onVMStateChanged += new ScripterNet.ScripterVM.VMStateEventHandler(vm_onVMStateChanged);

            updateState();
        }

        public static void print(object a)
        {
            lock (pendingOutput)
                pendingOutput.Add(a);
        }

        String state = "Idle";
        String ParsingTime = "...";
        String ExecutionTime = "...";
        DateTime t;

        void vm_onVMStateChanged(ScripterNet.ScripterVM.VMState v_new, ScripterNet.ScripterVM.VMState v_old)
        {
            state = v_new.ToString();
            var a = ((int)new TimeSpan(DateTime.Now.Ticks - t.Ticks).TotalMilliseconds).ToString() + " ms";
            if (v_new == ScripterNet.ScripterVM.VMState.Idle && v_old != ScripterNet.ScripterVM.VMState.Parsing)
                ExecutionTime = a;
            else if (v_new == ScripterNet.ScripterVM.VMState.Executing)
                ParsingTime = a;
            else if (v_new == ScripterNet.ScripterVM.VMState.Parsing)
            {
                ExecutionTime = "...";
                ParsingTime = "...";
            }
            rtb_Info.Invoke(new Action(() =>
            {
                updateState();
            }));
            t = DateTime.Now;
        }

        void vm_onDebug(int line, int pos, string command)
        {
        }

        public void updateState()
        {
            rtb_Info.Text = "VM state: " + state + "\r\nParsing time: " + ParsingTime + "\r\nExecution time: " + ExecutionTime;
            rtb_Info.SelectionStart = 10;
            rtb_Info.SelectionLength = state.Length;
            rtb_Info.SelectionColor = (state == "Idle" ? Color.Red : Color.Blue);
            rtb_Info.SelectionLength = 0;
            rtb_Info.SelectionStart = rtb_Info.Text.Length;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            b_Example1_Click(null, null);
        }

        private void b_ConsoleClear_Click(object sender, EventArgs e)
        {
            lb_Console.Items.Clear();
        }

        private void b_Terminate_Click(object sender, EventArgs e)
        {
            if (vm.IsExecuting)
            {
                vm.Terminate();
                System.Threading.Thread.Sleep(20);
                print("Execution terminated");
            }
        }

        private void b_Execute_Click(object sender, EventArgs e)
        {
            if (executionThread == null || 
                (executionThread.ThreadState != System.Threading.ThreadState.Aborted && executionThread.ThreadState != System.Threading.ThreadState.Stopped))
                b_Terminate_Click(null, null);
            executionThread = new System.Threading.Thread(_execute);
            executionThread.IsBackground = true;
            executionThread.Start();
        }

        private void _execute()
        {
            ParsingTime = ExecutionTime = "...";
            t = DateTime.Now;
            try
            {
                vm.Execute(tb_Code.Text);
            }
            catch (Exception e)
            {
                print(e.Message);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            vm.InfiniteLoopControl = (int)numericUpDown1.Value;
        }

        private void OutputTimer_Tick(object sender, EventArgs e)
        {
            if (pendingOutput.Count != 0)
                lock (pendingOutput)
                {
                    for (int i = 0; i < pendingOutput.Count; i++)
                    {
                        var a = pendingOutput[i].ToString().Split('\n');
                        for (int j = 0; j < a.Length; j++)
                            lb_Console.Items.Add(a[j]);
                    }
                    pendingOutput.Clear();
                    lb_Console.TopIndex = Math.Max(0, lb_Console.Items.Count - lb_Console.ClientSize.Height / lb_Console.ItemHeight + 1);
                }
        }

        private void tb_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Control)
            {
                b_Execute_Click(null, null);
                e.Handled = true;
            }
        }

        private void lb_Console_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left && lb_Console.SelectedItem != null)
                {
                    var a = lb_Console.SelectedItem.ToString().Trim();
                    if (a.StartsWith("["))
                    {
                        int n = Convert.ToInt32(a.Substring(1, a.IndexOf(';') - 1)) - 1;
                        int s = 0;
                        for (int i = 0; i < n; i++)
                            s += tb_Code.Lines[i].Length + 2;
                        tb_Code.Select(s, tb_Code.Lines[n].Length);
                        tb_Code.ScrollToCaret();
                    }
                }
            }
            catch { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void b_ResetVM_Click(object sender, EventArgs e)
        {
            b_Terminate_Click(null, null);
            vm.Reset();
        }

        private void b_Example1_Click(object sender, EventArgs e)
        {
            b_ResetVM_Click(null, null);
            tb_Code.Text =
            "//Prints out current time twice with a 2-second delay\r\n" +
            "\r\n" +
            "print(System.DateTime.Now.ToString());\r\n" + 
            "System.Threading.Thread.Sleep(2000);\r\n" + 
            "print(System.DateTime.Now.ToString());";
        }

        private void b_Example2_Click(object sender, EventArgs e)
        {
            b_ResetVM_Click(null, null);

            tb_Code.Text = "//Writes first 20 numbers of a Fibonacci sequence to a file \"fibo.txt\"\r\n" +
            "\r\n" +
            "System.IO.StreamWriter sw = new System.IO.StreamWriter(\"fibo.txt\");\r\n" +
            "int a = 1;\r\n" +
            "int b = 1;\r\n" +
            "sw.WriteLine(1);\r\n" +
            "sw.WriteLine(1);\r\n" +
            "for (int i = 0; i < 18; i++)\r\n" +
            "{\r\n" +
            "    b += a;\r\n" +
            "    a = b - a;\r\n" +
            "    sw.WriteLine(b);\r\n" +
            "}\r\n" +
            "sw.Close();\r\n" + 
            "print(\"Finished\");";
        }

        private void b_Example3_Click(object sender, EventArgs e)
        {
            b_ResetVM_Click(null, null);

            tb_Code.Text = "//Quickorts array of numbers and outputs the result\r\n" +
            "\r\n" +
            "function void Quicksort(int[] array, int left, int right)\r\n" +
            "{\r\n" +
            "    int i = left, j = right;\r\n" +
            "    int pivot = array[(left + right) / 2];\r\n" +
            "\r\n" +
            "    while (i <= j)\r\n" +
            "    {\r\n" +
            "        while (array[i] < pivot)\r\n" +
            "            i++;\r\n" +
            "\r\n" +
            "        while (array[j] > pivot)\r\n" +
            "            j--;\r\n" +
            "\r\n" +
            "        if (i <= j)\r\n" +
            "        {\r\n" +
            "            int tmp = array[i];\r\n" +
            "            array[i] = array[j];\r\n" +
            "            array[j] = tmp;\r\n" +
            "\r\n" +
            "            i++;\r\n" +
            "            j--;\r\n" +
            "        }\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    if (left < j)\r\n" +
            "        Quicksort(array, left, j);\r\n" +
            "\r\n" +
            "    if (i < right)\r\n" +
            "        Quicksort(array, i, right);\r\n" +
            "}\r\n" + 
            "\r\n" +
            "int[] arr = new int[10];\r\n" +
            "arr[0] = 6;\r\n" +
            "arr[1] = 1;\r\n" +
            "arr[2] = 8;\r\n" +
            "arr[3] = 4;\r\n" +
            "arr[4] = 5;\r\n" +
            "arr[5] = 3;\r\n" +
            "arr[6] = 9;\r\n" +
            "arr[7] = 7;\r\n" +
            "arr[8] = 2;\r\n" +
            "arr[9] = 10;\r\n" + 
            "Quicksort(arr, 0, arr.Length - 1);\r\n" +
            "for (int i = 0; i < arr.Length; i++)\r\n" +
            "    print(arr[i]);\r\n";
        }

        private void b_Example4_Click(object sender, EventArgs e)
        {
            b_ResetVM_Click(null, null);

            tb_Code.Text = "//Creates a simple Windows Form\r\n" +
            "\r\n" +
            "System.Windows.Forms.Form f = new System.Windows.Forms.Form();\r\n" +
            "f.Name = \"form\";\r\n" +
            "f.Text = \"Script form\";\r\n" +
            "\r\n" +
            "System.Windows.Forms.Label l = new System.Windows.Forms.Label();\r\n" +
            "l.Name = \"label\";\r\n" +
            "l.AutoSize = true;\r\n" +
            "l.Text = \"This is a form, created entirely by script!\";\r\n" +
            "l.Location = new System.Drawing.Point(16, 8);\r\n" + 
            "f.Controls.Add(l);\r\n" +
            "\r\n" +
            "System.Windows.Forms.Button b = new System.Windows.Forms.Button();\r\n" +
            "b.Location = new System.Drawing.Point(16, 36);\r\n" +
            "b.Size = new System.Drawing.Size(l.Size.Width, 36);\r\n" +
            "b.Text = \"Close\";\r\n" +
            "f.Controls.Add(b);\r\n" +
            "\r\n" +
            "f.CancelButton = b;\r\n" +
            "f.ClientSize = new System.Drawing.Size(l.Size.Width + 32, b.Location.Y + b.Size.Height + 8);\r\n" +
            "f.ShowDialog();\r\n";
        }

        private void b_Example5_Click(object sender, EventArgs e)
        {
            b_ResetVM_Click(null, null);

            tb_Code.Text = "//Break is able to stop multiple cycles\r\n" +
            "\r\n" +
            "for (int x = 0; x < 5; x++)\r\n" +
            "    for (int y = 0; y < 5; y++)\r\n" +
            "        for (int z = 0; z < 5; z++)\r\n" +
            "        {\r\n" +
            "            print(x.ToString() + \"; \" + y.ToString() + \"; \" + z.ToString());\r\n" +
            "            if (x == 2 && y == 2 && z == 2)\r\n" +
            "                break(3);\r\n" +
            "        }\r\n";
        }

        private void b_Example_6_Click(object sender, EventArgs e)
        {
            b_ResetVM_Click(null, null);

            tb_Code.Text = "//Switch allows falling through from one case to the next. It also does not require default to work.\r\n" + 
            "\r\n" +
            "int a = 2;\r\n" +
            "switch (a)\r\n" +
            "{\r\n" +
            "    case 1:\r\n" +
            "        print(1);\r\n" +
            "        break;\r\n" +
            "    case 2:\r\n" +
            "        print(2);\r\n" +
            "    case 3:\r\n" +
            "        print(3);\r\n" +
            "    case 4:\r\n" +
            "        print(4);\r\n" +
            "        break;\r\n" +
            "    case 5:\r\n" +
            "        print(5);\r\n" +
            "}\r\n";
        }

        private void b_Example7_Click(object sender, EventArgs e)
        {
            b_ResetVM_Click(null, null);

            tb_Code.Text = "//Demonstrates variable scopes\r\n" + 
            "\r\n" +
            "int a = 1;\r\n" +
            "{\r\n" +
            "    int b = 2;\r\n" +
            "    print(a + b);\r\n" +
            "}\r\n" +
            "print(a + b);\r\n";
        }

        private void b_Example8_Click(object sender, EventArgs e)
        {
            b_ResetVM_Click(null, null);

            tb_Code.Text = "//Bubblesorts array of numbers and outputs the result\r\n" +
            "\r\n" +
            "function void Bubblesort(int[] array)\r\n" +
            "{\r\n" +
            "    for (int i = 0; i < array.Length; i++)\r\n" + 
            "        for (int j = i + 1; j < array.Length; j++)\r\n" + 
            "            if (array[i] > array[j])\r\n" + 
            "            {\r\n" +
            "                int t = array[i];\r\n" +
            "                array[i] = array[j];\r\n" +
            "                array[j] = t;\r\n" + 
            "            }\r\n" + 
            "}\r\n" +
            "\r\n" +
            "int[] arr = new int[10];\r\n" +
            "arr[0] = 6;\r\n" +
            "arr[1] = 1;\r\n" +
            "arr[2] = 8;\r\n" +
            "arr[3] = 4;\r\n" +
            "arr[4] = 5;\r\n" +
            "arr[5] = 3;\r\n" +
            "arr[6] = 9;\r\n" +
            "arr[7] = 7;\r\n" +
            "arr[8] = 2;\r\n" +
            "arr[9] = 10;\r\n" +
            "Bubblesort(arr);\r\n" +
            "for (int i = 0; i < arr.Length; i++)\r\n" +
            "    print(arr[i]);\r\n";
        }

        private void b_Example9_Click(object sender, EventArgs e)
        {
            b_ResetVM_Click(null, null);

            tb_Code.Text = 
            "//A* pathfinding on a small array\r\n" +
            "//WARNING: May take up to 10 seconds to parse.\r\n" +
            "\r\n" +
            "System.Collections.Generic.List<System.Drawing.Point> directions = new System.Collections.Generic.List<System.Drawing.Point>();\r\n" +
            "directions.Add(new System.Drawing.Point(1, 0));\r\n" +
            "directions.Add(new System.Drawing.Point(-1, 0));\r\n" +
            "directions.Add(new System.Drawing.Point(0, 1));\r\n" +
            "directions.Add(new System.Drawing.Point(0, -1));\r\n" +
            "\r\n" +
            "int w = 10, h = 10;\r\n" +
            "\r\n" +
            "int[,] map = new int[w, h];\r\n" +
            "InitializeMap(\"1111111111\", 0);\r\n" +
            "InitializeMap(\"1000000001\", 1);\r\n" +
            "InitializeMap(\"1111111001\", 2);\r\n" +
            "InitializeMap(\"1000000001\", 3);\r\n" +
            "InitializeMap(\"1011111111\", 4);\r\n" +
            "InitializeMap(\"1001000001\", 5);\r\n" +
            "InitializeMap(\"1101001101\", 6);\r\n" +
            "InitializeMap(\"1001001001\", 7);\r\n" +
            "InitializeMap(\"1000001001\", 8);\r\n" +
            "InitializeMap(\"1111111111\", 9);\r\n" +
            "FindPath(new System.Drawing.Point(1, 1), new System.Drawing.Point(8, 8));\r\n" +
            "OutputMap();\r\n" +
            "\r\n" +
            "function void InitializeMap(String s, int y)\r\n" +
            "{\r\n" +
            "    for (int i = 0; i < s.Length; i++)\r\n" +
            "        map[i, y] = s[i] == '1' ? -1 : 0;\r\n" +
            "}\r\n" +
            "\r\n" +
            "function void OutputMap()\r\n" +
            "{\r\n" +
            "    String s;\r\n" +
            "    for (int y = 0; y < h; y++)\r\n" +
            "    {\r\n" +
            "        s = \"\";\r\n" +
            "        for (int x = 0; x < w; x++)\r\n" +
            "            if (map[x, y] == -1) s += \"■\";\r\n" +
            "            elseif (map[x, y] == 1) s += \"+\";\r\n" +
            "            elseif (map[x, y] == 2) s += \"S\";\r\n" +
            "            elseif (map[x, y] == 3) s += \"E\";\r\n" +
            "            else s += \" \";\r\n" + 
            "        print(s);\r\n" +
            "    }\r\n" +
            "}\r\n" +
            "\r\n" +
            "function void FindPath(System.Drawing.Point start, System.Drawing.Point end)\r\n" +
            "{\r\n" +
            "    System.Collections.Generic.List<object[]> open = new System.Collections.Generic.List<object[]>();\r\n" +
            "    System.Collections.Generic.Dictionary<System.Drawing.Point, object[]> closed = new System.Collections.Generic.Dictionary<System.Drawing.Point, object[]>();\r\n" +
            "\r\n" +
            "    bool found = false;\r\n" +
            "    object[] cur = null;\r\n" +
            "    System.Drawing.Point curp = start;\r\n" +
            "    open.Add(GenerateNode(start, null, 0));\r\n" +
            "\r\n" +
            "    while (open.Count != 0 && !found)\r\n" +
            "    {\r\n" +
            "        cur = open[0];\r\n" +
            "        curp = (System.Drawing.Point)cur[0];\r\n" + 
            "        open.RemoveAt(0);\r\n" +
            "        closed.Add(curp, cur);\r\n" +
            "\r\n" +
            "        for (int i = 0; i < directions.Count; i++)\r\n" +
            "        {\r\n" +
            "            curp = new System.Drawing.Point(((System.Drawing.Point)cur[0]).X + directions[i].X, ((System.Drawing.Point)cur[0]).Y + directions[i].Y);\r\n" +
            "            if (curp.X < 0 || curp.Y < 0 || curp.X >= w || curp.Y >= h)\r\n" +
            "                continue;\r\n" +
            "            if (closed.ContainsKey(curp))\r\n" +
            "                continue;\r\n" +
            "            if (map[curp.X, curp.Y] == -1)\r\n" +
            "            {\r\n" +
            "                closed.Add(curp, null);\r\n" +
            "                continue;\r\n" +
            "            }\r\n" +
            "            if (curp == end)\r\n" +
            "            {\r\n" +
            "                found = true;\r\n" +
            "                break;\r\n" +
            "            }\r\n" +
            "\r\n" +
            "            var a = GetOpenAt(open, curp);\r\n" +
            "            if (a == null)\r\n" +
            "                open.Add(GenerateNode(curp, cur, (int)cur[2] + 1));\r\n" +
            "            else if ((int)a[2] < (int)cur[2] + 1)\r\n" +
            "            {\r\n" +
            "                open.Remove(a);\r\n" +
            "                open.Add(GenerateNode(curp, cur, (int)cur[2] + 1));\r\n" +
            "            }\r\n" +
            "        }\r\n" +
            "    }\r\n" +
            "\r\n" +
            "    if (!found)\r\n" +
            "        print(\"Path not found!\");\r\n" +
            "    else\r\n" +
            "    {\r\n" +
            "        while (cur != null)\r\n" +
            "        {\r\n" +
            "            curp = (System.Drawing.Point)cur[0];\r\n" +
            "            map[curp.X, curp.Y] = 1;\r\n" +
            "            cur = (object[])cur[1];\r\n" +
            "        }\r\n" +
            "        map[start.X, start.Y] = 2;\r\n" + 
            "        map[end.X, end.Y] = 3;\r\n" +
            "    }\r\n" +
            "}\r\n" +
            "\r\n" +
            "function object[] GetOpenAt(System.Collections.Generic.List<object[]> open, System.Drawing.Point p)\r\n" +
            "{\r\n" +
            "    for (int i = 0; i < open.Count; i++)\r\n" +
            "        if ((System.Drawing.Point)open[i][0] == p)\r\n" +
            "            return open[i];\r\n" +
            "    return null;\r\n" +
            "}\r\n" +
            "\r\n" +
            "function object[] GenerateNode(System.Drawing.Point p, object[] parent, int length)\r\n" +
            "{\r\n" +
            "    object[] r = new object[3];\r\n" +
            "    r[0] = p;\r\n" +
            "    r[1] = parent;\r\n" +
            "    r[2] = length;\r\n" +
            "    return r;\r\n" +
            "}\r\n";
            /*
            directions.Add(new Point(1, 0));
            directions.Add(new Point(-1, 0));
            directions.Add(new Point(0, 1));
            directions.Add(new Point(0, -1));
            InitializeMap("1111101111", 2);
            FindPath(new Point(1, 1), new Point(8, 8));
            OutputMap();//*/
        }

        #region A*
        /*
        int[,] map = new int[10, 10];
        System.Collections.Generic.List<System.Drawing.Point> directions = new System.Collections.Generic.List<System.Drawing.Point>();

        void InitializeMap(String s, int y)
        {
            for (int i = 0; i < s.Length; i++)
                map[i, y] = s[i] == '1' ? -1 : 0;
        }

        void OutputMap()
        {
            String s;
            for (int y = 0; y < 10; y++)
            {
                s = "";
                for (int x = 0; x < 10; x++)
                    s += map[x, y] == -1 ? "■" : map[x, y] == 1 ? "+" : map[x, y].ToString();
                print(s);
            }
        }

        void FindPath(System.Drawing.Point start, System.Drawing.Point end)
        {
            System.Collections.Generic.List<object[]> open = new System.Collections.Generic.List<object[]>();
            System.Collections.Generic.Dictionary<System.Drawing.Point, object[]> closed = new System.Collections.Generic.Dictionary<System.Drawing.Point, object[]>();

            bool found = false;
            object[] cur = null;
            System.Drawing.Point curp = start;
            open.Add(GenerateNode(start, null, 0));

            while (open.Count != 0 && !found)
            {
                cur = open[0];
                curp = new System.Drawing.Point(((System.Drawing.Point)cur[0]).X, ((System.Drawing.Point)cur[0]).Y);
                open.RemoveAt(0);
                closed.Add(curp, cur);

                for (int i = 0; i < directions.Count; i++)
                {
                    curp = new System.Drawing.Point(((System.Drawing.Point)cur[0]).X + directions[i].X, ((System.Drawing.Point)cur[0]).Y + directions[i].Y);
                    if (curp.X < 0 || curp.Y < 0 || curp.X >= 10 || curp.Y >= 10)
                        continue;
                    if (closed.ContainsKey(curp))
                        continue;
                    if (map[curp.X, curp.Y] == -1)
                    {
                        closed.Add(curp, null);
                        continue;
                    }
                    if (curp == end)
                    {
                        found = true;
                        break;
                    }

                    var a = GetOpenAt(open, curp);
                    if (a == null)
                        open.Add(GenerateNode(curp, cur, (int)cur[2] + 1));
                    else if ((int)a[2] < (int)cur[2] + 1)
                    {
                        open.Remove(a);
                        open.Add(GenerateNode(curp, cur, (int)cur[2] + 1));
                    }
                }
            }

            if (!found)
                return;
            else
            {
                map[end.X, end.Y] = 1;
                while (cur != null)
                {
                    curp = (System.Drawing.Point)cur[0];
                    map[curp.X, curp.Y] = 1;
                    cur = (object[])cur[1];
                }
            }
        }

        object[] GetOpenAt(System.Collections.Generic.List<object[]> open, System.Drawing.Point p)
        {
            for (int i = 0; i < open.Count; i++)
                if ((System.Drawing.Point)open[i][0] == p)
                    return open[i];
            return null;
        }

        object[] GenerateNode(System.Drawing.Point p, object[] parent, int length)
        {
            object[] r = new object[3];
            r[0] = p;
            r[1] = parent;
            r[2] = length;
            return r;
        }
        //*/
        #endregion
    }
}
