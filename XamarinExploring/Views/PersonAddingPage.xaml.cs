using Xamarin.Forms;
using XamarinExploring.ViewModels;


namespace XamarinExploring.Views {
  
  public partial class PersonAddingPage : ContentPage {
    
    public PeopleListViewModel PeopleListViewModel { get; private set; }
    
    public PersonAddingPage(PeopleListViewModel personViewModel) {
      InitializeComponent();
      PeopleListViewModel = personViewModel;
      BindingContext = PeopleListViewModel;
    }
  }
}