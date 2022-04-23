using System;
using Xamarin.Forms;
using XamarinExploring.ViewModels;


namespace XamarinExploring.Views {
  
  public partial class PersonDetailsPage : ContentPage {
    
    public PeopleListViewModel PeopleListViewModel { get; private set; }
    
    public PersonDetailsPage(PeopleListViewModel peopleListViewModel) {
      InitializeComponent();
      PeopleListViewModel = peopleListViewModel;
      BindingContext = PeopleListViewModel.currentlyBeingEditedExistingPersonData;
      Console.WriteLine(PeopleListViewModel.currentlyBeingEditedExistingPersonData);
      Console.WriteLine(PeopleListViewModel.currentlyBeingEditedExistingPersonData.Name);
      Console.WriteLine(PeopleListViewModel.currentlyBeingEditedExistingPersonData.Email);
      Console.WriteLine(PeopleListViewModel.currentlyBeingEditedExistingPersonData.Phone);
    }
  }
}
