﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learn.bbs.bl.DTOs
{
    public struct PostInfo
    {
        public Guid AreaUid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
