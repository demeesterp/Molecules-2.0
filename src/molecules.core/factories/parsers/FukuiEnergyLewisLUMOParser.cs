﻿namespace molecules.core.factories.parsers
{
    internal class FukuiEnergyLewisLUMOParser : FukuiEnergyParser
    {
        #region tags

        private const string StartTag = "     PROPERTY VALUES FOR THE UHF   SELF-CONSISTENT FIELD WAVEFUNCTION";

        private const string EnergyTag = "TOTAL ENERGY";

        #endregion


        protected override string GetEnergyTag()
        {
            return StartTag;
        }

        protected override string GetStartTag()
        {
            return EnergyTag;
        }


        internal static decimal GetEnergy(List<string> fileLines)
        {
            FukuiEnergyLewisLUMOParser parser = new();
            return parser.Parse(fileLines);
        }
    }
}
