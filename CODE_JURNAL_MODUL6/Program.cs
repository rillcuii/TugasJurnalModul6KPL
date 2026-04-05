using CODE_JURNAL_MODUL6;
using System;

namespace modul6_NIM
{
    class Program
    {
        static void Main(string[] args)
        {
            string namaPraktikan = "NamaKamu"; // Ganti dengan nama aslimu 
            SayaTubeUser user = new SayaTubeUser(namaPraktikan);

            // Menambahkan minimal 10 judul film 
            string[] daftarFilm = { "Interstellar", "Inception", "The Dark Knight", "The Prestige", "Memento",
                                   "Oppenheimer", "Dunkirk", "Tenet", "The Batman", "Joker" };

            foreach (var judul in daftarFilm)
            {
                SayaTubeVideo v = new SayaTubeVideo("Review Film " + judul + " oleh " + namaPraktikan);

                // Uji normal penambahan playCount
                v.IncreasePlayCount(1000);
                user.AddVideo(v);
            }

            // Uji Exception Overflow (Menggunakan loop untuk mempercepat proses) 
            Console.WriteLine("--- Menjalankan Tes Overflow ---");
            for (int i = 0; i < 100; i++)
            {
                user.AddVideo(new SayaTubeVideo("Video Dummy " + i)); // Mengisi list lebih dari 8 untuk tes postcondition
            }

            // Tes penambahan besar untuk overflow pada satu video
            SayaTubeVideo vOverflow = new SayaTubeVideo("Video Tes Overflow");
            for (int i = 0; i < 100; i++) vOverflow.IncreasePlayCount(25000000);

            // Menampilkan hasil
            Console.WriteLine("\n--- Hasil Akhir ---");
            user.PrintAllVideoPlaycount(); // Akan terpotong di 8 video karena Postcondition 
            Console.WriteLine("Total Play Count Semua Video: " + user.GetTotalVideoPlayCount());
        }
    }
}