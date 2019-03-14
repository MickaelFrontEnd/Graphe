using System.Collections.Generic;
using System.Linq;

namespace Graphe.Algo
{
    class Graphe<T>
    {
        public Dictionary<T, List<Predecesseur<T>>> Predecesseurs { get; set; } = new Dictionary<T, List<Predecesseur<T>>>();
        public Dictionary<T, List<Predecesseur<T>>> Successeurs { get; set; } = new Dictionary<T, List<Predecesseur<T>>>();

        // Ajout noeud
        public void AjouterNoeud(T noeud)
        {
            if(!Predecesseurs.ContainsKey(noeud))
            {
                Predecesseurs.Add(noeud, new List<Predecesseur<T>>());
            }
            if(!Successeurs.ContainsKey(noeud))
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

        // Ajout noeud + plusieur predecesseur
        public void AjouterNoeud(T noeud, List<Predecesseur<T>> predecesseurs)
        {
            AjouterNoeud(noeud);
            Predecesseurs[noeud].AddRange(predecesseurs);

            foreach(var item in predecesseurs)
            {
                AjouterNoeud(item.Noeud);
                Successeurs[item.Noeud].Add(new Predecesseur<T>(noeud));
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

        // Degré moins
        public int GetDegreMoins(T noeud)
        {
            if(Predecesseurs.ContainsKey(noeud))
            {
                return Predecesseurs[noeud].Count;
            }
            return 0;
        }

        // Degré plus
        public int GetDegrePlus(T noeud)
        {
            if(Successeurs.ContainsKey(noeud))
            {
                return Successeurs[noeud].Count;
            }
            return 0;
        }

        // Degré
        public int GetDegre(T noeud)
        {
            return GetDegreMoins(noeud) + GetDegrePlus(noeud);
        }

        // Adjacent
        public int EstAdjacent(T A, T B)
        {
            if(Predecesseurs.ContainsKey(B))
            {
                return Predecesseurs[B].Any(x => x.Noeud.Equals(A)) ? 1 : 0;
            }
            return 0;
        }

        // Capacite (coût)
        public double GetCout(T A, T B)
        {
            if(A.Equals(B))
            {
                return 0;
            }
            else
            {
                return EstAdjacent(A, B) == 1 ? Predecesseurs[B].Single(x => x.Noeud.Equals(A)).Capacite : double.PositiveInfinity;
            }
        }

    }
}
