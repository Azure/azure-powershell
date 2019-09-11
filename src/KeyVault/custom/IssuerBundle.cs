namespace Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001
{
    public partial class IssuerBundle
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
                        if (sub.Equals("issuers"))
                        {
                            return tempId.Substring(idx + 1);
                        }

                        tempId = tempId.Substring(idx + 1);
                    }
                }

                return string.Empty;
            }
        }
    }
}