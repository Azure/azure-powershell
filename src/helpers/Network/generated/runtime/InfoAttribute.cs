namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Class)]
    public class InfoAttribute : Attribute
    {
        public bool Required { get; set; } = false;
        public bool ReadOnly { get; set; } = false;
        public Type[] PossibleTypes { get; set; } = new Type[0];
        public string Description { get; set; } = "";
        public string SerializedName { get; set; } = "";
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class CompleterInfoAttribute : Attribute
    {
        public string Script { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DefaultInfoAttribute : Attribute
    {
        public string Script { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
    }
}