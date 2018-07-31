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
    Name of the network quota resource.

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

.EXAMPLE

    PS C:\> New-AzsNetworkQuota -Name NetworkQuotaDefaultValues

    Create a new network quota with all the default values.
.EXAMPLE

    PS C:\> New-AzsNetworkQuota -Name NetworkQuota1 -MaxNicsPerSubscription 150 -MaxPublicIpsPerSubscription 150

    Create a new network quota with non default values for quota.
#>
function New-AzsNetworkQuota {
    [OutputType([Microsoft.AzureStack.Management.Network.Admin.Models.Quota])]
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxNicsPerSubscription = 100,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxPublicIpsPerSubscription = 50,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxVirtualNetworkGatewayConnectionsPerSubscription = 2,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxVnetsPerSubscription = 50,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxVirtualNetworkGatewaysPerSubscription = 1,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxSecurityGroupsPerSubscription = 50,

        [Parameter(Mandatory = $false)]
        [long]
        $MaxLoadBalancersPerSubscription = 50,

        [Parameter(Mandatory = $false)]
        [System.String]
        $Location,

        [Parameter(Mandatory = $false, DontShow = $true)]
        [ValidateSet('None', 'Prepare', 'Commit', 'Abort')]
        [System.String]
        $MigrationPhase = 'Prepare'
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



        # Add here, leave defaults above.
        if (-not $PSBoundParameters.ContainsKey('MigrationPhase')) {
            $PSBoundParameters.Add('MigrationPhase',$MigrationPhase)
        }

        if ($PSCmdlet.ShouldProcess("$Name", "Create a new network quota")) {

            if ([System.String]::IsNullOrEmpty($Location)) {
                $Location = (Get-AzureRMLocation).Location
            }

            # Validate this resource does not exist.
            $_objectCheck = $null
            try {
                $_objectCheck = Get-AzsNetworkQuota -Name $Name -Location $Location
            } catch {
                # No op
            } finally {
                if ($_objectCheck -ne $null) {
                    throw "A network quota with name $Name at location $Location already exists."
                }
            }

            # Create object
            $flattenedParameters = @(
                'MaxNicsPerSubscription', 'MaxPublicIpsPerSubscription',
                'MaxVirtualNetworkGatewayConnectionsPerSubscription', 'MaxVnetsPerSubscription',
                'MaxVirtualNetworkGatewaysPerSubscription', 'MaxSecurityGroupsPerSubscription',
                'MaxLoadBalancersPerSubscription', 'MigrationPhase'
            )
            $utilityCmdParams = @{}
            $flattenedParameters | ForEach-Object {
                $utilityCmdParams[$_] = Get-Variable -Name $_ -ValueOnly
            }
            $Quota = New-QuotaObject @utilityCmdParams

            $NewServiceClient_params = @{
                FullClientTypeName = 'Microsoft.AzureStack.Management.Network.Admin.NetworkAdminClient'
            }
            $GlobalParameterHashtable = @{}
            $GlobalParameterHashtable['SubscriptionId'] = $null
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
            }
            $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
            $NetworkAdminClient = New-ServiceClient @NewServiceClient_params

            Write-Verbose -Message 'Performing operation create on $NetworkAdminClient.'
            $TaskResult = $NetworkAdminClient.Quotas.CreateOrUpdateWithHttpMessagesAsync($Location, $Name, $Quota)

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

