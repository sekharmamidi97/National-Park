using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.Models
{
    public class RandomBackgroundGenerator
    {
        public string GetPicName()
        {
            Random r = new Random();
            int rInt = r.Next(0, 100);

        List<string> codeList = new List<string>()
        {
            "cvnp",
            "enp",
            "gcnp",
            "gnp",
            "gsmnp",
            "gtnp",
            "mrnp",
            "rmnp",
            "ynp",
            "ynp2",
        };

            return codeList[rInt];
        }
    }
}