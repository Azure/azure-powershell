namespace Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Models.Api20161001
{
    public partial class CertificateOperation
    {
        [Microsoft.Azure.PowerShell.Cmdlets.KeyVault.FormatTable(Index = 0)]
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Target))
                {
                    var tempTarget = this.Target;
                    while (!string.IsNullOrEmpty(tempTarget))
                    {
                        var idx = tempTarget.IndexOf('/');
                        if (idx < 0)
                        {
                            return string.Empty;
                        }

                        var sub = tempTarget.Substring(0, idx);
                        if (sub.Equals("certificates"))
                        {
                            return tempTarget.Substring(idx + 1);
                        }

                        tempTarget = tempTarget.Substring(idx + 1);
                    }
                }

                return string.Empty;
            }
        }
    }
}