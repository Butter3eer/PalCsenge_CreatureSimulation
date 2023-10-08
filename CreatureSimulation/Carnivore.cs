using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureSimulation
{
    public class Carnivore : Creature
    {
        public Carnivore()
        {
            this.Energy = 30;
        }

        public void move()
        {
            if (this.IsAlive)
            {
                Cell bestVisible = this.getVisibleCells().First();
                foreach (Cell cell in this.getVisibleCells())
                {
                    int db1 = bestVisible.Creatures.FindAll(x => x is Herbivore).Count;
                    int db2 = cell.Creatures.FindAll(x => x is Herbivore).Count;

                    if (db1 == db2)
                    {
                        List<Creature> herbivores1 = bestVisible.Creatures.FindAll(x => x is Herbivore).ToList();
                        List<Creature> herbivores2 = cell.Creatures.FindAll(x => x is Herbivore).ToList();

                        int suly1 = herbivores1.Max(x => (x as Herbivore).Size);
                        int suly2 = herbivores2.Max(x => (x as Herbivore).Size);

                        if (suly1 < suly2)
                        {
                            bestVisible = cell;
                        }
                    }
                    else if (db1 < db2)
                    {
                        bestVisible = cell;
                    }
                }

                this.moveTo(bestVisible);
            }
        }

        public void act()
        {
            if (this.CurrentCell.Creatures.FindAll(x => x is Herbivore).Count != 0)
            {
                List<Creature> herbivores = this.CurrentCell.Creatures.FindAll(y => y is Herbivore).ToList();

                int maxSuly = herbivores.Max(x => (x as Herbivore).Size);
                Creature biggest = herbivores.Find(x => (x as Herbivore).Size == maxSuly);
                biggest.die();
                this.changeEnergy(-6);
            }
        }
    }
}
