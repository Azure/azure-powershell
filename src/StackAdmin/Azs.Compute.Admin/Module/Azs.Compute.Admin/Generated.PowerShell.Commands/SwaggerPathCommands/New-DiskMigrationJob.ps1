<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Create a disk migration job.

.PARAMETER ResourceId
    The resource id.

.PARAMETER Disks
    The parameters of disk list.

.PARAMETER TargetShare
    The target share name.

.PARAMETER Location
    Location of the resource.

.PARAMETER Name
    The migration job guid name.

.PARAMETER InputObject
    The input object of type Microsoft.AzureStack.Management.Compute.Admin.Models.DiskMigrationJob.

#>
function New-DiskMigrationJob
{
    [OutputType([Microsoft.AzureStack.Management.Compute.Admin.Models.DiskMigrationJob])]
    [CmdletBinding(DefaultParameterSetName='DiskMigrationJobs_Create')]
    param(    
        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId_DiskMigrationJobs_Create')]
        [System.String]
        $ResourceId,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'DiskMigrationJobs_Create')]
        [Parameter(Mandatory = $true, ParameterSetName = 'InputObject_DiskMigrationJobs_Create')]
        [Parameter(Mandatory = $true, ParameterSetName = 'ResourceId_DiskMigrationJobs_Create')]
        [System.Collections.Generic.IList`1[Microsoft.AzureStack.Management.Compute.Admin.Models.Disk]]
        $Disks,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'DiskMigrationJobs_Create')]
        [Parameter(Mandatory = $true, ParameterSetName = 'InputObject_DiskMigrationJobs_Create')]
        [Parameter(Mandatory = $true, ParameterSetName = 'ResourceId_DiskMigrationJobs_Create')]
        [System.String]
        $TargetShare,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'DiskMigrationJobs_Create')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'DiskMigrationJobs_Create')]
        [Alias('MigrationId')]
        [System.String]
        $Name,
    
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject_DiskMigrationJobs_Create')]
        [Microsoft.AzureStack.Management.Compute.Admin.Models.DiskMigrationJob]
        $InputObject
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

    $MigrationId = $Name

 
    if('InputObject_DiskMigrationJobs_Create' -eq $PsCmdlet.ParameterSetName -or 'ResourceId_DiskMigrationJobs_Create' -eq $PsCmdlet.ParameterSetName) {
        $GetArmResourceIdParameterValue_params = @{
            IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Compute.Admin/locations/{location}/diskmigrationjobs/{migrationId}'
        }

        if('ResourceId_DiskMigrationJobs_Create' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
        }
        else {
            $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
        }
        $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
        $location = $ArmResourceIdParameterValues['location']

        $migrationId = $ArmResourceIdParameterValues['migrationId']
    }


    if ('DiskMigrationJobs_Create' -eq $PsCmdlet.ParameterSetName -or 'InputObject_DiskMigrationJobs_Create' -eq $PsCmdlet.ParameterSetName -or 'ResourceId_DiskMigrationJobs_Create' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation CreateWithHttpMessagesAsync on $ComputeAdminClient.'
        $TaskResult = $ComputeAdminClient.DiskMigrationJobs.CreateWithHttpMessagesAsync($Location, $MigrationId, $TargetShare, $Disks)
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

