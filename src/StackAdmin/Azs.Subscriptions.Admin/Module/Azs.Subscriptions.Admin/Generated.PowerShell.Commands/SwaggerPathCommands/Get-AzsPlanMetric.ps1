<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Get the plan metrics.

.DESCRIPTION
    Get the plan metrics.

.PARAMETER ResourceGroupName
    The resource group the resource is located under.

.PARAMETER PlanName
    Name of the plan.

.EXAMPLE

    Get-AzsPlanMetric -ResourceGroupName rg1 -PlanName plan1

    Get a plan's metrics.
#>
function Get-AzsPlanMetric {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Metric])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateLength(1, 90)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $PlanName
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
        $TaskResult = $SubscriptionsAdminClient.Plans.ListMetricsWithHttpMessagesAsync($ResourceGroupName, $PlanName)

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

