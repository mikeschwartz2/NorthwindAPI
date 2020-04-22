using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Models
{
    public class Employee
    {
        private int employeeID;
        private string lastName;
        private string firstName;
        private string title;
        private string titleOfCourtesy;
        private string birthDate;
        private string hireDate;
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string country;
        private string homePhone;
        private string extension;
        private string photo;
        private string notes;
        private string reportTo;
        private string photoPath;

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Title { get => title; set => title = value; }
        public string TitleOfCourtesy { get => titleOfCourtesy; set => titleOfCourtesy = value; }
        public string BirthDate { get => birthDate; set => birthDate = value; }
        public string HireDate { get => hireDate; set => hireDate = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Region { get => region; set => region = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string Country { get => country; set => country = value; }
        public string HomePhone { get => homePhone; set => homePhone = value; }
        public string Extension { get => extension; set => extension = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Notes { get => notes; set => notes = value; }
        public string ReportTo { get => reportTo; set => reportTo = value; }
        public string PhotoPath { get => photoPath; set => photoPath = value; }
    }
}
