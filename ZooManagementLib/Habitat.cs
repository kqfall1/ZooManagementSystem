//Quinn Keenan, 301504914, 07/08/2025

using Newtonsoft.Json; 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementLib
{
    public class Habitat<T> where T : Animal
    {
        [JsonIgnore]
        public double AvgAge
        {
            get
            {
                if (Occupants.Count > 0)
                {
                    return Occupants.Average(animal => animal.Age);
                }

                return 0;
            }
        }

        [JsonProperty]
        public readonly string Name; 

        private List<T> occupants;
        public List<T> Occupants
        {
            get
            {
                return occupants;
            }
        }

        [JsonIgnore]
        public double TotalWeight //KG
        {
            get
            {
                if (Occupants.Count > 0)
                {
                    return Occupants.Sum(animal => animal.Weight);
                }

                return 0;
            }
        }

        internal Habitat(string name)
        {
            Name = ZooManagementService.ValidateNameOrPassword(name, nameof(name));
            occupants = new List<T>();
        }
        [JsonConstructor]
        internal Habitat(string name, List<T> occupants)
        {
            Name = name;
            this.occupants = occupants; 
        }

        internal void AddAnimals(params T[] animalNames)
        {
            foreach (T animalName in animalNames)
            {
                if (Occupants.Contains(animalName))
                {
                    throw new ArgumentException($"Animal {animalName} already lives in {Name}...?");
                }
            }

            foreach (T animal in animalNames)
            {
                Occupants.Add(animal);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Habitat<T> otherHabitat &&
                   StringComparer.OrdinalIgnoreCase.Equals(Name, otherHabitat.Name);
        }

        internal void FeedAll()
        {
            byte foodTypeIndex;
            Random random = new Random();

            foreach (T animal in Occupants)
            {
                foodTypeIndex = (byte) random.Next(animal.Diet.Length);
                animal.Feed(animal.Diet[foodTypeIndex]);
            }
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
        }

        internal void RemoveAnimals(params int[] animalIds)
        {
            List<T> removeableAnimals = new List<T>();
            
            foreach (int animalId in animalIds)
            {
                foreach (T animal in Occupants)
                {
                    if (animal.Id == animalId)
                    {
                        removeableAnimals.Add(animal);
                        break; 
                    }
                }
            }

            foreach (T animal in removeableAnimals)
            {
                Occupants.Remove(animal); 
            }
        }

        public override string ToString()
        {
            
            string habitatStr = $"{Name}\n\nOccupants:\n"; 

            foreach (Animal animal in Occupants)
            {
                habitatStr = $"{habitatStr}{ZooManagementService.TO_STRING_INDENTATION}{animal}\n";
            }
            
            return habitatStr; 
        }
    }
}