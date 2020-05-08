$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzImageBuilderCustomizer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzImageBuilderCustomizer' {
    It 'WindowsUpdateCustomizer' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'FileCustomizer' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ShellCustomizer' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PowerShellCustomizer' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'RestartCustomizer' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
