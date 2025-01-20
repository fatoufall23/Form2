using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form2
{
    internal class Classe

    {
        public Classe() { 
        }
       public int Id { get; set; }
        public string libelle { get; set; }
        public string Libelle { get; internal set; }
        public ICollection<Etudiant> etudiants { get; set; }
    }
}
internal class ViewClase

{

    public int Id { get; set; }
    public string libelle { get; set; }
}