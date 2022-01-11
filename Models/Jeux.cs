using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Jeux
    {


        public void Combat<T,U> (T premier , U adversaire, int degat )
            where U: IPerso<T>
        {
            adversaire.Encaisse( degat);
        }
    }
}
