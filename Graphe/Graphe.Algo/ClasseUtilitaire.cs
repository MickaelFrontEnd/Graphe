

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

    // Tache
    public class Tache
    {
        public string Nom { get; set; }
        public int Durree { get; set; }
        public int DebutPlutot { get; set; } = 0;
        public int DebutPlustard { get; set; } = 0;
        public int MargeTotale { get; set; } = 0;
        public int MargeLibre { get; set; }
        public int MargeCertaine { get; set; }

        public Tache(string nom)
        {
            this.Nom = nom;
        }

        public Tache(string nom, int durree)
        {
            this.Nom = nom;
            this.Durree = durree;
        }
    }
}
