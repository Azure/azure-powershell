#Requires -Modules Pester

Import-Module $PSCommandPath\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1
Import-Module $PSCommandPath\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1
Import-Module $PSCommandPath\..\TestFx-Tasks.psd1
$defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
Set-Location $defaults 
Invoke-Pester
