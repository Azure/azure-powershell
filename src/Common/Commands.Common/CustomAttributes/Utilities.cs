using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Common.CustomAttributes
{
    class Utilities
    {
        public static string GetNameFromCmdletType(Type type)
        {
            string cmdletName = null;
            CmdletAttribute cmdletAttrib = (CmdletAttribute)type.GetCustomAttributes(typeof(CmdletAttribute), false).FirstOrDefault();

            if (cmdletAttrib != null)
            {
                cmdletName = cmdletAttrib.VerbName + "-" + cmdletAttrib.NounName;
            }

            return cmdletName;
        }
    }
}
