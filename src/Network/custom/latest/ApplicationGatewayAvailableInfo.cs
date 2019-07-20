namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models
{
    public partial class ApplicationGatewayAvailableInfo
    {
        public string[] AvailableRequestHeaders { get; set; } = new string[0];
        public string[] AvailableResponseHeaders { get; set; } = new string[0];
        public string[] AvailableServerVariables { get; set; } = new string[0];
    }
}
