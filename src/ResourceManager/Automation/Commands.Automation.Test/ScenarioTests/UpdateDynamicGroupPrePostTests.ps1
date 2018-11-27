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

$rg = "mo-resources-eus"
$aa = "mo-aaa-eus2"
$azureVMIdsW = @(
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-w-01",
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-w-02"
    )

$azureVMIdsL = @(
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-l-01",
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-l-02"
    )

$nonAzurecomputers = @("server-01", "server-02")

<#
WaitForProvisioningState
#>
function WaitForProvisioningState() {
    param([string] $Name, [string] $ExpectedState)
    $state = ""
    $timeoutInSeconds = 120
    $retries = $timeoutInSeconds / 5
    while($state -ne $ExpectedState -and $retries -gt 0) {
        $suc = Get-AzureRmAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $Name
        $state = $suc.ProvisioningState
        Write-Output "SoftwareUpdateConfiguration Provisioning state: $state"
        sleep -Seconds 5
        $retries = $retries - 1
    } 

    Assert-True {$retries -gt 0} "Timout waiting for provisioning state to reach '$ExpectedState'"
}


 function Test-CreateAndGetSoftwareUpdateConfigurationWithPrePost
{
    $name = "DG-suc-03"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    $params =  New-Object 'system.collections.generic.dictionary[string, string]'
    $params.Add("param1",  "we made it!")

    $preTask = @{
        source = "preTask"
    }

    $postTask = @{
        source = "postTask";
        parameters = $params
    }

    $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -AzureVMResourceId $azureVMIdsL `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -IncludedUpdateClassification Security,Critical `
                                                             -PreTask $preTask `
                                                             -PostTask $postTask `
                                                             -RebootSetting "Never"


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzureRmAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name

    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $sucGet.Tasks "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $sucGet.Tasks.PreTask "PreTask is null"
    Assert-NotNull $sucGet.Tasks.PostTask "PostTask is null"
    Assert-AreEqual $sucGet.Tasks.PostTask.source "postTask" "Post task didn't have the correct name"
    Assert-AreEqual $sucGet.Tasks.PostTask.parameters.Count 1 "Post task didn't have the correct number of parameters"
    Assert-AreEqual $sucGet.Tasks.PreTask.source "preTask" "Pre task didn't have the correct name"
    Assert-AreEqual $sucGet.UpdateConfiguration.Windows.RebootSetting "Never" "Reboot setting is not set to Never"
}

function Test-GetSoftwareUpdateConfigurationRunWithPrePost
{
    $sucName = 'prePostTest'
    $sucrId = 'c7040393-1451-4be7-9ed1-999aa747a155'

    $sucr = Get-AzureRMAutomationSoftwareUpdateRun  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Id $sucrId


    Assert-NotNull $sucr "Get-SoftwareUpdateConfigurationRun returned null"
    Assert-AreEqual $sucr.SoftwareUpdateConfigurationName $sucName "Name of created software update configuration run didn't match given name"

    Assert-NotNull $sucr.Tasks.PreTask "PreTask is null"
    Assert-NotNull $sucr.Tasks.PostTask "PostTask is null"
    Assert-NotNull $sucr.Tasks.PreTask.JobId "PreTask jobId is null"
    Assert-NotNull $sucr.Tasks.PostTask.JobId "PostTask jobId is null"
    Assert-AreEqual $sucr.Tasks.PostTask.source "postTask" "Post task didn't have the correct source name"
    Assert-AreEqual $sucr.Tasks.PostTask.Status "Completed" "Post task didn't have the correct status"
    Assert-AreEqual $sucr.Tasks.PreTask.source "preTask" "Pre task didn't have the correct source name"
    Assert-AreEqual $sucr.Tasks.PreTask.Status "Completed" "Pre task didn't have the correct status"
}

<#
.SYNOPSIS
Tests create new automation variable with string value.
#>
function Test-CreateAndGetSoftwareUpdateConfigurationWithDynamicGroups
{
    $name = "DG-suc-04"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzureRmAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate
    
    $query1Scope = @(
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-l-01",
        "/subscriptions/422b6c61-95b0-4213-b3be-7282315df71d/resourceGroups/mo-compute/providers/Microsoft.Compute/virtualMachines/mo-vm-l-02"
    )

    $query1Location =@("Japan East", "UK South")

    $query1Tags = New-Object 'system.collections.generic.dictionary[string, system.Collections.Generic.List[String]]'
    $query1Tags.Add("tag1",  @("tag1Value1", "tag1Value2"))
    $query1Tags.Add("tag2", @("tag2Value1", "tag2Value2"))
    $query1FilterOperator = "All"

    $AzureQuery1 = @{"Scope" = $query1Scope;
                      "Locations" = $query1Location;
                            "TagSettings" = @{"Tags" = $query1Tags;
                                                 "FilterOperator" = $query1FilterOperator}}
   $AzureQueries = @($AzureQuery1)

    $suc = New-AzureRmAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -AzureVMResourceId $azureVMIdsL `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -AzureQueries $AzureQueries `
                                                             -IncludedUpdateClassification Security,Critical 


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzureRmAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name
  
    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $sucGet.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets "Update targets object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets.AzureQueries "Update targets  azureQueries list  null"
    Assert-AreEqual $sucGet.UpdateConfiguration.Targets.AzureQueries.Count  1 "Update targets  doesn't have the correct number of azure queries"
   
 }