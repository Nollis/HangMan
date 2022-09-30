using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    internal class CustomExceptions : Exception
    {
        [Serializable]
        public class NonCharacterException : Exception
        {
            public NonCharacterException()
                : base("Du kan bara ange bokstäver!")
            {

            }
        }
    }
}
