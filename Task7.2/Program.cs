using System;
using System.Collections.Generic;
using System.Linq;

namespace Task7._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Jail jail = new Jail();
            jail.Work();
        }
    }

    class Jail
    {
        private List<Prisioner> _prisioners = new List<Prisioner>();

        public Jail()
        {
            AddPrisioners();
        }

        public void Work()
        {
            Console.WriteLine("Тюрьма до амнистии:");
            ShowPrisioners();
            Console.WriteLine(" \nТюрьма после амнистии:");
            DoAmnesty();
            ShowPrisioners();
        }

        private void DoAmnesty()
        {
            IEnumerable<Prisioner> prisionersWithOutAmnesty = _prisioners.Where(prisioner => prisioner.Crime != Crimes.антиправительственное);
            _prisioners = prisionersWithOutAmnesty.ToList();
        }

        private void ShowPrisioners()
        {
            foreach (Prisioner prisioner in _prisioners)
            {
                prisioner.ShowInfo();
            }
        }

        private void AddPrisioners()
        {
            Random random = new Random();
            int minValue = 10;
            int maxValue = 20;
            int countOfPrisioners = random.Next(minValue, maxValue);

            for (int i = 0; i < countOfPrisioners; i++)
            {
                int numberOfCrime = random.Next(Enum.GetValues(typeof(Crimes)).Length);
                _prisioners.Add(new Prisioner((NamesOfPrisioners)i, (Crimes)numberOfCrime));
            }
        }
    }

    class Prisioner
    {
        private NamesOfPrisioners _name;
        public Crimes Crime { get; private set; }

        public Prisioner(NamesOfPrisioners name, Crimes crime)
        {
            _name = name;
            Crime = crime;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {_name}. Преступление:{Crime}.");
        }
    }

    enum NamesOfPrisioners
    {
        Jose,
        Carl,
        John,
        James,
        Randy,
        Scott,
        Shawn,
        Keith,
        Curtis,
        Rafael,
        George,
        Martin,
        Robert,
        Michae,
        Justin,
        Thomas,
        Matthew,
        Raymond,
        Patrick,
        Clarence
    }

    enum Crimes
    {
        антиправительственное,
        убийсто,
        грабеж,
        террор
    }
}
