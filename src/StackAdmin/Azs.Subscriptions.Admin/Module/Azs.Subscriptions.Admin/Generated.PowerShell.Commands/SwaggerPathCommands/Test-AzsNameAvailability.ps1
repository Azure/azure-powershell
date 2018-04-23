<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Returns the avaialbility of the specified subscriptions resource type and name

.DESCRIPTION
    Returns the avaialbility of the specified subscriptions resource type and name

.PARAMETER Name
    The resource name to verify.

.PARAMETER ResourceType
    The resource type to verify.

.EXAMPLE

    Test-AzsNameAvailability -ResourceType "Microsoft.Subscriptions.Admin/offers" -Name offername1

    Returns the avaialbility of the specified subscriptions resource type and name
#>
function Test-AzsNameAvailability {
    [OutputType([Microsoft.AzureStack.Management.Subscriptions.Admin.Models.CheckNameAvailabilityResponse])]
    [CmdletBinding(DefaultParameterSetName = 'Subscriptions_CheckNameAvailability')]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Subscriptions_CheckNameAvailability')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $true, ParameterSetName = 'Subscriptions_CheckNameAvailability')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceType
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

        $flattenedParameters = @('Name', 'ResourceType')
        $utilityCmdParams = @{}
        $flattenedParameters | ForEach-Object {
            if ($PSBoundParameters.ContainsKey($_)) {
                $utilityCmdParams[$_] = $PSBoundParameters[$_]
            }
        }
        $NameAvailabilityDefinition = New-CheckNameAvailabilityDefinitionObject @utilityCmdParams

        if ('Subscriptions_CheckNameAvailability' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation CheckNameAvailabilityWithHttpMessagesAsync on $SubscriptionsAdminClient.'
            $TaskResult = $SubscriptionsAdminClient.Subscriptions.CheckNameAvailabilityWithHttpMessagesAsync($NameAvailabilityDefinition)
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

