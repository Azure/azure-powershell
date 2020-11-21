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
List Alert Rule Templates
#>
function Get-AzSentinelAlertRuleTemplate-List
{
	#Get Alert Rule Templates
    $alertruletemplates = Get-AzSentinelAlertRuleTemplate -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName)
	# Validate
	Validate-AlertRuleTemplates $alertruletemplates
}
	

<#
.SYNOPSIS
Get Alert Rule Template
#>
function Get-AzSentinelAlertRuleTemplate-Get
{
	#Get Alert Rule Templates
    $alertruletemplates = Get-AzSentinelAlertRuleTemplate -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName)

	#Get Alert Rule Template
    $alertrule = Get-AzSentinelAlertRuleTemplate -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -AlertRuleTemplateId ($alertruletemplates[0].Name)
	# Validate
	Validate-AlertRuleTemplate $alertrule
}

<#
.SYNOPSIS
Validates a list of alert rule templates
#>
function Validate-AlertRuleTemplates
{
	param($alertruletemplates)

    Assert-True { $alertruletemplates.Count -gt 0 }

	Foreach($alertruletemplate in $alertruletemplates)
	{
		Validate-AlertRuleTemplate $alertruletemplate
	}
}

<#
.SYNOPSIS
Validates a single alert rule template
#>
function Validate-AlertRuleTemplate
{
	param($alertruletemplate)

	Assert-NotNull $alertruletemplate
}