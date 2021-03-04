


function Set-AzDataProtectionBackupInstance_dppplatform {
    [OutputType('')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Configures Backup for supported azure resources')]

    param(
        [Parameter(Mandatory, HelpMessage='Id of the backup vault')]
        [System.String]
        ${VaultId},

        [Parameter(Mandatory, HelpMessage='Backup instance request object which will be used to configure backup')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupInstanceResource]
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