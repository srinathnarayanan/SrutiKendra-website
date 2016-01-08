using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ByteBlocks.Web.Control
{
    public class YouTubeVideo
    {
        /// <summary>
        /// Gets or sets Url of the video
        /// </summary>
        public string Url
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets authors of the video
        /// </summary>
        public string Authors
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets description of the video
        /// </summary>
        public string Description
        {
            get;
            set;
        }

        internal static YouTubeVideo CreateInstance(System.ServiceModel.Syndication.SyndicationItem item)
        {
            var video = new YouTubeVideo();
            video.Authors = string.Empty;
            if (null != item.Authors)
            {
                foreach (var author in item.Authors)
                {
                    video.Authors += string.Format("{0},", author.Name);
                }
            }
            video.Title = item.Title.Text;
            var txtContent = item.Content as System.ServiceModel.Syndication.TextSyndicationContent;
            if (null != txtContent)
            {
                video.Description = txtContent.Text;
            }

            if (item.Links != null &&
                item.Links.Count != 0)
            {
                video.Url = item.Links[0].Uri.AbsoluteUri;
            }
           
            return video;
        }
    }
}
