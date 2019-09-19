namespace Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180901Preview
{
    public partial class RoleAssignment
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.FormatTable(Index = 0)]
        public string DisplayName {get;set;}

        [Microsoft.Azure.PowerShell.Cmdlets.Resources.FormatTable(Index = 1)]
        public string ObjectId {get;set;}

        [Microsoft.Azure.PowerShell.Cmdlets.Resources.FormatTable(Index = 2)]
        public string ObjectType {get;set;}

        [Microsoft.Azure.PowerShell.Cmdlets.Resources.FormatTable(Index = 3)]
        public string RoleDefinitionName {get;set;}
    }
}