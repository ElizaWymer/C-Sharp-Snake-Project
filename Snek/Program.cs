using Snek;

Coord gridDimensions = new Coord(50, 20);
Coord snakePos = new Coord(10, 10);

for (int y =  0; y < gridDimensions.Y; y++)
{
    for (int x = 0; x < gridDimensions.X; x++)
    {
        Coord currentCoord = new Coord(x, y);

        if (snakePos.Equals(currentCoord))
        {
            Console.Write("■");
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