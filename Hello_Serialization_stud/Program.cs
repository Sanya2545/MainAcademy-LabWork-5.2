using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Hello_Serialization_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "Serialize.json";
            Student student = new Student("1", "Bob", 19, "22210 Campony place");
            Console.WriteLine(student);
            string strJson = JsonConvert.SerializeObject(student);
            File.AppendAllText(filepath, strJson);
            Student tempStudent;
            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    StreamReader sr = new StreamReader(fs);
                    tempStudent = JsonConvert.DeserializeObject<Student>(sr.ReadLine());
                }
                Console.WriteLine(tempStudent);

            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine("\nMessage : " + ex.Message + "\n");
            }
                // Create instance of Student class
                // Initialize its properties
                
                // Call methods for serialization and deserialization
        }
        public static void BinaryFrm(Student p, string filepath)
        {
            using(FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, p);

            }
        }
        // Impement BinaryFrm(Student p) method to serialize and deserialize p

        // Define path for file
        // Implement BinaryFormatter object creation and p serialization  in using block for FileStream object

        // Implement BinaryFormatter object creation and  deserialization  in using block for FileStream object
            // Write deserialization result to console

        // Impement SoapFrm(Student p) method to serialize and deserialize p

        // Define path for file
        // Implement SoapFormatter object creation and p serialization  in using block for FileStream object

        // Implement SoapFormatter object creation and  deserialization  in using block for FileStream object
            // Write deserialization result to console

        // Impement XmlFrm(Student p) method to serialize and deserialize p 

        // Define path for file
        // Create XmlSerializer serializer typeof Student       
        // Implement  p serialization  in using block for FileStream object

        // Create XmlSerializer deserializer typeof Student 
        // Implement   deserialization  in using block for FileStream object
            // Write deserialization result to console

    }
}

