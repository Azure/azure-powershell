


function Set-AzDataProtectionBackupInstance_dppplatform {
    [OutputType('')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Configure Backup')]

    param(
        [Parameter(Mandatory, HelpMessage='Vault Id')]
        [System.String]
        # ...
        ${VaultId},

        [Parameter(Mandatory, HelpMessage='Datasource Details')]
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDatasource]
        # ...
        ${DatasourceInfo},

        [Parameter(Mandatory, HelpMessage='Policy Id')]
        [System.String]
        # ...
        ${PolicyId},

        [Parameter(Mandatory, HelpMessage='Datasource Type')]
        [System.String]
        [ValidateSet("AzureDatabaseForPostgreSQL", "AzureBlob", IgnoreCase = $true)]
        # ...
        ${DatasourceType}
    )

    process {
        
        $manifest = LoadManifest -DatasourceType $DatasourceType
        $instance = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BackupInstance]::new()
        $instance.DataSourceInfo = $DatasourceInfo
        $instance.PolicyInfo.PolicyId = $PolicyId
        $instance.ProtectionStatus.Status = "ProtectionConfigured"
        if($manifest.isProxyResource -eq $true)
        {
            $instance.DataSourceSetInfo = GetDatasourceSetInfo -DatasourceInfo $DatasourceInfo
        }

        $instance.ObjectType = "BackupInstance"
        $guid = (New-Guid).Guid
        $name = $instance.DataSourceSetInfo.ResourceName + "-" + $DatasourceInfo.ResourceName + "-" + $guid    #Use manifest for constructing name here

        $match = $VaultId -match '/subscriptions/(?<subscription>.+)/resourceGroups/(?<rg>.+)/providers/(?<type>.+)/backupVaults/(?<vaultName>.+)'

        $null = $PSBoundParameters.Remove("VaultId")
        $null = $PSBoundParameters.Remove("DatasourceInfo")
        $null = $PSBoundParameters.Remove("PolicyId")
        $null = $PSBoundParameters.Remove("DatasourceType")
        $null = $PSBoundParameters.Add("Name", $name)
        $null = $PSBoundParameters.Add("ResourceGroupName", $Matches.rg)
        $null = $PSBoundParameters.Add("VaultName", $Matches.vaultName)
        $null = $PSBoundParameters.Add("SubscriptionId", $Matches.subscription)
        $null = $PSBoundParameters.Add("Property", $instance)
        Az.DataProtection\Set-AzDataProtectionBackupInstance @PSBoundParameters

    }

}