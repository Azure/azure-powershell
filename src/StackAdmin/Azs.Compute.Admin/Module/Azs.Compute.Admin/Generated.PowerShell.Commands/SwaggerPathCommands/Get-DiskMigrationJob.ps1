<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Returns a list of disk migration jobs.

.PARAMETER ResourceId
    The resource id.

.PARAMETER Status
    The parameters of disk migration job status.

.PARAMETER Location
    Location of the resource.

.PARAMETER Name
    The migration job guid name.

.PARAMETER InputObject
    The input object of type Microsoft.AzureStack.Management.Compute.Admin.Models.DiskMigrationJob.

#>
function Get-DiskMigrationJob
{
    [OutputType([Microsoft.AzureStack.Management.Compute.Admin.Models.DiskMigrationJob])]
    [CmdletBinding(DefaultParameterSetName='DiskMigrationJobs_List')]
    param(    
        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId_DiskMigrationJobs_Get')]
        [System.String]
        $ResourceId,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'DiskMigrationJobs_List')]
        [System.String]
        $Status,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'DiskMigrationJobs_Get')]
        [Parameter(Mandatory = $true, ParameterSetName = 'DiskMigrationJobs_List')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'DiskMigrationJobs_Get')]
        [Alias('MigrationId')]
        [System.String]
        $Name,
    
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject_DiskMigrationJobs_Get')]
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

 
    if('InputObject_DiskMigrationJobs_Get' -eq $PsCmdlet.ParameterSetName -or 'ResourceId_DiskMigrationJobs_Get' -eq $PsCmdlet.ParameterSetName) {
        $GetArmResourceIdParameterValue_params = @{
            IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Compute.Admin/locations/{location}/diskmigrationjobs/{migrationId}'
        }

        if('ResourceId_DiskMigrationJobs_Get' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
        }
        else {
            $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
        }
        $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
        $location = $ArmResourceIdParameterValues['location']

        $migrationId = $ArmResourceIdParameterValues['migrationId']
    }

$filterInfos = @(
@{
    'Type' = 'powershellWildcard'
    'Value' = $MigrationId
    'Property' = 'Name' 
})
$applicableFilters = Get-ApplicableFilters -Filters $filterInfos
if ($applicableFilters | Where-Object { $_.Strict }) {
    Write-Verbose -Message 'Performing server-side call ''Get-DiskMigrationJob -'''
    $serverSideCall_params = @{

}

$serverSideResults = Get-DiskMigrationJob @serverSideCall_params
foreach ($serverSideResult in $serverSideResults) {
    $valid = $true
    foreach ($applicableFilter in $applicableFilters) {
        if (-not (Test-FilteredResult -Result $serverSideResult -Filter $applicableFilter.Filter)) {
            $valid = $false
            break
        }
    }

    if ($valid) {
        $serverSideResult
    }
}
return
}
    if ('DiskMigrationJobs_List' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $ComputeAdminClient.'
        $TaskResult = $ComputeAdminClient.DiskMigrationJobs.ListWithHttpMessagesAsync($Location, $(if ($PSBoundParameters.ContainsKey('Status')) { $Status } else { [NullString]::Value }))
    } elseif ('DiskMigrationJobs_Get' -eq $PsCmdlet.ParameterSetName -or 'InputObject_DiskMigrationJobs_Get' -eq $PsCmdlet.ParameterSetName -or 'ResourceId_DiskMigrationJobs_Get' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $ComputeAdminClient.'
        $TaskResult = $ComputeAdminClient.DiskMigrationJobs.GetWithHttpMessagesAsync($Location, $MigrationId)
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

