using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CreatureSimulation
{
    public class Cell : IComparable<Cell>
    {
        private static readonly int MAX_PLANTS = 100;
        private World world;
        private int x;
        private int y;
        private List<Creature> creatures;
        private int plantCount;

        public Cell(World world, int x, int y)
        {
            this.world = world;
            this.x = x;
            this.y = y;
            creatures = new List<Creature>();
            plantCount = 0;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public List<Creature> Creatures { get => creatures; set => creatures = value; }
        public int PlantCount { get => plantCount; set => plantCount = value; }
        public World World { get => world; set => world = value; }

        public void changePlants(int amount)
        {
            if (plantCount + amount < 0)
            {
                throw new ArgumentException("Negatív mennyiségű virág nem lehet egy cellában!");
            }
            else if (plantCount + amount > 100)
            {
                plantCount = 100;
            }
            else
            {
                plantCount += amount;
            }
        }

        public int CompareTo(Cell other)
        {
            if (this.plantCount.CompareTo(other.plantCount) == 0)
            {
                return this.creatures.Count.CompareTo(other.creatures.Count);
            }
            else
            {
                return other.plantCount.CompareTo(this.plantCount);
            }
        }

        public void addCreature(Creature creature)
        {
            creatures.Add(creature);
        }

        public void removeCreature(Creature creature)
        {
            creatures.Remove(creature);
        }
    }
}
