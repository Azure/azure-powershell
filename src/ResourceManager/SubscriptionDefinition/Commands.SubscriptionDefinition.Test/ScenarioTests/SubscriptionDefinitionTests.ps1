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
List subscription definitions
#>
function Test-ListSubscriptionDefinitions
{
    $definitions = Get-AzureRmSubscriptionDefinition -ManagementGroupId 'ac03d01c-232b-4d97-b869-c979f8669be2'

    Assert-AreEqual 3 $definitions.Count
	Foreach($def in $definitions)
	{
		Assert-NotNull $def.Name
		Assert-NotNull $def.GroupId
		Assert-NotNull $def.SubscriptionId
	}
}

<#
.SYNOPSIS
Get subscription definition in group scope
#>
function Test-GetSubscriptionDefinitionInGroupScope
{
    $definition = Get-AzureRmSubscriptionDefinition -ManagementGroupId 'ac03d01c-232b-4d97-b869-c979f8669be2' -Name 'mySubDef'

    Assert-NotNull $definition.Name
	Assert-NotNull $definition.GroupId
	Assert-NotNull $definition.SubscriptionId
}

<#
.SYNOPSIS
Get subscription definition in subscription scope
#>
function Test-GetSubscriptionDefinitionInGroupScope
{
    $definition = Get-AzureRmSubscriptionDefinition

    Assert-NotNull $definition.Name
	Assert-NotNull $definition.GroupId
	Assert-NotNull $definition.SubscriptionId

    $definition2 = Get-AzureRmSubscription | Get-AzureRmSubscriptionDefinition

    Assert-AreEqual $definition.Name, $definition2.Name
	Assert-AreEqual $definition.GroupId, $definition2.GroupId
	Assert-AreEqual $definition.SubscriptionId, $definition2.SubscriptionId
}

<#
.SYNOPSIS
Create subscription definition
#>
function Test-NewSubscriptionDefinition
{
    $definitions = Get-AzureRmSubscriptionDefinition -ManagementGroup 'ac03d01c-232b-4d97-b869-c979f8669be2'
    $previousDefinitionCount = $definitions.Count

    $definition = New-AzureRmSubscriptionDefinition -ManagementGroupId 'ac03d01c-232b-4d97-b869-c979f8669be2' -Name 'myNewSubDef' -OfferType ''

    Assert-NotNull $definition.Name
	Assert-NotNull $definition.GroupId
	Assert-NotNull $definition.SubscriptionId

    $definitions = Get-AzureRmSubscriptionDefinition -ManagementGroup 'ac03d01c-232b-4d97-b869-c979f8669be2'
    Assert-AreEqual $definitions.Count, ($previousDefinitionCount + 1)
}
