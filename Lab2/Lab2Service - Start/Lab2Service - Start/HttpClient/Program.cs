using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HttpClient.SchoolServiceRef;
using HttpClient.MathSereviceRef;
using Lab2Service;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SchoolServiceClient proxy = new SchoolServiceClient();

            var newStudent = proxy.AddStudent("A123456", "Smith", "Bill", DateTime.Parse("2/3/1977"),
            GenderEnum.Male, "Communication", 33f, 3.5f);
            //Console.WriteLine(newStudent.ID + " " + newStudent.LastName + " " + newStudent.FirstName + " " + newStudent.DOB + " " + newStudent.Gender + " " + newStudent.Major + newStudent.Units + " " + newStudent.GPA);

            newStudent = proxy.AddStudent("B435345", "Williams", "Bill", DateTime.Parse("1/3/1988"),
            GenderEnum.Male, "Computer Science", 31f, 2.5f);
            //Console.WriteLine(newStudent.ID + " " + newStudent.LastName + " " + newStudent.FirstName + " " + newStudent.DOB + " " + newStudent.Gender + " " + newStudent.Major + newStudent.Units + " " + newStudent.GPA);

            newStudent = proxy.AddStudent("D777666", "Francis", "Jill", DateTime.Parse("8/8/1982"),
            GenderEnum.Female, "Math", 22f, 3.9f);
            //Console.WriteLine(newStudent.ID + " " + newStudent.LastName + " " + newStudent.FirstName + " " + newStudent.DOB + " " + newStudent.Gender + " " + newStudent.Major + newStudent.Units + " " + newStudent.GPA);

            newStudent = proxy.UpdateStudent("A123456", "Smith", "Bill", DateTime.Parse("2/3/1977"),
            GenderEnum.Unknown, "Communication", 33f, 3.5f);

            var getstud = proxy.GetStudent("A123456");

            var students = proxy.GetStudents();

            proxy.DeleteStudent("A123456");

            students = proxy.GetStudents();

            var newTeacher = proxy.AddTeacher(1, "George", "Paul", DateTime.Parse("5/1/1955"), GenderEnum.Male, DateTime.Parse("5/1/1990"), 50);

            newTeacher = proxy.AddTeacher(2, "Byers", "Bill", DateTime.Parse("1/1/1960"), GenderEnum.Male, DateTime.Parse("1/1/1990"), 50);

            newTeacher = proxy.AddTeacher(3, "Lopez", "Janice", DateTime.Parse("2/1/1965"), GenderEnum.Male, DateTime.Parse("2/1/1990"), 50);

            var teachers = proxy.GetTeachers();

            proxy.DeleteTeacher(1);

            teachers = proxy.GetTeachers();

            proxy.GetPeople("", "Bill");

            MathServiceClient proxy2 = new MathServiceClient();
            double result = proxy2.Add(12.5, 2.3);
            Console.WriteLine(result);

            result = proxy2.Subtract(12.5, 2.3);
            Console.WriteLine(result);

            result = proxy2.Multiply(12.5, 2.3);
            Console.WriteLine(result);

            result = proxy2.Divide(12.5, 2.3);
            Console.WriteLine(result);

            result =  proxy2.CircleArea(2.3);
            Console.WriteLine(result);
        }
    }
}
