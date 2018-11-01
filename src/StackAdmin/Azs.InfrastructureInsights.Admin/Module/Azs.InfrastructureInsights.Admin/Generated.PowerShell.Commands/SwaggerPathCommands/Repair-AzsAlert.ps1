<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Repairs the given alert.

.DESCRIPTION
    Repairs the given alert.

.PARAMETER Name
    The alert identifier.

.PARAMETER Location
    Name of the location.

.PARAMETER ResourceGroupName
    Resource group name which the resource resides.

.PARAMETER InputObject
    An alert returned from Get-AzsAlert.

.PARAMETER Force
    Don't ask for confirmation.

.EXAMPLE

    PS C:\> Repair-AzsAlert -Name f2147f3d-42ac-4316-8cbc-f0f9c18888b0

    Repairs an alert by Name.

.EXAMPLE

    PS C:\> Get-AzsAlert -Name f2147f3d-42ac-4316-8cbc-f0f9c18888b0 | Repair-AzsAlert

    Repairs an alert through piping.

#>
function Repair-AzsAlert {
    [CmdletBinding(DefaultParameterSetName = 'Repair', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Repair')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false, ParameterSetName = 'Repair')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $false, ParameterSetName = 'Repair')]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject')]
        [ValidateNotNullOrEmpty()]
        [Microsoft.AzureStack.Management.InfrastructureInsights.Admin.Models.Alert]
        $InputObject,

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

	if ('InputObject' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.InfrastructureInsights.Admin/regionHealths/{region}/alerts/{alertName}'
            }

            $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $ResourceGroupName = $ArmResourceIdParameterValues['resourceGroupName']
            $Location = $ArmResourceIdParameterValues['region']
            $Name = $ArmResourceIdParameterValues['alertName']
        }

        if ($PSCmdlet.ShouldProcess("$Name" , "Repair Alert")) {
            if ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Repair Alert?", "Performing operation repair on alert $Name")) {

                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.InfrastructureInsights.Admin.InfrastructureInsightsAdminClient'
                }

                $GlobalParameterHashtable = @{}
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

                $GlobalParameterHashtable['SubscriptionId'] = $null
                if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                    $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
                }

                $InfrastructureInsightsAdminClient = New-ServiceClient @NewServiceClient_params

                if ([System.String]::IsNullOrEmpty($Location)) {
                    $Location = (Get-AzureRMLocation).Location
                }

                if ([System.String]::IsNullOrEmpty($ResourceGroupName)) {
                    $ResourceGroupName = "System.$Location"
                }

                if ('Repair' -eq $PsCmdlet.ParameterSetName -or 'InputObject' -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation RepairWithHttpMessagesAsync on $InfrastructureInsightsAdminClient.'
                    $TaskResult = $InfrastructureInsightsAdminClient.Alerts.RepairWithHttpMessagesAsync($ResourceGroupName, $Location, $Name)
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
    }

    End {
        if ($tracerObject) {
            $global:DebugPreference = $oldDebugPreference
            Unregister-PSSwaggerClientTracing -TracerObject $tracerObject
        }
    }
}

