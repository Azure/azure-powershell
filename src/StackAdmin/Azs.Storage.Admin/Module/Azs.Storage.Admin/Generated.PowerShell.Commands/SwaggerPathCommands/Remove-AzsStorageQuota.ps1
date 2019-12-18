<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Delete an existing quota

.PARAMETER ResourceId
    The resource id.

.PARAMETER Location
    Resource location.

.PARAMETER InputObject
    The input object of type Microsoft.AzureStack.Management.Storage.Admin.Models.StorageQuota.

.PARAMETER Name
    The name of the storage quota.

.PARAMETER Force
    Do not ask for confirmation.

.EXAMPLE

    PS C:\> Remove-AzsStorageQuota -Name 'TestDeleteStorageQuota'

    Remove a storage quota by name.

.EXAMPLE

    PS C:\> Get-AzsStorageQuota -Name 'testquota' | Remove-AzsStorageQuota

    Remove a storage quota by piping.
#>
function Remove-AzsStorageQuota {
    [CmdletBinding(DefaultParameterSetName = 'Delete', SupportsShouldProcess = $true)]
    param(    
        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Delete')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject')]
        [Microsoft.AzureStack.Management.Storage.Admin.Models.StorageQuota]
        $InputObject,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Delete')]
        [Alias('QuotaName')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

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

        $quotaName = $Name

        if ('InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Storage.Admin/locations/{location}/quotas/{quotaName}'
            }

            if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
                $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            }
            else {
                $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
            }
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
            $location = $ArmResourceIdParameterValues['location']

            $quotaName = $ArmResourceIdParameterValues['quotaName']
        }

        if ($PsCmdlet.ShouldProcess("$quotaName", "Delete the storage quota")) {
            if (($Force.IsPresent -or $PSCmdlet.ShouldContinue("Delete the storage quota?", "Performing operation delete $quotaName."))) {
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

                if ([System.String]::IsNullOrEmpty($Location))
                {
                    $Location = (Get-AzureRmLocation).Location
                }
        
                if ('Delete' -eq $PsCmdlet.ParameterSetName -or 'InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation DeleteWithHttpMessagesAsync on $StorageAdminClient.'
                    $TaskResult = $StorageAdminClient.StorageQuotas.DeleteWithHttpMessagesAsync($Location, $quotaName)
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
        }
    }

    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}

