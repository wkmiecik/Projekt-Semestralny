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

        public ICommand Character0EditCommand { get; set; }
        public ICommand Character1EditCommand { get; set; }
        public ICommand Character2EditCommand { get; set; }
        public ICommand CharacterAddCommand { get; set; }
        public ICommand Character0RemoveCommand { get; set; }
        public ICommand Character1RemoveCommand { get; set; }
        public ICommand Character2RemoveCommand { get; set; }


        private player _selectedPlayer { get; set; }
        private characters_equipment selectedEquipment0;
        private characters_equipment selectedEquipment1;
        private characters_equipment selectedEquipment2;
        public player SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                _selectedPlayer = value;

                char0Exists = false;
                char1Exists = false;
                char2Exists = false;

                if (_selectedPlayer.characters.Count == 1)
                {
                    char0Exists = true;
                }
                else if (_selectedPlayer.characters.Count == 2)
                {
                    char0Exists = true;
                    char1Exists = true;
                }
                else if (_selectedPlayer.characters.Count == 3)
                {
                    char0Exists = true;
                    char1Exists = true;
                    char2Exists = true;
                }

                notChar0Exists = !char0Exists;
                notChar1Exists = !char1Exists;
                notChar2Exists = !char2Exists;

                OnPropertyChanged();
            }
        }

        public characters_equipment SelectedEquipment0
        {
            get => selectedEquipment0;
            set 
            {
                selectedEquipment0 = value;
                OnPropertyChanged();
            }
        }
        public characters_equipment SelectedEquipment1
        {
            get => selectedEquipment1;
            set
            {
                selectedEquipment1 = value;
                OnPropertyChanged();
            }
        }
        public characters_equipment SelectedEquipment2
        {
            get => selectedEquipment2;
            set
            {
                selectedEquipment2 = value;
                OnPropertyChanged();
            }
        }


        private bool _char0Exists = false;
        private bool _char1Exists = false;
        private bool _char2Exists = false;
        private bool _notChar0Exists = true;
        private bool _notChar1Exists = true;
        private bool _notChar2Exists = true;

        public bool notChar0Exists
        {
            get => _notChar0Exists;
            set
            {
                _notChar0Exists = value;
                OnPropertyChanged();
            }
        }
        public bool notChar1Exists
        {
            get => _notChar1Exists;
            set
            {
                _notChar1Exists = value;
                OnPropertyChanged();
            }
        }
        public bool notChar2Exists
        {
            get => _notChar2Exists;
            set
            {
                _notChar2Exists = value;
                OnPropertyChanged();
            }
        }
        public bool char0Exists
        {
            get => _char0Exists;
            set
            {
                _char0Exists = value;
                OnPropertyChanged();
            }
        }
        public bool char1Exists
        {
            get => _char1Exists;
            set
            {
                _char1Exists = value;
                OnPropertyChanged();
            }
        }
        public bool char2Exists
        {
            get => _char2Exists;
            set
            {
                _char2Exists = value;
                OnPropertyChanged();
            }
        }



        public MainViewModel()
        {
            playersDBEntities = new PlayersDBEntities();
            Players = new ObservableCollection<player>(playersDBEntities.players.OrderBy(item => item.player_id));
            SelectedPlayer = Players[0];

            PlayerEditCommand = new RelayCommand(o => PlayerEditClick());
            PlayerRemoveCommand = new RelayCommand(o => PlayerRemoveClick());
            PlayerAddCommand = new RelayCommand(o => PlayerAddClick());

            Character0EditCommand = new RelayCommand(o => CharacterEditClick(0));
            Character1EditCommand = new RelayCommand(o => CharacterEditClick(1));
            Character2EditCommand = new RelayCommand(o => CharacterEditClick(2));
            CharacterAddCommand = new RelayCommand(o => CharacterAddClick());
            Character0RemoveCommand = new RelayCommand(o => CharacterRemoveClick(0));
            Character1RemoveCommand = new RelayCommand(o => CharacterRemoveClick(1));
            Character2RemoveCommand = new RelayCommand(o => CharacterRemoveClick(2));
        }


        public void PlayerEditClick()
        {
            EditPlayerWindow inputDialog = new EditPlayerWindow("Change player name:", SelectedPlayer.player_name);
            if (inputDialog.ShowDialog() == true)
            {
                var tempName = SelectedPlayer.player_name;

                SelectedPlayer.player_name = inputDialog.Answer;

                if (playersDBEntities.players.Any(item => item.player_name == SelectedPlayer.player_name))
                {
                    SelectedPlayer.player_name = tempName;
                    new ErrorWindow("Player with this name already exists!").ShowDialog();
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
                        new ErrorWindow("Database error").ShowDialog();
                    }
                }
            }
        }

        public void PlayerRemoveClick()
        {
            var ok = (bool)new ConfirmationWindow("Are you sure you want to delete this player?").ShowDialog();

            if (ok)
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
                    new ErrorWindow("Database error").ShowDialog();
                }
            }
        }

        public void PlayerAddClick()
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
                    new ErrorWindow("Player with this name already exists!").ShowDialog();
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
                        new ErrorWindow("Database error").ShowDialog();
                    }
                }
            }
        }


        public void CharacterEditClick(int character)
        {
            EditCharacterWindow inputDialog = new EditCharacterWindow(SelectedPlayer.characters[character].character_name, SelectedPlayer.characters[character].character_level.ToString());
            if (inputDialog.ShowDialog() == true)
            {
                var tempName = SelectedPlayer.characters[character].character_name;
                var tempLevel = SelectedPlayer.characters[character].character_level;

                SelectedPlayer.characters[character].character_name = inputDialog.NameAnswer;

                try
                {
                    var level = byte.Parse(inputDialog.LevelAnswer);
                    if (level < 1 || level > 100) throw new Exception();
                    SelectedPlayer.characters[character].character_level = level;
                }
                catch
                {
                    SelectedPlayer.characters[character].character_name = tempName;
                    SelectedPlayer.characters[character].character_level = tempLevel;
                    new ErrorWindow("Invalid character level").ShowDialog();
                    return;
                }

                try
                {
                    playersDBEntities.SaveChanges();
                }
                catch
                {
                    SelectedPlayer.characters[character].character_name = tempName;
                    SelectedPlayer.characters[character].character_level = tempLevel;
                    new ErrorWindow("Database error").ShowDialog();
                }
            }
        }

        public void CharacterAddClick()
        {
            EditCharacterWindow inputDialog = new EditCharacterWindow();
            if (inputDialog.ShowDialog() == true)
            {
                character newCharacter;

                try
                {
                    var level = byte.Parse(inputDialog.LevelAnswer);
                    if (level < 1 || level > 100) throw new Exception();
                    newCharacter = new character { character_name = inputDialog.NameAnswer, character_level = level, creation_date = DateTime.Now };
                    SelectedPlayer.characters.Add(newCharacter);
                    SelectedPlayer = SelectedPlayer;
                }
                catch
                {
                    new ErrorWindow("Invalid character level").ShowDialog();
                    return;
                }

                try
                {
                    playersDBEntities.SaveChanges();
                }
                catch
                {
                    SelectedPlayer.characters.Remove(newCharacter);
                    new ErrorWindow("Database error").ShowDialog();
                }
            }
        }

        public void CharacterRemoveClick(int character)
        {
            var ok = (bool)new ConfirmationWindow("Are you sure you want to delete this character?").ShowDialog();

            if (ok)
            {
                playersDBEntities.characters.Remove(SelectedPlayer.characters[character]);
                try
                {
                    playersDBEntities.SaveChanges();
                    SelectedPlayer = SelectedPlayer;
                }
                catch
                {
                    new ErrorWindow("Database error").ShowDialog();
                }
            }
        }
    }
}
