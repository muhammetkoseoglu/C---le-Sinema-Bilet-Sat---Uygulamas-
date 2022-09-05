using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaUygulaması
{
    internal class Sinema
    {
        public string FilmAdi { get; set; }
        public int Kapasite { get; set; }
        public float TamBiletFiyati { get; }
        public float YarimBiletFiyati { get; }
        public int ToplamTamBiletAdeti { get; private set; }
        public int ToplamYarimBiletAdeti { get; private set; }
        public float Ciro
        {
            get
            {
                float c = this.ToplamTamBiletAdeti * this.TamBiletFiyati + this.ToplamYarimBiletAdeti * this.YarimBiletFiyati;
                return c;
            }
        }


        public Sinema(string filmAdi, int kapasite, float tamBiletfiyati, float yarimBiletFiyati)
        {
            this.FilmAdi = filmAdi;
            this.Kapasite = kapasite;
            this.TamBiletFiyati = tamBiletfiyati;
            this.YarimBiletFiyati = yarimBiletFiyati;
        }

        public void BiletSatis(int tamBiletAdeti, int yarimBiletAdeti)
        {
            if (tamBiletAdeti + yarimBiletAdeti <= BosKoltukAdetiGetir())
            {
                this.ToplamTamBiletAdeti += tamBiletAdeti;
                this.ToplamYarimBiletAdeti += yarimBiletAdeti;
                //CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine(BosKoltukAdetiGetir() + " adet boş koltuk olduğu için işlem gerçekleşmedi.");
            }

        }

        public void BiletIadesi(int tamBiletAdeti, int yarimBiletAdeti)
        {
            if (tamBiletAdeti <= this.ToplamTamBiletAdeti && yarimBiletAdeti <= this.ToplamYarimBiletAdeti)
            {
                this.ToplamTamBiletAdeti -= tamBiletAdeti;
                this.ToplamYarimBiletAdeti -= yarimBiletAdeti;
                //CiroHesapla();
                Console.WriteLine("İşlem gerçekleştirildi.");
            }
            else
            {
                Console.WriteLine("Satılmış olan bilet adedinden fazla iade yapılamaz.");
            }

        }

        private void CiroHesapla()
        {
            //this.Ciro = this.ToplamTamBiletAdeti * this.TamBiletFiyati + this.ToplamYarimBiletAdeti * this.YarimBiletFiyati;
        }

        public int BosKoltukAdetiGetir()
        {
            return this.Kapasite - this.ToplamYarimBiletAdeti - this.ToplamTamBiletAdeti;
        }

    }
}
