using XamarinExploring.BusinessRules.Enterprise;

using System.ComponentModel;


namespace XamarinExploring.ViewModels {
  public class PersonViewModel: INotifyPropertyChanged {

    public event PropertyChangedEventHandler PropertyChanged;
    public Person Person { get; private set; }
    

    public PersonViewModel() {
      Person = new Person();
    }
    
    
    public string Name {
      
      get => Person.Name;
      
      set {
        
        if (Person.Name == value) return;
        
        Person.Name = value;
        OnPropertyChanged(nameof(Person.Name));
      }
    }
    
    public string Email {
      
      get => Person.Email;

      set {
        
        if (Person.Email == value) return;
        
        
        Person.Email = value;
        OnPropertyChanged(nameof(Person.Email));
      }
    }
    
    public string Phone {
      
      get => Person.Phone;

      set {
        
        if (Person.Phone == value) return;
        
        
        Person.Phone = value;
        OnPropertyChanged(nameof(Person.Phone));
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
