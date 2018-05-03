#Requires -Modules Pester
$defaults = [System.IO.Path]::GetDirectoryName($PSScriptRoot)
Start-Job -ScriptBlock { 
    Import-Module $using:PSScriptRoot\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1;
    Import-Module $using:PSScriptRoot\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1;
    Set-Location $using:defaults; 
    Invoke-Pester 
} |  Receive-Job -Wait -AutoRemoveJob
