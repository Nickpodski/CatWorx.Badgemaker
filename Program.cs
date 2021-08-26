using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Next(List<Employee> employees)
    {
      Util.PrintEmployees(employees);
      Util.MakeCSV(employees);
      Util.MakeBadges(employees);
    }
    static void Main(string[] args)
    {
      bool response = PeopleFetcher.CheckTask();
      if (response == true)
      {
        List<Employee> employees = PeopleFetcher.GetFromAPI();
        Next(employees);
      }
      if (response == false)
      {
        List<Employee> employees = PeopleFetcher.GetEmployees();
        Next(employees);
      }
    }
  }
}
