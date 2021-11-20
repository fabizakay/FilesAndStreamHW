using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace FilesAndStreamHW
{
    class Program
    {
        private static string CreateCSVTextFile<T>(List<T> data, string seperator = ",")
        {
            var properties = typeof(T).GetProperties();
            var result = new StringBuilder();

            foreach (var row in data)
            {
                var values = properties.Select(p => p.GetValue(row, null));
                var line = string.Join(seperator, values);
                result.AppendLine(line);
            }

            return result.ToString();
        }
        static void Main(string[] args)
        {
            #region Q1
            Console.WriteLine("****1****");
            var Q1 = Directory.GetDirectories(@"C:\");
            foreach (var file in Q1.Take(10))
            {
                Console.WriteLine(file);
            }

            #endregion

            #region Q2
            Console.WriteLine("****2****");

            var dinfo = new DirectoryInfo(@"c:");
            var file2 = dinfo.GetFiles().OrderByDescending(q => q.Length).Take(3);
            foreach (var item in file2)
            {
                Console.WriteLine(file2);
            }
            #endregion

            #region Q3

            List<Student> students = new List<Student>();
            students.Add(new Student() { Id = "123", Fname = "Fabi", Lname = "Zakay" });
            students.Add(new Student() { Id = "456", Fname = "Avi", Lname = "Hagadol" });
            students.Add(new Student() { Id = "789", Fname = "Elad", Lname = "Hamatok" });
            students.Add(new Student() { Id = "741", Fname = "Itay", Lname = "CHUKU" });
            students.Add(new Student() { Id = "963", Fname = "Yonatan", Lname = "Buba" });

            var studentList = JsonConvert.SerializeObject(students);
            File.Create(@"C:\Users\fabi.zakay\source\repos\FilesAndStreamHW\FilesAndStreamHW\MyJsonFile.json");
            File.WriteAllText(@"C:\Users\fabi.zakay\source\repos\FilesAndStreamHW\MyJsonFile.json", studentList);

            #endregion

            #region Q4

            using (StreamWriter sw = new StreamWriter(@"C:\Users\fabi.zakay\source\repos\FilesAndStreamHW\FilesAndStreamHW\MyFixedLength.txt",false))
            {
                string addlist;
                string addlist1;
                string addlist2;
                foreach (var student in students)
                {
                    addlist = string.Format("{0,10}" ,  student.Fname);
                    addlist1 = string.Format("{0,10}" ,  student.Lname);
                    addlist2 = string.Format("{0,3}" ,  student.Id);
                    sw.WriteLine(addlist + " " + addlist1 + " " +  addlist2);
                }
            }

            #endregion

            #region Q5
            string str = CreateCSVTextFile(students);
            File.WriteAllText(@"C:\Users\fabi.zakay\source\repos\FilesAndStreamHW\FilesAndStreamHW\MyCSVFile.csv",str);

            #endregion
        }

        class Student
        {
            public string Id { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
        }
    }
}
