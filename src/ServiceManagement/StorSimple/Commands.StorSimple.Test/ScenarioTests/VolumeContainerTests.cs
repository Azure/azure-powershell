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
    public class VolumeContainerTests : StorSimpleTestBase
    {
        [Fact]
        [Trait("StorSimpleCmdlets", "VolumeContainer")]
        public void TestVolumeContainerSync()
        {
            RunPowerShellTest("Test-VolumeContainerSync");
        }

        [Fact]
        [Trait("StorSimpleCmdlets", "VolumeContainer")]
        public void TestVolumeContainerAsync()
        {
            RunPowerShellTest("Test-VolumeContainerAsync");
        }

        [Fact]
        [Trait("StorSimpleCmdlets", "VolumeContainer")]
        public void TestVolumeContainerSync_RepetitiveDCName()
        {
            RunPowerShellTest("Test-VolumeContainerSync_RepetitiveDCName");
        }
                            
    }
}