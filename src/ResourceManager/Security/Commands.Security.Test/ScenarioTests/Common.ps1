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
Gets test resource group name
#>
function Get-TestResourceGroupName
{
	"myService1"
}

<#
.SYNOPSIS
Gets test resource group name
#>
function Extract-ResourceLocation{
param(
	[string]$ResourceId
)
	$match = [Regex]::Match($ResourceId, "locations/(.*?)/")

	return $match.Captures.Groups[1].Value
}

<#
.SYNOPSIS
Gets test resource group name
#>
function Extract-ResourceGroup{
param(
	[string]$ResourceId
)
	$match = [Regex]::Match($ResourceId, "resourceGroups/(.*?)/")

	return $match.Captures.Groups[1].Value
}