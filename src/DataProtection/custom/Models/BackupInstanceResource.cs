using System;
using System.Collections.Generic;
using System.Text;

<<<<<<< HEAD
namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501
=======
namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
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