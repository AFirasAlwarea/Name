using System.Collections.Generic;
using NameAPI.Models;
using System.Net;
using System;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace NameAPI
{

    public class NameService
    {
        // breaking the url to be able to modify the returned json data
        private static string urlGender = "http://api.namnapi.se/v2/names.json?gender=";
        private static string urlType = "&type=";
        private static string urlLimit = "&limit=";

        // creating instance of objectsto be used in all methods
        private static string json_data = string.Empty;
        private static List<NameModel> jsonResult = new List<NameModel>();

        public static List<NameModel> GetNameList(int limit)
        {
            // downloading JSON-data as a string
            string url = urlGender + "both" + urlType + "both" + urlLimit + limit;
            json_data = GetJsonData(url);
            // trying to convert string of Json-data to list of NameModel
            jsonResult = GetNames(json_data);



            return jsonResult;
        }


        public static List<NameModel> GetNameList(NameType type, int limit)
        {
            // TODO: Your code here
            string url = urlGender + "both" + urlType + type + urlLimit + limit;

            // attempt to download JSON data as a string
            json_data = GetJsonData(url);

            jsonResult = GetNames(json_data);
            return jsonResult;
        }

        public static List<NameModel> GetNameList(NameGender gender, int limit)
        {
            // TODO: Your code here
            string url = urlGender + gender + urlType + "both" + urlLimit + limit;

            // attempt to download JSON data as a string
            json_data = GetJsonData(url);

            jsonResult = GetNames(json_data);
            return jsonResult;
        }

        public static List<NameModel> GetNameList(NameType type, NameGender gender, int limit)
        {
            // TODO: Your code here
            string gender1 = gender.ToString().ToLower();
            string type1 = type.ToString().ToLower();
            string url = urlGender + gender1 + urlType + type1 + urlLimit + limit;

            // attempt to download JSON data as a string
            json_data = GetJsonData(url);

            jsonResult = GetNames(json_data);

            return jsonResult;
        }

        // method to get json-data from given url to a string
        private static string GetJsonData(string url)
        {
            WebClient w = new WebClient();
            string jsonString;
            try
            {
                jsonString = w.DownloadString(url);
            }
            catch (Exception)
            {
                jsonString = "Json Data not found";
            }
            Console.WriteLine(jsonString);
            return jsonString;
        }

        // method to convert string of json-data to List of NameModel 
        private static List<NameModel> GetNames(string json_data)
        {
            //JavaScriptSerializer serializer = new JavaScriptSerializer();
            jsonResult.Clear();
            try
            {
                //jsonResult = (List<NameModel>)serializer.Deserialize<List<NameModel>>(json_data);
                //var result = JsonConvert.DeserializeObject<ListOfNames>(json_data);
                //List<NameModel> jsonResult = result.name.ToList();
                var list = JObject.Parse(json_data)["names"];
                foreach (var item in list)
                {
                    NameModel oneItem = new NameModel();
                    oneItem.FirstName = (string)item["firstname"];
                    oneItem.LastName = (string)item["surname"];
                    switch ((string)item["gender"])
                    {
                        case "male":
                            oneItem.Gender = NameGender.Male;
                            break;
                        case "female":
                            oneItem.Gender = NameGender.Female;
                            break;
                        default:
                            oneItem.Gender = NameGender.Both;
                            break;
                    }
                    jsonResult.Add(oneItem);
                    
                }
            }
            catch (Exception)
            {
                jsonResult = new List<NameModel>();
            }

            //if (!string.IsNullOrEmpty(json_data))
            return jsonResult;
        }
    }
}
