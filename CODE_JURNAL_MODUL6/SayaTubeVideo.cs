using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CODE_JURNAL_MODUL6
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
           // Precondition: Judul max 200 karakter dan tidak null 
            Debug.Assert(title != null && title.Length <= 200, "Judul video tidak valid (max 200 karakter).");

            this.title = title;
            this.playCount = 0; // [cite: 159]

            // Generate ID random 5 digit [cite: 159]
            Random random = new Random();
            this.id = random.Next(10000, 99999);
        }

        public void IncreasePlayCount(int count)
        {
            // Precondition: Input max 25.000.000 dan tidak negatif
            Debug.Assert(count >= 0 && count <= 25000000, "Input penambahan tidak valid (0 - 25.000.000).");

            // Exception: Handle overflow dengan 'checked' 
            try
            {
                checked
                {
                    this.playCount += count;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Peringatan: PlayCount video '" + title + "' mencapai batas maksimum (Overflow)!");
            }
        }

        public int GetPlayCount() => this.playCount;
        public string GetTitle() => this.title;

        public void PrintVideoDetails()
        {
            Console.WriteLine("ID: " + id + " | Judul: " + title + " | Plays: " + playCount);
        }
    }
}
