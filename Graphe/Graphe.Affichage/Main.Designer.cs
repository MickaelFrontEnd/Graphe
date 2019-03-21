namespace Graphe.Affichage
{
    partial class Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.BarreMenu = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OuvrirFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterUnNoeudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plusCourCheminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plusLongCheminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagrammeDeGanttToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OuvrirFichierDialogue = new System.Windows.Forms.OpenFileDialog();
            this.BarreMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarreMenu
            // 
            this.BarreMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.menu2ToolStripMenuItem,
            this.menu3ToolStripMenuItem});
            this.BarreMenu.Location = new System.Drawing.Point(0, 0);
            this.BarreMenu.Name = "BarreMenu";
            this.BarreMenu.Size = new System.Drawing.Size(800, 24);
            this.BarreMenu.TabIndex = 0;
            this.BarreMenu.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OuvrirFichier,
            this.quitterToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.menuToolStripMenuItem.Text = "Fichier";
            // 
            // menu2ToolStripMenuItem
            // 
            this.menu2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterUnNoeudToolStripMenuItem});
            this.menu2ToolStripMenuItem.Name = "menu2ToolStripMenuItem";
            this.menu2ToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.menu2ToolStripMenuItem.Text = "Graphe";
            // 
            // menu3ToolStripMenuItem
            // 
            this.menu3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plusCourCheminToolStripMenuItem,
            this.plusLongCheminToolStripMenuItem,
            this.diagrammeDeGanttToolStripMenuItem,
            this.colorationToolStripMenuItem,
            this.maximiToolStripMenuItem});
            this.menu3ToolStripMenuItem.Name = "menu3ToolStripMenuItem";
            this.menu3ToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.menu3ToolStripMenuItem.Text = "Algorithme";
            // 
            // OuvrirFichier
            // 
            this.OuvrirFichier.Name = "OuvrirFichier";
            this.OuvrirFichier.Size = new System.Drawing.Size(180, 22);
            this.OuvrirFichier.Text = "Ouvrir";
            this.OuvrirFichier.Click += new System.EventHandler(this.OuvrirFichier_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // ajouterUnNoeudToolStripMenuItem
            // 
            this.ajouterUnNoeudToolStripMenuItem.Name = "ajouterUnNoeudToolStripMenuItem";
            this.ajouterUnNoeudToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ajouterUnNoeudToolStripMenuItem.Text = "Ajouter un noeud";
            // 
            // plusCourCheminToolStripMenuItem
            // 
            this.plusCourCheminToolStripMenuItem.Name = "plusCourCheminToolStripMenuItem";
            this.plusCourCheminToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.plusCourCheminToolStripMenuItem.Text = "Plus cour chemin";
            // 
            // plusLongCheminToolStripMenuItem
            // 
            this.plusLongCheminToolStripMenuItem.Name = "plusLongCheminToolStripMenuItem";
            this.plusLongCheminToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.plusLongCheminToolStripMenuItem.Text = "Plus long chemin";
            // 
            // diagrammeDeGanttToolStripMenuItem
            // 
            this.diagrammeDeGanttToolStripMenuItem.Name = "diagrammeDeGanttToolStripMenuItem";
            this.diagrammeDeGanttToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.diagrammeDeGanttToolStripMenuItem.Text = "Diagramme de Gantt";
            // 
            // colorationToolStripMenuItem
            // 
            this.colorationToolStripMenuItem.Name = "colorationToolStripMenuItem";
            this.colorationToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.colorationToolStripMenuItem.Text = "Coloration";
            // 
            // maximiToolStripMenuItem
            // 
            this.maximiToolStripMenuItem.Name = "maximiToolStripMenuItem";
            this.maximiToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.maximiToolStripMenuItem.Text = "Maximisation flot réseau";
            // 
            // OuvrirFichierDialogue
            // 
            this.OuvrirFichierDialogue.FileName = "Donnee";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BarreMenu);
            this.MainMenuStrip = this.BarreMenu;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manipulation de GRAPHE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.BarreMenu.ResumeLayout(false);
            this.BarreMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip BarreMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OuvrirFichier;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterUnNoeudToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plusCourCheminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem plusLongCheminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagrammeDeGanttToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maximiToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog OuvrirFichierDialogue;
    }
}

