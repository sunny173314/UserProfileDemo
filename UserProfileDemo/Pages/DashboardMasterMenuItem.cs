﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileDemo.Pages
{
    public class DashboardMasterMenuItem
    {
        public DashboardMasterMenuItem()
        {
            TargetType = typeof(DashboardMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public String Icon { get; set; }
        public Type TargetType { get; set; }
    }
}