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
    [OutputType([Microsoft.AzureStack.Management.Subscription.Models.SubscriptionModel])]
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

            # Validate this resource does not exist
            if ($null -ne (Get-AzsSubscription -SubscriptionId $SubscriptionId -ErrorAction SilentlyContinue)) {
                Write-Error "A subscription with identifier $SubscriptionId already exists."
                return
            }

            $NewServiceClient_params = @{
                FullClientTypeName = 'Microsoft.AzureStack.Management.Subscription.SubscriptionClient'
            }
            $GlobalParameterHashtable = @{}
            $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
            $SubscriptionClient = New-ServiceClient @NewServiceClient_params

            $flattenedParameters = @('OfferId', 'Id', 'SubscriptionId', 'State', 'TenantId', 'DisplayName')
            $utilityCmdParams = @{}
            $flattenedParameters | ForEach-Object {
                if ($PSBoundParameters.ContainsKey($_)) {
                    $utilityCmdParams[$_] = $PSBoundParameters[$_]
                }
            }
            $NewSubscription = New-SubscriptionObject @utilityCmdParams

            Write-Verbose -Message 'Performing operation create on $SubscriptionClient.'
            $TaskResult = $SubscriptionClient.Subscriptions.CreateOrUpdateWithHttpMessagesAsync($SubscriptionId, $NewSubscription)

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

