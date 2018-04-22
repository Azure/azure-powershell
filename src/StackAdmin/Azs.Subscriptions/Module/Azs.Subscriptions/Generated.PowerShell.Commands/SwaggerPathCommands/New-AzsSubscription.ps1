<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Create a subscription.

.DESCRIPTION
    Create a subscription.

.PARAMETER OfferId
    Identifier of the offer under the scope of a delegated provider.

.PARAMETER Id
    Fully qualified identifier.

.PARAMETER Type
    Type of resource.

.PARAMETER Tags
    List of key-value pairs.

.PARAMETER SubscriptionId
    Subscription identifier.

.PARAMETER State
    Subscription state.

.PARAMETER TenantId
    Directory tenant identifier.

.PARAMETER DisplayName
    Subscription name.

.PARAMETER Location
    Location where resource is location.

.EXAMPLE

    PS C:\> New-AzsSubscription -OfferId /delegatedProviders/default/offers/offer1

    Create a subscription.
#>
function New-AzsSubscription {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Models.Subscription])]
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OfferId,

        [Parameter(Mandatory = $false)]
        [System.String]
        $DisplayName,

        [Parameter(Mandatory = $false)]
        [System.String]
        $TenantId,

        [Parameter(Mandatory = $false)]
        [System.String]
        $SubscriptionId = $([Guid]::NewGuid().ToString()),

        [Parameter(Mandatory = $false)]
        [ValidateSet('NotDefined', 'Enabled', 'Warned', 'PastDue', 'Disabled', 'Deleted')]
        [System.String]
        $State = 'Enabled',

        [Parameter(Mandatory = $false)]
        [System.String]
        [Alias("ArmLocation")]
        $Location
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

        if ($PSBoundParameters.ContainsKey('Location')) {
            if ( $MyInvocation.Line -match "\s-ArmLocation\s") {
                Write-Warning -Message "The parameter alias ArmLocation will be deprecated in future release. Please use the parameter Location instead"
            }
        }

        # Default above so that it appears in help
        if (-not $PSBoundParameters.ContainsKey('State')) {
            $PSBoundParameters.Add("State", $State)
        }
        if (-not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters.Add("SubscriptionId", $SubscriptionId)
        }

        if ($PSCmdlet.ShouldProcess("$SubscriptionId", "Create new subscription")) {

            # Validate this resource does not exist.
            $_objectCheck = $null
            try {
                $_objectCheck = Get-AzsSubscription -SubscriptionId $SubscriptionId
            } catch {
                # No op
            } finally {
                if ($_objectCheck -ne $null) {
                    throw "A subscription with identifier $SubscriptionId already exists."
                }
            }
        
            $NewServiceClient_params = @{
                FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.SubscriptionsManagementClient'
            }
            $GlobalParameterHashtable = @{}
            $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
            $SubscriptionsManagementClient = New-ServiceClient @NewServiceClient_params

            $flattenedParameters = @('OfferId', 'Id', 'SubscriptionId', 'State', 'TenantId', 'DisplayName')
            $utilityCmdParams = @{}
            $flattenedParameters | ForEach-Object {
                if ($PSBoundParameters.ContainsKey($_)) {
                    $utilityCmdParams[$_] = $PSBoundParameters[$_]
                }
            }
            $NewSubscription = New-SubscriptionObject @utilityCmdParams

            Write-Verbose -Message 'Performing operation create on $SubscriptionsManagementClient.'
            $TaskResult = $SubscriptionsManagementClient.Subscriptions.CreateOrUpdateWithHttpMessagesAsync($SubscriptionId, $NewSubscription)

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

