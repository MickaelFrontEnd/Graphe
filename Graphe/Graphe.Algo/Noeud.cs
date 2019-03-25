
using System.Collections.Generic;

namespace Graphe.Algo
{
    class Noeud<T>
    {
        public T Depart { get; set; }
        public T Arrive { get; set; }
        public double Cout { get; set; }

        public static Noeud<T> GetPlusPetitCout(List<Noeud<T>> noeuds)
        {
            if (noeuds.Count == 0) return null;

            noeuds.Sort((x1, x2) => x1.Cout.CompareTo(x2.Cout));
            return noeuds[0];
        }

        public static Noeud<T> GetPlusGrandCout(List<Noeud<T>> noeuds)
        {
            if (noeuds.Count == 0) return null;

            noeuds.Sort((x1, x2) => x2.Cout.CompareTo(x1.Cout));
            return noeuds[0];
        }
    }
}
