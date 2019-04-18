

namespace Graphe
{
    public class Predecesseur<T>
    {
        public T Noeud { get; set; }
        public double Capacite { get; set; }
        public double Flot { get; set; }
        public double Cout { get; set; }

        public Predecesseur()
        {

        }

        public Predecesseur(T noeud)
        {
            this.Noeud = noeud;
        }
    }
}
