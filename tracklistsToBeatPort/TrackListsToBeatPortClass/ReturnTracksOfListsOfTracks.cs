using System.Collections.Generic;
using System.Linq;

namespace TrackListsToBeatPortClass
{
    public class Functions
    {
        public Track[] ReturnTracksOfListsOfTracks(string[] tracks)
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