using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeMines.Model;

namespace EscapeMines
{
    public class GameAlgorithm
    {
        public void CalculateGameResults(GameContext gameContext, List<List<string>> movementList)
        {
            foreach (var line in movementList)
            {
                var currentlyPosition = new CurrentlyPositionAndStatus
                {
                    CoordX = gameContext.StartPosition.CoordX,
                    CoordY = gameContext.StartPosition.CoordY,
                    Direction = gameContext.StartPosition.Direction,
                    Status = (int)GameStatus.NotStarted
                };
                var i = 0;
                foreach (var item in line)
                {
                    try
                    {
                        Movements movement = Movements.UnknownMovement;
                        movement = (Movements)Enum.Parse(typeof(Movements), item);
                           
                    switch (movement)
                    {
                        case Movements.M:
                            currentlyPosition = MoveTurtle(gameContext, currentlyPosition);
                            break;
                        case Movements.L:
                            currentlyPosition = RotateLeftTurtle(gameContext, currentlyPosition);
                            break;
                        case Movements.R:
                            currentlyPosition = RotateRightTurtle(gameContext, currentlyPosition);
                            break;
                        default:
                            Console.WriteLine("Unknown Movement");
                            break;
                    }
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine("Unknown Movement");
                    }

                    if (currentlyPosition.Status == (int)GameStatus.MineHit)
                    {
                        Console.WriteLine("Sequence {0}: Mine hit!", movementList.IndexOf(line) + 1);
                        break;
                    }

                    if (i == line.Count - 1)
                    {
                        if (currentlyPosition.CoordX == gameContext.ExitPoint.CoordX && currentlyPosition.CoordY == gameContext.ExitPoint.CoordY)
                        {
                            Console.WriteLine("Sequence {0}: Success!", movementList.IndexOf(line) + 1);
                            currentlyPosition.Status = (int)GameStatus.Succeed;
                        }
                        else
                        {
                            Console.WriteLine("Sequence {0}: Still in danger!", movementList.IndexOf(line) + 1);
                            currentlyPosition.Status = (int)GameStatus.StillInDanger;
                        }
                    }
                    i++;

                }

            }
        }
        private CurrentlyPositionAndStatus MoveTurtle(GameContext game, CurrentlyPositionAndStatus currentlyPosition)
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
            foreach (var item in game.MineCoordinates)
            {
                if (item.CoordX == currentlyPosition.CoordX && item.CoordY == currentlyPosition.CoordY)
                {
                    currentlyPosition.Status = (int)GameStatus.MineHit;
                }

            }
            return currentlyPosition;
        }
        private CurrentlyPositionAndStatus RotateLeftTurtle(GameContext game, CurrentlyPositionAndStatus currentlyPosition)
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
        private CurrentlyPositionAndStatus RotateRightTurtle(GameContext game, CurrentlyPositionAndStatus currentlyPosition)
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
