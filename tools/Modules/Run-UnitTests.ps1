#Requires -Modules Pester

Import-Module $PSCommandPath\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1
Import-Module $PSCommandPath\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1
Import-Module $PSCommandPath\..\TestFx-Tasks.psd1
$defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
Start-Job -ScriptBlock { 
    Import-Module $using:PSCommandPath\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1;
    Import-Module $using:PSCommandPath\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1;
    Import-Module $using:PSCommandPath\..\TestFx-Tasks.psd1;
    Set-Location $using:defaults; 
    Invoke-Pester 
} |  Receive-Job -Wait -AutoRemoveJob
