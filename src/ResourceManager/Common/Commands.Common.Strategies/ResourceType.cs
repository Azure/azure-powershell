namespace Microsoft.Azure.Commands.Common.Strategies
{
    public sealed class ResourceType
    {
        /// <summary>
        /// A resource type namespace, for example 'Microsoft.Network'.
        /// </summary>
        public string Namespace { get; }

        /// <summary>
        /// A resource type provider, for example 'virtualNetworks'.
        /// </summary>
        public string Provider { get; }

        public ResourceType(string namespace_, string provider)
        {
            Namespace = namespace_;
            Provider = provider;
        }
    }
}
