using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
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

        public string ReturnHTMLOfListsOfTracks(string[] Tracks, string tracklistingName)
        {
            string top ="<!DOCTYPE html><html><body><h2>" +tracklistingName +"</h2>";
            string bottom = "</body></html>";
            List<string> LS = new List<string>();


            string html = top;
            html = html + "<ul>";
            string link = "";
            
            foreach (var track in Tracks)
            {
                var cleantrack = StripHTML(track).Trim();
                var cleantrackForSearch = StripHTML(track).Trim().Replace("&", "%26").Replace(" ", "+");
                string linkinner = "<li><a href=\"https://www.beatport.com/search?q="  +cleantrackForSearch + "\"" + ">" + cleantrack + "</a></li>" + System.Environment.NewLine;
                link = link + linkinner;
                LS.Add(track);
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
        
        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
        
        public class Track
        {
            public string TrackName { get; set; }
            public string Artist { get; set; }
            public string RecordLabel { get; set; }
            
        }
        
        
    }
}