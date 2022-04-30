using System;
using System.Diagnostics;
using System.IO;

namespace TrackListToBeatPort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Paste in your 1001TrackLists url");
            var url = Console.ReadLine();
             //   "https://www.1001tracklists.com/tracklist/mwzxpm9/charlie-hedges-shermanology-bbc-radio-1-dance-anthems-2022-04-23.html";
            var tracks = new TrackListsToBeatPortClass.Class1().GetXpath(url);
            var html = new TrackListsToBeatPortClass.Class1().ReturnHTMLOfListsOfTracks(tracks, url);
            var filename = Guid.NewGuid() + ".html";
            System.IO.File.WriteAllText(filename, html);

            //get track object 

            //var trackAsDatatype = new TrackListsToBeatPortClass.Class1().ReturnHTracksOfListsOfTracks(tracks);
            
            // end get track object
            try
            {
                Process.Start(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("open this file " + System.Environment.CurrentDirectory  + Path.DirectorySeparatorChar + filename );
            }
        }
    }
}