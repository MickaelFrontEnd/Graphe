using System.Collections.Generic;

namespace Graphe.Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphe<string> graphe = new Graphe<string>();
            string A = "A", B = "B", C = "C", D = "D", E = "E", F = "F";

            graphe.AjouterNoeud(A);
            graphe.AjouterNoeud(B);
            graphe.AjouterNoeud(C);
            graphe.AjouterNoeud(D);
            graphe.AjouterNoeud(E);
            graphe.AjouterNoeud(F);

            graphe.AjouterArc(A, B, 7);
            graphe.AjouterArc(A, D, 15);
            graphe.AjouterArc(B, C, 12);
            graphe.AjouterArc(B, F, 16);
            graphe.AjouterArc(B, E, 4);
            graphe.AjouterArc(D, C, 5);
            graphe.AjouterArc(D, E, 2);
            graphe.AjouterArc(C, F, 3);
            graphe.AjouterArc(E, F, 14);

            Arbre<string> arbre = graphe.GetPlusLongChemin(A);

            System.Console.WriteLine(arbre.Fils[0].Fils[0].Fils[0].Noeud);
            System.Console.ReadLine();

        }
    }
}
