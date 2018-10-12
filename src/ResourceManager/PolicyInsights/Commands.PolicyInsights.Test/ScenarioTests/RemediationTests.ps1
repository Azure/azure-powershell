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
Perform remediation CRUD operations at subscription scope
#>
function Remediation-SubscriptionScope-Crud
{
   $assignmentId = Get-TestRemediationSubscriptionPolicyAssignmentId
   $remediationName = "PSTestRemediation"

   # Create a new remediation
   $remediation = New-AzureRmPolicyRemediation -PolicyAssignmentId $assignmentId -Name $remediationName -LocationFilter "westus2","west central us"
   Validate-Remediation $remediation
   Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
   Assert-Null $remediation.PolicyDefinitionReferenceId
   Assert-AreEqual "Accepted" $remediation.ProvisioningState
   Assert-AreEqual 2 $remediation.Filters.Locations.Count
   Assert-AreEqualArray $remediation.Filters.Locations @("westus2", "westcentralus")
   Assert-AreEqual 3 $remediation.DeploymentSummary.TotalDeployments

   # Cancel the remediation
   $remediation | Stop-AzureRmPolicyRemediation

   # Get the remediation that was just cancelled
   $remediation = Get-AzureRmPolicyRemediation -Name $remediationName
   Validate-Remediation $remediation
   Assert-AreEqual $remediationName $remediation.Name
   Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
   Assert-True { $remediation.ProvisioningState -like "Cancel*" }
   Assert-AreEqual 2 $remediation.Filters.Locations.Count
   Assert-AreEqualArray $remediation.Filters.Locations @("westus2", "westcentralus")
   Assert-AreEqual 3 $remediation.DeploymentSummary.TotalDeployments
   Assert-AreEqual 0 $remediation.DeploymentSummary.FailedDeployments

   # Get the deployments for the remediation via piping
   $deployments = $remediation | Get-AzureRmPolicyRemediationDeployment
   Assert-AreEqual 3 $deployments.Count
   $acceptedStates = "Canceled", "NotStarted"
   $deployments | ForEach-Object {
      Validate-RemediationDeployment $_
      Assert-True { $acceptedStates -contains $_.Status }
   }

   # Get the deployments for the remediation without piping (+ top filter)
   $deployments = Get-AzureRmPolicyRemediationDeployment -Name $remediationName -Top 2
   Assert-AreEqual 2 $deployments.Count
   $deployments | ForEach-Object {
      Validate-RemediationDeployment $_
      Assert-True { $acceptedStates -contains $_.Status }
   }

   # Get all remediations in the subscription
   $remediations = Get-AzureRmPolicyRemediation
   Assert-AreEqual 71 $remediations.Count
   Validate-Remediation $remediations[10]

   # Get a limited number of remediations
   $remediations = Get-AzureRmPolicyRemediation -Top 5
   Assert-AreEqual 5 $remediations.Count
   Validate-Remediation $remediations[0]

   # Get all remediations for a specific assignment
   $remediations = Get-AzureRmPolicyRemediation -Filter "PolicyAssignmentId eq '$assignmentId'"
   Assert-AreEqual 2 $remediations.Count
   $remediations | ForEach-Object {
      Validate-Remediation $_
      Assert-AreEqual $assignmentId $_.PolicyAssignmentId
   }

   # Delete the remediation that was created initially
   $result = { $remediation | Remove-AzureRmPolicyRemediation -PassThru }
   Assert-True $result
}

