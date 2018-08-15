<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Returns a list of disks.

.PARAMETER ResourceId
    The resource id.

.PARAMETER InputObject
    The input object of type Microsoft.AzureStack.Management.Compute.Admin.Models.Disk.

.PARAMETER Location
    Location of the resource.

.PARAMETER Start
    The start index of disks in query.

.PARAMETER SharePath
    The source share which the resource belongs to.

.PARAMETER Count
    The maximum number of disks to return.

.PARAMETER UserSubscriptionId
    Tenant Subscription Id which the resource belongs to.

.PARAMETER Status
    The parameters of disk state.

.PARAMETER Name
    The disk guid as identity.

#>
function Get-Disk
{
    [OutputType([Microsoft.AzureStack.Management.Compute.Admin.Models.Disk])]
    [CmdletBinding(DefaultParameterSetName='Disks_List')]
    param(    
        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId_Disks_Get')]
        [System.String]
        $ResourceId,
    
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject_Disks_Get')]
        [Microsoft.AzureStack.Management.Compute.Admin.Models.Disk]
        $InputObject,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Disks_List')]
        [Parameter(Mandatory = $true, ParameterSetName = 'Disks_Get')]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Disks_List')]
        [System.Nullable`1[System.Int32]]
        $Start = $null,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Disks_List')]
        [System.String]
        $SharePath,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Disks_List')]
        [System.Nullable`1[System.Int32]]
        $Count = $null,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Disks_List')]
        [System.String]
        $UserSubscriptionId,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Disks_List')]
        [System.String]
        $Status,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Disks_Get')]
        [Alias('DiskId')]
        [System.String]
        $Name
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

    $DiskId = $Name

 
    if('InputObject_Disks_Get' -eq $PsCmdlet.ParameterSetName -or 'ResourceId_Disks_Get' -eq $PsCmdlet.ParameterSetName) {
        $GetArmResourceIdParameterValue_params = @{
            IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Compute.Admin/locations/{location}/disks/{DiskId}'
        }

        if('ResourceId_Disks_Get' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
        }
        else {
            $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
        }
        $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
        $location = $ArmResourceIdParameterValues['location']

        $DiskId = $ArmResourceIdParameterValues['DiskId']
    }

$filterInfos = @(
@{
    'Type' = 'powershellWildcard'
    'Value' = $DiskId
    'Property' = 'Name' 
})
$applicableFilters = Get-ApplicableFilters -Filters $filterInfos
if ($applicableFilters | Where-Object { $_.Strict }) {
    Write-Verbose -Message 'Performing server-side call ''Get-Disk -'''
    $serverSideCall_params = @{

}

$serverSideResults = Get-Disk @serverSideCall_params
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
    if ('Disks_List' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $ComputeAdminClient.'
        $TaskResult = $ComputeAdminClient.Disks.ListWithHttpMessagesAsync($Location, $(if ($PSBoundParameters.ContainsKey('UserSubscriptionId')) { $UserSubscriptionId } else { [NullString]::Value }), $(if ($PSBoundParameters.ContainsKey('Status')) { $Status } else { [NullString]::Value }), $(if ($PSBoundParameters.ContainsKey('SharePath')) { $SharePath } else { [NullString]::Value }), $Count, $Start)
    } elseif ('Disks_Get' -eq $PsCmdlet.ParameterSetName -or 'InputObject_Disks_Get' -eq $PsCmdlet.ParameterSetName -or 'ResourceId_Disks_Get' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $ComputeAdminClient.'
        $TaskResult = $ComputeAdminClient.Disks.GetWithHttpMessagesAsync($Location, $DiskId)
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

