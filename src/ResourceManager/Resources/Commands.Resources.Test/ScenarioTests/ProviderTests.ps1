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
    Tests registering and un-registering resource providers.
#>
function Test-AzureProvider
{
    $defaultProviders = Get-AzureRmResourceProvider
    Assert-True { $defaultProviders.Length -gt 0 }

    $allProviders = Get-AzureRmResourceProvider -ListAvailable
    Assert-True { $allProviders.Length -gt $defaultProviders.Length }

	$ErrorActionPreference = "SilentlyContinue"
	$Error.Clear()

	$nonProviders = Get-AzureRmResourceProvider -Location "abc"
	Assert-True { $Error[0].Contains("Provided location is not supported") }
	Assert-True { $nonProviders.Length -eq 0 }

	$ErrorActionPreference = "Stop"

	$globalProviders = Get-AzureRmResourceProvider -Location "global"
	Assert-True { $globalProviders.Length -gt 0 }

    Register-AzureRmResourceProvider -ProviderNamespace "Microsoft.ApiManagement"

    $endTime = [DateTime]::UtcNow.AddMinutes(5)

    while ([DateTime]::UtcNow -lt $endTime -and @(Get-AzureRmResourceProvider -ProviderNamespace "Microsoft.ApiManagement")[0].RegistrationState -ne "Registered")
    {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(1000)
    }
	$provider = Get-AzureRmResourceProvider -ProviderNamespace "Microsoft.ApiManagement"
    Assert-True { $provider[0].RegistrationState -eq "Registered" } 

    Unregister-AzureRmResourceProvider -ProviderNamespace "Microsoft.ApiManagement"

    while ([DateTime]::UtcNow -lt $endTime -and @(Get-AzureRmResourceProvider -ProviderNamespace "Microsoft.ApiManagement")[0].RegistrationState -ne "Unregistered")
    {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(1000)
    }
	$provider = Get-AzureRmResourceProvider -ProviderNamespace "Microsoft.ApiManagement"
    Assert-True { $provider[0].RegistrationState -eq "Unregistered" }
 }

 <#
    .SYNOPSIS
    Tests getting resource provider with zone mappings.
#>
function Test-AzureProvider-WithZoneMappings
{
    $testProvider = Get-AzureRmResourceProvider -ProviderNamespace "Providers.Test"
	Assert-True { $testProvider.Count -gt 0 }

	$statefulResources = $testProvider | where-object {$_.ResourceTypes.ResourceTypeName -contains "statefulResources"}

	Assert-NotNull { $statefulResources }
	Assert-NotNull { $statefulResources.ZoneMappings }

	Assert-True { $statefulResources.ZoneMappings.Count -eq 2 }
	Assert-True { $statefulResources.ZoneMappings["West Europe"] -contains "3"}
}

<#
    .SYNOPSIS
    Tests querying for a resource provider's operations/actions
#>
function Test-AzureProviderOperation
{
    # Get all operations by all providers
    $allActions = Get-AzureRmProviderOperation *
	Assert-True { $allActions.Length -gt 0 }

	# Get all operations of microsoft.insights provider
	$insightsActions = Get-AzureRmProviderOperation Microsoft.Insights/*
	$insightsActions
	Assert-True { $insightsActions.Length -gt 0 }
	Assert-True { $allActions.Length -gt $insightsActions.Length }

	# Filter non-Microsoft.Insights operations and match the lengths
	$nonInsightsActions = $allActions | Where-Object { $_.Operation.ToLower().StartsWith("microsoft.insights/") -eq $false }
	$actualLength = $allActions.Length - $nonInsightsActions.Length;
	$expectedLength = $insightsActions.Length;
	Assert-True { $actualLength -eq  $expectedLength }

	foreach ($action in $insightsActions)
	{
	    Assert-True { $action.Operation.ToLower().StartsWith("microsoft.insights/"); }
	}

	# Case insenstive search
	$insightsCaseActions = Get-AzureRmProviderOperation MicROsoFt.InSIghTs/*
	Assert-True { $insightsCaseActions.Length -gt 0 }
	Assert-True { $insightsCaseActions.Length -eq $insightsActions.Length }
	foreach ($action in $insightsCaseActions)
	{
		Assert-True { $action.Operation.ToLower().Startswith("microsoft.insights/"); }
	}

	# Get all Read operations of microsoft.insights provider
	$insightsReadActions = Get-AzureRmProviderOperation Microsoft.Insights/*/read
	Assert-True { $insightsReadActions.Length -gt 0 }
	Assert-True { $insightsActions.Length -gt $insightsReadActions.Length }
	foreach ($action in $insightsReadActions)
	{
	    Assert-True { $action.Operation.ToLower().EndsWith("/read"); }
		Assert-True { $action.Operation.ToLower().StartsWith("microsoft.insights/");}
	}

	# Get all Read operations of all providers
	$readActions = Get-AzureRmProviderOperation */read
	Assert-True { $readActions.Length -gt 0 }
	Assert-True { $readActions.Length -lt $allActions.Length }
	Assert-True { $readActions.Length -gt $insightsReadActions.Length }

	foreach ($action in $readActions)
	{
	    Assert-True { $action.Operation.ToLower().EndsWith("/read"); }
	}

	# Get a particular operation
	$action = Get-AzureRmProviderOperation Microsoft.OperationalInsights/workspaces/usages/read
	Assert-AreEqual $action.Operation.ToLower() "Microsoft.OperationalInsights/workspaces/usages/read".ToLower();

	# Get an invalid operation
	$action = Get-AzureRmProviderOperation Microsoft.OperationalInsights/workspaces/usages/read/123
	Assert-True { $action.Length -eq 0 }

	# Get operations for non-existing provider
	$exceptionMessage = "ProviderNotFound: Provider NonExistentProvider not found.";
	Assert-Throws { Get-AzureRmProviderOperation NonExistentProvider/* } $exceptionMessage

	# Get operations for non-existing provider
	Assert-Throws { Get-AzureRmProviderOperation NonExistentProvider/servers/read } $exceptionMessage

	# Get operations with invalid search string parts
	$exceptionMessage = "Individual parts in the search string should either equal * or not contain *.";
	Assert-Throws {Get-AzureRmProviderOperation Microsoft.ClassicCompute/virtual*/read } $exceptionMessage

	# Get operations with invalid provider name
	$exceptionMessage = "To get all operations under Microsoft.Sql, please specify the search string as Microsoft.Sql/*.";
	Assert-Throws {Get-AzureRmProviderOperation Microsoft.Sql } $exceptionMessage

	# Get operations with ? in search string
	$exceptionMessage = "Wildcard character ? is not supported.";
	Assert-Throws {Get-AzureRmProviderOperation Microsoft.Sql/servers/*/rea? } $exceptionMessage
 }