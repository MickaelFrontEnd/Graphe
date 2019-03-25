﻿using System.Collections.Generic;
using System.Linq;

namespace Graphe.Algo
{
    class Graphe<T>
    {
        // Propriété
        public Dictionary<T, List<Predecesseur<T>>> Predecesseurs { get; set; } = new Dictionary<T, List<Predecesseur<T>>>();
        public Dictionary<T, List<Predecesseur<T>>> Successeurs { get; set; } = new Dictionary<T, List<Predecesseur<T>>>();

        // Constructeur
        public Graphe() { }

        // Ajout noeud
        public void AjouterNoeud(T noeud)
        {
            if (!Predecesseurs.ContainsKey(noeud))
            {
                Predecesseurs.Add(noeud, new List<Predecesseur<T>>());
            }
            if (!Successeurs.ContainsKey(noeud))
            {
                Successeurs.Add(noeud, new List<Predecesseur<T>>());
            }
        }

        // Ajout noeud + un predecesseur
        public void AjouterNoeud(T noeud, Predecesseur<T> predecesseur)
        {
            AjouterNoeud(noeud);
            Predecesseurs[noeud].Add(predecesseur);

            AjouterNoeud(predecesseur.Noeud);
            Successeurs[predecesseur.Noeud].Add(new Predecesseur<T>(noeud));
        }

        // Ajout noeud + un predecesseur + capacité
        public void AjouterNoeud(T noeud, Predecesseur<T> predecesseur, double capacite)
        {
            predecesseur.Capacite = capacite;
            AjouterNoeud(noeud, predecesseur);
        }

        // Ajout noeud + plusieur predecesseur
        public void AjouterNoeud(T noeud, List<Predecesseur<T>> predecesseurs)
        {
            AjouterNoeud(noeud);
            Predecesseurs[noeud].AddRange(predecesseurs);

            foreach (var item in predecesseurs)
            {
                AjouterNoeud(item.Noeud);
                Successeurs[item.Noeud].Add(new Predecesseur<T>(noeud));
            }
        }

        // Ajout arc
        public void AjouterArc(T A, T B)
        {
            AjouterNoeud(B, new Predecesseur<T>(A));
        }

        // Ajout arc + capacite
        public void AjouterArc(T A, T B, double capacite)
        {
            AjouterNoeud(B, new Predecesseur<T>(A), capacite);
        }

        // Degré moins
        public int GetDegreMoins(T noeud)
        {
            return Predecesseurs[noeud]?.Count ?? 0;
        }

        // Degré plus
        public int GetDegrePlus(T noeud)
        {
            return Successeurs[noeud]?.Count ?? 0;
        }

        // Degré
        public int GetDegre(T noeud)
        {
            return GetDegreMoins(noeud) + GetDegrePlus(noeud);
        }

        // Adjacent
        public int EstAdjacent(T A, T B)
        {
            if (Predecesseurs.ContainsKey(B))
            {
                return Predecesseurs[B].Any(x => x.Noeud.Equals(A)) ? 1 : 0;
            }
            return 0;
        }

        // Capacite (coût)
        public double GetCout(T A, T B)
        {
            if (A.Equals(B))
            {
                return 0;
            }
            else
            {
                return EstAdjacent(A, B) == 1 ? Predecesseurs[B].Single(x => x.Noeud.Equals(A)).Capacite : double.PositiveInfinity;
            }
        }

        // Noeud sans predecesseur
        public List<T> GetSansPredecesseur()
        {
            List<T> resultat = new List<T>();
            foreach (var key in Predecesseurs.Keys)
            {
                if (Predecesseurs[key].Count == 0)
                {
                    resultat.Add(key);
                }
            }
            return resultat;
        }

        // Cloner predecesseur
        public Graphe<T> Cloner()
        {
            return new Graphe<T>()
            {
                Predecesseurs = this.Predecesseurs.ToDictionary(e => e.Key, e => e.Value),
                Successeurs = this.Successeurs.ToDictionary(e => e.Key, e => e.Value)
            };
        }

        // Supprimer noeud
        public void SupprimerNoeud(Dictionary<T, List<Predecesseur<T>>> source, T noeud)
        {
            source.Remove(noeud);

            foreach (var key in source.Keys)
            {
                source[key].RemoveAll(x => x.Noeud.Equals(noeud));
            }
        }

        // Supprimer plusieurs noeuds
        public void SupprimerNoeud(Dictionary<T, List<Predecesseur<T>>> source, List<T> noeud)
        {
            foreach (T item in noeud)
            {
                SupprimerNoeud(source, noeud);
            }
        }

