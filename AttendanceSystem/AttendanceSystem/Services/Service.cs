using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Text;

namespace AttendanceSystem.Services
{
    public class Service
    {
        public List<AttendanceSystem.Models.GetString> GetJsonFunction()
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
                item.Date = Object["created_at"].ToString();
                item.Status = Object["field2"].ToString();
                AttendaceRecrod.Add(item);
            }
            return AttendaceRecrod;
        }


        public List<AttendanceSystem.Models.GetMember> GetMemberFunction()
        {
            var url = "https://thingspeak.com/channels/270761/feed.json?api_key=EBNJ0E5FUDOHYEMY&timezone=Asia%2FTaipei";
            var jsonString = "";
            using (var webclient = new System.Net.WebClient())
            {
                webclient.Encoding = Encoding.UTF8;
                jsonString = webclient.DownloadString(url);
            }
            var Member = new List<AttendanceSystem.Models.GetMember>();
            JObject jobject = JObject.Parse(jsonString);
            foreach (var Object in jobject["feeds"])
            {
                var item = new AttendanceSystem.Models.GetMember();
                item.RFID_UID = Object["field1"].ToString();
                item.UserName = Object["field2"].ToString();
               Member.Add(item);
            }
            return Member;
        }
        public List<AttendanceSystem.Models.GetString> CompareFunction(List<AttendanceSystem.Models.GetString> Recrod,List<AttendanceSystem.Models.GetMember>Member)
        {

            for (int i = 0; i < Recrod.Count;i++ )
            {
                for (int j = 0; j < Member.Count;j++ )
                {
                    if (Recrod[i].RFID_UID.CompareTo(Member[j].RFID_UID) == 0)
                    {
                        Recrod[i].UserName= Member[j].UserName;
                        break;
                    }
                    else 
                    {
                        Recrod[i].UserName = "此卡未定義";
                    }
                }
            }
            return Recrod;
        }

    }
}