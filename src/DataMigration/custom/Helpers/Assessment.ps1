function Test-ConfigFile{
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $path
    )

    process {
        if (!(Test-Path -Path $path))
        {
            throw "Invalid Config File path: $path"
        } 

        $ConfigJson = Get-Content -Raw -Path $path | ConvertFrom-Json
        if(-Not (($ConfigJson.action -eq "Assess") -Or ($ConfigJson.action -eq "assess")))
        {
            throw "The desired action was invalid.";
        }

    }
}
