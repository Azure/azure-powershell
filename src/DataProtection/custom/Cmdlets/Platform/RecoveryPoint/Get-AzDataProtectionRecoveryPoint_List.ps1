function Get-AzDataProtectionRecoveryPoint_List
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Get Backup Vault object')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(HelpMessage='Vault Resource Group')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='Vault Name')]
        [System.String]
        ${VaultName},

        [Parameter(HelpMessage='Backup Instance Name')]
        [System.String]
        ${BackupInstanceName}
    )

    process {
        $rps = Az.DataProtection.internal\Get-AzDataProtectionRecoveryPointList @PSBoundParameters
        return $rps
    }
}