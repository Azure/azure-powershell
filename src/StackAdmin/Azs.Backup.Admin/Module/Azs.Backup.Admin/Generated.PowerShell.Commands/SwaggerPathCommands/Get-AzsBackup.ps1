<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Returns a backup from a location based on name.

.DESCRIPTION
    Returns a backup from a location based on name.

.PARAMETER Name
    Name of the backup.

.PARAMETER Location
    Location backed up.

.PARAMETER ResourceId
    The resource id.

.PARAMETER ResourceGroupName
    Name of the resource group.

.PARAMETER ParentResource
    Passing a backup location will return the list of all backups at that backup location.

.EXAMPLE

    PS C:\> Get-AzsBackup

    Get information sbout all Azure Stack backups.

.EXAMPLE

    PS C:\> Get-AzsBackup -Name 'backupName'

    Get information for the the specified Azure Stack backup.

#>
function Get-AzsBackup {
    [OutputType([Microsoft.AzureStack.Management.Backup.Admin.Models.Backup])]
    [CmdletBinding(DefaultParameterSetName = 'List')]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Get')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Get')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,

        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Get')]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'ParentResource')]
        [ValidateNotNullOrEmpty()]
        [Microsoft.AzureStack.Management.Backup.Admin.Models.BackupLocation]
        $ParentResource,

        [Parameter(Mandatory = $false, ParameterSetName = 'ParentResource')]
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [int]
        $Top = -1,

        [Parameter(Mandatory = $false, ParameterSetName = 'ParentResource')]
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [int]
        $Skip = -1
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



        $NewServiceClient_params = @{
            FullClientTypeName = 'Microsoft.AzureStack.Management.Backup.Admin.BackupAdminClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }

        $BackupAdminClient = New-ServiceClient @NewServiceClient_params
        if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroup}/providers/Microsoft.Backup.Admin/backupLocations/{location}/backups/{backup}'
            }
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $ResourceGroupName = $ArmResourceIdParameterValues['resourceGroup']
            $Location = $ArmResourceIdParameterValues['location']
            $Name = $ArmResourceIdParameterValues['backup']
        } elseif ('ParentResource' -eq $PsCmdlet.ParameterSetName) {

            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroup}/providers/Microsoft.Backup.Admin/backupLocations/{location}'
            }

            $GetArmResourceIdParameterValue_params['Id'] = $ParentResource.Id

            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
            $ResourceGroupName = $ArmResourceIdParameterValues['resourceGroup']
            $Location = $ArmResourceIdParameterValues['location']
        } else {

            if ([System.String]::IsNullOrEmpty($Location)) {
                $Location = (Get-AzureRMLocation).Location
            }

            if ([System.String]::IsNullOrEmpty($ResourceGroupName)) {
                $ResourceGroupName = "System.$Location"
            }
        }

        if ('List' -eq $PsCmdlet.ParameterSetName -or 'ParentResource' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $BackupAdminClient.'
            $TaskResult = $BackupAdminClient.Backups.ListWithHttpMessagesAsync($ResourceGroupName, $Location)
        } elseif ('Get' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $BackupAdminClient.'
            $TaskResult = $BackupAdminClient.Backups.GetWithHttpMessagesAsync($ResourceGroupName, $Location, $Name)
        } else {
            Write-Verbose -Message 'Failed to map parameter set to operation method.'
            throw 'Module failed to find operation to execute.'
        }

        if ($TaskResult) {
            $GetTaskResult_params = @{
                TaskResult = $TaskResult
            }

            $TopInfo = @{
                'Count' = 0
                'Max'   = $Top
            }
            $GetTaskResult_params['TopInfo'] = $TopInfo
            $SkipInfo = @{
                'Count' = 0
                'Max'   = $Skip
            }
            $GetTaskResult_params['SkipInfo'] = $SkipInfo
            $PageResult = @{
                'Result' = $null
            }
            $GetTaskResult_params['PageResult'] = $PageResult
            $GetTaskResult_params['PageType'] = 'Microsoft.Rest.Azure.IPage[Microsoft.AzureStack.Management.Backup.Admin.Models.Backup]' -as [Type]

            Get-TaskResult @GetTaskResult_params

            Write-Verbose -Message 'Flattening paged results.'
            while ($PageResult -and ($PageResult.ContainsKey('Page')) -and (Get-Member -InputObject $PageResult.Page -Name 'nextPageLink') -and $PageResult.Page.'nextPageLink' -and (($TopInfo -eq $null) -or ($TopInfo.Max -eq -1) -or ($TopInfo.Count -lt $TopInfo.Max))) {
                Write-Debug -Message "Retrieving next page: $($PageResult.Page.'nextPageLink')"
                $TaskResult = $BackupAdminClient.Backups.ListNextWithHttpMessagesAsync($PageResult.Page.'nextPageLink')
                $PageResult.Page = $null
                $GetTaskResult_params['TaskResult'] = $TaskResult
                $GetTaskResult_params['PageResult'] = $PageResult
                Get-TaskResult @GetTaskResult_params
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

