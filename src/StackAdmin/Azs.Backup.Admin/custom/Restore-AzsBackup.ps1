<#
.Synopsis
Restore a backup.
.Description
Restore a backup.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/azs.backup.admin/restore-azsbackup
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IRestoreOptions
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.IBackupAdminIdentity
.Outputs
System.Boolean
.Notes
COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IBackupAdminIdentity>: Identity Parameter
  [Backup <String>]: Name of the backup.
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the backup location.
  [ResourceGroupName <String>]: Name of the resource group.
  [SubscriptionId <String>]: Subscription credentials that uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

RESTOREOPTION <IRestoreOptions>: Properties for restore options.
  [DecryptionCertBase64 <String>]: The certificate file raw data in Base64 string. This should be the .pfx file with the private key.
  [DecryptionCertPassword <String>]: The password for the decryption certificate.
  [RoleName <String>]: The Azure Stack role name for restore, set it to empty for all infrastructure role
.Link
https://docs.microsoft.com/en-us/powershell/module/azs.backup.admin/restore-azsbackup
#>
function Restore-AzsBackup {
[OutputType([System.Boolean])]
[CmdletBinding(DefaultParameterSetName='RestoreExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Restore', Mandatory)]
    [Parameter(ParameterSetName='RestoreExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [System.String]
    # Name of the backup.
    ${Name},

    [Parameter(ParameterSetName='Restore')]
    [Parameter(ParameterSetName='RestoreExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.DefaultInfo(Script='(Get-AzLocation)[0].Name')]
    [System.String]
    # Name of the backup location.
    ${Location},

    [Parameter(ParameterSetName='Restore')]
    [Parameter(ParameterSetName='RestoreExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.DefaultInfo(Script='"system.$((Get-AzLocation)[0].Name)"')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Restore')]
    [Parameter(ParameterSetName='RestoreExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials that uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='RestoreViaIdentity', Mandatory, ValueFromPipeline)]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.IBackupAdminIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(ParameterSetName='Restore', Mandatory)]
    [Parameter(ParameterSetName='RestoreViaIdentity', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IRestoreOptions]
    # Properties for restore options.
    # To construct, see NOTES section for RESTOREOPTION properties and create a hash table.
    ${RestoreOption},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [System.String]
    # Path to the decryption cert file with private key (.pfx).
    ${DecryptionCertPath},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [SecureString]
    # The password for the decryption certificate.
    ${DecryptionCertPassword},

    [Parameter(ParameterSetName='RestoreExpanded')]
    [Parameter(ParameterSetName='RestoreViaIdentityExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Body')]
    [System.String]
    # The Azure Stack role name for restore, set it to empty for all infrastructure role
    ${RoleName},

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

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Returns true when the command succeeds
    ${PassThru},

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
    ${ProxyUseDefaultCredentials},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Don't ask for confirmation
    $Force
)

process {
    # The resource ID of backup does not match the required resource ID for restore operation. Directly get the backup and call with Name.
    if  ($PSBoundParameters.ContainsKey(('InputObject')))
    {
        $Backup = Get-AzsBackup -InputObject $InputObject
        $null = $PSBoundParameters.Remove('InputObject')
        $Name = $Backup.Name
        $PSBoundParameters.Add('Name', $Backup.Name)
    }

    # Generated SDK does not support {location}/{name} for nested resource name, so extract the {name} part here
    if ($PSBoundParameters.ContainsKey(('Name')))
    {
        if ($null -ne $Name -and $Name.Contains('/'))
        {
            $PSBoundParameters['Name'] = $Name.Split("/")[-1]
        }
    }

    if ($PSBoundParameters.ContainsKey(('DecryptionCertPassword')))
    {
        $Ptr = [System.Runtime.InteropServices.Marshal]::SecureStringToCoTaskMemUnicode($DecryptionCertPassword)
        $PasswordString = [System.Runtime.InteropServices.Marshal]::PtrToStringUni($Ptr)
        [System.Runtime.InteropServices.Marshal]::ZeroFreeCoTaskMemUnicode($Ptr)
        $PSBoundParameters['DecryptionCertPassword'] = $PasswordString
    }

    if ($PSBoundParameters.ContainsKey(('DecryptionCertPath')))
    {
        if (!(Test-Path -Path $DecryptionCertPath -PathType Leaf))
        {
            throw "The specified decryption cert $DecryptionCertPath does not exist"
        }

        $DecryptionCertBytes = [System.IO.File]::ReadAllBytes($DecryptionCertPath)
        $DecryptionCertBase64 = [System.Convert]::ToBase64String($DecryptionCertBytes)
        $null = $PSBoundParameters.Remove('DecryptionCertPath')
        $PSBoundParameters.Add('DecryptionCertBase64', $DecryptionCertBase64)
    }

    if ($PSCmdlet.ShouldProcess("$Name" , "Restore from backup at location $Location"))
    {
        if ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Restore from backup at location $($Location)?", "Performing operation restore using backup $Name."))
        {
            if ($PSBoundParameters.ContainsKey(('Force')))
            {
                $null = $PSBoundParameters.Remove('Force')
            }
        
            Azs.Backup.Admin.internal\Restore-AzsBackup @PSBoundParameters
        }
    }
}
}
