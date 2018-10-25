<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Get an overview of the state of the network resource provider.

.DESCRIPTION
    Get an overview of the state of the network resource provider.  Individual properties provide detailed counts of resource usage and health by component.

.EXAMPLE

	PS C:\> Get-AzsNetworkAdminOverview

    Get network admin overview.

.EXAMPLE

    PS C:\> (Get-AzsNetworkAdminOverview).PublicIpAddressUsage

    Get public ip address usage.
#>
function Get-AzsNetworkAdminOverview {
    [OutputType([Microsoft.AzureStack.Management.Network.Admin.Models.AdminOverview])]
    [CmdletBinding()]
    param(
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
            FullClientTypeName = 'Microsoft.AzureStack.Management.Network.Admin.NetworkAdminClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }
        $NetworkAdminClient = New-ServiceClient @NewServiceClient_params

        Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $NetworkAdminClient.'
        $TaskResult = $NetworkAdminClient.ResourceProviderState.GetWithHttpMessagesAsync()

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

