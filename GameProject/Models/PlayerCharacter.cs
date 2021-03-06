using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Game
{
    public class PlayerCharacter : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string NickName { get; set; }
        public bool IsNoob { get; set; }
        public List<string> Weapons { get; set; }
        public event EventHandler<EventArgs> PlayerSlept;
        public event PropertyChangedEventHandler PropertyChanged;

        private int _health = 100;
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, null);
        }

        public PlayerCharacter()
        {
            FirstName = GenerateRandomFirstName();
            IsNoob = true;
            CreateStartingWeapons();
        }

        public void Sleep()
        {

            var healthIncrease = CalculateHealthIncrease();
            Health += healthIncrease;
            OnPlayerSlept(EventArgs.Empty);
        }

        private int CalculateHealthIncrease()
        {
            var rnd = new Random();
            return rnd.Next(1, 101);
        }

        public void CreateStartingWeapons()
        {
            Weapons = new List<string>{
                "Long Bow",
                "Short Bow",
                "Short Sword",
                "Long Hammer",
            };
        }

        protected virtual void OnPlayerSlept(EventArgs e)
        {
            PlayerSlept?.Invoke(this, e);
        }

        public void TakeDamage(int damage) => Health = Math.Max(1, Health -= damage);

        private string GenerateRandomFirstName()
        {

            var possibleNames = new[] {

                "Bruce",
                "Andrian",
                "Nicko",
                "Dave",
                "Steve",
            };

            return possibleNames[new Random().Next(0, possibleNames.Length)];
        }

    }
}
