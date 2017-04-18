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

        // method to GetNameList with one parameter Limit
        public static List<NameModel> GetNameList(int limit)
        {
            // creating string to get JSON-data from NameAPI
            string url = urlGender + "both" + urlType + "both" + urlLimit + limit;

            // Calling method GetJsonData and passing the required url as well
            json_data = GetJsonData(url);

            // convert string of Json-data to list of NameModel
            jsonResult = GetNames(json_data);

            return jsonResult;
        }

        // method to GetNameList with two parameters Limit & type
        public static List<NameModel> GetNameList(NameType type, int limit)
        {
            // changing the passed strings to lowercase to match json data from NameAPI
            string typeLowerCase = type.ToString().ToLower();

            // creating string to get JSON-data from NameAPI
            string url = urlGender + "both" + urlType + typeLowerCase + urlLimit + limit;

            // Calling method GetJsonData and passing the required url as well
            json_data = GetJsonData(url);

            // convert string of Json-data to list of NameModel
            jsonResult = GetNames(json_data);

            return jsonResult;
        }

        // method to GetNameList with two parameters Limit & Gender
        public static List<NameModel> GetNameList(NameGender gender, int limit)
        {
            // changing the passed strings to lowercase to match json data from NameAPI
            string genderLowerCase = gender.ToString().ToLower();

            // creating string to get JSON-data from NameAPI
            string url = urlGender + gender + urlType + "both" + urlLimit + limit;

            // Calling method GetJsonData and passing the required url as well
            json_data = GetJsonData(url);

            // convert string of Json-data to list of NameModel
            jsonResult = GetNames(json_data);

            return jsonResult;
        }

        // method to GetNameList with three parameters Limit & Type & Gender
        public static List<NameModel> GetNameList(NameType type, NameGender gender, int limit)
        {
            // changing the passed strings to lowercase to match json data from NameAPI
            string genderLowerCase = gender.ToString().ToLower();
            string typeLowerCase = type.ToString().ToLower();

            // creating string to get JSON-data from NameAPI
            string url = urlGender + genderLowerCase + urlType + typeLowerCase + urlLimit + limit;

            // Calling method GetJsonData and passing the required url as well
            json_data = GetJsonData(url);

            // convert string of Json-data to list of NameModel
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
            // Clearing the list of json data in order not to add more names upon more requests
            jsonResult.Clear();
            try
            {
                var list = JObject.Parse(json_data)["names"];
                // matching the JObject properties with NameModel fields
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
                    // adding the new object oneItem to the List<NameModel>
                    jsonResult.Add(oneItem);
                }
            }
            catch (Exception)
            {
                jsonResult = new List<NameModel>();
            }
            return jsonResult;
        }
    }
}
