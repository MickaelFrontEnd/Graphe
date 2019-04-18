

using System.Collections.Generic;

namespace Graphe
{
    public class Mpm
    {
        public GrapheO<Tache> Graphe { get; set; } = new GrapheO<Tache>();

        // Ajouter tache
        public void AjouterTache(Tache tache)
        {
            Graphe.AjouterNoeud(tache);
        }

        // Ajouter predecesseur
        public void AjouterPredecesseur(Tache A, Tache B)
        {
            Graphe.AjouterArc(B, A, B.Durree);
        }

        // Placer noeud début
        public void PlacerNoeudDebut()
        {
            Tache debut = new Tache("Début");
            List<Tache> sansPredecesseurs = Graphe.GetSansPredecesseur();
            foreach (var item in sansPredecesseurs)
            {
                Graphe.AjouterArc(debut, item);
            }
        }
        
        // Place noeud fin
        public void PlacerNoeudFin()
        {
            Tache fin = new Tache("Fin");      
            List<Tache> sansSuccesseurs = Graphe.GetSansSuccesseur();
            foreach (var item in sansSuccesseurs)
            {
                Graphe.AjouterArc(item, fin);
            }
        }

        // Ajout des noeuds fictifs
        public void PlacerNoeudFictif()
        {
            PlacerNoeudDebut();
            PlacerNoeudFin();
        }

        // Calcul date au plutot
        public void CalculerDatePlutot(Tache sommet)
        {
            List<Predecesseur<Tache>> predecesseurs = Graphe.Predecesseurs[sommet];
            int plutot = 0;
            foreach(var item in predecesseurs)
            {
                if(item.Noeud.DebutPlutot + item.Noeud.Durree > plutot)
                {
                    plutot = item.Noeud.DebutPlutot + (int) item.Noeud.Durree;
                }
            }
            sommet.DebutPlutot = plutot;
        }

        // Calcul date au plutot
        public void CalculerDatePlutot(List<Tache> taches)
        {
            foreach(Tache tache in taches)
            {
                CalculerDatePlutot(tache);
            }
        }

        // Calcul date au plutard
        public void CalculerDatePlutard(Tache sommet)
        {
            List<Predecesseur<Tache>> successeurs = Graphe.Successeurs[sommet];
            int plustard = int.MaxValue;
            foreach(var item in successeurs)
            {
                if (item.Noeud.DebutPlustard - sommet.Durree < plustard)
                {
                    plustard = item.Noeud.DebutPlustard - (int) sommet.Durree;
                }
                sommet.DebutPlustard = plustard;
            }
        }

        // Calcul date au plutard
        public void CalculerDatePlutard(List<Tache> taches)
        {
            foreach (Tache tache in taches)
            {
                CalculerDatePlutard(tache);
            }
        }

        // Calcul marge total
        public void CalculerMargeTotal(Tache tache)
        {
            tache.MargeTotale = tache.DebutPlustard - tache.DebutPlutot;
        }

        // Calcul marge libre
        public int CalculerMargeLibre(Tache A, Tache B)
        {
            return B.DebutPlutot - A.DebutPlutot - A.Durree;
        }

        // Calcul marge libre
        public void CalculerMargeLibre(Tache tache)
        {
            var successeurs = Graphe.Successeurs[tache];
            int temp = int.MaxValue;
            foreach(var successeur in successeurs)
            {
                if(CalculerMargeLibre(tache,successeur.Noeud) < temp)
                {
                    temp = CalculerMargeLibre(tache, successeur.Noeud);
                }
            }
            tache.MargeLibre = temp;
        }

        // Calcul marge certaine
        public int CalculerMargeCertaine(Tache A, Tache B)
        {
            return B.DebutPlutot - A.DebutPlustard - A.Durree < 0 ? 0 : B.DebutPlutot - A.DebutPlustard - A.Durree;
        }

        // Calcul marge certaine
        public void CalculerMargeCertaine(Tache tache)
        {
            var successeurs = Graphe.Successeurs[tache];
            int temp = int.MaxValue;
            foreach (var successeur in successeurs)
            {
                if (CalculerMargeCertaine(tache, successeur.Noeud) < temp)
                {
                    temp = CalculerMargeCertaine(tache, successeur.Noeud);
                }
            }
            tache.MargeCertaine = temp;
        }

        // Algorithme MPM
        public List<List<Tache>> OrdonnerTache()
        {
            PlacerNoeudFictif();

            List<List<Tache>> niveaux = Graphe.DecomposerEnNiveau();

            for (int i = 0; i < niveaux.Count; i++)
            {
                CalculerDatePlutot(niveaux[i]);
            }

            // Tache Fin
            niveaux[niveaux.Count - 1][0].DebutPlustard = niveaux[niveaux.Count - 1][0].DebutPlutot;

            for (int i = niveaux.Count - 2; i > 0; i--)
            {
                CalculerDatePlutard(niveaux[i]);
            }

            // Marge totale + marge libre + marge certaine
            for(int i = 0; i < niveaux.Count; i++)
            {
                for(int j = 0; j < niveaux[i].Count; j++)
                {
                    CalculerMargeTotal(niveaux[i][j]);
                    CalculerMargeLibre(niveaux[i][j]);
                    CalculerMargeCertaine(niveaux[i][j]);
                }
            }

            return niveaux;
        }

        // Chemin critique
        public Arbre<Tache> GetCheminCritique()
        {
            Arbre<Tache> resultat = new Arbre<Tache>();
            Tache debut = Graphe.GetSansPredecesseur()[0];
            resultat.AjouterPere(debut);
            List<Predecesseur<Tache>> sucesseurs = Graphe.Successeurs[debut];
            while(sucesseurs.Count != 0)
            {
                foreach(var successeur in sucesseurs)
                { 
                }
            }
            return resultat;
        }
        
    }
}
