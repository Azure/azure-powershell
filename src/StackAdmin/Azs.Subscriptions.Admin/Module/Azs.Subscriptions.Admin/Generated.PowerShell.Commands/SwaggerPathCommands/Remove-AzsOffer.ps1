<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Delete the specified offer.

.DESCRIPTION
    Delete the specified offer.

.PARAMETER Name
    Name of an offer.

.PARAMETER ResourceId
    The resource id.

.PARAMETER ResourceGroupName
    The resource group the resource is located under.

.PARAMETER Force
    Flag to remove the item without confirmation.

.EXAMPLE

    Remove-AzsOffer -Name offername1 -ResourceGroupName rg1

    Delete the specified offer.
#>
function Remove-AzsOffer {
    [CmdletBinding(DefaultParameterSetName = 'Delete', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Delete')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $true, ParameterSetName = 'Delete')]
        [ValidateLength(1, 90)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,

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

        if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Subscriptions.Admin/offers/{offer}'
            }
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $resourceGroupName = $ArmResourceIdParameterValues['resourceGroupName']
            $Name = $ArmResourceIdParameterValues['offer']
        }

        if ($PSCmdlet.ShouldProcess("$Name" , "Delete offer")) {
            if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Delete offer?", "Performing operation DeleteWithHttpMessagesAsync on $Name."))) {

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

                if ('Delete' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation DeleteWithHttpMessagesAsync on $SubscriptionsAdminClient.'
                    $TaskResult = $SubscriptionsAdminClient.Offers.DeleteWithHttpMessagesAsync($ResourceGroupName, $Name)
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

