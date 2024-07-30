using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    public static class PSStyleFormatter
    {
        public static bool SupportsVirtualTerminal { get; set; }

        public static string PSStyleStringFormat(bool supportsVirtualTerminal, string informationStr)
        {
            string information = string.Empty;
            string[] informationStrArr = informationStr.Split('|');

            if (supportsVirtualTerminal)
            {
                foreach (string item in informationStrArr)
                {
                    information += item;
                }
            }
            else
            {
                for (int i = 1; i < informationStrArr.Length; i += 2)
                {
                    information += informationStrArr[i];
                }
            }

            return information;
        }
    }
}
