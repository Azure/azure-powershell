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


#Pre-requisite for rerecording these Tests
# 1. need to have automation account that has linked Log analytics workspaces
#    $aa = "fbs-aa-01"
# 2. need to have a resource group in which the automation account exist
#    eg. $rg = "to-delete-02"
# 2. need to have windows azure Vms that are already onborded to Update management
#     eg.  $azureVMIdsW
# 3 need to have Linux azure Vms that are already onborded to Update management
#     eg. $azureVMIdsL
# 4. need to have non azure computers that are already onborded to update management
#     eg. $nonAzurecomputers
# 5. need to have a subscription or resource group id in which update management onboarded Vms exists
#.....eg $query1Scope = @(
#       "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/sdk-tests-UM-rg"
#   )
# 6. have workspace saved search queries in which it has non azure Vms that are onboarded. 
#    eg.  $nonAzureQuery1 = @{
 #       FunctionAlias = "SavedSearch1";
 #      WorkspaceResourceId = "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourcegroups/mo-resources-eus/providers/microsoft.operationalinsights/workspaces/mo-la-eus2"
#   }

$rg = "mo-resources-eus"
$aa = "mo-aaa-eus2"
$azureVMIdsW = @(
        "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/mo-resources-eus/providers/Microsoft.Compute/virtualMachines/mo-vm-w-01",
        "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/mo-resources-eus/providers/Microsoft.Compute/virtualMachines/mo-vm-w-02"
    )

$azureVMIdsL = @(
        "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/mo-resources-eus/providers/Microsoft.Compute/virtualMachines/mo-vm-l-01"
    )

$nonAzurecomputers = @("server-01")

 function Test-CreateAndGetSoftwareUpdateConfigurationWithPrePost
{
    $name = "DG-suc-03"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    $params = @{"param1"= "we made it!"}

    $suc = New-AzAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -AzureVMResourceId $azureVMIdsL `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -IncludedUpdateClassification Security,Critical `
                                                             -PreTaskRunbookName "preTask" `
                                                             -PostTaskRunbookName "postTask" `
                                                             -PostTaskRunbookParameter $params `
                                                             -RebootSetting "Never"


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
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

function Test-CreateAndGetSoftwareUpdateConfigurationWithRebootOnly
{
    $name = "DG-suc-03"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    $suc = New-AzAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -AzureVMResourceId $azureVMIdsW `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -RebootOnly

    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name

    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"    
    Assert-AreEqual $sucGet.UpdateConfiguration.Windows.RebootSetting "RebootOnly" "Reboot setting is not set to Never"
}

function Test-GetSoftwareUpdateConfigurationRunWithPrePost
{
    $sucName = 'mo-onetime-01'
    $sucrId = '7f077575-3905-4608-843e-5651884ffea1'

    $sucr = Get-AzAutomationSoftwareUpdateRun  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Id $sucrId


    Assert-NotNull $sucr "Get-SoftwareUpdateConfigurationRun returned null"
    Assert-AreEqual $sucr.SoftwareUpdateConfigurationName $sucName "Name of created software update configuration run didn't match given name"

    #Assert-NotNull $sucr.Tasks.PreTask "PreTask is null"
    #Assert-NotNull $sucr.Tasks.PostTask "PostTask is null"
    #Assert-NotNull $sucr.Tasks.PreTask.JobId "PreTask jobId is null"
    #Assert-NotNull $sucr.Tasks.PostTask.JobId "PostTask jobId is null"
    #Assert-AreEqual $sucr.Tasks.PostTask.source "preTask" "Post task didn't have the correct source name"
    #Assert-AreEqual $sucr.Tasks.PostTask.Status "Completed" "Post task didn't have the correct status"
    #Assert-AreEqual $sucr.Tasks.PreTask.source "preTask" "Pre task didn't have the correct source name"
    #Assert-AreEqual $sucr.Tasks.PreTask.Status "Completed" "Pre task didn't have the correct status"
}

