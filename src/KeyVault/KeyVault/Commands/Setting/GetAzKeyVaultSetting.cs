using Microsoft.Azure.Commands.KeyVault.Models;

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Commands.Setting
{
    [Cmdlet("Get", ResourceManager.Common.AzureRMConstants.AzurePrefix + "KeyVaultSetting")]
    [OutputType(typeof(PSKeyVaultSetting))]
    public class GetAzKeyVaultSetting: KeyVaultCmdletBase
    {
        [Parameter(Position = 0)]
        public string HsmName;

        [Parameter(Position = 1)]
        public string Name;


        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                WriteObject(this.Track2DataClient.GetManagedHsmSettings(HsmName), true);
            }
            else
            {
                WriteObject(this.Track2DataClient.GetManagedHsmSetting(HsmName, Name));
            }
        }

    }
}
