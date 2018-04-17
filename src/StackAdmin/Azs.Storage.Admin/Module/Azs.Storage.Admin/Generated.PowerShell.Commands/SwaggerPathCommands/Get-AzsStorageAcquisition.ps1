<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Returns a list of blob acquistions.

.DESCRIPTION
    Returns a list of blob acquistions.

.PARAMETER Filter
    Filter string

.PARAMETER ResourceGroupName
    Resource group name.

.PARAMETER FarmName
    Farm Id.

.EXAMPLE

	PS C:\> Get-AzsStorageAcquisition -FarmName f9b8e2e2-e4b4-44e0-9d92-6a848b1a5376

    Get the list of blob acquistions.


.EXAMPLE

	PS C:\> Get-AzsStorageAcquisition -FarmName f9b8e2e2-e4b4-44e0-9d92-6a848b1a5376 -Filter "startswith(properties/Storageaccount, 'Test'"

    Get the list of blob acquistions.

#>
function Get-AzsStorageAcquisition {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FarmName,

        [Parameter(Mandatory = $false)]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $false)]
        [System.String]
        $Filter
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

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }

        $StorageAdminClient = New-ServiceClient @NewServiceClient_params

        if ([String]::IsNullOrEmpty($ResourceGroupName)) {
            $ResourceGroupName = "System.$((Get-AzureRmLocation).Location)"
        }

        Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $StorageAdminClient.'
        $TaskResult = $StorageAdminClient.Acquisitions.ListWithHttpMessagesAsync($ResourceGroupName, $FarmName, $(if ($PSBoundParameters.ContainsKey('Filter')) {
                    $Filter
                } else {
                    [NullString]::Value
                }))

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

