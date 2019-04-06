

using System.Collections.Generic;

namespace Graphe
{
    public partial class Graphe<T>
    {
        // Algorithme de Dijkstra
        public void GetChemin(Arbre<T> resultat, List<Noeud<T>> choisies, List<Noeud<T>> nonChoisies, T depart, double cout, int sens = 0)
        {
            // Initialisation
            if (choisies.Count == 0)
            {
                resultat.AjouterPere(depart);
                choisies.Add(new Noeud<T>()
                {
                    Depart = depart,
                    Arrive = depart,
                    Cout = 0
                });
            }

            // Avoir tout les successeurs
            List<Predecesseur<T>> successeurs = GetSuccesseur(depart);

            // Pour chaque successeur
            foreach (var successeur in successeurs)
            {
                if (!choisies.Exists(x => x.Arrive.Equals(successeur.Noeud)))
                {
                    nonChoisies.Add(new Noeud<T>()
                    {
                        Depart = depart,
                        Arrive = successeur.Noeud,
                        Cout = cout + GetCout(depart, successeur.Noeud)
                    });
                }
            }

            Noeud<T> noeud = sens == 0 ? Noeud<T>.GetPlusPetitCout(nonChoisies) : Noeud<T>.GetPlusGrandCout(nonChoisies);

            if (noeud != null)
            {
                choisies.Add(noeud);
                nonChoisies.Remove(noeud);
                nonChoisies.RemoveAll(x => x.Arrive.Equals(noeud.Arrive));

                Arbre<T> fils = new Arbre<T>();
                fils.AjouterPere(noeud.Arrive);
                resultat.AjouterFils(fils);

                // Continue
                GetChemin(fils, choisies, nonChoisies, noeud.Arrive, noeud.Cout, sens);
            }
        }

        // Algorthme de Dijkstra / Plus court chemin
        public void GetPlusCourtChemin(Arbre<T> resultat, List<Noeud<T>> choisies, List<Noeud<T>> nonChoisies, T depart, double cout)
        {
            GetChemin(resultat, choisies, nonChoisies, depart, 0, 0);
        }

        // Algorithme de Dijkstra / Plus court chemin
        public Arbre<T> GetPlusCourtChemin(T depart)
        {
            Arbre<T> resultat = new Arbre<T>();
            List<Noeud<T>> choisies = new List<Noeud<T>>();
            List<Noeud<T>> nonChoisies = new List<Noeud<T>>();

            GetPlusCourtChemin(resultat, choisies, nonChoisies, depart, 0);
            return resultat;
        }

        // Algorithme de Dijkstra / Plus court chemin
        public Arbre<T> GetPlusCourtChemin()
        {
            List<T> sansPredecesseurs = GetSansPredecesseur();
            if (sansPredecesseurs.Count == 0) return null;
            return GetPlusCourtChemin(sansPredecesseurs[0]);
        }

        // Algorthme de Dijkstra / Plus long chemin
        public void GetPlusLongChemin(Arbre<T> resultat, List<Noeud<T>> choisies, List<Noeud<T>> nonChoisies, T depart, double cout)
        {
            GetChemin(resultat, choisies, nonChoisies, depart, 0, 1);
        }

        // Algorithme de Dijkstra / Plus long chemin
        public Arbre<T> GetPlusLongChemin(T depart)
        {
            Arbre<T> resultat = new Arbre<T>();
            List<Noeud<T>> choisies = new List<Noeud<T>>();
            List<Noeud<T>> nonChoisies = new List<Noeud<T>>();

            GetPlusLongChemin(resultat, choisies, nonChoisies, depart, 0);
            return resultat;
        }

        // Algorithme de Dijkstra / Plus long chemin
        public Arbre<T> GetPlusLongChemin()
        {
            List<T> sansPredecesseurs = GetSansPredecesseur();
            if (sansPredecesseurs.Count == 0) return null;
            return GetPlusLongChemin(sansPredecesseurs[0]);
        }
    }
}
