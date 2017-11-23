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
    $definitions = Get-AzureRmSubscriptionDefinition

    Assert-AreEqual 4 $definitions.Count
	Foreach($def in $definitions)
	{
		Assert-NotNull $def.Name
	}
}

<#
.SYNOPSIS
Get subscription definition by name
#>
function Test-GetSubscriptionDefinitionByName
{
    $definition = Get-AzureRmSubscriptionDefinition -Name "MyProdSubscription"
    Assert-AreEqual "MyProdSubscription" $definition.Name
    Assert-AreEqual "MyProdSubscription" $definition.SubscriptionDisplayName
}

<#
.SYNOPSIS
Create subscription definition
#>
function Test-NewSubscriptionDefinition
{
    $definitions = Get-AzureRmSubscriptionDefinition
    $previousDefinitionCount = $definitions.Count

    $myNewSubDefName = "MyProdSubDef99"

    $definition = New-AzureRmSubscriptionDefinition -Name $myNewSubDefName -OfferType "MS-AZR-0017P"

    Assert-AreEqual $myNewSubDefName $definition.Name
    Assert-AreEqual $myNewSubDefName $definition.SubscriptionDisplayName
	Assert-NotNull $definition.SubscriptionId

    $definitions = Get-AzureRmSubscriptionDefinition
    Assert-AreEqual $definitions.Count ($previousDefinitionCount + 1)
}
