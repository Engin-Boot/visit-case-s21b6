﻿using System;
using System.Text.Json;
//public enum RegionInHosp
//{
//    Entrance1, Entrance2, Entrance3,Entrance4
//};
namespace VisitorCounter.Sender
{
    internal class CommPrimitive
    {
        //[JsonProperty(ItemConverterType = typeof(JavaScriptDateTimeConverter))]
        public DateTime Date { get; set; }
        //[JsonProperty(ItemConverterType = typeof(JavaScriptDateTimeConverter))]
        public TimeSpan Time { get; set; }
        //public const int Counter = 1;
        
    }
}

