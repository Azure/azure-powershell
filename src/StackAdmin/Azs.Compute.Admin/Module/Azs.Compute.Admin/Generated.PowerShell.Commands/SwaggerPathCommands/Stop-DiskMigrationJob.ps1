<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Cancel a disk migration job.

.PARAMETER Location
    Location of the resource.

.PARAMETER MigrationId
    The migration job guid name.

#>
function Stop-DiskMigrationJob
{
    [OutputType([Microsoft.AzureStack.Management.Compute.Admin.Models.DiskMigrationJob])]
    [CmdletBinding(DefaultParameterSetName='DiskMigrationJobs_Cancel')]
    param(    
        [Parameter(Mandatory = $true, ParameterSetName = 'DiskMigrationJobs_Cancel')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'DiskMigrationJobs_Cancel')]
        [System.String]
        $MigrationId
    )

    Begin 
    {
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
        FullClientTypeName = 'Microsoft.AzureStack.Management.Compute.Admin.ComputeAdminClient'
    }

    $GlobalParameterHashtable = @{}
    $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
     
    $GlobalParameterHashtable['SubscriptionId'] = $null
    if($PSBoundParameters.ContainsKey('SubscriptionId')) {
        $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
    }

    $ComputeAdminClient = New-ServiceClient @NewServiceClient_params


    if ('DiskMigrationJobs_Cancel' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation CancelWithHttpMessagesAsync on $ComputeAdminClient.'
        $TaskResult = $ComputeAdminClient.DiskMigrationJobs.CancelWithHttpMessagesAsync($Location, $MigrationId)
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

