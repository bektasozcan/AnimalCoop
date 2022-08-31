using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudyCase
{
    public class CoopClass
    {
        List<int> BirthRange;               

        List<int> DeathMountRange;          

        int Mounth;

        Random random = new Random();

        List<AnimalClass> animallist = new List<AnimalClass>();

        enum Gender
        {
            Male,
            Female
        }

        public CoopClass(List<int> BirthRange, List<int> DeathMountRange, int Mounth)
        {
            this.BirthRange = BirthRange;
            this.DeathMountRange = DeathMountRange;
            this.Mounth = Mounth;
            var animal1 = new AnimalClass();
            animal1.BirthTime = 0;
            animal1.Gender = "Male";
            animallist.Add(animal1);
            var animal2 = new AnimalClass();
            animal2.BirthTime = 0;
            animal2.Gender = "Female";
            animallist.Add(animal2);
        }

        private List<AnimalClass> Brith(int CurrentPeriot)
        {

            List<AnimalClass> femaleAnimal = animallist.Where(f => f.Gender == "Female" &&
                                                                   ((f.BirthTime != CurrentPeriot - 1) || f.BirthTime == 0) &&
                                                                   f.DeathTime == 0).ToList();

            int childCount = random.Next(BirthRange[0], BirthRange[1]) * femaleAnimal.Count;

            for (int i = 0; i < childCount; i++)
            {
                AnimalClass animal = new AnimalClass();
                animal.Gender = DeterminationGender();
                animal.BirthTime = CurrentPeriot;
                animallist.Add(animal);
            }

            return animallist;
        }

        private string DeterminationGender()
        {
            int childGender = random.Next(0, 2);

            return childGender == 0 ? Gender.Male.ToString() : Gender.Female.ToString();
        }

        private void Death(int CurrentPeriot)
        {
            List<AnimalClass> animalDeathList = animallist.Where(f => f.DeathTime == 0).ToList();
            int DeathTime = 0;

            for (int i = 0; i < animalDeathList.Count; i++)
            {
                DeathTime = random.Next(DeathMountRange[0], DeathMountRange[1]);

                if ((CurrentPeriot - animalDeathList[i].BirthTime) > DeathTime)
                {
                    animalDeathList[i].DeathTime = CurrentPeriot;
                }
            }
        }

        private void ResultGenderCount()
        {
            var femaleCount = animallist.Where(f => f.Gender == "Female").ToList().Count;
            var maleCount = animallist.Where(f => f.Gender == "Male").ToList().Count;       
            Console.WriteLine("Erkek Birey Sayısı:" + maleCount);
            Console.WriteLine("Dişi Birey Sayısı:" + femaleCount);   

        }

        private void ResultAge()
        {
            var Age = animallist.Max(x => x.DeathTime - x.BirthTime);
            Console.WriteLine("Ulaşılan En Yüksek Yaş:" + Age);
        }

        public void RunSimulation()
        {
            for (int i = 1; i < Mounth; i++)
            {
                Death(i);
                Brith(i);
            }

            ResultGenderCount();

            ResultAge();
        }
    }
}
