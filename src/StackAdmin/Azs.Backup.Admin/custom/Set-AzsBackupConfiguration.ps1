<#
.Synopsis
Update a backup location.
.Description
Update a backup location.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/azs.backup.admin/set-azsbackupconfiguration
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackupLocation
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackupLocation
.Notes
COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

BACKUP <IBackupLocation>: Information about the backup location.
  [Location <String>]: Location of the resource.
  [Tag <IResourceTags>]: List of key value pairs.
    [(Any) <String>]: This indicates any property can be added to this object.
  [BackupFrequencyInHours <Int32?>]: The interval, in hours, for the frequency that the scheduler takes a backup.
  [BackupRetentionPeriodInDays <Int32?>]: The retention period, in days, for backs in the storage location.
  [EncryptionCertBase64 <String>]: The base64 raw data for the backup encryption certificate.
  [IsBackupSchedulerEnabled <Boolean?>]: True if the backup scheduler is enabled.
  [Password <String>]: Password to access the location.
  [Path <String>]: Path to the update location
  [UserName <String>]: Username to access the location.
.Link
https://docs.microsoft.com/en-us/powershell/module/azs.backup.admin/set-azsbackupconfiguration
#>
function Set-AzsBackupConfiguration {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackupLocation])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.DefaultInfo(Script='(Get-AzLocation)[0].Name')]
    [System.String]
    # Name of the backup location.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.DefaultInfo(Script='"system.$((Get-AzLocation)[0].Name)"')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials that uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='Update', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackupLocation]
    # Information about the backup location.
    # To construct, see NOTES section for BACKUP properties and create a hash table.
    ${Backup},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [System.Int32]
    # The interval, in hours, for the frequency that the scheduler takes a backup.
    ${BackupFrequencyInHours},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [System.Int32]
    # The retention period, in days, for backs in the storage location.
    ${BackupRetentionPeriodInDays},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [System.String]
    # Path to the encryption cert file with public key (.cer).
    ${EncryptionCertPath},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # True if the backup scheduler is enabled.
    ${IsBackupSchedulerEnabled},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [SecureString]
    # Password to access the location.
    ${Password},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [System.String]
    # Path to the update location
    ${Path},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IResourceTags]))]
    [System.Collections.Hashtable]
    # List of key value pairs.
    ${Tag},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [System.String]
    # Username to access the location.
    ${UserName},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

process {
    if ($PSCmdlet.ParameterSetName -eq 'UpdateExpanded')
    {
        $PSBoundParameters.Add('Location1', $Location)
    }
    
    if ($PSBoundParameters.ContainsKey(('Password')))
    {
        $Ptr = [System.Runtime.InteropServices.Marshal]::SecureStringToCoTaskMemUnicode($Password)
        $PasswordString = [System.Runtime.InteropServices.Marshal]::PtrToStringUni($Ptr)
        [System.Runtime.InteropServices.Marshal]::ZeroFreeCoTaskMemUnicode($Ptr)
        $PSBoundParameters['Password'] = $PasswordString
    }

    if ($PSBoundParameters.ContainsKey(('EncryptionCertPath')))
    {
        if (!(Test-Path -Path $EncryptionCertPath -PathType Leaf))
        {
            throw "The specified encryption cert $EncryptionCertPath does not exist"
        }

        $EncryptionCertBytes = [System.IO.File]::ReadAllBytes($EncryptionCertPath)
        $EncryptionCertBase64 = [System.Convert]::ToBase64String($EncryptionCertBytes)
        $null = $PSBoundParameters.Remove('EncryptionCertPath')
        $PSBoundParameters.Add('EncryptionCertBase64', $EncryptionCertBase64)
    }

    Azs.Backup.Admin.internal\Set-AzsBackupConfiguration @PSBoundParameters
}
}
