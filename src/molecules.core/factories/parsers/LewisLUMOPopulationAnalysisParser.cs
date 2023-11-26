using molecules.core.domain.valueobjects.molecules;

namespace molecules.core.factories.parsers
{
    internal class LewisLUMOPopulationAnalysisParser : UHFPopulationAnalysisParser
    {
        protected override PopulationAnalysisType GetPopulationStatus()
        {
            return PopulationAnalysisType.lewisLUMO;
        }

        internal static void GetPopulation(List<string> fileLines, Molecule molecule)
        {
            LewisLUMOPopulationAnalysisParser parser = new ();
            parser.Parse(fileLines, molecule);
        }
    }
}
