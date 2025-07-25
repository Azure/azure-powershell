using Azure.Security.KeyVault.Administration;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class PSKeyVaultSetting
    {
        /// <summary>
        /// The account setting to be updated.
        /// </summary>
        public string HsmName;

        /// <summary>
        /// The account setting to be updated.
        /// </summary>
        public string Name;

        /// <summary>
        /// Gets the type specifier of the value.
        /// </summary>
        public string Type;

        /// <summary>
        /// Gets the value of the account setting.
        /// </summary>
        public string Value;

        public PSKeyVaultSetting() { }


        public PSKeyVaultSetting(KeyVaultSetting keyVaultSetting, string hsmName = null) 
        {
            if (null != keyVaultSetting)
            {
                Name = keyVaultSetting.Name;
                Type = keyVaultSetting.SettingType?.ToString();
                Value = keyVaultSetting.Value.ToString();
            }
            HsmName = hsmName;
        }

        public override string ToString() => $"{Name}={Value} ({Type ?? string.Empty})";

    }
}
