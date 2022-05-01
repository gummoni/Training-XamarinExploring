namespace XamarinExploring.BusinessRules.Enterprise {
  public class Person {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    internal Person Clone() {
      return new Person()
      {
        Name = Name,
        Email = Email,
        Phone = Phone,
      };
    }

  }
}
