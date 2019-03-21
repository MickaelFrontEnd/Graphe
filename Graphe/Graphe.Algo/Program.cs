using System.Collections.Generic;

namespace Graphe.Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphe<string> graphe = new Graphe<string>();
            string A = "A", B = "B", C = "C", D = "D", E = "E";

            graphe.AjouterNoeud(A);
            graphe.AjouterNoeud(B);
            graphe.AjouterNoeud(C);
            graphe.AjouterNoeud(D);

            graphe.AjouterArc(A, B, 2);
            graphe.AjouterArc(A, C, 1);
            graphe.AjouterArc(A, E, 10);
            graphe.AjouterArc(B, D, 5);
            graphe.AjouterArc(B, C, 7);
            graphe.AjouterArc(D, C, 3);

            List<List<string>> niveaux = graphe.DecomposerEnNiveau();
            foreach(List<string> niveau in niveaux)
            {
                foreach(string noeud in niveau)
                {
                    System.Console.Write(noeud + " ");
                }
                System.Console.WriteLine();
            }
            System.Console.ReadLine();
        }
    }
}
