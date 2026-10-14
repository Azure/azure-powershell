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
. (Join-Path $PSScriptRoot 'Common.ps1') 'Remediation-CRUD-AsJob'


Describe 'Remediation-CRUD-AsJob' -Tag 'LiveOnly' {

    BeforeAll {
        $managementGroupName = $env.managementGroup

        $remediationSubAssignmentId = $env.remediationSubPolicyAssignmentId
        $remediationMgAssignmentId = $env.remediationMgPolicyAssignmentId
        $remediationSubModifyAssignmentId = $env.remediationSubModifyPolicyAssignmentId

    }

    It 'SubscriptionScope-Crud-AsJob' {
        $assignmentId = $remediationSubAssignmentId
        $remediationName = "Remediation-SubscriptionScope-Crud"

        # Create a new remediation
        $job = Start-AzPolicyRemediation -PolicyAssignmentId $assignmentId -Name $remediationName -LocationFilter "westus2", "northcentralus" -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20 -AsJob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $remediation = $job | Receive-Job

        Validate-Remediation $remediation
        Assert-AreEqual "ExistingNonCompliant" $remediation.ResourceDiscoveryMode
        Assert-AreEqual $remediationName $remediation.Name
        Assert-AreEqual "Succeeded" $remediation.ProvisioningState
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-AreEqual 2 $remediation.FilterLocation.Count
        Assert-AreEqualArray $remediation.FilterLocation @("westus2", "northcentralus")
        Assert-AreEqual 3 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual ([float]0.9) $remediation.FailureThresholdPercentage
        Assert-AreEqual 3 $remediation.ResourceCount
        Assert-AreEqual 20 $remediation.ParallelDeployment

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
        $job = ($remediation | Stop-AzPolicyRemediation -AsJob)
        $job | Wait-Job

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

    It 'ResourceGroupScope-Crud-AsJob' {
        $assignmentId = $remediationSubAssignmentId
        $remediationName = "Remediation-ResourceGroupScope-Crud"
        $resourceGroupName = $env.firstRgName

        # Create a new remediation
        $job = Start-AzPolicyRemediation -ResourceGroupName $resourceGroupName -PolicyAssignmentId $assignmentId -Name $remediationName -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20 -AsJob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $remediation = $job | Receive-Job

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

        # Delete the remediation that was created initially
        $result = (Remove-AzPolicyRemediation -ResourceGroupName $resourceGroupName -Name $remediationName -PassThru)
        Assert-AreEqual $true $result
    }

    It 'ResourceScope-Crud-AsJob' {
        $assignmentId = $remediationSubAssignmentId
        $remediationName = "Remediation-ResourceScope-Crud"
        $scope = $env.testResourceId

        # Create a new remediation
        $job = Start-AzPolicyRemediation -Scope $scope -PolicyAssignmentId $assignmentId -Name $remediationName -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20 -AsJob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $remediation = $job | Receive-Job

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
        $job = Stop-AzPolicyRemediation -Scope $scope -Name $remediationName -AsJob
        $job | Wait-Job

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

    It 'ManagementGroupScope-Crud-AsJob' {
        $assignmentId = $remediationMgAssignmentId
        $remediationName = "Remediation-ManagementGroupScope-Crud"

        # Create a new remediation
        $job = Start-AzPolicyRemediation -ManagementGroupName $managementGroupName -PolicyAssignmentId $assignmentId -Name $remediationName -LocationFilter "westus2", "northcentralus"  -FailureThresholdPercentage 0.9 -ResourceCount 3 -ParallelDeploymentCount 20 -AsJob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $remediation = $job | Receive-Job

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

        # Delete the remediation that was created initially
        $result = (Remove-AzPolicyRemediation -ResourceId $remediation.Id -PassThru)
        Assert-AreEqual $true $result
    }

    It 'BackgroundJobs' {
        $assignmentId = $remediationSubAssignmentId
        $remediationName = "Remediation-BackgroundJobs"

        # Create a new remediation as a job which will wait for it to complete
        $job = Start-AzPolicyRemediation -PolicyAssignmentId $assignmentId -Name $remediationName -LocationFilter "westus2" -ResourceCount 1 -AsJob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $remediation = $job | Receive-Job

        Validate-Remediation $remediation
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-Null $remediation.PolicyDefinitionReferenceId
        Assert-AreEqual "Succeeded" $remediation.ProvisioningState
        Assert-AreEqual 1 $remediation.FilterLocation.Count
        Assert-AreEqualArray $remediation.FilterLocation @("westus2")
        Assert-AreEqual 1 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 1 $remediation.DeploymentStatusSuccessfulDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment

        # Create the remediation again so we can remove/stop it in a job
        $remediation = Start-AzPolicyRemediation -PolicyAssignmentId $assignmentId -Name $remediationName -LocationFilter "northcentralus" -NoWait

        # Remove and stop the remediation in one action as a background job
        $job = ($remediation | Remove-AzPolicyRemediation -AllowStop -PassThru -AsJob)
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $result = $job | Receive-Job
        Assert-AreEqual $true $result
    }

    It 'LargeRemediation' {
        $assignmentId = $remediationSubModifyAssignmentId
        $remediationName = "Remediation-LargeRemediation"

        $job = Start-AzPolicyRemediation -PolicyAssignmentId $assignmentId -Name $remediationName -ParallelDeploymentCount 30 -ResourceCount 1010 -AsJob
        $job | Wait-Job
        Assert-AreEqual "Completed" $job.State
        $remediation = $job | Receive-Job

        Validate-Remediation $remediation
        Assert-AreEqual $assignmentId $remediation.PolicyAssignmentId
        Assert-Null $remediation.PolicyDefinitionReferenceId
        Assert-AreEqual "Succeeded" $remediation.ProvisioningState
        Assert-AreEqual 1010 $remediation.DeploymentStatusTotalDeployment
        Assert-AreEqual 1010 $remediation.DeploymentStatusSuccessfulDeployment
        Assert-AreEqual 0 $remediation.DeploymentStatusFailedDeployment
        Assert-AreEqual 30 $remediation.ParallelDeployment
        Assert-AreEqual 1010 $remediation.ResourceCount

        # Get the remediation, get different numbers of remediation deployments
        $remediation = Get-AzPolicyRemediation -Name $remediationName -IncludeDetail -Top 10
        Assert-AreEqual 10 $remediation.Deployments.Count

        $remediation = Get-AzPolicyRemediation -Name $remediationName -IncludeDetail -Top 1001
        Assert-AreEqual 1001 $remediation.Deployments.Count

        $remediation = Get-AzPolicyRemediation -Name $remediationName -IncludeDetail
        Assert-AreEqual 1010 $remediation.Deployments.Count

        # Delete the remediation that was created initially
        $result = (Remove-AzPolicyRemediation -ResourceId $remediation.Id -PassThru -AllowStop)
        Assert-AreEqual $true $result
    }
}