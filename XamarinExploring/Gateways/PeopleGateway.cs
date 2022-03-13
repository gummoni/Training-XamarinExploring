using XamarinExploring.BusinessRules.Enterprise;

using System.Collections.Generic;


namespace XamarinExploring.Gateways {
  public interface IPeopleGateway {
    List<Person> GetAll();
  }
}
