using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace WebApplication4
{



    public class Number
    {
        Random rnd = new Random();
        public int Id { get; set; }
        public string Surname { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public long PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }


        public Number()
        {
           
            this.Surname = Guid.NewGuid().ToString().Substring(0, 8);

            this.Name = Guid.NewGuid().ToString().Substring(9, 4);

            this.LastName = Guid.NewGuid().ToString().Substring(0, 8);

            this.PhoneNumber = CreateNumber();
            this.Address = "Address";
            this.Description = $"Human with number: {this.PhoneNumber}";

        }
        public Number(string Name, long PhoneNumber)
        {
            this.Name = Name;
            this.Surname = $"Surname {Name}";
            this.LastName = $"LastName {Name}";
            this.PhoneNumber = PhoneNumber;
            this.Address = "Address";
            this.Description = $"Human with number: {PhoneNumber}";
        }
        public Number(string Surname, string Name, string LastName, long PhoneNumber, string Address, string Description )
        {
            this.Surname = Surname;
            this.Name = Name;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.Description = Description;
        }
        public long CreateNumber()
        {
            string y = "89";
            for (int i = 0; i < 9; i++)
            {
                string plusY = Convert.ToString(rnd.Next(0, 9));
                y+= plusY;
            }
            return Convert.ToInt64(y);
        }
        public string[] ReturnArray()
        {
            string[] array = new string[] { this.Surname, this.Name, this.LastName, Convert.ToString(this.PhoneNumber), this.Address, this.Description };

            return array;
        }



       
    }



}
