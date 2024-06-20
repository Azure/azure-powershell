# setup the Pester environment for policy backcompat tests
. (Join-Path $PSScriptRoot 'Common.ps1') 'Backcompat-GetBuiltinsByName'

Describe 'Backcompat-GetBuiltinsByName' -Tag 'LiveOnly' {

    It 'get some builtin definitions by name' {
        {
            # policy definitions
            $builtins = Get-AzPolicyDefinition -Builtin -BackwardCompatible | Select-Object -First 100
            foreach ($builtin in $builtins)
            {
                $done = $false
                do {
                    try {
                        $definition = Get-AzPolicyDefinition -Name $builtin.Name -BackwardCompatible
                        $done = $true
                        Assert-AreEqual $builtin.ResourceId $definition.ResourceId
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
        } | Should -Not -Throw
    }

    It 'get some builtin set definitions by name' {
        {
            # policy set definitions
            $builtins = Get-AzPolicySetDefinition -Builtin -BackwardCompatible | Select-Object -First 100
            foreach ($builtin in $builtins)
            {
                $done = $false
                do {
                    try {
                        $definition = Get-AzPolicySetDefinition -Name $builtin.Name -BackwardCompatible
                        $done = $true
                        Assert-AreEqual $builtin.ResourceId $definition.ResourceId
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
        } | Should -Not -Throw
    }
}
