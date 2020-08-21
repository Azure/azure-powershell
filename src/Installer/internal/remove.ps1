$modules=Get-InstalledModule -Name @('Az','Az.*')

foreach ($module in $modules) {
    Write-Output("remove module:" + $module.Name)
    Uninstall-Module $module.Name    
}
