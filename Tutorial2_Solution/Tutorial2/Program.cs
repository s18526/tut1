using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using Tutorial2.Models;

namespace Tutorial2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var listOfStudents = new HashSet<Student>(new CustomComparer());

            var university = new University
            {
                CreatedAt = DateTime.Now,
                Author = "Maksym Gulko",
                Students = listOfStudents,

            };

            var path = @"Data\dane.csv";

          
            var fi = new FileInfo(path);
            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
              
                while ((line = stream.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                   if(columns.Length != 9)
                    {
                        using var sw = new StreamWriter(@"log.txt");
                        sw.WriteLine(String.Concat(line, " incorrect line"));
                    }

                    foreach (string str in columns)
                    {
                        if (string.IsNullOrEmpty(str))
                        {
                            using var sw = new StreamWriter(@"log.txt");
                            sw.WriteLine(String.Concat(line, " incorrect line"));
                        }
                    }
                    var stud = getStudents(columns);
                    listOfStudents.Add(stud);

                    if (listOfStudents.Contains(stud))
                    {
                        using var sw = new StreamWriter(@"log.txt");
                        sw.WriteLine(String.Concat("element exists in the set"));
                    }

                    //Method "Add" return a value true or false
                    //False means that HashSet failed to add new object
                    //in our case it means that object is a duplicate and we have to add it to log.txt
                    if (!listOfStudents.Add(stud))
                    {
                        //Duplicate was found
                        //Write the info to the log.txt
                        using var sw = new StreamWriter(@"log.txt");
                        sw.WriteLine($"element with the first name {stud.FirstName} was not added to the set");
                    }
                }
            }
     
            static Student getStudents(string[] columns)
            {
                var student = new Student
                
                {

                    IndexNumber = columns[4],
                    FirstName = columns[0],
                    LastName = columns[1],
                    Birthdate = DateTime.Parse(columns[5]),
                    Email = columns[6],
                    DadsName = columns[7],
                    MomsName = columns[8],
                    ActiveStudies = new ActiveStudies
                    {
                        Name = columns[2],
                        StudyMode = columns[3],
                        
                    }
                    
                };

               
                return student;
        }

           



            //Check if object exists in the set 
           

            //Serialize the data to the xml file
            var writer = new FileStream(@"result.xml", FileMode.Create);
            var serializer = new XmlSerializer(typeof(University),
                                                new XmlRootAttribute("university"));
            serializer.Serialize(writer, university);

            var jsonString = JsonSerializer.Serialize(listOfStudents);
            File.WriteAllText("data.json", jsonString);
        }
    }
}
