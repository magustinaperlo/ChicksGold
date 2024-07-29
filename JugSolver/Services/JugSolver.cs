using System;

namespace JugSolverApp.Services
{
    public class JugSolverService
    {
        public (bool IsSolvable, int Steps) Solve(int capX, int capY, int z)
        {
            if (z > capX + capY) return (false, 0);
            if (z == 0) return (true, 0);
            if (z % GCD(capX, capY) != 0) return (false, 0); //checking if z is a multiple of the GCD of capX and capY. This approach ensures that the jar problem is solvable with the given quantities.

            int stepsFromX = SolveSteps(capX, capY, z); 
            int stepsFromY = SolveSteps(capY, capX, z); 

            return (true, Math.Min(stepsFromX, stepsFromY)); //I compare previous storages and return the efficient one
        }

        private int SolveSteps(int capX, int capY, int z)
        {
            int cont = 0;
            int cantX = 0;
            int cantY = 0;

            while (cantX != z && cantY != z)
            {
                if (cantX == 0)
                {
                    cantX = capX;
                    cont++;
                }
                else if (cantY == capY)
                {
                    cantY = 0;
                    cont++;
                }
                else
                {
                    int transfer = Math.Min(cantX, capY - cantY);
                    cantX -= transfer;
                    cantY += transfer;
                    cont++;
                }
            }

            return cont;
        }

        private int GCD(int a, int b)  //The concept of greatest common divisor (GCD) helped analyze the problem of measuring specific quantities without a remainder.
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
