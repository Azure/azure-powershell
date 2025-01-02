using System;
using System.IO;
using System.Management.Automation;
using AzDev.Models;
using AzDev.Models.PSModels;

namespace AzDev.Cmdlets.Context
{
    [Cmdlet("Set", "DevContext")]
    [OutputType(typeof(PSDevContext))]
    public class SetContextCmdlet : DevCmdletBase
    {
        [Parameter()]
        [Alias("AzurePowerShellRepositoryRoot")]
        public string RepoRoot { get; set; }

        [Parameter()]
        [Alias("AzurePowerShellCommonRepositoryRoot")]
        public string CommonRepoRoot { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            DevContext context;
            try { context = ContextProvider.LoadContext(); }
            catch
            {
                // ignore if context is not found
                context = new DevContext();
            }

            SetPathProperty(nameof(RepoRoot), x => context.AzurePowerShellRepositoryRoot = x);
            SetPathProperty(nameof(CommonRepoRoot), x => context.AzurePowerShellCommonRepositoryRoot = x);
            ContextProvider.SaveContext(context);
            WriteObject(new PSDevContext(context, ContextProvider.ContextPath));
        }

        private void SetPathProperty(string parameterName, Action<string> propertySetter)
        {
            if (MyInvocation.BoundParameters.ContainsKey(parameterName))
            {
                string path = (string)MyInvocation.BoundParameters[parameterName];

                if (!string.IsNullOrEmpty(path))
                {
                    string fullPath = Path.IsPathRooted(path) ? path : Path.Combine(SessionState.Path.CurrentFileSystemLocation.Path, path);
                    if (Directory.Exists(fullPath))
                    {
                        propertySetter(Path.GetFullPath(fullPath));
                        return;
                    }
                }

                throw new ArgumentException($"The input path [{path}] is incorrect or does not exist.]");
            }
        }
    }
}
