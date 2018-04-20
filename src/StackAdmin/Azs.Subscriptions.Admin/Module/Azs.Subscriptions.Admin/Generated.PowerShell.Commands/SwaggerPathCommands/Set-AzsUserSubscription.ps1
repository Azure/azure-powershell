<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Updates the specified user subscription

.DESCRIPTION
    Updates the specified user subscription

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
    Location of the resource.

.PARAMETER OfferId
    Identifier of the offer under the scope of a delegated provider.

.PARAMETER ResourceId
    The resource ID.

.PARAMETER InputObject
    The input object of type Microsoft.AzureStack.Management.Network.Admin.Models.Quota.

.PARAMETER Force
    Don't ask for confirmation.

.EXAMPLE

    PS C:\> Set-AzsUserSubscription -SubscriptionId 8e425478-c7f0-49ca-bb92-b42889ec3642 -DisplayName "NewName"

   Updates a subscription
#>
function Set-AzsUserSubscription {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Subscription])]
    [CmdletBinding(DefaultParameterSetName = 'Set', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Set')]
        [ValidateNotNullOrEmpty()]
        [System.Guid]
        $SubscriptionId,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        $DisplayName,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        $DelegatedProviderSubscriptionId,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        $Owner,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        $TenantId,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [ValidateSet('Default', 'Admin')]
        [System.String]
        $RoutingResourceManagerType,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        $ExternalReferenceId,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [ValidateSet('NotDefined', 'Enabled', 'Warned', 'PastDue', 'Disabled', 'Deleted')]
        [System.String]
        $State,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        [Alias("ArmLocation")]
        $Location,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        $OfferId,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [System.String]
        $ResourceId,

        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject')]
        [Alias('Subscription')]
        [Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Subscription]
        $InputObject,

        [Parameter(Mandatory = $false)]
        [switch]
        $Force
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

        $updatedSubscription = $null

        if ( 'InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName ) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Subscriptions.Admin/subscriptions/{targetSubscriptionId}'
            }

            if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
                $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            } else {
                $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
                $updatedSubscription = $InputObject
            }
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $SubscriptionId = $ArmResourceIdParameterValues['targetSubscriptionId']
        }

        if ($PSCmdlet.ShouldProcess("$SubscriptionId" , "Update subscription")) {
            if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Update subscription?", "Performing operation update for subscription $SubscriptionId."))) {


                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.Admin.SubscriptionsAdminClient'
                }

                $GlobalParameterHashtable = @{}
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
                $SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params

                if ([System.String]::IsNullOrEmpty($Location)) {
                    $Location = (Get-AzureRMLocation).Location
                }

                if ( 'InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName -or 'Set' -eq $PsCmdlet.ParameterSetName ) {

                    if ( $updatedSubscription -eq $null ) {
                        $updatedSubscription = Get-AzsUserSubscription | Where-Object { $_.SubscriptionId -eq $SubscriptionId }
                    }

                    $flattenedParameters = @('TenantId', 'SubscriptionId', 'DisplayName', 'DelegatedProviderSubscriptionId', 'Owner', 'RoutingResourceManagerType', 'ExternalReferenceId', 'State', 'Location', 'OfferId')
                    $flattenedParameters | ForEach-Object {
                        if ($PSBoundParameters.ContainsKey($_)) {
                            $updatedSubscription[$_] = $PSBoundParameters[$_]
                        }
                    }

                    Write-Verbose -Message 'Performing operation CreateOrUpdateWithHttpMessagesAsync on $SubscriptionsAdminClient.'
                    $TaskResult = $SubscriptionsAdminClient.Subscriptions.CreateOrUpdateWithHttpMessagesAsync($SubscriptionId, $updatedSubscription)

                } else {
                    Write-Verbose -Message 'Failed to map parameter set to operation method.'
                    throw 'Module failed to find operation to execute.'
                }

                if ($TaskResult) {
                    $GetTaskResult_params = @{
                        TaskResult = $TaskResult
                    }

                    Get-TaskResult @GetTaskResult_params
                }
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

