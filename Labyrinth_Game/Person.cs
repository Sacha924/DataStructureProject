using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Labyrinth_Game
{
    class Person
    { 
        public Labyrinth labyrinth;
        public Position currentPos;
        
        public Person(Labyrinth _labyrinth)
        {
            this.labyrinth = _labyrinth;
            currentPos = labyrinth.start;
            labyrinth.MarkPassage(currentPos, currentPos, false, false);
        }

        public bool Arrived()
        {
            bool result = false;
            //Console.WriteLine(posCourante.toString());
            //Console.WriteLine(laby.Arrivee.toString());
            if (currentPos.IsEqual(labyrinth.end))
            {
                result = true;
                ForegroundColor = ConsoleColor.Green;
                
                string display = @"

      o__ __o                                                                o                    o                 o        o                                      
     /v     v\                                                              <|>                  <|>               <|>     _<|>_                                    
    />       <\                                                             < >                  / \               < >                                              
  o/               o__ __o    \o__ __o     o__ __o/  \o__ __o     o__ __o/   |       o       o   \o/     o__ __o/   |        o      o__ __o    \o__ __o       __o__ 
 <|               /v     v\    |     |>   /v     |    |     |>   /v     |    o__/_  <|>     <|>   |     /v     |    o__/_   <|>    /v     v\    |     |>     />  \  
  \\             />       <\  / \   / \  />     / \  / \   < >  />     / \   |      < >     < >  / \   />     / \   |       / \   />       <\  / \   / \     \o     
    \         /  \         /  \o/   \o/  \      \o/  \o/        \      \o/   |       |       |   \o/   \      \o/   |       \o/   \         /  \o/   \o/      v\    
     o       o    o       o    |     |    o      |    |          o      |    o       o       o    |     o      |    o        |     o       o    |     |        <\   
     <\__ __/>    <\__ __/>   / \   / \   <\__  < >  / \         <\__  / \   <\__    <\__ __/>   / \    <\__  / \   <\__    / \    <\__ __/>   / \   / \  _\o__</   
                                                 |                                                                                                                  
                                         o__     o                                                                                                                  
                                         <\__ __/>                                                                                                                  
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
";
                string display2 = @"
      _____                   _______                   _____                                    _____                   _______                   _____                  
     |\    \                 /::\    \                 /\    \                                  /\    \                 /::\    \                 /\    \                 
     |:\____\               /::::\    \               /::\____\                                /::\____\               /::::\    \               /::\____\                
     |::|   |              /::::::\    \             /:::/    /                               /:::/    /              /::::::\    \             /::::|   |                
     |::|   |             /::::::::\    \           /:::/    /                               /:::/   _/___           /::::::::\    \           /:::::|   |                
     |::|   |            /:::/~~\:::\    \         /:::/    /                               /:::/   /\    \         /:::/~~\:::\    \         /::::::|   |                
     |::|   |           /:::/    \:::\    \       /:::/    /                               /:::/   /::\____\       /:::/    \:::\    \       /:::/|::|   |                
     |::|   |          /:::/    / \:::\    \     /:::/    /                               /:::/   /:::/    /      /:::/    / \:::\    \     /:::/ |::|   |                
     |::|___|______   /:::/____/   \:::\____\   /:::/    /      _____                    /:::/   /:::/   _/___   /:::/____/   \:::\____\   /:::/  |::|   | _____          
     /::::::::\    \ |:::|    |     |:::|    | /:::/____/      /\    \                  /:::/___/:::/   /\    \ |:::|    |     |:::|    | /:::/   |::|   |/\    \         
    /::::::::::\____\|:::|____|     |:::|    ||:::|    /      /::\____\                |:::|   /:::/   /::\____\|:::|____|     |:::|    |/:: /    |::|   /::\____\        
   /:::/~~~~/~~       \:::\    \   /:::/    / |:::|____\     /:::/    /                |:::|__/:::/   /:::/    / \:::\    \   /:::/    / \::/    /|::|  /:::/    /        
  /:::/    /           \:::\    \ /:::/    /   \:::\    \   /:::/    /                  \:::\/:::/   /:::/    /   \:::\    \ /:::/    /   \/____/ |::| /:::/    /         
 /:::/    /             \:::\    /:::/    /     \:::\    \ /:::/    /                    \::::::/   /:::/    /     \:::\    /:::/    /            |::|/:::/    /          
/:::/    /               \:::\__/:::/    /       \:::\    /:::/    /                      \::::/___/:::/    /       \:::\__/:::/    /             |::::::/    /           
\::/    /                 \::::::::/    /         \:::\__/:::/    /                        \:::\__/:::/    /         \::::::::/    /              |:::::/    /            
 \/____/                   \::::::/    /           \::::::::/    /                          \::::::::/    /           \::::::/    /               |::::/    /             
                            \::::/    /             \::::::/    /                            \::::::/    /             \::::/    /                /:::/    /              
                             \::/____/               \::::/    /                              \::::/    /               \::/____/                /:::/    /               
                              ~~                      \::/____/                                \::/____/                 ~~                      \::/    /                
                                                       ~~                                       ~~                                                \/____/                 
                                                                                                                                                                          
";
                WriteLine(display + display2);
            }

            return result;
        }
        public void NextMove()
        {   
            int line = -1; 
            int col = -1;
            bool gameOverSpike = false; //initially false, if the next position will be on a peak, gameOverSpike --> true
            //this parameter, called in the MarkPassage method, allows not to erase the spike if we go on it.
            bool jumpBoostCase = false; // initially false, if the next position will be on the JumpBoost, gameOverSpike --> true
            //this parameter, called in the MarkPassage method, allows not to erase the JumpBoost box if we go on it.
            ConsoleKeyInfo cki;
            do
            {
                cki = ReadKey();
            }
            while (cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.UpArrow && cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.DownArrow);
            //the user presses a key until it is an arrow

            switch (cki.Key)    //changes row and column values according to the direction of the arrow
            {
                case ConsoleKey.LeftArrow:
                    line = currentPos.line;
                    col = currentPos.column-1;
                    break;
                case ConsoleKey.UpArrow:
                    line = currentPos.line - 1;
                    col = currentPos.column;
                    break;
                case ConsoleKey.RightArrow:
                    line = currentPos.line;
                    col = currentPos.column +1;
                    break;
                case ConsoleKey.DownArrow:
                    line = currentPos.line + 1;
                    col = currentPos.column;
                    break;
            }
               
            Position newPos = new Position(line, col); //initialize the future position according
            if (labyrinth.IsASpike(newPos) == true) gameOverSpike = true;   // see if you are on the jumpboost cell, if so gameOverSpike = true
            if (labyrinth.IsAJumpBoost(newPos) == true) jumpBoostCase = true; // see if you are on the jumpboost cell, if so canJump = true


            if (labyrinth.MarkPassage(newPos, currentPos, gameOverSpike, jumpBoostCase) ==true)
            {
                int lineDirection = currentPos.line - newPos.line;  // direction in which we go in abscissa, takes the values 0, -1 or 1
                int columnDirection = currentPos.column - newPos.column; // direction in which we go in ordinate, takes the values 0, -1 or 1
                while (labyrinth.IsAWall(newPos) == true)
                {
                    //if you don't have the jumpwall ability or if you don't cross a wall, then currenPos = newPos. But if you have crossed a wall, 
                    //then you have to modify the value of NewPos (because you can't be on a wall, you only pass over it) until it doesn't correspond 
                    //to a wall anymore, while respecting the direction the user was going.
                    newPos = new Position(newPos.line - lineDirection, newPos.column - columnDirection);
                }
                currentPos = newPos; //our currentPos is now the one we just went to
            }



        }
        public bool GameOver() //game over if you are on a *, or if you can't move
        {
            bool res = false;
            if(labyrinth.IsASpike(currentPos) == true || labyrinth.Blocked(currentPos) == true )
            {
                res = true;
            }
            return res;
        }

    }
}
