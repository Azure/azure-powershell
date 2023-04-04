using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301
{
    public partial class BackupInstanceResource
    {
        private string backupInstanceName;
        public string BackupInstanceName
        {
            get 
            {
                if(this.Name != null && this.Name != "")
                {
                    return this.Name;
                }
                return this.backupInstanceName;
            }
            set { backupInstanceName = value; }
        }
    }
}