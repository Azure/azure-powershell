<#
The MIT License (MIT)

Copyright (c) 2017 Microsoft

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
#>

Import-Module -Name (Join-Path -Path $PSScriptRoot -ChildPath .. | Join-Path -ChildPath .. | Join-Path -ChildPath "GeneratedHelpers.psm1")
<#
.DESCRIPTION
    Gets a collection of SubscriberUsageAggregate, which are UsageAggregates from direct tenants.

.PARAMETER SubscriberId
    The tenant subscription identifier.

.PARAMETER ReportedStartTime
    The reported start time (inclusive).

.PARAMETER AggregationGranularity
    The aggregation granularity.

.PARAMETER ReportedEndTime
    The reported end time (exclusive).

.PARAMETER ContinuationToken
    The continuation token.

.EXAMPLE
Get-AzsSubscriberUsageAggregate -ReportedStartTime "2017-09-06T00:00:00Z" -ReportedEndTime "2017-09-07T00:00:00Z"

UsageStartTime       Type                              InstanceData
--------------       ----                              ------------
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/special/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/special/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourceGroups/special/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourceGroups/special/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/special/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/special/providers/Micro...
9/6/2017 12:00:00 AM Microsoft.Commerce/UsageAggregate {"Microsoft.Resources":{"resourceUri":"/subscriptions/36770ead-1c95-4048-8ff3-d727dd5007de/resourcegroups/special/providers/Micro...

#>
function Get-SubscriberUsageAggregate
{
    [OutputType([Microsoft.AzureStack.Management.Commerce.Admin.Models.UsageAggregate])]
    [CmdletBinding(DefaultParameterSetName='SubscriberUsageAggregates_List')]
    param(    
        [Parameter(Mandatory = $false, ParameterSetName = 'SubscriberUsageAggregates_List')]
        [System.String]
        $SubscriberId,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'SubscriberUsageAggregates_List')]
        [System.DateTime]
        $ReportedStartTime,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'SubscriberUsageAggregates_List')]
        [System.String]
        $AggregationGranularity,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'SubscriberUsageAggregates_List')]
        [System.DateTime]
        $ReportedEndTime,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'SubscriberUsageAggregates_List')]
        [System.String]
        $ContinuationToken
    )

    Begin 
    {
	    #Initialize-PSSwaggerDependencies -Azure
	}

    Process {
    
    $ErrorActionPreference = 'Stop'

    $CommerceAdminClient = Get-ServiceClient

    $skippedCount = 0
    $returnedCount = 0
    if ('SubscriberUsageAggregates_List' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $CommerceAdminClient.'
        $taskResult = $CommerceAdminClient.SubscriberUsageAggregates.ListWithHttpMessagesAsync($ReportedStartTime, $ReportedEndTime, $(if ($PSBoundParameters.ContainsKey('AggregationGranularity')) { $AggregationGranularity } else { [NullString]::Value }), $(if ($PSBoundParameters.ContainsKey('SubscriberId')) { $SubscriberId } else { [NullString]::Value }), $(if ($PSBoundParameters.ContainsKey('ContinuationToken')) { $ContinuationToken } else { [NullString]::Value }))
    } else {
        Write-Verbose -Message 'Failed to map parameter set to operation method.'
        throw 'Module failed to find operation to execute.'
    }
    
    if ($TaskResult) {
        $result = $null
        $ErrorActionPreference = 'Stop'
                    
        $null = $taskResult.AsyncWaitHandle.WaitOne()
                    
        Write-Debug -Message "$($taskResult | Out-String)"

        if($taskResult.IsFaulted)
        {
            Write-Verbose -Message 'Operation failed.'
            Throw "$($taskResult.Exception.InnerExceptions | Out-String)"
        } 
        elseif ($taskResult.IsCanceled)
        {
            Write-Verbose -Message 'Operation got cancelled.'
            Throw 'Operation got cancelled.'
        }
        else
        {
            Write-Verbose -Message 'Operation completed successfully.'

            if($taskResult.Result -and
                (Get-Member -InputObject $taskResult.Result -Name 'Body') -and
                $taskResult.Result.Body)
            {
                $result = $taskResult.Result.Body
                $result = $result.Value
                Write-Debug -Message "$($result | Out-String)"
                foreach ($item in $result) {
                    $item
                }
            }
        }
    }
    }

    End {
        
    }
}
