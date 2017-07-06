using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace Todo.Android.UITest.Features
{
    [Binding]
    [TestFixture(Platform.Android)]
    public class UnknownSteps
    {
        AndroidApp app;

        [Given(@"ik heb de app gestart")]
        public void GegevenIkHebDeAppGestart()
        {
            app = ConfigureApp
                .Android
                // TODO: Update this path to point to your Android app and uncomment the
                // code if the app is not included in the solution.
                .ApkFile("../../../Todo.Android/bin/Release/com.infosupport.Todo-Signed.apk")
                .EnableLocalScreenshots()
                .StartApp();
        }

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

        [When(@"ik op de toevoegen knop druk")]
        public void AlsIkOpDeToevoegenKnopDruk()
        {
            app.Tap("+");
            app.Screenshot("Todo add view launched");
        }
        
        [When(@"de volgende gegevens invul")]
        public void AlsDeVolgendeGegevensInvul(Table table)
        {
            string naam = table.Rows[0]["Naam"];
            string beschrijving = table.Rows[0]["Beschrijving"];

            app.EnterText("entryName", naam);
            app.EnterText("entryNotes", beschrijving);

            app.Screenshot("Todo is filled in");
        }

        [When(@"ik sla deze gegevens op")]
        public void AlsIkSlaDezeGegevensOp()
        {
            app.Tap("Save");
            app.Screenshot("Item must be added");
        }

        [Then(@"moet de todo-item '(.*)' zijn toegevoegd")]
        public void DanMoetDeTodo_ItemZijnToegevoegd(string naam)
        {
            var result = app.Query(naam);
            Assert.IsTrue(result.Any(), naam + " is not added");
        }
    }
}
