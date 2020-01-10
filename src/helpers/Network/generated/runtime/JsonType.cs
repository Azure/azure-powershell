namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json
{
    internal enum JsonType
    {
        Null    = 0,
        Object  = 1,
        Array   = 2,
        Binary  = 3,
        Boolean = 4,
        Date    = 5,
        Number  = 6,
        String  = 7
    }
}