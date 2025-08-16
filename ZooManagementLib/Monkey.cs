//Quinn Keenan, 301504914, 07/08/2025

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZooManagementLib
{
    public class Monkey : Animal
    {
        internal Monkey(int age, FoodType[] diet, int hungerLevel, string name, double weight) : base(age, diet, hungerLevel, name, 
                                                                                                      weight) {}
        [JsonConstructor]
        internal Monkey(byte age, FoodType[] diet, byte hungerLevel, int id, string name, double weight) : base(age, diet, hungerLevel,
                                                                                                               id, name, weight) {}

        internal override string MakeSound()
        {
            return $"{base.MakeSound()}OOOOH! OOOOH! AHHHH! AHHHH!\"";
        }
    }
}