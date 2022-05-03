using System.ComponentModel.Design;
using System.Data.SqlTypes;
using System.Linq;

namespace TrackListsToBeatPortClass
{
    public class SearchExistingTrackInRecordBox
    {
        public FoundTracks Search(DJ_PLAYLISTS Playlist, string title)
        {
            if (title.Contains("("))
            {
                title = title.Split("(").First().Trim();
            }
            var list =Playlist.COLLECTION.TRACK.Where(x => x.Name.Contains(title)).ToArray();
            if (list.Length > 0)
            {
                return new FoundTracks()
                {
                    Found = true, Tracks = list
                };
            }
            else
            {
                return new FoundTracks()
                {
                    Found = false, Tracks = null
                };
            }
            
        }
    }
}