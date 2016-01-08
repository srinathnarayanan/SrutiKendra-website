using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace ByteBlocks.Web.Control
{
    public class RenderingEngine
    {
        private readonly YouTube _control;
        public RenderingEngine(YouTube youTubeControl)
        {
            _control = youTubeControl;
        }

        public void DesignTimeRender(HtmlTextWriter writer)
        {
            writer.Write("ByteBlocks YouTube Player");
        }

        public void RunTimeRender(HtmlTextWriter writer)
        {
            writer.Write(GetControlHtml());
        }

        string GetControlHtml()
        {
            var videoUrl = GetVideoUrl();
            if (string.IsNullOrEmpty(videoUrl))
            {
                return string.Empty;
            }

            var dic = ParseQuery(new Uri(videoUrl));
            if (!dic.ContainsKey("v"))
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.AppendFormat("<object width=\"{0}\" height=\"{1}\">", _control.Width, _control.Height);
            sb.AppendFormat("<param name=\"movie\" value=\"http://www.youtube.com/v/{0}\"></param>", dic["v"]);
            sb.AppendFormat("<param name=\"allowFullScreen\" value=\"{0}\"></param>", _control.AllowFullScreen);
            sb.Append("<param name=\"allowscriptaccess\" value=\"always\"></param>");
            sb.AppendFormat("<embed src=\"http://www.youtube.com/v/{0}\" ", dic["v"]);
            sb.Append(" type=\"application/x-shockwave-flash\" allowscriptaccess=\"always\" ");
            sb.AppendFormat("allowfullscreen=\"{0}\" width=\"{1}\" height=\"{2}\"></embed></object>", _control.AllowFullScreen, _control.Width, _control.Height);

            return sb.ToString();
        }

        string GetVideoUrl()
        {
            if (!string.IsNullOrEmpty(_control.VideoUrl))
            {
                return _control.VideoUrl;
            }

            var feedAccess = new YouTubeVideoAccess();
            var videos = feedAccess.GetVideos(_control.FeedType);
            if (videos.Count == 0)
            {
                return string.Empty;
            }

            if (!_control.RandomResults)
            {
                return videos[Math.Max(videos.Count, _control.IndexToShow)].Url;
            }

            return videos[GetRandomIndex(videos.Count) - 1].Url;
        }

        internal static System.Collections.Specialized.StringDictionary ParseQuery(Uri uri)
        {
            var dic = new System.Collections.Specialized.StringDictionary();

            var queryString = uri.Query;
            if (!string.IsNullOrEmpty(uri.Query))
            {
                if (queryString.StartsWith("?"))
                {
                    queryString = queryString.Substring(1);
                }
                var fragments = queryString.Split("&".ToCharArray());
                if (fragments.Length != 0)
                {
                    foreach (var fragment in fragments)
                    {
                        var keyvalue = fragment.Split("=".ToCharArray());
                        if (keyvalue.Length == 2)
                        {
                            dic[keyvalue[0]] = keyvalue[1];
                        }
                    }
                }
            }
            return dic;
        }

        public static byte GetRandomIndex(int maxEntries)
        {
            var rngCsp = new System.Security.Cryptography.RNGCryptoServiceProvider();
            byte[] randomNumber = new byte[1];
            rngCsp.GetBytes(randomNumber);
            return (byte)((randomNumber[0] % maxEntries) + 1);
        }
    }
}
