# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# Azure Automation Source Control scenario tests
# This test suite contains 3 test cases. In each scenario, a source control is created,
# updated, retrieved and deleted. In addition to this, a sync is started for each source control
# and then the output streams are retrieved.
#
# Here is the sequence:
# 1) Create source control - validate properties
# 2) Update the newly created source control - validate that is was updated
# 3) Start a sync - validate that the sync completes 
# 4) Retrieve the streams for the completed source control sync job
# 5) Clean up - remove the source control

<# Prerequisites:

To develop automated tests for Source Control, you will need to create a private repo
in GitHub and two in Azure Repos (one for Git and one for TFVC). These will need to contain
at least one sample runbook to sync. For the current tests, I am using a PowerShell runbook.

After the repos are created, you will need to create a personal access token (PAT),
which will be used to register the source control. Please note that after the tests are recorded,
you should revoke access for PAT--this way no one can access to your private repos after the tests
are recorded.
#>

$testReposInfo = @{
    VsoGit = @{
        Name = "AASourceControl-VsoGit"
        RepoUrl = "https://francisco-gamino.visualstudio.com/_git/VsoGit-SwaggerAndCmdletsTests"
        Branch = "preview"
        FolderPath = "Azure/MyRunbooks"
        SourceType = "VsoGit"
        PersonalAccessToken = "REDACTED"
    }

    VsoTfvc =  @{
        Name = "AASourceControl-VsoTfvc"
        RepoUrl = "https://francisco-gamino.visualstudio.com/VsoTfvc-SwaggerAndCmdletsTests/_versionControl"
        FolderPath = "/MyRunbooks"
        SourceType = "VsoTfvc"
        PersonalAccessToken = "REDACTED"
    }

    GitHub = @{
        Name = "AASourceControl-GitHub"
        RepoUrl = "https://github.com/sharma224/SwaggerAndCmdletsTests.git"
        Branch = "ps"
        FolderPath = "/"
        SourceType = "GitHub"
        PersonalAccessToken = "REDACTED"
    }
}

# Automation account information
$resourceGroupName = "to-delete-01"
$automationAccountName = "fbs-aa-01"

#region Helper functions

# This function ensure that the given source control does not exist, 
# which implicitly validates Get-AzAutomationSourceControl and Remove-AzAutomationSourceControl
function EnsureSourceControlDoesNotExist
{
    Param 
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Name
    )

    $sourceControl = Get-AzAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                        -AutomationAccountName $automationAccountName `
                                                        -Name $Name `
                                                        -ErrorAction SilentlyContinue
    if ($sourceControl)
    {
        Remove-AzAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                              -AutomationAccountName $automationAccountName `
                                              -Name $Name
    }
}

function WaitForSourceControlSyncJobState
{
    Param 
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Name,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [Guid]
        $JobId,

        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedState
    )

    $waitTimeInSeconds = 5
    $retries = 40
    $jobCompleted = Retry-Function {
        return (Get-AzAutomationSourceControlSyncJob -ResourceGroupName $resourceGroupName `
                                                          -AutomationAccountName $automationAccountName  `
                                                          -Name $Name `
                                                          #-JobId $JobId `
                                                          ).ProvisioningState -eq $ExpectedState } $null $retries $waitTimeInSeconds

    Assert-True {$jobCompleted -gt 0} "Timeout waiting for provisioning state to reach '$ExpectedState'"
}

#endregion


