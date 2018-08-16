<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

<#
.SYNOPSIS
    Create a new backup location.

.DESCRIPTION
    Create a new backup location.

.PARAMETER Location
    Name of the backup location.

.PARAMETER ResourceGroupName
    Name of the resource group.

.PARAMETER ResourceId
    The resource id.

.PARAMETER InputObject
    Backup location configuration returned by Get-AzsBackupLocation.

.PARAMETER BackupShare
    Location where backups will be stored.

.PARAMETER Username
    Username required to access backup location.

.PARAMETER Password
    Password required to access backup location.

.PARAMETER EncryptionKey
    Encryption key used to encrypt backups.

.PARAMETER IsBackupSchedulerEnabled
    Whether the backup scheduler should be enabled.

.PARAMETER BackupFrequencyInHours
    The interval, in hours, for the frequency that the scheduler takes a backup.

.PARAMETER BackupRetentionPeriodInDays
    The retention period, in days, for backups in the storage location.

.PARAMETER AsJob
    Run asynchronous as a job and return the job object.

.EXAMPLE

    PS C:\> Set-AzsBackupShare -BackupShare "\\***.***.***.***\Share" -Username "asdomain1\azurestackadmin" -Password $password  -EncryptionKey $encryptionKey

    Set Azure Stack backup configuration.

