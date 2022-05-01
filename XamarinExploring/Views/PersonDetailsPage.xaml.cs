using System;
using Xamarin.Forms;
using XamarinExploring.ViewModels;


namespace XamarinExploring.Views {
  
  public partial class PersonDetailsPage : ContentPage {
    
    
    public PersonDetailsPage(PersonDetailViewModel personDetailViewModel) {
      InitializeComponent();

      BindingContext = personDetailViewModel;
      //BindingContext = PeopleListViewModel.currentlyBeingEditedExistingPersonData;
      //Console.WriteLine(PeopleListViewModel.currentlyBeingEditedExistingPersonData);
      //Console.WriteLine(PeopleListViewModel.currentlyBeingEditedExistingPersonData.Name);
      //Console.WriteLine(PeopleListViewModel.currentlyBeingEditedExistingPersonData.Email);
      //Console.WriteLine(PeopleListViewModel.currentlyBeingEditedExistingPersonData.Phone);
    }
  }
}
