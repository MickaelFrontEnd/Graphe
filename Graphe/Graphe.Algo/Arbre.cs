using System.Collections.Generic;

namespace Graphe.Algo
{
    class Arbre<T>
    {
        public T Noeud { get; set; }
        public List<Arbre<T>> Fils { get; set; }

        // Ajout pere
        public void AjouterPere(T noeud)
        {
            this.Noeud = noeud;
            this.Fils = new List<Arbre<T>>();
        }

        // Ajout fils
        public void AjouterFils(T noeud)
        {
            Arbre<T> arbre = new Arbre<T>();
            arbre.AjouterPere(noeud);
            this.Fils.Add(arbre);
        }

        // Ajout fils
        public void AjouterFils(Arbre<T> arbre)
        {
            this.Fils.Add(arbre);
        }
    }
}
