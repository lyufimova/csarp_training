﻿using WebAddressbookTests;
using System.IO;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {

            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];
            if (type == "group")
            {
                List<GroupData> groups = groupGenerate(count);

                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")

                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")

                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else if (type == "contact")
            {
                List<ContactData> contacts = contactGenerate(count);

                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (format == "xml")

                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")

                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format " + format);
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized type " + type);
            }

            writer.Close();
        }
        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
            // где writer - куда, groups - что
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        static List<GroupData> groupGenerate(int count)
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
            return groups;
        }


        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}",
                    contact.FirstName, contact.LastName));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
            // где writer - куда, contacts - что
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        static List<ContactData> contactGenerate(int count)
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(30), TestBase.GenerateRandomString(30)));
            }
            return contacts;
        }





    }
}

