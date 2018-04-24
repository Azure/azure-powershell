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
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
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
        [System.String]
        $Description,

        [Parameter(Mandatory = $false)]
        [System.String]
        $ExternalReferenceId,

        [Parameter(Mandatory = $false)]
        [ValidateSet('Private', 'Decommissioned')]
        [System.String]
        $State = 'Private',

        [Parameter(Mandatory = $false)]
        [System.String]
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

        # Add here, use defaults above for help.
        if (-not $PSBoundParameters.ContainsKey('State')) {
            $PSBoundParameters.Add("State", $State)
        }

        if ($PSCmdlet.ShouldProcess("$Name", "Create a new offer")) {

            if ($PSBoundParameters.ContainsKey('Location')) {
                if ( $MyInvocation.Line -match "\s-ArmLocation\s") {
                    Write-Warning -Message "The parameter alias ArmLocation will be deprecated in future release. Please use the parameter Location instead"
                }
            }

            if ([System.String]::IsNullOrEmpty($Location)) {
                $Location = (Get-AzureRMLocation).Location
                $PSBoundParameters.Add("Location", $Location)
            }

            # Validate this resource does not exist.
            $_objectCheck = $null
            try {
                $_objectCheck = Get-AzsManagedOffer -Name $Name -Location $Location -ResourceGroupName $ResourceGroupName
            } catch {
                # No op
            } finally {
                if ($_objectCheck -ne $null) {
                    throw "An offer with name $Name under the resource group $ResourceGroupName at location $Location already exists."
                }
            }

            $flattenedParameters = @('MaxSubscriptionsPerAccount', 'BasePlanIds', 'DisplayName', 'Name', 'Description', 'ExternalReferenceId', 'State', 'Location', 'SubscriptionCount', 'AddonPlanDefinition')
            $utilityCmdParams = @{}
            $flattenedParameters | ForEach-Object {
                if ($PSBoundParameters.ContainsKey($_)) {
                    $utilityCmdParams[$_] = $PSBoundParameters[$_]
                }
            }
            $NewOffer = New-OfferObject @utilityCmdParams

            $NewServiceClient_params = @{
                FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.Admin.SubscriptionsAdminClient'
            }
            $GlobalParameterHashtable = @{}
            $GlobalParameterHashtable['SubscriptionId'] = $null
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
            }
            $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
            $SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params

            Write-Verbose -Message 'Performing operation create on $SubscriptionsAdminClient.'
            $TaskResult = $SubscriptionsAdminClient.Offers.CreateOrUpdateWithHttpMessagesAsync($ResourceGroupName, $Name, $NewOffer)

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
