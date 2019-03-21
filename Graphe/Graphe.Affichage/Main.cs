using System;
using System.Windows.Forms;

namespace Graphe.Affichage
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        // Ovrir fichier 
        public void OuvrirFichier_Click(object sender, EventArgs args)
        {
            OuvrirFichierDialogue.ShowDialog();
        }
    }
}
