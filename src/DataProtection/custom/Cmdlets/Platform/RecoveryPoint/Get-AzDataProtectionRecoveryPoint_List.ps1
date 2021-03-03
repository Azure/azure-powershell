function Get-AzDataProtectionRecoveryPoint_List
{
	[OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Gets list of recovery point associated with a protected backup instance.')]

    param(
        [Parameter(Mandatory=$false, HelpMessage='Subscription Id of the vault')]
        [System.String[]]
        ${SubscriptionId},

        [Parameter(HelpMessage='Resource Group of the backup vault')]
        [System.String]
        ${ResourceGroupName},

        [Parameter(HelpMessage='Name of the backup vault')]
        [System.String]
        ${VaultName},

        [Parameter(HelpMessage='Unique Name of protected backup instance')]
        [System.String]
        ${BackupInstanceName}
    )

    process {
        $rps = Az.DataProtection.internal\Get-AzDataProtectionRecoveryPointList @PSBoundParameters
        return $rps
    }
}