Describe 'StackHCI Environment Functions' {

    BeforeAll {
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (Test-Path $privateDll) {
            Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        }
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath

        function Write-WarnLog { param([string]$Message) }
        function Write-VerboseLog { param([string]$Message) }
    }

    # ── Get-EnvironmentEndpoints ──────────────────────────────────────────
    Context 'Get-EnvironmentEndpoints' {
        It 'Should set AzureCloud endpoints' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureCloud' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)

            $se | Should -Be 'https://dp.stackhci.azure.com'
            $auth | Should -Be 'https://login.microsoftonline.com'
            $billing | Should -BeLike '*azurestackhci*'
            $graph | Should -BeLike '*graph.microsoft.com*'
        }

        It 'Should set AzureCanary endpoints same as AzureCloud' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureCanary' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)

            $se | Should -Be 'https://dp.stackhci.azure.com'
            $auth | Should -Be 'https://login.microsoftonline.com'
        }

        It 'Should set AzureChinaCloud endpoints' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureChinaCloud' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)

            $se | Should -Be 'https://dp.stackhci.azure.cn'
            $auth | Should -Be 'https://login.partner.microsoftonline.cn'
        }

        It 'Should set AzureUSGovernment endpoints' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureUSGovernment' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)

            $se | Should -Be 'https://dp.azurestackhci.azure.us'
            $auth | Should -Be 'https://login.microsoftonline.us'
        }

        It 'Should set AzureGermanCloud endpoints' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureGermanCloud' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)

            $se | Should -BeLike '*azurestackhci*trafficmanager.de*'
            $auth | Should -Be 'https://login.microsoftonline.de'
        }

        It 'Should set AzurePPE endpoints' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzurePPE' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)

            $se | Should -BeLike '*azurestackhci*azurefd.net*'
            $auth | Should -Be 'https://login.windows-ppe.net'
        }

        It 'Should set Azure.local endpoints' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'Azure.local' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)

            $se | Should -BeLike '*dp.aszrp*'
            $auth | Should -BeLike '*login*'
        }

        It 'Should use custom environment from Get-AzEnvironment' {
            Mock Get-AzEnvironment {
                return [PSCustomObject]@{
                    ActiveDirectoryAuthority = 'https://custom.login.example.com'
                    GraphEndpointResourceId  = 'https://custom.graph.example.com'
                }
            }

            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'CustomEnv' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)

            $se | Should -Be 'https://doesnotmatter/'
            $auth | Should -Be 'https://custom.login.example.com'
            $graph | Should -BeLike '*custom.graph.example.com*'
        }

        It 'Should throw for invalid environment with no AzEnvironment' {
            Mock Get-AzEnvironment { return $null }
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            { Get-EnvironmentEndpoints -EnvironmentName 'Invalid' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph) } | Should -Throw
        }
    }

    # ── Get-ManagementUrl ─────────────────────────────────────────────────
    Context 'Get-ManagementUrl' {
        It 'Should return correct URL for AzurePublicCloud' {
            Get-ManagementUrl -EnvironmentName 'AzurePublicCloud' | Should -Be 'https://management.azure.com'
        }

        It 'Should return correct URL for AzureGermanCloud' {
            Get-ManagementUrl -EnvironmentName 'AzureGermanCloud' | Should -Be 'https://management.microsoftazure.de'
        }

        It 'Should return correct URL for AzureChinaCloud' {
            Get-ManagementUrl -EnvironmentName 'AzureChinaCloud' | Should -Be 'https://management.chinacloudapi.cn'
        }

        It 'Should return correct URL for AzureUSGovernmentCloud' {
            Get-ManagementUrl -EnvironmentName 'AzureUSGovernmentCloud' | Should -Be 'https://management.usgovcloudapi.net'
        }

        It 'Should use Get-AzEnvironment for custom environments' {
            Mock Get-AzEnvironment {
                return [PSCustomObject]@{ ResourceManagerUrl = 'https://custom.management.example.com' }
            }
            Get-ManagementUrl -EnvironmentName 'CustomEnv' | Should -Be 'https://custom.management.example.com'
        }

        It 'Should throw for invalid environment name' {
            Mock Get-AzEnvironment { return $null }
            { Get-ManagementUrl -EnvironmentName 'NonExistent' } | Should -Throw
        }
    }

    # ── ValidateCloudDeployment ───────────────────────────────────────────
    Context 'ValidateCloudDeployment' {
        It 'Should return true when DEPLOYMENTTYPE env var is cloud_deployment' {
            $originalVal = $env:DEPLOYMENTTYPE
            try {
                $env:DEPLOYMENTTYPE = 'cloud_deployment'
                ValidateCloudDeployment | Should -Be $true
            } finally {
                $env:DEPLOYMENTTYPE = $originalVal
            }
        }

        It 'Should return false when DEPLOYMENTTYPE is not set and registry key does not exist' {
            $originalVal = $env:DEPLOYMENTTYPE
            try {
                $env:DEPLOYMENTTYPE = $null
                Mock Get-ItemProperty { throw 'Registry key not found' }
                ValidateCloudDeployment | Should -Be $false
            } finally {
                $env:DEPLOYMENTTYPE = $originalVal
            }
        }

        It 'Should return false when DEPLOYMENTTYPE is some other value' {
            $originalVal = $env:DEPLOYMENTTYPE
            try {
                $env:DEPLOYMENTTYPE = 'on_premise'
                Mock Get-ItemProperty { throw 'Registry key not found' }
                ValidateCloudDeployment | Should -Be $false
            } finally {
                $env:DEPLOYMENTTYPE = $originalVal
            }
        }
    }

    # ── Tests migrated from stackhci.Tests.ps1 ───────────────────────────

    Describe 'Get-DefaultRegion' {

        It 'Returns eastus for AzureCloud' {
            Get-DefaultRegion -EnvironmentName 'AzureCloud' | Should -Be 'eastus'
        }

        It 'Returns chinaeast2 for AzureChinaCloud' {
            Get-DefaultRegion -EnvironmentName 'AzureChinaCloud' | Should -Be 'chinaeast2'
        }

        It 'Returns usgovvirginia for AzureUSGovernment' {
            Get-DefaultRegion -EnvironmentName 'AzureUSGovernment' | Should -Be 'usgovvirginia'
        }

        It 'Returns germanynortheast for AzureGermanCloud' {
            Get-DefaultRegion -EnvironmentName 'AzureGermanCloud' | Should -Be 'germanynortheast'
        }

        It 'Returns westus for AzurePPE' {
            Get-DefaultRegion -EnvironmentName 'AzurePPE' | Should -Be 'westus'
        }

        It 'Returns eastus2euap for AzureCanary' {
            Get-DefaultRegion -EnvironmentName 'AzureCanary' | Should -Be 'eastus2euap'
        }

        It 'Returns autonomous for Azure.local' {
            Get-DefaultRegion -EnvironmentName 'Azure.local' | Should -Be 'autonomous'
        }

        It 'Returns eastus as fallback for unknown environment' {
            Get-DefaultRegion -EnvironmentName 'SomethingUnknown' | Should -Be 'eastus'
        }
    }

    Describe 'Get-PortalDomain' {

        It 'Returns MS portal for AzureCloud with Microsoft TenantId' {
            $result = Get-PortalDomain -TenantId '72f988bf-86f1-41af-91ab-2d7cd011db47' -EnvironmentName 'AzureCloud' -Region 'eastus'
            $result | Should -Be 'https://ms.portal.azure.com/'
        }

        It 'Returns public portal for AzureCloud with non-Microsoft TenantId' {
            $result = Get-PortalDomain -TenantId 'some-other-tenant' -EnvironmentName 'AzureCloud' -Region 'eastus'
            $result | Should -Be 'https://portal.azure.com/'
        }

        It 'Returns China portal for AzureChinaCloud' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzureChinaCloud' -Region 'chinaeast2'
            $result | Should -Be 'https://portal.azure.cn/'
        }

        It 'Returns US Government portal for AzureUSGovernment' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzureUSGovernment' -Region 'usgovvirginia'
            $result | Should -Be 'https://portal.azure.us/'
        }

        It 'Returns German portal for AzureGermanCloud' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzureGermanCloud' -Region 'germanynortheast'
            $result | Should -Be 'https://portal.microsoftazure.de/'
        }

        It 'Returns PPE portal for AzurePPE' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzurePPE' -Region 'westus'
            $result | Should -Be 'https://df.onecloud.azure-test.net/'
        }

        It 'Returns Canary portal with region suffix for AzureCanary' {
            $result = Get-PortalDomain -TenantId 'any-tenant' -EnvironmentName 'AzureCanary' -Region 'eastus2euap'
            $result | Should -BeLike 'https://portal.azure.com/*eastus2euap*'
        }

        It 'Throws for unknown environment without Az context' {
            Mock Get-AzEnvironment { return $null }
            { Get-PortalDomain -TenantId 'any' -EnvironmentName 'NonExistent' -Region 'eastus' } | Should -Throw
        }
    }

    Describe 'Get-ManagementUrl' {

        It 'Returns correct URL for AzurePublicCloud' {
            Get-ManagementUrl -EnvironmentName 'AzurePublicCloud' | Should -Be 'https://management.azure.com'
        }

        It 'Returns correct URL for AzureGermanCloud' {
            Get-ManagementUrl -EnvironmentName 'AzureGermanCloud' | Should -Be 'https://management.microsoftazure.de'
        }

        It 'Returns correct URL for AzureChinaCloud' {
            Get-ManagementUrl -EnvironmentName 'AzureChinaCloud' | Should -Be 'https://management.chinacloudapi.cn'
        }

        It 'Returns correct URL for AzureUSGovernmentCloud' {
            Get-ManagementUrl -EnvironmentName 'AzureUSGovernmentCloud' | Should -Be 'https://management.usgovcloudapi.net'
        }

        It 'Throws for invalid environment name' {
            Mock Get-AzEnvironment { return $null }
            { Get-ManagementUrl -EnvironmentName 'InvalidEnv' } | Should -Throw
        }
    }

    Describe 'Get-EnvironmentEndpoints' {

        It 'Sets AzureCloud endpoints correctly' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureCloud' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)
            $se | Should -Be 'https://dp.stackhci.azure.com'
            $auth | Should -Be 'https://login.microsoftonline.com'
            $billing | Should -Be 'https://azurestackhci-usage.trafficmanager.net/.default'
            $graph | Should -Be 'https://graph.microsoft.com/.default'
        }

        It 'Sets AzureCanary to AzureCloud endpoints' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureCanary' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)
            $se | Should -Be 'https://dp.stackhci.azure.com'
            $auth | Should -Be 'https://login.microsoftonline.com'
        }

        It 'Sets AzureChinaCloud endpoints correctly' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureChinaCloud' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)
            $se | Should -Be 'https://dp.stackhci.azure.cn'
            $auth | Should -Be 'https://login.partner.microsoftonline.cn'
        }

        It 'Sets AzureUSGovernment endpoints correctly' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureUSGovernment' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)
            $se | Should -Be 'https://dp.azurestackhci.azure.us'
            $auth | Should -Be 'https://login.microsoftonline.us'
        }

        It 'Sets AzureGermanCloud endpoints correctly' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzureGermanCloud' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)
            $se | Should -Be 'https://azurestackhci-usage.trafficmanager.de'
            $auth | Should -Be 'https://login.microsoftonline.de'
        }

        It 'Sets AzurePPE endpoints correctly' {
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'AzurePPE' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)
            $se | Should -Be 'https://azurestackhci-df.azurefd.net'
            $auth | Should -Be 'https://login.windows-ppe.net'
        }

        It 'Throws for unknown environment without Az context' {
            Mock Get-AzEnvironment { return $null }
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            { Get-EnvironmentEndpoints -EnvironmentName 'NonExistent' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph) } | Should -Throw
        }

        It 'Uses Az environment data for custom environment' {
            Mock Get-AzEnvironment {
                return [PSCustomObject]@{
                    ActiveDirectoryAuthority = 'https://custom-auth.example.com'
                    GraphEndpointResourceId = 'https://custom-graph.example.com'
                }
            }
            $se = ''; $auth = ''; $billing = ''; $graph = ''
            Get-EnvironmentEndpoints -EnvironmentName 'CustomEnv' -ServiceEndpoint ([ref]$se) -Authority ([ref]$auth) -BillingServiceApiScope ([ref]$billing) -GraphServiceApiScope ([ref]$graph)
            $se | Should -Be 'https://doesnotmatter/'
            $auth | Should -Be 'https://custom-auth.example.com'
            $graph | Should -Be 'https://custom-graph.example.com/.default'
        }
    }

    Describe 'Get-PortalHCIResourcePageUrl' {

        It 'Returns full portal URL with correct segments' {
            $result = Get-PortalHCIResourcePageUrl -TenantId 'tenant-1' -EnvironmentName 'AzureCloud' -SubscriptionId 'sub-1' -ResourceGroupName 'rg-1' -ResourceName 'cluster-1' -Region 'eastus'
            $result | Should -BeLike 'https://portal.azure.com/*tenant-1*sub-1*rg-1*cluster-1*'
        }

        It 'Uses MS portal for Microsoft TenantId' {
            $result = Get-PortalHCIResourcePageUrl -TenantId '72f988bf-86f1-41af-91ab-2d7cd011db47' -EnvironmentName 'AzureCloud' -SubscriptionId 'sub-1' -ResourceGroupName 'rg-1' -ResourceName 'cluster-1' -Region 'eastus'
            $result | Should -BeLike 'https://ms.portal.azure.com/*'
        }
    }
}
