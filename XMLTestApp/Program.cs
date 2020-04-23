using System;
using System.Collections.Generic;
using System.Linq;

using System.Xml;
using System.Xml.Linq;

namespace XMLTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string file_name = "TestData.xml";

            XmlDocument xml_doc = new XmlDocument();
            xml_doc.Load(file_name);

            var dekanat = xml_doc.DocumentElement;

            var students = (XmlElement)dekanat.GetElementsByTagName("StudentsList")[0];

            //var groups = students.ChildNodes;

            //var group1 = groups[1];
            //var group2 = groups[2];

            //var students_group1 = group1.ChildNodes;
            //var students_group2 = group2.ChildNodes;

            //Console.WriteLine(group1.Attributes["Name"].Value);
            //foreach (XmlElement student_node in group1.ChildNodes)
            //{
            //    Console.WriteLine("Student id: {0}", student_node.Attributes["Id"].Value);
            //    Console.WriteLine("\tName: {0}", student_node.GetElementsByTagName("Name")[0].InnerText);
            //    Console.WriteLine("\tSurname: {0}", student_node.GetElementsByTagName("Surname")[0].InnerText);
            //    Console.WriteLine("\tPatronymic: {0}", student_node.GetElementsByTagName("Patronymic")[0].InnerText);
            //    Console.WriteLine("\tBirthday: {0}", student_node.GetElementsByTagName("Birthday")[0].InnerText);
            //    Console.WriteLine("\tRating: {0}", student_node.Attributes["Rating"].Value);
            //}

            //Console.WriteLine(group2.Attributes["Name"].Value);
            //foreach (XmlElement student_node in group2.ChildNodes)
            //{
            //    Console.WriteLine("Student id: {0}", student_node.Attributes["Id"].Value);
            //    Console.WriteLine("\tName: {0}", student_node.GetElementsByTagName("Name")[0].InnerText);
            //    Console.WriteLine("\tSurname: {0}", student_node.GetElementsByTagName("Surname")[0].InnerText);
            //    Console.WriteLine("\tPatronymic: {0}", student_node.GetElementsByTagName("Patronymic")[0].InnerText);
            //    Console.WriteLine("\tBirthday: {0}", student_node.GetElementsByTagName("Birthday")[0].InnerText);
            //    Console.WriteLine("\tRating: {0}", student_node.Attributes["Rating"].Value);
            //}

            var decanat = new List<Group>();

            foreach (XmlElement xml_group in students.GetElementsByTagName("Group"))
            {
                var group = new Group();
                group.Name = xml_group.Attributes["Name"].Value;

                foreach (XmlElement xml_student in xml_group.GetElementsByTagName("Student"))
                {
                    var student = new Student();
                    student.Id = int.Parse(xml_student.Attributes["Id"].Value);
                    student.Name = xml_student.GetElementsByTagName("Name")[0].InnerText;
                    student.Surname = xml_student.GetElementsByTagName("Surname")[0].InnerText;
                    student.Patronymic = xml_student.GetElementsByTagName("Patronymic")[0].InnerText;
                    student.Birthday = DateTime.Parse(xml_student.GetElementsByTagName("Birthday")[0].InnerText);
                    student.Rating = double.Parse(xml_student.Attributes["Rating"].Value);

                    group.Students.Add(student);
                }

                decanat.Add(group);
            }

            

            Console.ReadLine();
        }
    }

    class Group
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public double Rating { get; set; }
    }
}
