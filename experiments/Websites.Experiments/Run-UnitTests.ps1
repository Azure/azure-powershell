#Requires -Modules AzureRM.Websites.Experiments, Pester

$defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
Set-Location $defaults 
Invoke-Pester -EnableExit