using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject
{
    class Test
    {
        public static void Main()
        {
            Sfx s = new Sfx();
            s.StartMusic("ButtonSound");
            Console.WriteLine(s.ToString());
            Console.WriteLine("SFX start");
            Console.WriteLine();

            System.Threading.Thread.Sleep(1000);

            Music m = new Music();
            m.StartMusic("Snowfall");
            Console.WriteLine(m.ToString());
            Console.WriteLine("Music start");
            Console.WriteLine();

            IEntity ent = new MovingEntity(1, 100, 10, "NomeEntità");
            
            Console.WriteLine("GetSpeed work? " + ent.GetSpeed().Equals(1));
            Console.WriteLine("GetHp work? " + ent.GetHp().Equals(100));
            Console.WriteLine("Income Damage 36");
            ent.IncomeDamage(36);
            Console.WriteLine("IncomeDamage work? " + ent.GetHp().Equals(64));
            Console.WriteLine("GetDamage work? " + ent.GetDamage().Equals(10));
            Console.WriteLine();

            Console.WriteLine("Wait..");
            Console.WriteLine();
            System.Threading.Thread.Sleep(10000);

            m.StopMusic();
            Console.WriteLine("Music stop");
            Console.WriteLine();

        }
    }
}