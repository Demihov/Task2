using System;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using Part2;

namespace Part2.Tests
{
    public class ArrayTests
    {

        private CustomArray<int> _arrM5to5;
        [SetUp]
        public void Setup()
        {
            _arrM5to5 = new CustomArray<int>(-5, 5, 0, 1, 2, 3, 4, 5, 6, 7, 8);
        }

        [Test]
        public void ArrayLength_minus5_5_11returned()
        {
            Assert.AreEqual(11, _arrM5to5.ArrayLength());
        }

        [Test]
        public void ArrayLength_1_5_5returned()
        {
            CustomArray<int> arr = new CustomArray<int>(1, 5);

            Assert.AreEqual(5, arr.ArrayLength());
        }

        [Test]
        public void ArrayLength_minus10minus5_5returned()
        {
            CustomArray<int> arr = new CustomArray<int>(-10, -5);

            Assert.AreEqual(6, arr.ArrayLength());
        }

        [Test]
        public void ArrayLength_minus5minus20_ExceptionReturned()
        {
            var ex = Assert.Throws<Exception>(() => new CustomArray<int>(-5, -20));

            Assert.That(ex.Message, Is.EqualTo("Start of range more then end"));
        }

        [Test]
        public void ArrayLength_nullArray_ExceptionReturned()
        {
            Assert.Throws<ArgumentNullException>(() => new CustomArray<int>().ArrayLength());
        }

        [Test]
        public void CustomArray_AddMoreArrayThenExisting_ExceptionReturned()
        {
            var ex = Assert.Throws<Exception>(() => new CustomArray<int>(-1, 0, 2, 4, 5, 6, 7, 8));

            Assert.That(ex.Message, Is.EqualTo("Input array's length is more than this array's length"));
        }

        [Test]
        public void CustomArray_AddParamsToExistingArray_normalArrayReturned()
        {
            bool result = true;
            int expected = 0;
            for (int i = -5; i < 4; i++)
            {
                if (_arrM5to5[i] != expected) result = false;

                expected++;
            }

            Assert.AreEqual(true, result);
        }
        [Test]
        public void Iterator_GetMinus10Element_ExceptionReturned()
        {
            Assert.That(() => _arrM5to5[-10], Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void Iterator_Get10Element_ExceptionReturned()
        {
            Assert.That(() => _arrM5to5[10], Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void Iterator_GetMinus3Element_2Returned()
        {
            Assert.AreEqual(2, _arrM5to5[-3]);
        }

        [Test]
        public void Iterator_Get3Element_2Returned()
        {
            CustomArray<int> arr = new CustomArray<int>(-2, 10, 0, 1, 2, 3, 4, 5, 6, 7);

            Assert.AreEqual(5, arr[3]);
        }

        [Test]
        public void Iterator_Set12ToMinus3Element_12Returned()
        {
            _arrM5to5[-3] = 12;

            Assert.AreEqual(12, _arrM5to5[-3]);
        }
        [Test]
        public void Iterator_Set12To3Element_12Returned()
        {
            CustomArray<int> arr = new CustomArray<int>(-2, 10, 0, 1, 2, 3, 4, 5, 6, 7);

            arr[3] = 12;

            Assert.AreEqual(12, arr[3]);
        }

        [Test]
        public void Iterator_SetMinus10Element_ExceptionReturned()
        {
            Assert.That(() => _arrM5to5[-10] = 2, Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }

        [Test]
        public void Iterator_Set10Element_ExceptionReturned()
        {
            Assert.That(() => _arrM5to5[10] = 2, Throws.Exception.TypeOf<IndexOutOfRangeException>());
        }
    }
}