function Test-CreateVsoGitSourceControlAndSync
{
    # VsoGit repo info
    $sourceControl = $testReposInfo["VsoGit"]

    try
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name

        # Access token
        $accessToken = ConvertTo-SecureString -String $sourceControl.PersonalAccessToken -AsPlainText -Force

        $createdSourceControl = New-AzAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                                   -AutomationAccountName $automationAccountName  `
                                                                   -Name $sourceControl.Name  `
                                                                   -RepoUrl $sourceControl.RepoUrl `
                                                                   -Branch $sourceControl.Branch `
                                                                   -SourceType $sourceControl.SourceType `
                                                                   -FolderPath $sourceControl.FolderPath `
                                                                   -AccessToken $accessToken `
                                                                   -DoNotPublishRunbook

        # Validate that the source control was created
        Assert-NotNull $createdSourceControl "Failed to create VsoGit source control."

        # Validate the source control properties
        $propertiesToValidate = @("Name", "RepoUrl", "SourceType", "Branch", "FolderPath")
        
        foreach ($property in $propertiesToValidate)
        {
            Assert-AreEqual $sourceControl.$property $createdSourceControl.$property `
                "'$property' of created source control does not match. Expected:$($sourceControl.$property). Actual: $($createdSourceControl.$property)"
        }

        # Enable PublishRunbook in the newly created source control 
        $updatedSourceControl = Update-AzAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                                      -AutomationAccountName $automationAccountName  `
                                                                      -Name $sourceControl.Name  `
                                                                      -PublishRunbook $true
        $expectedPropertyValue = "True"
        Assert-AreEqual $updatedSourceControl.PublishRunbook $expectedPropertyValue `
                "'PublishRunbook' property does not match. Expected: $expectedPropertyValue. Actual: $($updatedSourceControl.PublishRunbook)"
        
        # Start a sync for the source control
        $jobId = "0bfa6b49-c08c-4b2f-853e-08128c3c86ee"
        Start-AzAutomationSourceControlSyncJob -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName  `
                                            -Name $sourceControl.Name `
                                            -JobId $jobId

        WaitForSourceControlSyncJobState -Name $sourceControl.Name -JobId $jobId -ExpectedState Completed

        # Get the SourceControlSyncJob streams
        $streams =  Get-AzAutomationSourceControlSyncJobOutput -ResourceGroupName $resourceGroupName `
                                                                    -AutomationAccountName $automationAccountName  `
                                                                    -Name $sourceControl.Name `
                                                                    -JobId $jobId `
                                                                    -Stream Output | % Summary
        
        Assert-True {$streams.count -gt 0} "Failed to get Output stream via Get-AzAutomationSourceControlSyncJobOutput "
    }
    finally
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name
    }
}

function Test-CreateVsoTfvcSourceControlAndSync
{
    # VsoTfvc source control info
    $sourceControl = $testReposInfo["VsoTfvc"]

    try
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name

        # Access token
        $accessToken = ConvertTo-SecureString -String $sourceControl.PersonalAccessToken -AsPlainText -Force

        $createdSourceControl = New-AzAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                                   -AutomationAccountName $automationAccountName  `
                                                                   -Name  $sourceControl.Name  `
                                                                   -RepoUrl $sourceControl.RepoUrl `
                                                                   -SourceType $sourceControl.SourceType `
                                                                   -FolderPath  $sourceControl.FolderPath `
                                                                   -AccessToken $accessToken `
                                                                   -DoNotPublishRunbook

        # Validate that the source control was created
        Assert-NotNull $createdSourceControl "Failed to create VsoGit source control."

        # Validate the source control properties
        $propertiesToValidate = @("Name", "RepoUrl", "SourceType", "FolderPath")
        
        foreach ($property in $propertiesToValidate)
        {
            Assert-AreEqual $sourceControl.$property $createdSourceControl.$property `
                "'$property' of created source control does not match. Expected:$($sourceControl.$property) Actual: $($createdSourceControl.$property)"
        }

        # Enable PublishRunbook in the newly created source control 
        $updatedSourceControl = Update-AzAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                                      -AutomationAccountName $automationAccountName  `
                                                                      -Name $sourceControl.Name  `
                                                                      -PublishRunbook $true
        $expectedPropertyValue = "True"
        Assert-AreEqual $updatedSourceControl.PublishRunbook $expectedPropertyValue `
                "'PublishRunbook' property does not match. Expected: $expectedPropertyValue. Actual: $($updatedSourceControl.PublishRunbook)"
        
        # Start a sync for the source control
        $jobId = "27dcdb17-1f65-42e9-9eeb-088a5f50eeb8"
        Start-AzAutomationSourceControlSyncJob -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName  `
                                            -Name $sourceControl.Name `
                                            -JobId $jobId

        WaitForSourceControlSyncJobState -Name $sourceControl.Name -JobId $jobId -ExpectedState Completed

        # Get the SourceControlSyncJob streams
        $streams =  Get-AzAutomationSourceControlSyncJobOutput -ResourceGroupName $resourceGroupName `
                                                                    -AutomationAccountName $automationAccountName  `
                                                                    -Name $sourceControl.Name `
                                                                    -JobId $jobId `
                                                                    -Stream Output | % Summary
        
        Assert-True {$streams.count -gt 0} "Failed to get Output stream via Get-AzAutomationSourceControlSyncJobOutput "
    }
    finally
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name
    }
}

function Test-CreateGitHubSourceControlAndSync
{
    # GitHub repo info
    $sourceControl = $testReposInfo["GitHub"]

    try
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name

        # Access token
        $accessToken = ConvertTo-SecureString -String $sourceControl.PersonalAccessToken -AsPlainText -Force

        $createdSourceControl = New-AzAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                                   -AutomationAccountName $automationAccountName  `
                                                                   -Name $sourceControl.Name  `
                                                                   -RepoUrl $sourceControl.RepoUrl `
                                                                   -Branch $sourceControl.Branch `
                                                                   -SourceType $sourceControl.SourceType `
                                                                   -FolderPath $sourceControl.FolderPath `
                                                                   -AccessToken $accessToken `
                                                                   -DoNotPublishRunbook

        # Validate that the source control was created
        Assert-NotNull $createdSourceControl "Failed to create VsoGit source control."

        # Validate the source control properties
        $propertiesToValidate = @("Name", "RepoUrl", "SourceType", "Branch", "FolderPath")
        
        foreach ($property in $propertiesToValidate)
        {
            Assert-AreEqual $sourceControl.$property $createdSourceControl.$property `
                "'$property' of created source control does not match. Expected:$($sourceControl.$property) Actual: $($createdSourceControl.$property)"
        }

        # Enable PublishRunbook in the newly created source control 
        $updatedSourceControl = Update-AzAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                                      -AutomationAccountName $automationAccountName  `
                                                                      -Name $sourceControl.Name  `
                                                                      -PublishRunbook $true
        $expectedPropertyValue = "True"
        Assert-AreEqual $updatedSourceControl.PublishRunbook $expectedPropertyValue `
                "'PublishRunbook' property does not match. Expected: $expectedPropertyValue. Actual: $($updatedSourceControl.PublishRunbook)"
        
        # Start a sync for the source control
        $jobId = "ba7e6fcd-ea81-4adf-9bed-a38557110065"
        Start-AzAutomationSourceControlSyncJob -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName  `
                                            -Name $sourceControl.Name `
                                            #-JobId $jobId

        WaitForSourceControlSyncJobState -Name $sourceControl.Name -JobId $jobId -ExpectedState Completed

        # Get the SourceControlSyncJob streams
        <#
        $streams =  Get-AzAutomationSourceControlSyncJobOutput -ResourceGroupName $resourceGroupName `
                                                                    -AutomationAccountName $automationAccountName  `
                                                                    -Name $sourceControl.Name `
                                                                    -JobId $jobId `
                                                                    -Stream Output | % Summary
        
        Assert-True {$streams.count -gt 0} "Failed to get Output stream via Get-AzAutomationSourceControlSyncJobOutput "
        #>
    }
    finally
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name
    }
}