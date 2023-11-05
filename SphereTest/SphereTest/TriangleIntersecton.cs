using System;
namespace SphereTest
{
    public class TriangleIntersecton
    {

        static bool DoEdgesIntersect(Point a1, Point b1, Point a2, Point b2)
        {

            Point a1b1 = b1 - a1;
            Point a2a1 = a2 - a1;
            Point a1d2 = b2 - a1;
            Point a2d2 = b2 - a2;

            // Проверяем, лежит ли точка d по одну сторону от ребра ab
            float d1 = Point.Dot(Point.Cross(a1b1, a2a1), a1d2);

            if (d1 != 0 && Math.Sign(d1) != Math.Sign(Point.Dot(Point.Cross(a1b1, a2a1), Point.Cross(a1b1, a1d2))))
            {
                // Точки c и d лежат с разных сторон от ребра ab, продолжаем проверку
                float d2 = Point.Dot(Point.Cross(a2d2, a1b1), Point.Cross(a2d2, a2a1));
                return d2 != 0 && Math.Sign(d2) != Math.Sign(d1);
            }

            return false;
        }

        static bool AreTrianglesIntersecting(Point a1, Point b1, Point c1, Point a2, Point b2, Point c2)
        {
            return DoEdgesIntersect(a1, b1, a2, b2) || DoEdgesIntersect(a1, b1, a2, c2) || DoEdgesIntersect(a1, b1, b2, c2) ||
                   DoEdgesIntersect(b1, c1, a2, b2) || DoEdgesIntersect(b1, c1, a2, c2) || DoEdgesIntersect(b1, c1, b2, c2) ||
                   DoEdgesIntersect(c1, a1, a2, b2) || DoEdgesIntersect(c1, a1, a2, c2) || DoEdgesIntersect(c1, a1, b2, c2);
        }


        public TriangleIntersecton()
        {
            Point a1 = new Point(1, 0, 0);
            Point b1 = new Point(1, 0, 0);
            Point c1 = new Point(0, 1, 0);

            Point a2 = new Point(0.5f, 0.5f, 0);
            Point b2 = new Point(1.5f, 0.5f, 0);
            Point c2 = new Point(0.5f, 1.5f, 0);

            bool intersecting = AreTrianglesIntersecting(a1, b1, c1, a2, b2, c2);

            Console.WriteLine(intersecting ? "Треугольники пересекаются" : "Треугольники не пересекаются");
        }
    }
    class Point
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public Point(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        // перегрузка оператора "-"
        public static Point operator -(Point a, Point b)
        {
            return new Point(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Point Cross(Point a, Point b)
        {
            float x = a.Y * b.Z - a.Z * b.Y;
            float y = a.Z * b.X - a.X * b.Z;
            float z = a.X * b.Y - a.Y * b.X;
            return new Point(x, y, z);
        }

        public static float Dot(Point a, Point b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
    }
}

