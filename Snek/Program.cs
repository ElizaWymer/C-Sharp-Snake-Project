using Snek;

Coord gridDimensions = new Coord(50, 20);
Coord snakeHeadPos = new Coord(10, 10);

Random rand = new Random();
Coord applePos = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));

int framdeDelayMilli = 100;

Direction movementDirection = Direction.Still;

List<Coord> snakePosHistory = new List<Coord>();
int tailLength = 2;

int score = 0;

while (true)
{
    Console.WriteLine("Score: " + score + "\n");

    snakeHeadPos.ApplyMovementDirection(movementDirection);

    for (int y = 0; y < gridDimensions.Y; y++)
    {

        for (int x = 0; x < gridDimensions.X; x++)
        {
            Coord currentCoord = new Coord(x, y);

            if (snakeHeadPos.Equals(currentCoord))
            {

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("■");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (snakePosHistory.Contains(currentCoord))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("■");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (applePos.Equals(currentCoord))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("a");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
    }

    if (snakeHeadPos.Equals(applePos))
    {
        tailLength++;
        applePos = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
        score += 1;
    }
    else if (snakeHeadPos.X == 0 || snakeHeadPos.X == gridDimensions.X - 1 || snakeHeadPos.Y == 0 || snakeHeadPos.Y == gridDimensions.Y - 1 || snakePosHistory.Contains(snakeHeadPos) && tailLength > 2)
    {
        score = 0;
        tailLength = 2;
        snakeHeadPos = new Coord(10, 10);
        snakePosHistory = new List<Coord>();
        movementDirection = Direction.Still;
        applePos = new Coord(rand.Next(1, gridDimensions.X - 1), rand.Next(1, gridDimensions.Y - 1));
        continue;
    }
    snakePosHistory.Add(new Coord(snakeHeadPos.X, snakeHeadPos.Y));

    if (snakePosHistory.Count > tailLength)
    {
        snakePosHistory.RemoveAt(0);
    }

    DateTime time = DateTime.Now;

    while ((DateTime.Now - time).Milliseconds < framdeDelayMilli)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    movementDirection = Direction.Up;
                    break;
                case ConsoleKey.W:
                    movementDirection = Direction.Up;
                    break;

                case ConsoleKey.LeftArrow:
                    movementDirection = Direction.Left;
                    break;
                case ConsoleKey.A:
                    movementDirection = Direction.Left;
                    break;

                case ConsoleKey.DownArrow:
                    movementDirection = Direction.Down;
                    break;
                case ConsoleKey.S:
                    movementDirection = Direction.Down;
                    break;

                case ConsoleKey.RightArrow:
                    movementDirection = Direction.Right;
                    break;
                case ConsoleKey.D:
                    movementDirection = Direction.Right;
                    break;
            }
        }
    }
    Console.Clear();

}

