using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;

using System;
using System.Collections.Generic;
using System.Text;

using Xunit;

namespace Microsoft.Azure.Commands.Resources.Test.UnitTests.Utilities
{
    public class TestBicepUtility
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestIsBicepFile()
        {
            Assert.True(BicepUtility.IsBicepFile("test.bicep"));
            Assert.False(BicepUtility.IsBicepFile("test.json"));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCheckBicepExecutable()
        {
            Assert.True(BicepUtility.CheckBicepExecutable(FakeTrueScriptExcutor<Object>));
            Assert.False(BicepUtility.CheckBicepExecutable(FakeFalseScriptExcutor<Object>));
        }

        private List<T> FakeTrueScriptExcutor<T>(string script)
        {
            return null;
        }

        private List<T> FakeFalseScriptExcutor<T>(string script)
        {
            throw new Exception("fake exception");
        }
    }
}
