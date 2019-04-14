

using System.Collections.Generic;

namespace Graphe
{
    class Program
    {
        static void Main(string[] args)
        {
            Mpm mpm = new Mpm();

            Tache A = new Tache("A",2);
            Tache B = new Tache("B",4);
            Tache C = new Tache("C",4);
            Tache D = new Tache("D",5);
            Tache E = new Tache("E",6);

            mpm.AjouterTache(A);
            mpm.AjouterTache(B);
            mpm.AjouterTache(C);
            mpm.AjouterTache(D);
            mpm.AjouterTache(E);

            mpm.AjouterPredecesseur(C, A);
            mpm.AjouterPredecesseur(D, A);
            mpm.AjouterPredecesseur(D, B);
            mpm.AjouterPredecesseur(E, C);
            mpm.AjouterPredecesseur(E, D);

            mpm.OrdonnerTache();

            foreach (var key in mpm.Graphe.Predecesseurs.Keys)
            {
                //System.Console.WriteLine(key.Nom + " " + key.Durree + " " + key.DebutPlutot + " " + key.DebutPlustard);
            }
            
            System.Console.WriteLine(A.MargeLibre);

            System.Console.ReadLine();
        }
    }
}
