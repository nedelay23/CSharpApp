using System;
namespace SphereTest
{


    public class Tetrahedron : IComparable<Tetrahedron>
    {
        public float[] AngleOrientational { get; private set; }
        public float RadiusOfCircle { get; private set; }
        public float[] CenterPoint { get; private set; } = new float[3];
        public float[,,,] VertexPoint { get; private set; } = new float[3, 3, 3, 3];

        public static SortedSet<Tetrahedron> setOfTetrahedron { get; private set; } = new();

        public Tetrahedron(double minSize, double maxSize)
        {
            var generator = new ServiceGenerator();


            this.CenterPoint = new float[] {generator.CenterPointGenerator(),
                generator.CenterPointGenerator(),
                generator.CenterPointGenerator()};
            this.RadiusOfCircle = generator.NumberGenerator(minSize, maxSize);

            this.AngleOrientational = new float[] {generator.AngleGeneratorInRadian(),
                generator.AngleGeneratorInRadian(),
                generator.AngleGeneratorInRadian()};

        }


        public Tetrahedron(float[] angle, float radius, float[] center)
        {
            this.AngleOrientational = angle;
            this.RadiusOfCircle = radius;

        }


        public static void AddPrismToSortedSet(Tetrahedron prism)
        {
            setOfTetrahedron.Add(prism);

        }

        public static List<Tetrahedron> GetSorterListOfPrisms()
        {
            return new List<Tetrahedron>(setOfTetrahedron);
        }

        public override string ToString()
        {

            return $@"координаты центра {string.Join(", ", CenterPoint)} размер тетраэдра - радиус описанной окружности {RadiusOfCircle} углы ориентации {string.Join(", ", AngleOrientational)}";

        }

        public int CompareTo(Tetrahedron? other)
        {
            if (other == null)
            {
                return 0;
            }
            return other.RadiusOfCircle.CompareTo(this.RadiusOfCircle);
        }
    }
}

