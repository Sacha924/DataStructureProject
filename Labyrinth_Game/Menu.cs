using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Labyrinth_Game
{
    class Menu
    {
        int selectedIndex;
        string[] options;
        string prompt;

        public Menu(string _prompt, string[] _options)
        {
            this.prompt = _prompt;
            this.options = _options;
            selectedIndex = 0;
        }
        public void DisplayOptions()
        {
            WriteLine(prompt);
            for(int i =0; i< options.Length; i++)
            {
                string currentOption = options[i];
                string prefix;
                if (i == selectedIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine($"{prefix}<<{currentOption}>>");
            }
            ResetColor();

        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                PrimaryMenu();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex ==-1)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if (selectedIndex == options.Length)
                    {
                        selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter); //when we press enter, we valid the option that we want so we leave the loop
            return selectedIndex;
        }
        static void PrimaryMenu()
        {
            string a = " ██▓    ▄▄▄       ▄▄▄▄ ▓██   ██▓ ██▀███   ██▓ ███▄    █ ▄▄▄█████▓ ██░ ██  ";
            string b = "▓██▒   ▒████▄    ▓█████▄▒██  ██▒▓██ ▒ ██▒▓██▒ ██ ▀█   █ ▓  ██▒ ▓▒▓██░ ██▒ ";
            string c = "▒██░   ▒██  ▀█▄  ▒██▒ ▄██▒██ ██░▓██ ░▄█ ▒▒██▒▓██  ▀█ ██▒▒ ▓██░ ▒░▒██▀▀██░ ";
            string d = "▒██░   ░██▄▄▄▄██ ▒██░█▀  ░ ▐██▓░▒██▀▀█▄  ░██░▓██▒  ▐▌██▒░ ▓██▓ ░ ░▓█ ░██  ";
            string e = "░██████▒▓█   ▓██▒░▓█  ▀█▓░ ██▒▓░░██▓ ▒██▒░██░▒██░   ▓██░  ▒██▒ ░ ░▓█▒░██▓ ";
            string f = "░ ▒░▓  ░▒▒   ▓▒█░░▒▓███▀▒ ██▒▒▒ ░ ▒▓ ░▒▓░░▓  ░ ▒░   ▒ ▒   ▒ ░░    ▒ ░░▒░▒ ";
            string g = "░ ░ ▒  ░ ▒   ▒▒ ░▒░▒   ░▓██ ░▒░   ░▒ ░ ▒░ ▒ ░░ ░░   ░ ▒░    ░     ▒ ░▒░ ░ ";
            string h = "  ░ ░    ░   ▒    ░    ░▒ ▒ ░░    ░░   ░  ▒ ░   ░   ░ ░   ░       ░  ░░ ░ ";
            string i = "    ░  ░     ░  ░ ░     ░ ░        ░      ░           ░           ░  ░  ░ ";
            string j = "                       ░░ ░                                               ";
            string k = "  ▄████  ▄▄▄       ███▄ ▄███▓▓█████ ";
            string l = " ██▒ ▀█▒▒████▄    ▓██▒▀█▀ ██▒▓█   ▀ ";
            string m = "▒██░▄▄▄░▒██  ▀█▄  ▓██    ▓██░▒███   ";
            string n = "░▓█  ██▓░██▄▄▄▄██ ▒██    ▒██ ▒▓█  ▄ ";
            string o = "░▒▓███▀▒ ▓█   ▓██▒▒██▒   ░██▒░▒████▒";
            string p = " ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ░  ░░░ ▒░ ░";
            string q = "  ░   ░   ▒   ▒▒ ░░  ░      ░ ░ ░  ░";
            string r = "  ░ ░   ░   ░   ▒   ░      ░      ░ ";
            string s = "   ░       ░  ░       ░      ░  ░   ";

            ForegroundColor = ConsoleColor.DarkRed;
            Write("".PadLeft(80) + a + "\n");
            ForegroundColor = ConsoleColor.Red;
            Write("".PadLeft(80) + b + "\n");
            ForegroundColor = ConsoleColor.DarkYellow;
            Write("".PadLeft(80) + c + "\n");
            ForegroundColor = ConsoleColor.Yellow;
            Write("".PadLeft(80) + d + "\n");
            ForegroundColor = ConsoleColor.DarkMagenta;
            Write("".PadLeft(80) + e + "\n");
            ForegroundColor = ConsoleColor.Magenta;
            Write("".PadLeft(80) + f + "\n");
            ForegroundColor = ConsoleColor.DarkBlue;
            Write("".PadLeft(80) + g + "\n");
            ForegroundColor = ConsoleColor.Blue;
            Write("".PadLeft(80) + h + "\n");
            ForegroundColor = ConsoleColor.Cyan;
            Write("".PadLeft(80) + i + "\n");
            ForegroundColor = ConsoleColor.Cyan;
            Write("".PadLeft(80) + j + "\n");
            ForegroundColor = ConsoleColor.DarkCyan;
            Write("".PadLeft(80) + j + "\n\n");
            ForegroundColor = ConsoleColor.DarkGreen;
            Write("".PadLeft(80 + (a.Length) / 4) + k + "\n");
            ForegroundColor = ConsoleColor.DarkBlue;
            Write("".PadLeft(80 + (a.Length) / 4) + l + "\n");
            ForegroundColor = ConsoleColor.DarkRed;
            Write("".PadLeft(80 + (a.Length) / 4) + m + "\n");
            ForegroundColor = ConsoleColor.Red;
            Write("".PadLeft(80 + (a.Length) / 4) + n + "\n");
            ForegroundColor = ConsoleColor.White;
            Write("".PadLeft(80 + (a.Length) / 4) + o + "\n");
            ForegroundColor = ConsoleColor.DarkGray;
            Write("".PadLeft(80 + (a.Length) / 4) + p + "\n");
            ForegroundColor = ConsoleColor.Gray;
            Write("".PadLeft(80 + (a.Length) / 4) + q + "\n");
            ForegroundColor = ConsoleColor.Magenta;
            Write("".PadLeft(80 + (a.Length) / 4) + r + "\n");
            ForegroundColor = ConsoleColor.DarkMagenta;
            Write("".PadLeft(80 + (a.Length) / 4) + s + "\n");
            ForegroundColor = ConsoleColor.White;
        }


    }
}
