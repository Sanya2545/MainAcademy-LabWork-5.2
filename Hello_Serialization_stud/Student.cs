using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Serialization_stud
{

    [Serializable] //Required by BinaryFormatter and SoapFormatter  
    public class Student  //XMLSerializer needs the public class
    {
        [System.Xml.Serialization.XmlIgnore]   //Ignore in Xml Serialization          
        public string Code { get; set; }                     //Public fields are serialize by the three formatters  
        public string Name { get; set; }
        public int Age { get; set; }


        [NonSerialized]
        public string adress;
        //These fields will not be serialized by XmlSerialization

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        public Student(string code = "", string name = "", int age = 0, string adress = "")
        {
            Name = name;
            Age = age;
            Code = code;
            Adress = adress;
        }
        public void SetAdress(string adress, string code)
        {
            Adress = adress;
            Code = code;
        }
        // Create SetAddress(string address, string code) method
        public override string ToString()
        {
            return $"Name : {Name}, Age : {Age}, Code : {Code}";
        }
        // Override ToString() method

    }

}
