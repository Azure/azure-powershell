# .\UpdateNugetPackage.ps1 "Microsoft.Rest.ClientRuntime" "2.1.0" "2.3.1"
[CmdletBinding()]
Param(
[Parameter(Mandatory=$True, Position=0)]
[String]$packageName,
[Parameter(Mandatory=$True, Position=1)]
[String]$packageOldVersion,
[Parameter(Mandatory=$True, Position=2)]
[String]$packageNewVersion
)

function ReplaceVersion([string]$searchString,[string]$line)
{
    if($line -Match $searchString)
    {
        $unmaskedString=$searchString.Replace("\\", "\")
        $newVersion=$unmaskedString.Replace("$packageOldVersion","$packageNewVersion")
        $line.Replace($unmaskedString, $newVersion)
    } else {
        $line
    }
}

# Function to update nuspec file
function IncrementVersion([string]$FilePath,[string]$SearchString)
{
    Write-Output "Updating File: $FilePath"   
    Write-Output "Replacing: $SearchString"   
    (Get-Content $FilePath) | 
    ForEach-Object {
        ReplaceVersion $SearchString $_
    } | Set-Content -Path $FilePath -Encoding UTF8
}

$Folder = "$PSScriptRoot\..\src"

$modules = Get-ChildItem -Path $Folder -Filter packages.config -Recurse
$sString="id=`"$packageName`" version=`"$packageOldVersion`""
ForEach ($module in $modules)
{
    IncrementVersion $module.FullName $sString
}

$modules = Get-ChildItem -Path $Folder -Filter *.csproj -Recurse
$sString="\\packages\\$packageName.$packageOldVersion\\lib"
ForEach ($module in $modules)
{
    IncrementVersion $module.FullName $sString
}