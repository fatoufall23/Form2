using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form2
{
    public partial class FormEtudiant : Form
    {
        public object comboBoxClasse { get; private set; }

        public FormEtudiant()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormEtudiant_Load(object sender, EventArgs e)
        {
            using (var db = new DbScolaire())
            {
                ckbClasse.DataSource = db.Classe.ToList();
                ckbClasse.DisplayMember = "Libelle";
                ckbClasse.ValueMember= "Id";
                Actualiser();
            }
     
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private object btnEnregistrer_Click(object sender, EventArgs e)
        {
            using (var db = new DbScolaire())
            {
                Etudiant etudiant = new Etudiant();
                etudiant.Prenom = txtPrenom.Text;
                etudiant.Nom = txtNom.Text;
                etudiant.IdClasse = (int)ckbClasse.SelectedValue;
                etudiant.classe = db.Classe.FirstOrDefault(c => c.Id == etudiant.IdClasse);
                db.Etudiant.Add(etudiant);
                db.SaveChanges();

                MessageBox.Show("Données insérées", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Actualiser();

        } 
        }

        private void Actualiser()
        {
            dataGridView1.DataSource = null;
            using (var db = new DbScolaire())
            {
                dataGridView1.DataSource = db.Etudiant.Select(e => new ViewEtudiant { Id = e.Id, Prenom = e.Prenom, Nom = e.Nom, Libelle = e.classe.Libelle }).ToList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        { 
        
            if (etudiantSelected == null)
            {
                MessageBox.Show("Vérifiez que vous avez sélectionné un étudiant", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet étudiant ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                using (var db = new DBScolaire())  // Remplacez par votre contexte de base de données
                {
                    var etudiant = db.Etudiants.Find(etudiantSelected.IdEtudiant);

                    if (etudiant != null)
                    {
                        db.Etudiants.Remove(etudiant);
                        db.SaveChanges();
                        MessageBox.Show("L'étudiant a été supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Étudiant introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        
           
        {
            object etudiantSelected = null;
            if (etudiantSelected == null)
            {
                MessageBox.Show("Vérifiez que vous avez sélectionné un étudiant", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new DBScolaire()) 
            {
                var etudiant = db.Etudiants.Find(etudiantSelected.IdEtudiant);

                if (etudiant != null)
                {
                    etudiant.Prenom = txtPrenom.Text;
                    etudiant.Nom = txtNom.Text;
                    etudiant.Classe = ckbClasse.Text;
                    
          
                    etudiant.IdClasse = (int)comboBoxClasse.SelectedValue;
                    etudiant.Classe = (Classe)comboBoxClasse.SelectedItem;

                    db.SaveChanges();  
                    MessageBox.Show("Les informations de l'étudiant ont été mises à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Étudiant introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
    

