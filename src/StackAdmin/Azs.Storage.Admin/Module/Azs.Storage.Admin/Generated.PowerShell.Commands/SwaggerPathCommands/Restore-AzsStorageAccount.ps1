<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    

.DESCRIPTION
    Undelete a deleted storage account.

.PARAMETER Name
    Internal storage account ID, which is not visible to tenant.

.PARAMETER Location
    Resource location.

.PARAMETER ResourceId
    The resource id.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.PARAMETER Force
    Do not ask for confirmation.

.EXAMPLE

    PS C:\> Restore-AzsStorageAccount -Name "83fe9ac0-f1e7-433e-b04c-c61ae0712093"

    Undelete a deleted storage account.
#>
function Restore-AzsStorageAccount {
    [OutputType([Microsoft.AzureStack.Management.Storage.Admin.Models.StorageAccount])]
    [CmdletBinding(DefaultParameterSetName = 'Undelete', SupportsShouldProcess = $true)]
    param(    
        [Parameter(Mandatory = $true, ParameterSetName = 'Undelete')]
        [Alias('accountid')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Name,
    
        [Parameter(Mandatory = $false, ParameterSetName = 'Undelete')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Location,

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
    
        $ErrorActionPreference = 'Stop'

        if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/providers/Microsoft.Storage.Admin/locations/{location}/storageaccounts/{accountId}'
            }

            $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
            $Location = $ArmResourceIdParameterValues['location']

            $accountId = $ArmResourceIdParameterValues['accountId']
        }
        else {
            $accountId = $Name
            if ([System.String]::IsNullOrEmpty($Location)) {
                $Location = (Get-AzureRmLocation).Location
            }
        }

        if ($PSCmdlet.ShouldProcess("$accountId" , "Restore the storage account")) {
            if ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Restore the storage account?", "Performing operation restore storage account with name $accountId.")) {

                $NewServiceClient_params = @{
                    FullClientTypeName = 'Microsoft.AzureStack.Management.Storage.Admin.StorageAdminClient'
                }
        
                $GlobalParameterHashtable = @{ }
                $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable
             
                $GlobalParameterHashtable['SubscriptionId'] = $null
                if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                    $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
                }
        
                $StorageAdminClient = New-ServiceClient @NewServiceClient_params
        
        
                if ('Undelete' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
                    Write-Verbose -Message 'Performing operation UndeleteWithHttpMessagesAsync on $StorageAdminClient.'
                    $TaskResult = $StorageAdminClient.StorageAccounts.UndeleteWithHttpMessagesAsync($Location, $accountId)
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

