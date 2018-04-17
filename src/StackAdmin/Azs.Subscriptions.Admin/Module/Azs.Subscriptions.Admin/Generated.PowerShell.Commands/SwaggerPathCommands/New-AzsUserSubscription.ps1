<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Create a new subscription.

.DESCRIPTION
    Create a new subscription.

.PARAMETER TenantId
    Directory tenant identifier.

.PARAMETER SubscriptionId
    Subscription identifier.

.PARAMETER DisplayName
    Subscription name.

.PARAMETER DelegatedProviderSubscriptionId
    Parent DelegatedProvider subscription identifier.

.PARAMETER Owner
    Subscription owner.

.PARAMETER RoutingResourceManagerType
    Routing resource manager type.

.PARAMETER ExternalReferenceId
    External reference identifier.

.PARAMETER State
    Subscription state.

.PARAMETER Location
    Location where resource is location.

.PARAMETER OfferId
    Identifier of the offer under the scope of a delegated provider.

.PARAMETER Subscription
    Subscription parameter.

.EXAMPLE

    PS C:\> New-AzsUserSubscription -Owner user@contoso.com -OfferId "/subscriptions/302d0fcd-5263-4f4d-82ba-383ad95a3e53/resourceGroups/rg1/providers/Microsoft.Subscriptions.Admin/offers/offer1"

    Creates a new user subscription

#>
function New-AzsUserSubscription {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Subscription])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string]
        $Owner,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string]
        $OfferId,

        [Parameter(Mandatory = $false)]
        [string]
        $TenantId,

        [Parameter(Mandatory = $false)]
        [string]
        $DisplayName,

        [Parameter(Mandatory = $false)]
        [string]
        $DelegatedProviderSubscriptionId,

        [Parameter(Mandatory = $false)]
        [ValidateSet('Default', 'Admin')]
        [string]
        $RoutingResourceManagerType,

        [Parameter(Mandatory = $false)]
        [string]
        $ExternalReferenceId,

        [Parameter(Mandatory = $false)]
        [ValidateSet('NotDefined', 'Enabled', 'Warned', 'PastDue', 'Disabled', 'Deleted')]
        [string]
        $State,

        [Parameter(Mandatory = $false)]
        [System.String]
        $SubscriptionId
    )

    Begin {
        Initialize-PSSwaggerDependencies -Azure
        $tracerObject = $null
        if (('continue' -eq $DebugPreference) -or ('inquire' -eq $DebugPreference)) {
            $oldDebugPreference = $global:DebugPreference
            $global:DebugPreference = "continue"
            $tracerObject = New-PSSwaggerClientTracing
            Register-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }

    Process {

        $ErrorActionPreference = 'Stop'

        $NewServiceClient_params = @{
            FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.Admin.SubscriptionsAdminClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params

        if (-not $PSBoundParameters.ContainsKey('RoutingResourceManagerType')) {
            $RoutingResourceManagerType = "Default"
            $PSBoundParameters.Add("RoutingResourceManagerType", $RoutingResourceManagerType)
        }

        if (-not $PSBoundParameters.ContainsKey('State')) {
            $State = "Enabled"
            $PSBoundParameters.Add("State", $State)
        }

        if (-not ($PSBoundParameters.ContainsKey('SubscriptionId'))) {
            $SubscriptionId = [Guid]::NewGuid().ToString()
            $PSBoundParameters.Add("SubscriptionId", $SubscriptionId)
        }

        $flattenedParameters = @('TenantId', 'SubscriptionId', 'DisplayName', 'DelegatedProviderSubscriptionId', 'Owner', 'RoutingResourceManagerType', 'ExternalReferenceId', 'State', 'OfferId')
        $utilityCmdParams = @{}
        $flattenedParameters | ForEach-Object {
            if ($PSBoundParameters.ContainsKey($_)) {
                $utilityCmdParams[$_] = $PSBoundParameters[$_]
            }
        }
        $NewSubscription = New-SubscriptionObject @utilityCmdParams

        Write-Verbose -Message 'Performing operation CreateOrUpdateWithHttpMessagesAsync on $SubscriptionsAdminClient.'
        $TaskResult = $SubscriptionsAdminClient.Subscriptions.CreateOrUpdateWithHttpMessagesAsync($SubscriptionId, $NewSubscription)

        if ($TaskResult) {
            $GetTaskResult_params = @{
                TaskResult = $TaskResult
            }

            Get-TaskResult @GetTaskResult_params
        }
    }

    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}
