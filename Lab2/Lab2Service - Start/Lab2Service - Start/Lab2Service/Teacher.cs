using System;
using System.Runtime.Serialization;

namespace Lab2Service
{
    [DataContract]
    public class Teacher : Person
    {
        [DataMember] public int ID { get; set; }
        [DataMember] public DateTime DateOfHire { get; set; }
        [DataMember] public int Salary { get; set; }
    }
}