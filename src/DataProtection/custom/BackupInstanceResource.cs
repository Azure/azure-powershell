using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha

{
    public partial class BackupInstanceResource
    {
        public string FriendlyName
        {
            get
            {
                string backupInstanceName = this.Name;
                int lastIndex = backupInstanceName.LastIndexOf('_');
                return backupInstanceName.Substring(0, lastIndex);
            }
        }
    }
}
