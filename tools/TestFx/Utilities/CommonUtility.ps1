function RemovePreInstalledModule {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory, Position = 0)]
        [Alias("ModuleName")]
        [ValidateNotNullOrEmpty()]
        [string] $Name
    )

    # Remove Az modules
    Get-Module -Name $Name* -ListAvailable | ForEach-Object {
        $moduleDirectory = $_.Path | Split-Path | Split-Path
        if (Test-Path -LiteralPath $moduleDirectory) {
            Remove-Item -LiteralPath $moduleDirectory -Recurse -Force
        }
    }
}

RemovePreInstalledModule -Name Az
RemovePreInstalledModule -Name AzureRM
