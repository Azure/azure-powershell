param(
	[Parameter(Mandatory=$true)]
	$Configuraton)

$ErrorActionPreference = "Stop"
$scriptpath = $MyInvocation.MyCommand.Path
$scriptDirectory = Split-Path $scriptpath
$scriptFileName = Split-Path $scriptpath -Leaf

Import-Module "..\..\..\..\..\..\src\Package\$Configuraton\ResourceManager\AzureResourceManager\AzureRM.StorageSync\AzureRM.StorageSync.psd1" -Verbose

$VerbosePreference='Continue'

function prompt { return "PS> " }

Write-Verbose 'Your debugger is attached to current PowerShell instance'
