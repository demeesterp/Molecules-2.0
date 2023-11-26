using molecules.core.domain.valueobjects.molecules;

namespace molecules.core.factories.parsers
{
    internal class LewisHOMOPopulationAnalysisParser : UHFPopulationAnalysisParser
    {
        protected override PopulationAnalysisType GetPopulationStatus()
        {
            return PopulationAnalysisType.lewisHOMO;
        }

        internal static void GetPopulation(List<string> fileLines, Molecule molecule)
        {
            LewisHOMOPopulationAnalysisParser parser = new ();
            parser.Parse(fileLines, molecule);
        }
    }
}
