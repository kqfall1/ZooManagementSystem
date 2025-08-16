//Quinn Keenan, 301504914, 08/08/2025

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ZooManagementLib
{
    public static class EmployeeInterface
    { 
        //Currently only works on one Animal, for simplicity: 
        public static void AddAnimal(int age, FoodType[] diet, int hungerLevel, string name, double weight, 
                                     int animalTypeIndex, int habitatIndex)
        {
            Animal animal = null;
            
            switch ((AnimalType) animalTypeIndex)
            {
                case AnimalType.Dragon:
                    animal = new Dragon(age, diet, hungerLevel, name, weight);
                    break;
                case AnimalType.GrizzlyBear:
                    animal = new GrizzlyBear(age, diet, hungerLevel, name, weight);
                    break;
                case AnimalType.Lion:
                    animal = new Lion(age, diet, hungerLevel, name, weight);
                    break;
                case AnimalType.Mermaid:
                    animal = new Mermaid(age, diet, hungerLevel, name, weight);
                    break;
                case AnimalType.Monkey:
                    animal = new Monkey(age, diet, hungerLevel, name, weight);
                    break;
                case AnimalType.Unicorn:
                    animal = new Unicorn(age, diet, hungerLevel, name, weight);
                    break;
            }

            GetHabitat(habitatIndex).AddAnimals(animal);
        }
        public static void AddHabitats(params string[] habitatNames)
        {
            int count; 
            Habitat<Animal>[] habitatObjArr = new Habitat<Animal>[habitatNames.Length];             
            
            for (count = 0; count < habitatNames.Length; count++)
            {
                habitatObjArr[count] = new Habitat<Animal>(habitatNames[count]);
            }

            ZooManagementService.ActiveInstance.AddHabitats(habitatObjArr);
        }
        public static void AddPasswords(params string[] passwords)
        {
            ZooManagementService.ActiveInstance.AddPasswords(passwords);
        }
        public static void AddVisitor(int age, string email, string name, string phoneNumber)
        {
            ZooManagementService.ActiveInstance.AddVisitors(new Visitor(age, email, name, phoneNumber)); 
        }
        public static void EditAnimalDiet(int animalIndex, int habitatIndex, FoodType[] selectedFoodTypes)
        {
            GetAnimal(habitatIndex, animalIndex).Diet = selectedFoodTypes;
        }
        public static void EditAnimal(string ageString, FoodType[] diet, string hungerLevelString, string weightString, int 
                                      habitatIndex, int animalIndex)
        {
            Animal animal = GetAnimal(habitatIndex, animalIndex);

            if (!String.IsNullOrEmpty(ageString))
            {
                animal.Age = ZooManagementService.ValidateAge(Convert.ToInt32(ageString)); 
            }

            if (!String.IsNullOrEmpty(hungerLevelString))
            {
                animal.HungerLevel = ZooManagementService.ValidateHungerLevel(Convert.ToInt32(hungerLevelString));
            }

            if (!String.IsNullOrEmpty(weightString))
            {
                animal.Weight = ZooManagementService.ValidateWeight(Convert.ToDouble(weightString)); 
            }
        }

        public static void Export()
        {
            string PATH = @$"{ZooManagementService.SERVICE_FILES_PATH}\{ZooManagementService.ActiveInstance.Name.ToUpper()}.json";

            FileStream fileOut = new FileStream(PATH, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileOut);

            try 
            { 
                ZooManagementService.ExportService(writer);
            }
            catch 
            {
                throw; 
            }
            finally
            {
                writer.Close();
                fileOut.Close();
            }
        }

        public static void FeedAll(int habitatIndex)
        {
            GetHabitat(habitatIndex).FeedAll();
        }

        public static string FeedAnimal(int animalIndex, byte foodIndex, int habitatIndex)
        {
            Animal animal = GetHabitatAnimals(habitatIndex).ElementAt(animalIndex);
            FoodType selectedFood = animal.Diet[foodIndex]; 
            animal.Feed(selectedFood);
            return $"Fed {animal.Name} {selectedFood}.";
        }

        public static Animal GetAnimal(int habitatIndex, int animalIndex)
        {
            return ZooManagementService.ActiveInstance.Habitats.ElementAt(habitatIndex).Occupants.ElementAt(animalIndex);
        }
        public static Animal[] GetHabitatAnimals(int habitatIndex)
        {
            return ZooManagementService.ActiveInstance.Habitats.ElementAt(habitatIndex).Occupants.ToArray(); 
        }
        public static double GetHabitatAvgAge(int habitatIndex)
        {
            return ZooManagementService.ActiveInstance.Habitats.ElementAt(habitatIndex).AvgAge; 
        }
        public static string GetHabitatName(int habitatIndex)
        {
            return ZooManagementService.ActiveInstance.Habitats.ElementAt(habitatIndex).Name;
        }
        public static Habitat<Animal> GetHabitat(int habitatIndex)
        {
            return ZooManagementService.ActiveInstance.Habitats.ElementAt(habitatIndex);
        }
        public static Habitat<Animal>[] GetHabitats()
        {
            return ZooManagementService.ActiveInstance.Habitats.ToArray(); 
        }
        public static double GetHabitatTotalWeight(int habitatIndex)
        {
            return ZooManagementService.ActiveInstance.Habitats.ElementAt(habitatIndex).TotalWeight; 
        }
        public static string[] GetPasswords()
        {
            return ZooManagementService.ActiveInstance.Passwords.ToArray();
        }
        public static Visitor[] GetVisitors()
        {
            return ZooManagementService.ActiveInstance.Visitors.ToArray(); 
        }

        public static string GreetAnimal(int habitatIndex, int animalIndex)
        {
            return GetAnimal(habitatIndex, animalIndex).MakeSound();
        }

        public static void Import(string path) 
        {
            FileStream fileIn = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileIn);

            try
            {
                ZooManagementService.ActiveInstance = ZooManagementService.ImportService(reader);
            }
            catch 
            {
                throw; 
            }
            finally
            {
                reader.Close();
                fileIn.Close();
            }
        }

        public static bool Login(string password) 
        {                         
            if (ZooManagementService.ActiveInstance is null || ZooManagementService.ActiveInstance.IsLoggedIn == true)
            {
                throw new InvalidLoginException(); 
            }
            
            ZooManagementService.ActiveInstance.IsLoggedIn = ZooManagementService.VerifyPassword(password);
            return ZooManagementService.ActiveInstance.IsLoggedIn;
        }

        public static void Logout()
        {
            if (ZooManagementService.ActiveInstance is null || ZooManagementService.ActiveInstance.IsLoggedIn == false)
            {
                throw new InvalidLogoutException();
            }

            ZooManagementService.ActiveInstance = null;
        }

        public static void RemoveAnimals(int habitatIndex, params int[] animalIDs)
        {
            GetHabitat(habitatIndex).RemoveAnimals(animalIDs);
        }
        public static void RemoveHabitats(params string[] habitatNames)
        {
            int count = 0;
            Habitat<Animal>[] habitats = new Habitat<Animal>[habitatNames.Length]; 

            for (count = 0; count < habitats.Length; count++)
            {
                habitats[count] = new Habitat<Animal>(habitatNames[count]);
            }
            
            ZooManagementService.ActiveInstance.RemoveHabitats(habitats);
        }
        public static void RemovePasswords(params string[] passwords)
        {
            ZooManagementService.ActiveInstance.RemovePasswords(passwords); 
        }
        public static void RemoveVisitors(params int[] visitorIds)
        {
            ZooManagementService.ActiveInstance.RemoveVisitors(visitorIds); 
        }

        public static void ServiceCreationRequest(string name, string password)
        {
            string PATH = @$"{ZooManagementService.SERVICE_FILES_PATH}\";

            if (String.IsNullOrEmpty(name) || name.Length < 2)
            {
                throw new ArgumentException("Name must be 2 or more characters.");
            }
            else if (String.IsNullOrEmpty(password) || password.Length < 6)
            {
                throw new ArgumentException("Password must be 6 or more characters.");
            }

            PATH = @$"{PATH}{name}.json";

            if (File.Exists(PATH))
            {
                throw new ArgumentException($"File {PATH} already exists!");
            }

            ZooManagementService.ActiveInstance = new ZooManagementService(name, password);
        }
    }
}