<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Returns the state of the garbage collection job.

.DESCRIPTION
    Returns the state of the garbage collection job.

.PARAMETER JobId
    Operation Id.

.PARAMETER ResourceGroupName
    Resource group name.

.PARAMETER FarmName
    Farm Id.

.EXAMPLE

    PS C:\> Get-AzsReclaimStorageCapacityStatus -FarmName "6ddbfe6e-8781-4a3d-b370-4a8b20a494d8" -JobId "92360f29-cd21-429d-a20b-9b11ab5902a0"

    Return information about the status of garbage collection.

#>
function Get-AzsReclaimStorageCapacityStatus {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FarmName,

        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $JobId,

        [Parameter(Mandatory = $false)]
        [ValidateLength(1, 90)]
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
        $ErrorActionPreference = 'Stop'

        $NewServiceClient_params = @{
            FullClientTypeName = 'Microsoft.AzureStack.Management.Storage.Admin.StorageAdminClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }

        $StorageAdminClient = New-ServiceClient @NewServiceClient_params

        if ([String]::IsNullOrEmpty($ResourceGroupName)) {
            $ResourceGroupName = "System.$((Get-AzureRmLocation).Location)"
        }

        Write-Verbose -Message 'Performing operation GetGarbageCollectionStateWithHttpMessagesAsync on $StorageAdminClient.'
        $TaskResult = $StorageAdminClient.Farms.GetGarbageCollectionStateWithHttpMessagesAsync($ResourceGroupName, $FarmName, $JobId)

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

