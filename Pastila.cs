using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnII_1058_Stancu_Gheorghe_Mirel
{
    [Serializable]
    public class Pastila
    {
        public int gramaj;
        public string denumire;
        public string producator;
        public string modEliberare;

        public Pastila()
        {
            gramaj = 0;
            denumire = "NA";
            producator = "NA";
            modEliberare = "NA";
        }

        public Pastila(int gramaj, string denumire, string producator, string modEliberare)
        {
            this.gramaj = gramaj;
            this.denumire = denumire;
            this.producator = producator;
            this.modEliberare = modEliberare;
        }

        //getteri

        public int getGramaj()
        {
            return this.gramaj;
        }

        public string getDenumire()
        {
            return this.denumire;
        }

        public string getProducator()
        {
            return this.producator;
        }

        public string getModEliberare()
        {
            return this.modEliberare;
        }

        //Setteri

        public void setGramaj(int gramaj)
        {
            this.gramaj = gramaj;
        }
        public void setDenumire(string denumire)
        {
            this.denumire = denumire;
        }
        public void setProducator(string producator)
        {
            this.producator = producator;
        }
        public void setModEliberare(string mod)
        {
            this.modEliberare = mod;
        }
    }
}
