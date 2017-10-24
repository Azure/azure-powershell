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

if (!$azureConfig) {
    . "$PSScriptRoot\AzureConfig.ps1"
}

<#
.SYNOPSIS
Upload, publish and start runbook
.PARAMETER path
Path to the directory where runbook is located
.PARAMETER bookName
Name of the runbook
.PARAMETER subscriptionName
Automation Account subscription name
.PARAMETER automationAccountName
Automaition account name
.PARAMETER resourceGroupName
Automation Account resource group name
#>
function UploadPublishAndStartRunbook (
     [string] $path
    ,[string] $bookName   
    ,[string] $subscriptionName
    ,[string] $automationAccountName
    ,[string] $resourceGroupName) {

    $subscriptionName, $automationAccountName, $resourceGroupName = DefaultIfNotSpecifiedAA $subscriptionName $automationAccountName $resourceGroupName

    Write-Verbose "Uploading '$bookName' runbook..."
    $null = Import-AzureRmAutomationRunbook -Path $path -Name $bookName -type PowerShell -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName -Force -ErrorAction Stop
    
    Write-Verbose "Publishing '$bookName' runbook..."
    $null = Publish-AzureRmAutomationRunbook -Name $bookName -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName -ErrorAction Stop
    
    # to save result streams in Azure Storage Account Container
    $runbookParams = @{
        subscriptionName        = $subscriptionName; 
        automationAccountName   = $automationAccountName; 
        aaResourseGroupName     = $resourceGroupName;
        storageAccountName      =  $azureConfig.Get_Item("saName");
        saResourseGroupName     = $azureConfig.Get_Item("saResourceGroupName");
        containerName           = 'testreports';
        reportFolderPrefix      = $bookName
    }

    Write-Verbose "Starting '$bookName' runbook..."
    $null = Start-AzureRmAutomationRunbook -Name $bookName -Parameters $runbookParams -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName -ErrorAction Stop
}

<#
.SYNOPSIS
Upload, publish and start all runbooks in the $path directory
.PARAMETER path
Path to the directory where runbooks are located
if not specifien, default value is '..\Runbooks'
.EXAMPLE
UploadPublishAndStartRunbooks -path "d:\tmp\RunBooks\"
#>
function UploadPublishAndStartRunbooks ([string] $path ) {

    if ([string]::IsNullOrEmpty($path)) {
        $path = Join-Path "$PSScriptRoot\..\" "RunBooks"
    }

    Get-ChildItem $path | ForEach-Object {
        $filepath = Join-Path $path $_
        #$filepath
        $bookName = $_.BaseName
        UploadPublishAndStartRunbook -path $filepath -bookName $bookName
    }
}

<#
.SYNOPSIS
Removes all runbooks from Automation Account that match pattern
.PARAMETER like
Pattern to use with -like operator to remove runbooks. Sample pattern for generated runbooks is 'Live*Tests'. 
.PARAMETER subscriptionName
Automation Account subscription name
.PARAMETER automationAccountName
Automaition account name
.PARAMETER resourceGroupName
Automation Account resource group name
#>
function RemoveRunbookFromAutomationAccount (
     [string] $like   
    ,[string] $subscriptionName
    ,[string] $automationAccountName
    ,[string] $resourceGroupName) {

    $subscriptionName, $automationAccountName, $resourceGroupName = DefaultIfNotSpecifiedAA $subscriptionName $automationAccountName $resourceGroupName

    Write-Verbose "Removing runbooks with name like '$like' from Automation Account..."

    $accountRunbooks = Get-AzureRmAutomationRunbook -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName 
    $accountRunbooks | Where-Object {
        $_.Name -like $like
    } | ForEach-Object {
        Remove-AzureRmAutomationRunbook -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName -Name $_.Name -Force
    }    
    
    Write-Verbose "Done."
}