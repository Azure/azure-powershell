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
Tests location completer
#>
function Test-LocationCompleter
{
	$resourceTypes = @("Microsoft.Batch/operations")
	$locations = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.LocationCompleterAttribute]::FindLocations($resourceTypes, -1)
	$expectedResourceType = (Get-AzResourceProvider -ProviderNamespace "Microsoft.Batch").ResourceTypes | Where-Object {$_.ResourceType -eq "operations"}
	$expectedLocations = $expectedResourceType.Locations | ForEach-Object {"`'" + $_ + "`'"}
	Assert-AreEqualArray $locations $expectedLocations
}


<#
.SYNOPSIS
Tests resource group completer
#>
function Test-ResourceGroupCompleter
{
	$resourceGroups = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceGroupCompleterAttribute]::GetResourceGroups(-1)
	$expectResourceGroups = Get-AzResourceGroup | ForEach-Object {$_.Name}
	Assert-AreEqualArray $resourceGroups $expectResourceGroups
}

<#
.SYNOPSIS
Tests resource id completer
#>
function Test-ResourceIdCompleter
{
    $resourceType = "Microsoft.Storage/storageAccounts"
    $expectResourceIds = Get-AzResource -ResourceType $resourceType | ForEach-Object {$_.Id}
    # take data from Azure and put to cache
    $resourceIds = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceIdCompleterAttribute]::GetResourceIds($resourceType)
    Assert-AreEqualArray $resourceIds $expectResourceIds
    # take data from the cache
    $resourceIds = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceIdCompleterAttribute]::GetResourceIds($resourceType)
    Assert-AreEqualArray $resourceIds $expectResourceIds
    # change time to update the cache
    [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceIdCompleterAttribute]::TimeToUpdate = [System.TimeSpan]::FromSeconds(0)
    # take data from Azure again and put to cache
    $resourceIds = [Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters.ResourceIdCompleterAttribute]::GetResourceIds($resourceType)
    Assert-AreEqualArray $resourceIds $expectResourceIds
}

<#
.SYNOPSIS
Tests environment completer
#>
function Test-EnvironmentCompleter
{
    $expectedEnvironments = (Get-AzEnvironment).Name

    # Test EnvironmentCompleterAttribute static method
    $environments = [Microsoft.Azure.Commands.Profile.Common.EnvironmentCompleterAttribute]::GetEnvironments()
    Assert-AreEqualArray $environments $expectedEnvironments

    # Test completion results for Connect-AzAccount
    $connectAzAccount = Get-EnvironmentCompleterResult -CmdletName 'Connect-AzAccount' -ParameterName 'Environment'
    Assert-AreEqualArray $connectAzAccount $expectedEnvironments

    # Test completion results for Set-AzEnvironment
    $setAzEnvironment = Get-EnvironmentCompleterResult -CmdletName 'Set-AzEnvironment' -ParameterName 'Name'
    Assert-AreEqualArray $setAzEnvironment $expectedEnvironments

    # Test completion results for Get-AzEnvironment
    $getAzEnvironment = Get-EnvironmentCompleterResult -CmdletName 'Get-AzEnvironment' -ParameterName 'Name'
    Assert-AreEqualArray $getAzEnvironment $expectedEnvironments

    # Test completion results for Remove-AzEnvironment
    $removeAzEnvironment = Get-EnvironmentCompleterResult -CmdletName 'Remove-AzEnvironment' -ParameterName 'Name'
    Assert-AreEqualArray $removeAzEnvironment $expectedEnvironments
}

<#
.SYNOPSIS
Helper function to get parameter completer results for specified cmdlet.
#>
function Get-EnvironmentCompleterResult
{
    param
    (
        [Parameter(Mandatory = $true)]
        [string]
        $CmdletName,

        [Parameter(Mandatory = $true)]
        [string]
        $ParameterName
    )

    $command = Get-Command -Name $CmdletName
    $environmentCompleterAttribute = $command.Parameters.$ParameterName.Attributes | Where-Object { $_.GetType() -eq [Microsoft.Azure.Commands.Profile.Common.EnvironmentCompleterAttribute]}

    return $environmentCompleterAttribute.ScriptBlock.Invoke().CompletionText
}

