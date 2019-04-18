

using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphe
{
    public partial class GrapheO<T>
    {
        // TODO: Refactoriser l'algorithme de Welsh and Powell
        public List<NoeudCouleur<T>> ColorerGraphe()
        {
            List<NoeudCouleur<T>> resultat = new List<NoeudCouleur<T>>();
            List<T> sommets = ExtraireSommet("desc");
            List<T> sommetColores = new List<T>();

            var random = new Random();
            string couleur;
            int index = 0;

            // Tant que tous les sommets ne sont pas encores colorés
            while (sommets.Count != sommetColores.Count)
            {
                couleur = String.Format("#{0:X6}", random.Next(0x1000000));
                index = 0;
                foreach(var sommet in sommets)
                {
                    if(!sommetColores.Any(x => x.Equals(sommet)))
                    {
                        // Premier sommet non encore coloré
                        if (index == 0)
                        {
                            resultat.Add(new NoeudCouleur<T>()
                            {
                                Noeud = sommet,
                                Couleur = couleur
                            });
                            sommetColores.Add(sommet);
                            index++;
                        }
                        else
                        {
                            List<NoeudCouleur<T>> sommetEnCouleur = resultat.FindAll(x => x.Couleur.CompareTo(couleur) == 0);
                            bool estAdjacent = false;

                            foreach (var sommetColore in sommetEnCouleur)
                            {
                                if (EstTotalementAdjacent(sommetColore.Noeud, sommet))
                                {
                                    estAdjacent = true;
                                }

                            }

                            if (!estAdjacent)
                            {
                                resultat.Add(new NoeudCouleur<T>()
                                {
                                    Noeud = sommet,
                                    Couleur = couleur
                                });
                                sommetColores.Add(sommet);
                            }
                        }
                    }                   
                }
            }

            return resultat;
        }
    }
}
