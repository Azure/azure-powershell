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

# This script will set up the necessary resources and policies in a subscription to record the Remediation tests
# You'll need to update the policy assignment IDs, resource IDs, etc... in the test to match the env your SPN has access to
$subscriptionId = "f67cc918-f64f-4c3f-aa24-a855465f9d41"
$managementGroupId = "AzGovPerfTest" # should be a parent of the subscription
$resourceGroupName = "PSTestRG"

# Create the resoure group
Select-AzSubscription $subscriptionId
$rg = Get-AzResourceGroup -Name $resourceGroupName -ErrorVariable rgNotPresent -ErrorAction SilentlyContinue
if ($rgNotPresent)
{
   $rg = New-AzResourceGroup -Name $resourceGroupName -Location "northcentralus"
}

New-AzKeyVault -Name "PSTestKV1" -ResourceGroupName $rg.ResourceGroupName -Location "northcentralus"
New-AzKeyVault -Name "PSTestKV2" -ResourceGroupName $rg.ResourceGroupName -Location "northcentralus"
New-AzKeyVault -Name "PSTestKV3" -ResourceGroupName $rg.ResourceGroupName -Location "westus2"

$policyDef = New-AzPolicyDefinition -Name "PSTestDeployDefinition" -Policy "$PSScriptRoot/emptyDeployment_KeyVault_policyDefinition.json" -DisplayName "Empty deployment on each KeyVault resource" -Mode Indexed -ManagementGroupName $managementGroupId

$mgAssignment = New-AzPolicyAssignment -Name "PSTestDeployAssignmentMG" -Scope "/providers/microsoft.management/managementgroups/$managementGroupId" -DisplayName "Empty deployment on each KeyVault resource (MG)" -PolicyDefinition $policyDef -AssignIdentity -Location "westus2"
$subAssignment = New-AzPolicyAssignment -Name "PSTestDeployAssignmentSub" -Scope "/subscriptions/$subscriptionId" -DisplayName "Empty deployment on each KeyVault resource (SUB)" -PolicyDefinition $policyDef -AssignIdentity -Location "westus2"

Start-Sleep -Seconds 60

New-AzRoleAssignment -Scope "/providers/microsoft.management/managementgroups/$managementGroupId" -ObjectId $mgAssignment.Identity.principalId -RoleDefinitionName "Key Vault Contributor"
New-AzRoleAssignment -Scope "/subscriptions/$subscriptionId" -ObjectId $subAssignment.Identity.principalId -RoleDefinitionName "Key Vault Contributor"