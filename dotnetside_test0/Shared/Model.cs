using System;

namespace dotnetside.Shared
{
    public class EventResponse
    {
        public Event[] data { get; set; }
    }

    public class Event
    {
        public string description { get; set; }
        public DateTime end_time { get; set; }
        public string name { get; set; }
        public Place place { get; set; }
        public DateTime start_time { get; set; }
        public string id { get; set; }
    }

    public class Place
    {
        public string name { get; set; }
        public Location location { get; set; }
        public string id { get; set; }
    }

    public class Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string street { get; set; }
        public string zip { get; set; }
    }
}