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
    public class VolumeTests : StorSimpleTestBase
    {
        [Fact]
        [Trait("StorSimpleCmdlets", "Volume")]
        public void TestVolumeSync()
        {
            RunPowerShellTest("Test-VolumeSync");
        }

        [Fact]
        [Trait("StorSimpleCmdlets", "Volume")]
        public void TestVolumeAsync()
        {
            RunPowerShellTest("Test-VolumeAsync");
        }

        [Fact]
        [Trait("StorSimpleCmdlets", "Volume")]
        public void TestNewVolumeRepetitiveName()
        {
            RunPowerShellTest("Test-NewVolumeRepetitiveName");
        }
                            
    }
}