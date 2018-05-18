$ErrorActionPreference = "Stop"
$scriptpath = $MyInvocation.MyCommand.Path
$scriptDirectory = Split-Path $scriptpath
$scriptFileName = Split-Path $scriptpath -Leaf

# Import-Module ..\..\..\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1
Import-Module ..\..\..\..\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.StorageSync\AzureRM.StorageSync.psd1 -Verbose

$VerbosePreference='Continue'

function prompt { return "PS> " }

Write-Verbose 'Your debugger is attached to current PowerShell instance'
