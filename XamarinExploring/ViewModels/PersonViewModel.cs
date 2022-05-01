using XamarinExploring.BusinessRules.Enterprise;

using System.ComponentModel;
using System.Windows.Input;

namespace XamarinExploring.ViewModels {

  public class PersonDetailViewModel : INotifyPropertyChanged
  {

    public event PropertyChangedEventHandler PropertyChanged;
    readonly PeopleListViewModel ViewModel;
    internal readonly PersonViewModel Original;
    public Person Person { get; private set; }

    internal PersonDetailViewModel(PeopleListViewModel viewModel, PersonViewModel personViewModel)
    {
      ViewModel = viewModel;
      Original = personViewModel;
      Person = personViewModel.Person.Clone();
    }

    internal PersonViewModel Clone()
    {
      return new PersonViewModel(Person.Clone());
    }

    public string Name
    {

      get => Person.Name;

      set
      {

        if (Person.Name == value) return;

        Person.Name = value;
        OnPropertyChanged(nameof(Person.Name));
      }
    }

    public string Email
    {

      get => Person.Email;

      set
      {

        if (Person.Email == value) return;


        Person.Email = value;
        OnPropertyChanged(nameof(Person.Email));
      }
    }

    public string Phone
    {

      get => Person.Phone;

      set
      {

        if (Person.Phone == value) return;


        Person.Phone = value;
        OnPropertyChanged(nameof(Person.Phone));
      }
    }


    public bool IsValid =>
        ((!string.IsNullOrEmpty(Name.Trim())) ||
        (!string.IsNullOrEmpty(Phone.Trim())) ||
        (!string.IsNullOrEmpty(Email.Trim())));

    private void OnPropertyChanged(string propName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public ICommand UpdatePersonCommand => ViewModel.UpdatePersonCommand;
    public ICommand DeletePersonCommand => ViewModel.DeletePersonCommand;
    public ICommand BackToPeopleListCommand => ViewModel.BackToPeopleListCommand;

    internal void Update()
    {
      Original.Name = Person.Name;
      Original.Email = Person.Email;
      Original.Phone = Person.Phone;
    }
  }

  public class PersonViewModel: INotifyPropertyChanged {

    public event PropertyChangedEventHandler PropertyChanged;
    public Person Person { get; private set; }
    

    public PersonViewModel() {
      Person = new Person();
    }
    
    internal PersonViewModel(Person person)
    {
      Person = person;
    }

    internal PersonViewModel Clone()
    {
      return new PersonViewModel(Person.Clone());
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
