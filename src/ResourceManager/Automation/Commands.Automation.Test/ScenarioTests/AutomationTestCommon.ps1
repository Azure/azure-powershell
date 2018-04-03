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

<#
.SYNOPSIS
Create Automation account and return the account
#>
function CreateAutomationAccount
{
	$resourceGroupName = Get-RandomResourceGroupName
	$location = Get-AutomationAccountTestLocation
	$automationAccountName = Get-RandomAutomationAccountName
    
    $resourceGroupCreated = New-AzureRMResourceGroup -Name $resourceGroupName -Location $location
	$automationAccountCreated = New-AzureRmAutomationAccount -ResourceGroupName $resourceGroupName `
	                                                          -Location $location `
															  -Name $automationAccountName `
															  -Plan Basic

	return $automationAccountCreated
}

 function CreateAutomationAccountAndConnectionAsset
 {
    param([string] $connectionAssetName)

 	$automationAccount = CreateAutomationAccount
	$resourceGroupName = $automationAccount.ResourceGroupName
	$automationAccountName = $automationAccount.AutomationAccountName
    
	$connectionTypeName = "AzureServicePrincipal"
	$applicationId = "applicationIdString"
	$tenantId = "tenantIdString"
	$thumbprint  = "thumbprintIdString"
	$subscriptionId  = "subscriptionIdString"
	$connectionFieldValues = @{"ApplicationId" = $applicationId; `
	                           "TenantId" = $tenantId; `
							   "CertificateThumbprint" = $thumbprint; `
							   "SubscriptionId" = $subscriptionId}

	$connectionAssetCreated = New-AzureRmAutomationConnection -ResourceGroupName $resourceGroupName `
	                                                          -AutomationAccountName $automationAccountName `
															  -Name $connectionAssetName `
															  -ConnectionTypeName $connectionTypeName `
															  -ConnectionFieldValues $connectionFieldValues

	return $connectionAssetCreated
 }

<#
.SYNOPSIS
Imports a new runbook 
#>
function CreateRunbook
{
    param([string] $runbookPath, [boolean] $byName=$false, [string[]] $tag, [string] $description)

	$automationAccount = CreateAutomationAccount
	$resourceGroupName = $automationAccount.ResourceGroupName
	$automationAccountName = $automationAccount.AutomationAccountName

    $runbookName = gci $runbookPath | %{$_.BaseName}

    if(!$byName)
    {
        return Import-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
		                                       -AutomationAccountName $automationAccountName `
											   -Path $runbookPath `
											   -Type PowerShell `
											   -Tag $tag `
											   -Description $description
    }
    else 
    {
        return New-AzureRmAutomationRunbook -ResourceGroupName $resourceGroupName `
		                                    -AutomationAccountName $automationAccountName `
									        -Name $runbookName `
											-Type PowerShell `
											-Tag $tag `
											-Description $description
    }
}

<#
.SYNOPSIS
Waits for Job to be a specific status for approximately $numOfSeconds
#>
function WaitForJobStatus
{
    param([String] $resourceGroupName, [String] $automationAccountName, [Guid] $Id, [Int] $numOfSeconds = 150, [String] $Status)
    
    $timeElapse = 0
    $interval = 3
    $endStatus = @('completed','failed')
    while($timeElapse -lt $numOfSeconds)
    {
        Wait-Seconds $interval
        $timeElapse = $timeElapse + $interval
        $job = Get-AzureRmAutomationJob -ResourceGroupName $resourceGroupName `
		                                -AutomationAccountName $automationAccountName -Id $Id
        if($job.Status -eq $Status)
        {
            break
        }
        elseif($endStatus -contains $job.Status.ToLower())
        {	    
            Write-Output ("The Job with ID $($job.JobId) reached $($job.Status) Status already.")
            return
        }
    }
    Assert-AreEqual $Status $job.Status "Job did not reach $Status status within $numOfSeconds seconds.";
}
