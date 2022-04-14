using System;
using System.Collections.Generic;
using System.Text;

namespace QCash
{
    class SomeUsefulCodeTemplates
    {


        public System.Random objRandom = new System.Random(Convert.ToInt32(System.DateTime.Now.Ticks % System.Int32.MaxValue));
        public int GenerateRandomNumber(int min, int max)
        {
            return objRandom.Next(min, max);
        }

    }
}
