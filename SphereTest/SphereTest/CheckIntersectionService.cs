using System;
namespace SphereTest
{
	public class CheckIntersectionService {

		public Tetrahedron? tetrahedron;

		public CheckIntersectionService()
		{
		}


		public void SetPrism(Tetrahedron tetrahedron)
		{
			this.tetrahedron = tetrahedron;

		}

		public static bool IsIntersection(Tetrahedron tetrahedron)
		{
			

			foreach (Tetrahedron pr in Tetrahedron.setOfTetrahedron) 
			{
				if (Math.Pow(pr.CenterPoint[0] - tetrahedron.CenterPoint[0], 2) +
					Math.Pow(pr.CenterPoint[1] - tetrahedron.CenterPoint[1], 2) +
					Math.Pow(pr.CenterPoint[2] - tetrahedron.CenterPoint[2], 2) <= Math.Pow(pr.RadiusOfCircle, 2))
				{
					return true;
				} 

            }
			return false;
		}

    }
}

