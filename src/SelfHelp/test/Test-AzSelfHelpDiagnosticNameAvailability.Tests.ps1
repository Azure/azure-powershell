if (($null -eq $TestName) -or ($TestName -contains 'Test-AzSelfHelpDiagnosticNameAvailability')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzSelfHelpDiagnosticNameAvailability.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzSelfHelpDiagnosticNameAvailability' {
    It 'CheckExpanded' {
        $resourceName = RandomString -allChars $true -len 10
        $scope = "/subscriptions/$($env.SubscriptionId)"
        $type = "microsoft.help/diagnostics"
        $result = Test-AzSelfHelpDiagnosticNameAvailability -Name $resourceName -Type $type -Scope $scope
        $result.NameAvailable | Should -Be $true
    }
}