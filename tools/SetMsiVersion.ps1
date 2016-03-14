[CmdletBinding()]
Param(
[Parameter(Mandatory=$True, Position=0)]
[String]$Version,
[Parameter(Mandatory=$True, Position=1)]
[String]$Release,
[Parameter(Mandatory=$False, Position=2)]
[String]$Folder
)

function SetMsiVersion([string]$FilePath, [string]$MsiVersion)
{ 
    $wxsPath = Join-Path $FilePath "azurecmd.wxs"

    Write-Output "Updating File: $wxsPath"   
    $content = Get-Content $wxsPath
    $matches = ([regex]::matches($content, '\<\?define version="([\d\.]+)" \?\>'))

    $prevousVersion = $matches.Groups[1].Value

    $content = $content.Replace("<?define version=`"$prevousVersion`" ?>", "<?define version=`"$MsiVersion`" ?>")
    
    Set-Content -Path $wxsPath -Value $content -Encoding UTF8
}

function SetMsiReleaseString([string]$FilePath, [string]$MsiRelease)
{ 
    $wxsPath = Join-Path $FilePath "azurecmd.wxs"

    Write-Output "Updating File: $wxsPath"   
    $content = Get-Content $wxsPath
    $matches = ([regex]::matches($content, '\<\?define productName="Microsoft Azure PowerShell - ([a-zA-z]+\s[\d]+)" \?\>'))

    $prevousVersion = $matches.Groups[1].Value
    Write-Output "Found: $prevousVersion"

    $content = $content.Replace("<?define productName=`"Microsoft Azure PowerShell - $prevousVersion`" ?>", "<?define productName=`"Microsoft Azure PowerShell - $MsiRelease`" ?>")
    
    Set-Content -Path $wxsPath -Value $content -Encoding UTF8
}

if (!$Folder) 
{
    $Folder = "$PSScriptRoot\..\setup"
}

SetMsiVersion $Folder $Version
SetMsiReleaseString $Folder $Release