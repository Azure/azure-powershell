[CmdletBinding()]
Param(
[Parameter(Mandatory=$False, Position=0)]
[String]$Folder
)

# Function to sync assembly version with module version
function SyncVersion([string]$FilePath)
{ 
    $FolderPath = [System.IO.Path]::GetDirectoryName($FilePath)
    Write-Output "Folder Path: $FolderPath"
    $matches = ([regex]::matches((Get-Content $FilePath), "ModuleVersion = '([\d\.]+)'"))

    $packageVersion = $matches.Groups[1].Value
    Write-Output "Updating AssemblyInfo.cs inside of $FilePath to $packageVersion"

    $assemblyInfos = Get-ChildItem -Path $FolderPath -Filter AssemblyInfo.cs -Recurse
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
    $Folder = "$PSScriptRoot\..\src\ResourceManager"
}
$modules = Get-ChildItem -Path $Folder -Filter *.psd1 -Recurse -Exclude *.dll-help.psd1
ForEach ($module in $modules)
{
    SyncVersion $module.FullName
}