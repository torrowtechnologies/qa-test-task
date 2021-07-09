using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestTorrowtech.RequestApi
{
    public class Request
    {
        private static readonly string ApiPhoneCode = "https://smsdev1.torrow.net/api/phone/";
        public static string GetCodeForMobileNumber(string number)
        {
            string answer = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ApiPhoneCode + number);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    answer = reader.ReadToEnd();
                }
            }
            response.Close();
            return answer;
        }
    }
}
