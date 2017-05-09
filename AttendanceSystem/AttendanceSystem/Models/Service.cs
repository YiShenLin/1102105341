using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AttendanceSystem.Models
{
    public class Service
    {
        string str;
        public static List<AttendanceSystem.Models.GetString> GetJsonFunction()
        {
          var url= "https://thingspeak.com/channels/267190/feed.json?api_key=J8OGS6CAVVJ9P4TC&timezone=Asia%2FTaipei";
          var jsonString = "";
          using (var webclient = new System.Net.WebClient())
            {
                webclient.Encoding = Encoding.UTF8;
                jsonString = webclient.DownloadString(url);
            }
            var AttendaceRecrod= new List<AttendanceSystem.Models.GetString>();
            JObject jobject = JObject.Parse(jsonString);
            foreach (var Object in jobject["feeds"])
            {
                var item = new AttendanceSystem.Models.GetString();
                item.RFID_UID = Object["field1"].ToString();
                item.UserName = Object["field2"].ToString();
                item.Date = Object["created_at"].ToString();
                item.Status = Object["field3"].ToString();
                AttendaceRecrod.Add(item);
            }
            return AttendaceRecrod;
        }
    }
}