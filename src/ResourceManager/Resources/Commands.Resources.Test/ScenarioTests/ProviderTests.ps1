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
    $defaultProviders = Get-AzureRMResourceProvider

    Assert-True { $defaultProviders.Length -gt 0 }

    $allProviders = Get-AzureRMResourceProvider -ListAvailable

    Assert-True { $allProviders.Length -gt $defaultProviders.Length }

    Register-AzureRMResourceProvider -ProviderName "Microsoft.ApiManagement" -Force

    $endTime = [DateTime]::UtcNow.AddMinutes(5)

    while ([DateTime]::UtcNow -lt $endTime -and @(Get-AzureRMResourceProvider -ProviderName "Microsoft.ApiManagement").RegistrationState -ne "Registered")
    {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(1000)
    }

    Assert-True { @(Get-AzureRMResourceProvider -ProviderName "Microsoft.ApiManagement").RegistrationState -eq "Registered" }

    Unregister-AzureRMResourceProvider -ProviderName "Microsoft.ApiManagement" -Force

    while ([DateTime]::UtcNow -lt $endTime -and @(Get-AzureRMResourceProvider -ProviderName "Microsoft.ApiManagement").RegistrationState -ne "Unregistered")
    {
        [Microsoft.WindowsAzure.Commands.Utilities.Common.TestMockSupport]::Delay(1000)
    }

    Assert-True { @(Get-AzureRMResourceProvider -ProviderName "Microsoft.ApiManagement").RegistrationState -eq "Unregistered" }
 }

 <#
    .SYNOPSIS
    Tests querying for a resource provider's operations/actions
#>
function Test-AzureProviderOperation
{
    # Get all actions by all providers
    $allActions = Get-AzureRMProviderOperation *
	Assert-True { $allActions.Length -gt 0 }

	# Get all actions of microsoft.insights provider
	$insightsActions = Get-AzureRMProviderOperation Microsoft.Insights/*
	$insightsActions
	Assert-True { $insightsActions.Length -gt 0 }
	Assert-True { $allActions.Length -gt $insightsActions.Length }

	# Filter non-Microsoft.Insights actions and match the lengths
	$nonInsightsActions = $allActions | Where-Object { $_.Operation.ToLower().StartsWith("microsoft.insights/") -eq $false }
	$actualLength = $allActions.Length - $nonInsightsActions.Length;
	$expectedLength = $insightsActions.Length;
	Assert-True { $actualLength -eq  $expectedLength }

	foreach ($action in $insightsActions)
	{
	    Assert-True { $action.Operation.ToLower().StartsWith("microsoft.insights/"); }
	}

	# Case insenstive search
	$insightsCaseActions = Get-AzureRMProviderOperation MicROsoFt.InSIghTs/*
	Assert-True { $insightsCaseActions.Length -gt 0 }
	Assert-True { $insightsCaseActions.Length -eq $insightsActions.Length }
	foreach ($action in $insightsCaseActions)
	{
		Assert-True { $action.Operation.ToLower().Startswith("microsoft.insights/"); }
	}

	# Get all Read actions of microsoft.insights provider
	$insightsReadActions = Get-AzureRMProviderOperation Microsoft.Insights/*/read
	Assert-True { $insightsReadActions.Length -gt 0 }
	Assert-True { $insightsActions.Length -gt $insightsReadActions.Length }
	foreach ($action in $insightsReadActions)
	{
	    Assert-True { $action.Operation.ToLower().EndsWith("/read"); }
		Assert-True { $action.Operation.ToLower().StartsWith("microsoft.insights/");}
	}

	# Get all Read actions of all providers
	$readActions = Get-AzureRMProviderOperation */read
	Assert-True { $readActions.Length -gt 0 }
	Assert-True { $readActions.Length -lt $allActions.Length }
	Assert-True { $readActions.Length -gt $insightsReadActions.Length }

	foreach ($action in $readActions)
	{
	    Assert-True { $action.Operation.ToLower().EndsWith("/read"); }
	}

	# Get a particular action
	$action = Get-AzureRMProviderOperation Microsoft.OperationalInsights/workspaces/usages/read
	Assert-AreEqual $action.Operation.ToLower() "Microsoft.OperationalInsights/workspaces/usages/read".ToLower();

	# Get an invalid action
	$action = Get-AzureRMProviderOperation Microsoft.OperationalInsights/workspaces/usages/read/123
	Assert-True { $action.Length -eq 0 }

	# Get actions for non-existing provider
	$exceptionMessage = "ProviderNotFound: Provider NonExistentProvider not found.";
	Assert-Throws { Get-AzureRMProviderOperation NonExistentProvider/* } $exceptionMessage

	# Get action for non-existing provider
	Assert-Throws { Get-AzureRMProviderOperation NonExistentProvider/servers/read } $exceptionMessage
 }