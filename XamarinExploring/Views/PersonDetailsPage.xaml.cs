using Xamarin.Forms;
using XamarinExploring.ViewModels;


namespace XamarinExploring.Views {
  
  public partial class PersonDetailsPage : ContentPage {
    
    public PersonViewModel PersonViewModel { get; private set; }
    
    public PersonDetailsPage(PersonViewModel personViewModel) {
      InitializeComponent();
      PersonViewModel = personViewModel;
      BindingContext = PersonViewModel;
    }
  }
}
