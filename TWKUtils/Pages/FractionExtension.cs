using System;

namespace TWKUtils.Pages
{
    public static class FractionExtension
    {
        //https://stackoverflow.com/questions/38891250/convert-to-fraction-inches
        public static string ToFraction( double value)
        {
            // denominator is fixed
            int denominator = 64;
            // integer part, can be signed: 1, 0, -3,...
            int integer = (int)value;
            // numerator: always unsigned (the sign belongs to the integer part)
            // + 0.5 - rounding, nearest one: 37.9 / 64 -> 38 / 64; 38.01 / 64 -> 38 / 64
            int numerator = (int)((Math.Abs(value) - Math.Abs(integer)) * denominator + 0.5);

            // some fractions, e.g. 24 / 64 can be simplified:
            // both numerator and denominator can be divided by the same number
            // since 64 = 2 ** 6 we can try 2 powers only 
            // 24/64 -> 12/32 -> 6/16 -> 3/8
            // In general case (arbitrary denominator) use gcd (Greatest Common Divisor):
            //   double factor = gcd(denominator, numerator);
            //   denominator /= factor;
            //   numerator /= factor;
            while ((numerator % 2 == 0) && (denominator % 2 == 0))
            {
                numerator /= 2;
                denominator /= 2;
            }

            // The longest part is formatting out

            // if we have an actual, not degenerated fraction (not, say, 4 0/1)
            if (denominator > 1)
                if (integer != 0) // all three: integer + numerator + denominator
                    return string.Format("{0}-{1}/{2}", integer, numerator, denominator);
                else if (value < 0) // negative numerator/denominator, e.g. -1/4
                    return string.Format("-{0}/{1}", numerator, denominator);
                else // positive numerator/denominator, e.g. 3/8
                    return string.Format("{0}/{1}", numerator, denominator);
            else
                return integer.ToString(); // just an integer value, e.g. 0, -3, 12...  
        }
    }
}
