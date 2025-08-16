//Quinn Keenan, 301504914, 07/08/2025

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace ZooManagementLib
{
    public abstract class Animal : IComparable
    {
        private byte age;
        public byte Age
        {
            get
            {
                return age;
            }
            internal set
            {
                age = value; 
            }
        }

        private FoodType[] diet;
        public FoodType[] Diet
        {
            get
            {
                return diet;
            }
            internal set
            {
                diet = value;
            }
        }

        private byte hungerLevel;
        public byte HungerLevel
        {
            get
            {
                return hungerLevel; 
            }
            internal set
            {
                hungerLevel = value; 
            }
        }

        [JsonProperty]
        public readonly int Id;
        [JsonProperty]
        public readonly string Name; 

        private double weight;
        public double Weight
        {
            get
            {
                return weight; 
            }
            internal set
            {
                weight = value;
            }
        }

        internal Animal(int age, FoodType[] diet, int hungerLevel, string name, double weight)
        {
            Age = ZooManagementService.ValidateAge(age);
            Diet = ZooManagementService.ValidateDiet(diet);
            HungerLevel = ZooManagementService.ValidateHungerLevel(hungerLevel);
            Id = ZooManagementService.ActiveInstance.LowestUniqueAnimalId;
            Name = ZooManagementService.ValidateNameOrPassword(name, nameof(name));
            Weight = ZooManagementService.ValidateWeight(weight);
        }
        [JsonConstructor]
        internal Animal(byte age, FoodType[] diet, byte hungerLevel, int id, string name, double weight)
        {
            Age = age;
            Diet = diet;
            HungerLevel = hungerLevel;
            Id = id; 
            Name = name;
            Weight = weight; 
        }

        public int CompareTo(object obj)
        {
            Animal otherAnimal = obj as Animal; 

            if (this.Id < otherAnimal.Id)
            {
                return -1; 
            }
            else if (this.Id > otherAnimal.Id)
            {
                return 1; 
            }
            else
            {
                return 0; 
            }
        }

        public int[] DietToIntArr() //Used to set the selected indices of the listBox that dynamically loads on
        {                                                //the EditAnimal panel.
            int count;
            FoodType[] foodTypes = (FoodType[])Enum.GetValues(typeof(FoodType));
            int[] indices = new int[Diet.Length];
            byte indicesArrIndex = 0;

            for (count = 0; count < foodTypes.Length; count++)
            {
                if (Diet.Contains(foodTypes[count]))
                {
                    indices[indicesArrIndex] = count;
                    indicesArrIndex++;
                }
            }

            return indices;
        }

        public override bool Equals(object? obj)
        {
            return obj is Animal otherAnimal && (Id == otherAnimal.Id);
        }

        internal void Feed(FoodType foodType)
        {
            HungerLevel = 0;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        internal virtual string MakeSound()
        {
            return $"{Name} says \"";
        }

        public override string ToString()
        {
            string dietStr = string.Join(", ", Diet);
            return $"Name: {Name} ({Id}), Age: {Age} years old. Weighs {Weight}kg. Eats {dietStr}. Is {HungerLevel}% hungry."; 
        }
    }
}