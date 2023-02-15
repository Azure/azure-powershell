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
Get latest policy states at management group scope
#>
function Get-AzureRmPolicyState-LatestManagementGroupScope {
  $managementGroupName = Get-TestManagementGroupName
  $from = Get-TestQueryIntervalStart

  $policyStates = Get-AzPolicyState -ManagementGroupName $managementGroupName -Top 10 -From $from
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at management group scope
#>
function Get-AzureRmPolicyState-AllManagementGroupScope {
  $managementGroupName = Get-TestManagementGroupName
  $from = Get-TestQueryIntervalStart

  $policyStates = Get-AzPolicyState -All -ManagementGroupName $managementGroupName -Top 10 -From $from
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get multiple pages of policy states at management group scope
#>
function Get-AzureRmPolicyState-ManagementGroupScope-Paging {
  $managementGroupName = Get-TestManagementGroupName
  $from = Get-TestQueryIntervalStart

  # Apply filters\selection to recude the session recording size
  $policyStates = Get-AzPolicyState -ManagementGroupName $managementGroupName -Top 1001 -From $from -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
  Assert-True { $policyStates.Count -eq 1001 }

  $policyStates = Get-AzPolicyState -ManagementGroupName $managementGroupName -From $from -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
  Assert-True { $policyStates.Count -ge 1001 }
}

<#
.SYNOPSIS
Get latest policy states at subscription scope
#>
function Get-AzureRmPolicyState-LatestSubscriptionScope {
  $from = Get-TestQueryIntervalStart

  $policyStates = Get-AzPolicyState -Top 10 -From $from
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get multiple pages of policy states at subscription scope
#>
function Get-AzureRmPolicyState-SubscriptionScope-Paging {
  $from = Get-TestQueryIntervalStart

  # Apply filters\selection to recude the session recording size
  $policyStates = Get-AzPolicyState -Top 1001 -From $from -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
  Assert-True { $policyStates.Count -eq 1001 }

  $policyStates = Get-AzPolicyState -From $from -Select "Timestamp" -Filter "PolicyDefinitionAction eq 'modify'"
  Assert-True { $policyStates.Count -ge 1001 }
}

<#
.SYNOPSIS
Get all policy states at subscription scope
#>
function Get-AzureRmPolicyState-AllSubscriptionScope {
  $from = Get-TestQueryIntervalStart

  $policyStates = Get-AzPolicyState -All -Top 10 -From $from
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at resource group scope
#>
function Get-AzureRmPolicyState-LatestResourceGroupScope {
  $resourceGroupName = Get-FirstTestResourceGroupName
  $from = Get-TestQueryIntervalStart

  $policyStates = Get-AzPolicyState -ResourceGroupName $resourceGroupName -Top 10 -From $from
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at resource group scope
#>
function Get-AzureRmPolicyState-AllResourceGroupScope {
  $resourceGroupName = Get-FirstTestResourceGroupName
  $from = Get-TestQueryIntervalStart

  $policyStates = Get-AzPolicyState -All -ResourceGroupName $resourceGroupName -Top 10 -From $from
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at resource scope
#>
function Get-AzureRmPolicyState-LatestResourceScope {
  $resourceId = Get-TestResourceId
  $from = Get-TestQueryIntervalStart

  $policyStates = Get-AzPolicyState -ResourceId $resourceId -Top 10 -From $from
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at resource scope
#>
function Get-AzureRmPolicyState-AllResourceScope {
  $resourceId = Get-TestResourceId
  $from = Get-TestQueryIntervalStart

  $policyStates = Get-AzPolicyState -All -ResourceId $resourceId -Top 10 -From $from
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get latest policy states at policy set definition scope
#>
function Get-AzureRmPolicyState-LatestPolicySetDefinitionScope {
  $policySetDefinitionName = Get-TestPolicySetDefinitionName

  $policyStates = Get-AzPolicyState -PolicySetDefinitionName $policySetDefinitionName -Top 10
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at policy set definition scope
#>
function Get-AzureRmPolicyState-AllPolicySetDefinitionScope {
  $policySetDefinitionName = Get-TestPolicySetDefinitionName

  $policyStates = Get-AzPolicyState -All -PolicySetDefinitionName $policySetDefinitionName -Top 10
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get multiple pages of policy states for policy set definition
#>
function Get-AzureRmPolicyState-PolicySetDefinitionScope-Paging {
  $policySetDefinitionName = Get-TestPolicySetDefinitionName

  # Apply selection to recude session recording size
  $policyStates = Get-AzPolicyState -All -PolicySetDefinitionName $policySetDefinitionName -Top 1001 -Select "Timestamp"
  Assert-True { $policyStates.Count -eq 1001 }

  $policyStates = Get-AzPolicyState -All -PolicySetDefinitionName $policySetDefinitionName -Select "Timestamp"
  Assert-True { $policyStates.Count -ge 1001 }
}

<#
.SYNOPSIS
Get latest policy states at policy definition scope
#>
function Get-AzureRmPolicyState-LatestPolicyDefinitionScope {
  $policyDefinitionName = Get-TestAuditPolicyDefinitionName

  $policyStates = Get-AzPolicyState -PolicyDefinitionName $policyDefinitionName -Top 10
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at policy definition scope
#>
function Get-AzureRmPolicyState-AllPolicyDefinitionScope {
  $policyDefinitionName = Get-TestAuditPolicyDefinitionName

  $policyStates = Get-AzPolicyState -All -PolicyDefinitionName $policyDefinitionName -Top 10
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get multiple pages of policy states for policy definition
#>
function Get-AzureRmPolicyState-PolicyDefinitionScope-Paging {
  $policyDefinitionName = Get-TestAuditPolicyDefinitionName

  # Apply selection to recude session recording size
  $policyStates = Get-AzPolicyState -All -PolicyDefinitionName $policyDefinitionName -Top 1001 -Select "Timestamp"
  Assert-True { $policyStates.Count -eq 1001 }

  $policyStates = Get-AzPolicyState -All -PolicyDefinitionName $policyDefinitionName -Select "Timestamp"
  Assert-True { $policyStates.Count -ge 1001 }
}

<#
.SYNOPSIS
Get latest policy states at subscription level policy assignment scope
#>
function Get-AzureRmPolicyState-LatestSubscriptionLevelPolicyAssignmentScope {
  $policyAssignmentName = Get-TestSubscriptionAuditAssignmentName

  $policyStates = Get-AzPolicyState -PolicyAssignmentName $policyAssignmentName -Top 10
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at subscription level policy assignment scope
#>
function Get-AzureRmPolicyState-AllSubscriptionLevelPolicyAssignmentScope {
  $policyAssignmentName = Get-TestSubscriptionAuditAssignmentName

  $policyStates = Get-AzPolicyState -All -PolicyAssignmentName $policyAssignmentName -Top 10
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get multiple pages of policy states for policy assignment
#>
function Get-AzureRmPolicyState-PolicyAssignmentScope-Paging {
  $policyAssignmentName = Get-TestSubscriptionAuditAssignmentName

  # Apply selection to recude session recording size
  $policyStates = Get-AzPolicyState -All -PolicyAssignmentName $policyAssignmentName -Top 1001 -Select "Timestamp"
  Assert-True { $policyStates.Count -eq 1001 }

  $policyStates = Get-AzPolicyState -All -PolicyAssignmentName $policyAssignmentName -Select "Timestamp"
  Assert-True { $policyStates.Count -ge 1001 }
}

<#
.SYNOPSIS
Get latest policy states at resource group level policy assignment scope
#>
function Get-AzureRmPolicyState-LatestResourceGroupLevelPolicyAssignmentScope {
  $resourceGroupName = Get-FirstTestResourceGroupName
  $policyAssignmentName = Get-TestResourceGroupAuditAssignmentName

  $policyStates = Get-AzPolicyState -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Get all policy states at resource group level policy assignment scope
#>
function Get-AzureRmPolicyState-AllResourceGroupLevelPolicyAssignmentScope {
  $resourceGroupName = Get-FirstTestResourceGroupName
  $policyAssignmentName = Get-TestResourceGroupAuditAssignmentName

  $policyStates = Get-AzPolicyState -All -ResourceGroupName $resourceGroupName -PolicyAssignmentName $policyAssignmentName -Top 10
  Validate-PolicyStates $policyStates 10
}

<#
.SYNOPSIS
Trigger a policy compliance scan at subscription scope
#>
function Start-AzPolicyComplianceScan-SubscriptionScope {
  Assert-True { Start-AzPolicyComplianceScan -PassThru }
}

<#
.SYNOPSIS
Trigger a policy compliance scan at subscription scope
#>
function Start-AzPolicyComplianceScan-SubscriptionScope-AsJob {
  $job = Start-AzPolicyComplianceScan -PassThru -AsJob
  $job | Wait-Job
  Assert-AreEqual "Completed" $job.State
  Assert-True { $job | Receive-Job }
}

<#
.SYNOPSIS
Trigger a policy compliance scan at resource group scope
#>
function Start-AzPolicyComplianceScan-ResourceGroupScope {
		$resourceGroupName = Get-FirstTestResourceGroupName
  Assert-True { Start-AzPolicyComplianceScan -ResourceGroupName $resourceGroupName -PassThru }
}
