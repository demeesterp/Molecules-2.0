using MoleculesGui.data.viewmodel;
using NCDK;
using NCDK.Default;
using NCDK.Graphs;
using NCDK.IO;
using NCDK.Layout;
using NCDK.Numerics;

namespace MoleculesGui.services.molecules_display
{
    public class MoleculesDisplayService
    {
        public static string GetMolFile(MoleculeReportVM moleculeReport)
        {
            var molecule = new AtomContainer();
            foreach(var atom in moleculeReport.AtomPositions)
            {
                var currentAtom = new Atom(atom.AtomSymbol,
                                                new Vector3(Convert.ToDouble(atom.PosX??0),
                                                             Convert.ToDouble(atom.PosY??0),
                                                             Convert.ToDouble(atom.PosZ??0)));

                molecule.Atoms.Add(currentAtom);

                
            }


            molecule.AddBond(molecule.Atoms[0], molecule.Atoms[1], BondOrder.Single, BondStereo.None);

            // Generate bonds
            //var result = ConnectivityChecker.PartitionIntoMolecules(molecule);

            // Generate 2D coordinates
            //ar sdg = new StructureDiagramGenerator(molecule);
            //g.GenerateCoordinates();

            // Write to Molfile
            var writer = new StringWriter();
            var mdlWriter = new MDLV2000Writer(writer);


            mdlWriter.Write(molecule);
            mdlWriter.Close();

            return writer.ToString();
        }
    }
}
