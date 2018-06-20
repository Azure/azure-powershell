<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    List all quotas.

.DESCRIPTION
    List all quotas. Limit the list by passing a name or filter.

.PARAMETER Name
    Network quota resource name.

.PARAMETER Location
    Location of the resource.

.PARAMETER Filter
    OData filter parameter.

.PARAMETER ResourceId
    The resource id.

.EXAMPLE

    PS C:\> Get-AzsNetworkQuota

    Lists all the  network quotas.

.EXAMPLE

    PS C:\> Get-AzsNetworkQuota -Name NetworkQuota1

    Gets the specified network quota.
#>
function Get-AzsNetworkQuota {
    [OutputType([Microsoft.AzureStack.Management.Network.Admin.Models.Quota])]
    [CmdletBinding(DefaultParameterSetName = 'List')]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Get', Position = 0)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false, ParameterSetName = 'Get')]
        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,

        [Parameter(Mandatory = $false, ParameterSetName = 'List')]
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
            FullClientTypeName = 'Microsoft.AzureStack.Management.Network.Admin.NetworkAdminClient'
        }

        $GlobalParameterHashtable = @{}
        $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

        $GlobalParameterHashtable['SubscriptionId'] = $null
        if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
            $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
        }

        $NetworkAdminClient = New-ServiceClient @NewServiceClient_params

        $oDataQuery = ""
        if ($Filter) {
            $oDataQuery += "&`$Filter=$Filter"
        }
        $oDataQuery = $oDataQuery.Trim("&")

        if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Network.Admin/locations/{location}/quotas/{resourceName}'
            }
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $location = $ArmResourceIdParameterValues['location']
            $Name = $ArmResourceIdParameterValues['resourceName']
        } elseif ([System.String]::IsNullOrEmpty($Location)) {
            $Location = (Get-AzureRMLocation).Location
        }


        if ('List' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation ListWithHttpMessagesAsync on $NetworkAdminClient.'
            $TaskResult = $NetworkAdminClient.Quotas.ListWithHttpMessagesAsync($Location, $(if ($oDataQuery) {
                        New-Object -TypeName "Microsoft.Rest.Azure.OData.ODataQuery``1[Microsoft.AzureStack.Management.Network.Admin.Models.Quota]" -ArgumentList $oDataQuery
                    } else {
                        $null
                    }))
        } elseif ('Get' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            Write-Verbose -Message 'Performing operation GetWithHttpMessagesAsync on $NetworkAdminClient.'
            $TaskResult = $NetworkAdminClient.Quotas.GetWithHttpMessagesAsync($Location, $Name)
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

