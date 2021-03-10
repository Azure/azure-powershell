
function Set-AzDataProtectionBackupVault_custom {
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Create a backup vault')]

    param(
        [Parameter(Mandatory, HelpMessage='Location of Vault')]
        [System.String]
        ${Location},

        [Parameter(HelpMessage='Subscription of Vault')]
        [System.String]
        ${SubscriptionId},

        [Parameter(Mandatory, HelpMessage='Resource Group of Vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='Name of the vault')]
        [System.String]
        ${VaultName},

        [Parameter(HelpMessage='Tags to be added to the created vault')]
        [System.Collections.Hashtable]
        ${Tag},

        [Parameter(Mandatory, HelpMessage='Storage setting of the vault')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IStorageSetting[]]
        ${StorageSetting},

        [Parameter(HelpMessage='Identity type of the vault')]
        [System.String]
        ${IdentityType}
    )

    process {
        Az.DataProtection\Set-AzDataProtectionBackupVault @PSBoundParameters
    }
}