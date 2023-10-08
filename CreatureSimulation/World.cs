using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureSimulation
{
    public class World
    {
        private int w;
        private int h;
        private List<Creature> creatures;
        private List<Cell> cellList;

        public World(int w, int h)
        {
            this.w = w;
            this.h = h;
            creatures = new List<Creature>();
            cellList = new List<Cell>();

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    cellList.Add(new Cell(this, x, y));
                }
            }
        }

        public List<Creature> Creatures { 
            get
            {
                List<Creature> list = new List<Creature>();
                foreach (Cell cell in cellList)
                {
                    list.AddRange(cell.Creatures);
                }
                return list;
            }
        }

        public int W { get => w; set => w = value; }
        public int H { get => h; set => h = value; }
        public List<Cell> CellList { get => cellList; set => cellList = value; }

        public Cell getCell(int x, int y)
        {
            if (x > w || y > h || x < 0 || y < 0)
            {
                throw new ArgumentException("A kórdináták nem lehetnek érvénytelenek!");
            }
            else
            {
                return cellList.Find(a => a.X == x && a.Y == y);
            }
        }
    }
}
