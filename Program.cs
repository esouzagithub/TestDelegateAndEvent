using System;

namespace appDelegateAndEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person();
            // 1 - Exemplo de utilização
            //p.CashEvent += () => Console.WriteLine("Person has gained 100 dollars");
            
            // 2 - Exemplo de utilização
            p.CashEvent += P_CashEvent;
            p.AddCash(150);
            p.AddCash(20);
            p.AddCash(50);
            Console.ReadKey();
        }

        // 2 - Exemplo de utilização
        private static void P_CashEvent()
        {
            Console.WriteLine("Person has gained 100 dollars");
        }

        public class Person
        {
            public delegate void MyEventHandler();
            public event MyEventHandler CashEvent;
            private int _cash;

            protected virtual void OnCashEvent()
            {
                CashEvent?.Invoke();
            }

            public int Cash
            {
                get { return _cash; }
                set
                {
                    _cash = value;
                    if (_cash >= 100)
                    {
                        OnCashEvent();
                        //CashEvent?.Invoke();
                    }
                }
            }

            public void AddCash(int amount)
            {
                Cash += amount;
            }

        }
    }
}