<#
.SYNOPSIS
Test-CreateAndGetSoftwareUpdateConfigurationWithDynamicGroups.
#>
function Test-CreateAndGetSoftwareUpdateConfigurationWithDynamicGroups
{
    $name = "DG-suc-04"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

$query1Scope = @(
        "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/sdk-tests-UM-rg"
    )

    $query1Location =@("Japan East", "UK South")
    $query1FilterOperator = "All"

    $tag1 = @{"tag1"= @("tag1Value1", "tag1Value2")}
    $tag1.add("tag2", "tag2Value")
    $azq = New-AzAutomationUpdateManagementAzureQuery -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Scope $query1Scope `
                                       -Location $query1Location `
                                       -Tag $tag1


   $AzureQueries = @($azq)

    $nonAzureQuery1 = @{
        FunctionAlias = "SavedSearch1";
       WorkspaceResourceId = "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourcegroups/mo-resources-eus/providers/microsoft.operationalinsights/workspaces/mo-la-eus2"
    }

    $nonAzureQuery2 = @{
        FunctionAlias = "SavedSearch2";
       WorkspaceResourceId = "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourcegroups/mo-resources-eus/providers/microsoft.operationalinsights/workspaces/mo-la-eus2"
    }

    $NonAzureQueries = @($nonAzureQuery1, $nonAzureQuery2)

    $suc = New-AzAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -AzureVMResourceId $azureVMIdsL `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -AzureQuery $AzureQueries `
                                                             -NonAzureQuery $NonAzureQueries `
                                                             -IncludedUpdateClassification Security,Critical 


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name
  
    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $sucGet.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets "Update targets object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets.AzureQueries "Update targets  azureQueries list  null"
    Assert-AreEqual $sucGet.UpdateConfiguration.Targets.AzureQueries.Count  1 "Update targets  doesn't have the correct number of azure queries"
   
 }

 <#
.SYNOPSIS
Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsOnly.
#>
function Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsOnly
{
    $name = "DG-suc-04"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

$query1Scope = @(
        "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/sdk-tests-UM-rg"
    )

    $query1Location =@("Japan East", "UK South")
    $query1FilterOperator = "All"

    $tag1 = @{"tag1"= @("tag1Value1", "tag1Value2")}
    $tag1.add("tag2", "tag2Value")
    $azq = New-AzAutomationUpdateManagementAzureQuery -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Scope $query1Scope `
                                       -Location $query1Location `
                                       -Tag $tag1


   $AzureQueries = @($azq)

    $suc = New-AzAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -AzureQuery $AzureQueries `
                                                             -IncludedUpdateClassification Security,Critical 


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name
  
    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $sucGet.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets "Update targets object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets.AzureQueries "Update targets  azureQueries list  null"
    Assert-AreEqual $sucGet.UpdateConfiguration.Targets.AzureQueries.Count  1 "Update targets  doesn't have the correct number of azure queries"
   
 }

  <#
.SYNOPSIS
Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsOnlyWithOutTags
#>
 function Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsOnlyWithOutTags
{
    $name = "DG-suc-04"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

$query1Scope = @(
        "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/sdk-tests-UM-rg"
    )

    $query1Location =@("Japan East", "UK South")
    $query1FilterOperator = "All"

    $azq = New-AzAutomationUpdateManagementAzureQuery -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Scope $query1Scope `
                                       -Location $query1Location `
                                       -FilterOperator $query1FilterOperator

   $AzureQueries = @($azq)

    $suc = New-AzAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -AzureQuery $AzureQueries `
                                                             -IncludedUpdateClassification Security,Critical 


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name
  
    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $sucGet.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets "Update targets object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets.AzureQueries "Update targets  azureQueries list  null"	
    Assert-AreEqual $sucGet.UpdateConfiguration.Targets.AzureQueries.Count  1 "Update targets  doesn't have the correct number of azure queries"
   
 }

 <#
.SYNOPSIS
Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsOnlyWithOutTags
#>
 function Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsWithLocationParameterbackwardCompatiple
{
    $name = "DG-suc-04"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

$query1Scope = @(
        "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/sdk-tests-UM-rg"
    )

    $query1Location =@("Japan East", "UK South")
    $query1FilterOperator = "All"

    $azq = New-AzAutomationUpdateManagementAzureQuery -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Scope $query1Scope `
                                       -Locaton $query1Location `
                                       -FilterOperator $query1FilterOperator

   $AzureQueries = @($azq)

    $suc = New-AzAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -AzureQuery $AzureQueries `
                                                             -IncludedUpdateClassification Security,Critical 


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name
  
    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $sucGet.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets "Update targets object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets.AzureQueries "Update targets  azureQueries list  null"	
    Assert-AreEqual $sucGet.UpdateConfiguration.Targets.AzureQueries.Count  1 "Update targets  doesn't have the correct number of azure queries"
   
 }

   <#
