<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Get the offer metrics.

.DESCRIPTION
    Get the offer metrics.

.PARAMETER ResourceGroupName
    The resource group the resource is located under.

.PARAMETER OfferName
    Name of an offer.

.EXAMPLE

    PS C:\> Get-AzsOfferMetric -ResourceGroupName rg1 -OfferName offername1

    Get the offer metrics.

#>
function Get-AzsOfferMetric {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Metric])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $OfferName,

        [Parameter(Mandatory = $true)]
        [ValidateLength(1, 90)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName
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

        Write-Verbose -Message 'Performing operation ListMetricsWithHttpMessagesAsync on $SubscriptionsAdminClient.'
        $TaskResult = $SubscriptionsAdminClient.Offers.ListMetricsWithHttpMessagesAsync($ResourceGroupName, $OfferName)

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

