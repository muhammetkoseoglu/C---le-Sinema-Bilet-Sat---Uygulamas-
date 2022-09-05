using System;

namespace SinemaUygulaması
{
    internal class Program
    {
        static Sinema Snm;
        static void Main(string[] args)
        {
            Uygulama();
            //Test();

        }

        static int Test2()
        {
            Console.Write("sayı gir: ");
            int giris = int.Parse(Console.ReadLine());
            return 5;

            
        }

        static void Test()
        {
            while (true)
            {
                Console.Write("sayı gir: ");
                string giris = Console.ReadLine();

                int a;

                bool sonuc = int.TryParse(giris, out a);

                if (sonuc == true)
                {
                    Console.WriteLine(a);
                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı");
                }

            }
        }

        static int SayiAl(string mesaj)
        {
            int sayi;

            while (true)
            {
                Console.Write(mesaj);
                string giris = Console.ReadLine();

                if (  int.TryParse(giris, out sayi)  )
                {
                    return sayi;

                }
                Console.WriteLine("Hatalı giriş yapıldı.");

            }

        }



        static void Uygulama()
        {

            Giris();
            Menu();

            while (true)
            {
                string secim = SecimAl();
                switch (secim)
                {
                    case "1":
                    case "S":
                        BiletSat();
                        break;
                    case "2":
                    case "R":
                        BiletIade();
                        break;
                    case "3":
                    case "D":
                        DurumBilgisi();
                        break;
                    case "4":
                    case "X":
                        Environment.Exit(0);
                        break;

                }

            }

        }
        static void BiletSat()
        {
            Console.WriteLine("Bilet Sat:");
            //Console.Write("Tam Bilet Adeti: ");
            //int tam = int.Parse(Console.ReadLine());

            int tam = SayiAl("Tam Bilet Adeti: ");

            //Console.Write("Yarim Bilet Adeti: ");
            //int yarim = int.Parse(Console.ReadLine());

            int yarim = SayiAl("Yarim Bilet Adeti: ");

            Snm.BiletSatis(tam, yarim);
        }

        static void BiletIade()
        {
            Console.WriteLine("Bilet İade:");
            //Console.Write("Tam Bilet Adeti: ");
            //int tam = int.Parse(Console.ReadLine());

            int tam = SayiAl("Tam Bilet Adeti: ");

            //Console.Write("Yarim Bilet Adeti: ");
            //int yarim = int.Parse(Console.ReadLine());

            int yarim = SayiAl("Yarim Bilet Adeti: ");

            Snm.BiletIadesi(tam, yarim);
        }

        static void DurumBilgisi()
        {

            Console.WriteLine();
            Console.WriteLine("Durum Bilgisi");
            Console.WriteLine("Film: " + Snm.FilmAdi);
            Console.WriteLine("Kapasite: " + Snm.Kapasite);
            Console.WriteLine("Tam Bilet Fiyatı: " + Snm.TamBiletFiyati);
            Console.WriteLine("Yarım Bilet Fiyatı: " + Snm.YarimBiletFiyati);
            Console.WriteLine("Toplam Tam Bilet Adedi: " + Snm.ToplamTamBiletAdeti);
            Console.WriteLine("Toplam Yarım Bilet Adedi: " + Snm.ToplamYarimBiletAdeti);
            Console.WriteLine("Ciro: " + Snm.Ciro);
            Console.WriteLine("Boş Koltuk Adedi: " + Snm.BosKoltukAdetiGetir());
            Console.WriteLine();

        }



        static string SecimAl()
        {
            Console.WriteLine();
            string karakterler = "1234SRDX";
            int sayac = 0;

            while (true)
            {
                sayac++;
                Console.Write("Seçiminiz: ");
                string giris = Console.ReadLine().ToUpper();
                int index = karakterler.IndexOf(giris);

                if (giris.Length == 1 && index >= 0)
                {
                    return giris;
                }
                else
                {

                    if (sayac == 10)
                    {
                        Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Hatalı giriş yapıldı.");
                }


                Console.WriteLine();

            }


        }

        static void Giris()
        {
            Console.WriteLine("-------Butik Sinema Salonu-------");
            Console.Write("Film adı: ");
            string film = Console.ReadLine();


            //Console.Write("Kapasite: ");
            //int kapasite = int.Parse(Console.ReadLine());

            int kapasite = SayiAl("Kapasite: ");

            Console.Write("Tam Bilet Fiyatı:  ");
            float tam = float.Parse(Console.ReadLine());

            Console.Write("Yarım Bilet Fiyatı: ");
            float yarim = float.Parse(Console.ReadLine());

            Snm = new Sinema(film, kapasite, tam, yarim);

        }

        static void Menu()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Bilet Sat(S)          ");
            Console.WriteLine("2 - Bilet İade(R)         ");
            Console.WriteLine("3 - Durum Bilgisi(D)      ");
            Console.WriteLine("4 - Çıkış(X)             ");
        }

    }
}
