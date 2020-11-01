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
    $wxsPath = Join-Path $FilePath "setup\azurecmd.wxs"

    Write-Output "Updating File: $wxsPath"   
    $content = Get-Content $wxsPath
    $matches = ([regex]::matches($content, '\<\?define version="([\d\.]+)" \?\>'))

    $prevousVersion = $matches.Groups[1].Value

    $content = $content.Replace("<?define version=`"$prevousVersion`" ?>", "<?define version=`"$MsiVersion`" ?>")
    
    Set-Content -Path $wxsPath -Value $content -Encoding UTF8
}

function SetMsiReleaseString([string]$FilePath, [string]$MsiRelease)
{ 
    $wxsPath = Join-Path $FilePath "setup\azurecmd.wxs"

    Write-Output "Updating File: $wxsPath"   
    $content = Get-Content $wxsPath
    $matches = ([regex]::matches($content, '\<\?define productName="Microsoft Azure PowerShell - ([a-zA-z]+\s[\d]+)" \?\>'))

    $prevousVersion = $matches.Groups[1].Value

    $content = $content.Replace("<?define productName=`"Microsoft Azure PowerShell - $prevousVersion`" ?>", "<?define productName=`"Microsoft Azure PowerShell - $MsiRelease`" ?>")
    
    Set-Content -Path $wxsPath -Value $content -Encoding UTF8
}

function AlignAsmPsdReleaseVersion([string]$FilePath, [string]$MsiVersion)
{
    $psd1Path = Join-Path $FilePath "src\ServiceManagement\Services\Commands.Utilities\Azure.psd1"

    $content = Get-Content $psd1Path
    $matches = ([regex]::matches($content, "ModuleVersion = '([\d\.]+)'\s+"))

    $packageVersion = $matches.Groups[1].Value
    Write-Output "Updating version of $psd1Path from $packageVersion to $MsiVersion"
    $content = $content.Replace("ModuleVersion = '$packageVersion'", "ModuleVersion = '$MsiVersion'")
    
    Set-Content -Path $psd1Path -Value $content -Encoding UTF8
}

function AlignArmPsdReleaseVersion([string]$FilePath, [string]$MsiVersion)
{
    $psd1Path = Join-Path $FilePath "tools\AzureRM\AzureRM.psd1"

    $content = Get-Content $psd1Path
    $matches = ([regex]::matches($content, "ModuleVersion = '([\d\.]+)'\s+"))

    $packageVersion = $matches.Groups[1].Value
    Write-Output "Updating version of $psd1Path from $packageVersion to $MsiVersion"
    $content = $content.Replace("ModuleVersion = '$packageVersion'", "ModuleVersion = '$MsiVersion'")
    
    Set-Content -Path $psd1Path -Value $content -Encoding UTF8
}

if (!$Folder) 
{
    $Folder = "$PSScriptRoot\.."
}

SetMsiVersion $Folder $Version
SetMsiReleaseString $Folder $Release
AlignAsmPsdReleaseVersion $Folder $Version
AlignArmPsdReleaseVersion $Folder $Version