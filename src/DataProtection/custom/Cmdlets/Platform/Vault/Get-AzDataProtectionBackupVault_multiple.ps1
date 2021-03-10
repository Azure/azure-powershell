function Get-AzDataProtectionBackupVault_multiple
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Get Backup Vault object')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(Mandatory=$false, HelpMessage='Vault Resource Group')]
        [System.String]
        ${ResourceGroupName}
    )

    process {
        $vaults = Az.DataProtection.internal\Get-AzDataProtectionBackupVaultResource @PSBoundParameters
        return $vaults
    }
}