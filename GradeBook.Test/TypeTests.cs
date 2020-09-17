using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using Xunit;

namespace GradeBook.Test
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        int count = 0;
        [Fact]

        public void WrtieLogDelegateCanPointtoMethod()

        {
            WriteLogDelegate log = ReturnMessage;
               
            log += ReturnMessage;
            log += IncrementCount;


            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);

        }

        private void SetInt(ref int x)
        {
            x = 42;

        }


        private int GetInt()
        {
            return 3;
        }

        [Fact]

        public void CSharpCanPassByValue()
        {
            //arrange 
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);


        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]

        public void CSharpIsPassByValue()
        {
            //arrange 
            var book1 = GetBook("InMemoryBook 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);


        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange 
            var book1 = GetBook("InMemoryBook 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);


        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUppercase(name);

            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange 
            var book1 = GetBook("InMemoryBook 1");
            var book2 = GetBook("InMemoryBook 2");

            Assert.Equal("InMemoryBook 1", book1.Name);
            Assert.Equal("InMemoryBook 2", book2.Name);


        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange 
            var book1 = GetBook("InMemoryBook 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
