using XamarinExploring.Views;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace XamarinExploring.ViewModels {
  public class PeopleListViewModel : INotifyPropertyChanged {
    
    public ObservableCollection<PersonViewModel> People { get; set; }
    
    public event PropertyChangedEventHandler PropertyChanged;
    
    public ICommand AddPersonCommand { protected set; get; }
    public ICommand DeletePersonCommand { protected set; get; }
    public ICommand SavePersonCommand { protected set; get; }
    public ICommand BackToPeopleListCommand { protected set; get; }
    
    PersonViewModel selectedPerson;
    
    public INavigation NavigationService { get; set;}
    
    
    public PeopleListViewModel() {
      People = new ObservableCollection<PersonViewModel>();
      AddPersonCommand = new Command(AddPerson);
      DeletePersonCommand = new Command(DeletePerson);
      SavePersonCommand = new Command(SavePerson);
      BackToPeopleListCommand = new Command(BackToPeopleListPage);
    }
    
    
    public PersonViewModel SelectedPerson {
      
      get => selectedPerson;
      
      set　{
        
        if (selectedPerson == value) return;


        selectedPerson = null;
        OnPropertyChanged("SelectedPerson");
        NavigationService.PushAsync(new PersonDetailsPage(value));
      }
    }


    private void OnPropertyChanged(string propName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
    
    private void AddPerson() {
      NavigationService.PushAsync(new PersonDetailsPage(new PersonViewModel() { ListViewModel = this }));
    }
    
    private void BackToPeopleListPage() {
      NavigationService.PopAsync();
    }
    
    private void SavePerson(object personObject) {
      
      if (personObject is PersonViewModel person && person.IsValid && !People.Contains(person)) {
        People.Add(person);
      }
      
      BackToPeopleListPage();
    }
    
    private void DeletePerson(object personObject) {
      
      if (personObject is PersonViewModel person) {
        People.Remove(person);
      }
      
      BackToPeopleListPage();
    }
  }
}