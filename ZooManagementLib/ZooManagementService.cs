//Quinn Keenan, 301504914, 08/08/2025

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace ZooManagementLib
{
    //I began this projct by utilizing System.Text.Json for serialization. I eventually realized later on that System.Text.Json is
    //primitive, unsuitable for polymorphic deserialization, and will not deserialize proprties without public get and set methods. I
    //like to have control over my project and I lose a lot with my original serialization tool of choice, so I switched to Newtonsoft.
    //I personally like it a lot better, although I wonder if there's a "catch" or downside to using it. Time will tell...
    public class ZooManagementService
    {
        internal static ZooManagementService ActiveInstance;
        internal const byte TO_STRING_INDENTATION = 4;

        private List<Habitat<Animal>> habitats;
        public List<Habitat<Animal>> Habitats
        {
            get
            {
                return habitats; 
            }
        }
 
        private bool isLoggedIn;
        [JsonIgnore]
        public bool IsLoggedIn
        {
            get
            {
                return isLoggedIn; 
            }
            internal set
            {
                isLoggedIn = value; 
            }
        }

        static JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented,
        };

        [JsonIgnore]
        internal int LowestUniqueAnimalId
        {
            get
            {
                int count;
                Animal[] ascendingSortedOccupants = AllOccupants().ToArray();

                Array.Sort(ascendingSortedOccupants);

                for (count = 0; count < ascendingSortedOccupants.Count(); count++)
                {
                    if (ascendingSortedOccupants[count].Id != count + 1)
                    {
                        break;
                    }
                }

                return count + 1;
            }
        }
        [JsonIgnore]
        internal int LowestUniqueVisitorId
        {
            get
            {
                int count;
                Visitor[] ascendingSortedVisitors = Visitors.ToArray();

                Array.Sort(ascendingSortedVisitors);

                for (count = 0; count < ascendingSortedVisitors.Count(); count++)
                {
                    if (ascendingSortedVisitors[count].Id != count + 1)
                    {
                        break;
                    }
                }

                return count + 1;
            }
        }

        public readonly string Name; 

        private List<string> passwords;
        public List<string> Passwords
        {
            get
            {
                return passwords;
            }
        }

        public static readonly string SERVICE_FILES_PATH = Path.Combine(Environment.
                        GetFolderPath(Environment.SpecialFolder.CommonApplicationData),
                        "ZooAnimalManagementServiceFiles");

        private List<Visitor> visitors;
        public List<Visitor> Visitors
        {
            get
            {
                return visitors; 
            }
        }

        internal ZooManagementService(string name, string password) : this()
        {
            habitats = new List<Habitat<Animal>>();
            Name = ValidateNameOrPassword(name, nameof(name));
            passwords = new List<string>();
            Passwords.Add(password);
            visitors = new List<Visitor>();

            if (!Directory.Exists(SERVICE_FILES_PATH))
            {
                Directory.CreateDirectory(SERVICE_FILES_PATH);
            }
        }
        [JsonConstructor]
        internal ZooManagementService(List<Habitat<Animal>> habitats, string name, List<string> passwords, List<Visitor> visitors) : this()
        {
            this.habitats = habitats;
            Name = name;
            this.passwords = passwords; 
            this.visitors = visitors;
        }
        private ZooManagementService()
        {
            IsLoggedIn = false;
        }

        internal void AddHabitats(params Habitat<Animal>[] habitats)
        {   
            foreach (Habitat<Animal> habitat in habitats)
            {
                if (this.Habitats.Contains(habitat))
                {
                    throw new ArgumentException($"Habitat {habitat} already exists!");
                }
            }

            foreach (Habitat<Animal> habitat in habitats)
            {
                this.Habitats.Add(habitat); 
            }
        }
        internal void AddPasswords(params string[] passwords)
        { 
            foreach(string password in passwords)
            {
                if (Passwords.Contains(password))
                {
                    throw new ArgumentException($"Password {password} already exists!"); 
                }
            }

            foreach (string password in passwords)
            {
                Passwords.Add(password);
            }
        }
        internal void AddVisitors(params Visitor[] visitors)
        {
            foreach (Visitor visitor in visitors)
            {
                if (Visitors.Contains(visitor))
                {
                    throw new ArgumentException($"Visitor {visitor} already exists!");
                }
            }

            foreach (Visitor visitor in visitors)
            {
                Visitors.Add(visitor); 
            }
        }

        public static string ActiveInstanceName() //Only meant to be accessed outside of the library. This was done to prevent
        {                                         //library users from having access to activeInstance. activeInstance is 
            return ActiveInstance.Name;           //accessed and has its value set directly elsewhere in this class. It is currently
        }                                         //used to load dyanmic text for the GUI and nothing more. 

        internal List<Animal> AllOccupants()
        {
            List<Animal> occupants = new List<Animal>();

            foreach (Habitat<Animal> habitat in ActiveInstance.Habitats)
            {
                foreach (Animal animal in habitat.Occupants)
                {
                    occupants.Add(animal);
                }
            }

            return occupants;
        }

        internal static void ExportService(StreamWriter writer)
        {
            string jsonString = JsonConvert.SerializeObject(ActiveInstance, JSON_SETTINGS);
            writer.WriteLine(jsonString);
        }

        internal static ZooManagementService ImportService(StreamReader reader)
        {
            string jsonString = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<ZooManagementService>(jsonString, JSON_SETTINGS); 
        }

        internal void RemoveHabitats(params Habitat<Animal>[] habitats)
        {
            foreach (Habitat<Animal> habitat in habitats)
            {
                if (!this.Habitats.Contains(habitat))
                {
                    throw new ArgumentException($"Habitat {habitat} does not exist!");
                }
            }

            foreach (Habitat<Animal> habitat in habitats)
            {
                this.Habitats.Remove(habitat);
            }
        }
        internal void RemovePasswords(params string[] passwords)
        {
            foreach (string password in passwords)
            {
                if (!Passwords.Contains(password))
                {
                    throw new ArgumentException($"Password {password} does not exist!"); 
                }
            }

            foreach (string password in passwords)
            {
                Passwords.Remove(password); 
            }
        }
        internal void RemoveVisitors(params int[] visitorIds)
        {
            List<Visitor> removeableVisitors = new List<Visitor>();

            foreach (int visitorId in visitorIds)
            {
                foreach (Visitor visitor in Visitors)
                {
                    if (visitor.Id == visitorId)
                    {
                        removeableVisitors.Add(visitor);
                        break;
                    }
                }
            }

            foreach (Visitor visitor in removeableVisitors)
            {
                Visitors.Remove(visitor);
            }
        }

        public override string ToString()
        {
            string serviceStr = "Habitats:\n--------\n\n";
            foreach (Habitat<Animal> habitat in Habitats)
            {
                serviceStr = $"{serviceStr}{habitat}\n".Replace("\n", $"\n{"", TO_STRING_INDENTATION}");
            }

            return serviceStr; 
        }

        public static byte ValidateAge(int age)
        {
            if (age < 0 || age > 150)
            {
                throw new InvalidInputException(nameof(age));
            }

            return (byte) age; 
        }
        public static string ValidateEmail(string email)
        {
            /* ^ is the start of the string. 
               [a-zA-Z0-9._%+-] is a letter, digit, or symbols. 
               + matches one or more of the characters definied in the preceding range. 
               @ is the literal '@' character. 
               \. is a period. The backslash is an escape character.
               [a-zA-Z]{2,} is at least 2 letters
               $ is the end of the string.
            */
            string regularExpression = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, regularExpression) && email is not null)
            {
                throw new InvalidInputException(nameof(email));
            }

            return email;
        }
        public static FoodType[] ValidateDiet(FoodType[] diet)
        {
            if (!(diet.Length > 0))
            {
                throw new ArgumentException($"{nameof(diet)} cannot be null or empty!");
            }

            return diet; 
        }
        public static byte ValidateHungerLevel(int hungerLevel)
        {
            if (hungerLevel < 0 || hungerLevel > 100)
            {
                throw new InvalidSelectionException(nameof(hungerLevel)); 
            }

            return (byte) hungerLevel; 
        }
        public static string ValidateNameOrPassword(string input, string inputVariableName)
        {
            if (String.IsNullOrEmpty(inputVariableName) || inputVariableName.Length < 2 || inputVariableName.Length > 32)
            {
                throw new ArgumentException($"{nameof(inputVariableName)} must be between 2 and 32 characters inclusive.");
            }
            else if (String.IsNullOrEmpty(input) || input.Length < 2 || input.Length > 32)
            {
                throw new InvalidInputException(inputVariableName);
            }

            return input;
        }
        public static string ValidatePhoneNumber(string phoneNumber)
        {
            string regularExpression = "^[0-9]{3}-[0-9]{3}-[0-9]{4}$";

            if (!Regex.IsMatch(phoneNumber, regularExpression) && phoneNumber is not null)
            {
                throw new InvalidInputException(nameof(phoneNumber));
            }

            return phoneNumber;
        }
        public static double ValidateWeight(double weight)
        {
            if (weight < 0)
            {
                throw new InvalidSelectionException(nameof(weight));
            }

            return weight; 
        }

        public static bool VerifyPassword(string password)
        {
            if (ActiveInstance.Passwords.Contains(password))
            {
                return true;
            }
                
            return false;
        }
    }
}