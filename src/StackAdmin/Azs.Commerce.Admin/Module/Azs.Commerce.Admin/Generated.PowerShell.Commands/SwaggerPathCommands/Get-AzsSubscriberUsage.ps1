<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Get usage data from during the specified timespan.

.DESCRIPTION
    Get usage data from during the specified timespan.

.PARAMETER SubscriberId
    The tenant subscription identifier.

.PARAMETER ReportedStartTime
    The reported start time (inclusive).

.PARAMETER AggregationGranularity
    The aggregation granularity.

.PARAMETER Skip
    Skip the first N items as specified by the parameter value.

.PARAMETER ReportedEndTime
    The reported end time (exclusive).

.PARAMETER ContinuationToken
    The continuation token.

.PARAMETER Top
    Return the top N items as specified by the parameter value. Applies after the -Skip parameter.

.EXAMPLE

    Get-AzsSubscriberUsage -ReportedStartTime "2017-09-06T00:00:00Z" -ReportedEndTime "2017-09-07T00:00:00Z"

    Get usage data from the last 24 hours.

#>
function Get-AzsSubscriberUsage {
    [OutputType([Microsoft.AzureStack.Management.Commerce.Admin.Models.UsageAggregate])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $false)]
        [System.String]
        $SubscriberId,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.DateTime]
        $ReportedStartTime,

        [Parameter(Mandatory = $false)]
        [System.String]
        [ValidateSet("Daily", "Hourly")]
        $AggregationGranularity,

        [Parameter(Mandatory = $false)]
        [int]
        $Skip = -1,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.DateTime]
        $ReportedEndTime,

        [Parameter(Mandatory = $false)]
        [System.String]
        $ContinuationToken,

        [Parameter(Mandatory = $false)]
        [int]
        $Top = -1
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
            FullClientTypeName = 'Microsoft.AzureStack.Management.Commerce.Admin.CommerceAdminClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }

        $CommerceAdminClient = New-ServiceClient @NewServiceClient_params

        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $CommerceAdminClient.'
        $TaskResult = $CommerceAdminClient.SubscriberUsageAggregates.ListWithHttpMessagesAsync($ReportedStartTime, $ReportedEndTime, $(if ($PSBoundParameters.ContainsKey('AggregationGranularity')) {
                    $AggregationGranularity
                } else {
                    [NullString]::Value
                }), $(if ($PSBoundParameters.ContainsKey('SubscriberId')) {
                    $SubscriberId
                } else {
                    [NullString]::Value
                }), $(if ($PSBoundParameters.ContainsKey('ContinuationToken')) {
                    $ContinuationToken
                } else {
                    [NullString]::Value
                }))

        if ($TaskResult) {
            $GetTaskResult_params = @{
                TaskResult = $TaskResult
            }

            $TopInfo = @{
                'Count' = 0
                'Max'   = $Top
            }
            $GetTaskResult_params['TopInfo'] = $TopInfo
            $SkipInfo = @{
                'Count' = 0
                'Max'   = $Skip
            }
            $GetTaskResult_params['SkipInfo'] = $SkipInfo
            $PageResult = @{
                'Result' = $null
            }
            $GetTaskResult_params['PageResult'] = $PageResult
            $GetTaskResult_params['PageType'] = 'Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.Commerce.Admin.Models.UsageAggregate]' -as [Type]
            Get-TaskResult @GetTaskResult_params

            Write-Verbose -Message 'Flattening paged results.'
            while ($PageResult -and $PageResult.Result -and (Get-Member -InputObject $PageResult.Result -Name 'nextLink') -and $PageResult.Result.'nextLink' -and (($TopInfo -eq $null) -or ($TopInfo.Max -eq -1) -or ($TopInfo.Count -lt $TopInfo.Max))) {
                $PageResult.Result = $null
                Write-Debug -Message "Retrieving next page: $($PageResult.Result.'nextLink')"
                $TaskResult = $CommerceAdminClient.SubscriberUsageAggregates.ListNextWithHttpMessagesAsync($PageResult.Result.'nextLink')
                $GetTaskResult_params['TaskResult'] = $TaskResult
                $GetTaskResult_params['PageResult'] = $PageResult
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