#>
function Set-AzsBackupShare {
    [OutputType([Microsoft.AzureStack.Management.Backup.Admin.Models.BackupLocation])]
    [CmdletBinding(DefaultParameterSetName = 'Update', SupportsShouldProcess = $true)]
    param(
        [Parameter(Mandatory = $true, ValueFromPipeline = $true, ParameterSetName = 'InputObject')]
        [ValidateNotNullOrEmpty()]
        [Microsoft.AzureStack.Management.Backup.Admin.Models.BackupLocation]
        $InputObject,

        [Parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, ParameterSetName = 'ResourceId')]
        [Alias('id')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $ResourceId,

        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [ValidateLength(1, 90)]
        [System.String]
        $ResourceGroupName,

        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [System.String]
        $Location,

        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceId')]
        [Parameter(Mandatory = $false, ParameterSetName = 'InputObject')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        [Alias("Path")]
        $BackupShare,

        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceId')]
        [Parameter(Mandatory = $false, ParameterSetName = 'InputObject')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        $Username,

        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceId')]
        [Parameter(Mandatory = $false, ParameterSetName = 'InputObject')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [ValidateNotNull()]
        [securestring]
        $Password,

        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceId')]
        [Parameter(Mandatory = $false, ParameterSetName = 'InputObject')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [ValidateNotNull()]
        [securestring]
        $EncryptionKey,

        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceId')]
        [Parameter(Mandatory = $false, ParameterSetName = 'InputObject')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [bool]
        $IsBackupSchedulerEnabled,

        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceId')]
        [Parameter(Mandatory = $false, ParameterSetName = 'InputObject')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [int]
        $BackupFrequencyInHours,

        [Parameter(Mandatory = $false, ParameterSetName = 'ResourceId')]
        [Parameter(Mandatory = $false, ParameterSetName = 'InputObject')]
        [Parameter(Mandatory = $false, ParameterSetName = 'Update')]
        [int]
        $BackupRetentionPeriodInDays,

        [Parameter(Mandatory = $false)]
        [switch]
        $AsJob
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



        if ('InputObject' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {
            $GetArmResourceIdParameterValue_params = @{
                IdTemplate = '/subscriptions/{subscriptionId}/resourcegroups/{resourceGroup}/providers/Microsoft.Backup.Admin/backupLocations/{location}'
            }
            if ('ResourceId' -eq $PsCmdlet.ParameterSetName) {
                $GetArmResourceIdParameterValue_params['Id'] = $ResourceId
            } else {
                $GetArmResourceIdParameterValue_params['Id'] = $InputObject.Id
            }
            $ArmResourceIdParameterValues = Get-ArmResourceIdParameterValue @GetArmResourceIdParameterValue_params
            $ResourceGroupName = $ArmResourceIdParameterValues['resourceGroup']

            $Location = $ArmResourceIdParameterValues['location']
        }

        # Should process
        if ($PSCmdlet.ShouldProcess("$Location" , "Set backup configuration for location.")) {

            if ([System.String]::IsNullOrEmpty($Location)) {
                $Location = (Get-AzureRMLocation).Location
            }
            if ([System.String]::IsNullOrEmpty($ResourceGroupName)) {
                $ResourceGroupName = "System.$($Location)"
            }

            $NewServiceClient_params = @{
                FullClientTypeName = 'Microsoft.AzureStack.Management.Backup.Admin.BackupAdminClient'
            }

            $GlobalParameterHashtable = @{}
            $NewServiceClient_params['GlobalParameterHashtable'] = $GlobalParameterHashtable

            $GlobalParameterHashtable['SubscriptionId'] = $null
            if ($PSBoundParameters.ContainsKey('SubscriptionId')) {
                $GlobalParameterHashtable['SubscriptionId'] = $PSBoundParameters['SubscriptionId']
            }

            $BackupAdminClient = New-ServiceClient @NewServiceClient_params

            if ('InputObject' -eq $PsCmdlet.ParameterSetName -or 'Update' -eq $PsCmdlet.ParameterSetName -or 'ResourceId' -eq $PsCmdlet.ParameterSetName) {

                if ($InputObject -eq $null) {
                    $InputObject = Get-AzsBackupLocation -ResourceGroupName $ResourceGroupName -Location $Location
                }

                if ($PSBoundParameters.ContainsKey('BackupShare'))
                {
                    $InputObject.Path = $BackupShare
                }

                if ($PSBoundParameters.ContainsKey('Username'))
                {
                    $InputObject.UserName = $Username
                }

                if ($PSBoundParameters.ContainsKey('Password'))
                {
                    $InputObject.Password = ConvertTo-String -SecureString $Password
                }

                if ($PSBoundParameters.ContainsKey('EncryptionKey'))
                {
                    $InputObject.EncryptionKeyBase64 = ConvertTo-String $EncryptionKey
                }

                if ($PSBoundParameters.ContainsKey('IsBackupSchedulerEnabled'))
                {
                    $InputObject.IsBackupSchedulerEnabled = $IsBackupSchedulerEnabled
                }

                if ($PSBoundParameters.ContainsKey('BackupFrequencyInHours'))
                {
                    $InputObject.BackupFrequencyInHours = $BackupFrequencyInHours
                }

                if ($PSBoundParameters.ContainsKey('BackupRetentionPeriodInDays'))
                {
                    $InputObject.BackupRetentionPeriodInDays = $BackupRetentionPeriodInDays
                }

                Write-Verbose -Message 'Performing operation update on $BackupAdminClient.'
                $TaskResult = $BackupAdminClient.BackupLocations.UpdateWithHttpMessagesAsync($ResourceGroupName, $Location, $InputObject)
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
            if ($AsJob) {
                $ScriptBlockParameters = New-Object -TypeName 'System.Collections.Generic.Dictionary[string,object]'
                $ScriptBlockParameters['TaskResult'] = $TaskResult
                $ScriptBlockParameters['AsJob'] = $true
                $ScriptBlockParameters['TaskHelperFilePath'] = $TaskHelperFilePath
                $PSCommonParameters.GetEnumerator() | ForEach-Object { $ScriptBlockParameters[$_.Name] = $_.Value }

                Start-PSSwaggerJobHelper -ScriptBlock $PSSwaggerJobScriptBlock `
                    -CallerPSBoundParameters $ScriptBlockParameters `
                    -CallerPSCmdlet $PSCmdlet `
                    @PSCommonParameters
            } else {
                Invoke-Command -ScriptBlock $PSSwaggerJobScriptBlock `
                    -ArgumentList $TaskResult, $TaskHelperFilePath `
                    @PSCommonParameters
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


function ConvertTo-String {
    param(
        [SecureString]$SecureString
    )
    $Ptr = [System.Runtime.InteropServices.Marshal]::SecureStringToCoTaskMemUnicode($SecureString)
    $Result = [System.Runtime.InteropServices.Marshal]::PtrToStringUni($Ptr)
    [System.Runtime.InteropServices.Marshal]::ZeroFreeCoTaskMemUnicode($Ptr)
    $Result
}
