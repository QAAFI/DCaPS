using System;

namespace Utilities
{
    public class TableFunction
    {
        public double[] xVals { get; set; }
        public double[] yVals { get; set; }
        public bool flatEnds { get; set; }

        //--------------------------------------------------------------------

        public TableFunction(double[] x, double[] y, bool flatEnds = true)
        {
            xVals = x;
            yVals = y;

            this.flatEnds = flatEnds;
        }
        //--------------------------------------------------------------------
        // Get the y value of the function
        //--------------------------------------------------------------------

        public double value(double v)
        {
            // Find which sector of the function that v falls in
            int sector;

            if (!flatEnds)
            {
                if (xVals.Length == 0)
                {
                    throw (new Exception("Array has no data"));
                }

                if (v < xVals[0] || v > xVals[xVals.Length - 1])
                {
                    throw (new Exception("X value is outside the bounds of the Array"));
                }
            }

            for (sector = 0; sector < xVals.Length; sector++)
            {
                if (v <= xVals[sector])
                {
                    break;
                }
            }

            if (sector == 0)
            {
                return yVals[0];
            }

            if (sector == xVals.Length)
            {
                return yVals[yVals.Length - 1];
            }

            if (v == xVals[sector])
            {
                return yVals[sector];
            }

            double slope;
            try
            {

                slope = (xVals[sector] == xVals[sector - 1]) ? 0 :
                                 (yVals[sector] - yVals[sector - 1]) / (xVals[sector] - xVals[sector - 1]);
            }
            catch (DivideByZeroException dbz)
            {
                slope = 0;
            }

            return yVals[sector - 1] + slope * (v - xVals[sector - 1]);
        }
    }
}
