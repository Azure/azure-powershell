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

# Automation account information
$resourceGroupName = "frangom-test"
$subscriptionId = "52d8cf1b-bcac-493a-bbae-f234b5ff38b0"
$automationAccountName = "frangom-sdkCmdlet-tests"

#region Helper functions

# This function ensure that the given source control does not exist, 
# which implicitly validates Get-AzureRmAutomationSourceControl and Remove-AzureRmAutomationSourceControl
function EnsureSourceControlDoesNotExist
{
    Param 
    (
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Name
    )

    $sourceControl = Get-AzureRmAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                        -AutomationAccountName $automationAccountName `
                                                        -Name $Name `
                                                        -ErrorAction SilentlyContinue
    if ($sourceControl)
    {
        Remove-AzureRmAutomationSourceControl -ResourceGroupName $resourceGroupName `
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

    $state = ""
    $waitTimeInSeconds = 5
    $retries = 20

    do
    {
        $syncJob = Get-AzureRmAutomationSourceControlSyncJob -ResourceGroupName $resourceGroupName `
                                                             -AutomationAccountName $automationAccountName  `
                                                             -Name $Name `
                                                             -JobId $JobId

        $state = $syncJob.ProvisioningState
        Write-Output "Source control sync job Provisioning state: $state"

        # Wait for 5 seconds and try again
        sleep -Seconds 5
        $retries--

    } while ($state -ne $ExpectedState -and $retries -gt 0) 

    Assert-True {$retries -gt 0} "Timeout waiting for provisioning state to reach '$ExpectedState'"
}

#endregion


function Test-CreateVsoGitSourceControlAndSync
{
    # VsoGit repo info
    $sourceControl = @{
        Name = "AASourceControl-VsoGit"
        RepoUrl = "https://francisco-gamino.visualstudio.com/_git/VsoGit-SwaggerAndCmdletsTests"
        Branch = "preview"
        FolderPath = "Azure/MyRunbooks"
        SourceType = "VsoGit"
    }

    try
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name

        # Access token
        $token = "3qdxa22lutnhezd4atpna74jn3m7wgo6o6kfbwezjfnvgbjhvoca"
        $accessToken = ConvertTo-SecureString -String $token -AsPlainText -Force

        $createdSourceControl = New-AzureRmAutomationSourceControl -ResourceGroupName $resourceGroupName `
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
        $updatedSourceControl = Update-AzureRmAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                                      -AutomationAccountName $automationAccountName  `
                                                                      -Name $sourceControl.Name  `
                                                                      -PublishRunbook $true
        $expectedPropertyValue = "True"
        Assert-AreEqual $updatedSourceControl.PublishRunbook $expectedPropertyValue `
                "'PublishRunbook' property does not match. Expected: $expectedPropertyValue. Actual: $($updatedSourceControl.PublishRunbook)"
        
        # Start a sync for the source control
        $jobId = "0bfa6b49-c08c-4b2f-853e-08128c3c86ee"
        Start-AzureRmAutomationSourceControlSyncJob -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName  `
                                            -Name $sourceControl.Name `
                                            -JobId $jobId

        WaitForSourceControlSyncJobState -Name $sourceControl.Name -JobId $jobId -ExpectedState Completed

        # Get the SourceControlSyncJob streams
        $streams =  Get-AzureRmAutomationSourceControlSyncJobOutput -ResourceGroupName $resourceGroupName `
                                                                    -AutomationAccountName $automationAccountName  `
                                                                    -Name $sourceControl.Name `
                                                                    -JobId $jobId `
                                                                    -Stream Output | % Summary
        
        Assert-True {$streams.count -gt 0} "Failed to get Output stream via Get-AzureRmAutomationSourceControlSyncJobOutput "
    }
    finally
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name
    }
}

