using molecules.core.factories.GmsParsers;

namespace molecules.core.factories.parsers
{
    internal class FukuiEnergyLewisHOMOParser : FukuiEnergyParser
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
            return new FukuiEnergyLewisHOMOParser().Parse(fileLines);
        }

    }
}
