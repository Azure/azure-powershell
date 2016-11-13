Import-Module -Name AzureRM.Bootstrapper

if ((Get-Module -Name Pester) -eq $null)
{
    Find-Module –Name 'Pester' | Install-Module
    Import-Module -Name 'Pester'
}

$defaults = [System.IO.Path]::GetDirectoryName($PSCommandPath)
cd $defaults 

Invoke-Pester
