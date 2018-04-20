<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Unlink a plan from an offer.

.DESCRIPTION
    Unlink a plan from an offer.

.PARAMETER PlanLinkType
    Type of the plan link.

.PARAMETER OfferName
    Name of an offer.

.PARAMETER PlanName
    Name of the plan.

.PARAMETER ResourceGroupName
    The resource group the resource is located under.

.PARAMETER MaxAcquisitionCount
    The maximum acquisition count by subscribers

.PARAMETER Force
    Flag to remove the item without confirmation.

.EXAMPLE
    Remove-AzsPlanToOffer -Offer offer1 -PlanName plan1 -ResourceGroup rg1
#>
function Remove-AzsPlanFromOffer {
    [CmdletBinding(DefaultParameterSetName = 'Offers_Unlink', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Offers_Unlink')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $PlanName,

        [Parameter(Mandatory = $true, ParameterSetName = 'Offers_Unlink')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OfferName,

        [Parameter(Mandatory = $true, ParameterSetName = 'Offers_Unlink')]
        [ValidateNotNullOrEmpty()]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $false, ParameterSetName = 'Offers_Unlink')]
        [ValidateSet('None', 'Base', 'Addon')]
        [System.String]
        $PlanLinkType,

        [Parameter(Mandatory = $false, ParameterSetName = 'Offers_Unlink')]
        [int64]
        $MaxAcquisitionCount,

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

        if ($PSCmdlet.ShouldProcess("$PlanName to $OfferName" , "Disconnect plan from offer")) {
            if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Disconnect the plan from the offer?", "Performing operation unlink plan from offer for $PlanName to $OfferName."))) {

                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.Admin.SubscriptionsAdminClient'
                }

                $GlobalParameterHashtable = @{}
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

                $GlobalParameterHashtable['SubscriptionId'] = $null
                if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                    $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
                }

                $SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params

                $flattenedParameters = @('PlanName', 'PlanLinkType', 'MaxAcquisitionCount')
                $utilityCmdParams = @{}
                $flattenedParameters | ForEach-Object {
                    if ($PSBoundParameters.ContainsKey($_)) {
                        $utilityCmdParams[$_] = $PSBoundParameters[$_]
                    }
                }
                $PlanLink = New-PlanLinkDefinitionObject @utilityCmdParams

                if ('Offers_Unlink' -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation UnlinkWithHttpMessagesAsync on $SubscriptionsAdminClient.'
                    $TaskResult = $SubscriptionsAdminClient.Offers.UnlinkWithHttpMessagesAsync($ResourceGroupName, $OfferName, $PlanLink)
                } else {
                    Write-Verbose -Message 'Failed to map parameter set to operation method.'
                    throw 'Module failed to find operation to execute.'
                }

                if ($TaskResult) {
                    $GetTaskResult_params = @{
                        TaskResult = $TaskResult
                    }

                    Get-TaskResult @GetTaskResult_params

                    if ($TaskResult.IsFaulted -ne $true) {
                        Get-AzsPlan -ResourceGroupName $ResourceGroupName -Name $PlanName
                    }
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

