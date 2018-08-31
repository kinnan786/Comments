using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using log4net;

namespace Comments.Facebook
{
    public class GraphApiResponse
    {
        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public string GetResponse(string address)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(address).Result;

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                Log.Error(" Message = " + ex.Message + " stacktrace= " + ex.StackTrace);
                throw ex;
            }
        }

        public string GeturlExpiryResponse(string address)
        {
            try
            {
                var client = new HttpClient();
                var response = client.GetAsync(address).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                Log.Error(" Message = " + ex.Message + " stacktrace= " + ex.StackTrace);
                throw ex;
            }
        }
    }
}