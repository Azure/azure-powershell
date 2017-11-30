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

using Microsoft.Azure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.Internal.Resources.Utilities;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading;
using Xunit;

namespace Microsoft.Azure.Commands.Profile.Test
{ 
    public class LongRunningCmdletTests : RMTestBase
    {
        const string Warning = "warning", Debug = "Debug", Verbose = "Verbose";
        static readonly ProgressRecord Progress = new ProgressRecord(0, "activity", "description");
        static readonly ErrorRecord Error = new ErrorRecord(new InvalidOperationException("invalid operation"), "12345", ErrorCategory.InvalidOperation, new object());
        static readonly object Output = new TestCmdletOutput();

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanReceiveAllStreams()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(false, false, out mockRuntime);
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            int times = 0;
            while (times++ < 4 && job.StatusMessage != "Completed")
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            ValidateCompletedCmdlet(job);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSupportShouldProcess()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(true, false, out mockRuntime);
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            int times = 0;
            while (times++ < 4 && job.StatusMessage != "Completed")
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            ValidateCompletedCmdlet(job);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSupportShouldContinue()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(true, true, out mockRuntime);
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            int times = 0;
            while (times++ < 4 && job.StatusMessage != "Completed")
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (job.StatusMessage == "Blocked")
                {
                    job.Start();
                }
            }

            ValidateCompletedCmdlet(job);
            mockRuntime.Verify(m => m.ShouldContinue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanHandleCmdletException()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(false, false, out mockRuntime);
            cmdlet.Fail = true;
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            int times = 0;
            while (times++ < 4 && job.StatusMessage != "Completed" && job.StatusMessage != "Failed")
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            Assert.Equal("Failed", job.StatusMessage);
            Assert.Equal(2, job.Error.Count);
        }

        AzureStreamTestCmdlet SetupCmdlet(bool CallShouldProcess, bool CallShouldContinue, out Mock<ICommandRuntime> mockRuntime)
        {
            var cmdlet = new AzureStreamTestCmdlet();
            cmdlet.Warning.Add(Warning);
            cmdlet.Debug.Add(Debug);
            cmdlet.Verbose.Add(Verbose);
            cmdlet.Progress.Add(Progress);
            cmdlet.Output.Add(Output);
            cmdlet.Error.Add(Error);
            mockRuntime = new Mock<ICommandRuntime>();
            if (CallShouldProcess || CallShouldContinue)
            {
                cmdlet.CallShouldProcess = true;
                mockRuntime.Setup(m => m.ShouldProcess(It.IsAny<string>())).Returns(true);
                mockRuntime.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
                mockRuntime.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            }
            else
            {
                mockRuntime.Setup(m => m.ShouldProcess(It.IsAny<string>())).Throws(new InvalidOperationException("ShouldProcess should not be called"));
                mockRuntime.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Throws(new InvalidOperationException("ShouldProcess should not be called"));
                mockRuntime.Setup(m => m.ShouldProcess(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Throws(new InvalidOperationException("ShouldProcess should not be called"));
            }

            if (CallShouldContinue)
            {
                cmdlet.CallShouldContinue = true;
                mockRuntime.Setup(m => m.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            }
            else
            {
                mockRuntime.Setup(m => m.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Throws(new InvalidOperationException("ShouldContinue should not be called"));
            }

            cmdlet.CommandRuntime = mockRuntime.Object;

            return cmdlet;
        }

        void ValidateCompletedCmdlet<T>(AzureLongRunningJob<T> job) where T : AzurePSCmdlet
        {
            Assert.Equal("Completed", job.StatusMessage);
            Assert.True(job.HasMoreData);
            Assert.Collection(job.Debug, t => Assert.Equal(Debug, t.Message));
            Assert.Collection(job.Warning, t => Assert.Equal(Warning, t.Message));
            Assert.Collection(job.Verbose, t => Assert.Equal(Verbose, t.Message));
            Assert.Collection(job.Progress, t => Assert.Equal(Progress, t));
            Assert.Collection(job.Output, t => Assert.Equal(Output, t.BaseObject));
            Assert.Collection(job.Error, t => Assert.Equal(Error, t));
        }

        public class TestCmdletOutput
        {
            public string Property { get { return "PropertyValue"; } }
        }

        public class AzureStreamTestCmdlet : AzurePSCmdlet
        {
            public IList<ErrorRecord> Error { get; set; } = new List<ErrorRecord>();
            public IList<ProgressRecord> Progress { get; set; } = new List<ProgressRecord>();
            public IList<string> Verbose { get; set; } = new List<string>();
            public IList<string> Warning { get; set; } = new List<string>();
            public IList<string> Debug { get; set; } = new List<string>();
            public bool CallShouldProcess { get; set; }
            public bool CallShouldContinue { get; set; }
            public bool Fail { get; set; }

            public IList<object> Output { get; set; } = new List<object>();
            protected override string DataCollectionWarning
            {
                get
                {
                    return "";
                }
            }

            protected override IAzureContext DefaultContext
            {
                get
                {
                    return null;
                }
            }

            protected override void InitializeQosEvent()
            {
               
            }

            public override void ExecuteCmdlet()
            {
                if (!CallShouldProcess || ShouldProcess("target", "action"))
                {
                    if (!CallShouldContinue || ShouldContinue("query", "caption"))
                    {
                        WriteValues(Verbose, WriteVerbose);
                        WriteValues(Warning, WriteWarning);
                        WriteValues(Progress, WriteProgress);
                        WriteValues(Debug, WriteDebug);
                        WriteValues(Output, WriteObject);
                        WriteValues(Error, WriteError);
                    }
                }

                if (Fail)
                {
                    throw new InvalidOperationException("We Failed");
                }
            }

            static void WriteValues<T>(IEnumerable<T> collection, Action<T> writer)
            {
                foreach(var item in collection)
                {
                    writer(item);
                }
            }
        }
    }
}
