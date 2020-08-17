using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);

            Assert.NotEqual(42, x);
        }

        void SetInt(int x)
        {
            x = 42;
        }

        int GetInt()
        {
            return 3;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name1 = "jack";
            MakeUpper1(name1);
            // Here MakeUpper1 can only change its reference to upper and cannot change
            // name here
            Assert.NotEqual("JACK", name1);

            string name2 = "jack";
            name2 = MakeUpper2(name2);
            // Here MakeUpper2 is returning a uppercase value and we are setting it to
            // the variable name2 here and so it has been changed.
            Assert.Equal("JACK", name2);
            
        }

        private string MakeUpper2(string name)
        {
            return name.ToUpper();
        }

        private void MakeUpper1(string name)
        {
            name.ToUpper();
        }




        // Here the instance book1 is being 'passed by reference' into GetBookSetTitleByRef.
        // This means the actual reference to the instance is being changed rather than the
        // value of the reference. Therefore, the Book instance is overwritten. 
        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");

            var before = book1;

            // Note that 'ref' has to be used here and in the function to make sure
            // that is what the dev intends to do.
            // It's not very common to see this in code..
            GetBookSetTitleByRef(ref book1, "New Title");

            var after = book1;

            Assert.Equal("New Title", book1.Title);

            // Therefore:
            Assert.NotSame(before, after);
        }

        void GetBookSetTitleByRef(ref Book book, string title)
        {
            book = new Book(title);
        }

        // Here the value of the reference is being passed to GetBookSetTitle.
        // So nothing changes and the instance of Book (book1) stays the same.
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");

            var before = book1;

            GetBookSetTitle(book1, "New Title");

            var after = book1;

            Assert.Equal("Book 1", book1.Title);
            Assert.Same(before, after); 
        }

        void GetBookSetTitle(Book book, string title)
        {
            book = new Book(title);
        }

        [Fact]
        public void CanSetTitleFromReference()
        {
            var book1 = GetBook("Book 1");

            SetTitle(book1, "New Title");

            Assert.Equal("New Title", book1.Title);
        }

        void SetTitle(Book book, string title)
        {
            book.Title = title;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Title);
            Assert.Equal("Book 2", book2.Title);

            // Or can be tested like so:
            Assert.NotSame(book1, book2);

        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            // Can be written as:
            Assert.True(Object.ReferenceEquals(book1, book2));

        }


        Book GetBook(string title)
        {
            return new Book(title);
        }
    }
}
