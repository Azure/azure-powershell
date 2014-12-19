using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commands.StorSimple.Test;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets;
using Xunit;

namespace Microsoft.Azure.Commands.StorSimple.Test.ScenarioTests
{
    public class ResourceTests : StorSimpleTestBase
    {
        #region Get-AzureStorSimpleResource
        [Fact]
        [Trait("StorSimpleCmdlets", "Get-Resource")]
        public void TestGetResourceCheckCount()
        {
            RunPowerShellTest("Test-GetResourcesCheckCount");
        }

        [Fact]
        [Trait("StorSimpleCmdlets", "Get-Resource")]
        public void TestGetResource()
        {
            RunPowerShellTest("Test-GetResources");
        }

        #endregion Get-AzureStorSimpleResource

        #region Select-AzureStorSimpleResource
        [Fact]
        [Trait("StorSimpleCmdlets", "Set-Resource")]
        public void TestSetResource_IncorrectName()
        {
            RunPowerShellTest("Test-SetResources-IncorrectResourceName");
        }

        [Fact]
        [Trait("StorSimpleCmdlets", "Set-Resource")]
        public void TestSetResource_DirectInput()
        {
            RunPowerShellTest("Test-SetResources-DirectInput");
        }

        [Fact]
        [Trait("StorSimpleCmdlets", "Set-Resource")]
        public void TestSetResource_PipedInput()
        {
            RunPowerShellTest("Test-SetResources-PipedInput");
        }
        #endregion Select-AzureStorSimpleResource

        #region Get-AzureStorSimpleResourceContext
        [Fact]
        [Trait("StorSimpleCmdlets", "Get-ResourceContext")]
        public void TestGetResourceContext()
        {
            RunPowerShellTest("Test-GetResourceContext");
        }
        #endregion Get-AzureStorSimpleResourceContext
    }
}
