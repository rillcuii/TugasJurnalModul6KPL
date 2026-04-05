using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CODE_JURNAL_MODUL6
{
    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        public string Username { get; set; }

        public SayaTubeUser(string username)
        {
            // Precondition: Username max 100 karakter dan tidak null 
            Debug.Assert(username != null && username.Length <= 100, "Username tidak valid.");

            this.Username = username;
            this.uploadedVideos = new List<SayaTubeVideo>(); // [cite: 162]

            Random random = new Random();
            this.id = random.Next(10000, 99999);
        }

        public void AddVideo(SayaTubeVideo video)
        {
            // Precondition: Video tidak null dan playCount di bawah max int 
            Debug.Assert(video != null, "Video yang ditambahkan tidak boleh null.");
            Debug.Assert(video.GetPlayCount() < int.MaxValue, "Video sudah mencapai batas maksimal playCount.");

            uploadedVideos.Add(video);
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (var video in uploadedVideos)
            {
                total += video.GetPlayCount();
            }
            return total;
        }

        public void PrintAllVideoPlaycount()
        {
            Console.WriteLine("User: " + Username);

            // Postcondition: Maksimal 8 video yang di-print 
            int limit = Math.Min(uploadedVideos.Count, 8);

            for (int i = 0; i < limit; i++)
            {
                Console.WriteLine("Video " + (i + 1) + " judul: " + uploadedVideos[i].GetTitle());
            }
        }
    }
}