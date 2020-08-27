using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Archanagrand.Models
{
    public class connection
    {
        public static string HttpGet(string URI,string data)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI+data);
            //req.Proxy = new System.Net.WebProxy(true); //true means no proxy
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
        public static string HttpPost(string URI, string Parameters)

        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(URI);
            // req.Proxy = new System.Net.WebProxy(ProxyString, true);
            //Add these, as we're doing a POST
            req.ContentType = "application/json";
            req.Method = "POST";
            //We need to count how many bytes we're sending. Post'ed Faked Forms should be name=value&
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(Parameters);
            req.ContentLength = bytes.Length;
            System.IO.Stream os = req.GetRequestStream();
            os.Write(bytes, 0, bytes.Length); //Push it out there
            os.Close();
            System.Net.WebResponse resp = req.GetResponse();
            if (resp == null) return null;
            System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
        public static string getconfigvalue(string key)
        {
            if (ConfigurationManager.AppSettings[key] != null)

                return ConfigurationManager.AppSettings[key];
            else
                return "hi";
        }
    }
}