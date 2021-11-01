﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IGI_Web_953501_Smolyar.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}