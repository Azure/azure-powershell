# Copyright Microsoft Corporation. Licensed under the Apache License, Version 2.0.
if ($TestName -and $TestName -notcontains 'Recording normalization') { return }

Describe 'Recording normalization' {
    BeforeEach {
        $work = Join-Path $TestDrive ([guid]::NewGuid().ToString('N'))
        $null = New-Item -ItemType Directory -Path $work
        Copy-Item (Join-Path $PSScriptRoot 'utils.ps1') $work
        . (Join-Path $work 'utils.ps1')
        $TestMode = 'record'
        $UsePreviousConfigForRecord = $false
        $script:edgeActionEnvironmentStarted = $true
        $group = 'rgps-powershellsdk-edgeaction-tests-012345abcdef'
        $env = @{
            ResourceGroupName = $group
            ResourceGroupState = 'Created'
            SubscriptionId = 'test-subscription'
            Tenant = 'test-tenant'
            EnvironmentName = 'AzureCloud'
            EdgeActionFixtures = @{}
        }
        Save-EdgeActionTestEnvironment
        $url = 'https://example.invalid/providers/Microsoft.Cdn/edgeactionoperations/OpA?api-version=2026-10-01&t=token&c=credential&s=signature&h=hash'
        $safeUrl = $url -replace '(?<=[?&][tcsh]=)[^&]*', 'Sanitized'
        $safeJson = (ConvertTo-Json -InputObject $safeUrl -Compress).Trim('"')
        $content = @'
{
  "GET URL": {
    "Request": {"RequestUri": "URL"},
    "Response": {"Headers": {"Azure-AsyncOperation": ["URL"], "Location": ["URL"]}, "Content": "payload GROUP"}
  }
}
'@.Replace('URL', $url).Replace('GROUP', $group)
        $recordingPath = Join-Path $work 'Example.Recording.json'
        [IO.File]::WriteAllText($recordingPath, $content)
        Mock Assert-EdgeActionTestResourceGroup {}
        Mock Invoke-EdgeActionTestCommand {
            if ($Command -eq 'Get-AzResourceGroup') {
                $script:groupReads++
                return @{ NotFound = ($script:groupReads -gt 1) }
            }
        }
        $script:groupReads = 0
    }

    It 'normalizes recordings and environment after Record cleanup deletes the group' {
        cleanupEnv
        Assert-MockCalled Invoke-EdgeActionTestCommand -Scope It -Times 1 -Exactly -ParameterFilter { $Command -eq 'Remove-AzResourceGroup' }
        $actual = [IO.File]::ReadAllText($recordingPath)
        $actual | Should -BeExactly ($content.Replace($url, $safeJson).Replace($group, 'powershellsdk-edgeaction-tests-rgname'))
        $saved = Get-Content (Join-Path $work 'env.json') -Raw | ConvertFrom-Json
        $saved.ResourceGroupState | Should -Be 'Cleaned'
        $saved.ResourceGroupName | Should -Be 'powershellsdk-edgeaction-tests-rgname'
    }

    It 'recovers normalization after the resource group was already deleted' {
        $env.ResourceGroupState = 'Cleaned'
        Save-EdgeActionTestEnvironment
        Resume-EdgeActionTestCleanup -Mode record -ResourceGroup -Confirm:$false
        Assert-MockCalled Invoke-EdgeActionTestCommand -Scope It -Times 0 -Exactly
        [IO.File]::ReadAllText($recordingPath) | Should -BeExactly ($content.Replace($url, $safeJson).Replace($group, 'powershellsdk-edgeaction-tests-rgname'))
        (Get-Content (Join-Path $work 'env.json') -Raw | ConvertFrom-Json).ResourceGroupName | Should -Be 'powershellsdk-edgeaction-tests-rgname'
    }

    It 'preserves distinct lookup keys that differ only by case' {
        $second = $content.Replace('OpA', 'Opa')
        $combined = $content.TrimEnd().TrimEnd('}') + ',' + $second.TrimStart().Substring(1)
        Protect-EdgeActionTestRecording $combined | Should -BeExactly ($combined.Replace($url, $safeJson).Replace($url.Replace('OpA', 'Opa'), $safeJson.Replace('OpA', 'Opa')))
    }

    It 'rejects collisions before writing recordings or normalizing environment metadata' {
        $env.ResourceGroupState = 'Cleaned'
        Save-EdgeActionTestEnvironment
        $second = $content.Replace('t=token', 't=other')
        $collision = $content.TrimEnd().TrimEnd('}') + ',' + $second.TrimStart().Substring(1)
        $collisionPath = Join-Path $work 'Collision.Recording.json'
        [IO.File]::WriteAllText($collisionPath, $collision)
        $saved = [IO.File]::ReadAllText((Join-Path $work 'env.json'))
        { Complete-EdgeActionTestRecording } | Should -Throw 'duplicate recording lookup keys'
        [IO.File]::ReadAllText($recordingPath) | Should -BeExactly $content
        [IO.File]::ReadAllText($collisionPath) | Should -BeExactly $collision
        [IO.File]::ReadAllText((Join-Path $work 'env.json')) | Should -BeExactly $saved
    }

    It 'preserves payload strings and unrelated URLs without reserializing the recording' {
        $payload = $content.Replace('payload ' + $group, 'escaped \"quote\" and https://example.invalid/resource?t=keep')
        Protect-EdgeActionTestRecording $payload | Should -BeExactly ($payload.Replace($url, $safeJson))
    }

    It 'handles escaped URL tokens' {
        $escaped = $content.Replace('&', '\u0026').Replace('?', '\u003f')
        Protect-EdgeActionTestRecording $escaped | Should -BeExactly ($content.Replace($url, $safeJson))
    }

    It 'leaves already normalized recordings unchanged' {
        $safe = $content.Replace($url, $safeUrl)
        Protect-EdgeActionTestRecording $safe | Should -BeExactly $safe
    }

    It 'rejects malformed JSON' {
        { Protect-EdgeActionTestRecording '{"entry":' } | Should -Throw
    }

    It 'rejects a non-object recording' {
        { Protect-EdgeActionTestRecording '[]' } | Should -Throw 'JSON object'
    }
}
