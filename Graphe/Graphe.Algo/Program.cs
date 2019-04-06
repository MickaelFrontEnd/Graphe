

using System.Collections.Generic;

namespace Graphe
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphe<string> graphe = new Graphe<string>();
            string A = "A", B = "B", C = "C", D = "D", E = "E", F = "F", G = "G";

            graphe.AjouterNoeud(A);
            graphe.AjouterNoeud(B);
            graphe.AjouterNoeud(C);
            graphe.AjouterNoeud(D);
            //graphe.AjouterNoeud(E);
            //graphe.AjouterNoeud(F);
            //graphe.AjouterNoeud(G);

            graphe.AjouterArc(A, B, 7);
            graphe.AjouterArc(B, C, 7);
            graphe.AjouterArc(B, D, 7);
            graphe.AjouterArc(C, D, 7);


            List<NoeudCouleur<string>> ColorerGraphe = graphe.ColorerGraphe();
            
            foreach(var item in ColorerGraphe)
            {
                System.Console.WriteLine(string.Format("{0}: {1}",item.Noeud,item.Couleur));
            }

            System.Console.ReadLine();
        }
    }
}
