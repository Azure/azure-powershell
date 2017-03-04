#Requires -Modules AzureRM.Bootstrapper, Pester

$defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
Set-Location $defaults 

. .\AzureRM.Bootstrapper.ScenarioTests.ps1