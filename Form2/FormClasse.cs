using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Form2
{
    public partial class FormClasse : Form
    {
        private Classe classeSelected; // Correction du type

        public FormClasse()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (DbScolaire db = new DbScolaire())
            {
                Classe classe = new Classe();
                classe.Libelle = txtLibelle.Text;
                db.Classe.Add(classe);
                db.SaveChanges();

                MessageBox.Show("Données insérées", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Actualiser();
            }
        }

        private void Actualiser()
        {
            dataGridView1.DataSource = null;
            using (var db = new DbScolaire())
            {
                dataGridView1.DataSource = db.Classe.ToList();
            }
        }

        private void FormClasse_Load(object sender, EventArgs e)
        {
            Actualiser();
        }

        private void btnUpdateC_Click(object sender, EventArgs e)
        {
            if (classeSelected == null)
            {
                MessageBox.Show("Vérifiez que vous avez sélectionné une classe", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new DbScolaire()) 
            {
                var classe = db.Classe.Find(classeSelected.IdClasse);
                if (classe != null)
                {
                    classe.Libelle = txtLibelle.Text;

                    db.SaveChanges();
                    MessageBox.Show("Les informations de la classe ont été mises à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Actualiser();
                }
                else
                {
                    MessageBox.Show("Classe introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDeleteC_Click(object sender, EventArgs e)
        {
            if (classeSelected == null)
            {
                MessageBox.Show("Vérifiez que vous avez sélectionné une classe", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette classe ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                using (var db = new DbScolaire())
                {
                    var classe = db.Classe.Find(classeSelected.IdClasse); // Correction de l'accès à la table

                    if (classe != null)
                    {
                        db.Classe.Remove(classe);
                        db.SaveChanges();
                        MessageBox.Show("La classe a été supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Actualiser();
                    }
                    else
                    {
                        MessageBox.Show("Classe introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Gestion de la sélection d'une classe dans le DataGridView
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                classeSelected = dataGridView1.Rows[e.RowIndex].DataBoundItem as Classe;
                if (classeSelected != null)
                {
                    txtLibelle.Text = classeSelected.Libelle;
                }
            }
        }
    }
}
