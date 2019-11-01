using System;
using Core;
namespace UIC
{
    class Program
    {
        private static Core.Method.FindRepeatWord find = new Core.Method.FindRepeatWord();
        private static Core.Method.LinqForXml linq = new Core.Method.LinqForXml();
        static void Main(string[] args)
        {
            //if (find.ReadInText()==true)
            //{
            //    find.WriteInXml();
            //    find.ReadInXml();
            //}
            linq.SelectWords();
            Console.ReadLine();
        }
    }
}
