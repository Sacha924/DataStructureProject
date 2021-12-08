using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;


namespace Labyrinth_Game
{
    class Driver
    {

        static void RunMenu()
        {
            string prompt = "welcome to the labyrinth game, what would you like to do ?";
            string[] options = { "play original labyrinth","play classic labyrinth", "Rules" };
            Menu menu = new Menu(prompt, options);
            menu.DisplayOptions();
            int selectedIndex = menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunFirstCase();
                    break;
                case 1:
                    RunSecondCase();
                    break;
                case 2:
                    RunThirdCase(); 
                    break;
                
            }
        }

        static void RunFirstCase()
        {
            Clear();
            string[] schema = { "███████████████████████████",
                                "█  e                      █",
                                "█ ███████████████████████ █",
                                "█ █   ███████████████  s█ █",
                                "█ █ █     ██ █*      █  █ █",
                                "█ █      ████  █     █  █ █",
                                "█ █     █  █     ██  █  █ █",
                                "█ █ █       ███     *█  █ █",
                                "█ █     █          █   *█ █",
                                "█ █☻█   █  █         █  █ █",
                                "█ █          █  ██ █    █ █",
                                "█ ███████████████████████ █",
                                "█                         █",
                                "███████████████████████████" };
            DateTime maxPlayerTime = DateTime.Now.AddSeconds(60);
            GameCreation(schema, maxPlayerTime);
        }

        static void RunSecondCase()
        {
            Clear();
            string[] schema = File.ReadAllLines("lab.txt");
            DateTime maxPlayerTime = DateTime.Now.AddSeconds(120);
            GameCreation(schema, maxPlayerTime);
        }

        static void GameCreation(string [] schema, DateTime maxPlayerTime)
        {
            Labyrinth lab = new Labyrinth(schema);
            WriteLine(lab.ToString());
            DateTime currentTime = DateTime.Now;
            Person pers = new Person(lab);
            while (pers.Arrived() == false && pers.GameOver() == false && currentTime < maxPlayerTime)
            {
                pers.NextMove();
                Clear();
                WriteLine(lab.ToString());
                currentTime = DateTime.Now;
            }
            if (currentTime > maxPlayerTime) WriteLine("you lost because you exceeded the maximum time allowed");
        }

        static void RunThirdCase()
        {
            Clear();
            string display = @"Here are the rules: 


- You start at point s (start) and must arrive at point e (exit)

- The '*' kill you

- You move with the arrows of your keyboard

- Each time you pass somewhere, you condemn the cell and can't go back to it

- You can't go through walls, except if you step on the cell ☻ which will allow you to jump the walls only once

- if you get stuck, you will automatically lose.

Have fun";
            WriteLine(display);
        }
        
        public void RunProgram()
        {
            SetWindowSize(240, 63);
            ConsoleKeyInfo cki;
            do
            {
                RunMenu(); 
                WriteLine("press escape to exit, or any other key to go back to the menu");
                cki = ReadKey();
            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
