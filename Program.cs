using System;

namespace AsIs
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent realLife = new Parent();
            Console.WriteLine($"в реальности у нас {realLife.Treasure} шекелей");
            Console.WriteLine(new String('-', 60));

            Console.WriteLine("Тут коллеги спрашивают, сколько ты зарабатываешь");
            Child realApi = new Child();
            realApi.ExtMethod();  //в наследнике понтуясь увеличиваем шекели
            Console.WriteLine(realApi.Treasure);
            Console.WriteLine(new String('-', 60));

            Console.WriteLine("Отвечаем жене, сколько у нас денег"); //тут нас ВНЕЗАПНО спрашивает жена
            Parent forWife = realApi; //апкастим тот самый экземпляр наследника 
            Console.WriteLine(forWife.Treasure);
            Console.WriteLine(new String('-', 60));

            Console.WriteLine("Тут подходит дочь и говорит 'Пап, сколько у тебя шекелей'");
            Child manupulate = (Child)forWife; // даункастим экземпляр для жены
            Console.WriteLine(manupulate.Treasure);
            Console.WriteLine(new String('=', 60));
            // и все эти манипуляции апкаста-даункаста - они с одним экземпляром класса.

            Console.WriteLine("Тут позвонил тебе я и попросил 1000000000 шекелей в долг");
            Parent answer = null;
            answer = manupulate as Parent; //апкастим через As
            Console.WriteLine($"отвечаешь, что у тебя только {answer.Treasure} шекелей");
            if (answer is Parent) //тут проверяем объект
            {
                Console.WriteLine("и кричишь, что ты совсем бедный!");
            }
            else
            {
                Console.WriteLine("Бери конечно и можешь не возвращать");
            }
            Console.WriteLine(new String('-', 60));
        }
    }

    class Parent
    {
        private int _treasure = 100;
        public void Method()
        {
            Console.WriteLine("This is parent ctor");
        }
        public int Treasure => _treasure;
    }

    class Child : Parent
    {
        private int _treasure = 100;
        public void Method()
        {
            Console.WriteLine("This is child ctor");
        }
        public void ExtMethod()
        {
            _treasure = _treasure * 100;
        }
        public int Treasure => _treasure;
    }
}