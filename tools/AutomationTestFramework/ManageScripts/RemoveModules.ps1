if (!$azureConfig) {
    . "$PSScriptRoot\AzureConfig.ps1"
}

<#
.SYNOPSIS
Removes modules from Azure Automation Account
.DESCRIPTION
Requests list of modules on Automation Account 
and removes only those whose names match pattern
.PARAMETER like
Pattern for module names to remove
.PARAMETER subscriptionName
subscription name of Azure Automation Account
.PARAMETER automationAccountName
Azure Automation Account name 
.PARAMETER resourceGroupName
Resource Group name of Azure Automation Account
.EXAMPLE
RemoveAutomationAccountModules -like "*AzureRm*"
#>
function RemoveAutomationAccountModules (
    [string] $like
   ,[string] $subscriptionName
   ,[string] $automationAccountName
   ,[string] $resourceGroupName) {
       
    $subscriptionName, $automationAccountName, $resourceGroupName = DefaultIfNotSpecifiedAA $subscriptionName $automationAccountName $resourceGroupName

    Write-Host "Removing '$like' modules..." -ForegroundColor Green
    $moduleList = Get-AzureRmAutomationModule -AutomationAccountName  $automationAccountName -ResourceGroupName $resourceGroupName 
    $moduleList | Where-Object {
        $_.Name -like $like
    } | ForEach-Object {
        try {
            $mn = $_.Name
            $_ | Remove-AzureRmAutomationModule -Force -ErrorAction Stop
        } catch {
            if ($_.Exception.Message -like "*The account is unauthorized to create or update a global module*") {
                Write-Host "Module $mn can not be removed"
            } else {
                throw
            }
       }
    } 

   Write-Host "Done." -ForegroundColor Green
}