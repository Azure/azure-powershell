function RemovePreInstalledModule {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [hashtable] $ModuleToRemove
    )

    $ModuleToRemove.Keys | ForEach-Object {
        $moduleName = $_
        $moduleVersion = $ModuleToRemove[$moduleName]

        Write-Host "##[group]Processing module $moduleName"

        Write-Host "All installed modules with name $moduleName :"
        Get-Module -Name $moduleName -ListAvailable
        Write-Host

        $modules = Get-Module -Name $moduleName -ListAvailable | Where-Object Version -gt ([Version]$moduleVersion)
        $modules | ForEach-Object {
            $installedModule = $_
            $installedModuleName = $installedModule.Name

            Write-Host "##[section]Unqualified pre-installed module is $installedModuleName with version $($installedModule.Version)."
            $installedModule | Format-List

            $moduleDirectory = $installedModule.Path | Split-Path | Split-Path
            if (Test-Path -Path $moduleDirectory) {
                Write-Host "##[section]Start to remove module located in $moduleDirectory."
                Remove-Item -Path $moduleDirectory -Recurse -Force -ErrorAction SilentlyContinue
                Write-Host "##[section]Module $installedModuleName has been removed."
                Write-Host
            }
        }

        Write-Host "##[endgroup]"
        Write-Host
    }
}

$modulesToRemove = @{
    "Az" = "0.0.0.0";
    "Az.*" = "0.0.0.0";
    "Azure" = "0.0.0.0";
    "Azure.*" = "0.0.0.0";
    "AzureRM" = "0.0.0.0";
    "AzureRM.*" = "0.0.0.0";
    "Pester" = "4.10.1.0"
}
RemovePreInstalledModule -ModuleToRemove $modulesToRemove
