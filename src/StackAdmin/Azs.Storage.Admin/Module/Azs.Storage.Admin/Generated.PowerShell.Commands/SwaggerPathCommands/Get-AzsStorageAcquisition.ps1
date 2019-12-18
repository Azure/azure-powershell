<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Returns a list of blob acquistions.

.PARAMETER Location
    Resource location.

.EXAMPLE

	PS C:\> Get-AzsStorageAcquisition

    Get the list of blob acquistions.

#>
function Get-AzsStorageAcquisition {
    [OutputType([Microsoft.AzureStack.Management.Storage.Admin.Models.Acquisition])]
    [CmdletBinding(DefaultParameterSetName = 'List')]
    param(    
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [System.String]
        $Location
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

        $GlobalParameterHashtable = @{ }
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
     
        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }

        $StorageAdminClient = New-ServiceClient @NewServiceClient_params

        if ([System.String]::IsNullOrEmpty($Location)) {
            $Location = (Get-AzureRmLocation).Location
        }

        if ('List' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $StorageAdminClient.'
            $TaskResult = $StorageAdminClient.Acquisitions.ListWithHttpMessagesAsync($Location)
        }
        else {
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

