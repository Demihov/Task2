using System;
using Part1.Models;

namespace Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student() { Name = "Oleh", Mark = 100, TestDate = DateTime.Now, TestName = "Math" };
            Student s2 = new Student() { Name = "Denis", Mark = 99, TestDate = DateTime.Now, TestName = "Math" };
            Student s3 = new Student() { Name = "Bohdan", Mark = 120, TestDate = DateTime.Now, TestName = "Math" };
            Student s4 = new Student() { Name = "Slad", Mark = 97, TestDate = DateTime.Now, TestName = "Math" };
            Student s5 = new Student() { Name = "Ihor", Mark = 95, TestDate = DateTime.Now, TestName = "Math" };

            BinaryTree<Student> studentsTree = new BinaryTree<Student>();
            studentsTree.Notify += DisplayMessage;

            studentsTree.Insert(s1, s1.Mark);
            studentsTree.Insert(s2, s2.Mark);
            studentsTree.Insert(s3, s3.Mark);
            studentsTree.Insert(s4, s4.Mark);
            studentsTree.Insert(s5, s5.Mark);

            Console.WriteLine(new string('-', 10));

            foreach (var st in studentsTree.GetEnumeratorPreOrder())
            {
                Console.Write(st.Mark + " ");
            }
            Console.WriteLine();


            studentsTree.DeleteKey(970);

            Console.WriteLine(new string('-', 10));

            foreach (var st in studentsTree.GetEnumeratorPreOrder())
            {
                Console.WriteLine(st.Mark);
            }

        }

        private static void DisplayMessage(object sender, TreeEventArgs args)
        {
            Console.WriteLine(args.Message);
        }
    }
}
