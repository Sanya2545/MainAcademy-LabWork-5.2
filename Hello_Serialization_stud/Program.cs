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
            string filepathJson = "Serialize.json";
            string filepathXml = "Serialize.xml";
            string filepathBin = "Serialize.bin";
            Student student = new Student("1", "Bob", 19, "22210 Campony place");
            Console.WriteLine(JsonFrm(student, filepathJson)); 
            Console.WriteLine(XmlFrm(student, filepathXml)); 
            Console.WriteLine(JsonFrm(student, filepathBin)); 
                // Create instance of Student class
                // Initialize its properties
                
                // Call methods for serialization and deserialization
        }
        public static string JsonFrm(Student p, string filepath)
        {
            string strJson = JsonConvert.SerializeObject(p);
            File.WriteAllText(filepath, strJson);
            Student temp;
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                StreamReader sr = new StreamReader(fs);
                temp = JsonConvert.DeserializeObject<Student>(sr.ReadLine());
            }
            return "Json formatting Deserialized : " + temp;
        }
        public static string BinaryFrm(Student p, string filepath)
        {
            using(FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, p);
                Student temp = (Student)binaryFormatter.Deserialize(fs);
                return "Binary formatting Deserialized : " + temp;
            }
        }
        // Impement BinaryFrm(Student p) method to serialize and deserialize p

        // Define path for file
        // Implement BinaryFormatter object creation and p serialization  in using block for FileStream object

        // Implement BinaryFormatter object creation and  deserialization  in using block for FileStream object
        // Write deserialization result to console

        public static string XmlFrm(Student p, string filepath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                xmlSerializer.Serialize(fs, p);
                Student temp = (Student)xmlSerializer.Deserialize(fs);
                return "Xml formatting Deserialized : " + temp;
            }
        }
        // Impement XmlFrm(Student p) method to serialize and deserialize p 

        // Define path for file
        // Create XmlSerializer serializer typeof Student       
        // Implement  p serialization  in using block for FileStream object

        // Create XmlSerializer deserializer typeof Student 
        // Implement   deserialization  in using block for FileStream object
        // Write deserialization result to console

    }
}

