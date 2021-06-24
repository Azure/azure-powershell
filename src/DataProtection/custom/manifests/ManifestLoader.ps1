
function LoadManifest {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    [OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Prepares Datasource object for backup')]

    param(
        [Parameter(ParameterSetName='GetByDarasourceType', Mandatory, HelpMessage='Datasource Type')]
        [System.String]
        ${DatasourceType}
    )

    process {
        # validate datasource type is valid 
        $manifestPath = $PSScriptRoot + "/" + $DatasourceType + ".json"
        $manifest = Get-Content -Path $manifestPath | ConvertFrom-Json

        return $manifest
    }
}

function GetDatasourceTypes {
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
    [OutputType('PSObject')]
    [CmdletBinding(PositionalBinding=$false)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Prepares Datasource object for backup')]

    param(
    )

    process {
        # validate datasource type is valid 
        $manifestPath = $PSScriptRoot + "/DatasourceTypesInfo.json"
        $manifest = Get-Content -Path $manifestPath | ConvertFrom-Json

        return $manifest
    }
}