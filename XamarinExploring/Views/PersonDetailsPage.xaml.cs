using Xamarin.Forms;
using XamarinExploring.ViewModels;


namespace XamarinExploring.Views {
  
  public partial class PersonDetailsPage : ContentPage {
    
    public PeopleListViewModel PeopleListViewModel { get; private set; }
    
    public PersonDetailsPage(PeopleListViewModel personViewModel) {
      InitializeComponent();
      PeopleListViewModel = personViewModel;
      BindingContext = PeopleListViewModel;
    }
  }
}
