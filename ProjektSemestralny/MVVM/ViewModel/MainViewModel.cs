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
        //public ObservableCollection<PlayerModel> Players { get; set; }

        //public PlayerModel _selectedPlayer { get; set; }
        //public PlayerModel SelectedPlayer
        //{
        //    get => _selectedPlayer;
        //    set
        //    {
        //        _selectedPlayer = value;
        //        OnPropertyChanged();
        //    }
        //}



        //private object _currentView;
        //public object CurrentView
        //{
        //    get => _currentView;
        //    set
        //    {
        //        _currentView = value;
        //        OnPropertyChanged();
        //    }
        //}

        
        public ObservableCollection<player> Players { get; set; }

        public player _selectedPlayer { get; set; }
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
            PlayersDBEntities playersDBEntities = new PlayersDBEntities();
            Players = new ObservableCollection<player>(playersDBEntities.players);



            //// Fill up players list with dummy data
            //Players = new ObservableCollection<PlayerModel>();

            //for (int i = 1; i < 1500; i++)
            //{
            //    var eq = new ObservableCollection<EquipmentModel>();
            //    for (int j = 1; j <= 30; j++)
            //    {
            //        eq.Add(new EquipmentModel()
            //        {
            //            Name = $"Eq {j}",
            //            Quantity = 3,
            //            Id = (uint)(j*i)
            //        });
            //    }

            //    var char1 = new CharacterModel()
            //    {
            //        Name = $"Character {i}1",
            //        Level = 1,
            //        CreationDate = DateTime.Now,
            //        Equipment = eq
            //    };
            //    var char2 = new CharacterModel()
            //    {
            //        Name = $"Character {i}2",
            //        Level = 1,
            //        CreationDate = DateTime.Now,
            //        Equipment = eq
            //    };
            //    var char3 = new CharacterModel()
            //    {
            //        Name = $"Character {i}3",
            //        Level = 1,
            //        CreationDate = DateTime.Now,
            //        Equipment = eq
            //    };

            //    Players.Add(new PlayerModel() 
            //    { 
            //        Username = $"User {i}",
            //        Id = (uint)i - 1,
            //        Character1 = char1,
            //        Character2 = char2,
            //        Character3 = char3
            //    });
            //}

            //_selectedPlayer = Players[0];
        }
    }
}
