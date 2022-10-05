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
            new FootballPlayer{Id = _nexId++, Name = "Modric", Age = 28, ShirtNumber = 8},
            new FootballPlayer{Id = _nexId++, Name = "Modric", Age = 31, ShirtNumber = 27},
        };
    }
}
                        