<#
.SYNOPSIS
Perform remediation CRUD operations at resource group scope
#>
function Remediation-ResourceGroupScope-Crud
{
   $assignmentId = Get-TestRemediationSubscriptionPolicyAssignmentId
   $remediationName = "PSTestRemediation"
   $resourceGroupName = "elpere"

   # Create a new remediation
   $remediation = New-AzureRmPolicyRemediation -ResourceGroupName $resourceGroupName -PolicyAssignmentId $assignmentId -Name $remediationName
   Validate-Remediation $remediation
   Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
   Assert-Null $remediation.PolicyDefinitionReferenceId
   Assert-AreEqual "Accepted" $remediation.ProvisioningState
   Assert-Null $remediation.Filters
   Assert-AreEqual 5 $remediation.DeploymentSummary.TotalDeployments

   # Cancel the remediation
   Stop-AzureRmPolicyRemediation -ResourceId $remediation.Id

   # Get the remediation that was just cancelled
   $remediation = Get-AzureRmPolicyRemediation -ResourceGroupName $resourceGroupName -Name $remediationName
   Validate-Remediation $remediation
   Assert-AreEqual $remediationName $remediation.Name
   Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
   Assert-True { $remediation.ProvisioningState -like "Cancel*" }
   Assert-Null $remediation.Filters
   Assert-AreEqual 5 $remediation.DeploymentSummary.TotalDeployments
   Assert-AreEqual 0 $remediation.DeploymentSummary.FailedDeployments

   # Get the deployments for the remediation via piping
   $deployments = $remediation | Get-AzureRmPolicyRemediationDeployment
   Assert-AreEqual 5 $deployments.Count
   $acceptedStates = "Canceled", "NotStarted"
   $deployments | ForEach-Object {
      Validate-RemediationDeployment $_
      Assert-True { $acceptedStates -contains $_.Status }
   }

   # Get the deployments for the remediation without piping (+ top filter)
   $deployments = Get-AzureRmPolicyRemediationDeployment -ResourceGroupName $resourceGroupName -Name $remediationName -Top 2
   Assert-AreEqual 2 $deployments.Count
   $deployments | ForEach-Object {
      Validate-RemediationDeployment $_
      Assert-True { $acceptedStates -contains $_.Status }
   }

   # Get all remediations in the resource group
   $remediations = Get-AzureRmPolicyRemediation -ResourceGroupName $resourceGroupName
   Assert-AreEqual 11 $remediations.Count
   Validate-Remediation $remediations[5]

   # Get a limited number of remediations
   $remediations = Get-AzureRmPolicyRemediation -ResourceGroupName $resourceGroupName -Top 5
   Assert-AreEqual 5 $remediations.Count
   Validate-Remediation $remediations[0]

   # Get all remediations for a specific assignment
   $remediations = Get-AzureRmPolicyRemediation -ResourceGroupName $resourceGroupName -Filter "PolicyAssignmentId eq '$assignmentId'"
   Assert-AreEqual 1 $remediations.Count
   $remediations | ForEach-Object {
      Validate-Remediation $_
      Assert-AreEqual $assignmentId $_.PolicyAssignmentId
   }

   # Delete the remediation that was created initially
   $result = { Remove-AzureRmPolicyRemediation -ResourceGroupName $resourceGroupName -Name $remediationName -PassThru }
   Assert-True $result
}

<#
.SYNOPSIS
Perform remediation CRUD operations at individual resource scope
#>
function Remediation-ResourceScope-Crud
{
   $assignmentId = Get-TestRemediationSubscriptionPolicyAssignmentId
   $remediationName = "PSTestRemediation"
   $scope = "/subscriptions/d0610b27-9663-4c05-89f8-5b4be01e86a5/resourceGroups/elpere/providers/Microsoft.KeyVault/vaults/elpereKv"

   # Create a new remediation
   $remediation = New-AzureRmPolicyRemediation -Scope $scope -PolicyAssignmentId $assignmentId -Name $remediationName
   Validate-Remediation $remediation
   Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
   Assert-Null $remediation.PolicyDefinitionReferenceId
   Assert-AreEqual "Accepted" $remediation.ProvisioningState
   Assert-Null $remediation.Filters
   Assert-AreEqual 1 $remediation.DeploymentSummary.TotalDeployments

   # Cancel the remediation
   Stop-AzureRmPolicyRemediation -Scope $scope -Name $remediationName

   # Get the remediation that was just cancelled
   $remediation = Get-AzureRmPolicyRemediation -Scope $scope -Name $remediationName
   Validate-Remediation $remediation
   Assert-AreEqual $remediationName $remediation.Name
   Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
   Assert-True { $remediation.ProvisioningState -like "Cancel*" }
   Assert-Null $remediation.Filters
   Assert-AreEqual 1 $remediation.DeploymentSummary.TotalDeployments
   Assert-AreEqual 0 $remediation.DeploymentSummary.FailedDeployments

   # Get the deployments for the remediation via piping
   $deployments = $remediation | Get-AzureRmPolicyRemediationDeployment
   Assert-AreEqual 1 $deployments.Count
   $acceptedStates = "Canceled", "NotStarted"
   $deployments | ForEach-Object {
      Validate-RemediationDeployment $_
      Assert-True { $acceptedStates -contains $_.Status }
   }

   # Get the deployments for the remediation without piping (+ top filter)
   $deployments = Get-AzureRmPolicyRemediationDeployment -Scope $scope -Name $remediationName -Top 2
   Assert-AreEqual 1 $deployments.Count
   $deployments | ForEach-Object {
      Validate-RemediationDeployment $_
      Assert-True { $acceptedStates -contains $_.Status }
   }

   # Get all remediations underneath the resource
   $remediations = Get-AzureRmPolicyRemediation -Scope $scope
   Assert-AreEqual 1 $remediations.Count
   Validate-Remediation $remediations[0]

   # Get all remediations for a specific assignment
   $remediations = Get-AzureRmPolicyRemediation -Scope $scope -Filter "PolicyAssignmentId eq '$assignmentId'"
   Assert-AreEqual 1 $remediations.Count
   $remediations | ForEach-Object {
      Validate-Remediation $_
      Assert-AreEqual $assignmentId $_.PolicyAssignmentId
   }

   # Delete the remediation that was created initially
   $result = { Remove-AzureRmPolicyRemediation -Scope $scope -Name $remediationName -PassThru }
   Assert-True $result
}

