namespace AzDev.Models.PSModels
{
    public class PSDevContext
    {
        public string AzurePowerShellRepositoryRoot { get; set; }
        public string AzurePowerShellCommonRepositoryRoot { get; set; }
        public string ContextPath { get; set; }

        public PSDevContext(DevContext context, string path)
        {
            AzurePowerShellRepositoryRoot = context.AzurePowerShellRepositoryRoot;
            AzurePowerShellCommonRepositoryRoot = context.AzurePowerShellCommonRepositoryRoot;
            ContextPath = path;
        }
    }
}
