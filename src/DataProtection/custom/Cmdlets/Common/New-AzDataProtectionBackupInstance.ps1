


function New-AzDataProtectionBackupInstance {
    [OutputType('')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Configures Backup for supported azure resources')]

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

        [Parameter(Mandatory, HelpMessage='Backup instance request object which will be used to configure backup')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20210201Preview.IBackupInstanceResource]
        ${BackupInstance}

    )

    process {
        

        $name = $BackupInstance.BackupInstanceName
        $null = $PSBoundParameters.Remove("BackupInstance")
        $null = $PSBoundParameters.Add("BackupInstance", $BackupInstance.Property)
        $null = Az.DataProtection.Internal\Test-AzDataProtectionBackupInstance @PSBoundParameters
        $null = $PSBoundParameters.Remove("BackupInstance")
        $null = $PSBoundParameters.Add("Name", $name)
        $null = $PSBoundParameters.Add("Parameter", $BackupInstance)

        Az.DataProtection.Internal\New-AzDataProtectionBackupInstance @PSBoundParameters
    }

}