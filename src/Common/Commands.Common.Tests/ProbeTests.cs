using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Linq;
using Xunit;

namespace Commands.Common.Tests
{
    public class ProbeTests
    {
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
            Assert.True(GeneralUtilities.Probe("powershell", " -c 'echo hello world!'"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FailIfStdOutDoesNotMatchTest()
        {
            Assert.False(
                GeneralUtilities.Probe(
                    "powershell", " -c 'echo foo'",
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
                    "powershell", " -c 'echo foo'",
                    criterion: (processExitInfo) =>
                    {
                        return processExitInfo.StdOut.Any(x => x.Contains("foo"));
                    }));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FailIfProcessTakesTooLongToRespondTest()
        {
            Assert.False(GeneralUtilities.Probe("powershell", "-c \"sleep 4\""));
        }
    }
}