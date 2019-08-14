<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Update storge resource provider settings.

.PARAMETER RetentionPeriodForDeletedStorageAccountsInDays
    Set the retention days for deleted storage accounts.

.PARAMETER ResourceGroupName
    Resource group name.

.EXAMPLE

    PS C:\> Update-AzsStorageSetting -RetentionPeriodForDeletedStorageAccountsInDays 2

    Update the storage settings

#>
function Update-AzsStorageSettings {
    [OutputType([Microsoft.AzureStack.Management.Storage.Admin.Models.Settings])]
    [CmdletBinding(DefaultParameterSetName = 'Update')]
    param(   
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [ValidateLength(1, 90)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true, ParameterSetName = 'Update')]
        [ValidateRange(0, [int]::MaxValue)]
        [System.Int32]
        $RetentionPeriodForDeletedStorageAccountsInDays
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

        if ([System.String]::IsNullOrEmpty($ResourceGroupName)) {
            $ResourceGroupName = "System.$((Get-AzureRmLocation).Location)"
        }

        if ('Update' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation UpdateWithHttpMessagesAsync on $StorageAdminClient.'
            $TaskResult = $StorageAdminClient.StorageSettings.UpdateWithHttpMessagesAsync($ResourceGroupName, $RetentionPeriodForDeletedStorageAccountsInDays)
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

