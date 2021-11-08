using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    internal class IClass
    {
        public int Num;
    }

    public class PClass
    {
        public int PNum;

        internal int INum;

        //public IClass PIClass = new IClass();
    }
}
