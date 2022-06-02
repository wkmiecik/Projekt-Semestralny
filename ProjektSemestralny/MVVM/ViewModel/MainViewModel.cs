using ProjektSemestralny.Core;
using ProjektSemestralny.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private PlayersDBEntities playersDBEntities;
        public ObservableCollection<player> Players { get; set; }
        

        private player _selectedPlayer { get; set; }
        public player SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                _selectedPlayer = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            playersDBEntities = new PlayersDBEntities();
            Players = new ObservableCollection<player>(playersDBEntities.players);

            SelectedPlayer = Players[0];
        }
    }
}
