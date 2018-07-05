[CmdletBinding(
    SupportsShouldProcess=$true
)]
param(
    [Parameter(Mandatory = $false)]
    [string] $BuildConfig = "Debug",
    [Parameter(Mandatory = $false)]
    [string] $CIToolsPath
)

& "$CIToolsPath\tools\PoliCheck\PoliCheck5.8.1\PoliCheck.exe" /F:"$PSScriptRoot\..\src\Package" /T:"9" /O:"$PSScriptRoot\..\src\Package\PoliCheck-Scan.xml"

$poliCheckReport = Get-Content $PSScriptRoot\..\src\Package\PoliCheck-Scan.xml
if ($poliCheckReport -like "*Severity=`"1`"*")
{
    throw "PoliCheck failed with a Severity 1 issue, please check the report at in src/Package/PoliCheck-Scan.html"
}