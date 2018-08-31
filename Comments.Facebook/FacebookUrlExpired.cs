using System;

namespace Comments.Facebook
{
    public class FacebookUrlExpired
    {
        public string CheckVideoUrl(string url)
        {
            try
            {
                var a = new GraphApiResponse();
                return a.GeturlExpiryResponse(url);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}