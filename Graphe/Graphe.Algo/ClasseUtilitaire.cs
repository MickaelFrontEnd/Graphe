

namespace Graphe
{
    // Base classe avec noeud
    public class BaseNoeud<T>
    {
        public T Noeud { get; set; }
    }
    
    // Noeud + Degres
    public class NoeudDegre<T> : BaseNoeud<T>
    {
        public int Degres { get; set; }
    }

    // Noeud + Couleur
    public class NoeudCouleur<T> : BaseNoeud<T>
    {
        public string Couleur { get; set; }
    }
}
