using System.Security;

namespace Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001
{
    public partial class SecretBundle

    {
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.FormatTable(Index = 0)]
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Id))
                {
                    var tempId = this.Id;
                    while (!string.IsNullOrEmpty(tempId))
                    {
                        var idx = tempId.IndexOf('/');
                        if (idx < 0)
                        {
                            return string.Empty;
                        }

                        var sub = tempId.Substring(0, idx);
                        if (sub.Equals("secrets"))
                        {
                            tempId = tempId.Substring(idx + 1);
                            idx = tempId.IndexOf("/" + this.Version);
                            if (idx < 0)
                            {
                                return tempId;
                            }

                            return tempId.Substring(0, idx);
                        }

                        tempId = tempId.Substring(idx + 1);
                    }
                }

                return string.Empty;
            }
        }

        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.FormatTable(Index = 1)]
        public string Version
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Id))
                {
                    var idx = this.Id.LastIndexOf('/');
                    return this.Id.Substring(idx + 1);
                }

                return string.Empty;
            }
        }
    }
}