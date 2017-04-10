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
Get ResourceGroup name
#>
function Get-ResourceGroupName
{
  return "RGName-" + (getAssetName)
}

<#
.SYNOPSIS
Get RelayName name
#>
function Get-RelayName
{
    return "Relay-" + (getAssetName)
}

<#
.SYNOPSIS
Get Namespace name
#>
function Get-NamespaceName
{
    return "Relay-Namespace-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid AuthorizationRule name
#>
function Get-AuthorizationRuleName
{
    return "Relay-Namespace-AuthorizationRule" + (getAssetName)	
}

<#
.SYNOPSIS
Tests Relay Namespace CheckNameAvailability operations.
#>
function OperationsListTest
{
    # Setup	
    Write-Debug "Get Operations List"
    $OperationsList = Get-AzureRmRelayOperations
	
	# Assert 
	Assert-True { $OperationsList.Count -gt 0 }

}