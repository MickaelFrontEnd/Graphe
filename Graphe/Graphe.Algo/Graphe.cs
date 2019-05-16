using System.Collections.Generic;
using System.Linq;

namespace Graphe
{
    public partial class GrapheO<T>
    {
        // Propriété
        public Dictionary<T, List<Predecesseur<T>>> Predecesseurs { get; set; } = new Dictionary<T, List<Predecesseur<T>>>();
        public Dictionary<T, List<Predecesseur<T>>> Successeurs { get; set; } = new Dictionary<T, List<Predecesseur<T>>>();

        // Constructeur
        public GrapheO() { }

        // Ajout noeud
        public void AjouterNoeud(T noeud)
        {
            if (!Predecesseurs.ContainsKey(noeud))
            {
                Predecesseurs.Add(noeud, new List<Predecesseur<T>>());
            }
            if (!Successeurs.ContainsKey(noeud))
            {
                Successeurs.Add(noeud, new List<Predecesseur<T>>());
            }
        }

        // Ajout noeud + un predecesseur
        public void AjouterNoeud(T noeud, Predecesseur<T> predecesseur)
        {
            AjouterNoeud(noeud);
            Predecesseurs[noeud].Add(predecesseur);

            AjouterNoeud(predecesseur.Noeud);
            Successeurs[predecesseur.Noeud].Add(new Predecesseur<T>(noeud));
        }

        // Ajout noeud + un predecesseur + capacité
        public void AjouterNoeud(T noeud, Predecesseur<T> predecesseur, double capacite)
        {
            predecesseur.Capacite = capacite;
            AjouterNoeud(noeud, predecesseur);
        }

        // Ajout noeud + un predecesseur + capacité + cout
        public void AjouterNoeud(T noeud, Predecesseur<T> predecesseur, double capacite, double cout)
        {
            predecesseur.Capacite = capacite;
            predecesseur.Cout = cout;
            AjouterNoeud(noeud, predecesseur);
        }

        // Ajout noeud + plusieur predecesseur
        public void AjouterNoeud(T noeud, List<Predecesseur<T>> predecesseurs)
        {
            AjouterNoeud(noeud);
            Predecesseurs[noeud].AddRange(predecesseurs);

            foreach (var item in predecesseurs)
            {
                AjouterNoeud(item.Noeud);
                Successeurs[item.Noeud].Add(new Predecesseur<T>(noeud));
            }
        }

        // Modification noeud
        public void ModifierNoeud(T noeudAncien, T noeudNouveau)
        {
            List<Predecesseur<T>> predecesseurs = Predecesseurs[noeudAncien];
            List<Predecesseur<T>> successeurs = Successeurs[noeudAncien];

            Predecesseurs.Remove(noeudAncien);
            Successeurs.Remove(noeudAncien);

            Predecesseurs.Add(noeudNouveau, predecesseurs);
            Successeurs.Add(noeudNouveau, successeurs);

            foreach (var key in Predecesseurs.Keys)
            {
                foreach(var item in Predecesseurs[key])
                {
                    if(item.Noeud.Equals(noeudAncien))
                    {
                        item.Noeud = noeudNouveau;
                    }
                }
            }

            foreach (var key in Successeurs.Keys)
            {
                foreach (var item in Successeurs[key])
                {
                    if (item.Noeud.Equals(noeudAncien))
                    {
                        item.Noeud = noeudNouveau;
                    }
                }
            }
        }

        // Ajout arc
        public void AjouterArc(T A, T B)
        {
            AjouterNoeud(B, new Predecesseur<T>(A));
        }

        // Ajout arc + capacite
        public void AjouterArc(T A, T B, double capacite)
        {
            AjouterNoeud(B, new Predecesseur<T>(A), capacite);
        }

        // Ajout arc + capacite + cout
        public void AjouterArc(T A, T B, double capacite, double cout)
        {
            AjouterNoeud(B, new Predecesseur<T>(A), capacite, cout);
        }

        // Degré moins
        public int GetDegreMoins(T noeud)
        {
            return Predecesseurs[noeud]?.Count ?? 0;
        }

        // Degré plus
        public int GetDegrePlus(T noeud)
        {
            return Successeurs[noeud]?.Count ?? 0;
        }

        // Degré
        public int GetDegre(T noeud)
        {
            return GetDegreMoins(noeud) + GetDegrePlus(noeud);
        }

        // Degré moins en tant que dictionnaire
        public Dictionary<T,int> GetDegreMoins()
        {
            Dictionary<T, int> niveaux = new Dictionary<T, int>();
            foreach (var key in Predecesseurs.Keys)
            {
                niveaux.Add(key, GetDegreMoins(key));
            }
            return niveaux;
        }

        // Adjacent
        public int EstAdjacent(T A, T B)
        {
            if (Predecesseurs.ContainsKey(B))
            {
                return Predecesseurs[B].Any(x => x.Noeud.Equals(A)) ? 1 : 0;
            }
            return 0;
        }

