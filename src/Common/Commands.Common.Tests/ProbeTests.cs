using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace Commands.Common.Tests
{
    public class ProbeTests
    {
        private readonly string _pwsh;

        public ProbeTests()
        {
#if !NETSTANDARD
            _pwsh = "powershell";
#else
            _pwsh = "pwsh";
#endif        
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FalseWhenProgramDoesNotExistTest()
        {
            Assert.False(GeneralUtilities.Probe("foo"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TrueWhenProgramDoesExistTest()
        {
            Assert.True(GeneralUtilities.Probe(_pwsh, " -c 'echo hello world!'"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FailIfStdOutDoesNotMatchTest()
        {
            Assert.False(
                GeneralUtilities.Probe(
                    _pwsh, " -c 'echo foo'",
                    criterion: (processExitInfo) =>
                    {
                        return processExitInfo.StdOut.Any(x => x.Contains("bar"));
                    }));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TrueIfStdOutDoesMatchTest()
        {
            Assert.True(
                GeneralUtilities.Probe(
                    _pwsh, " -c 'echo foo'",
                    criterion: (processExitInfo) =>
                    {
                        return processExitInfo.StdOut.Any(x => x.Contains("foo"));
                    }));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FailIfProcessTakesTooLongToRespondTest()
        {
            Assert.False(GeneralUtilities.Probe(_pwsh, "-c \"sleep 4\""));
        }
    }
}