using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.MVVM.Model
{
    class PlayerModel
    {
        public string Username { get; set; }

        public uint Id { get; set; }

        public CharacterModel Character1 { get; set; }
        public CharacterModel Character2 { get; set; }
        public CharacterModel Character3 { get; set; }
    }
}
