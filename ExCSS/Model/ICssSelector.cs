﻿// MIT License. https://github.com/sst-soft/ExCSS which is a fork of https://github.com/Unity-Technologies/ExCSS.

namespace ExCSS.Model
{
    internal interface ISupportsSelector
    {
        BaseSelector Selector { get; set; }
    }
}