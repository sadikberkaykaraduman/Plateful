using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.SocialMediaDtos
{
    public class ResultSocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaTitle { get; set; }
        public string SocialMediaUrl { get; set; }
        public string SocialMediaIcon { get; set; }
    }
}
