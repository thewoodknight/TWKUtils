using System.Collections.Generic;

namespace TWKUtils.Pages
{
    public partial class Index
    {
        private double[] CommonBits = new double[] { 3.125, 6.35, 9.5, 12.7 };
        private double[] CommonBushings = new double[] { 7.95, 9.5, 11.13, 12.7, 15.875, 17, 19.01, 34.9 };
        private double DesiredHole = 20;

        /* RA1128 contains 5/16, 7/16, 5/8, 1-3/8, 1/2, 3/4 */
        //  TemplateID = DesiredHole + (BushingOD - BitOD);

        public List<Bit> Bits = new List<Bit>();

        public void ConvertClick()
        {
            Bits = new List<Bit>();

            foreach (var bit in CommonBits)
            {
                var b = new Bit()
                {
                    BitMetric = bit,
                    BitImperial = FractionExtension.ToFraction(bit / 25.4),
                    Combinations = new List<PossibleCombination>(),
                };

                foreach (var bushing in CommonBushings)
                {
                    if (bit < bushing && DesiredHole > bit)
                    {
                        var t = DesiredHole + (bushing - bit);
                        b.Combinations.Add(new PossibleCombination(bushing, t));
                    }
                }

                Bits.Add(b);
            }
        }
    }
}