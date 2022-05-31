using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.MVVM.Model
{
    class CharacterModel
    {
        public string? Name { get; set; }
        public int Level { get; set; }
        public DateTime CreationDate { get; set; }

        public uint Id { get; set; }

        public ObservableCollection<EquipmentModel>? Equipment { get; set; }
    }
}
