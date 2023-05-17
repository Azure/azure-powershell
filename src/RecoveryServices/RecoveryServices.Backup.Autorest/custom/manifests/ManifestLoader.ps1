
function LoadManifest {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
    [OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Prepares Datasource object for backup')]

    param(
        [Parameter(ParameterSetName='GetByDatasourceType', Mandatory, HelpMessage='Datasource Type')]
        [System.String]
        ${DatasourceType}
    )

    process {
        # validate datasource type is valid 
        $manifestPath = $PSScriptRoot + "\" + $DatasourceType + ".json"
        $manifest = Get-Content -Path $manifestPath | ConvertFrom-Json
        
        return $manifest
    }
}

# RsvRef : get DSTypes - check this code
function GetDatasourceTypes {
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.DoNotExportAttribute()]
    [OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Description('Prepares Datasource object for backup')]

    param(
    )

    process {
        # validate datasource type is valid 
        $manifestPath = $PSScriptRoot + "/DatasourceTypesInfo.json"
        $manifest = Get-Content -Path $manifestPath | ConvertFrom-Json

        return $manifest
    }
}