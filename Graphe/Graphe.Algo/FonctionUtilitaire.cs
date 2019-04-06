

using System;

namespace Graphe
{
    public class FonctionUtilitaire
    {
        public static string GenererCouleur()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }
    }
}