.SYNOPSIS
Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsOnlyWithOutLocations
#>
 function Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsOnlyWithOutLocations
{
    $name = "DG-suc-04"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

$query1Scope = @(
        "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/sdk-tests-UM-rg"
    )

    $query1FilterOperator = "All"
    $tag1 = @{"tag1"= @("tag1Value1", "tag1Value2")}
    $tag1.add("tag2", "tag2Value")
    $azq = New-AzAutomationUpdateManagementAzureQuery -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Scope $query1Scope `
                                       -FilterOperator $query1FilterOperator `
                                       -Tag $tag1

   $AzureQueries = @($azq)

    $suc = New-AzAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -AzureQuery $AzureQueries `
                                                             -IncludedUpdateClassification Security,Critical 


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name
  
    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $sucGet.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets "Update targets object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets.AzureQueries "Update targets  azureQueries list  null"
    Assert-AreEqual $sucGet.UpdateConfiguration.Targets.AzureQueries.Count  1 "Update targets  doesn't have the correct number of azure queries"
   
 }

    <#
.SYNOPSIS
Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsOnlyWithOutLocationsAndTags
#>
 function Test-CreateAndGetSoftwareUpdateConfigurationWithAzureDynamicGroupsOnlyWithOutLocationsAndTags
{
    $name = "DG-suc-04"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

$query1Scope = @(
        "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourceGroups/sdk-tests-UM-rg"
    )
    $azq = New-AzAutomationUpdateManagementAzureQuery -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Scope $query1Scope `

   $AzureQueries = @($azq)

    $suc = New-AzAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -AzureQuery $AzureQueries `
                                                             -IncludedUpdateClassification Security,Critical 


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name
  
    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $sucGet.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets "Update targets object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets.AzureQueries "Update targets  azureQueries list  null"
    Assert-AreEqual $sucGet.UpdateConfiguration.Targets.AzureQueries.Count  1 "Update targets  doesn't have the correct number of azure queries"
   
 }

 <#
.SYNOPSIS
Test-CreateAndGetSoftwareUpdateConfigurationWithNonAzureDynamicGroupsOnly
#>
function Test-CreateAndGetSoftwareUpdateConfigurationWithNonAzureDynamicGroupsOnly
{
    $name = "DG-suc-04"
    $startTime = ([DateTime]::Now).AddMinutes(10)
    $s = New-AzAutomationSchedule -ResourceGroupName $rg `
                                       -AutomationAccountName $aa `
                                       -Name $name `
                                       -Description test-OneTime `
                                       -OneTime `
                                       -StartTime $startTime `
                                       -ForUpdate

    $nonAzureQuery1 = @{
        FunctionAlias = "SavedSearch1";
       WorkspaceResourceId = "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourcegroups/mo-resources-eus/providers/microsoft.operationalinsights/workspaces/mo-la-eus2"
    }

    $nonAzureQuery2 = @{
        FunctionAlias = "SavedSearch2";
       WorkspaceResourceId = "/subscriptions/783fd652-64f3-4680-81e9-0b978c542005/resourcegroups/mo-resources-eus/providers/microsoft.operationalinsights/workspaces/mo-la-eus2"
    }

    $NonAzureQueries = @($nonAzureQuery1, $nonAzureQuery2)

    $suc = New-AzAutomationSoftwareUpdateConfiguration  -ResourceGroupName $rg `
                                                             -AutomationAccountName $aa `
                                                             -Schedule $s `
                                                             -Window `
                                                             -Duration (New-TimeSpan -Hours 2) `
                                                             -NonAzureQuery $NonAzureQueries `
                                                             -IncludedUpdateClassification Security,Critical 


    Assert-NotNull $suc "New-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $suc.Name $name "Name of created software update configuration didn't match given name"

    $sucGet = Get-AzAutomationSoftwareUpdateConfiguration -ResourceGroupName $rg `
                                                                -AutomationAccountName $aa `
                                                                -Name $name
  
    Assert-NotNull $sucGet "Get-AzureRmAutomationSoftwareUpdateConfiguration returned null"
    Assert-AreEqual $sucGet.Name $name "Name of created software update configuration didn't match given name"
    Assert-NotNull $sucGet.UpdateConfiguration "UpdateConfiguration of the software update configuration object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets "Update targets object is null"
    Assert-NotNull $sucGet.UpdateConfiguration.Targets.NonAzureQueries "Update targets  non azureQueries list  null"
    Assert-AreEqual $sucGet.UpdateConfiguration.Targets.NonAzureQueries.Count  2 "Update targets  doesn't have the correct number of non azure queries"
   
 }