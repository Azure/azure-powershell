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

# This script will set up the necessary resources and policies to record the policy insights tests.
# This makes things a lot easier, since the tests require specific policies to be present in various scopes
# as well as large number of non-compliant resources in order to test things like paging.
# Both the tests and this script use the resource details defined in the common.ps1 script.
# Before running env setup, make sure you have access to the MG and Subscription defined in common.ps1 (or change them to MG\subscription you do have acess to)
. "..\ScenarioTests\Common.ps1"

# Note: Once the script is finished, wait for full compliance results before running the tests.
$subscriptionId = $(Get-TestSubscriptionId)
$managementGroupId = $(Get-TestManagementGroupName)
$emptyResourceGroupName = $(Get-EmptyTestResourceGroupName)
$resourceGroup1 = $(Get-FirstTestResourceGroupName)
$resourceGroup2 = $(Get-SecondTestResourceGroupName)

# Connect
Connect-AzAccount -DeviceCode
Set-AzContext -SubscriptionId $subscriptionId

#Create an empty RG
Get-AzResourceGroup -Name $emptyResourceGroupName -ErrorVariable rgNotPresent -ErrorAction SilentlyContinue
if ($rgNotPresent) {
   New-AzResourceGroup -Name $emptyResourceGroupName -Location "eastus"
}

# Create 2 RGs
foreach ($resourceGroupName in @($resourceGroup1, $resourceGroup2)) {
   Get-AzResourceGroup -Name $resourceGroupName -ErrorVariable rgNotPresent -ErrorAction SilentlyContinue
   if ($rgNotPresent) {
      New-AzResourceGroup -Name $resourceGroupName -Location "northcentralus"
   }
}

# Create DINE and modify definitions (MG-level)
$deployIfNotExistsPolicyDefinition = New-AzPolicyDefinition -Name $(Get-TestDINEPolicyDefinitionName) -Policy "$PSScriptRoot/NSG_DINE_neverCompliant_policyDefinition.json" -DisplayName "PS cmdlet tests: never compliant DINE policy" -Mode Indexed -ManagementGroupName $managementGroupId
$modifyPolicyDefinition = New-AzPolicyDefinition -Name $(Get-TestModifyPolicyDefinitionName) -Policy "$PSScriptRoot/NSG_modify_neverCompliant_policyDefinition.json" -DisplayName "PS cmdlet tests: never compliant modify policy" -Mode Indexed -ManagementGroupName $managementGroupId

# Assign the DINE policy in both MG and subscription level
$mgDINEAssignment = New-AzPolicyAssignment -Name $(Get-TestManagementGroupDINEAssignmentName) -Scope "/providers/microsoft.management/managementgroups/$managementGroupId" -DisplayName "PS cmdlet tests: never compliant DINE policy (MG)" -PolicyDefinition $deployIfNotExistsPolicyDefinition -AssignIdentity -Location "westus2"
$subDINEAssignment = New-AzPolicyAssignment -Name $(Get-TestSubscriptionDINEAssignmentName) -Scope "/subscriptions/$subscriptionId" -DisplayName "PS cmdlet tests: never compliant DINE policy (Sub)" -PolicyDefinition $deployIfNotExistsPolicyDefinition -AssignIdentity -Location "westus2"

# Assign the modify policy to the subscription
$subModifyAssignment = New-AzPolicyAssignment -Name $(Get-TestSubscriptionModifyAssignmentName) -Scope "/subscriptions/$subscriptionId" -DisplayName "PS cmdlet tests: never compliant modify policy" -PolicyDefinition $modifyPolicyDefinition -AssignIdentity -Location "westus2"

# Give the assignments permissions to perform remediations
Start-TestSleep -Seconds 60
New-AzRoleAssignment -Scope "/providers/microsoft.management/managementgroups/$managementGroupId" -ObjectId $mgDINEAssignment.Identity.principalId -RoleDefinitionName "Key Vault Contributor"
New-AzRoleAssignment -Scope "/subscriptions/$subscriptionId" -ObjectId $subDINEAssignment.Identity.principalId -RoleDefinitionName "Key Vault Contributor"
New-AzRoleAssignment -Scope "/subscriptions/$subscriptionId" -ObjectId $subModifyAssignment.Identity.principalId -RoleDefinitionName "Tag Contributor"

# Trigger 101 modify remediations with different names (don't care about the outcome, just want to have 101 remediation entities we can query)
New-AzResourceGroupDeployment -ResourceGroupName $resourceGroup1 -TemplateFile "$PSScriptRoot/CreateRemediationsTemplate.json" -remediationCount 101 -assignmentId $subModifyAssignment.ResourceId

# Create a subscription-level audit policy definition
$partiallyCompliantAuditPolicyDefinition = New-AzPolicyDefinition -Name $(Get-TestAuditPolicyDefinitionName) -Policy "$PSScriptRoot/NSG_audit_partiallyCompliant_policyDefinition.json" -DisplayName "PS cmdlet tests: partially compliant audit policy" -Mode Indexed -SubscriptionId $subscriptionId

# Assign the audit policy to subscription and RG levels
New-AzPolicyAssignment -Name $(Get-TestSubscriptionAuditAssignmentName) -Scope "/subscriptions/$subscriptionId" -DisplayName "PS cmdlet tests: partially compliant audit policy (Sub)" -PolicyDefinition $partiallyCompliantAuditPolicyDefinition
New-AzPolicyAssignment -Name $(Get-TestResourceGroupAuditAssignmentName) -Scope "/subscriptions/$subscriptionId/resourceGroups/$resourceGroup1" -DisplayName "PS cmdlet tests: partially compliant audit policy (RG)" -PolicyDefinition $partiallyCompliantAuditPolicyDefinition

# Create an initiative for the audit policy
$policyDefinitions = @"
[
   {
      "policyDefinitionId": "$($partiallyCompliantAuditPolicyDefinition.ResourceId)"
   }
]
"@

$policySetDefinition = New-AzPolicySetDefinition -Name $(Get-TestPolicySetDefinitionName) -DisplayName "PS cmdlet tests: test initiative" -PolicyDefinition $policyDefinitions -SubscriptionId $subscriptionId

# Assign the initiative to the subscription
New-AzPolicyAssignment -Name $(Get-TestSubscriptionAuditInitiativeAssignmentName) -Scope "/subscriptions/$subscriptionId" -DisplayName "PS cmdlet tests: initiative with audit policy (Sub)" -PolicySetDefinition $policySetDefinition

Start-TestSleep -Seconds 60

# In each RG, create 510 NSGs (will take a while)
foreach ($resourceGroupName in @($resourceGroup1, $resourceGroup2)) {
   New-AzResourceGroupDeployment -ResourceGroupName $resourceGroupName -TemplateFile "$PSScriptRoot/CreateNSGsTemplate.json" -resourceCount 510 -resourceNamePrefix $(Get-TestResourceNamePrefix)
}
