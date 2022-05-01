using System.Runtime.InteropServices;

namespace TrackListsToBeatPortClass
{
    public class TracksToHTMLTable
    {
        public string HTMLTable(TRACK[] Tracks)
        {
            var Top = "<!DOCTYPE html>\n<html>\n<head>\n<style>\ntable {\n  font-family: arial, sans-serif;\n  border-collapse: collapse;\n  width: 100%;\n}\n\ntd, th {\n  border: 1px solid #dddddd;\n  text-align: left;\n  padding: 8px;\n}\n\ntr:nth-child(even) {\n  background-color: #dddddd;\n}\n</style>\n</head>\n<body>\n\n<h2>Tracks Already Exists in RecordBox</h2>\n\n<table>\n  <tr>\n    <th>Artist</th>\n    <th>Name</th>\n    <th>Location</th>\n <th>BPM</th>\n <th>Key</th>\n  </tr>";
            var Middle = "";
            foreach (var track in Tracks)
            {
                Middle = Middle + "<tr><td>" + track.Artist + "</td><td>" + track.Name + "</td><td><a href=\"" + track.Location +"\"" + ">" + track.Name + "</a>" + "</td><td>" + track.AverageBpm +  "</td><td>" + track.Tonality + "</td><td>" +  "</tr>";
            }

            var Bottom = "</table>\n\n</body>\n</html>\n\n";

            return Top + Middle + Bottom;
        }
        
    }
}