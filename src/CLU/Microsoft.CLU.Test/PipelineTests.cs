using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Microsoft.Azure.Commands.ScenarioTest;
using System.Management.Automation.Runspaces;
using System.Management.Automation;

namespace Microsoft.CLU.Test
{
    public class PipelineTests
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestBasicPipeline()
        {
            var runspace = RunspaceFactory.CreateRunspace(InitialSessionState.CreateDefault());
            runspace.Open();
            var pipeline = runspace.CreatePipeline();
            pipeline.Commands.Add(new Command("az env"));
            var objs = pipeline.Invoke(new string[] { "az", "env" });
            runspace.Close();
        }
    }
}
