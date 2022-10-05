using assignment1;
using Microsoft.AspNetCore.Mvc;

namespace assignment4.Managers
{
    public class FootballPlayersManager
    {
        private static int _nexId = 1;

        public static readonly List<FootballPlayer> players = new()
        {
            new FootballPlayer{Id = _nexId++, Name = "Modric", Age = 37, ShirtNumber = 10},
            new FootballPlayer{Id = _nexId++, Name = "Perisic", Age = 33, ShirtNumber = 14},
            new FootballPlayer{Id = _nexId++, Name = "Kovacic", Age = 28, ShirtNumber = 8},
            new FootballPlayer{Id = _nexId++, Name = "Kramaric", Age = 31, ShirtNumber = 27},
        };

        internal IEnumerable<FootballPlayer> GetAll()
        {
            return new List<FootballPlayer>(players);
        }

        internal FootballPlayer GetById(int id)
        {
            return players.Find(player => player.Id == id);
        }

        internal FootballPlayer Add(FootballPlayer player)
        {
            player.Id = _nexId++;

            player.ValidateName();
            player.ValidateAge();
            player.ValidateNo();

            players.Add(player);
            return player;
        }

        internal FootballPlayer Update(int id, FootballPlayer value)
        {
            var player = GetById(id);

            value.ValidateName();
            value.ValidateAge();
            value.ValidateNo();

            (player.Name, player.Age, player.ShirtNumber) = (value.Name, value.Age, value.ShirtNumber);

            return player;
        }

        internal FootballPlayer Delete(int id)
        {
            var player = GetById(id);

            players.Remove(player);

            return player;
        }
    }
}