function Test-CreateVsoTfvcSourceControlAndSync
{
    # VsoTfvc source control info
    $sourceControl = @{
        Name = "AASourceControl-VsoTfvc"
        RepoUrl = "https://francisco-gamino.visualstudio.com/VsoTfvc-SwaggerAndCmdletsTests/_versionControl"
        FolderPath = "/MyRunbooks"
        SourceType = "VsoTfvc"
    }

    try
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name

        # Access token
        $token = "3qdxa22lutnhezd4atpna74jn3m7wgo6o6kfbwezjfnvgbjhvoca"
        $accessToken = ConvertTo-SecureString -String $token -AsPlainText -Force

        $createdSourceControl = New-AzureRmAutomationSourceControl -ResourceGroupName $resourceGroupName `
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
        $updatedSourceControl = Update-AzureRmAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                                      -AutomationAccountName $automationAccountName  `
                                                                      -Name $sourceControl.Name  `
                                                                      -PublishRunbook $true
        $expectedPropertyValue = "True"
        Assert-AreEqual $updatedSourceControl.PublishRunbook $expectedPropertyValue `
                "'PublishRunbook' property does not match. Expected: $expectedPropertyValue. Actual: $($updatedSourceControl.PublishRunbook)"
        
        # Start a sync for the source control
        $jobId = "27dcdb17-1f65-42e9-9eeb-088a5f50eeb8"
        Start-AzureRmAutomationSourceControlSyncJob -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName  `
                                            -Name $sourceControl.Name `
                                            -JobId $jobId

        WaitForSourceControlSyncJobState -Name $sourceControl.Name -JobId $jobId -ExpectedState Completed

        # Get the SourceControlSyncJob streams
        $streams =  Get-AzureRmAutomationSourceControlSyncJobOutput -ResourceGroupName $resourceGroupName `
                                                                    -AutomationAccountName $automationAccountName  `
                                                                    -Name $sourceControl.Name `
                                                                    -JobId $jobId `
                                                                    -Stream Output | % Summary
        
        Assert-True {$streams.count -gt 0} "Failed to get Output stream via Get-AzureRmAutomationSourceControlSyncJobOutput "
    }
    finally
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name
    }
}

function Test-CreateGitHubSourceControlAndSync
{
    # GitHub repo info
    $sourceControl = @{
        Name = "AASourceControl-GitHub"
        RepoUrl = "https://github.com/Francisco-Gamino/SwaggerAndCmdletsTests.git"
        Branch = "master"
        FolderPath = "/"
        SourceType = "GitHub"
    }

    try
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name

        # Access token
        $token = "5fd81166a9ebaebc60da4756f2094a598f1d4c01"
        $accessToken = ConvertTo-SecureString -String $token -AsPlainText -Force

        $createdSourceControl = New-AzureRmAutomationSourceControl -ResourceGroupName $resourceGroupName `
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
        $updatedSourceControl = Update-AzureRmAutomationSourceControl -ResourceGroupName $resourceGroupName `
                                                                      -AutomationAccountName $automationAccountName  `
                                                                      -Name $sourceControl.Name  `
                                                                      -PublishRunbook $true
        $expectedPropertyValue = "True"
        Assert-AreEqual $updatedSourceControl.PublishRunbook $expectedPropertyValue `
                "'PublishRunbook' property does not match. Expected: $expectedPropertyValue. Actual: $($updatedSourceControl.PublishRunbook)"
        
        # Start a sync for the source control
        $jobId = "f7dd56e6-0da3-442a-b1c5-3027065c7786"
        Start-AzureRmAutomationSourceControlSyncJob -ResourceGroupName $resourceGroupName `
                                            -AutomationAccountName $automationAccountName  `
                                            -Name $sourceControl.Name `
                                            -JobId $jobId

        WaitForSourceControlSyncJobState -Name $sourceControl.Name -JobId $jobId -ExpectedState Completed

        # Get the SourceControlSyncJob streams
        $streams =  Get-AzureRmAutomationSourceControlSyncJobOutput -ResourceGroupName $resourceGroupName `
                                                                    -AutomationAccountName $automationAccountName  `
                                                                    -Name $sourceControl.Name `
                                                                    -JobId $jobId `
                                                                    -Stream Output | % Summary
        
        Assert-True {$streams.count -gt 0} "Failed to get Output stream via Get-AzureRmAutomationSourceControlSyncJobOutput "
    }
    finally
    {
        EnsureSourceControlDoesNotExist -Name $sourceControl.Name
    }
}