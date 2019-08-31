using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lab2Service
{
    [CollectionDataContract]
    public class PersonList : List<Person>
    {
        public PersonList()
        {

        }

        public PersonList(IEnumerable<Person> source) : base(source)
        {

        }
    }
}