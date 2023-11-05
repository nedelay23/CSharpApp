using System;
namespace SphereTest
{
    public interface IGenerator
    {
        public float NumberGenerator(double min, double max);
        public float AngleGeneratorInRadian();
        public float CenterPointGenerator();

    }
}

