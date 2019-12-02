using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsVG
{
    public class Adress
    {
        public Adress()
        {

        }

        public Adress(string street, string city, string areaCode)
        {
            Street = street;
            City = city;
            AreaCode = areaCode;
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string AreaCode { get; set; }
    }
}
