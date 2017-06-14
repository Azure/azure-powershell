[CmdletBinding()]
Param(
[Parameter(Mandatory=$False, Position=0)]
[String]$Folder,
[Parameter(Mandatory=$False)]
[bool]$Major,
[Parameter(Mandatory=$False)]
[bool]$Minor,
[Parameter(Mandatory=$False)]
[bool]$Patch
)

# Function to update nuspec file
function IncrementVersion([string]$FilePath)
{

    $psd1Path = Join-Path $FilePath "\Services\Commands.Utilities\Azure.psd1"

    Write-Output "Updating File: $psd1Path"   
    $content = Get-Content $psd1Path
    $matches = ([regex]::matches($content, "ModuleVersion = '([\d\.]+)'"))

    $packageVersion = $matches.Groups[1].Value
    $version = $packageVersion.Split(".")
    
    $cMajor = $Major
    $cMinor = $Minor
    $cPatch = $Patch
       
    if ($cMajor -eq $true)
    {
        $version[0] = 1 + $version[0]
        $version[1] = "0"
        $version[2] = "0"
    }
    
    if ($cMinor -eq $true)
    {
        $version[1] = 1 + $version[1]
        $version[2] = "0"
    }
    
    if ($cPatch -eq $true)
    {
        $version[2] = 1 + $version[2]
    }
    
    $version = [String]::Join(".", $version)
    
    Write-Output "Updating version of $psd1Path from $packageVersion to $version"
    $content = $content.Replace("ModuleVersion = '$packageVersion'", "ModuleVersion = '$version'")
    
    Set-Content -Path $psd1Path -Value $content -Encoding UTF8

    Write-Output "Updating AssemblyInfo.cs inside of $FilePath to $packageVersion"

    $assemblyInfos = Get-ChildItem -Path $FilePath -Filter AssemblyInfo.cs -Recurse
    ForEach ($assemblyInfo in $assemblyInfos)
    {
        $content = Get-Content $assemblyInfo.FullName
        $content = $content -replace "\[assembly: AssemblyVersion\([\w\`"\.]+\)\]", "[assembly: AssemblyVersion(`"$version`")]"
        $content = $content -replace "\[assembly: AssemblyFileVersion\([\w\`"\.]+\)\]", "[assembly: AssemblyFileVersion(`"$version`")]"
        Write-Output "Updating assembly version in " $assemblyInfo.FullName
        Set-Content -Path $assemblyInfo.FullName -Value $content -Encoding UTF8
    }   
}

# Function to update nuspec file
function UpdateStorageVersion([string]$FilePath)
{

    $psd1Path = Join-Path $FilePath "\Services\Commands.Utilities\Azure.psd1"

    Write-Output "Updating File: $psd1Path"   
    $content = Get-Content $psd1Path
    $matches = ([regex]::matches($content, "; ModuleVersion = '([\d\.]+)'"))

    $packageVersion = $matches.Groups[1].Value
    $version = $packageVersion.Split(".")
    
    $cMajor = $Major
    $cMinor = $Minor
    $cPatch = $Patch
       
    if ($cMajor -eq $true)
    {
        $version[0] = 1 + $version[0]
        $version[1] = "0"
        $version[2] = "0"
    }
    
    if ($cMinor -eq $true)
    {
        $version[1] = 1 + $version[1]
        $version[2] = "0"
    }
    
    if ($cPatch -eq $true)
    {
        $version[2] = 1 + $version[2]
    }
    
    $version = [String]::Join(".", $version)
    
    Write-Output "Updating version of $psd1Path from $packageVersion to $version"
    $content = $content.Replace("; ModuleVersion = '$packageVersion'", "; ModuleVersion = '$version'")
    
    Set-Content -Path $psd1Path -Value $content -Encoding UTF8
}

if (!$Folder) 
{
    $Folder = "$PSScriptRoot\..\src\ServiceManagement"
}

IncrementVersion $Folder
UpdateStorageVersion $Folder
