using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using HtmlAgilityPack;
using RestSharp;

namespace TrackListsToBeatPortClass
{
    public class Class1
    {
        
        public string[] GetXpath(string url)
        {
            List<string> LS = new List<string>();
            HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load (url);

            foreach (HtmlNode row in doc.DocumentNode.SelectNodes("//*[@itemprop=\"tracks\"]")) 
            {
                LS.Add(row.InnerText);     
            }

            return LS.ToArray();
        }

        public string ReturnHTMLOfListsOfTracks(Track[] Tracks, string tracklistingName)
        {
            var exportcollectionExists = System.IO.File.Exists("collectionexport.xml");
            DJ_PLAYLISTS djPlaylist = null;
            if (exportcollectionExists == true)
            {
                var collectionExport = System.IO.File.ReadAllText("collectionexport.xml").Replace("\r\n", String.Empty);


                XmlSerializer serializer = new XmlSerializer(typeof(DJ_PLAYLISTS));


                using (StringReader reader = new StringReader(collectionExport))
                {
                    djPlaylist = (DJ_PLAYLISTS) serializer.Deserialize(reader);
                }
            }
            

            string top ="<!DOCTYPE html><html><body><h2>" +tracklistingName +"</h2>";
            string bottom = "</body></html>";
            List<string> LS = new List<string>();


            string html = top;
            html = html + "<ul>";
            string link = "";
            
            foreach (var track in Tracks)
            {
                
                var cleantrack = new Strip().StripHTML(track.Artist).Trim() + " - " + new Strip().StripHTML(track.TrackName).Trim();
                var cleantrackForSearch = new Strip().StripHTML(cleantrack).Trim().Replace("&", "%26").Replace(" ", "+");
                var linkinner = "";
                if (exportcollectionExists ==true)
                {
                    var trackexists = new SearchExistingTrackInRecordBox().Search(djPlaylist, track.TrackName);
                    if (trackexists.Found == true)
                    {
                        linkinner = "<li><a href=\"https://www.beatport.com/search?q="  +cleantrackForSearch + "\"" + ">" + cleantrack + "</a><p>Exists in RecordBox "+ new TracksToHTMLTable().HTMLTable(trackexists.Tracks) + "</P></li>" + System.Environment.NewLine;
                    }
                    else
                    {
                        linkinner = "<li><a href=\"https://www.beatport.com/search?q="  +cleantrackForSearch + "\"" + ">" + cleantrack + "</a></li>" + System.Environment.NewLine;
                    }
                }

                else
                {
                    linkinner = "<li><a href=\"https://www.beatport.com/search?q="  +cleantrackForSearch + "\"" + ">" + cleantrack + "</a></li>" + System.Environment.NewLine;
                }
                
                
                
                link = link + linkinner;
                
                
                
            }

            html = html + link;
            
            html = html + "</ul>";

            html = html + bottom;

            return html;

            

        }

        public Track[] ReturnHTracksOfListsOfTracks(string[] tracks)
        {
            List<Track> TrackList = new List<Track>();

            foreach (var track in tracks)
            {
                var trimtrack = track.Trim();
                var ArtistAndTrack = trimtrack.Split("  ").First();
                var recordlable = trimtrack.Split("  ").Last();
                var artist = ArtistAndTrack.Split(" - ").First();
                var trackname = ArtistAndTrack.Split(" - ").Last();
                
                TrackList.Add(new Track()
                {
                    Artist = artist, RecordLabel = recordlable, TrackName = trackname
                });
                
            }

            return TrackList.ToArray();
        }
        
        
        
        
        
        
        
        
    }
}