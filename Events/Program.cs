using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instantiate an event publisher object
            EvtPublisher EP = new EvtPublisher();
            //Instantiate an event subscriber object
            EvtSubscriber ES = new EvtSubscriber();
            EP.Evt += ES.HandleTheEvent;

            //Call the CheckBalance method on the EP object
            // it will invoke the ep.evt delegate if the balance exceeds 250
            EP.CheckBalance(251);


        }
    }

    public class EvtPublisher
    {
        public delegate void del(string x);

        public event del Evt;

        public void CheckBalance (int x)
        {
            if (x >= 250)
            {
                Evt("ATTENTION!!! The current balance exceeds 250...");
            }
            else
                Evt("Correct Balance");

        }
    }

    public class EvtSubscriber
    {
        public void HandleTheEvent(string a)
        {
            Console.WriteLine(a);
        }
    }
}
