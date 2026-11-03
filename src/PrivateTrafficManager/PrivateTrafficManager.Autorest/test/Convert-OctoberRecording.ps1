#Requires -Version 7.0
[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string]$InputPath,
    [Parameter(Mandatory)]
    [string]$OutputPath,
    [Parameter(Mandatory)]
    [string]$SubscriptionId,
    [string]$OwnedResourceGroupName
)

$ErrorActionPreference = 'Stop'
$guidMap = @{}
function Convert-RecordingValue {
    param($Value)
    if ($Value -is [System.Collections.IDictionary]) {
        $converted = [ordered]@{}
        foreach ($entry in $Value.GetEnumerator()) {
            $key = Convert-RecordingValue $entry.Key
            if ($key -match '^(Authorization|Cookie|Set-Cookie)$') {
                $converted[$key] = @('[Filtered]')
            }
            else {
                $converted[$key] = Convert-RecordingValue $entry.Value
            }
        }
        return $converted
    }
    if ($Value -is [array]) {
        return ,@($Value | ForEach-Object { Convert-RecordingValue $_ })
    }
    if ($Value -is [string]) {
        $text = $Value.Replace($SubscriptionId, '00000000-0000-0000-0000-000000000000')
        $text = $text -replace 'ptm-pwsh-oct-[a-f0-9]+', 'ptm-october-validation'
        $text = $text -replace 'ptm-synthetics-probingplane', 'recording-gateways'
        $text = $text -replace 'ptm-syn-probe-westcentralus-pgw', 'recording-gateway'
        $text = $text -replace '[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}', 'recording@example.test'
        return [regex]::Replace($text, '(?i)[a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12}', {
            param($match)
            if ($match.Value -eq '00000000-0000-0000-0000-000000000000') { return $match.Value }
            if (-not $guidMap.ContainsKey($match.Value)) {
                $guidMap[$match.Value] = '00000000-0000-0000-0000-{0:D12}' -f ($guidMap.Count + 1)
            }
            return $guidMap[$match.Value]
        })
    }
    return $Value
}

$recording = Get-Content $InputPath -Raw | ConvertFrom-Json -AsHashtable
if ($OwnedResourceGroupName) {
    foreach ($exchange in $recording.Values) {
        if ($exchange -isnot [System.Collections.IDictionary] -or -not $exchange.Contains('Request')) { continue }
        $uri = [uri]$exchange.Request.RequestUri
        if ($exchange.Request.Method -eq 'GET' -and $uri.AbsolutePath -match '^/subscriptions/[^/]+/providers/Microsoft.Network/privateTrafficManagerProfiles/?$') {
            $content = $exchange.Response.Content | ConvertFrom-Json -AsHashtable
            $ownedPrefix = "/subscriptions/$SubscriptionId/resourceGroups/$OwnedResourceGroupName/"
            $content.value = @($content.value | Where-Object { $_.id.StartsWith($ownedPrefix, [StringComparison]::OrdinalIgnoreCase) })
            $exchange.Response.Content = ConvertTo-Json -InputObject $content -Depth 100 -Compress
            $exchange.Response.ContentHeaders.Remove('Content-Length')
        }
    }
}
$sanitized = Convert-RecordingValue $recording
$json = ConvertTo-Json -InputObject $sanitized -Depth 100
if ($json -match 'eyJ[A-Za-z0-9_-]+\.[A-Za-z0-9_-]+\.[A-Za-z0-9_-]+') {
    throw 'Potential JWT found; recording was not written.'
}
[System.IO.File]::WriteAllText($OutputPath, $json, [System.Text.UTF8Encoding]::new($false))
Write-Information "Sanitized $($sanitized.Count) exchanges." -InformationAction Continue