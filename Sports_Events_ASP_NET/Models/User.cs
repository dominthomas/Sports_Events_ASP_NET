﻿using System;
using System.Text.RegularExpressions;

namespace Sports_Events_ASP_NET.Models
{
    public class User
    {
        public int UserID { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public int AddressID { get; set; }

        public int DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string WorkLocation { get; set; }

        public string Bio { get; set; }

        public string Skills { get; set; }

        private readonly string Pattern = @"(\w*) (\w*)";

        private readonly string EmptyJPG = "empty.jpg";

        public string getProfileImageString()
        {
            string Lower = this.Name.ToLower().Trim();

            Match m = Regex.Match(Lower, Pattern);

            string ProfImgStr;

            ProfImgStr = m.Groups[1] + "_" + m.Groups[2] + ".jpg";

            string ReturnStr = EmptyJPG;

            if(ProfImgStr != null && !ProfImgStr.Equals(""))
            {
                ReturnStr = ProfImgStr;
            }

            return ReturnStr;
        }
    }
}
