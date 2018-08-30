<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Create or update a quota.

.DESCRIPTION
    Create or update a quota.

.PARAMETER Name
    Name of the resource.

.PARAMETER Location
    Location of the resource.

.PARAMETER MaxNicsPerSubscription
    The maximum NICs allowed per subscription.

.PARAMETER MaxPublicIpsPerSubscription
    The maximum public IP addresses allowed per subscription.

.PARAMETER MaxVirtualNetworkGatewayConnectionsPerSubscription
    The maximum number of virtual network gateway connections allowed per subscription.

.PARAMETER MaxVnetsPerSubscription
    The maxium number of virtual networks allowed per subscription.

.PARAMETER MaxVirtualNetworkGatewaysPerSubscription
    The maximum number of virtual network gateways allowed per subscription.

.PARAMETER MaxSecurityGroupsPerSubscription
    The maximum number of security groups allowed per subscription.

.PARAMETER MaxLoadBalancersPerSubscription
    The maximum number of load balancers allowed per subscription.

.PARAMETER ResourceId
    The resource id.

.PARAMETER InputObject
    Posbbily modified network quota returned by Get-AzsNetworkQuota

.EXAMPLE

    PS C:\> Set-AzsNetworkQuota -Name NetworkQuota1 -MaxVnetsPerSubscription 20

    Update a network quota by name.

.EXAMPLE

    PS C:\> Set-AzsNetworkQuota -Name NetworkQuota1 -MaxPublicIpsPerSubscription 75 -MaxNicsPerSubscription 100

    Update a network quota by name.
#>
function Set-AzsNetworkQuota {
    [OutputType([Microsoft.AzureStack.Management.Network.Admin.Models.Quota])]
    [CmdletBinding(DefaultParameterSetName = 'Quotas', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Quotas')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxNicsPerSubscription,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxPublicIpsPerSubscription,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxVirtualNetworkGatewayConnectionsPerSubscription,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxVnetsPerSubscription,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxVirtualNetworkGatewaysPerSubscription,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxSecurityGroupsPerSubscription,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxLoadBalancersPerSubscription,

        [Parameter(Mandatory = $false, ParameterSetName = 'Quotas')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,

        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject')]
        [ValidateNotNullOrEmpty()]
        [Microsoft.AzureStack.Management.Network.Admin.Models.Quota]
        $InputObject
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



        $Quota = $null

        if ('InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Network.Admin/locations/{location}/quotas/{resourceName}'
            }

            if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
                $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            } else {
                $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
                $Quota = $InputObject
            }
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $Location = $ArmResourceIdParameterValues['location']
            $Name = $ArmResourceIdParameterValues['resourceName']
        }

        if ($PSCmdlet.ShouldProcess("$Name" , "Update network quota")) {

            if ([System.String]::IsNullOrEmpty($Location)) {
                $Location = (Get-AzureRMLocation).Location
            }

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

            if ('Quotas' -eq $PsCmdlet.ParameterSetName -or 'InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {

                if ($Quota -eq $null) {
                    $Quota = Get-AzsNetworkQuota -Location $Location -Name $Name
                }

                $flattenedParameters = @(
                    'MaxNicsPerSubscription', 'MaxPublicIpsPerSubscription',
                    'MaxVirtualNetworkGatewayConnectionsPerSubscription', 'MaxVnetsPerSubscription',
                    'MaxVirtualNetworkGatewaysPerSubscription', 'MaxSecurityGroupsPerSubscription',
                    'MaxLoadBalancersPerSubscription')
                # Update the Quota object
                $flattenedParameters | ForEach-Object {
                    if ($PSBoundParameters.ContainsKey($_)) {
                        $Quota.$($_) = $PSBoundParameters[$_]
                    }
                }

                Write-Verbose -Message 'Performing operation update on $NetworkAdminClient.'
                $TaskResult = $NetworkAdminClient.Quotas.CreateOrUpdateWithHttpMessagesAsync($Location, $Name, $Quota)
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
    }

    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}

