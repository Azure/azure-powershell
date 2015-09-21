// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.Insights.Metrics;
using Microsoft.Azure.Insights.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Insights.Test.Metrics
{
    public class FormatMetricsAsTableCommandTests
    {
        private readonly FormatMetricsAsTableCommand cmdlet;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public FormatMetricsAsTableCommandTests()
        {
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new FormatMetricsAsTableCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void FormatMetricsAsTableCommandParametersProcessing()
        {
            // Null parameter
            var result = cmdlet.ProcessParameter();
            Assert.True(result != null, "Non-null expected");
            Assert.True(result.Length == 0, "0 length expected");

            // Empty parameter
            cmdlet.Metrics = new Metric[] {};
            result = cmdlet.ProcessParameter();
            Assert.True(result != null, "Non-null expected");
            Assert.True(result.Length == 0, "0 length expected");

            // Non empty parameter
            DateTime timeStamp = DateTime.Parse("2015/03/01 01:30:00");
            DateTime endTime = DateTime.Parse("2015/03/01 02:00:00");
            DateTime startTime = DateTime.Parse("2015/03/01 00:00:00");
            TimeSpan timeGrain = TimeSpan.FromMinutes(1);

            cmdlet.Metrics = new Metric[]
            {
                new Metric()
                {
                    EndTime = endTime,
                    Name = new LocalizableString() { Value = "metric1", LocalizedValue = "metric1" },
                    MetricValues = new MetricValue[]
                    {
                        new MetricValue()
                        {
                            Count  = 1,
                            Timestamp = timeStamp,
                        },
                    },
                    Properties = new Dictionary<string, string>(),
                    ResourceId = "\\resourceid\\",
                    StartTime = startTime,
                    TimeGrain = timeGrain,
                    Unit = Unit.Count,
                }
            };
            result = cmdlet.ProcessParameter();
            Assert.True(result != null, "Non-null expected");
            Assert.True(result.Length == 1, "length = 1 expected");
            Assert.Equal("metric1", result[0].Name);
            Assert.Equal("\\resourceid\\", result[0].ResourceId);
            Assert.Equal(1, result[0].Count);
            Assert.Equal(timeStamp.ToUniversalTime().ToString("u"), result[0].TimestampUTC);
            Assert.Equal(endTime.ToUniversalTime().ToString("u"), result[0].EndTimeUTC);
            Assert.Equal(startTime.ToUniversalTime().ToString("u"), result[0].StartTimeUTC);
            Assert.Equal(timeGrain, result[0].TimeGrain);
            Assert.Equal(Unit.Count, result[0].Unit);
        }
    }
}
