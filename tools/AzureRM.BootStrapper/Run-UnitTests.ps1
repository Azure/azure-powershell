#Requires -Modules AzureRM.Bootstrapper, Pester

$defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
cd $defaults 

Invoke-Pester
