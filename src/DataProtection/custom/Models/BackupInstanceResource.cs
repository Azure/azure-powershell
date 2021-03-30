﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview
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