        // Totalement adjacent
        public bool EstTotalementAdjacent(T A, T B)
        {
            return EstAdjacent(A, B) == 1 || EstAdjacent(B, A) == 1;
        }

        // Capacite (coût)
        public double GetCout(T A, T B)
        {
            if (A.Equals(B))
            {
                return 0;
            }
            else
            {
                return EstAdjacent(A, B) == 1 ? Predecesseurs[B].Single(x => x.Noeud.Equals(A)).Capacite : double.PositiveInfinity;
            }
        }

        // Noeud sans predecesseur
        public List<T> GetSansPredecesseur()
        {
            List<T> resultat = new List<T>();
            foreach (var key in Predecesseurs.Keys)
            {
                if (Predecesseurs[key].Count == 0)
                {
                    resultat.Add(key);
                }
            }
            return resultat;
        }

        // Noeud sans successeur
        public List<T> GetSansSuccesseur()
        {
            List<T> resultat = new List<T>();
            foreach (var key in Successeurs.Keys)
            {
                if(Successeurs[key].Count == 0)
                {
                    resultat.Add(key);
                }
            }
            return resultat;
        }

        public Dictionary<T, List<Predecesseur<T>>> Cloner(Dictionary<T, List<Predecesseur<T>>> originale)
        {
            Dictionary<T, List<Predecesseur<T>>> resultat = new Dictionary<T, List<Predecesseur<T>>>();
            foreach(T key in originale.Keys)
            {
                resultat.Add(key, originale[key]);
            }
            return resultat;
        }

        // Supprimer noeud
        public void SupprimerNoeud(Dictionary<T, List<Predecesseur<T>>> source, T noeud)
        {
            source.Remove(noeud);

            foreach (var key in source.Keys)
            {
                source[key].RemoveAll(x => x.Noeud.Equals(noeud));
            }
        }

        // Supprimer plusieurs noeuds
        public void SupprimerNoeud(Dictionary<T, List<Predecesseur<T>>> source, List<T> noeud)
        {
            foreach (T item in noeud)
            {
                SupprimerNoeud(source, noeud);
            }
        }

        // Suppression noeud
        public void SupprimerNoeud(T noeud)
        {
            SupprimerNoeud(this.Predecesseurs, noeud);
            SupprimerNoeud(this.Successeurs, noeud);
        }

        // Suppression plusieurs noeuds
        public void SupprimerNoeud(List<T> noeud)
        {
            SupprimerNoeud(this.Predecesseurs, noeud);
            SupprimerNoeud(this.Successeurs, noeud);
        }

        // Suppression noeud sans predecesseur
        public List<T> SupprimerSansPredecesseur()
        {
            List<T> resultat = GetSansPredecesseur();
            foreach (T noeud in resultat)
            {
                SupprimerNoeud(noeud);
            }
            return resultat;
        }

        // Savoir si une graphe est vide
        public bool EstVide()
        {
            return this.Predecesseurs.Count == 0 && this.Successeurs.Count == 0;
        }

        // Decomposition en niveau
        public List<List<T>> DecomposerEnNiveau()
        {
            // Initialisation
            Dictionary<T, int> degresMoins = GetDegreMoins();
            List<T> dejaTraite = new List<T>();
            List<List<T>> resultat = new List<List<T>>();
            List<Predecesseur<T>> successeurs;

            // Niveau 1
            List<T> niveau1 = GetSansPredecesseur();
            resultat.Add(niveau1);
            dejaTraite.AddRange(niveau1);

            // Variable temporaire
            List<T> temp = niveau1;
            List<T> niveauEnCours = new List<T>();

            while(dejaTraite.Count != Predecesseurs.Count)
            {
                niveauEnCours = new List<T>();
                foreach (var item in temp)
                {
                    successeurs = Successeurs[item];
                    foreach(Predecesseur<T> successeur in successeurs)
                    {
                        degresMoins[successeur.Noeud]--;
                        if(degresMoins[successeur.Noeud] == 0)
                        {
                            niveauEnCours.Add(successeur.Noeud);
                            dejaTraite.Add(successeur.Noeud);
                        }
                    }
                }
                resultat.Add(niveauEnCours);
                temp = niveauEnCours;
            }

            return resultat;
        }
         
        // Obtient tout les successeurs
        public List<Predecesseur<T>> GetSuccesseur(T noeud)
        {
            if(Successeurs.ContainsKey(noeud))
            {
                return Successeurs[noeud];
            }
            return null;
        }

