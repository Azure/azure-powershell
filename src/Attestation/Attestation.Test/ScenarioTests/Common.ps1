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
Creates a unique name for a resource group
#>
function Get-ResourceGroupName
{
    return getAssetName
}


<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
      Remove-AzResourceGroup -Name $rgname -Force
}

<#
.SYNOPSIS
Creates a new resource group
#>
function Create-ResourceGroup
{
	$resourceGroupName = Get-ResourceGroupName
	return New-AzResourceGroup -Name $resourceGroupName -Location WestUS
}

