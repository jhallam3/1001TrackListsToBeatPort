using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TrackListsToBeatPortClass
{
    [XmlRoot(ElementName="COLLECTION")]
	public class COLLECTION {
		[XmlAttribute(AttributeName="Entries")]
		public string Entries { get; set; }
		[XmlElement(ElementName="TRACK")]
		public List<TRACK> TRACK { get; set; }
	}

	[XmlRoot(ElementName="DJ_PLAYLISTS")]
	public class DJ_PLAYLISTS {
		[XmlElement(ElementName="COLLECTION")]
		public COLLECTION COLLECTION { get; set; }
		[XmlElement(ElementName="PLAYLISTS")]
		public PLAYLISTS PLAYLISTS { get; set; }
		[XmlElement(ElementName="PRODUCT")]
		public PRODUCT PRODUCT { get; set; }
		[XmlAttribute(AttributeName="Version")]
		public string Version { get; set; }
	}

	[XmlRoot(ElementName="NODE")]
	public class NODE {
		[XmlAttribute(AttributeName="Entries")]
		public string Entries { get; set; }
		[XmlAttribute(AttributeName="KeyType")]
		public string KeyType { get; set; }
		[XmlAttribute(AttributeName="Name")]
		public string Name { get; set; }
		[XmlElement(ElementName="TRACK")]
		public TRACK TRACK { get; set; }
		[XmlAttribute(AttributeName="Type")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="PLAYLISTS")]
	public class PLAYLISTS {
		[XmlElement(ElementName="NODE")]
		public NODE NODE { get; set; }
	}

	[XmlRoot(ElementName="PRODUCT")]
	public class PRODUCT {
		[XmlAttribute(AttributeName="Company")]
		public string Company { get; set; }
		[XmlAttribute(AttributeName="Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="Version")]
		public string Version { get; set; }
	}

	[XmlRoot(ElementName="TEMPO")]
	public class TEMPO {
		[XmlAttribute(AttributeName="Battito")]
		public string Battito { get; set; }
		[XmlAttribute(AttributeName="Bpm")]
		public string Bpm { get; set; }
		[XmlAttribute(AttributeName="Inizio")]
		public string Inizio { get; set; }
		[XmlAttribute(AttributeName="Metro")]
		public string Metro { get; set; }
	}

	[XmlRoot(ElementName="TRACK")]
	public class TRACK {
		[XmlAttribute(AttributeName="Album")]
		public string Album { get; set; }
		[XmlAttribute(AttributeName="Artist")]
		public string Artist { get; set; }
		[XmlAttribute(AttributeName="AverageBpm")]
		public string AverageBpm { get; set; }
		[XmlAttribute(AttributeName="BitRate")]
		public string BitRate { get; set; }
		[XmlAttribute(AttributeName="Comments")]
		public string Comments { get; set; }
		[XmlAttribute(AttributeName="Composer")]
		public string Composer { get; set; }
		[XmlAttribute(AttributeName="DateAdded")]
		public string DateAdded { get; set; }
		[XmlAttribute(AttributeName="DiscNumber")]
		public string DiscNumber { get; set; }
		[XmlAttribute(AttributeName="Genre")]
		public string Genre { get; set; }
		[XmlAttribute(AttributeName="Grouping")]
		public string Grouping { get; set; }
		[XmlAttribute(AttributeName="Key")]
		public string Key { get; set; }
		[XmlAttribute(AttributeName="Kind")]
		public string Kind { get; set; }
		[XmlAttribute(AttributeName="Label")]
		public string Label { get; set; }
		[XmlAttribute(AttributeName="Location")]
		public string Location { get; set; }
		[XmlAttribute(AttributeName="Mix")]
		public string Mix { get; set; }
		[XmlAttribute(AttributeName="Name")]
		public string Name { get; set; }
		[XmlAttribute(AttributeName="PlayCount")]
		public string PlayCount { get; set; }
		[XmlAttribute(AttributeName="Rating")]
		public string Rating { get; set; }
		[XmlAttribute(AttributeName="Remixer")]
		public string Remixer { get; set; }
		[XmlAttribute(AttributeName="SampleRate")]
		public string SampleRate { get; set; }
		[XmlAttribute(AttributeName="Size")]
		public string Size { get; set; }
		[XmlElement(ElementName="TEMPO")]
		public List<TEMPO> TEMPO { get; set; }
		[XmlAttribute(AttributeName="Tonality")]
		public string Tonality { get; set; }
		[XmlAttribute(AttributeName="TotalTime")]
		public string TotalTime { get; set; }
		[XmlAttribute(AttributeName="TrackID")]
		public string TrackID { get; set; }
		[XmlAttribute(AttributeName="TrackNumber")]
		public string TrackNumber { get; set; }
		[XmlAttribute(AttributeName="Year")]
		public string Year { get; set; }
	}

}