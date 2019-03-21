
namespace Graphe.Test
{
    class MathHelper
    {
        public static long Factorielle(int a)
        {
            if (a <= 1)
                return 1;
            return a * Factorielle(a - 1);
        }
    }
}
