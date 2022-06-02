using ProjektSemestralny.Core;
using ProjektSemestralny.MVVM.Model;
using ProjektSemestralny.MVVM.View.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjektSemestralny.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        private PlayersDBEntities playersDBEntities;
        public ObservableCollection<player> Players { get; set; }

        public ICommand PlayerEditCommand { get; set; }
        public ICommand PlayerRemoveCommand { get; set; }
        public ICommand PlayerAddCommand { get; set; }


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
            Players = new ObservableCollection<player>(playersDBEntities.players.OrderBy(item => item.player_id));
            SelectedPlayer = Players[0];

            PlayerEditCommand = new RelayCommand(o => PlayerEditClick("MainButton"));
            PlayerRemoveCommand = new RelayCommand(o => PlayerRemoveClick("MainButton"));
            PlayerAddCommand = new RelayCommand(o => PlayerAddClick("MainButton"));
        }

        
        public void PlayerEditClick(object sender)
        {
            EditPlayerWindow inputDialog = new EditPlayerWindow("Change player name:", SelectedPlayer.player_name);
            if (inputDialog.ShowDialog() == true)
            {
                var tempName = SelectedPlayer.player_name;
                
                SelectedPlayer.player_name = inputDialog.Answer;

                if (playersDBEntities.players.Any(item => item.player_name == SelectedPlayer.player_name))
                {
                    SelectedPlayer.player_name = tempName;
                    MessageBox.Show("Player with this name already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    try
                    {
                        playersDBEntities.SaveChanges();
                    }
                    catch
                    {
                        SelectedPlayer.player_name = tempName;
                        MessageBox.Show("Wrong name given", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public void PlayerRemoveClick(object sender)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this player?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                playersDBEntities.players.Remove(SelectedPlayer);
                try
                {
                    playersDBEntities.SaveChanges();
                    Players.Remove(SelectedPlayer);
                    SelectedPlayer = Players[0];
                }
                catch
                {
                    MessageBox.Show("Database error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void PlayerAddClick(object sender)
        {
            EditPlayerWindow inputDialog = new EditPlayerWindow("New player's name:", iconSource: "/Images/plus.png");
            if (inputDialog.ShowDialog() == true)
            {
                var newPlayer = new player { player_name = inputDialog.Answer };
                Players.Add(newPlayer);
                playersDBEntities.players.Add(newPlayer);

                if (playersDBEntities.players.Any(item => item.player_name == newPlayer.player_name))
                {
                    Players.Remove(newPlayer);
                    MessageBox.Show("Player with this name already exists!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    try
                    {
                        playersDBEntities.SaveChanges();
                        SelectedPlayer = newPlayer;
                    }
                    catch
                    {
                        Players.Remove(newPlayer);
                        MessageBox.Show("Wrong name given", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
