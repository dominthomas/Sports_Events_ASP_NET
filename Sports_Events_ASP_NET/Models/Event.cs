using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sports_Events_ASP_NET.Models
{
    public class Event
    {
        public int EventID { get; set; }

        public string Title { get; set; }

        public int AddressID { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        private readonly string Pattern = @"(\w*) (\w*)";

        private readonly string EmptyJPG = "empty.jpg";

        public string getCategoryImageString()
        {
            string Lower = this.Category.ToLower().Trim();

            Match m = Regex.Match(Lower, Pattern);

            string ProfImgStr = m.Groups[1].ToString();

            if(ProfImgStr != null & !ProfImgStr.Equals("") & m.Groups[2] != null)
            {
                ProfImgStr = ProfImgStr + "_" + m.Groups[2].ToString() + ".jpg";
            }
            else if (ProfImgStr != null & !ProfImgStr.Equals(""))
            {
                ProfImgStr += ".jpg";
            }

            string ReturnStr = EmptyJPG;

            if (ProfImgStr != null && !ProfImgStr.Equals(""))
            {
                return ProfImgStr;
            }

            return ReturnStr;
        }
    }
}
