using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Net;

namespace ByteBlocks.Web.Control
{
    public class YouTubeVideoAccess
    {
        internal static string STANDARDFEEDSURL = " http://gdata.youtube.com/feeds/api/standardfeeds/";

        public List<YouTubeVideo> GetVideos(VideoFeedType feedType)
        {
            List<YouTubeVideo> collVideos = null;

            String strReqUrl = String.Format("{0}{1}", STANDARDFEEDSURL, GetFeedUrlSuffix(feedType));
            String strResponse = ProcessRequest(strReqUrl);
            if (!string.IsNullOrEmpty(strResponse))
            {
                var sr = new System.IO.StringReader(strResponse);
                var xmlReader = XmlReader.Create(sr);
                var syndReader = System.ServiceModel.Syndication.SyndicationFeed.Load(xmlReader);
                collVideos = new List<YouTubeVideo>();
                foreach (var item in syndReader.Items)
                {
                    var video = YouTubeVideo.CreateInstance(item);
                    collVideos.Add(video);
                }
            }
            return collVideos;
        }

        static string GetFeedUrlSuffix(VideoFeedType feedType)
        {
            switch (feedType)
            {
                case VideoFeedType.TopRated:
                    return "top_rated";
                case VideoFeedType.TopFeatured:
                    return "top_featured";
                case VideoFeedType.MostDiscussed:
                    return "most_discussed";
                case VideoFeedType.MostPopular:
                    return "most_popular";
                case VideoFeedType.MostResponded:
                    return "most_responded";
                case VideoFeedType.MostViewed:
                    return "most_viewed";
                case VideoFeedType.RecentlyFeatured:
                    return "recently_featured";
                case VideoFeedType.MostRecent:
                default:
                    return "most_recent";
            }
        }

        #region Web Access
        internal static String ProcessRequest(String strUrl)
        {
            String strResp = String.Empty;
            HttpWebResponse webResp = null;
            HttpWebRequest webReq = WebRequest.Create(strUrl) as HttpWebRequest;
            webReq.Method = "GET";
            System.Net.CookieContainer cookies = new System.Net.CookieContainer();
            webReq.CookieContainer = cookies;
            try
            {
                webResp = webReq.GetResponse() as HttpWebResponse;
                byte[] respBytes = ProcessContent(webResp);
                strResp = ConvertResponseContentToString(respBytes);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (null != webResp)
                {
                    webResp.Close();
                }
            }
            return strResp;
        }

        internal static byte[] ProcessContent(System.Net.HttpWebResponse resp)
        {
            Int64 iContentLength = resp.ContentLength;

            MemoryStream memStream = new MemoryStream();
            const int BUFFER_SIZE = 4096;
            int iRead = 0;
            int idx = 0;
            Int64 iSize = 0;
            memStream.SetLength(BUFFER_SIZE);
            while (true)
            {
                byte[] respBuffer = new byte[BUFFER_SIZE];
                try
                {
                    iRead = resp.GetResponseStream().Read(respBuffer, 0, BUFFER_SIZE);
                }
                catch (System.Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.Message);
                }

                if (iRead == 0)
                {
                    break;
                }

                iSize += iRead;
                memStream.SetLength(iSize);
                memStream.Write(respBuffer, 0, iRead);
                idx += iRead;
            }

            byte[] contentBytes = memStream.ToArray();
            memStream.Close();
            return contentBytes;
        }

        internal static String ConvertResponseContentToString(byte[] output)
        {
            String strOutput = String.Empty;
            if (null != output)
            {
                System.Text.Encoding enc = null;
                enc = System.Text.Encoding.UTF8;
                strOutput = enc.GetString(output);
            }
            return strOutput;
        }
        #endregion
    }
}
