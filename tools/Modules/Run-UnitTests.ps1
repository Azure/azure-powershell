#Requires -Modules Pester

Import-Module $PSCommandPath\TestFx-Tasks.psd1
$defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
Set-Location $defaults 
Invoke-Pester -EnableExit