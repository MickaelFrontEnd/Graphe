using System.Collections.Generic;

namespace Graphe.Algo
{
    class Arbre<T>
    {
        public T Noeud { get; set; }
        public List<Arbre<T>> Fils { get; set; }
    }
}
