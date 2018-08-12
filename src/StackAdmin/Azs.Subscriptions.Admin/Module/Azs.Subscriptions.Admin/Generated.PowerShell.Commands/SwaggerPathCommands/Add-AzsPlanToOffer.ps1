<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Links a plan to an offer.

.DESCRIPTION
    Links a plan to an offer.

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
    Add-AzsPlanToOffer -PlanLinkType Addon -Offer offer1 -PlanName plan1 -ResourceGroupName rg1 -MaxAcquisitionCount 2
#>
function Add-AzsPlanToOffer {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $PlanName,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OfferName,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $false)]
        [ValidateSet('None', 'Base', 'Addon')]
        [System.String]
        $PlanLinkType,

        [Parameter(Mandatory = $false)]
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

        if ($PSCmdlet.ShouldProcess("$PlanName to $OfferName" , "Connect plan to offer")) {

            $_offer = Get-AzsManagedOffer -Name $OfferName -ResourceGroupName $ResourceGroupName
            $_planId = $_offer.BasePlanIds | Where-Object { $_ -like "*$PlanName" }
            if ($null -ne (Get-AzsPlan -ResourceId $_planId -ErrorAction SilentlyContinue)) {
                Write-Error "A plan with the name $Name under the offer $Offername in the resource group $resourceGroupName already exists"
                return
            }

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

            Write-Verbose -Message 'Performing operation link on $SubscriptionsAdminClient.'
            $TaskResult = $SubscriptionsAdminClient.Offers.LinkWithHttpMessagesAsync($ResourceGroupName, $OfferName, $PlanLink)

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
    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}

