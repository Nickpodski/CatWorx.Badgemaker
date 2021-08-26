using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
  class PeopleFetcher
  {
    public static bool CheckTask()
    {
      while (true)
      {
        Console.WriteLine("Would like to fetch employees? (y/n)");
        string response = Console.ReadLine();
        if (response == "y")
        {
          return true;
        }
        if (response == "n")
        {
          return false;
        }
        else
        {
          break;
        }
      }
      return false;
    }
    public static List<Employee> GetEmployees()
    {
      List<Employee> employees = new List<Employee>();
      while (true)
      {
        Console.WriteLine("Please enter a name: (leave empty to exit): ");
        string firstName = Console.ReadLine();
        if (firstName == "")
        {
          break;
        }

        Console.Write("Enter last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Enter Id: ");
        int id = Int32.Parse(Console.ReadLine());
        Console.Write("Enter Photo URL: ");
        string photoUrl = Console.ReadLine();


        // Create a new Employee instance
        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
        employees.Add(currentEmployee);
      }
      // This is important!
      return employees;
    }
    public static List<Employee> GetFromAPI()
    {
      List<Employee> employees = new List<Employee>();
      using (WebClient client = new WebClient())
      {
        string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
        JObject json = JObject.Parse(response);
        foreach (JToken token in json.SelectToken("results"))
        {
          // Parse JSON data
          Employee emp = new Employee
          (
            token.SelectToken("name.first").ToString(),
            token.SelectToken("name.last").ToString(),
            Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
            token.SelectToken("picture.large").ToString()
          );
          employees.Add(emp);
        }
      }
      return employees;
    }
  }
}