using System;
using System.Collections.Generic;

namespace StudyCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var BirthRange =  new List<int> { 8,15};
            var DeathMountRange = new List<int> { 3, 4 };
            int Mounth = 15;

            var coopClass = new CoopClass(BirthRange, DeathMountRange, Mounth);

            coopClass.RunSimulation();
        }
    }
}
