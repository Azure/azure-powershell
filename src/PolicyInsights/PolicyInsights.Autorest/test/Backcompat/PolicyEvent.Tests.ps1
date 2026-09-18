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
. (Join-Path $PSScriptRoot 'Common.ps1') 'Get-AzPolicyEvent'


Describe 'Get-AzPolicyEvent' {

    BeforeAll {
        $managementGroupName = $env.managementGroup
        $from = $env.fromDate
        $resourceGroupName = $env.firstRgName
    }

    It 'ManagementGroupScope' {
        $policyEvents = Get-AzPolicyEvent -ManagementGroupName $managementGroupName -Top 10 -From $from
        Validate-PolicyEvents $policyEvents 10
    }

    It 'ManagementGroupScope-Paging' {
        # Apply filters\selection to recude the session recording size
        $policyEvents = Get-AzPolicyEvent -ManagementGroupName $managementGroupName -From $from -Top 1001 -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
        Assert-True { $policyEvents.Count -eq 1001 }

        $policyEvents = Get-AzPolicyEvent -ManagementGroupName $managementGroupName -From $from  -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
        Assert-True { $policyEvents.Count -ge 1001 }
    }

    It 'SubscriptionScope' {
        $policyEvents = Get-AzPolicyEvent -Top 10 -From $from
        Validate-PolicyEvents $policyEvents 10
    }

    It 'SubscriptionScope-Paging' {
        # Apply filters\selection to recude the session recording size
        $policyEvents = Get-AzPolicyEvent -Top 1001 -From $from  -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
        Assert-True { $policyEvents.Count -eq 1001 }

        $policyEvents = Get-AzPolicyEvent -From $from  -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
        Assert-True { $policyEvents.Count -ge 1001 }
    }

    It 'ResourceGroupScope' {
        $policyEvents = Get-AzPolicyEvent -ResourceGroupName $resourceGroupName -Top 10 -From $from
        Validate-PolicyEvents $policyEvents 10
    }

    It 'ResourceScope' {
        $resourceId = $env.testResourceId

        $policyEvents = Get-AzPolicyEvent -ResourceId $resourceId -Top 10 -From $from
        Validate-PolicyEvents $policyEvents 10
    }

    It 'PolicySetDefinitionScope' {
        $policySetDefinitionName = $env.policySetDefName

        $policyEvents = Get-AzPolicyEvent -PolicySetDefinitionName $policySetDefinitionName -Top 10 -From $from
        Validate-PolicyEvents $policyEvents 10
    }

    It 'PolicyDefinitionScope' {
        $policyDefinitionName = $env.auditPolicyDefName

        $policyEvents = Get-AzPolicyEvent -PolicyDefinitionName $policyDefinitionName -Top 10
        Validate-PolicyEvents $policyEvents 10
    }

    It 'SubscriptionLevelPolicyAssignmentScope' {
        $policyAssignmentName = $env.auditAssignmentNameSub

        $policyEvents = Get-AzPolicyEvent -PolicyAssignmentName $policyAssignmentName -Top 10 -From $from
        Validate-PolicyEvents $policyEvents 10
    }

    It 'ResourceGroupLevelPolicyAssignmentScope' {
        $policyAssignmentName = $env.auditAssignmentNameRg

        $policyEvents = Get-AzPolicyEvent -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
        Validate-PolicyEvents $policyEvents 10
    }
}