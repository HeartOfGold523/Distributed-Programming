using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.Serialization;

namespace Lab5Client
{
    class Program
    {
        const string BASE_ADDR = "http://localhost:44347/api/students/";
        static void Main(string[] args)
        {
            //Single item GET
            var result = ClientHelper.Get<Student>(BASE_ADDR, SerializationModesEnum.Json, "{0}", 136655918);
            Console.WriteLine(result.Result);

            //Multiple items GET
            var results = ClientHelper.Get<List<Student>>(BASE_ADDR, SerializationModesEnum.Json, "?page={0}&count={1}", 5, 5);
            foreach (var s in results.Result)
            {
                Console.WriteLine(s);
            }

            //POST
            Student add = new Student
            {
                ID = 123456789,
                LastName = "Gates",
                FirstName = "Bill",
                Grade = Student.GradeEnum.College,
                DOB = new DateTime(1955, 10, 28),
                GPA = 3.5f
            };
            var addResult = ClientHelper.Post<Student, object>(BASE_ADDR, SerializationModesEnum.Json, add, string.Empty);
            if (addResult.StatusCode != System.Net.HttpStatusCode.OK) // 200 == success
            {
                Console.WriteLine("Error encountered: {0}", addResult.Error);
            }
            else
            {
                Console.WriteLine("POST result: " + addResult.Result);
            }

            //PUT
            Student put = new Student
            {
                ID = 000000000,
                LastName = "Jones",
                FirstName = "Jim",
                Grade = Student.GradeEnum.College,
                DOB = new DateTime(1996, 02, 21),
                GPA = 2.5f
            };
            var putResult = ClientHelper.Put<Student, object>(BASE_ADDR, SerializationModesEnum.Json, put, string.Empty);
            if (putResult.StatusCode != System.Net.HttpStatusCode.OK) // 200 == succes
            {
                Console.WriteLine("Error encountered: {0}", putResult.Error);
            }
            else
            {
                Console.WriteLine("PUT result: " + putResult.Result);
            }

            //DELETE
            Student delete = put;
            var deleteResult = ClientHelper.Delete<Student, object>(BASE_ADDR, SerializationModesEnum.Json, delete, string.Empty);
            if (deleteResult.StatusCode != System.Net.HttpStatusCode.OK) // 200 == succes
            {
                Console.WriteLine("Error encountered: {0}", deleteResult.Error);
            }
            else
            {
                Console.WriteLine("PUT result: " + deleteResult.Result);
            }
        }
    }
}
