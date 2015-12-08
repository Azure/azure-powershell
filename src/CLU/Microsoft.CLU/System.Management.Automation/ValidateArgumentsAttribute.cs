namespace System.Management.Automation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public abstract class ValidateArgumentsAttribute : CmdletMetadataAttribute
    {
        protected ValidateArgumentsAttribute() { }

        internal protected abstract void Validate(object arguments, EngineIntrinsics engineIntrinsics);
    }
}
