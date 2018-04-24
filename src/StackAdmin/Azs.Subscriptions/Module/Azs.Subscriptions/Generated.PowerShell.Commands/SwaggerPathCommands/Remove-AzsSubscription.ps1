<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Delete the specifed subscription.

.DESCRIPTION
    Delete the specifed subscription.

.PARAMETER SubscriptionId
    Id of the subscription.

.PARAMETER Force
    Remove subscription without prompting
    
.EXAMPLE

    PS C:\> Remove-AzsSubscription -SubscriptionId d387f779-85d8-40b6-8607-8306295ebff9

    Delete the specifed subscription.

#>
function Remove-AzsSubscription {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [System.String]
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

        $NewServiceClient_params = @{
            FullClientTypeName = 'Microsoft.AzureStack.Management.Subscriptions.SubscriptionsManagementClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $SubscriptionsManagementClient = New-ServiceClient @NewServiceClient_params

        if ($PSCmdlet.ShouldProcess("$SubscriptionId" , "Delete the subscription")) {
            if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Delete the subscription?", "Performing operation delete on $SubscriptionId."))) {

                Write-Verbose -Message 'Performing operation DeleteWithHttpMessagesAsync on $SubscriptionsManagementClient.'
                $TaskResult = $SubscriptionsManagementClient.Subscriptions.DeleteWithHttpMessagesAsync($SubscriptionId)
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

