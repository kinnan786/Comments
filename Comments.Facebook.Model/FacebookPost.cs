using System;

namespace Comments.Facebook.Model
{
    public class FacebookPost
    {
        public string id { get; set; }
        public string caption { get; set; }
        public DateTime created_time { get; set; }
        public string description { get; set; }
        public From from { get; set; }
        public string icon { get; set; }
        public string instagram_eligibility { get; set; }
        public bool is_hidden { get; set; }
        public bool is_instagram_eligible { get; set; }
        public bool is_published { get; set; }
        public string link { get; set; }
        public string message { get; set; }
        public Message_Tags message_tags { get; set; }
        public string name { get; set; }
        public string object_id { get; set; }
        public string parent_id { get; set; }
        public string permalink_url { get; set; }
        public string picture { get; set; }
        public Place place { get; set; }
        public Privacy privacy { get; set; }
        public Properties properties { get; set; }
        public Shares shares { get; set; }
        public string status_type { get; set; }
        public string story { get; set; }
        public string type { get; set; }
        public DateTime updated_time { get; set; }
        public AdminCreator admin_creator { get; set; }
        public Application application { get; set; }
    }


    public class Place
    {
        public string id { get; set; }
        public Location location { get; set; }
        public string name { get; set; }
        public float overall_rating { get; set; }
    }

    public class Location
    {
        public string city { get; set; }
        public string city_id { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string latitude { get; set; }
        public string located_in { get; set; }
        public string longitude { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string region_id { get; set; }
        public string state { get; set; }
        public string street { get; set; }
        public string zip { get; set; }
    }

    public class AdminCreator
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Properties
    {
        public string name { get; set; }
        public string text { get; set; }
        public string href { get; set; }
    }

    public class Privacy
    {
        public string description { get; set; }
        public string value { get; set; }
        public string friends { get; set; }
        public string allow { get; set; }
        public string deny { get; set; }
    }

    public class Shares
    {
        public int count { get; set; }
    }
}