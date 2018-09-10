<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Power on an infrastructure role instance.

.DESCRIPTION
    Power on an infrastructure role instance.

.PARAMETER InfraRoleInstance
    Name of an infrastructure role instance.

.PARAMETER ResourceGroupName
    Resource group in which the resource provider has been registered.

.PARAMETER Location
    Location of the resource.

.PARAMETER ResourceId
    Infrastructure role instance resource ID.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.PARAMETER Force
    Don't ask for confirmation.

.EXAMPLE

    PS C:\> Start-AzsInfrastructureRoleInstance -Name "AzS-ACS01"

    Power on an infrastructure role instance.

#>
function Start-AzsInfrastructureRoleInstance {
    [CmdletBinding(DefaultParameterSetName = 'PowerOn', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'PowerOn')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false, ParameterSetName = 'PowerOn')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $false, ParameterSetName = 'PowerOn')]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,

        [Parameter(Mandatory = $false)]
        [switch]
        $AsJob,

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

        if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Fabric.Admin/fabricLocations/{location}/infraRoleInstances/{infraRoleInstance}'
            }

            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $ResourceGroupName = $ArmResourceIdParameterValues['resourceGroupName']
            $Location = $ArmResourceIdParameterValues['location']
            $Name = $ArmResourceIdParameterValues['infraRoleInstance']
        } else {
            $Name = Get-ResourceNameSuffix -ResourceName $Name
        }

        if ($PSCmdlet.ShouldProcess("$Name" , "Start infrastructure role instance")) {
            if ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Start infrastructure role instance?", "Performing operation start for infrastructure role instance $Name")) {

                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.Fabric.Admin.FabricAdminClient'
                }

                $GlobalParameterHashtable = @{}
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

                $GlobalParameterHashtable['SubscriptionId'] = $null
                if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                    $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
                }

                $FabricAdminClient = New-ServiceClient @NewServiceClient_params

                if ([System.String]::IsNullOrEmpty($Location)) {
                    $Location = (Get-AzureRMLocation).Location
                }
                if ([System.String]::IsNullOrEmpty($ResourceGroupName)) {
                    $ResourceGroupName = "System.$Location"
                }

                if ('PowerOn' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation PowerOnWithHttpMessagesAsync on $FabricAdminClient.'
                    $TaskResult = $FabricAdminClient.InfraRoleInstances.PowerOnWithHttpMessagesAsync($ResourceGroupName, $Location, $Name)
                } else {
                    Write-Verbose -Message 'Failed to map parameter set to operation method.'
                    throw 'Module failed to find operation to execute.'
                }

                Write-Verbose -Message "Waiting for the operation to complete."

                $PSSwaggerJobScriptBlock = {
                    [CmdletBinding()]
                    param(
                        [Parameter(Mandatory = $true)]
                        [System.Threading.Tasks.Task]
                        $TaskResult,

                        [Parameter(Mandatory = $true)]
                        [System.String]
                        $TaskHelperFilePath
                    )
                    if ($TaskResult) {
                        . $TaskHelperFilePath
                        $GetTaskResult_params = @{
                            TaskResult = $TaskResult
                        }

                        Get-TaskResult @GetTaskResult_params

                    }
                }

                $PSCommonParameters = Get-PSCommonParameter -CallerPSBoundParameters $PSBoundParameters
                $TaskHelperFilePath = Join-Path -Path $ExecutionContext.SessionState.Module.ModuleBase -ChildPath 'Get-TaskResult.ps1'
                if (-not $AsJob.IsPresent) {
                    Invoke-Command -ScriptBlock $PSSwaggerJobScriptBlock `
                        -ArgumentList $TaskResult, $TaskHelperFilePath `
                        @PSCommonParameters
                } else {
                    $ScriptBlockParameters = New-Object -TypeName 'System.Collections.Generic.Dictionary[string,object]'
                    $ScriptBlockParameters['TaskResult'] = $TaskResult
                    $ScriptBlockParameters['AsJob'] = $true
                    $ScriptBlockParameters['TaskHelperFilePath'] = $TaskHelperFilePath
                    $PSCommonParameters.GetEnumerator() | ForEach-Object { $ScriptBlockParameters[$_.Name] = $_.Value }

                    Start-PSSwaggerJobHelper -ScriptBlock $PSSwaggerJobScriptBlock `
                        -CallerPSBoundParameters $ScriptBlockParameters `
                        -CallerPSCmdlet $PSCmdlet `
                        @PSCommonParameters
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

