using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;
using Microsoft.Azure.Mobile.Push;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Todo
{
	public class App : Application
	{
		static TodoItemDatabase database;

		public App()
		{
			Resources = new ResourceDictionary();
			Resources.Add("primaryGreen", Color.FromHex("91CA47"));
			Resources.Add("primaryDarkGreen", Color.FromHex("6FA22E"));

			var nav = new NavigationPage(new TodoListPage());
			nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
			nav.BarTextColor = Color.White;

			MainPage = nav;
		}

		public static TodoItemDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new TodoItemDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
				}
				return database;
			}
		}

		public int ResumeAtTodoId { get; set; }

		protected override void OnStart()
		{
			MobileCenter.Start("uwp=21242859-6c7c-41ce-babe-6228c4a892ba;android=8c4dc2a1-4536-4e4a-aeb4-7a86e121ea5b;ios=f467fb1e-f56f-4e99-a70b-127da06e639b;",
                               typeof(Analytics), 
                               typeof(Crashes),
                               typeof(Push));

          	//Debug.WriteLine("OnStart");

			//// always re-set when the app starts
			//// users expect this (usually)
			////			Properties ["ResumeAtTodoId"] = "";
			//if (Properties.ContainsKey("ResumeAtTodoId"))
			//{
			//	var rati = Properties["ResumeAtTodoId"].ToString();
			//	Debug.WriteLine("   rati=" + rati);
			//	if (!String.IsNullOrEmpty(rati))
			//	{
			//		Debug.WriteLine("   rati=" + rati);
			//		ResumeAtTodoId = int.Parse(rati);

			//		if (ResumeAtTodoId >= 0)
			//		{
			//			var todoPage = new TodoItemPage();
			//			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
			//			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
			//		}
			//	}
			//}
		}

		protected override void OnSleep()
		{
			//Debug.WriteLine("OnSleep saving ResumeAtTodoId = " + ResumeAtTodoId);
			//// the app should keep updating this value, to
			//// keep the "state" in case of a sleep/resume
			//Properties["ResumeAtTodoId"] = ResumeAtTodoId;
		}

		protected override void OnResume()
		{
			//Debug.WriteLine("OnResume");
			//if (Properties.ContainsKey("ResumeAtTodoId"))
			//{
			//	var rati = Properties["ResumeAtTodoId"].ToString();
			//	Debug.WriteLine("   rati=" + rati);
			//	if (!String.IsNullOrEmpty(rati))
			//	{
			//		Debug.WriteLine("   rati=" + rati);
			//		ResumeAtTodoId = int.Parse(rati);

			//		if (ResumeAtTodoId >= 0)
			//		{
			//			var todoPage = new TodoItemPage();
			//			todoPage.BindingContext = await Database.GetItemAsync(ResumeAtTodoId);
			//			await MainPage.Navigation.PushAsync(todoPage, false); // no animation
			//		}
			//	}
			//}
		}
	}
}

