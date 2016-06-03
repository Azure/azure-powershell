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

function ReplaceVersion([string]$key, [string]$line)
{
	$matches = ([regex]::matches($line, "$key = '([\d\.]+)'"))
	if($matches.Count -eq 1)
        {
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
            $line.Replace("$key = '$packageVersion'", "$key = '$version'")
        } else {
            $line
        }
}
# Function to update nuspec file
function IncrementVersion([string]$FilePath)
{
    Write-Output "Updating File: $FilePath"   
    (Get-Content $FilePath) | 
    ForEach-Object {
		$temp = ReplaceVersion "ModuleVersion" $_
		ReplaceVersion "RequiredVersion" $temp
    } | Set-Content -Path $FilePath -Encoding UTF8
}

if (!$Folder) 
{
    $Folder = "$PSScriptRoot\..\src\ResourceManager"
}

$modules = Get-ChildItem -Path $Folder -Filter *.psd1 -Recurse -Exclude *.dll-help.psd1
ForEach ($module in $modules)
{
    IncrementVersion($module.FullName)
}