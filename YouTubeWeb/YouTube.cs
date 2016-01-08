using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace ByteBlocks.Web.Control
{
    [
        DefaultProperty("VideoUrl"),
        ToolboxData("<{0}:YouTubeUnit runat=\"server\"></{0}:YouTubeUnit>"),
        ParseChildren(true),
        PersistChildren(false)
    ]
    public class YouTube : System.Web.UI.Control
    {
        #region Control Properties
        /// <summary>
        /// Gets or sets url of Youtube Video
        /// </summary>
        [Category("Data")]
        [Bindable(true)]
        [Description("Url of Youtube video")]
        public string VideoUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(VideoFeedType.RecentlyFeatured)]
        [Bindable(true)]
        [Category("Apperance")]
        [Description("Standard feed type")]
        public VideoFeedType FeedType
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(385)]
        [Bindable(true)]
        [Category("Apperance")]
        [Description("Height of video player")]
        public short Height
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(480)]
        [Bindable(true)]
        [Category("Apperance")]
        [Description("Width of video player")]
        public short Width
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(true)]
        [Bindable(true)]
        [Category("Apperance")]
        [Description("Allow video player to be full screen or not")]
        public bool AllowFullScreen
        {
            get;
            set;
        }

        [DefaultValue(false)]
        [Bindable(true)]
        [Category("Data")]
        [Description("Value indicating if random video from feed should be shown")]
        public bool RandomResults
        {
            get;
            set;
        }

        [DefaultValue(0)]
        [Bindable(true)]
        [Category("Data")]
        [Description("Index of feed item to show")]
        public int IndexToShow
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            var renderer = new RenderingEngine(this);
            if (DesignMode)
            {
                renderer.DesignTimeRender(writer);
            }
            else
            {
                renderer.RunTimeRender(writer);
            }
        }

        #region Helper Methods
        #endregion
    }
}
