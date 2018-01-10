namespace Microsoft.Azure.Commands.Common.Strategies.Templates
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-manager-templates-outputs
    /// </summary>
    public class Output
    {
        public string type { get; set; }

        public object value { get; set; }
    }
}
