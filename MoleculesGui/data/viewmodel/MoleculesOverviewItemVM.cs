using MoleculesGui.data.serviceagents.molecules;

namespace MoleculesGui.data.viewmodel
{
    public class MoleculesOverviewItemVM
    {

        public MoleculesOverviewItemVM(CalcMolecule calcMolecule) 
        { 
            Id = calcMolecule.Id;
            Name = calcMolecule.MoleculeName;
            CalcOrderName = calcMolecule.OrderName;
            BasisSetName = calcMolecule.BasisSet;     
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CalcOrderName { get; set; }

        public string BasisSetName { get; set; }

        public CalcMolecule GetCalcMolecule()
        {
            return new CalcMolecule(Id, CalcOrderName, BasisSetName, Name);
        }


    }
}
