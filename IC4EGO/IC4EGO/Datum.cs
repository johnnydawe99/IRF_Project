using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC4EGO
{
    public class Datum
    {
        public bool CheckDate(string datum)
        {
            try
            {
                DateTime dt = DateTime.Parse(datum);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DateTime DatumKonvert(string datum)
        {
            if (CheckDate(datum) == true)
            {
                DateTime siker;
                DateTime.TryParse(datum, out siker);
                return siker;
            }
            else
            {
                return new DateTime(0001, 01, 01);
            }
        }
    }
}