        // Suppression noeud
        public void SupprimerNoeud(T noeud)
        {
            SupprimerNoeud(this.Predecesseurs, noeud);
            SupprimerNoeud(this.Successeurs, noeud);
        }

        // Suppression plusieurs noeuds
        public void SupprimerNoeud(List<T> noeud)
        {
            SupprimerNoeud(this.Predecesseurs, noeud);
            SupprimerNoeud(this.Successeurs, noeud);
        }

        // Suppression noeud sans predecesseur
        public List<T> SupprimerSansPredecesseur()
        {
            List<T> resultat = GetSansPredecesseur();
            foreach (T noeud in resultat)
            {
                SupprimerNoeud(noeud);
            }
            return resultat;
        }

        // Savoir si une graphe est vide
        public bool EstVide()
        {
            return this.Predecesseurs.Count == 0 && this.Successeurs.Count == 0;
        }

        // Decomposition en niveau
        public List<List<T>> DecomposerEnNiveau()
        {
            List<List<T>> resultat = new List<List<T>>();
            Graphe<T> graphe = Cloner();
            while (!graphe.EstVide())
            {
                resultat.Add(graphe.SupprimerSansPredecesseur());
            }
            return resultat;
        }

        // Obtient tout les successeurs
        public List<Predecesseur<T>> GetSuccesseur(T noeud)
        {
            if(Successeurs.ContainsKey(noeud))
            {
                return Successeurs[noeud];
            }
            return null;
        }

        // Parcours en profondeur
        public void ParcourirEnProfondeur(Arbre<T> resultat,List<T> noeudParcourues, T noeudDepart)
        {    
            // Pere de l'arbre
            if(noeudParcourues.Count == 0)
            {
                resultat.AjouterPere(noeudDepart);
            }

            // Contient tout les noeuds déjà parcourue
            noeudParcourues.Add(noeudDepart);

            // Successeurs
            List<Predecesseur<T>> successeurs = GetSuccesseur(noeudDepart);
            foreach(var successeur in successeurs)
            {
                if(!noeudParcourues.Exists(x => x.Equals(successeur.Noeud)))
                {
                    // Ajout d'un nouveau fils
                    Arbre<T> arbre = new Arbre<T>();
                    arbre.AjouterPere(successeur.Noeud);
                    resultat.AjouterFils(arbre);

                    ParcourirEnProfondeur(arbre, noeudParcourues,successeur.Noeud);
                }
            }
        }

        // Parcours en profondeur
        public Arbre<T> ParcourirEnProfondeur(T noeudDepart)
        {
            Arbre<T> resultat = new Arbre<T>();
            List<T> noeudParcourues = new List<T>();
            ParcourirEnProfondeur(resultat, noeudParcourues, noeudDepart);
            return resultat;
        }

        // Parcours en profondeur
        public Arbre<T> ParcourirEnProfondeur()
        {
            List<T> noeuds = GetSansPredecesseur();
            if(noeuds.Count != 0)
            {
                return ParcourirEnProfondeur(noeuds[0]);
            }
            return null;
        }

        // Parcours en largeur
        public void ParcourirEnLargeur(Arbre<T> resultat, List<T> noeudParcourues, T noeudDepart)
        {
            List<Predecesseur<T>> successeurs = GetSuccesseur(noeudDepart);
            List<Arbre<T>> arbres = new List<Arbre<T>>();
            List<Predecesseur<T>> parcoursSuivants = new List<Predecesseur<T>>();

            // Départ 
            if(noeudParcourues.Count == 0)
            {
                noeudParcourues.Add(noeudDepart);
                resultat.AjouterPere(noeudDepart);
            }

            // Ajouter chaque successeur s'il ne sont pas encore visité
            foreach (var successeur in successeurs)
            {
                if(!noeudParcourues.Exists(x => x.Equals(successeur)))
                {
                    // Création d'un nouveau noeud
                    Arbre<T> arbre = new Arbre<T>();
                    arbre.AjouterPere(successeur.Noeud);

                    // Ajout du noeud en tant que fils
                    resultat.AjouterFils(arbre);
                    arbres.Add(arbre);
                    
                    // Ajout dans noeud parcourues + à parcourir
                    noeudParcourues.Add(successeur.Noeud);
                    parcoursSuivants.Add(successeur);
                }
            }

            for(int i = 0; i < parcoursSuivants.Count; i++)
            {
                ParcourirEnLargeur(arbres[i], noeudParcourues, parcoursSuivants[i].Noeud);
            }
        }

