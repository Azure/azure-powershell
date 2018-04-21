<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Get a list of all quota objects for KeyVault at a location.

.DESCRIPTION
    Get a list of all quota objects for KeyVault at a location.

.PARAMETER Location
    The location of the quota.

.EXAMPLE

    PS C:\> Get-AzsKeyVaultQuota

    Get a list of all quota objects for KeyVault at a location.

#>
function Get-AzsKeyVaultQuota {
    [OutputType([Microsoft.AzureStack.Management.KeyVault.Admin.Models.Quota])]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $false, Position = 0)]
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
            FullClientTypeName = 'Microsoft.AzureStack.Management.KeyVault.Admin.KeyVaultAdminClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }

        $KeyVaultAdminClient = New-ServiceClient @NewServiceClient_params

        if ([System.String]::IsNullOrEmpty($Location)) {
            $Location = (Get-AzureRMLocation).Location
        }

        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $KeyVaultAdminClient.'
        $TaskResult = $KeyVaultAdminClient.Quotas.ListWithHttpMessagesAsync($Location)

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

