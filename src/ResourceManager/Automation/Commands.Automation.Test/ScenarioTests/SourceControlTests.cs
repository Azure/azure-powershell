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
are recorded.

$testReposInfo = @{
    VsoGit = @{
        Name = "AASourceControl-VsoGit"
        RepoUrl = "https://francisco-gamino.visualstudio.com/_git/VsoGit-SwaggerAndCmdletsTests"
        Branch = "preview"
        FolderPath = "Azure/MyRunbooks"
        SourceType = "VsoGit"
        PersonalAccessToken = "3qdxa22lutnhezd4atpna74jn3m7wgo6o6kfbwezjfnvgbjhvoca"
    }

    VsoTfvc =  @{
        Name = "AASourceControl-VsoTfvc"
        RepoUrl = "https://francisco-gamino.visualstudio.com/VsoTfvc-SwaggerAndCmdletsTests/_versionControl"
        FolderPath = "/MyRunbooks"
        SourceType = "VsoTfvc"
        PersonalAccessToken = "3qdxa22lutnhezd4atpna74jn3m7wgo6o6kfbwezjfnvgbjhvoca"
    }

    GitHub = @{
        Name = "AASourceControl-GitHub"
        RepoUrl = "https://github.com/Francisco-Gamino/SwaggerAndCmdletsTests.git"
        Branch = "master"
        FolderPath = "/"
        SourceType = "GitHub"
        PersonalAccessToken = "5fd81166a9ebaebc60da4756f2094a598f1d4c01"
    }
}
 */

namespace Commands.Automation.Test
{
    using Microsoft.Azure.Commands.Automation.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.Azure.ServiceManagemenet.Common.Models;
    using Xunit;

    public class SourceControlTests : AutomationScenarioTestsBase
    {
        public XunitTracingInterceptor _logger;

        public SourceControlTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateVsoGitSourceControlAndSync()
        {
            RunPowerShellTest(_logger, "Test-CreateVsoGitSourceControlAndSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateVsoTfvcSourceControlAndSync()
        {
            RunPowerShellTest(_logger, "Test-CreateVsoTfvcSourceControlAndSync");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [Trait(Category.Service, Category.Automation)]
        public void CreateGitHubSourceControlAndSync()
        {
            RunPowerShellTest(_logger, "Test-CreateGitHubSourceControlAndSync");
        }
    }
}