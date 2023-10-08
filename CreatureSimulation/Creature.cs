using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureSimulation
{
    public abstract class Creature
    {
        private readonly int sight;
        private Cell currentCell;
        private int energy;
        private bool isAlive;

        protected Creature()
        {
            this.isAlive = false;
            this.energy = 20;
            if (this is Herbivore)
            {
                this.sight = 1;
            }
            else if (this is Carnivore)
            {
                this.sight = 2;
            }
        }

        public Cell CurrentCell { get => currentCell; set => currentCell = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public int Energy { get => energy; set => energy = value; }

        public int Sight => sight;

        public void die()
        {
            isAlive = false;
            currentCell.removeCreature(this);
            currentCell = null;
        }
        public void moveTo(Cell newCell)
        {
            this.isAlive = true;
            currentCell = newCell;
            currentCell.addCreature(this);
        }

        public void changeEnergy(int amount)
        {
            if (energy + amount < 0)
            {
                die();
            }
            else
            {
                energy += amount;
            }
        }

        public List<Cell> getVisibleCells()
        {
            List<Cell> cells = new List<Cell>();
            World world = this.currentCell.World;

            foreach (Cell cell in world.CellList)
            {
                if (Math.Max(Math.Abs(this.currentCell.X - cell.X), Math.Abs(this.CurrentCell.Y - cell.Y)) <= sight)
                {
                    cells.Add(cell);
                }
            }
            return cells;
        }
    }
}
