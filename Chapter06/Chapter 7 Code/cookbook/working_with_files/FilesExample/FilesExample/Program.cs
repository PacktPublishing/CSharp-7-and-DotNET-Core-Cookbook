using System.IO;
using System.IO.Compression;
using System.Text;
using static System.Console;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FilesExample
{
    class Program
    {
        public enum VehicleTypes
        {
            Car = 1,
            SUV = 2,
            Utility = 3
        }

        static void Main(string[] args)
        {

            #region Zip, Unzip, Compression
            //string path = @"c:\temp\";
            //ZipIt(path);
            //UnZipIt(path);
            //InMemCompressDecompress(); 
            #endregion

            #region Serialization
            //Stream str = SerializeTiger();
            //WriteLine(new StreamReader(str).ReadToEnd());
            //DeserializeTiger(str); 
            #endregion

            #region Vehicle : ISerializable
            //string serializationPath = @"C:\temp\vehicleInfo.dat";
            //Vehicle vehicle = new Vehicle();
            //vehicle.VehicleType = (int)VehicleTypes.Car;
            //vehicle.EngineCapacity = 1600;
            //vehicle.TopSpeed = 230;

            //if (File.Exists(serializationPath))
            //    File.Delete(serializationPath);

            //using (FileStream stream = new FileStream(serializationPath, FileMode.Create))
            //{
            //    BinaryFormatter fmter = new BinaryFormatter();
            //    fmter.Serialize(stream, vehicle);
            //}

            //using (FileStream stream = new FileStream(serializationPath, FileMode.Open))
            //{
            //    BinaryFormatter fmter = new BinaryFormatter();
            //    Vehicle deserializedVehicle = (Vehicle)fmter.Deserialize(stream);
            //} 
            #endregion

            #region Using XmlSerializer
            //string serializationPath = @"C:\temp\classInfo.xml";
            //Student studentA = new Student()
            //{
            //    StudentName = "John Smith"
            //    ,
            //    SubjectMark = 86.4
            //};
            //Student studentB = new Student()
            //{
            //    StudentName = "Jane Smith"
            //    ,
            //    SubjectMark = 67.3
            //};
            //List<Student> students = new List<Student>();
            //students.Add(studentA);
            //students.Add(studentB);

            //FundamentalProgramming subject = new FundamentalProgramming();
            //subject.Lecturer = "Prof. Johan van Niekerk";
            //subject.RoomNumber = "Lecture Auditorium A121";
            //subject.Students = students;
            //subject.ClassAverage = (students.Sum(mark => mark.SubjectMark) / students.Count());

            //using (FileStream stream = new FileStream(serializationPath, FileMode.Create))
            //{
            //    XmlSerializer xmlSer = new XmlSerializer(typeof(FundamentalProgramming));
            //    xmlSer.Serialize(stream, subject);
            //}

            //using (FileStream stream = new FileStream(serializationPath, FileMode.Open))
            //{
            //    XmlSerializer xmlSer = new XmlSerializer(typeof(FundamentalProgramming));
            //    FundamentalProgramming fndProg = (FundamentalProgramming)xmlSer.Deserialize(stream);
            //}
            #endregion

            #region JSON Serialization
            //string serializationPath = @"C:\temp\classInfo.txt";
            //Student studentA = new Student()
            //{
            //    StudentName = "John Smith"
            //    ,
            //    SubjectMark = 86.4
            //};
            //Student studentB = new Student()
            //{
            //    StudentName = "Jane Smith"
            //    ,
            //    SubjectMark = 67.3
            //};
            //List<Student> students = new List<Student>();
            //students.Add(studentA);
            //students.Add(studentB);

            //FundamentalProgramming subject = new FundamentalProgramming();
            //subject.Lecturer = "Prof. Johan van Niekerk";
            //subject.RoomNumber = "Lecture Auditorium A121";
            //subject.Students = students;
            //subject.ClassAverage = (students.Sum(mark => mark.SubjectMark) / students.Count());
            //WriteLine($"Calculated class average = {subject.ClassAverage}");

            //JsonSerializer json = new JsonSerializer();
            //json.Formatting = Formatting.Indented;
            //using (StreamWriter sw = new StreamWriter(serializationPath))
            //{
            //    using (JsonWriter wr = new JsonTextWriter(sw))
            //    {
            //        json.Serialize(wr, subject);
            //    }
            //}
            //WriteLine("Serialized to file using JSON Serializer");

            //using (StreamReader sr = new StreamReader(serializationPath))
            //{
            //    string jsonString = sr.ReadToEnd();
            //    WriteLine("JSON String Read from file");
            //    JObject jobj = JObject.Parse(jsonString);
            //    IList<double> subjectMarks = jobj["Students"].Select(m => (double)m["SubjectMark"]).ToList();
            //    var ave = subjectMarks.Sum() / subjectMarks.Count();
            //    WriteLine($"Calculated class average using JObject = {ave}");
            //}

            //using (StreamReader sr = new StreamReader(serializationPath))
            //{
            //    using (JsonReader jr = new JsonTextReader(sr))
            //    {
            //        FundamentalProgramming funProg = json.Deserialize<FundamentalProgramming>(jr);
            //    }
            //} 
            #endregion
            
            #region Test File Sizes
            //int iteration = 10000;

            //List<Student> students = new List<Student>();
            //for (int i = 0; i <= iteration; i++)
            //{
            //    Student student = new Student();
            //    student.StudentName = $"Student Name {i}";
            //    Random rnd = new Random();

            //    student.SubjectMark = (rnd.NextDouble() * 100);
            //    students.Add(student);
            //}

            //FundamentalProgramming subject = new FundamentalProgramming();
            //subject.Lecturer = "Prof. Johan van Niekerk";
            //subject.RoomNumber = "Lecture Auditorium A121";
            //subject.Students = students;
            //subject.ClassAverage = (students.Sum(mark => mark.SubjectMark) / students.Count());

            //string jsonserializationPath = @"C:\temp\serializationJson.txt";
            //string xmlserializationPath = @"C:\temp\serializationXml.xml";

            //JsonSerializer json = new JsonSerializer();
            //json.Formatting = Formatting.Indented;
            //using (StreamWriter sw = new StreamWriter(jsonserializationPath))
            //{
            //    using (JsonWriter wr = new JsonTextWriter(sw))
            //    {
            //        json.Serialize(wr, subject);
            //    }
            //}

            //using (FileStream stream = new FileStream(xmlserializationPath, FileMode.Create))
            //{
            //    XmlSerializer xmlSer = new XmlSerializer(typeof(FundamentalProgramming));
            //    xmlSer.Serialize(stream, subject);
            //} 
            #endregion

            WindowHeight = 18;
            WindowWidth = 62;
            //ReadLine();
        }

        #region Zip, Unzip, Compression
        private static void ZipIt(string path)
        {
            string sourceDirectory = $"{path}Documents";

            if (Directory.Exists(sourceDirectory))
            {
                string archiveName = $"{path}DocumentsArchive.zip";
                ZipFile.CreateFromDirectory(sourceDirectory, archiveName, CompressionLevel.Optimal, false);
            }
        }

        private static void UnZipIt(string path)
        {
            string destinationDirectory = $"{path}DocumentsUnzipped";

            if (Directory.Exists(path))
            {
                string archiveName = $"{path}DocumentsArchive.zip";
                ZipFile.ExtractToDirectory(archiveName, destinationDirectory);
            }
        }

        private static void InMemCompressDecompress()
        {
            string largeFile = @"C:\temp\Documents\file 3.txt";

            string inputString = File.ReadAllText(largeFile);
            var bytes = Encoding.Default.GetBytes(inputString);

            var originalLength = bytes.Length;
            var compressed = bytes.CompressStream();
            var compressedLength = compressed.Length;

            var newFromCompressed = compressed.DecompressStream();
            var newFromCompressedLength = newFromCompressed.Length;


            WriteLine($"Original string length = {originalLength}");
            WriteLine($"Compressed string length = {compressedLength}");
            WriteLine($"Uncompressed string length = {newFromCompressedLength}");

            // To get the original Test back, call this
            //var newString = Encoding.Default.GetString(newFromCompressed);
        }
        #endregion

        #region Serialization
        private static Stream SerializeTiger()
        {
            Tiger tiger = new Tiger();
            tiger.Age = 12;
            tiger.IsTamed = false;
            tiger.Trainer = "Joe Soap";
            tiger.Weight = 120;

            MemoryStream stream = new MemoryStream();
            BinaryFormatter fmt = new BinaryFormatter();
            fmt.Serialize(stream, tiger);
            stream.Position = 0;
            return stream;
        }

        private static void DeserializeTiger(Stream stream)
        {
            stream.Position = 0;
            BinaryFormatter fmt = new BinaryFormatter();
            Tiger tiger = (Tiger)fmt.Deserialize(stream);
        }
        #endregion



    }


    #region Extension Methods
    public static class ExtensionMethods
    {
        public static byte[] CompressStream(this byte[] originalSource)
        {
            using (var outStream = new MemoryStream())
            {
                using (var gzip = new GZipStream(outStream, CompressionMode.Compress))
                {
                    gzip.Write(originalSource, 0, originalSource.Length);
                }

                return outStream.ToArray();
            }
        }

        public static byte[] DecompressStream(this byte[] originalSource)
        {
            using (var sourceStream = new MemoryStream(originalSource))
            {
                using (var outStream = new MemoryStream())
                {
                    using (var gzip = new GZipStream(sourceStream, CompressionMode.Decompress))
                    {
                        gzip.CopyTo(outStream);
                    }

                    return outStream.ToArray();
                }
            }
        }
    }
    #endregion

    #region Serializable Custom Classes
    [Serializable]
    public class Tiger : Cat
    {
        public string Trainer;
        public bool IsTamed;
    }


    [Serializable]
    public abstract class Cat
    {
        // fields
        public int Weight;
        public int Age;
    }
    #endregion

    #region Vehicle : ISerializable
    [Serializable]
    public class Vehicle : ISerializable
    {
        // Primitive fields
        public int VehicleType;
        public int EngineCapacity;
        public int TopSpeed;

        public Vehicle()
        {

        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("VehicleType", VehicleType);
            info.AddValue("EngineCapacity", EngineCapacity);
            info.AddValue("TopSpeed", TopSpeed);
        }

        // Deserialization constructor
        protected Vehicle(SerializationInfo info, StreamingContext context)
        {
            VehicleType = info.GetInt32("VehicleType");
            EngineCapacity = info.GetInt32("EngineCapacity");
            TopSpeed = info.GetInt32("TopSpeed");
        }
    }
    #endregion

    #region Using XmlSerializer
    //[XmlRoot(ElementName = "FundamentalsOfProgramming", Namespace = "http://serialization")]
    //public class FundamentalProgramming
    //{
    //    [XmlElement(ElementName = "LecturerFullName", DataType = "string")]
    //    public string Lecturer;

    //    [XmlIgnore]
    //    public double ClassAverage;

    //    [XmlAttribute]
    //    public string RoomNumber;

    //    [XmlArray(ElementName = "StudentsInClass", Namespace = "http://serialization")]
    //    public List<Student> Students;
    //}

    //public class Student
    //{
    //    public string StudentName;
    //    public double SubjectMark;
    //} 
    #endregion

    
    public class FundamentalProgramming
    {
        public string Lecturer;

        public double ClassAverage;

        public string RoomNumber;

        public List<Student> Students;
    }

    public class Student
    {
        public string StudentName;
        public double SubjectMark;
    }
}
