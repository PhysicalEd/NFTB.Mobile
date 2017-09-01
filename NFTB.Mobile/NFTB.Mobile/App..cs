using NFTB.Mobile.UI.Pages;
using NFTB.Mobile.UI.Content;
using NFTB.Mobile.UI.Navigation;
using Xamarin.Forms;

namespace NFTB.Mobile
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            //var content = new ContentPage
            //{
            //    Title = "FTB",
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
            Resources = new Styles().Resources;
            var menu = new MasterMenu();
            //menu.Title = "WOOF";
            //var nav = new NavigationPage(menu);
            
            
            
            
            
            //nav.Title = "Meow";
            //MainPage = new NavigationPage(new MasterMenu());
            //MainPage = nav;
            MainPage = new MasterMenu();

            //MainPage = new TermEditor();
            //MainPage = new Xamarin.Forms.MasterDetailPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
