<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Creates a new offer.

.DESCRIPTION
    Create or update the offer.

.PARAMETER Name
    Name of an offer.

.PARAMETER MaxSubscriptionsPerAccount
    Maximum subscriptions per account.

.PARAMETER DisplayName
    Display name of offer.

.PARAMETER BasePlanIds
    Identifiers of the base plans that become available to the tenant immediately when a tenant subscribes to the offer.

.PARAMETER Description
    Description of offer.

.PARAMETER ResourceGroupName
    The resource group the resource is located under.

.PARAMETER ExternalReferenceId
    External reference identifier.

.PARAMETER State
    Offer accessibility state.

.PARAMETER Location
    Location of the resource.

.PARAMETER SubscriptionCount
    Current subscription count.

.PARAMETER AddonPlanDefinition
    References to add-on plans that a tenant can optionally acquire as a part of the offer.

.EXAMPLE

    PS C:\> New-AzsOffer -Name offer1 -ResourceGroupName rg1 -State Public -DisplayName "offer1" -BasePlanIds "/subscriptions/0a823c45-d9e7-4812-a138-74e22213693a/resourceGroups/rg1/providers/Microsoft.Subscriptions.Admin/plans/plan1"

    Creates a new offer.

#>
function New-AzsOffer {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Offer])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [string]
        $DisplayName,

        [Parameter(Mandatory = $true)]
        [ValidateLength(1, 90)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $false)]
        [string[]]
        $BasePlanIds,

        [Parameter(Mandatory = $false)]
        [string]
        $Description,

        [Parameter(Mandatory = $false)]
        [string]
        $ExternalReferenceId,

        [Parameter(Mandatory = $false)]
        [ValidateSet('Private', 'Public', 'Decommissioned')]
        [string]
        $State,

        [Parameter(Mandatory = $false)]
        [string]
        [Alias("ArmLocation")]
        $Location,

        [Parameter(Mandatory = $false)]
        [int64]
        $MaxSubscriptionsPerAccount,

        [Parameter(Mandatory = $false)]
        [int64]
        $SubscriptionCount,

        [Parameter(Mandatory = $false)]
        [Microsoft.AzureStack.Management.Subscriptions.Admin.Models.AddonPlanDefinition[]]
        $AddonPlanDefinition
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

        if ([String]::IsNullOrEmpty($Location)) {
            $Location = (Get-AzureRMLocation).Location
            $PSBoundParameters.Add("Location", $Location)
        }

        if (-not $PSBoundParameters.ContainsKey('State')) {
            $State = "Private"
            $PSBoundParameters.Add("State", $State)
        }

        $flattenedParameters = @('MaxSubscriptionsPerAccount', 'BasePlanIds', 'DisplayName', 'Name', 'Description', 'ExternalReferenceId', 'State', 'Location', 'SubscriptionCount', 'AddonPlanDefinition')
        $utilityCmdParams = @{}
        $flattenedParameters | ForEach-Object {
            if ($PSBoundParameters.ContainsKey($_)) {
                $utilityCmdParams[$_] = $PSBoundParameters[$_]
            }
        }

        $NewOffer = New-OfferObject @utilityCmdParams

        Write-Verbose -Message 'Performing operation CreateOrUpdateWithHttpMessagesAsync on $SubscriptionsAdminClient.'
        $TaskResult = $SubscriptionsAdminClient.Offers.CreateOrUpdateWithHttpMessagesAsync($ResourceGroupName, $Name, $NewOffer)

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