        // Parcours en largeur
        public Arbre<T> ParcourirEnLargeur(T noeudDepart)
        {
            Arbre<T> resultat = new Arbre<T>();
            List<T> noeudParcourues = new List<T>();
            ParcourirEnLargeur(resultat, noeudParcourues, noeudDepart);
            return resultat;
        }

        // Parcours en largeur
        public Arbre<T> ParcourirEnLargeur()
        {
            List<T> noeuds = GetSansPredecesseur();
            if (noeuds.Count != 0)
            {
                return ParcourirEnLargeur(noeuds[0]);
            }
            return null;
        }

        // Algorithme de Dijkstra
        public void GetChemin(Arbre<T> resultat, List<Noeud<T>> choisies, List<Noeud<T>> nonChoisies, T depart, double cout, int sens = 0)
        {
            // Initialisation
            if (choisies.Count == 0)
            {
                resultat.AjouterPere(depart);
                choisies.Add(new Noeud<T>()
                {
                    Depart = depart,
                    Arrive = depart,
                    Cout = 0
                });
            }

            // Avoir tout les successeurs
            List<Predecesseur<T>> successeurs = GetSuccesseur(depart);

            // Pour chaque successeur
            foreach (var successeur in successeurs)
            {
                if (!choisies.Exists(x => x.Arrive.Equals(successeur.Noeud)))
                {
                    nonChoisies.Add(new Noeud<T>()
                    {
                        Depart = depart,
                        Arrive = successeur.Noeud,
                        Cout = cout + GetCout(depart, successeur.Noeud)
                    });
                }
            }

            Noeud<T> noeud = sens == 0 ? Noeud<T>.GetPlusPetitCout(nonChoisies) : Noeud<T>.GetPlusGrandCout(nonChoisies);

            if (noeud != null)
            {
                choisies.Add(noeud);
                nonChoisies.Remove(noeud);
                nonChoisies.RemoveAll(x => x.Arrive.Equals(noeud.Arrive));

                Arbre<T> fils = new Arbre<T>();
                fils.AjouterPere(noeud.Arrive);
                resultat.AjouterFils(fils);

                // Continue
                GetChemin(fils, choisies, nonChoisies, noeud.Arrive, noeud.Cout, sens);
            }
        }

        // Algorthme de Dijkstra / Plus court chemin
        public void GetPlusCourtChemin(Arbre<T> resultat,List<Noeud<T>> choisies, List<Noeud<T>> nonChoisies, T depart,double cout)
        {
            GetChemin(resultat, choisies, nonChoisies, depart, 0, 0);
        } 

        // Algorithme de Dijkstra / Plus court chemin
        public Arbre<T> GetPlusCourtChemin(T depart)
        {
            Arbre<T> resultat = new Arbre<T>();
            List<Noeud<T>> choisies = new List<Noeud<T>>();
            List<Noeud<T>> nonChoisies = new List<Noeud<T>>();

            GetPlusCourtChemin(resultat, choisies, nonChoisies, depart, 0);
            return resultat;
        }

        // Algorithme de Dijkstra / Plus court chemin
        public Arbre<T> GetPlusCourtChemin()
        {
            List<T> sansPredecesseurs = GetSansPredecesseur();
            if (sansPredecesseurs.Count == 0) return null;
            return GetPlusCourtChemin(sansPredecesseurs[0]);
        }

        // Algorithme de Dijkstra / Plus court chemin
        public Arbre<T> GetPlusCourtChemin(T depart, T arrive)
        {
            Arbre<T> arbre = GetPlusCourtChemin(depart);
        }

        // Algorthme de Dijkstra / Plus long chemin
        public void GetPlusLongChemin(Arbre<T> resultat, List<Noeud<T>> choisies, List<Noeud<T>> nonChoisies, T depart, double cout)
        {
            GetChemin(resultat, choisies, nonChoisies, depart, 0, 1);
        }

        // Algorithme de Dijkstra / Plus long chemin
        public Arbre<T> GetPlusLongChemin(T depart)
        {
            Arbre<T> resultat = new Arbre<T>();
            List<Noeud<T>> choisies = new List<Noeud<T>>();
            List<Noeud<T>> nonChoisies = new List<Noeud<T>>();

            GetPlusLongChemin(resultat, choisies, nonChoisies, depart, 0);
            return resultat;
        }

        // Algorithme de Dijkstra / Plus long chemin
        public Arbre<T> GetPlusLongChemin()
        {
            List<T> sansPredecesseurs = GetSansPredecesseur();
            if (sansPredecesseurs.Count == 0) return null;
            return GetPlusLongChemin(sansPredecesseurs[0]);
        }
    }
}
