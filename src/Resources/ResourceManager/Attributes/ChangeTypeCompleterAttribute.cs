namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Attributes
{
    using System.Management.Automation;

    public class ChangeTypeCompleterAttribute : ArgumentCompleterAttribute
    {
        public ChangeTypeCompleterAttribute()
            : base(typeof(ChangeTypeCompleter))
        {
        }
    }
}
