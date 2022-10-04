using assignment1;

namespace assignment4
{
    public class FootballPlayersManager
    {
        private static int _nextId = 1;

        public static readonly List<FootballPlayer> players = new()
        {
            new FootballPlayer{Id = _nextId++, Name = "Modric", Age = 37, ShirtNumber = 10},
            new FootballPlayer{Id = _nextId++, Name = "Perisic", Age = 33, ShirtNumber = 14},
            new FootballPlayer{Id = _nextId++, Name = "Kovacic", Age = 28, ShirtNumber = 8},
            new FootballPlayer{Id = _nextId++, Name = "Kramaric", Age = 31, ShirtNumber = 27},
        };
    }
}
