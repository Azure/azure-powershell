using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.OperationalInsights.Test.ScenarioTests
{
    public class TableTests : OperationalInsightsScenarioTestBase
    {
        public XunitTracingInterceptor _logger;

        public TableTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestTableCRUD()
        {
            RunPowerShellTest(_logger, "Test-TableCRUD");
        }
    }
}
