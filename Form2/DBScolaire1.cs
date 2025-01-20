using System;

namespace Form2
{
    internal class DBScolaire : IDisposable
    {
        internal object Classe;
        internal object Etudiants;

        public object Etudiant { get; internal set; }

        internal void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}