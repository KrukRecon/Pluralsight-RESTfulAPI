using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TicTacToe.Commands;
using TicTacToe.Models;

namespace TicTacToe.View
{
    public class MainView : INotifyPropertyChanged
    {
        private Board board = new Board();
        private ICommand _fieldCommand;
        private ICommand _resetGame;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand FieldCommand => _fieldCommand ?? (_fieldCommand = new RelayCommand(FieldAction, FieldExecute));

        public ICommand ResetGame => _resetGame ?? (_resetGame = new RelayCommand(NewGame, ReturnTrue));

        public string[] Chars => board.chars;

        public string WinText => board.winText;

        public string Player => board.player ? "X" : "O";

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void FieldAction(object o)
        {
            try
            {
                int.TryParse(o.ToString(), out var field);
                board.chars[field] = board.player ? "X" : "O";
                board.player = !board.player;

                if (board.solve())
                {
                    board.fill();
                    OnPropertyChanged("WinText");
                }

                OnPropertyChanged("Chars");
                OnPropertyChanged("Player");
            }
            catch
            {
                // ignored
            }
        }

        private bool FieldExecute(object o)
        {
            try
            {
                if (o == null) return true;
                int.TryParse(o.ToString(), out var field);
                return board.chars[field] == null;
            }
            catch
            {
                return true;
            }
        }

        private void NewGame(object o)
        {
            try
            {

                board.chars = new string[9];
                board.player = true;
                board.winText = "";
                OnPropertyChanged("Chars");
                OnPropertyChanged("WinText");
                OnPropertyChanged("Player");
            }
            catch
            {
                // ignored
            }
        }

        private bool ReturnTrue(object o)
        {
            return true;
        }
    }
}
