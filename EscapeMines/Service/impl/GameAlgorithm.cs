using System;
using System.Collections.Generic;
using EscapeMines.Model;

namespace EscapeMines.Service.impl
{
    public class GameAlgorithm : IGameAlgorithm
    {
        public GameAlgorithm(GameContext gameContext)
        {
            CalculateGameResults(gameContext);
        }

        /// <summary>
        /// Calculating game movements and write console results.
        /// </summary>
        /// <param name="gameContext">Game context, it is include mapped game settings</param>
        public bool CalculateGameResults(GameContext gameContext)
        {
            if (gameContext == null)
            {
                return false;
            }
            foreach (var line in gameContext.CommandList)
            {
                var currentlyPosition = new CurrentlyPositionAndStatus
                {
                    CoordX = gameContext.StartPosition.CoordX,
                    CoordY = gameContext.StartPosition.CoordY,
                    Direction = gameContext.StartPosition.Direction,
                    Status = (int) GameStatus.NotStarted
                };
                var i = 0;
                foreach (var command in line)
                {
                    try
                    {
                        currentlyPosition = RunCommand(currentlyPosition, gameContext.MineCoordinates, command);
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Unknown Movement");
                        return false;
                    }

                    if (currentlyPosition.Status == (int) GameStatus.MineHit)
                    {
                        Console.WriteLine("Sequence {0}: Mine hit!", gameContext.CommandList.IndexOf(line) + 1);
                        break;
                    }

                    if (i == line.Count - 1)
                    {
                        if (currentlyPosition.CoordX == gameContext.ExitPoint.CoordX &&
                            currentlyPosition.CoordY == gameContext.ExitPoint.CoordY)
                        {
                            Console.WriteLine("Sequence {0}: Success!", gameContext.CommandList.IndexOf(line) + 1);
                            currentlyPosition.Status = (int) GameStatus.Succeed;
                        }
                        else
                        {
                            Console.WriteLine("Sequence {0}: Still in danger!",
                                gameContext.CommandList.IndexOf(line) + 1);
                            currentlyPosition.Status = (int) GameStatus.StillInDanger;
                        }
                    }

                    i++;
                }
            }

            return true;
        }

        private static CurrentlyPositionAndStatus RunCommand(CurrentlyPositionAndStatus currentlyPosition, IEnumerable<GameCoordinate> mineCoordinate, string command)
        {
            var movement = Movements.UnknownMovement;
            movement = (Movements) Enum.Parse(typeof(Movements), command);
            if (movement.Equals(Movements.UnknownMovement))
            {
                throw new ArgumentException();
            }

            switch (movement)
            {
                case Movements.M:
                    currentlyPosition = MoveTurtle(mineCoordinate, currentlyPosition);
                    break;
                case Movements.L:
                    currentlyPosition = RotateLeftTurtle(currentlyPosition);
                    break;
                case Movements.R:
                    currentlyPosition = RotateRightTurtle(currentlyPosition);
                    break;
                case Movements.UnknownMovement:
                    break;
                default:
                    Console.WriteLine("Unknown Movement");
                    break;
            }


            return currentlyPosition;
        }
        private static CurrentlyPositionAndStatus MoveTurtle(IEnumerable<GameCoordinate> mineCoordinates, CurrentlyPositionAndStatus currentlyPosition)
        {
            switch (currentlyPosition.Direction)
            {
                case "N":
                    currentlyPosition.CoordY = currentlyPosition.CoordY - 1;
                    break;
                case "S":
                    currentlyPosition.CoordY = currentlyPosition.CoordY + 1;
                    break;
                case "W":
                    currentlyPosition.CoordX = currentlyPosition.CoordX - 1;
                    break;
                case "E":
                    currentlyPosition.CoordX = currentlyPosition.CoordX + 1;
                    break;
            }
            foreach (var item in mineCoordinates)
            {
                if (item.CoordX == currentlyPosition.CoordX && item.CoordY == currentlyPosition.CoordY)
                {
                    currentlyPosition.Status = (int)GameStatus.MineHit;
                }

            }
            return currentlyPosition;
        }
        private static CurrentlyPositionAndStatus RotateLeftTurtle(CurrentlyPositionAndStatus currentlyPosition)
        {
            switch (currentlyPosition.Direction)
            {
                case "N":
                    currentlyPosition.Direction = Directions.West;
                    break;
                case "S":
                    currentlyPosition.Direction = Directions.East;
                    break;
                case "W":
                    currentlyPosition.Direction = Directions.South;
                    break;
                case "E":
                    currentlyPosition.Direction = Directions.North;
                    break;
            }
            return currentlyPosition;
        }
        private static CurrentlyPositionAndStatus RotateRightTurtle(CurrentlyPositionAndStatus currentlyPosition)
        {
            switch (currentlyPosition.Direction)
            {
                case "N":
                    currentlyPosition.Direction = Directions.East;
                    break;
                case "S":
                    currentlyPosition.Direction = Directions.West;
                    break;
                case "W":
                    currentlyPosition.Direction = Directions.North;
                    break;
                case "E":
                    currentlyPosition.Direction = Directions.South;
                    break;
            }

            return currentlyPosition;
        }
    }
}
