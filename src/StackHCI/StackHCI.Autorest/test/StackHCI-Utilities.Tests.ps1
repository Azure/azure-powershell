Describe 'StackHCI Utility Functions' {

    BeforeAll {
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (Test-Path $privateDll) {
            Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        }
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath

        # Suppress log output during tests
        function Write-WarnLog { param([string]$Message) }
        function Write-VerboseLog { param([string]$Message) }
    }

    # ── Normalize-RegionName ──────────────────────────────────────────────
    Context 'Normalize-RegionName' {
        It 'Should lowercase the region name' {
            Normalize-RegionName -Region 'EastUS' | Should -Be 'eastus'
        }
        It 'Should remove spaces' {
            Normalize-RegionName -Region 'East US' | Should -Be 'eastus'
        }
        It 'Should handle already normalized names' {
            Normalize-RegionName -Region 'westus2' | Should -Be 'westus2'
        }
        It 'Should handle empty string' {
            Normalize-RegionName -Region '' | Should -Be ''
        }
        It 'Should handle multiple spaces' {
            Normalize-RegionName -Region 'East  US  2' | Should -Be 'eastus2'
        }
    }

    # ── Get-ResourceId ────────────────────────────────────────────────────
    Context 'Get-ResourceId' {
        It 'Should return correctly formatted resource ID' {
            $result = Get-ResourceId -ResourceName 'myCluster' -SubscriptionId 'sub-123' -ResourceGroupName 'rg-test'
            $result | Should -Be '/Subscriptions/sub-123/resourceGroups/rg-test/providers/Microsoft.AzureStackHCI/clusters/myCluster'
        }
        It 'Should handle special characters in resource name' {
            $result = Get-ResourceId -ResourceName 'my-cluster-01' -SubscriptionId 'sub-456' -ResourceGroupName 'rg-prod'
            $result | Should -BeLike '*/my-cluster-01'
        }
    }

    # ── Get-DefaultRegion ─────────────────────────────────────────────────
    Context 'Get-DefaultRegion' {
        It 'Should return eastus for AzureCloud' {
            Get-DefaultRegion -EnvironmentName 'AzureCloud' | Should -Be 'eastus'
        }
        It 'Should return chinaeast2 for AzureChinaCloud' {
            Get-DefaultRegion -EnvironmentName 'AzureChinaCloud' | Should -Be 'chinaeast2'
        }
        It 'Should return usgovvirginia for AzureUSGovernment' {
            Get-DefaultRegion -EnvironmentName 'AzureUSGovernment' | Should -Be 'usgovvirginia'
        }
        It 'Should return germanynortheast for AzureGermanCloud' {
            Get-DefaultRegion -EnvironmentName 'AzureGermanCloud' | Should -Be 'germanynortheast'
        }
        It 'Should return westus for AzurePPE' {
            Get-DefaultRegion -EnvironmentName 'AzurePPE' | Should -Be 'westus'
        }
        It 'Should return eastus2euap for AzureCanary' {
            Get-DefaultRegion -EnvironmentName 'AzureCanary' | Should -Be 'eastus2euap'
        }
        It 'Should return autonomous for Azure.local' {
            Get-DefaultRegion -EnvironmentName 'Azure.local' | Should -Be 'autonomous'
        }
        It 'Should return eastus for unknown environments' {
            Get-DefaultRegion -EnvironmentName 'SomeOtherEnv' | Should -Be 'eastus'
        }
    }

    # ── Get-PortalDomain ──────────────────────────────────────────────────
    Context 'Get-PortalDomain' {
        It 'Should return MS portal for AzureCloud with Microsoft tenant' {
            $result = Get-PortalDomain -TenantId '72f988bf-86f1-41af-91ab-2d7cd011db47' -EnvironmentName 'AzureCloud'
            $result | Should -Be 'https://ms.portal.azure.com/'
        }
        It 'Should return public portal for AzureCloud with non-Microsoft tenant' {
            $result = Get-PortalDomain -TenantId 'some-other-tenant' -EnvironmentName 'AzureCloud'
            $result | Should -Be 'https://portal.azure.com/'
        }
        It 'Should return China portal for AzureChinaCloud' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzureChinaCloud'
            $result | Should -Be 'https://portal.azure.cn/'
        }
        It 'Should return US Gov portal for AzureUSGovernment' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzureUSGovernment'
            $result | Should -Be 'https://portal.azure.us/'
        }
        It 'Should return German portal for AzureGermanCloud' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzureGermanCloud'
            $result | Should -Be 'https://portal.microsoftazure.de/'
        }
        It 'Should return PPE portal for AzurePPE' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzurePPE'
            $result | Should -Be 'https://df.onecloud.azure-test.net/'
        }
        It 'Should return Canary portal with region suffix for AzureCanary' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzureCanary' -Region 'eastus2euap'
            $result | Should -BeLike 'https://portal.azure.com/*eastus2euap*'
        }
        It 'Should throw for unknown environment with no AzEnvironment' {
            Mock Get-AzEnvironment { return $null }
            { Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'NonExistent' } | Should -Throw
        }
    }

    # ── Get-PortalHCIResourcePageUrl ──────────────────────────────────────
    Context 'Get-PortalHCIResourcePageUrl' {
        It 'Should compose the full portal URL' {
            $result = Get-PortalHCIResourcePageUrl -TenantId 'tenant-1' -EnvironmentName 'AzureCloud' -SubscriptionId 'sub-1' -ResourceGroupName 'rg-1' -ResourceName 'cluster-1'
            $result | Should -BeLike 'https://portal.azure.com/*tenant-1*sub-1*rg-1*cluster-1*'
        }
    }

    # ── Set-WacOutputProperty ─────────────────────────────────────────────
    Context 'Set-WacOutputProperty' {
        It 'Should add property when IsWAC is true' {
            $output = [PSCustomObject]@{}
            Set-WacOutputProperty -IsWAC $true -PropertyName 'TestProp' -PropertyValue 'TestVal' -Output $output
            $output.TestProp | Should -Be 'TestVal'
        }
        It 'Should not add property when IsWAC is false' {
            $output = [PSCustomObject]@{}
            Set-WacOutputProperty -IsWAC $false -PropertyName 'TestProp' -PropertyValue 'TestVal' -Output $output
            $output.PSObject.Properties.Name | Should -Not -Contain 'TestProp'
        }
        It 'Should overwrite existing property with Force' {
            $output = [PSCustomObject]@{ TestProp = 'OldVal' }
            Set-WacOutputProperty -IsWAC $true -PropertyName 'TestProp' -PropertyValue 'NewVal' -Output $output
            $output.TestProp | Should -Be 'NewVal'
        }
    }

    # ── Print-FunctionParameters ──────────────────────────────────────────
    Context 'Print-FunctionParameters' {
        It 'Should include normal parameters in output' {
            $params = @{ ResourceGroupName = 'rg-test'; Location = 'eastus' }
            $result = Print-FunctionParameters -Message 'TestCmd' -Parameters $params
            $result | Should -BeLike '*TestCmd*'
            $result | Should -BeLike '*ResourceGroupName*'
            $result | Should -BeLike '*rg-test*'
        }
        It 'Should mask sensitive parameters' {
            $params = @{ ArmAccessToken = 'secret-token-123'; ResourceGroupName = 'rg-test' }
            $result = Print-FunctionParameters -Message 'TestCmd' -Parameters $params
            $result | Should -Not -BeLike '*secret-token-123*'
            $result | Should -BeLike '*XXXXXXX*'
        }
        It 'Should mask Credential parameter' {
            $params = @{ Credential = 'my-cred'; Location = 'westus' }
            $result = Print-FunctionParameters -Message 'TestCmd' -Parameters $params
            $result | Should -BeLike '*XXXXXXX*'
            $result | Should -Not -BeLike '*my-cred*'
        }
        It 'Should mask GraphAccessToken parameter' {
            $params = @{ GraphAccessToken = 'graph-secret' }
            $result = Print-FunctionParameters -Message 'TestCmd' -Parameters $params
            $result | Should -Not -BeLike '*graph-secret*'
        }
        It 'Should mask AccessToken parameter' {
            $params = @{ AccessToken = 'access-secret' }
            $result = Print-FunctionParameters -Message 'TestCmd' -Parameters $params
            $result | Should -Not -BeLike '*access-secret*'
        }
        It 'Should mask AccountId parameter' {
            $params = @{ AccountId = 'account-secret' }
            $result = Print-FunctionParameters -Message 'TestCmd' -Parameters $params
            $result | Should -Not -BeLike '*account-secret*'
        }
        It 'Should mask ArcSpnCredential parameter' {
            $params = @{ ArcSpnCredential = 'spn-secret' }
            $result = Print-FunctionParameters -Message 'TestCmd' -Parameters $params
            $result | Should -Not -BeLike '*spn-secret*'
        }
        It 'Should skip common parameters like Debug and Verbose' {
            $params = @{ Debug = $true; Verbose = $true; ResourceGroupName = 'rg-test' }
            $result = Print-FunctionParameters -Message 'TestCmd' -Parameters $params
            $result | Should -BeLike '*ResourceGroupName*'
        }
        It 'Should handle empty parameters' {
            $params = @{}
            $result = Print-FunctionParameters -Message 'TestCmd' -Parameters $params
            $result | Should -BeLike '*TestCmd*'
        }
    }

    # ── Test-ComputerNameHasDnsSuffix ─────────────────────────────────────
    Context 'Test-ComputerNameHasDnsSuffix' {
        It 'Should return true for FQDN with dot' {
            $result = Test-ComputerNameHasDnsSuffix -ComputerName 'node1.contoso.local'
            @($result)[-1] | Should -Be $true
        }
        It 'Should return false for short hostname' {
            $result = Test-ComputerNameHasDnsSuffix -ComputerName 'node1'
            @($result)[-1] | Should -Be $false
        }
        It 'Should throw for empty string since ComputerName is mandatory' {
            { Test-ComputerNameHasDnsSuffix -ComputerName '' } | Should -Throw
        }
        It 'Should return false for whitespace-only string' {
            $result = Test-ComputerNameHasDnsSuffix -ComputerName '   '
            $result | Should -Be $false
        }
        It 'Should return true for multi-level domain' {
            $result = Test-ComputerNameHasDnsSuffix -ComputerName 'node1.sub.contoso.local'
            @($result)[-1] | Should -Be $true
        }
    }

    # ── New-Directory ─────────────────────────────────────────────────────
    Context 'New-Directory' {
        It 'Should create directory if it does not exist' {
            $testDir = Join-Path $TestDrive 'newdir'
            New-Directory -Path $testDir
            Test-Path -Path $testDir -PathType Container | Should -Be $true
        }
        It 'Should not throw if directory already exists' {
            $testDir = Join-Path $TestDrive 'existingdir'
            New-Item -ItemType Directory -Path $testDir -Force | Out-Null
            { New-Directory -Path $testDir } | Should -Not -Throw
        }
    }

    Describe 'Execute-Without-ProgressBar' {

        BeforeEach {
            # Suppress Write-ErrorLog output that interferes with Pester's Should -Throw
            Mock Write-ErrorLog { }
        }

        It 'Executes script block and returns result' {
            $result = Execute-Without-ProgressBar -ScriptBlock { 42 }
            $result | Should -Be 42
        }

        It 'Restores ProgressPreference after execution' {
            $originalPref = $ProgressPreference
            Execute-Without-ProgressBar -ScriptBlock { 'test' } | Out-Null
            $ProgressPreference | Should -Be $originalPref
        }

        It 'Restores ProgressPreference even on error' {
            $originalPref = $ProgressPreference
            try {
                Execute-Without-ProgressBar -ScriptBlock { throw 'test error' }
            } catch {}
            $ProgressPreference | Should -Be $originalPref
        }

        It 'Rethrows exceptions from script block' {
            { Execute-Without-ProgressBar -ScriptBlock { throw 'expected failure' } } | Should -Throw
        }
    }

    Describe 'Retry-Command' {

        It 'Returns result on first success' {
            $result = Retry-Command -ScriptBlock { 'success' } -Attempts 3 -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1
            $result | Should -Be 'success'
        }

        It 'Retries on null output when RetryIfNullOutput is true' {
            $script:callCount = 0
            $result = Retry-Command -ScriptBlock {
                $script:callCount++
                if ($script:callCount -lt 3) { return $null }
                return 'got it'
            } -Attempts 5 -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1 -RetryIfNullOutput $true
            $result | Should -Be 'got it'
            $script:callCount | Should -Be 3
        }

        It 'Succeeds on null output when RetryIfNullOutput is false' {
            $result = Retry-Command -ScriptBlock { return $null } -Attempts 3 -RetryIfNullOutput $false -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1
            $result | Should -Be $null
        }

        It 'Throws when MaxWaitTime is less than MinWaitTime' {
            { Retry-Command -ScriptBlock { 'test' } -MinWaitTimeInSeconds 10 -MaxWaitTimeInSeconds 5 } | Should -Throw
        }

        It 'Throws after exhausting all attempts' {
            { Retry-Command -ScriptBlock { throw 'always fails' } -Attempts 2 -MinWaitTimeInSeconds 0 -MaxWaitTimeInSeconds 1 } | Should -Throw
        }
    }

    Describe 'Test-FolderAccess' {

        It 'Returns true for accessible directory' {
            $tempDir = Join-Path ([System.IO.Path]::GetTempPath()) ("TestFolderAccess_" + [guid]::NewGuid().ToString('N'))
            New-Item -ItemType Directory -Path $tempDir -Force | Out-Null
            try {
                Test-FolderAccess -folderPath $tempDir | Should -Be $true
            } finally {
                Remove-Item $tempDir -Recurse -Force -ErrorAction SilentlyContinue
            }
        }

        It 'Returns true for non-existent directory it can create' {
            $tempDir = Join-Path ([System.IO.Path]::GetTempPath()) ("TestFolderAccess_" + [guid]::NewGuid().ToString('N'))
            try {
                Test-FolderAccess -folderPath $tempDir | Should -Be $true
                Test-Path $tempDir | Should -Be $true
            } finally {
                Remove-Item $tempDir -Recurse -Force -ErrorAction SilentlyContinue
            }
        }
    }

    Describe 'New-ClusterWithRetries' {

        It 'Returns true on successful response (2xx)' {
            Mock Invoke-AzRestMethod {
                return [PSCustomObject]@{ StatusCode = 200; ErrorCode = $null; Content = '' }
            }
            $result = New-ClusterWithRetries -ResourceIdWithAPI '/test?api-version=2023-01-01' -Payload '{}'
            $result | Should -Be $true
        }

        It 'Returns true on 201 Created' {
            Mock Invoke-AzRestMethod {
                return [PSCustomObject]@{ StatusCode = 201; ErrorCode = $null; Content = '' }
            }
            $result = New-ClusterWithRetries -ResourceIdWithAPI '/test?api-version=2023-01-01' -Payload '{}'
            $result | Should -Be $true
        }

        It 'Returns false after max retries on failure' {
            Mock Invoke-AzRestMethod {
                return [PSCustomObject]@{ StatusCode = 500; ErrorCode = 'InternalError'; Content = 'Server Error' }
            }
            Mock Start-Sleep {} # Skip sleep during tests
            $result = New-ClusterWithRetries -ResourceIdWithAPI '/test?api-version=2023-01-01' -Payload '{}'
            $result | Should -Be $false
        }
    }
}