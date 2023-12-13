[CmdletBinding()]
param (
    [Parameter(Mandatory = $true)]
    [string]
    $AzVersion,

    [Parameter(Mandatory = $true)]
    [string]
    $NugetPath
)

$module = Find-Module -name Az -RequiredVersion $AzVersion
if ($null -ne $module)
{
    $null = Install-AzModule -RequiredAzVersion $AzVersion -UseExactAccountVersion -Repository PSGallery
}
else
{
    throw "The specified version $AzVersion is not found in PSGallery."
}
$accountsVersion = ($module.Dependencies | Where-Object {$_.Name -eq "Az.Accounts"}).MinimumVersion
$null = Install-AzModule -Path $NugetPath

$accountsVersion