<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Get the list of user subscriptions as administrator.

.DESCRIPTION
    Get the list of user subscriptions as administrator.

.PARAMETER Filter
    OData filter parameter.

.PARAMETER SubscriptionId
    Subscription Id parameter.

.EXAMPLE

    PS C:\Windows\system32> Get-AzsUserSubscription

    Get the list of user subscriptions as administrator.
#>
function Get-AzsUserSubscription {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Subscription])]
    [CmdletBinding(DefaultParameterSetName = 'List')]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Get')]
        [ValidateNotNull()]
        [System.Guid]
        $SubscriptionId,

        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [System.String]
        $Filter
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

        #$GlobalParameterHashtable['SubscriptionId'] = $null
        #if($PSBoundParameters.ContainsKey('SubscriptionId')) {
        #    $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        #}

        $SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params

        $oDataQuery = ""
        if ($Filter) {
            $oDataQuery += "&`$Filter=$Filter"
        }
        $oDataQuery = $oDataQuery.Trim("&")


        if ('List' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $SubscriptionsAdminClient.'
            $TaskResult = $SubscriptionsAdminClient.Subscriptions.ListWithHttpMessagesAsync()
        } elseif ('Get' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $SubscriptionsAdminClient.'
            $TaskResult = $SubscriptionsAdminClient.Subscriptions.GetWithHttpMessagesAsync($SubscriptionId.ToString())
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

    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}

