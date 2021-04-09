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

/*
Prerequisites:
To develop automated tests for Source Control, you will need to create a private repo
in GitHub and two in Azure Repos (one for Git and one for TFVC). These will need to contain
at least one sample runbook to sync. For the current tests, I am using a PowerShell runbook.

After the repos are created, you will need to create a personal access token (PAT),
which will be used to register the source control. Please note that after the tests are recorded,
you should revoke access for PAT--this way no one can access to your private repos after the tests
are recorded. See example in SourceControlTests.ps1 where $testReposInfo is defined.
*/

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Automation.Test
{
    public class SourceControlTests : AutomationTestRunner
    {
        public SourceControlTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact(Skip = "Temporarily skipping, using just GitHub")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateVsoGitSourceControlAndSync()
        {
            TestRunner.RunTestScript("Test-CreateVsoGitSourceControlAndSync");
        }

        [Fact(Skip = "Tfvc not commonly used.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateVsoTfvcSourceControlAndSync()
        {
            TestRunner.RunTestScript("Test-CreateVsoTfvcSourceControlAndSync");
        }

        [Fact(Skip = "Temporarily skipping, running locally, PAT getting revoked after commiting")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateGitHubSourceControlAndSync()
        {
            TestRunner.RunTestScript("Test-CreateGitHubSourceControlAndSync");
        }
    }
}