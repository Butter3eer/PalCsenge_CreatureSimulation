using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureSimulation
{
    public class Herbivore : Creature
    {
        private int size;

        public Herbivore(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("A méret csak pozitív lehet!");
            }
        }

        public int Size { get => size; set => size = value; }

        public void move()
        {
            if (this.IsAlive)
            {
                Cell bestVisible = this.getVisibleCells().First();
                foreach (Cell cell in this.getVisibleCells())
                {
                    if (bestVisible.PlantCount == cell.PlantCount)
                    {
                        if (bestVisible.Creatures.Count > cell.Creatures.Count)
                        {
                            bestVisible = cell;
                        }
                    }
                    else if (bestVisible.PlantCount < cell.PlantCount)
                    {
                        bestVisible = cell;
                    }
                }

                this.moveTo(bestVisible);
            }
        }

        public void act()
        {
            double eat = Math.Min(this.CurrentCell.PlantCount, 2 * Math.Pow(size, 2) / (1 + size));

            this.CurrentCell.changePlants(Convert.ToInt16(eat));
            this.changeEnergy(Convert.ToInt16(eat));
            this.changeEnergy(size * -1);
        }
    }
}
