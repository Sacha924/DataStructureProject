using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth_Game
{
    class Position
    {

        public int line;
        public int column;

        public Position(int _line, int _column)
        {
            if (line >= 0) this.line = _line;
            else this.line = -1;   
            if (column >= 0) this.column = _column;
            else this.column = -1;
        }

        public override string ToString()
        {
            string a = "vous êtes actuellement positionné sur la ligne " + this.line + " et sur la colonne " + this.column;
            if (this.line < 0) a = a + "\n Attention, vous avez saisi une valeur de ligne invalide ! Le code d'erreur -1 lui a été assimilé";
            if (this.column < 0) a = a + "\n Attention, vous avez saisi une valeur de colonne invalide ! Le code d'erreur -1 lui a été assimilé";
            return a;
        }
        public bool IsEqual(Position pos)
        {
            if (this.line == pos.line && this.column == pos.column) return true;
            else return false;
        }
    }
}
