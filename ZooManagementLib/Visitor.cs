using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace ZooManagementLib
{
    public class Visitor : IComparable
    {
        private byte age;
        public byte Age
        {
            get
            {
                return age;
            }
        }

        private DateTime arrivalTime;
        public DateTime ArrivalTime
        {
            get
            {
                return arrivalTime;
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
        }

        [JsonProperty]
        public readonly int Id;
        [JsonProperty]
        public readonly string Name; 

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
        }

        internal Visitor(int age, string email, string name, string phoneNumber)
        {
            this.age = ZooManagementService.ValidateAge(age);
            arrivalTime = DateTime.Now;

            if (!String.IsNullOrEmpty(email))
            {
                this.email = ZooManagementService.ValidateEmail(email);
            }
            else
            {
                this.email = email; 
            }

            Id = ZooManagementService.ActiveInstance.LowestUniqueVisitorId;
            Name = ZooManagementService.ValidateNameOrPassword(name, nameof(name));
            
            if (!String.IsNullOrEmpty(phoneNumber))
            {
                this.phoneNumber = ZooManagementService.ValidatePhoneNumber(phoneNumber);
            }
            else
            {
                this.phoneNumber = phoneNumber;
            }
        }
        [JsonConstructor]
        internal Visitor(byte age, DateTime arrivalTime, string email, int id, string name, string phoneNumber)
        {
            this.age = age;
            this.arrivalTime = arrivalTime;
            this.email = email;
            Id = id;
            Name = name;
            this.phoneNumber = phoneNumber;
        }

        public int CompareTo(object obj)
        {
            Visitor otherVisitor = obj as Visitor;

            if (this.Id < otherVisitor.Id)
            {
                return -1;
            }
            else if (this.Id > otherVisitor.Id)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            if (String.IsNullOrEmpty(Email) && String.IsNullOrEmpty(PhoneNumber))
            {
                return $"{Name} ({Id}), {Age} years old. Arrived at {ArrivalTime}.";
            }
            else if (String.IsNullOrEmpty(Email))
            {
                return $"{Name} ({Id}), {Age} years old. Arrived at {ArrivalTime}. {PhoneNumber}.";
            }
            else if (String.IsNullOrEmpty(PhoneNumber))
            {
                return $"{Name} ({Id}), {Age} years old. Arrived at {ArrivalTime}. {Email}.";
            }
            else
            {
                return $"{Name} ({Id}), {Age} years old. Arrived at {ArrivalTime}. {Email}, {PhoneNumber}.";
            }
        }
    }
}