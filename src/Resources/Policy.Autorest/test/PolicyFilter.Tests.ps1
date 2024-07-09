# setup the Pester environment for policy cmdlet tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'PolicyFilter'

Describe 'PolicyFilter' -Tag 'LiveOnly' {

    It 'Get and validate PolicyType of Get-AzPolicyDefinition -BuiltIn' {
        # builtin policy definitions
        $builtins = Get-AzPolicyDefinition -Builtin
        $builtins | %{ $_.PolicyType | Should -Be 'BuiltIn' }
    }

    It 'Get and validate PolicyType of Get-AzPolicyDefinition -Custom' {
        # custom policy definitions
        $custom = Get-AzPolicyDefinition -Custom
        $custom | %{ $_.PolicyType | Should -Be 'Custom' }
    }

    It 'Get and validate PolicyType of Get-AzPolicyDefinition -Static' {
        # static policy definitions
        $static = Get-AzPolicyDefinition -Static
        $static| %{ $_.PolicyType | Should -Be 'Static' }
    }

    It 'Get and validate PolicyType of Get-AzPolicySetDefinition -BuiltIn' {
        # builtin policy set definitions
        $builtins = Get-AzPolicySetDefinition -Builtin
        $builtins | %{ $_.PolicyType | Should -Be 'BuiltIn' }
    }

    It 'Get and validate PolicyType of Get-AzPolicySetDefinition -Custom' {
        # custom policy set definitions
        $custom = Get-AzPolicySetDefinition -Custom
        $custom = Get-AzPolicyDefinition -Custom
        $custom | %{ $_.PolicyType | Should -Be 'Custom' }
    }

    It 'Get and validate 100 builtin definitions' {
        # policy definitions
        $builtins = Get-AzPolicyDefinition -Builtin | Select-Object -First 100
        foreach ($builtin in $builtins) {
            $done = $false
            do {
                try {
                    $definition = Get-AzPolicyDefinition -Name $builtin.Name
                    $done = $true
                    $builtin.ResourceId
                    | Should -Be $definition.ResourceId
                }
                catch {
                    if ($_.Exception.Message -like '`[ResourceRequestsThrottled`] : *') {
                        Write-Host -NoNewline -ForegroundColor DarkYellow 'Waiting 5 seconds to allow throttling limit to reset...'
                        Start-Sleep -Seconds 5
                        Write-Host -ForegroundColor DarkYellow 'resuming.'
                    }
                    else {
                        throw $_
                    }
                }
            } while (!$done)
        }
    }

    It 'Get and validate 100 builtin set definitions' {
        # policy set definitions
        $builtins = Get-AzPolicySetDefinition -Builtin | Select-Object -First 100
        foreach ($builtin in $builtins) {
            $done = $false
            do {
                try {
                    $definition = Get-AzPolicySetDefinition -Name $builtin.Name
                    $done = $true
                    $builtin.ResourceId
                    | Should -Be $definition.ResourceId
                }
                catch {
                    if ($_.Exception.Message -like '`[ResourceRequestsThrottled`] : *') {
                        Write-Host -NoNewline -ForegroundColor DarkYellow 'Waiting 5 seconds to allow throttling limit to reset...'
                        Start-Sleep -Seconds 5
                        Write-Host -ForegroundColor DarkYellow 'resuming.'
                    }
                    else {
                        throw $_
                    }
                }
            } while (!$done)
        }
    }
}
