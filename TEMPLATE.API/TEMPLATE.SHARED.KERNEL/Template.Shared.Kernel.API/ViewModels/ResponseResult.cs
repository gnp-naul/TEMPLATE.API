﻿using System.Collections.Generic;

namespace Template.Shared.Kernel.Api.ViewModels
{
    public class ResponseResult
    {
        public bool Success { get; set; }

        public object Data { get; set; }

        public List<string> Notifications { get; set; } = new List<string>();
    }
}
