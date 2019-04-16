﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaskFamilyWeb.Models
{
    public class Event : BaseDoc
    {
        public PeriodicityEnum Periodicity { get; set; }
        public DateTime DateBegin { get; set; }

    }

    public enum PeriodicityEnum
    {
        once,
        everyday,
        everyweek,
        everymonth,
        everyyear
    }

}