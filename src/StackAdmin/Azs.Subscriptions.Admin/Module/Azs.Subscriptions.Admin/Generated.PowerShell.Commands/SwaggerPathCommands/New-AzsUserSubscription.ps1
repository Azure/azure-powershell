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
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Owner,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OfferId,

        [Parameter(Mandatory = $false)]
        [System.String]
        $TenantId,

        [Parameter(Mandatory = $false)]
        [System.String]
        $DisplayName,

        [Parameter(Mandatory = $false)]
        [System.String]
        $DelegatedProviderSubscriptionId,

        [Parameter(Mandatory = $false)]
        [ValidateSet('Default', 'Admin')]
        [System.String]
        $RoutingResourceManagerType = 'Default',

        [Parameter(Mandatory = $false)]
        [System.String]
        $ExternalReferenceId,

        [Parameter(Mandatory = $false)]
        [ValidateSet('NotDefined', 'Enabled', 'Warned', 'PastDue', 'Disabled', 'Deleted')]
        [System.String]
        $State = 'Enabled',

        [Parameter(Mandatory = $false)]
        [System.String]
        $SubscriptionId = $([Guid]::NewGuid().ToString())
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



        # Use defaults so that can be documented
        if (-not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters.Add("SubscriptionId", $SubscriptionId)
        }
        if (-not $PSBoundParameters.ContainsKey('RoutingResourceManagerType')) {
            $PSBoundParameters.Add("RoutingResourceManagerType", $RoutingResourceManagerType)
        }
        if (-not $PSBoundParameters.ContainsKey('State')) {
            $PSBoundParameters.Add("State", $State)
        }

        if ($PSCmdlet.ShouldProcess("$SubscriptionId", "Create a new user subscription")) {

            # Validate this resource does not exist.
            if ($null -ne (Get-AzsUserSubscription -SubscriptionId $SubscriptionId -ErrorAction SilentlyContinue)) {
                Write-Error "A user subsription with identifier $SubscriptionId already exists."
                return
            }

            $NewServiceClient_params = @{
                FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.Admin.SubscriptionsAdminClient'
            }
            $GlobalParameterHashtable = @{}
            $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
            $SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params

            $flattenedParameters = @('TenantId', 'SubscriptionId', 'DisplayName', 'DelegatedProviderSubscriptionId', 'Owner', 'RoutingResourceManagerType', 'ExternalReferenceId', 'State', 'OfferId')
            $utilityCmdParams = @{}
            $flattenedParameters | ForEach-Object {
                if ($PSBoundParameters.ContainsKey($_)) {
                    $utilityCmdParams[$_] = $PSBoundParameters[$_]
                }
            }
            $NewSubscription = New-SubscriptionObject @utilityCmdParams

            Write-Verbose -Message 'Performing operation create on $SubscriptionsAdminClient.'
            $TaskResult = $SubscriptionsAdminClient.Subscriptions.CreateOrUpdateWithHttpMessagesAsync($SubscriptionId, $NewSubscription)

            if ($TaskResult) {
                $GetTaskResult_params = @{
                    TaskResult = $TaskResult
                }
                Get-TaskResult @GetTaskResult_params
            }
        }
    }

    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}
