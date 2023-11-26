using molecules.core.domain.valueobjects.gmscalc;
using molecules.core.domain.valueobjects.molecules;
using molecules.core.factories.GmsParsers;
using molecules.core.factories.parsers;
using molecules.core.factories.parsersds;

namespace molecules.core.factories.calcmolecule
{
    public class MoleculeFromGmsFactory : IMoleculeFromGmsFactory
    {
        public bool TryCompleteMolecule(string fileName, List<string> fileLines, Molecule? molecule)
        {
            if (molecule == null) return false;
            if ( fileName.Contains(GmsCalculationKind.GeometryOptimization.ToString()) ) {
                if (GmsCalcValidityParser.TryParse(GmsCalculationKind.GeometryOptimization, fileLines, molecule))
                {
                    GeoOptParser.Parse(fileLines, molecule);
                    GeoOptDftEnergyParser.Parse(fileLines, molecule);
                }
            }
            else if ( fileName.Contains(GmsCalculationKind.GeoDiskCharge.ToString()) ) {
                if (GmsCalcValidityParser.TryParse(GmsCalculationKind.GeoDiskCharge, fileLines, molecule)){
                    ChargeParser.Parse(fileLines, molecule);
                }
            }
            else if ( fileName.Contains(GmsCalculationKind.CHelpGCharge.ToString()) ) 
            {
                if (GmsCalcValidityParser.TryParse(GmsCalculationKind.CHelpGCharge,fileLines, molecule))
                {
                    ChargeParser.Parse(fileLines, molecule);
                }
            }
            else if ( fileName.Contains(GmsCalculationKind.FukuiHOMO.ToString()) ) {
                if (GmsCalcValidityParser.TryParse(GmsCalculationKind.FukuiHOMO, fileLines, molecule))
                {
                    LewisHOMOPopulationAnalysisParser.GetPopulation(fileLines, molecule);
                    molecule.HFEnergyHOMO = FukuiEnergyLewisHOMOParser.GetEnergy(fileLines);
                }
            }
            else if ( fileName.Contains(GmsCalculationKind.FukuiLUMO.ToString()) ) {
                if ( GmsCalcValidityParser.TryParse(GmsCalculationKind.FukuiLUMO, fileLines, molecule))
                {
                    LewisLUMOPopulationAnalysisParser.GetPopulation(fileLines, molecule);
                    molecule.HFEnergyLUMO = FukuiEnergyLewisLUMOParser.GetEnergy(fileLines);
                }
            }
            else if ( fileName.Contains(GmsCalculationKind.FukuiNeutral.ToString()) ) {
                if ( GmsCalcValidityParser.TryParse(GmsCalculationKind.FukuiNeutral, fileLines, molecule))
                {
                    NeutralPopulationAnalysisParser.GetPopulation(fileLines, molecule);
                    molecule.HFEnergy = FukuiEnergyNeutralParser.GetEnergy(fileLines);
                }
            } 
            else {
                return false;
            }
            return true;
        }

    }
}
