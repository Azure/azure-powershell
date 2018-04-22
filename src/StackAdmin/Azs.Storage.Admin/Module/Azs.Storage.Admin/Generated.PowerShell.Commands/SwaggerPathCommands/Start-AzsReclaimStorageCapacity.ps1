<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Start garbage collection on deleted storage objects.

.DESCRIPTION
    Start garbage collection on deleted storage objects.

.PARAMETER ResourceGroupName
    Resource group name.

.PARAMETER FarmName
    Farm Id.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.PARAMETER Force
    Do not ask for confirmation.

.EXAMPLE

    PS C:\> Start-AzsReclaimStorageCapacity -FarmName "44263c10-13b2-4912-9b17-85c1e43b2a30"

    Start garbage collection.

#>
function Start-AzsReclaimStorageCapacity {
    [CmdletBinding(SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $false)]
        [ValidateLength(1, 90)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $true)]
        [Alias('name')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $FarmName,

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

        $ErrorActionPreference = 'Stop'

        # Should process
        if ($PSCmdlet.ShouldProcess("$FarmName" , "Start garbage collection")) {
            if ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Start garbage collection?", "Performing operation garbage collect for farm $FarmName.")) {

                if ([System.String]::IsNullOrEmpty($ResourceGroupName)) {
                    $ResourceGroupName = "System.$((Get-AzureRmLocation).Location)"
                }

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

                Write-Verbose -Message 'Performing operation StartGarbageCollectionWithHttpMessagesAsync on $StorageAdminClient.'
                $TaskResult = $StorageAdminClient.Farms.StartGarbageCollectionWithHttpMessagesAsync($ResourceGroupName, $FarmName)

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

