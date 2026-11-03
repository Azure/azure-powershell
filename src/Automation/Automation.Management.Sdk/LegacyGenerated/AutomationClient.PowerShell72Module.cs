namespace Microsoft.Azure.Management.Automation
{
    public partial interface IAutomationClient
    {
        IPowerShell72ModuleOperations PowerShell72Module { get; }
    }

    public partial class AutomationClient
    {
        public virtual IPowerShell72ModuleOperations PowerShell72Module { get; private set; }

        partial void CustomInitialize()
        {
            this.PowerShell72Module = new PowerShell72ModuleOperations(this);
        }
    }
}
