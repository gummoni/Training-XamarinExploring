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
    
    public ICommand DeletePersonCommand { protected set; get; }     // TODO
    public ICommand BackToPeopleListCommand { protected set; get; } // TODO
    
    PersonViewModel selectedPerson;
    
    public INavigation NavigationService { get; set;}
    
    
    public PeopleListViewModel() {
      
      People = new ObservableCollection<PersonViewModel> {
        new PersonViewModel() { Name = "John Davis", Email = "john.davis@fmail.com", Phone = "55555555" },
        new PersonViewModel() { Name = "Cris Jonson", Email = "cris.jonson@fmail.com", Phone = "666666666" }
      };
      
      BeginToInputNewPersonDataCommand = new Command(BeginToInputNewPersonData);
      SaveNewPersonCommand = new Command(SaveNewPerson);
      
      DeletePersonCommand = new Command(DeletePerson);              // TODO
      BackToPeopleListCommand = new Command(BackToPeopleListPage);  // TODO
    }
    
    
    public PersonViewModel SelectedPerson {
      
      get => selectedPerson;
      
      set　{
        
        if (selectedPerson == value) return;


        selectedPerson = null;
        OnPropertyChanged("SelectedPerson");
        NavigationService.PushAsync(new PersonDetailsPage(this));
      }
    }


    /* === Person adding ============================================================================================ */
    public PersonViewModel NewPerson { get; set; }
    
    public ICommand BeginToInputNewPersonDataCommand { protected set; get; }
    public ICommand SaveNewPersonCommand { protected set; get; }
    
    private void BeginToInputNewPersonData() {
      NewPerson = new PersonViewModel();
      NavigationService.PushAsync(new PersonAddingPage(this));
    }
    
    private void SaveNewPerson(object personObject) {
      
      if (personObject is PersonViewModel person && person.IsValid) {
        People.Add(person);
      }
      
      NewPerson = null;
      BackToPeopleListPage();
    }

    
    // === < TODO > ====================================================================================================
    private void BackToPeopleListPage() {
      NavigationService.PopAsync();
    }

    private void DeletePerson(object personObject) {
      
      if (personObject is PersonViewModel person) {
        People.Remove(person);
      }
      
      BackToPeopleListPage();
    }
    // === TODO > ======================================================================================================
    
    
    /* === Routines ================================================================================================= */
    private void OnPropertyChanged(string propName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
  }
}