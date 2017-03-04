#Requires -Modules AzureRM.Bootstrapper, Pester

$defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
Set-Location $defaults 

Invoke-Pester -EnableExit
