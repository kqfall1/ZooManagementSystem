using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagementApp
{
    internal enum PanelTag : byte
    {
        CreateNewAnimals,
        CreateNewService,
        CreateNewVisitors,
        Dashboard,
        EditAnimal,
        Intro,
        LoadService,
        Login,
        ManageHabitats,
        ManagePasswords, 
        ManageVisitors
    }
}