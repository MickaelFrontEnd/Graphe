using System.Collections.Generic;

namespace Graphe
{
    public class Arbre<T>
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
        
        // Rechercher un fils
        public Arbre<T> GetFils(T fils)
        {
            foreach (var item in Fils)
            {
                if (item.Noeud.Equals(fils))
                {
                    return item;
                }
                else
                {
                    GetFils(item.Noeud);
                }
            }
            return null;
        }
    }
}
