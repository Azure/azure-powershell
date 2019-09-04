namespace Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001
{
    public partial class KeyItem
    {
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.FormatTable(Index = 0)]
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Kid))
                {
                    var tempKid = this.Kid;
                    while (!string.IsNullOrEmpty(tempKid))
                    {
                        var idx = tempKid.IndexOf('/');
                        if (idx < 0)
                        {
                            return string.Empty;
                        }

                        var sub = tempKid.Substring(0, idx);
                        if (sub.Equals("keys"))
                        {
                            return tempKid.Substring(idx + 1);
                        }

                        tempKid = tempKid.Substring(idx + 1);
                    }

                    return string.Empty;
                }

                return string.Empty;
            }
        }
    }
}