using System;
using System.Runtime.Serialization;

namespace Lab2Service
{
    [KnownType(typeof(Student))]
    [KnownType(typeof(Teacher))]
    [DataContract]
    public class Person
    {
        [DataMember] public string LastName { get; set; }
        [DataMember] public string FirstName { get; set; }
        [DataMember] public DateTime DOB { get; set; }
        [DataMember] public GenderEnum Gender { get; set; }
    }
}