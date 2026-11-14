Describe 'NetworkSecurity test environment loading' {
    It 'loads <FileName> using the <Location> environment file' -TestCases @(
        @{ Mode = 'playback'; FileName = 'env.json'; Location = 'parent' }
        @{ Mode = 'live'; FileName = 'localEnv.json'; Location = 'parent' }
        @{ Mode = 'playback'; FileName = 'env.json'; Location = 'local' }
    ) {
        param($Mode, $FileName, $Location)

        $moduleDirectory = Join-Path $TestDrive "$Mode-$Location"
        $testDirectory = Join-Path $moduleDirectory 'test'
        New-Item -Path $testDirectory -ItemType Directory -Force | Out-Null
        $loader = Join-Path $testDirectory 'loadEnv.ps1'
        Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'loadEnv.ps1') -Destination $loader
        @{ SubscriptionId = 'parent-subscription'; Tenant = 'parent-tenant' } |
            ConvertTo-Json | Set-Content -Path (Join-Path $moduleDirectory $FileName)
        if ($Location -eq 'local') {
            @{ SubscriptionId = 'local-subscription'; Tenant = 'local-tenant' } |
                ConvertTo-Json | Set-Content -Path (Join-Path $testDirectory $FileName)
        }

        $result = & {
            param($Loader, $Mode)
            Set-Variable -Name TestMode -Value $Mode
            . $Loader
            [pscustomobject]@{
                Settings = $env
                TenantDefault = $PSDefaultParameterValues['*:Tenant']
            }
        } $loader $Mode

        $result.Settings.SubscriptionId | Should -Be "$Location-subscription"
        $result.Settings.Tenant | Should -Be "$Location-tenant"
        $result.TenantDefault | Should -Be "$Location-tenant"
    }
}
