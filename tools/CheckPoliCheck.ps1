[CmdletBinding(
    SupportsShouldProcess=$true
)]
param(
    [Parameter(Mandatory = $false)]
    [string] $BuildConfig = "Debug",
    [Parameter(Mandatory = $false)]
    [string] $CIToolsPath
)

& "$CIToolsPath\tools\PoliCheck\PoliCheck5.8.1\PoliCheck.exe" /F:"$PSScriptRoot\..\artifacts\$BuildConfig" /T:"9" /O:"$PSScriptRoot\..\artifacts\PoliCheck-Scan.xml"

[xml]$poliCheckReport = Get-Content $PSScriptRoot\..\artifacts\PoliCheck-Scan.xml

$hits = $poliCheckReport.PLCKRR.Result.Object | Where-Object { $_.Severity -eq 1 }

$suppressions = Get-Content -Raw $PSScriptRoot/PolicheckSuppressions.json | ConvertFrom-Json

$hits | ForEach-Object {
    $relativePath = ($_.URL -split "artifacts")[1]
    $fileName = "artifacts" + $relativePath
    $TermId = $_.TermId
    if ($suppressions.$fileName -ne $TermId)
    {
        throw "PoliCheck failed with a Severity 1 issue, please check the report at in artifacts/PoliCheck-Scan.html"
    }
}
