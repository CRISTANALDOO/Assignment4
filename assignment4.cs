using System;
using System.Collections.Generic;

public class Circle
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateSurfaceArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public bool IsPointInsideCircle(double x, double y)
    {
        double distance = Math.Sqrt(x * x + y * y);
        return distance <= Radius;
    }
}

public class Program
{
    public static List<Circle> CreateCircles(int numCircles)
    {
        List<Circle> circles = new List<Circle>();
        for (int i = 0; i < numCircles; i++)
        {
            Console.Write($"Enter the radius for circle {i + 1}: ");
            double radius = Convert.ToDouble(Console.ReadLine());
            circles.Add(new Circle(radius));
        }
        return circles;
    }

    public static void PrintCircleInfo(List<Circle> circles)
    {
        for (int i = 0; i < circles.Count; i++)
        {
            Console.WriteLine($"Circle {i + 1}:");
            Console.WriteLine($"Surface Area: {circles[i].CalculateSurfaceArea():F2}");
            Console.WriteLine($"Perimeter: {circles[i].CalculatePerimeter():F2}");
            Console.WriteLine();
        }
    }

    public static (double, double) GetPoint()
    {
        Console.Write("Enter the x-coordinate of the point: ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter the y-coordinate of the point: ");
        double y = Convert.ToDouble(Console.ReadLine());
        return (x, y);
    }

    public static void CheckPointInCircles((double, double) point, List<Circle> circles)
    {
        for (int i = 0; i < circles.Count; i++)
        {
            bool isInside = circles[i].IsPointInsideCircle(point.Item1, point.Item2);
            Console.WriteLine($"Point is {(isInside ? "inside" : "outside")} Circle {i + 1}.");
        }
    }

    public static void Main()
    {
        Console.Write("Enter the number of circles you want to create: ");
        int numCircles = Convert.ToInt32(Console.ReadLine());
        List<Circle> circles = CreateCircles(numCircles);
        PrintCircleInfo(circles);
        var point = GetPoint();
        CheckPointInCircles(point, circles);
    }
}
