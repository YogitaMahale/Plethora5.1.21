using System;
using System.Collections.Generic;
using System.Text;

namespace plathora.Utility
{
    public static class SD
    {
        public const string Role_Affilate = "Affilate";
        public const string Role_Customer = "Customer";
        public const string Role_Admin = "Admin";


      //  public const string cityId {get;set; }
    public static int cityId { get; set; }
    public static string searchText {get;set; }

        //main 
        public static String MerchantKey = "43JVTVB1CX";
        public static String Salt = "T9B5988XNR";
        public static String env = "prod";

        ////test 
        //public static String MerchantKey = "2PBP7IABZ2";
        //public static String Salt = "DAH88E3UWQ";
        //public static String env = "test";
    }
}
