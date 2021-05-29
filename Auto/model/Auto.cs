using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autokauppa.model
{
    public class Auto
    {
        public int id
        {
            get;
            set;
        }
        public decimal hinta
        {
            get;
            set;
        }
        public DateTime rekisteri_paivamaara
        {
            get;
            set;
        }
        public decimal moottorin_tilavuus
        {
            get;
            set;
        }
        public int mittarilukema
        {
            get;
            set;
        }
        public int autonmerkkiID
        {
            get;
            set;
        }
        public int autonmalli_ID
        {
            get;
            set;
        }
        public int varitID
        {
            get;
            set;
        }
        public int polttoaineID
        {
            get;
            set;
        }
    }
}
