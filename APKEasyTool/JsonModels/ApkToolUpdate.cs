using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APKEasyTool.JsonModels
{
    public class ApkToolUpdate
    {
        [JsonProperty("values")]
        public ApkToolUpdateValue[] Values { get; set; }

        public class ApkToolUpdateValue
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("size")]
            public string Size { get; set; }

            [JsonProperty("created_on")]
            public DateTime CreatedOn { get; set; }

            [JsonProperty("links")]
            private ApkToolUpdateLink Links { get; set; }

            public class ApkToolUpdateLink
            {
                [JsonProperty("self")]
                public ApkToolUpdateLinkSelf Self { get; set; }

                public class ApkToolUpdateLinkSelf
                {
                    [JsonProperty("href")]
                    public string Href { get; set; }
                }
            }

            public string DownloadUrl
            {
                get
                {
                    return Links.Self.Href;
                }
            }
        }

    }
}
