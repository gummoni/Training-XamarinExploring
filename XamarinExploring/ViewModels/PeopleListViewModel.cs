using System;
using XamarinExploring.Views;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace XamarinExploring.ViewModels {
  
  public class PeopleListViewModel : INotifyPropertyChanged {
    
    public ObservableCollection<PersonViewModel> People { get; set; }
    
    public event PropertyChangedEventHandler PropertyChanged;
    public INavigation NavigationService { get; set;}

    
    public PeopleListViewModel() {
      
      People = new ObservableCollection<PersonViewModel> {
        new PersonViewModel { Name = "John Davis", Email = "john.davis@fmail.com", Phone = "55555555" },
        new PersonViewModel { Name = "Cris Jonson", Email = "cris.jonson@fmail.com", Phone = "666666666" }
      };
      
      InitializeCommands();
    }
    
    
    /* === Person adding ============================================================================================ */
    public PersonViewModel NewPerson { get; set; }
    
    public ICommand BeginToEditPersonDataCommand { protected set; get; }
    private void BeginToEditPersonData(object eventArgs)
    {
      if (eventArgs is SelectedItemChangedEventArgs selectedItemChangedEventArgs)
      {
        if (selectedItemChangedEventArgs.SelectedItem is PersonViewModel selectedPerson)
        {
          var viewModel = new PersonDetailViewModel(this, selectedPerson);
          NavigationService.PushAsync(new PersonDetailsPage(viewModel));
        }
      }
    }

    public ICommand BeginToInputNewPersonDataCommand { protected set; get; }
    private void BeginToInputNewPersonData() {
      NewPerson = new PersonViewModel();
      NavigationService.PushAsync(new PersonAddingPage(this));
    }
    
    public ICommand SaveNewPersonCommand { protected set; get; }
    private void SaveNewPerson(object personObject) {
      
      if (personObject is PersonViewModel person && person.IsValid) {
        People.Add(person);
      }
      
      NewPerson = null;
      BackToPeopleListPage();
    }
    
    
    /* === Person viewing and editing =============================================================================== */
    //private PersonViewModel _selectedPerson;
    
    /* [ Methodology ] Currently it is even with 'PersonViewModel' but in the future it will change. */
    //public CurrentlyBeingEditedExistingPersonData currentlyBeingEditedExistingPersonData;
    //public class CurrentlyBeingEditedExistingPersonData : PersonViewModel {}
    
    //public PersonViewModel SelectedPerson {
      
    //  get => _selectedPerson;
      
    //  set　{
        
    //    if (_selectedPerson == value) return;

    //    _selectedPerson = value;
    //    OnPropertyChanged(nameof(SelectedPerson));

    //    currentlyBeingEditedExistingPersonData = new CurrentlyBeingEditedExistingPersonData {
    //      Name = _selectedPerson.Name,
    //      Email = _selectedPerson.Email,
    //      Phone = _selectedPerson.Phone
    //    };
        
    //    NavigationService.PushAsync(new PersonDetailsPage(this));
        
    //    _selectedPerson = null;
    //  }
    //}
    
    // === < TODO > ====================================================================================================
    public ICommand UpdatePersonCommand { protected set; get; }

    private void UpdatePerson(object args) {
      if (args is PersonDetailViewModel viewModel) {
        viewModel.Update();
      }
      BackToPeopleListPage();
    }
    
    public ICommand DeletePersonCommand { protected set; get; }     // TODO
    public ICommand BackToPeopleListCommand { protected set; get; } // TODO
    
    private void BackToPeopleListPage() {
      NavigationService.PopAsync();
    }

    private void DeletePerson(object args) {
      
      if (args is PersonDetailViewModel viewModel) {
        People.Remove(viewModel.Original);
      }
      
      BackToPeopleListPage();
    }
    // === TODO > ======================================================================================================
    
    
    /* === Routines ================================================================================================= */
    private void InitializeCommands() {
      
      BeginToEditPersonDataCommand = new Command(BeginToEditPersonData);
      BeginToInputNewPersonDataCommand = new Command(BeginToInputNewPersonData);
      SaveNewPersonCommand = new Command(SaveNewPerson);
      UpdatePersonCommand = new Command(UpdatePerson);
      DeletePersonCommand = new Command(DeletePerson);
      BackToPeopleListCommand = new Command(BackToPeopleListPage);
    }
    
    private void OnPropertyChanged(string propName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
  }
}
