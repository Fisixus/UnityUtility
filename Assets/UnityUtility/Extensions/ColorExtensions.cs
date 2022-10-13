using UnityEngine;

namespace UnityUtility.Extensions
{
    public static class ColorExtensions 
    {
        
        public static Color WithR(this Color c, float r)
        {
            c.r = r;
            return c;
        }

        public static Color WithG(this Color c, float g)
        {
            c.g = g;
            return c;
        }

        public static Color WithB(this Color c, float b)
        {
            c.b = b;
            return c;
        }
        
        public static Color WithA(this Color color, float a)
        {
            color.a = a;
            return color;
        }
    
    }
}
