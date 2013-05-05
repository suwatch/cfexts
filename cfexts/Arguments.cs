using System;
using System.Collections.Generic;
using System.Text;

namespace cfexts
{
    public static class Arguments
    {
        public static string Raw { get; private set; }
        public static string[] Items { get; private set; }

        public static void Init(string args)
        {
            Arguments.Raw = args;
            Arguments.Items = args.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void Clear()
        {
            Arguments.Raw = null;
            Arguments.Items = null;
        }

        public static bool Contains(string value)
        {
            foreach (string str in Items)
            {
                if (str == value)
                    return true;
            }
            return false;
        }
    }
}
