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
Gets a Data Lake Store account name to use for testing
#>
function Get-PowerBIEmbeddedCapacityName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets a resource group name for testing.
#>
function Get-ResourceGroupName
{
    return getAssetName;
}

<#
.SYNOPSIS
Gets resource location for testing.
#>
function Get-Location
{
	if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne `
        [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback)
	{
		$namespace = "Microsoft.PowerBIDedicated"
		$type = "capacities"
		$location = Get-AzureRmResourceProvider -ProviderNamespace $namespace `
        | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

		if ($location -eq $null)
		{
			return "West Central US"
		} else
		{
			return $location.Locations[0]
		}
	}
	return "West Central US"
}

<#
.SYNOPSIS
Gets a resource group location for testing.
#>
function Get-RG-Location
{
	return "West US"
}

<#
.SYNOPSIS
Executes a cmdlet and enables ignoring of errors if desired
NOTE: this only catches errors that are thrown. If the command calls to Write-Error
the user must specify the errorAction to be silent or store the record in an error variable.
#>
function Invoke-HandledCmdlet
{
	param
	(
		[ScriptBlock] $Command,
		[switch] $IgnoreFailures
	)
	
	try
	{
		&$Command
	}
	catch
	{
		if(!$IgnoreFailures)
		{
			throw;
		}
	}
}