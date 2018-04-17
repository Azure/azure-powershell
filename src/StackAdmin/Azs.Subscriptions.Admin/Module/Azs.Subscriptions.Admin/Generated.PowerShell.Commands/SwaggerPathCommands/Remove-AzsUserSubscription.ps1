<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Removes the specified tenant subscription.

.DESCRIPTION
    Removes the specified tenant subscription.

.PARAMETER SubscriptionId
    Subscription Id parameter.

.PARAMETER Force
    Flag to remove the item without confirmation.

.EXAMPLE

    Remove-AzsUserSubscription -SubscriptionId "c90173b1-de7a-4b1d-8600-b832b0e65946"

    Remove the specified tenant subscription.
#>
function Remove-AzsUserSubscription {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [ValidateNotNull()]
        [System.Guid]
        $SubscriptionId,

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

        if ($PSCmdlet.ShouldProcess("$SubscriptionId" , "Delete user subscription")) {
            if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Delete user subscription?", "Performing operation DeleteWithHttpMessagesAsync on $SubscriptionId."))) {

                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.Admin.SubscriptionsAdminClient'
                }

                $GlobalParameterHashtable = @{}
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
                $SubscriptionsAdminClient = New-ServiceClient @NewServiceClient_params

                Write-Verbose -Message 'Performing operation DeleteWithHttpMessagesAsync on $SubscriptionsAdminClient.'
                $TaskResult = $SubscriptionsAdminClient.Subscriptions.DeleteWithHttpMessagesAsync($SubscriptionId.ToString())

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

