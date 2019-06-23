using System.Collections.Generic;

namespace EscapeMines.Model
{
    public class GameContext
    {
        private List<List<string>> _commandList;
        private GameSize _gameSize;
        private List<GameCoordinate> _mineCoordinates;
        private GameCoordinate _exitPoint;
        private TurtlePosition _startPosition;

        public GameSize GameSize
        {
            get => _gameSize;
            set => _gameSize = value;
        }

        public List<GameCoordinate> MineCoordinates
        {
            get => _mineCoordinates;
            set => _mineCoordinates = value;
        }

        public GameCoordinate ExitPoint
        {
            get => _exitPoint;
            set => _exitPoint = value;
        }

        public TurtlePosition StartPosition
        {
            get => _startPosition;
            set => _startPosition = value;
        }

        public List<List<string>> CommandList
        {
            get => _commandList;
            set => _commandList = value;
        }
    }

}

