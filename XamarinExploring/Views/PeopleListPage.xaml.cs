using Xamarin.Forms;
using XamarinExploring.ViewModels;


namespace XamarinExploring.Views {
  public partial class PeopleListPage : ContentPage {

    public PeopleListPage() {
      InitializeComponent();
      BindingContext = new PeopleListViewModel { NavigationService = this.Navigation };
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();
      PeopleList.SelectedItem = null;
    }
  }
}