<#
.SYNOPSIS
Perform remediation CRUD operations at management group scope
#>
function Remediation-ManagementGroupScope-Crud
{
   $assignmentId = Get-TestRemediationMgPolicyAssignmentId
   $remediationName = "PSTestRemediation"
   $managementGroupId = "PolicyUIMG"

   # Create a new remediation
   $remediation = New-AzureRmPolicyRemediation -ManagementGroupName $managementGroupId -PolicyAssignmentId $assignmentId -Name $remediationName
   Validate-Remediation $remediation
   Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
   Assert-Null $remediation.PolicyDefinitionReferenceId
   Assert-AreEqual "Accepted" $remediation.ProvisioningState
   Assert-Null $remediation.Filters
   Assert-AreEqual 1 $remediation.DeploymentSummary.TotalDeployments

   # Cancel the remediation
   Stop-AzureRmPolicyRemediation -ManagementGroupName $managementGroupId -Name $remediationName

   # Get the remediation that was just cancelled
   $remediation = Get-AzureRmPolicyRemediation -ManagementGroupName $managementGroupId -Name $remediationName
   Validate-Remediation $remediation
   Assert-AreEqual $remediationName $remediation.Name
   Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
   Assert-True { $remediation.ProvisioningState -like "Cancel*" }
   Assert-Null $remediation.Filters
   Assert-AreEqual 1 $remediation.DeploymentSummary.TotalDeployments
   Assert-AreEqual 0 $remediation.DeploymentSummary.FailedDeployments

   # Get the deployments for the remediation via piping
   $deployments = $remediation | Get-AzureRmPolicyRemediationDeployment
   Assert-AreEqual 1 $deployments.Count
   $acceptedStates = "Canceled", "NotStarted"
   $deployments | ForEach-Object {
      Validate-RemediationDeployment $_
      Assert-True { $acceptedStates -contains $_.Status }
   }

   # Get the deployments for the remediation without piping (+ top filter)
   $deployments = Get-AzureRmPolicyRemediationDeployment -ManagementGroupName $managementGroupId -Name $remediationName -Top 2
   Assert-AreEqual 1 $deployments.Count
   $deployments | ForEach-Object {
      Validate-RemediationDeployment $_
      Assert-True { $acceptedStates -contains $_.Status }
   }

   # Get all remediations in the management group
   $remediations = Get-AzureRmPolicyRemediation -ManagementGroupName $managementGroupId
   Assert-AreEqual 3 $remediations.Count
   Validate-Remediation $remediations[2]

   # Get a limited number of remediations
   $remediations = Get-AzureRmPolicyRemediation -Top 2
   Assert-AreEqual 2 $remediations.Count
   Validate-Remediation $remediations[1]

   # Get all remediations for a specific assignment
   $remediations = Get-AzureRmPolicyRemediation -ManagementGroupName $managementGroupId -Filter "PolicyAssignmentId eq '$assignmentId'"
   Assert-AreEqual 1 $remediations.Count
   $remediations | ForEach-Object {
      Validate-Remediation $_
      Assert-AreEqual $assignmentId $_.PolicyAssignmentId
   }

   # Delete the remediation that was created initially
   $result = { Remove-AzureRmPolicyRemediation -ResourceId $remediation.Id -PassThru }
   Assert-True $result
}