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
using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Commands.Profile.Test
{
    public class LongRunningCmdletTests : RMTestBase
    {
        const string Warning = "warning", Debug = "Debug", Verbose = "Verbose";
        static readonly ProgressRecord Progress = new ProgressRecord(0, "activity", "description");
        static readonly ErrorRecord Error = new ErrorRecord(new InvalidOperationException("invalid operation"), "12345", ErrorCategory.InvalidOperation, new object());
        static readonly object Output = new TestCmdletOutput();
        static readonly object lockObject = new object();

        ManualResetEvent jobCompleted = new ManualResetEvent(false);
        private XunitTracingInterceptor xunitLogger;

        public LongRunningCmdletTests(ITestOutputHelper output)
        {
            TestExecutionHelpers.SetUpSessionAndProfile();
            xunitLogger = new XunitTracingInterceptor(output);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanReceiveAllStreams()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(false, false, out mockRuntime);
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            WaitForCompletion(job, j =>
            {
                ValidateCompletedCmdlet(job);
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSupportShouldProcess()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(true, false, out mockRuntime);
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            WaitForCompletion(job, j =>
            {
                ValidateCompletedCmdlet(job);
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanSupportShouldContinue()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(true, true, out mockRuntime);
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            WaitForCompletion(job, j =>
            {
                ValidateCompletedCmdlet(job);
            });
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
            WaitForCompletion(job, j =>
            {
                Assert.Equal("Failed", job.StatusMessage);
                Assert.Equal(2, job.Error.Count);
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanHandleCmdletStop()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(true, true, out mockRuntime);
            cmdlet.Wait = true;
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            job.StateChanged += this.HandleStateChange;
            try
            {
                if (job.JobStateInfo.State != JobState.Completed)
                {
                    job.StopJob();
                    this.jobCompleted.WaitOne(TimeSpan.FromSeconds(10));
                    Assert.Equal("Stopped", job.StatusMessage);
                }

            }
            finally
            {
                job.StateChanged -= this.HandleStateChange;
            }
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanHandleShouldProcessExceptionForConfirm()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(true, false, out mockRuntime);
            cmdlet.MyInvocation.BoundParameters["Confirm"] = true;
            mockRuntime.Setup((r) => r.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Throws(new InvalidOperationException("Exception on ShouldProcess"));
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            WaitForCompletion(job, j =>
                {
                    Assert.Equal("Failed", job.StatusMessage);
                    Assert.True(j.Error.Count > 0 && j.Error.Any(e => e.Exception != null && e.Exception.GetType() == typeof(InvalidOperationException) && e.Exception.Message.Contains("Confirm")));
                });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanHandleShouldProcessExceptionForWhatIf()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(true, false, out mockRuntime);
            cmdlet.MyInvocation.BoundParameters["WhatIf"] = true;
            mockRuntime.Setup((r) => r.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Throws(new InvalidOperationException("Exception on ShouldProcess"));
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            WaitForCompletion(job, j =>

           {
               Assert.Equal("Failed", j.StatusMessage);
               Assert.True(j.Error.Count > 0 && j.Error.Any(e => e.Exception != null && e.Exception.GetType() == typeof(InvalidOperationException) && e.Exception.Message.Contains("WhatIf")));
           });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void CanHandleShouldContinueException()
        {
            Mock<ICommandRuntime> mockRuntime;
            var cmdlet = SetupCmdlet(true, true, out mockRuntime);
            mockRuntime.Setup((r) => r.ShouldContinue(It.IsAny<string>(), It.IsAny<string>())).Throws(new InvalidOperationException("Exception on ShouldContinue"));
            var job = cmdlet.ExecuteAsJob("Test Job") as AzureLongRunningJob<AzureStreamTestCmdlet>;
            WaitForCompletion(job, j =>
            {
                Assert.Equal("Failed", job.StatusMessage);
                Assert.True(j.Error.Count > 0 && j.Error.Any(e => e.Exception != null && e.Exception.GetType() == typeof(InvalidOperationException) && e.Exception.Message.Contains("Force")));
            });
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void JobCopiesCmdletParameterSet()
        {
            Mock<ICommandRuntime> mock = new Mock<ICommandRuntime>();
            var cmdlet = new AzureParameterSetCmdlet();
            cmdlet.SetParameterSet("ParameterSetIsSet");
            cmdlet.CommandRuntime = mock.Object;
            var job = cmdlet.ExecuteAsJob("Test parameter set job") as AzureLongRunningJob<AzureParameterSetCmdlet>;
            WaitForCompletion(job, j =>
            {
                Assert.Equal("Completed", j.StatusMessage);
                Assert.False(j.Error.Any());
            });
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

        public void HandleStateChange(object sender, JobStateEventArgs args)
        {
            lock (lockObject)
            {
                var job = sender as AzureLongRunningJob;
                xunitLogger.Information(string.Format("[statechangedhandler]: previous state: '{0}', current state: '{1}'", args.PreviousJobStateInfo?.State, args.JobStateInfo?.State));
                if (args.JobStateInfo.State == JobState.Completed || args.JobStateInfo.State == JobState.Failed || args.JobStateInfo.State == JobState.Stopped)
                {
                    this.jobCompleted.Set();
                }
                else
                {
                    if (args.JobStateInfo.State == JobState.Blocked)
                    {
                        if (job != null)
                        {
                            job.TryStart();
                        }

                    }
                }

            }

        }

        void WaitForCompletion(AzureLongRunningJob job, Action<AzureLongRunningJob> validate)
        {
            job.StateChanged += this.HandleStateChange;
            try
            {
                HandleStateChange(job, new JobStateEventArgs(job.JobStateInfo, new JobStateInfo(JobState.NotStarted)));
                this.jobCompleted.WaitOne(TimeSpan.FromSeconds(30));
                validate(job);
            }
            finally
            {
                job.StateChanged -= this.HandleStateChange;
               foreach (var message in job.Debug)
                {
                    xunitLogger.Information(message?.Message);
                }
            }

        }

        void ValidateCompletedCmdlet<T>(AzureLongRunningJob<T> job) where T : AzurePSCmdlet
        {
            Assert.Equal("Completed", job.StatusMessage);
            Assert.True(job.HasMoreData);
            Assert.True(job.Debug.Any(t => t.Message == Debug));
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

        [Cmdlet(VerbsDiagnostic.Test, "AzureJob",ConfirmImpact =ConfirmImpact.High)]
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
            public bool Wait { get; set; }

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

                if (Wait)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                }

                if (Fail)
                {
                    throw new InvalidOperationException("We Failed");
                }
            }

            static void WriteValues<T>(IEnumerable<T> collection, Action<T> writer)
            {
                foreach (var item in collection)
                {
                    writer(item);
                }
            }
        }

        public class AzureParameterSetCmdlet : AzurePSCmdlet
        {
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

            public override void ExecuteCmdlet()
            {
                if (String.IsNullOrEmpty(this.ParameterSetName))
                {
                    throw new InvalidOperationException("Parameter set must be set");
                }
            }

            protected override void InitializeQosEvent()
            {

            }
        }
    }
}
