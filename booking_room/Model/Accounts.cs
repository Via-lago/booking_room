﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_room.Model
{
    public class Accounts
    {
        public int EmployeeId { get; set; }
        public string Password { get; set; }
        public string IsDelete { get; set; }
        public string OTP { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
