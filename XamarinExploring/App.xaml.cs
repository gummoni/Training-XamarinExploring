using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinExploring.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamarinExploring
{
  public partial class App : Application
  {
    public App()
    {
      MainPage = new NavigationPage(new PeopleListPage());
    }
  }
}