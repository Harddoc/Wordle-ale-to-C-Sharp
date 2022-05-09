using System;
using System.Collections.Generic;
using System.Linq;

namespace program_1
{
    class Program
    {

        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.Green;


            int guess_index = 0;
            string guess = "a";
            //do zmienienia na liste słów na 5 liter.
            string zagatka = "polka";
            char[] zagadkaCharA = zagatka.ToCharArray();
            char[] fake_litery = { };
            char[] dobre_litery = zagatka.ToCharArray();
            int index_of_letter = 0;
            char[] abc = { 'a' };
            List<char> spokoLitery = new List<char>();

            List<Wybor> wybors = new List<Wybor>();

            //6 loop na 6 prób
            while (guess_index <= 5)
            {

                Intro();
                guess = Console.ReadLine();
                //tutaj error control kurwa wstaw debilu

                while (!Error_controle(guess))
                {
                    guess = Console.ReadLine();

                }



                //else break;
                Console.Clear();
                Intro();
                char[] guessCharA = guess.ToCharArray();
                //nowy obiekt wyboru
                wybors.Add(new Wybor(guessCharA, zagadkaCharA));

                
                foreach (Wybor wybor in wybors)
                {
                        //Console.WriteLine("test");
                        wybor.Wkwadracie();
                }

                if (zagatka == guess)
                {

                    Console.WriteLine("Udało sie za {0} razem!", guess_index + 1);
                    foreach (Wybor wybor in wybors)
                    {
                        wybor.Wkwadracie();
                    }
                    Console.Read();
                    return;
                }


              


                foreach (char litera in guessCharA)
                {
                    index_of_letter = 0;
                    //Console.WriteLine(litera);

                    foreach (char dobraL in zagadkaCharA)
                    {
                        index_of_letter++;


                        if (dobraL == litera)
                        {
                            //!impotrant
                            //Console.Write(litera + " znajduje sie w słowaie na miejscu {0} \n", index_of_letter);
                        }
                        else
                        {

                            //dodajemy wszystkie litery do array
                            fake_litery = fake_litery.Append(litera).ToArray();

                            //tworzymy liste składającą sie ze wszystkich liter.
                            List<char> fake_li = new List<char>();
                            fake_li = fake_litery.ToList();
                            //usuwanie poprawnych litery z kolekcji wpisanych liter
                            foreach (char item in dobre_litery)
                            {
                                fake_li.Remove(item);
                            }

                            fake_litery = fake_li.ToArray();

                        }
                    }
                }

                fake_litery = fake_litery.Distinct().ToArray();
                Console.Write("nie ma w tym słowie liter: ");
                foreach (char f_litera in fake_litery)
                {
                    Console.BackgroundColor = ConsoleColor.Red;

                    Console.Write("{0},", f_litera);

                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
                guess_index++;
                //Console.Clear();
            }

            Console.WriteLine("game over");
            Console.ReadLine();

        }


        struct Wybor
        {

            public char[] guessCharA { get; set; }
            public char[] zagadkaCharA { get; }

            public Wybor(char[] guessCharA, char[] zagadkaCharA)
            {
                this.guessCharA = guessCharA;
                this.zagadkaCharA = zagadkaCharA;
            }
            
            public void Wkwadracie()
            {
                int IndexOfChar = 0;
                Console.Write("                                              ");
                for (IndexOfChar = 0; IndexOfChar <= 4; IndexOfChar++)
                {
                    //Console.Write(zagadkaCharA.ToList().IndexOf(guessCharA[IndexOfChar]));

                    if (zagadkaCharA[IndexOfChar] == guessCharA[IndexOfChar])
                    {
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("[{0}]", guessCharA[IndexOfChar]);
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (zagadkaCharA.ToList().IndexOf(guessCharA[IndexOfChar]) != -1)
                    {
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.DarkYellow;
                        Console.Write("[{0}]", guessCharA[IndexOfChar]);
                        Console.BackgroundColor = ConsoleColor.Black;

                    }
                    else
                    {
                        Console.Write("  ");
                        Console.Write("[{0}]", guessCharA[IndexOfChar]);
                    }
                    
                }
                Console.WriteLine();

            }
        }
        public static bool Error_controle(string guessCharA)
        {
            if (guessCharA.Length != 5)
            {
                //Console.WriteLine();
                Console.SetCursorPosition(0, 27);
                Console.WriteLine("słowo powinno zawierac 5 liter \nwpisz ponownie:");
                return false;
            }
            else return true;

        }

        static void Intro()
         {
            //ekran startowy
            int maxKolom = Console.WindowWidth - 1;
            //Console.SetCursorPosition(10, 1);
            Console.Write("________________________________________________________________________________________________________________________\n");
            Console.SetCursorPosition(10, 2);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@" .----------------. ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@" .----------------. ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@" .----------------. ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@" .----------------. ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@".----------------.  ");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(10, 3);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@"| .--------------. |");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"| .--------------. |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| .--------------. |");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| .--------------. |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| .--------------. |");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(10, 4);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@"| |    _______   | |");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"| |   _____      | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |     ____     | |");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| | _____  _____ | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |      __      | |");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(10, 5);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@"| |   /  ___  |  | |");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"| |  |_   _|     | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |   .'    `.   | |");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| ||_   _||_   _|| |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |     /  \     | |");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(10, 6);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@"| |  |  (__ \_|  | |");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"| |   _| |_      | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |  /  .--.  \  | |");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| |  | | /\ | |  | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |    / /\ \    | |");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(10, 7);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@"| |   '.___`-.   | |");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"| |  |_   _| _   | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |  | |    | |  | |");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| |  | |/  \| |  | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |   / ____ \   | |");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(10, 8);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@"| |  |`\____) |  | |");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"| |   _| |__/ |  | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |  \  `--'  /  | |");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| |  |   /\   |  | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| | _/ /    \ \_ | |");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(10, 9);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@"| |  |_______.'  | |");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"| |  |________|  | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |   `.____.'   | |");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| |  |__/  \__|  | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| ||____|  |____|| |");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(10, 10);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@"| |              | |");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"| |              | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |              | |");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| |              | |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| |              | |");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(10, 11);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@"| '--------------' |");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@"| '--------------' |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| '--------------' |");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"| '--------------' |");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@"| '--------------' |");
            Console.BackgroundColor = ConsoleColor.Black;


            Console.SetCursorPosition(10, 12);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.Write(@" '----------------' ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write(@" '----------------' ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@" '----------------' ");
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.Write(@" '----------------' ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(@" '----------------' " + "\n");
            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write("________________________________________________________________________________________________________________________\n");

            Console.WriteLine("Wpisz słowo na 5 liter: ");
         }

    }

}

