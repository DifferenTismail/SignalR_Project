﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_WebUI.Dtos.SocialMediaDtos
{
    public class GetSocialMediaDto
    {
        public int SocialMeadiaID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
