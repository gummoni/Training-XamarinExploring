using XamarinExploring.BusinessRules.Enterprise;

using System.ComponentModel;


namespace XamarinExploring.ViewModels {
  public class PersonViewModel: INotifyPropertyChanged {

    public event PropertyChangedEventHandler PropertyChanged;
    public Person Person { get; private set; }
    
    private PeopleListViewModel _peopleListViewModel;


    public PersonViewModel() {
      Person = new Person();
    }
    
    
    public PeopleListViewModel ListViewModel {
      
      get => _peopleListViewModel;

      set　{
        
        if (_peopleListViewModel == value) return;
        
        _peopleListViewModel = value;
        OnPropertyChanged("ListViewModel");
      }
    }
    
    
    public string Name {
      
      get => Person.Name;
      
      set {
        
        if (Person.Name == value) return;
        
        
        Person.Name = value;
        OnPropertyChanged("Name");
      }
    }
    
    public string Email {
      
      get => Person.Email;

      set {
        
        if (Person.Email == value) return;
        
        
        Person.Email = value;
        OnPropertyChanged("Email");
      }
    }
    
    public string Phone {
      
      get => Person.Phone;

      set {
        
        if (Person.Phone == value) return;
        
        
        Person.Phone = value;
        OnPropertyChanged("Phone");
      }
    }
    
    
    public bool IsValid =>
        ((!string.IsNullOrEmpty(Name.Trim())) ||
        (!string.IsNullOrEmpty(Phone.Trim())) ||
        (!string.IsNullOrEmpty(Email.Trim())));


    private void OnPropertyChanged(string propName) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
  }
}
