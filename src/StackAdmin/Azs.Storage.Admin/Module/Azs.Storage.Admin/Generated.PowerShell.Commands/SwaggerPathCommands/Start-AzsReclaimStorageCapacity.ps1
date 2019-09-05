<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Start garbage collection on deleted storage objects.

.PARAMETER Location
    Resource location.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.PARAMETER Force
    Do not ask for confirmation.

.EXAMPLE

    PS C:\> Start-AzsReclaimStorageCapacity 

    Start garbage collection.

#>
function Start-AzsReclaimStorageCapacity {
    [CmdletBinding(DefaultParameterSetName = 'ReclaimStorageCapacity', SupportsShouldProcess = $true)]
    param(    
        [Parameter(Mandatory = $false, ParameterSetName = 'ReclaimStorageCapacity')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,

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

        if ($PSCmdlet.ShouldProcess("Storage Accounts" , "Start reclaim storage capacity")) {
            if ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Start reclaim storage capacity?", "Performing operation garbage collect for deleted storage accounts.")) {
                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.Storage.Admin.StorageAdminClient'
                }
        
                $GlobalParameterHashtable = @{ }
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
             
                $GlobalParameterHashtable['SubscriptionId'] = $null
                if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                    $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
                }

                if ([System.String]::IsNullOrEmpty($Location)) {
                    $Location = (Get-AzureRmLocation).Location
                }
        
                $StorageAdminClient = New-ServiceClient @NewServiceClient_params
        
        
                if ('ReclaimStorageCapacity' -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation ReclaimStorageCapacityWithHttpMessagesAsync on $StorageAdminClient.'
                    $TaskResult = $StorageAdminClient.StorageAccounts.ReclaimStorageCapacityWithHttpMessagesAsync($Location)
                }
                else {
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
                        [string]
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
                if ($AsJob) {
                    $ScriptBlockParameters = New-Object -TypeName 'System.Collections.Generic.Dictionary[string,object]'
                    $ScriptBlockParameters['TaskResult'] = $TaskResult
                    $ScriptBlockParameters['AsJob'] = $AsJob
                    $ScriptBlockParameters['TaskHelperFilePath'] = $TaskHelperFilePath
                    $PSCommonParameters.GetEnumerator() | ForEach-Object { $ScriptBlockParameters[$_.Name] = $_.Value }
        
                    Start-PSSwaggerJobHelper -ScriptBlock $PSSwaggerJobScriptBlock `
                        -CallerPSBoundParameters $ScriptBlockParameters `
                        -CallerPSCmdlet $PSCmdlet `
                        @PSCommonParameters
                }
                else {
                    Invoke-Command -ScriptBlock $PSSwaggerJobScriptBlock `
                        -ArgumentList $TaskResult, $TaskHelperFilePath `
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

