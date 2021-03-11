

function Update-AzDataProtectionBackupInstanceAssociatedPolicy
{
	[OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupInstanceResource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Updates associated policy for a given backup instance')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group of the backup vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(Mandatory, HelpMessage='Unique Name of protected backup instance')]
        [System.String]
        ${BackupInstanceName},

        [Parameter(Mandatory, HelpMessage='Id of the Policy to be associated with the backup instance')]
        [System.String]
        ${PolicyId}
    )

    process
    {
        $null = $PSBoundParameters.Remove("PolicyId")
        $instance = Az.DataProtection\Get-AzDataProtectionBackupInstance @PSBoundParameters
        $instance.Property.PolicyInfo.PolicyId = $PolicyId
        $null = $PSBoundParameters.Remove("BackupInstanceName")
        $null = $PSBoundParameters.Add("BackupInstance", $instance)

        Az.DataProtection\New-AzDataProtectionBackupInstance  @PSBoundParameters
    }
}