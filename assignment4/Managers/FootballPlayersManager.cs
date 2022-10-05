using assignment1;

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

        public IEnumerable<FootballPlayer> GetAll()
        {
            if (players.Count <= 0 || players == null)
                return Enumerable.Empty<FootballPlayer>();

            return new List<FootballPlayer>(players);
        }

        public FootballPlayer GetById(int id)
        {
            var player = players.Find(player => player.Id == id);

            if (player == null)
                throw new ArgumentException("Player with that ID doesn't exist.");

            return player;
        }

        public FootballPlayer Add(FootballPlayer player)
        {
            player.Id = _nexId++;

            // Validator functions can throw ArgumentOutOfRangeException
            // as per the implementation in the assignment 1 dependency
            // the comment is here because of bad documentation 🙃 
            player.ValidateName();
            player.ValidateAge();
            player.ValidateNo();

            players.Add(player);
            return player;
        }

        public FootballPlayer Update(int id, FootballPlayer value)
        {
            // Get by can throw ArgumentException
            var player = GetById(id);

            // Validator functions can throw ArgumentOutOfRangeException
            // as per the implementation in the assignment 1 dependency
            // the comment is here because of bad documentation 🙃 
            value.ValidateName();
            value.ValidateAge();
            value.ValidateNo();

            (player.Name, player.Age, player.ShirtNumber) = (value.Name, value.Age, value.ShirtNumber);

            return player;
        }

        public FootballPlayer Delete(int id)
        {
            var player = GetById(id);

            players.Remove(player);

            return player;
        }
    }
}
