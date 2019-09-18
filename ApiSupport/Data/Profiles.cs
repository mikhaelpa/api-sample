using ApiSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSupport.Data
{
    public static class Profiles
    {
        public static List<ProfileModel> Bio => new List<ProfileModel>
        {
            new ProfileModel
            {
                Name = "Mikhael Pramodana Agus",
                Age = 24,
                Dob = "Sleman, 12 March 1995",
                Religion = "Christian"
            },
             new ProfileModel
            {
                Name = "Cindy Ong",
                Age = 21,
                Dob = "Medan, 18 Mei 1998",
                Religion = "Budhist"
            },
              new ProfileModel
            {
                Name = "Sample 3",
                Age = 24,
                Dob = "Sleman, 12 March 1995",
                Religion = "Christian"
            }
        };
    }
}
