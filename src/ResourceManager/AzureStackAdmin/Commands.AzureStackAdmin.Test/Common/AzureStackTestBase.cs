namespace Microsoft.AzureStack.Commands.Admin.Test.Common
{
    using System;

    public abstract class AzureStackTestBase
    {
        private static Random random = new Random();

        public AzStackController SetupHelper { get; private set; }

        protected AzureStackTestBase()
        {
            this.SetupHelper = new AzStackController();
        }

        public void RunPowerShellTest(string script, bool skipCleanupOnFailure=false)
        {
            if (!skipCleanupOnFailure)
            {
                script = "Start-Test {" + script + "}";
            }
            this.SetupHelper.SetupModules(@".\" + this.GetType().Name + ".ps1");

            this.SetupHelper.RunPowerShellTest(script);
        }

    }
}
