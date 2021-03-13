namespace TWKUtils.Pages
{
    public partial class Index
    {

        string output = "";

        double DesiredHole = 20;

        double[] CommonBits = new double[] { 3.125, 6.35, 9.5, 12.7 };

        double[] CommonBushings = new double[] { 7.95, 9.5, 11.13, 12.7, 15.875, 17, 19.01, 34.9 };

        /* RA1128 contains
         
         5/16, 7/16, 5/8, 1-3/8, 1/2, 3/4
         
         
         * */
        //  TemplateID = DesiredHole + (BushingOD - BitOD);

        public void ConvertClick()
        {         
            foreach (var bit in CommonBits)
            {
                //convert to stringbuilder
                output += string.Format("\n{0}mm bit ({1}\")\n", bit, FractionExtension.ToFraction(bit / 25.4));
                foreach (var bushing in CommonBushings)
                {
                    if (bit < bushing)
                    {
                        var t = DesiredHole + (bushing - bit);

                        //string builder
                        output += string.Format("{1}mm ({3}\") bushing and {2}mm ({4}\") template\n", 
                            bit,
                            bushing, 
                            t, 
                            FractionExtension.ToFraction(bushing / 25.4), 
                            FractionExtension.ToFraction(t / 25.4)); ;
                    }
                }
            }
        }
    }
}
