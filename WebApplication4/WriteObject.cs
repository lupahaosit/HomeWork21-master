using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace WebApplication4
{
    public class WriteObject
    {
        public string Path { get; set; }

        public WriteObject()
        {
            this.Path = "textPage.txt";
        }
        public  void Write(List<Number> number)
        {

            StreamWriter sw = new StreamWriter($"{this.Path}"); ;
            foreach (var item in number)
            {
                sw.WriteLine($"{item.Surname} {item.Name} {item.LastName} {item.PhoneNumber} {item.Address} Description");

            }
            sw.Close();



        }
      
    }
}
