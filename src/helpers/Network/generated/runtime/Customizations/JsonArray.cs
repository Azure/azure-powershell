namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    public partial class JsonArray
    {
        internal override object ToValue() =>  Count == 0 ? new object[0] : System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(this, each => each.ToValue()));
    }


}