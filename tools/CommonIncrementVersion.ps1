[CmdletBinding()]
Param(
[Parameter(Mandatory=$True, Position=0)]
[String]$Version,
[Parameter(Mandatory=$False, Position=1)]
[String]$Folder
)

function SetCommandsCommonVersion([string]$FilePath, [string]$Version)
{
    $powershellCs = Join-Path $FilePath "Common\Commands.Common\AzurePowerShell.cs"

    Write-Output "Updating File: $powershellCs"   
    $content = Get-Content $powershellCs
    $content = $content -replace "public const string AssemblyVersion = `"([\d\.]+)`";", "public const string AssemblyVersion = `"$Version`";"
    $content = $content -replace "public const string AssemblyFileVersion = `"([\d\.]+)`";", "public const string AssemblyFileVersion = `"$Version`";"
    
    Set-Content -Path $powershellCs -Value $content -Encoding UTF8
}

function SetArmCommonVersion([string]$FilePath, [string]$Version)
{
    $assemblyConfig = Join-Path $FilePath "ResourceManager\Common\Commands.ResourceManager.Common\Properties\AssemblyInfo.cs"
    
    Write-Output "Updating File: $assemblyConfig"   
    $content = Get-Content $assemblyConfig
    $content = $content -replace "\[assembly: AssemblyVersion\([\w\`"\.]+\)\]", "[assembly: AssemblyVersion(`"$Version`")]"
    $content = $content -replace "\[assembly: AssemblyFileVersion\([\w\`"\.]+\)\]", "[assembly: AssemblyFileVersion(`"$Version`")]"
    
    Set-Content -Path $assemblyConfig -Value $content -Encoding UTF8
}

if (!$Folder) 
{
    $Folder = "$PSScriptRoot\..\src"
}

SetCommandsCommonVersion $Folder $Version
SetArmCommonVersion $Folder $Version