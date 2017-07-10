using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Todo.UnitTest
{
    [TestClass]
    public class TodoItemDatabaseTest
    {
        [TestMethod]
        public void TodoItemDatabase_NotNull_Test()
        {
            var sut = new TodoItemDatabase();
            Assert.IsNotNull(sut);
        }
    }
}
