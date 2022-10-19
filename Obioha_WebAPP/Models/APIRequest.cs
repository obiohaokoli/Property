﻿using Microsoft.AspNetCore.Mvc;
using static Obioha_Utility.SD;

namespace Obioha_WebAPP.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } //= ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}