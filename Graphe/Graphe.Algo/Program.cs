using System.Collections.Generic;

namespace Graphe.Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphe<string> graphe = new Graphe<string>();
            string A = "A", B = "B", C = "C", D = "D";

            graphe.AjouterNoeud(A);
            graphe.AjouterNoeud(B);
            graphe.AjouterNoeud(C);
            graphe.AjouterNoeud(D);

            graphe.AjouterArc(A, B, 2);
            graphe.AjouterArc(A, C, 1);
            graphe.AjouterArc(B, D, 5);
            graphe.AjouterArc(B, C, 7);
            graphe.AjouterArc(D, C, 3);

            Arbre<string> arbre = graphe.ParcourirEnProfondeur();
            System.Console.Write("Fils de B: ");
            foreach(Arbre<string> fils in arbre.Fils[0].Fils)
            {
                System.Console.Write(fils.Noeud + " ");
            }
            System.Console.ReadLine();
        }
    }
}
