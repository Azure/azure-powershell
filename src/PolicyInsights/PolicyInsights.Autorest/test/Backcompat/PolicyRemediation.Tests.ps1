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

# setup the Pester environment
. (Join-Path $PSScriptRoot 'Common.ps1') 'Remediation-CRUD'


Describe 'Remediation-CRUD' -Tag 'LiveOnly' {

    BeforeAll {
        $managementGroupName = $env.managementGroup

        $remediationSubAssignmentId = $env.remediationSubPolicyAssignmentId
        $remediationMgAssignmentId = $env.remediationMgPolicyAssignmentId
    }

    It 'SubscriptionScope-Crud' {
        $assignmentId = $remediationSubAssignmentId
        $remediationName = "Remediation-SubscriptionScope-Crud"

        $resourceIdFilter = @("/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/pstestrg2/providers/microsoft.network/networksecuritygroups/pstests97", "/subscriptions/e5a130f3-57fd-46b6-9c55-03d21a853935/resourcegroups/pstestrg2/providers/microsoft.network/networksecuritygroups/pstests92")
        $remediation = Start-AzPolicyRemediation -PolicyAssignmentId $assignmentId -Name $remediationName -LocationFilter "westus2", "northcentralus" -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20 -FilterResourceId $resourceIdFilter
        
        # Verify the remediation completed with the expected properties
        Validate-Remediation $remediation
        Assert-AreEqual "ExistingNonCompliant" $remediation.ResourceDiscoveryMode
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual "Succeeded" $remediation.ProvisioningState
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-AreEqual 2 $remediation.FilterLocation.Count
        Assert-AreEqualArray $remediation.FilterLocation @("westus2", "northcentralus")
        Assert-AreEqual 2 $remediation.FilterResourceId.Count
        Assert-AreEqualArray $remediation.FilterResourceId $resourceIdFilter
        Assert-AreEqual 2 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment

        # Get the deployments for the remediation
        $remediation = Get-AzPolicyRemediation -Name $remediationName -IncludeDetail
        Assert-AreEqual 2 $remediation.Deployments.Count
        $remediation.Deployments | ForEach-Object {
           Validate-RemediationDeployment $_
        }

        # Get the deployments for the remediation with a Top filter
        $remediation = Get-AzPolicyRemediation -Name $remediationName -IncludeDetail -Top 2
        Assert-AreEqual 2 $remediation.Deployments.Count

        # Get all remediations in the subscription
        $remediations = Get-AzPolicyRemediation
        Assert-True { $remediations.Count -gt 100 }
        Validate-Remediation $remediations[10]

        # Get a limited number of remediations
        $remediations = Get-AzPolicyRemediation -Top 5
        Assert-AreEqual 5 $remediations.Count
        Validate-Remediation $remediations[0]

        # Get a limited number of remediations
        $remediations = Get-AzPolicyRemediation -Top 101
        Assert-AreEqual 101 $remediations.Count

        # Get all remediations for a specific assignment
        $remediations = Get-AzPolicyRemediation -Filter "PolicyAssignmentId eq '$assignmentId'"
        Assert-True { $remediations.Count -gt 1 }
        $remediations | ForEach-Object {
           Validate-Remediation $_
           Assert-AreEqual $assignmentId $_.PolicyAssignmentId
        }

        # Delete the remediation that was created initially
        $result = ($remediation | Remove-AzPolicyRemediation -PassThru)
        Assert-AreEqual $true $result

        # Create a new remediation with the NoWait flag
        $remediation = Start-AzPolicyRemediation -PolicyAssignmentId $assignmentId -Name $remediationName -LocationFilter "westus2", "northcentralus" -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20 -NoWait
        Validate-Remediation $remediation
        Assert-AreEqual "ExistingNonCompliant" $remediation.ResourceDiscoveryMode
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-Null $remediation.PolicyDefinitionReferenceId
        Assert-AreEqual "Accepted" $remediation.ProvisioningState
        Assert-AreEqual 2 $remediation.FilterLocation.Count
        Assert-AreEqualArray $remediation.FilterLocation @("westus2", "northcentralus")
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment

        # Cancel the remediation as a job so that we wait for cancellation to complete
        $remediation = ($remediation | Stop-AzPolicyRemediation)

        # Get the remediation that was just canceled
        $remediation = Get-AzPolicyRemediation -Name $remediationName
        Validate-Remediation $remediation
        Assert-AreEqual "ExistingNonCompliant" $remediation.ResourceDiscoveryMode
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-AreEqual "Canceled" $remediation.ProvisioningState
        Assert-AreEqual 2 $remediation.FilterLocation.Count
        Assert-AreEqualArray $remediation.FilterLocation @("westus2", "northcentralus")
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment
    }

    It 'ResourceGroupScope-Crud' {
        $assignmentId = $remediationSubAssignmentId
        $remediationName = "Remediation-ResourceGroupScope-Crud"
        $resourceGroupName = $env.firstRgName

        # Create a new remediation to test the synchronous Start
        $remediation = Start-AzPolicyRemediation -ResourceGroupName $resourceGroupName -PolicyAssignmentId $assignmentId -Name $remediationName -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20

        # Validate the remediation completed with the expected properties
        Validate-Remediation $remediation
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual $remediation.ProvisioningState "Succeeded"
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-Null $remediation.Filters
        Assert-AreEqual 3 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment

        # Get the deployments for the remediation
        $remediation = Get-AzPolicyRemediation -ResourceGroupName $resourceGroupName -Name $remediationName -IncludeDetail
        Assert-AreEqual 3 $remediation.Deployments.Count
        $remediation.Deployments | ForEach-Object {
           Validate-RemediationDeployment $_
        }

        # Get the deployments for the remediation (+ top filter)
        $remediation = Get-AzPolicyRemediation -ResourceGroupName $resourceGroupName -Name $remediationName -IncludeDetail -Top 2
        Assert-AreEqual 2 $remediation.Deployments.Count
        $remediation.Deployments | ForEach-Object {
           Validate-RemediationDeployment $_
        }

        # Get all remediations in the resource group
        $remediations = Get-AzPolicyRemediation -ResourceGroupName $resourceGroupName
        Assert-True { $remediations.Count -gt 1 }
        Validate-Remediation $remediations[1]

        # Get a limited number of remediations
        $remediations = Get-AzPolicyRemediation -ResourceGroupName $resourceGroupName -Top 1
        Assert-AreEqual 1 $remediations.Count
        Validate-Remediation $remediations[0]

        # Get all remediations for a specific assignment
        $remediations = Get-AzPolicyRemediation -ResourceGroupName $resourceGroupName -Filter "PolicyAssignmentId eq '$assignmentId'"
        Assert-True { $remediations.Count -ge 1 }
        $remediations | ForEach-Object {
           Validate-Remediation $_
           Assert-AreEqual $assignmentId $_.PolicyAssignmentId
        }

        # Delete the remediation that was created initially
        $result = (Remove-AzPolicyRemediation -ResourceGroupName $resourceGroupName -Name $remediationName -PassThru)
        Assert-AreEqual $true $result

        # Create a new remediation with the NoWait flag
        $remediation = Start-AzPolicyRemediation -ResourceGroupName $resourceGroupName -PolicyAssignmentId $assignmentId -Name $remediationName -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20 -NoWait
        Validate-Remediation $remediation
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-Null $remediation.PolicyDefinitionReferenceId
        Assert-AreEqual "Accepted" $remediation.ProvisioningState
        Assert-Null $remediation.Filters
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment

        # Cancel the remediation
        Stop-AzPolicyRemediation -ResourceId $remediation.Id

        # Get the remediation that was just canceled
        $remediation = Get-AzPolicyRemediation -ResourceGroupName $resourceGroupName -Name $remediationName
        Validate-Remediation $remediation
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-AreEqual "Canceled" $remediation.ProvisioningState
        Assert-Null $remediation.Filters
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment
    }

    It 'ResourceScope-Crud' {
        $assignmentId = $remediationSubAssignmentId
        $remediationName = "Remediation-ResourceScope-Crud"
        $scope = $env.testResourceId

        # Create a new remediation to test synchronous Start
        $remediation = Start-AzPolicyRemediation -Scope $scope -PolicyAssignmentId $assignmentId -Name $remediationName -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20

        # Verify the remediation completed with the expected properties
        Validate-Remediation $remediation
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual $remediation.ProvisioningState "Succeeded"
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-Null $remediation.Filters
        Assert-AreEqual 1 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment

        # Get the deployments for the remediation
        $remediation = Get-AzPolicyRemediation -Scope $scope -Name $remediationName -IncludeDetail
        Assert-AreEqual 1 $remediation.Deployments.Count
        $remediation.Deployments | ForEach-Object {
           Validate-RemediationDeployment $_
        }

        # Get the deployments for the remediation (+ top filter)
        $remediation = Get-AzPolicyRemediation -Scope $scope -Name $remediationName -IncludeDetail -Top 2
        Assert-AreEqual 1 $remediation.Deployments.Count
        $remediation.Deployments | ForEach-Object {
           Validate-RemediationDeployment $_
        }

        # Get all remediations underneath the resource
        $remediations = Get-AzPolicyRemediation -Scope $scope
        Assert-True { $remediations.Count -gt 0 }
        Validate-Remediation $remediations[0]

        # Get all remediations for a specific assignment
        $remediations = Get-AzPolicyRemediation -Scope $scope -Filter "PolicyAssignmentId eq '$assignmentId'"
        Assert-True { $remediations.Count -gt 0 }
        $remediations | ForEach-Object {
           Validate-Remediation $_
           Assert-AreEqual $assignmentId $_.PolicyAssignmentId
        }

        # Delete the remediation that was created initially
        $result = (Remove-AzPolicyRemediation -Scope $scope -Name $remediationName -PassThru)
        Assert-AreEqual $true $result

        # Create a new remediation to test NoWait
        $remediation = Start-AzPolicyRemediation -Scope $scope -PolicyAssignmentId $assignmentId -Name $remediationName -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20 -NoWait
        Validate-Remediation $remediation
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-Null $remediation.PolicyDefinitionReferenceId
        Assert-AreEqual "Accepted" $remediation.ProvisioningState
        Assert-Null $remediation.Filters
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment

        # Cancel the remediation as a job so that we wait for cancellation to complete
        $remediation = Stop-AzPolicyRemediation -Scope $scope -Name $remediationName

        # Get the remediation that was just canceled
        $remediation = Get-AzPolicyRemediation -Scope $scope -Name $remediationName
        Validate-Remediation $remediation
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-AreEqual "Canceled" $remediation.ProvisioningState
        Assert-Null $remediation.Filters
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment
    }

    It 'ManagementGroupScope-Crud' {
        $assignmentId = $remediationMgAssignmentId
        $remediationName = "Remediation-ManagementGroupScope-Crud"

        # Create a new remediation to test synchronous Start
        $remediation = Start-AzPolicyRemediation -ManagementGroupName $managementGroupName -PolicyAssignmentId $assignmentId -Name $remediationName -LocationFilter "westus2", "northcentralus"  -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20

        # Validate the remediation completed with the expected properties
        Validate-Remediation $remediation
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual "Succeeded" $remediation.ProvisioningState
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-AreEqualArray $remediation.FilterLocation @("westus2", "northcentralus")
        Assert-AreEqual 3 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment

        # Get the deployments for the remediation
        $remediation = Get-AzPolicyRemediation -ManagementGroupName $managementGroupName -Name $remediationName -IncludeDetail
        Assert-True { $remediation.Deployments.Count -gt 2 }
        $remediation.Deployments | ForEach-Object {
           Validate-RemediationDeployment $_
        }

        # Get the deployments for the remediation (+ top filter)
        $remediation = Get-AzPolicyRemediation -ManagementGroupName $managementGroupName -Name $remediationName -IncludeDetail -Top 1
        Assert-AreEqual 1 $remediation.Deployments.Count
        $remediation.Deployments | ForEach-Object {
           Validate-RemediationDeployment $_
        }

        # Get all remediations in the management group
        $remediations = Get-AzPolicyRemediation -ManagementGroupName $managementGroupName
        Assert-True { $remediations.Count -gt 0 }
        Validate-Remediation $remediations[0]

        # Get a limited number of remediations
        $remediations = Get-AzPolicyRemediation -Top 1
        Assert-AreEqual 1 $remediations.Count
        Validate-Remediation $remediations[0]
  
        # Get all remediations for a specific assignment
        $remediations = Get-AzPolicyRemediation -ManagementGroupName $managementGroupName -Filter "PolicyAssignmentId eq '$assignmentId'"
        Assert-True { $remediations.Count -gt 0 }
        $remediations | ForEach-Object {
           Validate-Remediation $_
           Assert-AreEqual $assignmentId $_.PolicyAssignmentId
        }

        # Delete the remediation that was created initially
        $result = (Remove-AzPolicyRemediation -ResourceId $remediation.Id -PassThru)
        Assert-AreEqual $true $result

        # Create a new remediation to test NoWait
        $remediation = Start-AzPolicyRemediation -ManagementGroupName $managementGroupName -PolicyAssignmentId $assignmentId -Name $remediationName -LocationFilter "westus2", "northcentralus"  -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20 -NoWait
        Validate-Remediation $remediation
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-Null $remediation.PolicyDefinitionReferenceId
        Assert-AreEqual "Accepted" $remediation.ProvisioningState
        Assert-AreEqualArray $remediation.FilterLocation @("westus2", "northcentralus")
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment

        # Cancel the remediation
        Stop-AzPolicyRemediation -ManagementGroupName $managementGroupName -Name $remediationName

        # Get the remediation that was just canceled
        $remediation = Get-AzPolicyRemediation -ManagementGroupName $managementGroupName -Name $remediationName
        Validate-Remediation $remediation
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-AreEqual "Canceled" $remediation.ProvisioningState
        Assert-AreEqualArray $remediation.FilterLocation @("westus2", "northcentralus")
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment
    }

    It 'ReEvaluateCompliance' {
        $assignmentId = $remediationSubAssignmentId
        $remediationName = "Remediation-ReEvaluateCompliance"
        $resourceGroupName = $env.emptyRgName

        # Create a new remediation
        $remediation = Start-AzPolicyRemediation -ResourceGroupName $resourceGroupName -PolicyAssignmentId $assignmentId -Name $remediationName -ResourceDiscoveryMode ReEvaluateCompliance -NoWait
        Validate-Remediation $remediation
        Assert-AreEqual "ReEvaluateCompliance" $remediation.ResourceDiscoveryMode
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-Null $remediation.PolicyDefinitionReferenceId
        Assert-AreEqual "Accepted" $remediation.ProvisioningState
        Assert-Null $remediation.Filters
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment

        # Cancel the remediation
        Stop-AzPolicyRemediation -ResourceId $remediation.Id

        # Get the remediation that was just cancelled
        $remediation = Get-AzPolicyRemediation -ResourceGroupName $resourceGroupName -Name $remediationName
        Validate-Remediation $remediation
        Assert-AreEqual "ReEvaluateCompliance" $remediation.ResourceDiscoveryMode
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-AreEqual "Canceled" $remediation.ProvisioningState
        Assert-Null $remediation.Filters
        Assert-AreEqual 0 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment

        # Delete the remediation that was created initially
        $result = (Remove-AzPolicyRemediation -ResourceGroupName $resourceGroupName -Name $remediationName -PassThru)
        Assert-AreEqual $true $result
    }

    It 'ErrorHandling' {
        $assignmentId = $remediationMgAssignmentId
        $remediationName = "Remediation-ErrorHandling"

        # Attempt to request compliance re-evaluation at MG scope, should fail
        Assert-ThrowsContains `
        { Start-AzPolicyRemediation -ManagementGroupName $managementGroupName -PolicyAssignmentId $assignmentId -Name $remediationName -ResourceDiscoveryMode ReEvaluateCompliance } `
           "[InvalidCreateRemediationRequest] : The request to create remediation '$remediationName' is invalid. Evaluating compliance before remediation is only supported for remediations at subscription scope and below."
    }
}