<#
.SYNOPSIS
Tests tenant completer
#>
function Test-TenantCompleter
{
    $expectedTenantIds = (Get-AzTenant).Id

    # Test TenantCompleterAttribute static method
    $tenantIds = [Microsoft.Azure.Commands.Profile.Common.TenantCompleterAttribute]::GetTenantIds()
    Assert-AreEqualArray $tenantIds $expectedTenantIds

    # Test completion results for Set-AzContext
    $paramTenantIds = Get-TenantCompleterResult -CmdletName 'Set-AzContext' -ParameterName 'Tenant'
    Assert-AreEqualArray $paramTenantIds $expectedTenantIds
}

<#
.SYNOPSIS
Helper function to get tenant parameter completer results for specified cmdlet.
#>
function Get-TenantCompleterResult
{
    param
    (
        [Parameter(Mandatory = $true)]
        [string]
        $CmdletName,

        [Parameter(Mandatory = $true)]
        [string]
        $ParameterName
    )

    $command = Get-Command -Name $CmdletName
    $tenantCompleterAttribute = $command.Parameters.$ParameterName.Attributes | Where-Object { $_.GetType() -eq [Microsoft.Azure.Commands.Profile.Common.TenantCompleterAttribute]}

    return $tenantCompleterAttribute.CompleteArgument($CmdletName,$ParameterName,"",$null, $null).CompletionText
}

<#
.SYNOPSIS
Tests subscription completer
#>
function Test-SubscriptionCompleter
{
    $expectedSubIds = (Get-AzSubscription).Id
    $expectedSubNames = (Get-AzSubscription).Name
    $expectedSubs = $expectedSubNames,$expectedSubIds

    $tenantIds = (Get-AzTenant).Id
    $expectedSubIds01 = Get-AzSubscription -TenantId $tenantIds[0]

    # Test SubscriptionCompleterAttribute static method
    $subIds = [Microsoft.Azure.Commands.Profile.Common.SubscriptionCompleterAttribute]::GetSubscriptions("subscriptionid")
    $subIds01 = [Microsoft.Azure.Commands.Profile.Common.SubscriptionCompleterAttribute]::GetSubscriptions("subscriptionid", $tenantIds[0])
    $subNames = [Microsoft.Azure.Commands.Profile.Common.SubscriptionCompleterAttribute]::GetSubscriptions("subscriptionname")
    $subs = [Microsoft.Azure.Commands.Profile.Common.SubscriptionCompleterAttribute]::GetSubscriptions($null)
    Assert-AreEqualArray $subIds $expectedSubIds
    Assert-AreEqualArray $subIds01 $expectedSubIds01
    Assert-AreEqualArray $subNames $expectedSubNames
    Assert-AreEqualArray $subs $expectedSubs

    # Test completion results for Set-AzContext
    # SubscriptionId and SubscriptionName as alias of the Subscription. Cannot as parameter name of the cmdlet.
    $paramSubs = (Get-SubscriptionCompleterResult -CmdletName 'Set-AzContext' -ParameterName 'Subscription') | ForEach-Object { $_.TrimStart("'").TrimEnd("'") }
    Assert-AreEqualArray $paramSubs $expectedSubs
}

<#
.SYNOPSIS
Helper function to get subscription parameter completer results for specified cmdlet.
#>
function Get-SubscriptionCompleterResult
{
    param
    (
        [Parameter(Mandatory = $true)]
        [string]
        $CmdletName,

        [Parameter(Mandatory = $true)]
        [string]
        $ParameterName
    )

    $command = Get-Command -Name $CmdletName
    $subCompleterAttribute = $command.Parameters.$ParameterName.Attributes | Where-Object { $_.GetType() -eq [Microsoft.Azure.Commands.Profile.Common.SubscriptionCompleterAttribute]}

    return $subCompleterAttribute.CompleteArgument($CmdletName,$ParameterName,"",$null, $null).CompletionText
}