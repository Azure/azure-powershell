


function Set-AzDataProtectionBackupInstance_dppplatform {
    [OutputType('')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Configure Backup')]

    param(
        [Parameter(Mandatory, HelpMessage='Vault Id')]
        [System.String]
        ${VaultId},

        [Parameter(Mandatory, HelpMessage='Datasource Details')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IBackupInstanceResource]
        ${BackupInstance}

    )

    process {
        

        $name = $BackupInstance.BackupInstanceName

        $match = $VaultId -match '/subscriptions/(?<subscription>.+)/resourceGroups/(?<rg>.+)/providers/(?<type>.+)/backupVaults/(?<vaultName>.+)'

        $null = $PSBoundParameters.Remove("VaultId")
        $null = $PSBoundParameters.Remove("BackupInstance")

        $null = $PSBoundParameters.Add("Name", $name)
        $null = $PSBoundParameters.Add("ResourceGroupName", $Matches.rg)
        $null = $PSBoundParameters.Add("VaultName", $Matches.vaultName)
        $null = $PSBoundParameters.Add("SubscriptionId", $Matches.subscription)
        $null = $PSBoundParameters.Add("Parameter", $BackupInstance)

        Az.DataProtection\Set-AzDataProtectionBackupInstance @PSBoundParameters
    }

}