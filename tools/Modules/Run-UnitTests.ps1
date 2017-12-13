#Requires -Modules Pester
$defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
Start-Job -ScriptBlock { 
    Import-Module $using:PSCommandPath\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1;
    Import-Module $using:PSCommandPath\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1;
    Set-Location $using:defaults; 
    Invoke-Pester 
} |  Receive-Job -Wait -AutoRemoveJob
