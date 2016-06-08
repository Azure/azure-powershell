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
using System.ComponentModel;
using Microsoft.WindowsAzure.Commands.Websites.WebJobs;
using Microsoft.WindowsAzure.WebSitesExtensions.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.WindowsAzure.Commands.Test.Websites
{
    public class WebJobWrapperTest
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReadProperties_ValuesAreSameWiththeInternalWebJobInstance()
        {
            //Set up
            TriggeredWebJobRun jobRun = new TriggeredWebJobRun();
            TriggeredWebJob webJob = new TriggeredWebJob()
            {
                ExtraInfoUrl = "an extra info url",
                HistoryUrl = "a history url",
                LatestRun = jobRun,
                Name = "my web job name",
                Type = WebJobType.Triggered,
                RunCommand = "my run command",
                Url = new System.Uri("http://myWebJobUrl")
            };

            // Test
            PSTriggeredWebJob wrapper = new PSTriggeredWebJob(webJob);

            // Assert
            Assert.Equal(webJob.ExtraInfoUrl, wrapper.ExtraInfoUrl);
            Assert.Equal(webJob.HistoryUrl, wrapper.HistoryUrl);
            Assert.Equal(new PSTriggeredWebJobRun(webJob.LatestRun).ToString(), wrapper.LatestRun.ToString());
            Assert.Equal(webJob.Name, wrapper.JobName);
            Assert.Equal(webJob.RunCommand, wrapper.RunCommand);
            Assert.Equal(webJob.Type, wrapper.JobType);
            Assert.Equal(webJob.Url, wrapper.Url);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void WriteProperties_InternalWebJobInstanceIsUpdated()
        {
            //Set up
            TriggeredWebJobRun jobRun = new TriggeredWebJobRun();
            TriggeredWebJob webJob = new TriggeredWebJob()
            {
                Type = WebJobType.Triggered,
            };

            string jobName = "My Job Name";
            WebJobType jobType = WebJobType.Triggered;
            string extraInfoUrl = "an extra info url";
            string historyUrl = "a history url";
            TriggeredWebJobRun latestRun = new TriggeredWebJobRun();
            string runCommand = "my run command";
            Uri url = new System.Uri("http://myWebJobUrl");

            // Test
            PSTriggeredWebJob wrapper = new PSTriggeredWebJob(webJob);
            wrapper.JobType = jobType;
            wrapper.JobName = jobName;
            wrapper.ExtraInfoUrl = extraInfoUrl;
            wrapper.HistoryUrl = historyUrl;
            wrapper.LatestRun = latestRun;
            wrapper.RunCommand = runCommand;
            wrapper.Url = url;

            // Assert
            Assert.Equal(jobName, wrapper.JobName);
            Assert.Equal(jobType, wrapper.JobType);
            Assert.Equal(extraInfoUrl, wrapper.ExtraInfoUrl);
            Assert.Equal(historyUrl, wrapper.HistoryUrl);
            Assert.Equal(new PSTriggeredWebJobRun(latestRun).ToString(), wrapper.LatestRun.ToString());
            Assert.Equal(runCommand, wrapper.RunCommand);
            Assert.Equal(url, wrapper.Url);
            Assert.Equal(jobName, webJob.Name);
            Assert.Equal(jobType, webJob.Type);
            Assert.Equal(extraInfoUrl, webJob.ExtraInfoUrl);
            Assert.Equal(historyUrl, webJob.HistoryUrl);
            Assert.Equal(latestRun, webJob.LatestRun);
            Assert.Equal(runCommand, webJob.RunCommand);
            Assert.Equal(url, webJob.Url);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SamePropertyNumberWithTriggeredWebJobModelClass()
        {
            // Setup & Test
            int webJobPropertyNumber = TypeDescriptor.GetProperties(typeof(TriggeredWebJob)).Count - 1; // Ignore the error property
            int webJobWrapperPropertyNumber = TypeDescriptor.GetProperties(typeof(PSTriggeredWebJob)).Count;

            // Assert
            Assert.Equal(webJobPropertyNumber, webJobWrapperPropertyNumber);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SamePropertyNumberWithContinuousWebJobModelClass()
        {
            // Setup & Test
            int webJobPropertyNumber = TypeDescriptor.GetProperties(typeof(ContinuousWebJob)).Count - 1; // Ignore the error property
            int webJobWrapperPropertyNumber = TypeDescriptor.GetProperties(typeof(PSContinuousWebJob)).Count;

            // Assert
            Assert.Equal(webJobPropertyNumber, webJobWrapperPropertyNumber);
        }
    }
}
