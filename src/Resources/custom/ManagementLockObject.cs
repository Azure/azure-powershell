namespace Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901
{
    public partial class ManagementLockObject
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.FormatTable(Index = 2)]
        public string ResourceId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Id))
                {
                    var idx = this.Id.IndexOf("/providers/Microsoft.Authorization/locks/");
                    if (idx < 0)
                    {
                        return string.Empty;
                    }

                    return this.Id.Substring(0, idx);
                }

                return string.Empty;
            }
        }
    }
}