<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Create or update an existing storage quota.

.PARAMETER CapacityInGb
    Maxium capacity (GB).

.PARAMETER ResourceId
    The resource id.

.PARAMETER NumberOfStorageAccounts
    Total number of storage accounts.

.PARAMETER Location
    Resource location.

.PARAMETER InputObject
    The input object of type Microsoft.AzureStack.Management.Storage.Admin.Models.StorageQuota.

.PARAMETER Name
    The name of the storage quota.

.EXAMPLE

    PS C:\> Set-AzsStorageQuota -Name 'TestUpdateStorageQuota' -CapacityInGb 123 -NumberOfStorageAccounts 10

    Update an existing storage quota by name.

.EXAMPLE

    PS C:\> Get-AzsStorageQuota -Name 'TestUpdateStorageQuota' | Set-AzsStorageQuota -CapacityInGb 123 -NumberOfStorageAccounts 10

    Update an existing storage quota by piping.

#>
function Set-AzsStorageQuota {
    [OutputType([Microsoft.AzureStack.Management.Storage.Admin.Models.StorageQuota])]
    [CmdletBinding(DefaultParameterSetName = 'Update')]
    param(    
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceId')]
        [Parameter(Mandatory = $false, ParameterSetName = 'InputObject')]
        [int32]
        $CapacityInGb,
    
        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceId')]
        [Parameter(Mandatory = $false, ParameterSetName = 'InputObject')]
        [int32]
        $NumberOfStorageAccounts,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,
    
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject')]
        [ValidateNotNullOrEmpty()]
        [Microsoft.AzureStack.Management.Storage.Admin.Models.StorageQuota]
        $InputObject,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'Update')]
        [Alias('QuotaName')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name
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

        $QuotaName = $Name
        $quotaSet = $false
        if ('InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Storage.Admin/locations/{location}/quotas/{quotaName}'
            }

            if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
                $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            }
            else {
                $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
                $Quota = $InputObject
                $quotaSet = $true
            }
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
            $Location = $ArmResourceIdParameterValues['location']

            $QuotaName = $ArmResourceIdParameterValues['quotaName']
        }

        if ([System.String]::IsNullOrEmpty($Location)) {
            $Location = (Get-AzureRMLocation).Location
        }

        if ('Update' -eq $PsCmdlet.ParameterSetName -or 'InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            # Get quota if not set
            if ($quotaSet -eq $false) {
                $Quota = Get-AzsStorageQuota -Location $Location -Name $QuotaName
            }

            $flattenedParameters = @('NumberOfStorageAccounts', 'CapacityInGb')
            $utilityCmdParams = @{ }
            $flattenedParameters | ForEach-Object {
                if ($PSBoundParameters.ContainsKey($_)) {
                    $utilityCmdParams[$_] = $PSBoundParameters[$_]
                }
            }

            $Parameters = New-StorageQuotaObject @utilityCmdParams

            Write-Verbose -Message 'Performing operation CreateOrUpdateWithHttpMessagesAsync on $StorageAdminClient.'
            $TaskResult = $StorageAdminClient.StorageQuotas.CreateOrUpdateWithHttpMessagesAsync($Location, $QuotaName, $Parameters)
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

