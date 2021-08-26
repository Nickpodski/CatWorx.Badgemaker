using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
      bool response = PeopleFetcher.CheckTask();
      if (response == true)
      {
        List<Employee> employees = PeopleFetcher.GetFromAPI();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        Util.MakeBadges(employees);
      }
      if (response == false)
      {
        List<Employee> employees = PeopleFetcher.GetEmployees();
        Util.PrintEmployees(employees);
        Util.MakeCSV(employees);
        Util.MakeBadges(employees);
      }
    }
  }
}
