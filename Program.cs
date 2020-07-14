using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World!");

        GenericStack<string> numbers = new GenericStack<string>();
        var hs = new HandelStack();
        numbers.StackEvent += hs.StackChange;

        numbers.Push("one");
        numbers.Push("two");
        numbers.Push("three");
        numbers.Push("four");
        numbers.Push("five");

        numbers.Pop("one");

        numbers.Display();

    }
    public class HandelStack
    {
        //Creating a code that should occure when the event happens
        public void StackChange(object sender, StackEventArgs e)
        {
            Console.WriteLine("Stack Event call {0} {1}", e.obj, e.strEvent);
        }
    }


    public class GenericStack<T>
    {
        private List<T> list = new List<T>();
        public event StackEventHandeler StackEvent;

        public void Push(T item)
        {
            string s = "Item has been added.";
            list.Add(item);
            if (StackEvent != null)
            {
                StackEvent(this, new StackEventArgs(item, s));
            }
        }

        public void Pop(T item)
        {
            string s = "Item has been removed.";
            list.Remove(item);
            if (StackEvent != null)
            {
                StackEvent(this, new StackEventArgs(item, s));
            }
        }

        public void Display()
        {
            foreach (T number in list)
            {
                Console.WriteLine(number);
            }
        }

    }

    //setting up the delegate for the event
    public delegate void StackEventHandeler(object sender, StackEventArgs e);

    //Create the class to pass the arguments for the event handlers
    public class StackEventArgs : EventArgs
    {
        public object obj { get; set; }
        public string strEvent { get; set; }
        public StackEventArgs(object o, string e)
        {
            this.obj = o;
            this.strEvent = e;
        }

    }
}