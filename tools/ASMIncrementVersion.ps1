[CmdletBinding()]
Param(
[Parameter(Mandatory=$False, Position=0)]
[String]$Folder,
[Parameter(ParameterSetName="Major", Mandatory=$True)]
[Switch]$Major,
[Parameter(ParameterSetName="Minor", Mandatory=$True)]
[Switch]$Minor,
[Parameter(ParameterSetName="Patch", Mandatory=$True)]
[Switch]$Patch
)

# Function to update nuspec file
function IncrementVersion([string]$FilePath)
{
    Write-Output "Updating File: $FilePath"   
    $content = Get-Content $FilePath
    $matches = ([regex]::matches($content, "ModuleVersion = '([\d\.]+)'"))

    $packageVersion = $matches.Groups[1].Value
    $version = $packageVersion.Split(".")
    
    $cMajor = $Major
    $cMinor = $Minor
    $cPatch = $Patch
       
    if ($cMajor)
    {
        $version[0] = 1 + $version[0]
        $version[1] = "0"
        $version[2] = "0"
    }
    
    if ($cMinor)
    {
        $version[1] = 1 + $version[1]
        $version[2] = "0"
    }
    
    if ($cPatch)
    {
        $version[2] = 1 + $version[2]
    }
    
    $version = [String]::Join(".", $version)
    
    Write-Output "Updating version of $FilePath from $packageVersion to $version"
    $content = $content.Replace("ModuleVersion = '$packageVersion'", "ModuleVersion = '$version'")
    
    Set-Content -Path $FilePath -Value $content -Encoding UTF8
    return $version
}

# Function to sync assembly version with module version
function SyncVersion([string]$FilePath, [string] $packageVersion)
{ 
    Write-Output "Updating AssemblyInfo.cs inside of $FilePath to $packageVersion"

    $assemblyInfos = Get-ChildItem -Path $FilePath -Filter AssemblyInfo.cs -Recurse
    ForEach ($assemblyInfo in $assemblyInfos)
    {
        $content = Get-Content $assemblyInfo.FullName
        $content = $content -replace "\[assembly: AssemblyVersion\([\w\`"\.]+\)\]", "[assembly: AssemblyVersion(`"$packageVersion`")]"
        $content = $content -replace "\[assembly: AssemblyFileVersion\([\w\`"\.]+\)\]", "[assembly: AssemblyFileVersion(`"$packageVersion`")]"
        Write-Output "Updating assembly version in " $assemblyInfo.FullName
        Set-Content -Path $assemblyInfo.FullName -Value $content -Encoding UTF8
    }   
    #$content = $content.Replace("ModuleVersion = '$packageVersion'", "ModuleVersion = '$version'")
    
    #Set-Content -path $FilePath -value $content
}

if (!$Folder) 
{
    $Folder = "$PSScriptRoot\..\src\ServiceManagement"
}


$psd1Path = $Folder + "\Services\Commands.Utilities\Azure.psd1"
$version = IncrementVersion $psd1Path
SyncVersion $Folder