        // Parcours en profondeur
        public void ParcourirEnProfondeur(Arbre<T> resultat,List<T> noeudParcourues, T noeudDepart)
        {    
            // Pere de l'arbre
            if(noeudParcourues.Count == 0)
            {
                resultat.AjouterPere(noeudDepart);
            }

            // Contient tout les noeuds déjà parcourue
            noeudParcourues.Add(noeudDepart);

            // Successeurs
            List<Predecesseur<T>> successeurs = GetSuccesseur(noeudDepart);
            foreach(var successeur in successeurs)
            {
                if(!noeudParcourues.Exists(x => x.Equals(successeur.Noeud)))
                {
                    // Ajout d'un nouveau fils
                    Arbre<T> arbre = new Arbre<T>();
                    arbre.AjouterPere(successeur.Noeud);
                    resultat.AjouterFils(arbre);

                    ParcourirEnProfondeur(arbre, noeudParcourues,successeur.Noeud);
                }
            }
        }

        // Parcours en profondeur
        public Arbre<T> ParcourirEnProfondeur(T noeudDepart)
        {
            Arbre<T> resultat = new Arbre<T>();
            List<T> noeudParcourues = new List<T>();
            ParcourirEnProfondeur(resultat, noeudParcourues, noeudDepart);
            return resultat;
        }

        // Parcours en profondeur
        public Arbre<T> ParcourirEnProfondeur()
        {
            List<T> noeuds = GetSansPredecesseur();
            if(noeuds.Count != 0)
            {
                return ParcourirEnProfondeur(noeuds[0]);
            }
            return null;
        }

        // Parcours en largeur
        public void ParcourirEnLargeur(Arbre<T> resultat, List<T> noeudParcourues, T noeudDepart)
        {
            List<Predecesseur<T>> successeurs = GetSuccesseur(noeudDepart);
            List<Arbre<T>> arbres = new List<Arbre<T>>();
            List<Predecesseur<T>> parcoursSuivants = new List<Predecesseur<T>>();

            // Départ 
            if(noeudParcourues.Count == 0)
            {
                noeudParcourues.Add(noeudDepart);
                resultat.AjouterPere(noeudDepart);
            }

            // Ajouter chaque successeur s'il ne sont pas encore visité
            foreach (var successeur in successeurs)
            {
                if(!noeudParcourues.Exists(x => x.Equals(successeur)))
                {
                    // Création d'un nouveau noeud
                    Arbre<T> arbre = new Arbre<T>();
                    arbre.AjouterPere(successeur.Noeud);

                    // Ajout du noeud en tant que fils
                    resultat.AjouterFils(arbre);
                    arbres.Add(arbre);
                    
                    // Ajout dans noeud parcourues + à parcourir
                    noeudParcourues.Add(successeur.Noeud);
                    parcoursSuivants.Add(successeur);
                }
            }

            for(int i = 0; i < parcoursSuivants.Count; i++)
            {
                ParcourirEnLargeur(arbres[i], noeudParcourues, parcoursSuivants[i].Noeud);
            }
        }

        // Parcours en largeur
        public Arbre<T> ParcourirEnLargeur(T noeudDepart)
        {
            Arbre<T> resultat = new Arbre<T>();
            List<T> noeudParcourues = new List<T>();
            ParcourirEnLargeur(resultat, noeudParcourues, noeudDepart);
            return resultat;
        }

        // Parcours en largeur
        public Arbre<T> ParcourirEnLargeur()
        {
            List<T> noeuds = GetSansPredecesseur();
            if (noeuds.Count != 0)
            {
                return ParcourirEnLargeur(noeuds[0]);
            }
            return null;
        }

        // Trier les noeuds par degrés decroissant
        public GrapheO<T> TrierParDegres(string ordre = "asc")
        {
            GrapheO<T> graphe = new GrapheO<T>();
            List<NoeudDegre<T>> noeuds = new List<NoeudDegre<T>>();

            foreach (KeyValuePair<T,List<Predecesseur<T>>> entree in Predecesseurs)
            {
                noeuds.Add(new NoeudDegre<T>()
                {
                    Noeud = entree.Key,
                    Degres = this.GetDegre(entree.Key)
                });
            }

            if(ordre.CompareTo("asc") == 0)
            {
                noeuds.Sort((x1, x2) => x1.Degres - x2.Degres);
            }
            else
            {
                noeuds.Sort((x1, x2) => x2.Degres - x1.Degres);
            }
            

            foreach(var noeud in noeuds)
            {
                graphe.Predecesseurs.Add(noeud.Noeud, Predecesseurs[noeud.Noeud]);
                graphe.Successeurs.Add(noeud.Noeud, Successeurs[noeud.Noeud]);
            }

            return graphe;
        }

        // Extraire juste les sommets
        public List<T> ExtraireSommet()
        {
            List<T> resultat = new List<T>();
            foreach (KeyValuePair<T, List<Predecesseur<T>>> entree in Predecesseurs)
            {
                resultat.Add(entree.Key);
            }
            return resultat;
        }

        // Extraire sommet + ordre  des degrés
        public List<T> ExtraireSommet(string ordre = "asc")
        {
            GrapheO<T> graphe = TrierParDegres(ordre);
            return graphe.ExtraireSommet();
        }
    }
}
