using System;
namespace SphereTest
{
    public class ServiceGenerator : IGenerator
    {
        
        public ServiceGenerator() {}

        public float NumberGenerator(double min, double max)
        {
            Random rnd = new ();     
            double sample = rnd.NextDouble();
            double range = (max - min);
            double scaled = (sample * range) + min;
            return (float)scaled;

        }

        public float CenterPointGenerator()
        {
            Random rnd = new ();
            double range = 1D - -1D;
            double sample = rnd.NextDouble();
            double scaled = (sample * range) + -1f;
            return (float)scaled;
        }

        public float AngleGeneratorInRadian()
        {
            Random rnd = new ();
            double sample = rnd.NextDouble();
            double scaled = (sample * 2);
            return (float)(scaled * Math.PI);
        }


    }


}

