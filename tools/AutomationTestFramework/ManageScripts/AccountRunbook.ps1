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

    Write-Host "Uploading '$bookName' runbook..." -ForegroundColor Green
    $null = Import-AzureRmAutomationRunbook -Path $path -Name $bookName -type PowerShell -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName -Force -ErrorAction Stop
    
    Write-Host "Publishing '$bookName' runbook..." -ForegroundColor Green
    $null = Publish-AzureRmAutomationRunbook -Name $bookName -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName -ErrorAction Stop
    
    Write-Host "Starting '$bookName' runbook..." -ForegroundColor Green
    $null = Start-AzureRmAutomationRunbook -Name $bookName -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName -ErrorAction Stop
}

#UploadRunbook $path "E:\OneDrive - Microsoft\Projects\PowerShell\AzureAutomation\AutomationTestAssets\RunBooks\LiveWebsitesTests.ps1" -name "LiveWebsitesTests"

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
        $filepath
        $bookName = $_.BaseName
        UploadPublishAndStartRunbook -path $filepath -bookName $bookName
    }
}

#UploadPublishAndStartRunbooks

<#
.SYNOPSIS
Removes all runbooks from Automation Account that match pattern
.PARAMETER like
Pattern
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

    Write-Host "Removing runbooks with name like '$like' from Automation Account..." -ForegroundColor Green

    $accountRunbooks = Get-AzureRmAutomationRunbook -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName 
    $accountRunbooks | Where-Object {
        $_.Name -like $like
    } | ForEach-Object {
        Remove-AzureRmAutomationRunbook -AutomationAccountName $automationAccountName -ResourceGroupName $resourceGroupName -Name $_.Name -Force
    }    
    
    Write-Host "Done." -ForegroundColor Green
}    
    


