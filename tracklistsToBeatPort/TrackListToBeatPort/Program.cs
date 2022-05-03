using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using TrackListsToBeatPortClass;

namespace TrackListToBeatPort
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Console.WriteLine("To Search your recordBox, then put that Collection Export in to this folder");
            Console.WriteLine(System.Environment.CurrentDirectory);
            
            Console.WriteLine("-----");
            Console.WriteLine("Paste in your 1001TrackLists url");
            var url = Console.ReadLine();
             //   "https://www.1001tracklists.com/tracklist/mwzxpm9/charlie-hedges-shermanology-bbc-radio-1-dance-anthems-2022-04-23.html";
            var tracks = new TrackListsToBeatPortClass.Class1().GetXpath(url);
            var trackAsDatatype = new TrackListsToBeatPortClass.Class1().ReturnHTracksOfListsOfTracks(tracks);
            var html = new TrackListsToBeatPortClass.Class1().ReturnHTMLOfListsOfTracks(trackAsDatatype, url);
            var filename = Guid.NewGuid() + ".html";
            System.IO.File.WriteAllText(filename, html);
            

           
            try
            {
                Process.Start(filename);
            }
            catch (Exception e)
            {
                Console.WriteLine("open this file " + System.Environment.CurrentDirectory  + Path.DirectorySeparatorChar + filename );
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Console.WriteLine("open this file file://" + System.Environment.CurrentDirectory  + Path.DirectorySeparatorChar + filename );
                }
            }
        }
    }
}