using System.Collections.ObjectModel;

namespace molecules.core.domain.valueobjects.atomproperty
{
    public static class AtomPropertiesTable
    {
        private static readonly ReadOnlyCollection<AtomProperties> _atomProperties =
            new(new AtomProperties[] {
                   new (1,"H","Hydrogen",1),
                   new (2,"He","Helium",2),
                   new (3,"Li", "Lithium", 3),
                   new (4,"Be","Beryllium",4),
                   new (5,"B", "Boron",5),
                   new (6,"C","Carbon",6),
                   new (7,"N", "Nitrogen",7),
                   new (8,"O", "Oxygen",8),
                   new (9,"F", "Fluorine",9),
                   new (10,"Ne","Neon",10),
                   new (11,"Na","Sodium",11),
                   new (12,"Mg","Magnesium",12),
                   new (13,"Al","Aluminium",13),
                   new (14,"Si","Silicon",14),
                   new (15,"P","Phosphorus",15),
                   new (16,"S", "Sulfur",16),
                   new (17,"Cl", "Chlorine", 17),
                   new (18,"Ar", "Argon", 18),
                   new (19,"K", "Potassium",19),
                   new (20,"Ca", "Calcium", 20),
                   new (21,"Fe","Iron",21)
            });

        public static AtomProperties? GetAtomProperties(string symbol)
        {
            return _atomProperties.FirstOrDefault(x => x.Symbol == symbol);
        }
    }
}
