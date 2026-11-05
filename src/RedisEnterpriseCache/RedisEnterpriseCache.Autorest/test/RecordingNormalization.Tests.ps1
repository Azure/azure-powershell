# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
if ($TestName -and $TestName -notcontains 'RedisEnterpriseCache recording sanitization') { return }

Describe 'RedisEnterpriseCache recording sanitization' {
    BeforeEach {
        . (Join-Path $PSScriptRoot 'utils.ps1')
        $url = 'https://example.invalid/subscriptions/test/providers/Microsoft.Cache/locations/East%20US/operationsStatus/OpA?api-version=2025-07-01&t=token&c=certificate&s=signature&h=hash'
        $keyUrl = ([uri]$url).ToString()
        $safeUrl = $url -replace '(?<=[?&][tcsh]=)[^&]*', 'Sanitized'
        $safeKeyUrl = ([uri]$safeUrl).ToString()
        $safeJson = (ConvertTo-Json -InputObject $safeUrl -Compress).Trim('"')
        $safeKeyJson = (ConvertTo-Json -InputObject $safeKeyUrl -Compress).Trim('"')
        $content = @'
{
  "GET KEYURL+1": {
    "Request": {"RequestUri": "URL"},
    "Response": {"Headers": {"Azure-AsyncOperation": ["URL"], "Location": ["URL"]}, "Content": "payload"}
  }
}
'@.Replace('KEYURL', $keyUrl).Replace('URL', $url)
        $expected = $content.Replace($keyUrl, $safeKeyJson).Replace($url, $safeJson)
        $recordingPath = Join-Path $TestDrive 'ChangeSafety.Recording.json'
        [IO.File]::WriteAllText($recordingPath, $content)
    }

    It 'sanitizes lookup keys, encoded request URIs and polling response headers together' {
        Protect-RedisEnterpriseCacheTestRecording $content | Should -BeExactly $expected
    }

    It 'handles request lookup keys that already use the encoded URI' {
        $encoded = $content.Replace($keyUrl, $url)
        Protect-RedisEnterpriseCacheTestRecording $encoded | Should -BeExactly ($encoded.Replace($url, $safeJson))
    }

    It 'preserves lookup keys that differ only by case' {
        $second = $content.Replace('OpA', 'Opa')
        $combined = $content.TrimEnd().TrimEnd('}') + ',' + $second.TrimStart().Substring(1)
        $safeCombined = $expected.TrimEnd().TrimEnd('}') + ',' + $expected.Replace('OpA', 'Opa').TrimStart().Substring(1)
        Protect-RedisEnterpriseCacheTestRecording $combined | Should -BeExactly $safeCombined
    }

    It 'rejects collisions caused by redacting different signatures' {
        $second = $content.Replace('t=token', 't=other')
        $collision = $content.TrimEnd().TrimEnd('}') + ',' + $second.TrimStart().Substring(1)
        { Protect-RedisEnterpriseCacheTestRecording $collision } | Should -Throw 'duplicate recording lookup keys'
    }

    It 'preserves payload strings and unrelated URLs without reserializing the recording' {
        $payload = $content.Replace('payload', 'escaped \"quote\" and https://example.invalid/resource?t=keep')
        Protect-RedisEnterpriseCacheTestRecording $payload | Should -BeExactly ($expected.Replace('payload', 'escaped \"quote\" and https://example.invalid/resource?t=keep'))
    }

    It 'handles escaped JSON URL tokens' {
        $escaped = $content.Replace('&', '\u0026').Replace('?', '\u003f')
        Protect-RedisEnterpriseCacheTestRecording $escaped | Should -BeExactly $expected
    }

    It 'keeps normalized recordings unchanged' {
        Protect-RedisEnterpriseCacheTestRecording $expected | Should -BeExactly $expected
    }

    It 'preserves unrelated paths with similarly named query fields' {
        $other = $content.Replace('operationsStatus', 'resources')
        Protect-RedisEnterpriseCacheTestRecording $other | Should -BeExactly $other
    }

    It 'handles operation-result paths, mixed-case fields and fragments' {
        $candidate = $url.Replace('operationsStatus', 'operationResults').Replace('&t=', '&T=') + '#fragment'
        $safe = $safeUrl.Replace('operationsStatus', 'operationResults').Replace('&t=', '&T=') + '#fragment'
        Protect-RedisEnterpriseCacheTestPollingUrl $candidate | Should -BeExactly $safe
    }

    It 'sanitizes resource-scoped operation-result Location headers' {
        $candidate = $content.Replace('/locations/East%20US/operationsStatus/', '/redisEnterprise/cache/operationresults/')
        $candidate = $candidate.Replace('/locations/East US/operationsStatus/', '/redisEnterprise/cache/operationresults/')
        $safe = $expected.Replace('/locations/East%20US/operationsStatus/', '/redisEnterprise/cache/operationresults/')
        $safe = $safe.Replace('/locations/East US/operationsStatus/', '/redisEnterprise/cache/operationresults/')
        Protect-RedisEnterpriseCacheTestRecording $candidate | Should -BeExactly $safe
    }

    It 'preserves a URL without a query' {
        $withoutQuery = $url.Split('?')[0]
        Protect-RedisEnterpriseCacheTestPollingUrl $withoutQuery | Should -BeExactly $withoutQuery
    }

    It 'rejects malformed JSON' {
        { Protect-RedisEnterpriseCacheTestRecording '{"entry":' } | Should -Throw
    }

    It 'rejects a non-object recording' {
        { Protect-RedisEnterpriseCacheTestRecording '[]' } | Should -Throw 'JSON object'
    }

    It 'rejects a mismatched request lookup key' {
        { Protect-RedisEnterpriseCacheTestRecording ($content.Replace('GET ' + $keyUrl, 'GET missing')) } | Should -Throw 'lookup key does not contain'
    }

    It 'normalizes the completed Record file atomically' {
        $TestMode = 'record'
        Complete-RedisEnterpriseCacheTestRecording -Path $recordingPath
        [IO.File]::ReadAllText($recordingPath) | Should -BeExactly $expected
        Test-Path "$recordingPath.tmp" | Should -Be $false
    }

    It 'does not rewrite recordings in Playback or Live' {
        foreach ($mode in 'playback', 'live') {
            $TestMode = $mode
            Complete-RedisEnterpriseCacheTestRecording -Path $recordingPath
            [IO.File]::ReadAllText($recordingPath) | Should -BeExactly $content
        }
    }

    It 'does not replace the original file when sanitization fails' {
        $TestMode = 'record'
        [IO.File]::WriteAllText($recordingPath, '{"entry":')
        { Complete-RedisEnterpriseCacheTestRecording -Path $recordingPath } | Should -Throw
        [IO.File]::ReadAllText($recordingPath) | Should -BeExactly '{"entry":'
        Test-Path "$recordingPath.tmp" | Should -Be $false
    }
}
