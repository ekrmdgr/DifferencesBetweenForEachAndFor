using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //foreach(var item in list)
            //{
            //    Task.Run(() => { Console.WriteLine(item); });
            //}

            // Example1();

            Example2();

            // Example3();

            Console.ReadLine();
        }

        private static void Example3()
        {
            TestClass t = new TestClass();
            t.ThreadingMethod();
        }

        private static void Example2()
        {

            var list = new List<ExampleClass> { };

            for (int i = 1; i <= 10; i++)
            {
                list.Add(new ExampleClass
                {
                    Id = i,
                    Name = i.ToString()
                });
            }

            for (int i = 0; i < list.Count-1; i++)
            {
                new Thread(() => { WriteToConsole(list[i]); }).Start();
            }
        }

        private static void WriteToConsole(ExampleClass item)
        {
            Console.WriteLine(item.Id);
        }

        private static void Example1()
        {
            List<Func<int>> actions = new List<Func<int>>();

            int variable = 0;
            while (variable < 5)
            {
                // var copy = variable;
                // actions.Add(() => copy * 2);

                actions.Add(() => variable);

                ++variable;
            }

            foreach (var act in actions)
            {
                Console.WriteLine(act.Invoke());
            }
        }
    }

    class TestClass
    {
        public void ThreadingMethod()
        {
            var myList = new List<MyClass> { new MyClass("test1"), new MyClass("test2") };

            foreach (MyClass myObj in myList)
            {
                Thread myThread = new Thread(() => this.MyMethod(myObj));
                myThread.Start();
            }
        }

        public void MyMethod(MyClass myObj) { Console.WriteLine(myObj.prop1); }
    }

    class MyClass
    {
        public string prop1 { get; set; }

        public MyClass(string input) { this.prop1 = input; }
    }

}
