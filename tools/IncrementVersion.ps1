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
    
    Set-Content -path $FilePath -value $content
}

$modules = Get-ChildItem -Path $Folder -Filter *.psd1 -Recurse -Exclude *.dll-help.psd1
ForEach ($module in $modules)
{
    IncrementVersion($module.FullName)
}