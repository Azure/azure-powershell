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
. (Join-Path $PSScriptRoot 'Common.ps1') 'Get-AzPolicyStateSummary'


Describe 'Get-AzPolicyStateSummary' {

    BeforeAll {
        # set up commonly used variables
        $managementGroupName = $env.managementGroup
        $from = $env.fromDate
        $resourceGroupName = $env.firstRgName
        $resourceId = $env.testResourceId
        $policySetDefinitionName = $env.policySetDefName
        $policyDefinitionName = $env.auditPolicyDefName
    }

		It 'ManagementGroupScope' {
				$policyStateSummary = Get-AzPolicyStateSummary -ManagementGroupName $managementGroupName -Top 10 -From $from
				Validate-PolicyStateSummary $policyStateSummary
		}

		It 'SubscriptionScope' {
				$policyStateSummary = Get-AzPolicyStateSummary -Top 10 -From $from
				Validate-PolicyStateSummary $policyStateSummary
		}

		It 'ResourceGroupScope' {
			$policyStateSummary = Get-AzPolicyStateSummary -ResourceGroupName $resourceGroupName -Top 10 -From $from
			Validate-PolicyStateSummary $policyStateSummary
		}

		It 'ResourceScope' {
				$policyStateSummary = Get-AzPolicyStateSummary -ResourceId $resourceId -Top 10 -From $from
				Validate-PolicyStateSummary $policyStateSummary
		}

		It 'PolicySetDefinitionScope' {
				$policyStateSummary = Get-AzPolicyStateSummary -PolicySetDefinitionName $policySetDefinitionName -Top 10
				Validate-PolicyStateSummary $policyStateSummary
		}

		It 'PolicyDefinitionScope' {
				$policyStateSummary = Get-AzPolicyStateSummary -PolicyDefinitionName $policyDefinitionName -Top 10
				Validate-PolicyStateSummary $policyStateSummary
		}

		It 'SubscriptionLevelPolicyAssignmentScope' {
				$policyAssignmentName = $env.auditAssignmentNameSub

				$policyStateSummary = Get-AzPolicyStateSummary -PolicyAssignmentName $policyAssignmentName -Top 10
				Validate-PolicyStateSummary $policyStateSummary
		}

		It 'ResourceGroupLevelPolicyAssignmentScope' {
				$policyAssignmentName = $env.auditAssignmentNameRg

				$policyStateSummary = Get-AzPolicyStateSummary -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
				Validate-PolicyStateSummary $policyStateSummary
		}

}