using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Form2;

namespace Form2
{
    internal class Etudiant

    {
        internal object Prenom;

        public Etudiant() { }
        public string Id { get; set; }
        public string prenom { get; set; }
       
        public string Nom { get; internal set; }
        public string IdClasse { get; set; }
        public  Classe classe { get; set; }

    }
}
internal class viewEtudiant

{


    public string Id { get; set; }
    public string prenom { get; set; }
    public string Nom { get; set; }
    public string Libelle { get; set; }
}
    

 
  