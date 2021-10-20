using System;

namespace ADO.Net_AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO ADDRESS BOOK SYSTEM!!!!");
            AddressBookRepo addressBook = new AddressBookRepo();
            addressBook.DBCOnnection();
            addressBook.CreateContact();
        }
    }
}
