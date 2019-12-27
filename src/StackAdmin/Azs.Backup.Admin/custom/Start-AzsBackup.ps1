<#
.Synopsis
Back up a specific location.
.Description
Back up a specific location.
.Example
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/azs.backup.admin/start-azsbackup
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.IBackupAdminIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackup
.Notes
COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IBackupAdminIdentity>: Identity Parameter
  [Backup <String>]: Name of the backup.
  [Id <String>]: Resource identity path
  [Location <String>]: Name of the backup location.
  [ResourceGroupName <String>]: Name of the resource group.
  [SubscriptionId <String>]: Subscription credentials that uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
.Link
https://docs.microsoft.com/en-us/powershell/module/azs.backup.admin/start-azsbackup
#>
function Start-AzsBackup {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackup])]
[CmdletBinding(DefaultParameterSetName='Create', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Create')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.DefaultInfo(Script='(Get-AzLocation)[0].Name')]
    [System.String]
    # Name of the backup location.
    ${Location},

    [Parameter(ParameterSetName='Create')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.DefaultInfo(Script='"system.$((Get-AzLocation)[0].Name)"')]
    [System.String]
    # Name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Create')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials that uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.IBackupAdminIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

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
    ${ProxyUseDefaultCredentials},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Don't ask for confirmation
    $Force
)

process {
    if ($PSCmdlet.ShouldProcess("$Location" , "Start backup at $Location"))
    {
        if ($Force.IsPresent -or $PSCmdlet.ShouldContinue("Start backup at $($Location)?", "Performing operation backup at $Location."))
        {
            if ($PSBoundParameters.ContainsKey(('Force')))
            {
                $null = $PSBoundParameters.Remove('Force')
            }
        
            Azs.Backup.Admin.internal\Start-AzsBackup @PSBoundParameters
        }
    }
}
}
