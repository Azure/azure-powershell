$sub = "00000000-0000-0000-0000-000000000001"
$rg = "confluentorg-rg-fwh8oe"
$org = "confluentorg-63y1vz"
$apiVer = "2025-08-18-preview"
$url = "https://management.azure.com/subscriptions/$sub/resourceGroups/$rg/providers/Microsoft.Confluent/organizations/$org`?api-version=$apiVer"

function Build-OrgBody($tags) {
    $t = $tags | ConvertTo-Json -Compress
    return '{"id":"/subscriptions/' + $sub + '/resourceGroups/' + $rg + '/providers/Microsoft.Confluent/organizations/' + $org + '","name":"' + $org + '","type":"microsoft.confluent/organizations","location":"eastus2euap","tags":' + $t + ',"properties":{"createdTime":"0001-01-01T00:00:00Z","provisioningState":"Succeeded","offerDetail":{"publisherId":"confluentinc","id":"confluent-cloud-azure-stag","planId":"confluent-cloud-azure-payg-stag","planName":"Confluent Cloud - Pay as you Go","termUnit":"P1M","termId":"gmz7xq9ge3py","status":"Started"},"userDetail":{"firstName":"Test","lastName":"User","emailAddress":"user4@example.com","userPrincipalName":"user4@example.com"},"organizationId":"aaaabbbb-cccc-dddd-eeee-ffffffffffff","ssoUrl":"https://example.confluent.io/login/sso/aaaabbbb"}}'
}

$body3 = Build-OrgBody @{key01="value01";key02="value02";key03="value03"}
$body2 = Build-OrgBody @{key01="value01";key02="value02"}
$body0 = Build-OrgBody @{}

$len3 = [System.Text.Encoding]::UTF8.GetByteCount($body3)
$len2 = [System.Text.Encoding]::UTF8.GetByteCount($body2)
$len0 = [System.Text.Encoding]::UTF8.GetByteCount($body0)

Write-Output "body3 len=$len3, body2 len=$len2, body0 len=$len0"

$patchBody3 = '{"tags":{"key01":"value01","key02":"value02","key03":"value03"}}'
$patchBody2 = '{"tags":{"key01":"value01","key02":"value02"}}'

# Build the recording as a hashtable and convert to JSON
$recording = [ordered]@{}

$keys = @(
    @("UpdateExpanded", "PATCH", 1, $patchBody3, $body3, $len3),
    @("UpdateExpanded", "GET",   2, $null, $body3, $len3),
    @("UpdateViaIdentityExpanded", "GET",  1, $null, $body0, $len0),
    @("UpdateViaIdentityExpanded", "PATCH", 2, $patchBody2, $body2, $len2),
    @("UpdateViaIdentityExpanded", "GET",  3, $null, $body2, $len2)
)

foreach ($entry in $keys) {
    $scenario  = $entry[0]
    $method    = $entry[1]
    $counter   = $entry[2]
    $reqBody   = $entry[3]
    $respBody  = $entry[4]
    $respLen   = $entry[5]

    $key = "Update-AzConfluentOrganization+[NoContext]+$scenario+`$$method+$url+$counter"

    $reqContent = $null
    $reqContentHeaders = @{}
    if ($null -ne $reqBody) {
        $reqContent = $reqBody
        $reqContentHeaders = @{ "Content-Type" = @("application/json; charset=utf-8") }
    }

    $recording[$key] = @{
        Request = @{
            Method = $method
            RequestUri = $url
            Content = $reqContent
            isContentBase64 = $false
            Headers = @{
                "x-ms-unique-id" = @("1")
                "x-ms-client-request-id" = @("00000000-0000-0000-0000-000000000000")
                "CommandName" = @("Update-AzConfluentOrganization")
                "FullCommandName" = @("Update-AzConfluentOrganization_$scenario")
                "ParameterSetName" = @($scenario)
                "User-Agent" = @("AzurePowershell/v15.3.0", "PSVersion/v7.5.0", "Az.confluent/0.3.0")
                "Authorization" = @("[Filtered]")
            }
            ContentHeaders = $reqContentHeaders
        }
        Response = @{
            StatusCode = 200
            Headers = @{
                "Cache-Control" = @("no-cache")
                "Pragma" = @("no-cache")
                "x-ms-request-id" = @("00000000-0000-0000-0000-000000000000")
                "x-ms-correlation-request-id" = @("00000000-0000-0000-0000-000000000000")
                "x-ms-routing-request-id" = @("Sanitized")
                "Strict-Transport-Security" = @("max-age=31536000; includeSubDomains")
                "X-Content-Type-Options" = @("nosniff")
                "Date" = @("Sun, 22 Mar 2026 00:00:00 GMT")
            }
            ContentHeaders = @{
                "Content-Length" = @("$respLen")
                "Content-Type" = @("application/json; charset=utf-8")
                "Expires" = @("-1")
            }
            Content = $respBody
            isContentBase64 = $false
        }
    }
}

$outJson = $recording | ConvertTo-Json -Depth 10
$outPath = Join-Path $PSScriptRoot "src\Confluent\Confluent.Autorest\test\Update-AzConfluentOrganization.Recording.json"
[System.IO.File]::WriteAllText($outPath, $outJson, [System.Text.Encoding]::UTF8)

Write-Output "Written to $outPath"

# Verify
$parsed = Get-Content $outPath | ConvertFrom-Json
$keysFound = $parsed.PSObject.Properties.Count
Write-Output "Keys in JSON: $keysFound"
foreach ($k in $parsed.PSObject.Properties.Name) {
    Write-Output "  Key: $k"
}
