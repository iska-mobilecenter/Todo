//using System;
//using System.IO;
//using System.Linq;
//using NUnit.Framework;
//using Xamarin.UITest;
//using Xamarin.UITest.Queries;
//using Xamarin.UITest.Android;

//namespace Todo.Android.UITest
//{
//    [TestFixture]
//    public class Tests
//    {
//        AndroidApp app;

//        [SetUp]
//        public void BeforeEachTest()
//        {
//            // TODO: If the Android app being tested is included in the solution then open
//            // the Unit Tests window, right click Test Apps, select Add App Project
//            // and select the app projects that should be tested.
//            app = ConfigureApp
//                .Android
//                // TODO: Update this path to point to your Android app and uncomment the
//                // code if the app is not included in the solution.
//                .ApkFile("../../../Todo.Android/bin/Release/com.infosupport.Todo-Signed.apk")
//                .EnableLocalScreenshots()
//                .StartApp();
//        }

//        [Test]
//        public void AddTodoItem()
//        {
//            // Arrange
//            string expectedName = "Boodschappen doen";

//            // Act
//            app.Tap("+");
//            app.Screenshot("Todo add view launched");
//            app.EnterText("entryName", expectedName);
//            app.EnterText("entryNotes", "Voor vanavond");

//            app.Screenshot("Todo is filled in");

//            app.Tap("Save");
//            app.Screenshot("Item must be added");

//            // Assert
//            var result = app.Query(expectedName);
//            Assert.IsTrue(result.Any(), expectedName + " is not added");
//        }
//    }
//}

