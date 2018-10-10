<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Create a new storage quota.

.DESCRIPTION
    Create a new storage quota.

.PARAMETER CapacityInGb
    Maxium capacity (GB).

.PARAMETER NumberOfStorageAccounts
    Total number of storage accounts.

.PARAMETER Location
    Resource location.

.PARAMETER Name
    The name of the storage quota.

.EXAMPLE

	PS C:\> New-AzsStorageQuota -CapacityInGb 1000 -NumberOfStorageAccounts 100 -Name 'TestCreateStorageQuota'

    Create a new storage quota with specified values.

#>
function New-AzsStorageQuota {
    [OutputType([Microsoft.AzureStack.Management.Storage.Admin.Models.StorageQuota])]
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false)]
        [int32]
        $CapacityInGb = 500,

        [Parameter(Mandatory = $false)]
        [int32]
        $NumberOfStorageAccounts = 20,

        [Parameter(Mandatory = $false)]
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



        if ($PSCmdlet.ShouldProcess("$Name", "Create a storage quota")) {

            if ([System.String]::IsNullOrEmpty($Location)) {
                $Location = (Get-AzureRMLocation).Location
            }

            # Validate this resource does not exist.
            if ($null -ne (Get-AzsStorageQuota -Name $Name -Location $Location -ErrorAction SilentlyContinue)) {
                Write-Error "A storage quota with the name $Name at location $location already exists"
                return
            }

            $flattenedParameters = @('NumberOfStorageAccounts', 'CapacityInGb')
            $utilityCmdParams = @{}
            $flattenedParameters | ForEach-Object {
                if ($PSBoundParameters.ContainsKey($_)) {
                    $utilityCmdParams[$_] = $PSBoundParameters[$_]
                }
            }
            $Parameters = New-StorageQuotaObject @utilityCmdParams

            $NewServiceClient_params = @{
                FullClientTypeName = 'Microsoft.AzureStack.Management.Storage.Admin.StorageAdminClient'
            }
            $GlobalParameterHashtable = @{}
            $GlobalParameterHashtable['SubscriptionId'] = $null
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
            }
            $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
            $StorageAdminClient = New-ServiceClient @NewServiceClient_params

            Write-Verbose -Message 'Performing operation create on $StorageAdminClient.'
            $TaskResult = $StorageAdminClient.StorageQuotas.CreateOrUpdateWithHttpMessagesAsync($Location, $Name, $Parameters)

            if ($TaskResult) {
                $GetTaskResult_params = @{
                    TaskResult = $TaskResult
                }
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

