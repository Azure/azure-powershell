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
Get security topologies on a subscription scope
#>
function Get-AzureRmSecurityTopology-SubscriptionScope
{
    $securityTopologies = Get-AzSecurityTopology
	Validate-SecurityTopologies $securityTopologies
}

<#
.SYNOPSIS
Get security topologies
#>
function Get-AzureRmSecurityTopology-ResourceGroupLevelResource
{
	$securityTopologies = Get-AzSecurityTopology | Select -First 1
	$rgName = Extract-ResourceGroup -ResourceId $securityTopologies.Id
	$location = Extract-ResourceLocation -ResourceId $securityTopologies.Id

    $fetchedSecurityTopologies = Get-AzSecurityTopology -ResourceGroupName $rgName -Location $location -Name $securityTopologies.Name
	Validate-SecurityTopologies $fetchedSecurityTopologies
}

<#
.SYNOPSIS
Get security topologies by a resource ID
#>
function Get-AzureRmSecurityTopology-ResourceId
{
	$securityTopologies = Get-AzSecurityTopology | Select -First 1

    $securityTopologies = Get-AzSecurityTopology -ResourceId $securityTopologies.Id
	Validate-SecurityTopologies $securityTopologies
}

<#
.SYNOPSIS
Validates a list of Security Topologies
#>
function Validate-SecurityTopologies
{
	param($SecurityTopologies)

    Assert-True { $securityTopologies.Count -gt 0 }

	Foreach($SecurityTopologies in $securityTopologies)
	{
		Validate-SecurityTopologies $SecurityTopologies
	}
}

<#
.SYNOPSIS
Validates a single SecurityTopologie
#>
function Validate-SecurityTopologies
{
	param($SecurityTopologies)

	Assert-NotNull $SecurityTopologies
}