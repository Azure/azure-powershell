if (($null -eq $TestName) -or ($TestName -contains 'New-AzSelfHelpDiagnostic')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSelfHelpDiagnostic.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzSelfHelpDiagnostic' -Tag 'LiveOnly' {
    It 'CreateExpanded' {
        { 
            $resourceName = RandomString -allChars $false -len 10
            $insightsToInvoke = [ordered]@{
                "solutionId" = "Demo2InsightV2"
            }
            New-AzSelfHelpDiagnostic -Scope $env.scope -SResourceName $resourceName -Insight $insightsToInvoke
        } | Should -Not -Throw
    }
}