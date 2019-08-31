using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Xml;

namespace Checking
{
    public static class DataStore
    {
        private const string FILENAME = "TransactionData.xml";
        private static TransactionList m_Data;

        public static string Serialize<T>(T obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
                serializer.WriteObject(memoryStream, obj);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public static T Deserialize<T>(string xml)
        {
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                Type toType = typeof(T);
                XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(memoryStream, Encoding.UTF8, new XmlDictionaryReaderQuotas(), null);
                DataContractSerializer serializer = new DataContractSerializer(toType);
                return (T)serializer.ReadObject(reader);
            }
        }

        public static TransactionList LoadData()
        {
            string path = Path.Combine(Path.GetTempPath(), FILENAME);
            if (m_Data == null && File.Exists(path))
            {
                string ser = File.ReadAllText(path);
                m_Data = Deserialize<TransactionList>(ser);
            }
            if (m_Data == null)
            {
                m_Data = new TransactionList();
            }
            return m_Data;
        }

        public static void SaveData()
        {
            string path = Path.Combine(Path.GetTempPath(), FILENAME);
            if (m_Data == null)
            {
                m_Data = new TransactionList();
            }
            string ser = Serialize(m_Data);
            File.WriteAllText(path, ser);
        }
    }
}