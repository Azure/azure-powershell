


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
        ${PolicyId}
    )

    process {

        $instance = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.BackupInstance]::new()
        $instance.DataSourceInfo = $DatasourceInfo
        $instance.PolicyInfo.PolicyId = $PolicyId
        $instance.ProtectionStatus.Status = "ProtectionConfigured"
        $instance.DataSourceSetInfo.DatasourceType = $DatasourceInfo.Type
        $instance.DataSourceSetInfo.ObjectType = "DatasourceSet"
        $splitResourceId = $DatasourceInfo.ResourceId.Split("/")
        $instance.DataSourceSetInfo.ResourceId = $splitResourceId[0..($splitResourceId.Count -3)] | Join-String -Separator '/'
        $instance.DataSourceSetInfo.ResourceLocation = $DatasourceInfo.ResourceLocation
        $instance.DataSourceSetInfo.ResourceName = $splitResourceId[$splitResourceId.Count -3]
        $splitResourceType = $DatasourceInfo.ResourceType.Split("/")
        $instance.DataSourceSetInfo.ResourceType =  $splitResourceType[0..($splitResourceType.Count -2)] | Join-String -Separator '/'     # Use manifest for datasource set type
        $instance.DataSourceSetInfo.ResourceUri = ""

        $instance.ObjectType = "BackupInstance"
        $guid = (New-Guid).Guid
        $name = $instance.DataSourceSetInfo.ResourceName + "-" + $DatasourceInfo.ResourceName + "-" + $guid    #Use manifest for constructing name here

        $match = $VaultId -match '/subscriptions/(?<subscription>.+)/resourceGroups/(?<rg>.+)/providers/(?<type>.+)/backupVaults/(?<vaultName>.+)'

        $null = $PSBoundParameters.Remove("VaultId")
        $null = $PSBoundParameters.Remove("DatasourceInfo")
        $null = $PSBoundParameters.Remove("PolicyId")
        $null = $PSBoundParameters.Add("Name", $name)
        $null = $PSBoundParameters.Add("ResourceGroupName", $Matches.rg)
        $null = $PSBoundParameters.Add("VaultName", $Matches.vaultName)
        $null = $PSBoundParameters.Add("SubscriptionId", $Matches.subscription)
        $null = $PSBoundParameters.Add("Property", $instance)
        Az.DataProtection\Set-AzDataProtectionBackupInstance @PSBoundParameters

    }

}