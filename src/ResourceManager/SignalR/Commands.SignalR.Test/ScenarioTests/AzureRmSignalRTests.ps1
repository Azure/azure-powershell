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
List billing periods
#>
function Test-NewAzureRmSignalR
{
	$rgName = getAssetName
	try
	{
		$signalR = New-AzureRmSignalR -Name $rgName
	}
	finally
	{
		Remove-AzureRmResourceGroup -Name $rgname -Force
	}
}

function Get-Context
{
      return [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
}

function Get-ResourcesClient
{
  param([Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext] $context)
  $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.ClientFactory
  [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext], 
	[string]
  $method = [Microsoft.Azure.Commands.Common.Authentication.IHyakClientFactory].GetMethod("CreateClient", $types)
  $closedMethod = $method.MakeGenericMethod([Microsoft.Azure.Management.Resources.ResourceManagementClient])
  $arguments = $context, [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment+Endpoint]::ResourceManager
  $client = $closedMethod.Invoke($factory, $arguments)
  return $client
}

function Remove-AzureRmResourceGroup 
{
	[CmdletBinding()]
	param(
		[string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] [alias("ResourceGroupName")] $Name,
		[switch] $Force)
	BEGIN {
		$context = Get-Context
		$client = Get-ResourcesClient $context
	}
	PROCESS {
		$deleteTask = $client.ResourceGroups.DeleteAsync($Name, [System.Threading.CancellationToken]::None)
		$rg = $deleteTask.Result
	}
	END {}
}