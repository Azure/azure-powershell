<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Create or updates a subscription.

.DESCRIPTION
    Create or updates a subscription.

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

.PARAMETER ResourceId
    The resource ID.

.PARAMETER InputObject
    Posbbily modified network quota returned by Get-AzsNetworkQuota.

.EXAMPLE

    PS C:\> Set-AzsSubscription -SubscriptionId 2d9f5af9-3397-44fb-8700-d98762c2422a -DisplayName MyTestSub -State Enabled -OfferId /delegatedProviders/default/offers/offer1

    Create or updates a subscription.
#>
function Set-AzsSubscription {
    [OutputType([Microsoft.AzureStack.Management.Subscription.Models.SubscriptionModel])]
    [CmdletBinding(DefaultParameterSetName = 'Set', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OfferId,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        $Type,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.Collections.Generic.Dictionary[[System.String], [System.String]]]
        $Tags,

        [Parameter(Mandatory = $true, ParameterSetName = 'Set')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $SubscriptionId,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [ValidateSet('NotDefined', 'Enabled', 'Warned', 'PastDue', 'Disabled', 'Deleted')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $State,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        $TenantId,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        $DisplayName,

        [Parameter(Mandatory = $false, ParameterSetName = 'Set')]
        [System.String]
        [Alias("ArmLocation")]
        $Location,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [System.String]
        $ResourceId,

        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject')]
        [Microsoft.AzureStack.Management.Subscription.Models.SubscriptionModel]
        $InputObject
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

        $NewServiceClient_params = @{
            FullClientTypeName = 'Microsoft.AzureStack.Management.Subscription.SubscriptionClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $SubscriptionClient = New-ServiceClient @NewServiceClient_params

        $updatedSubscription = $null

        if ( 'InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName ) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}'
            }

            if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
                $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            } else {
                $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
                $updatedSubscription = $InputObject
            }
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $SubscriptionId = $ArmResourceIdParameterValues['subscriptionId']
        }

        if ($PSCmdlet.ShouldProcess("$SubscriptionId" , "Update subscription")) {

            if ('Set' -eq $PsCmdlet.ParameterSetName -or 'InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {

                if ($updatedSubscription -eq $null) {
                    $updatedSubscription = Get-AzsSubscription -SubscriptionId $SubscriptionId
                }

                $flattenedParameters = @('OfferId', 'Id', 'Type', 'Tags', 'SubscriptionId', 'State', 'TenantId', 'Location', 'DisplayName')
                $flattenedParameters | ForEach-Object {
                    if ($PSBoundParameters.ContainsKey($_)) {
                        $updatedSubscription.$($_) = $PSBoundParameters[$_]
                    }
                }

                Write-Verbose -Message 'Performing operation update on $SubscriptionClient.'
                $TaskResult = $SubscriptionClient.Subscriptions.CreateOrUpdateWithHttpMessagesAsync($SubscriptionId, $updatedSubscription)

            } else {
                Write-Verbose -Message 'Failed to map parameter set to operation method.'
                throw 'Module failed to find operation to execute.'
            }
        }

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

