using System;
using System.Collections.Generic;
using System.Text;

namespace RollerCoaster2019.Logic
{
    public class MathHelper : IMathHelper
    {
        public float ToRadians(float degrees)
        {
            return (float)(Math.PI * degrees / 180.0);
        }

        public float ToDegree(float radian)
        {
            return (float)(radian * (180.0 / Math.PI));
        }

        public float PiOver4()
        {
            return (float)(Math.PI / 4);
        }
    }
}
