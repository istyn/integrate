using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integration
{
	class Program
	{
		static void Main(string[] args)
		{
			Calc c = new Calc();
			Func<double, double> parabola = (x) => -Math.Pow((x-Math.Sqrt(3)),2) + 3;
			double area = Calc.integrate(parabola, 0, 2 * Math.Sqrt(3));  //integrate over entire area of parabola
		}
	}
	
class Calc
	{
		public static double integrate (Func<double, double> f, double a, double b)    //integrate using simpson's rule
		{
			int i = 10;                         //number of iterations
			double area = 0;                    //sum of area under curve
			double delta = (b - a) / i;         //change in x to increment
			for (int j = 0; j <= i; j++)
			{
				if (j==0 || j == i)             //if first or last case
				{
					area += f.Invoke(a + delta * j);
				}
				else if (j % 2 != 0)            //if even case, 4 * f(x)
				{
					area += 4 * f.Invoke(a + delta * j);
				} 
				else                            //if odd case, 2 * f(x)
				{
					area += 2 * f.Invoke(a + delta * j);
				}
				
			}
			return (delta/3)*area;
		}
		/// <summary>
		/// Numbers the decimals places to the right.
		/// </summary>
		/// <param name="d">The decimal.</param>
		/// <returns>b in ax10^b</returns>
		private int numDecimals(double d)
		{
			int num = 0;
			for (int i = 0; i < 100; i++)
			{
				if (Math.Floor(d)==1)
				{
					break;
				}
				else
				{
					d = d * 10;
					num++;
				}
			}
			return num;
		}
	}    
}
