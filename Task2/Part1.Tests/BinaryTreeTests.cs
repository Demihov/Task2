using NUnit.Framework;
using Part1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;

namespace Part1.Tests
{
    public class BinaryTreeTests
    {
        BinaryTree<Student> studentsTree = new BinaryTree<Student>();

        Student s1 = new Student() { Name = "Oleh", Mark = 100, TestDate = DateTime.Now, TestName = "Math" };
        Student s2 = new Student() { Name = "Denis", Mark = 99, TestDate = DateTime.Now, TestName = "Math" };
        Student s3 = new Student() { Name = "Bohdan", Mark = 120, TestDate = DateTime.Now, TestName = "Math" };
        Student s4 = new Student() { Name = "Slad", Mark = 97, TestDate = DateTime.Now, TestName = "Math" };
        Student s5 = new Student() { Name = "Ihor", Mark = 95, TestDate = DateTime.Now, TestName = "Math" };

        [SetUp]
        public void Setup()
        {
            //studentsTree.Notify += DisplayMessage;

            studentsTree.Insert(s1, s1.Mark);
            studentsTree.Insert(s2, s2.Mark);
            studentsTree.Insert(s3, s3.Mark);
            studentsTree.Insert(s4, s4.Mark);
            studentsTree.Insert(s5, s5.Mark);
        }

        [Test]
        public void Find_99_element_InStudentsTree_DenisReturned()
        {
            var expected = s2;

            Assert.AreEqual(expected.Name, studentsTree.Find(expected.Mark).Data.Name);
        }

        [Test]
        public void Find_200_element_InStudentsTree_NullReturned()
        {
            Assert.AreEqual(null, studentsTree.Find(200));
        }

        [Test]
        public void Insert_Student_InStudentsTree_ThisStudentMustBeFound()
        {
            var expected = new Student() { Name = "Taras", Mark = 104, TestDate = DateTime.Now, TestName = "Math" };

            studentsTree.Insert(expected, expected.Mark);

            Assert.AreEqual(expected.Name, studentsTree.Find(expected.Mark).Data.Name);
        }

        [Test]
        public void InsertStudentThatHaveMoreMarkThenRoot_InNewTree_ThisStudentMustBeInRightNode()
        {
            BinaryTree<Student> Tree = new BinaryTree<Student>();

            Tree.Insert(s1, s1.Mark);
            Tree.Insert(s3, s3.Mark);

            var root = Tree.Find(s1.Mark);

            Assert.AreEqual(s3.Name, root.Right.Data.Name);
        }

        [Test]
        public void InsertStudentThatHaveLessMarkThenRoot_InNewTree_ThisStudentMustBeInLeftNode()
        {
            BinaryTree<Student> Tree = new BinaryTree<Student>();

            Tree.Insert(s1, s1.Mark);
            Tree.Insert(s2, s2.Mark);

            var root = Tree.Find(s1.Mark);

            Assert.AreEqual(s2.Name, root.Left.Data.Name);
        }

        [Test]
        public void InOrder_showLeftThenRootThenRightNodeInStudentsTree_Returned_95_97_99_100_120()
        {
            var expectedKeys = new byte[] { 95, 97, 99, 100, 120 };

            var actualKeys = new byte[5];

            int i = 0;
            foreach (var current in studentsTree.GetEnumeratorInOrder())
            {
                actualKeys[i] = current.Mark;
                i++;
            }

            CollectionAssert.AreEqual(expectedKeys, actualKeys);
        }

        [Test]
        public void PostOrder_showLeftThenRightThenRootNodeInStudentsTree_Returned_95_97_99_120_100()
        {

            var expectedKeys = new byte[] { 95, 97, 99, 120, 100 };

            var actualKeys = new byte[5];

            int i = 0;
            foreach (var current in studentsTree.GetEnumeratorPostOrder())
            {
                actualKeys[i] = current.Mark;
                i++;
            }
            CollectionAssert.AreEqual(expectedKeys, actualKeys);
        }

        [Test]
        public void PreOrder_showRootThenLeftThenRightNodeInStudentsTree_Returned_100_99_97_95_120()
        {

            var expectedKeys = new byte[] { 100, 99, 97, 95, 120 };

            var actualKeys = new byte[5];

            int i = 0;
            foreach (var current in studentsTree.GetEnumeratorPreOrder())
            {
                actualKeys[i] = current.Mark;
                i++;
            }

            CollectionAssert.AreEqual(expectedKeys, actualKeys);
        }

        [Test]
        public void DeleteKey_delete99KeyFromStudentTree_ReturnedNullIfFount99Key()
        {
            var tree = new BinaryTree<Student>();

            tree.Insert(s1, s1.Mark);
            tree.Insert(s2, s2.Mark);
            tree.Insert(s3, s3.Mark);
            tree.Insert(s4, s4.Mark);
            tree.Insert(s5, s5.Mark);

            tree.DeleteKey(99);

            Assert.AreEqual(null, tree.Find(99));
        }
    }
}