﻿namespace AsmeFace
{
    public class Helper
    {
        public static string CnnVal(string name)
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
