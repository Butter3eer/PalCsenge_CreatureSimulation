using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            World w = new World(5, 3);

            //Console.WriteLine(w.W == 5);
            //Console.WriteLine(w.H == 3);
            //Console.WriteLine("----------------------------");
            //Console.WriteLine(w.getCell(1, 2).X == 1);
            //Console.WriteLine(w.getCell(1, 2).Y == 2);
            //Console.WriteLine("----------------------------");
            //Console.WriteLine(w.getCell(1, 1) == w.getCell(1, 1));
            //Console.WriteLine("----------------------------");
            //List<Cell> cells = w.CellList;
            //Console.WriteLine(cells.Count == w.W * w.H);
            //Console.WriteLine(cells.Contains(w.getCell(0, 0)));
            //Console.WriteLine(cells.Contains(w.getCell(4, 0)));
            //Console.WriteLine(cells.Contains(w.getCell(0, 2)));
            //Console.WriteLine(cells.Contains(w.getCell(4, 2)));
            //Console.WriteLine("----------------------------");
            //Carnivore c1 = new Carnivore();
            //Carnivore c2 = new Carnivore();
            //c1.moveTo(w.getCell(1, 2));
            //c2.moveTo(w.getCell(2, 1));
            //Console.WriteLine(c1.getVisibleCells() != null);
            //List<Creature> allCreatures = w.Creatures;
            //Console.WriteLine(allCreatures.Count == 2);
            //Console.WriteLine(allCreatures.Contains(c1));
            //Console.WriteLine(allCreatures.Contains(c2));
            //Console.WriteLine("----------------------------");
            //World w2 = new World(4, 1);

            //Cell a = w2.getCell(0, 0);
            //Cell b = w2.getCell(1, 0);
            //Cell c = w2.getCell(2, 0);
            //Cell d = w2.getCell(3, 0);
            //a.changePlants(20);
            //b.changePlants(20);
            //new Carnivore().moveTo(b);
            //c.changePlants(30);
            //new Carnivore().moveTo(c);
            //new Carnivore().moveTo(c);
            //new Carnivore().moveTo(c);
            //d.changePlants(30);
            //new Carnivore().moveTo(d);
            //new Carnivore().moveTo(d);

            //List<Cell> cells2 = new List<Cell> { a, b, c, d };
            //cells2.Sort();

            //Console.WriteLine(a == cells2[2]);
            //Console.WriteLine(b == cells2[3]);
            //Console.WriteLine(c == cells2[1]);
            //Console.WriteLine(d == cells2[0]);
            //Console.WriteLine("----------------------------");
            Herbivore h = new Herbivore(1);

            Console.WriteLine(h.Sight == 1);
            Console.WriteLine(h.Energy == 20);
            Console.WriteLine(!h.IsAlive);
            Console.WriteLine(h.CurrentCell == null);
            Console.WriteLine("----------------------------");
            World w3 = new World(5, 5);
            Cell c3 = w3.getCell(2, 2);
            h.moveTo(c3);
            Console.WriteLine(h.IsAlive);
            Console.WriteLine(h.CurrentCell == c3);
            Console.WriteLine(c3.Creatures.Contains(h));
            Console.WriteLine("----------------------------");
            List<Cell> visible = h.getVisibleCells();

            Console.WriteLine(visible.Contains(h.CurrentCell));
            Console.WriteLine(visible.Contains(w3.getCell(1, 1)));
            Console.WriteLine(visible.Contains(w3.getCell(3, 3)));
            Console.WriteLine(visible.Contains(w3.getCell(1, 3)));
            Console.WriteLine(visible.Contains(w3.getCell(3, 1)));
            Console.WriteLine(!visible.Contains(w3.getCell(0, 0)));
            Console.WriteLine(!visible.Contains(w3.getCell(4, 4)));
            Console.WriteLine(!visible.Contains(w3.getCell(4, 0)));
            Console.WriteLine(!visible.Contains(w3.getCell(0, 4)));
            Console.WriteLine(!visible.Contains(w3.getCell(2, 4)));
            Console.WriteLine(!visible.Contains(w3.getCell(4, 2)));
            Console.WriteLine("----------------------------");
            h.die();
            Console.WriteLine(!h.IsAlive);
            Console.WriteLine(h.CurrentCell == null);
            Console.WriteLine(!c3.Creatures.Contains(h));
        }
    }
}
