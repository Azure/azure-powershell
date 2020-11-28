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
List Alert Rules
#>
function Get-AzSentinelAlertRule-List
{
	
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	$alertRule2 = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest2" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
	#Get Alert Rules
    $alertrules = Get-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName)
	# Validate
	Validate-AlertRules $alertrules

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule.Name)
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertRule2.Name)
}

<#
.SYNOPSIS
Get Alert Rule
#>
function Get-AzSentinelAlertRule-Get
{
	
	#create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
	#Get Alert Rule
    $alertrule = Get-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)
	# Validate
	Validate-AlertRule $alertrule

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)
}

<#
.SYNOPSIS
Create Fusion Alert Rule
#>
function New-AzSentinelAlertRule-CreateFusion
{
    $AlertRuleTemplateName = "f71aba3d-28fb-450b-b192-4e76a83015c8"
		
	#Create Alert Rule
	$alertrule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Fusion -Enabled -AlertRuleTemplateName $AlertRuleTemplateName
	
	#Validate
	Validate-AlertRule $alertrule

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)
}

<#
.SYNOPSIS
Create Microsoft Incident Create Alert Rule
#>
function New-AzSentinelAlertRule-CreateMSIC
{
	$AlertRuleTemplateName = "a2e0eb51-1f11-461a-999b-cd0ebe5c7a72"

	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -MicrosoftSecurityIncidentCreation -Enabled -AlertRuleTemplateName $AlertRuleTemplateName -DisplayName "MSICposhTest" -ProductFilter "Azure Security Center for IoT"
	
	# Validate
	Validate-AlertRule $alertrule

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)
}

<#
.SYNOPSIS
Create Scheduled Alert Rule
#>
function New-AzSentinelAlertRule-CreateScheduled
{
	$AlertRuleTemplateName = "a2e0eb51-1f11-461a-999b-cd0ebe5c7a72"

	#Create Alert Rule
	$alertrule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
	# Validate
	Validate-AlertRule $alertrule

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)
}

<#
.SYNOPSIS
Update AlertRule
#>
function Set-AzSentinelAlertRule-Update
{
	#Create Alert Rule
	$alertrule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
	#update alert rule
	$alertrule = Set-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name) -Etag ($alertrule.Etag) -Scheduled -Enabled $false  -DisplayName ($alertrule.DisplayName) -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
	# Validate
	Validate-AlertRule $alertrule

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)
}

<#
.SYNOPSIS
Delete AlertRule
#>
function Remove-AzSentinelAlertRule-Delete
{
	#Create Alert Rule
	$alertrule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
	#delete alert rule
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)
	
	# Validate
	Validate-AlertRule $alertrule
}

<#
.SYNOPSIS
Validates a list of alert rules
#>
function Validate-AlertRules
{
	param($alertrules)

    Assert-True { $alertrules.Count -gt 0 }

	Foreach($alertrule in $alertrules)
	{
		Validate-AlertRule $alertrule
	}
}

<#
.SYNOPSIS
Validates a single alert rule
#>
function Validate-AlertRule
{
	param($alertrule)

	Assert-NotNull $alertrule
}