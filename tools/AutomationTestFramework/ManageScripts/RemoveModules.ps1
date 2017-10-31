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

    Write-Verbose "Removing '$like' modules..."
    $moduleList = Get-AzureRmAutomationModule -AutomationAccountName  $automationAccountName -ResourceGroupName $resourceGroupName 
    $moduleList | Where-Object {
        $_.Name -like $like
    } | ForEach-Object {
        try {
            $mn = $_.Name
            $_ | Remove-AzureRmAutomationModule -Force -ErrorAction Stop
        } catch {
            if ($_.Exception.Message -like "*The account is unauthorized to create or update a global module*") {
                Write-Verbose "Module $mn can not be removed"
            } else {
                throw
            }
       }
    } 

   Write-Verbose "Done."
}