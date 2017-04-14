using System.Collections.Generic;
using NameAPI.Models;
using System.Net;
using System;
using Newtonsoft.Json;

namespace NameAPI
{

    public class NameService
    {
        // breaking the url to be able to modify the returned json data
        private static string urlGender = "http://api.namnapi.se/v2/names.json?gender=";
        private static string urlType = "&type=";
        private static string urlLimit = "&limit=";

        private static WebClient w = new WebClient();
        private static string json_data = string.Empty;

        public static List<NameModel> GetNameList(int limit)
        {
            // TODO: Your code here
            string url = urlGender + "both" + urlType + "both" + urlLimit + limit;

            // attempt to download JSON data as a string
            json_data = GetJsonData(url);

            List<NameModel> jsonResult = !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<List<NameModel>>(json_data) : new List<NameModel>();

            return jsonResult;
        }


        public static List<NameModel> GetNameList(NameType type, int limit)
        {
            // TODO: Your code here
            string url = urlGender + "both" + urlType + type + urlLimit + limit;

            // attempt to download JSON data as a string
            json_data = GetJsonData(url);

            List<NameModel> jsonResult = !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<List<NameModel>>(json_data) : new List<NameModel>();

            return jsonResult;
        }

        public static List<NameModel> GetNameList(NameGender gender, int limit)
        {
            // TODO: Your code here
            string url = urlGender + gender + urlType + "both" + urlLimit + limit;

            // attempt to download JSON data as a string
            json_data = GetJsonData(url);

            List<NameModel> jsonResult = !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<List<NameModel>>(json_data) : new List<NameModel>();

            return jsonResult;
        }

        public static List<NameModel> GetNameList(NameType type, NameGender gender, int limit)
        {
            // TODO: Your code here
            string url = urlGender + gender + urlType + type + urlLimit + limit;

            // attempt to download JSON data as a string
            json_data = GetJsonData(url);

            List<NameModel> jsonResult = !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<List<NameModel>>(json_data) : new List<NameModel>();

            return jsonResult;
        }

        private static string GetJsonData(string url)
        {
            string jsonString;
            try
            {
                jsonString = w.DownloadString(url);
            }
            catch(Exception)
            {
                jsonString = "Json Data not found";
            }
            return jsonString;
        }

    }
}
