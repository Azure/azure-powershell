<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Apply a specific update at an update location.

.DESCRIPTION
    Apply a specific update at an update location.  After invoked, Get-AzsUpdateRun may be used to modify the progress of the update.

.PARAMETER ResourceGroupName
    The resource group the resource is located under.

.PARAMETER Location
    The name of the update location.

.PARAMETER Name
    Name of the update.

.PARAMETER ResourceId
    The resource id.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.PARAMETER Force
    Don't ask for confirmation.

.EXAMPLE

    PS C:\> Get-AzsUpdate -Name Microsoft1.0.180305.1 | Install-AzsUpdate

    Apply a specific update at an update location.

#>
function Install-AzsUpdate {
    [OutputType([Microsoft.AzureStack.Management.Update.Admin.Models.Update])]
    [CmdletBinding(DefaultParameterSetName = 'Apply', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'Apply')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,

        [Parameter(Mandatory = $false, ParameterSetName = 'Apply')]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $false, ParameterSetName = 'Apply')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $false)]
        [switch]
        $AsJob,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,

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
                IdTemplate = '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroup}/providers/Microsoft.Update.Admin/updateLocations/{updateLocation}/updates/{update}'
            }
            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params

            $ResourceGroupName = $ArmResourceIdParameterValues['resourceGroup']
            $Location = $ArmResourceIdParameterValues['updateLocation']
            $Name = $ArmResourceIdParameterValues['update']
        } else {
            $Name = Get-ResourceNameSuffix -ResourceName $Name
        }

        if ($PsCmdlet.ShouldProcess($Name, "Install the update")) {
            if ($Force.IsPresent -or $PsCmdlet.ShouldContinue("Install the update?", "Performing operation ApplyWithHttpMessagesAsync on $Name")) {

                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.Update.Admin.UpdateAdminClient'
                }

                $GlobalParameterHashtable = @{}
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

                $GlobalParameterHashtable['SubscriptionId'] = $null
                if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                    $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
                }

                $UpdateAdminClient = New-ServiceClient @NewServiceClient_params

                if ([System.String]::IsNullOrEmpty($Location)) {
                    $Location = (Get-AzureRmLocation).Location
                }
                if ([System.String]::IsNullOrEmpty($ResourceGroupName)) {
                    $ResourceGroupName = "System.$Location"
                }

                if ('Apply' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation ApplyWithHttpMessagesAsync on $UpdateAdminClient.'
                    $TaskResult = $UpdateAdminClient.Updates.ApplyWithHttpMessagesAsync($ResourceGroupName, $Location, $Name)
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

