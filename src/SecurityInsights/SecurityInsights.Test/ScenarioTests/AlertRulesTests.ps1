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
	$AlertRuleId = "3fefb3df-b5af-4bae-b3b9-2b32e7bb9fa9"
	$AlertRuleId2 = "3a516217-ec98-4bbf-8d00-c6d7d60095ff"
	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	$alertRule2 = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId2 -Scheduled -Enabled -DisplayName "PoshModuleTest2" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
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
	$AlertRuleId = "4324441a-de38-42c2-83dd-bb93db929e7c"
	#create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
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
	$AlertRuleId = "db5ded90-76a4-4c59-8581-1c8b7601b375"
	#remove builtin rule
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId "BuiltInFusion"
	#Create Alert Rule
	$alertrule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Fusion -Enabled -AlertRuleTemplateName $AlertRuleTemplateName
	
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
	$AlertRuleId = "b3ccc517-c3ba-4134-abd1-43256d0d9f4e"

	#Create Alert Rule
	$alertRule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -MicrosoftSecurityIncidentCreation -Enabled -AlertRuleTemplateName $AlertRuleTemplateName -DisplayName "MSICposhTest" -ProductFilter "Azure Security Center for IoT"
	
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
	$AlertRuleId = "103818ba-9f48-41af-bf1b-101f797ab82e"

	#Create Alert Rule
	$alertrule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
	# Validate
	Validate-AlertRule $alertrule

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)
}

<#
.SYNOPSIS
Update AlertRule
#>
function Update-AzSentinelAlertRule-Update
{
	$AlertRuleId = "51d3e29d-5e17-48f3-ab1f-68c0dcd010f4"
	#Create Alert Rule
	$alertrule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
	#update alert rule
	$alertrule = Update-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name) -Disabled
	
	# Validate
	Validate-AlertRule $alertrule

	#Cleanup
	Remove-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)
}

function Update-AzSentinelAlertRule-InputObject
{
	$AlertRuleId = "4037076e-479a-4d18-93f9-bcdb72f0c856"
	#Create Alert Rule
	$alertrule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	#update alert rule
	Update-AzSentinelAlertRule -InputObject $alertrule -Disabled
	$alertrule = Get-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId ($alertrule.Name)

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
	$AlertRuleId = "c0a45694-5077-4fd0-a81c-95de70659378"
	#Create Alert Rule
	$alertrule = New-AzSentinelAlertRule -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleId $AlertRuleId -Scheduled -Enabled -DisplayName "PoshModuleTest" -Severity Low -Query "SecurityAlert | take 1" -QueryFrequency (New-TimeSpan -Hours 5) -QueryPeriod (New-TimeSpan -Hours 5) -TriggerThreshold 10
	
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