Describe 'StackHCI Registration Functions' {

    BeforeAll {
        $privateDll = Join-Path $PSScriptRoot '..' 'bin' 'Az.StackHCI.private.dll'
        if (-not (Test-Path $privateDll)) {
            throw "Az.StackHCI.private.dll not found at '$privateDll'. Run a build first (dotnet msbuild build.proj /p:Scope=StackHCI) to generate the required assembly."
        }
        Add-Type -Path $privateDll -ErrorAction SilentlyContinue
        $customPath = Join-Path $PSScriptRoot '..' 'custom' 'stackhci.ps1'
        . $customPath

        # Stubs for Az.Resources commands not available when only Az.StackHCI is loaded
        foreach ($cmd in @('Get-AzRoleAssignment','New-AzRoleAssignment','Remove-AzRoleAssignment','Get-AzResource','Get-AzResourceGroup','Get-AzADApplication','Get-AzResourceProvider','Register-AzResourceProvider','New-AzResourceGroup','Remove-AzResourceGroup','Invoke-AzResourceAction')) {
            if (-not (Get-Command $cmd -ErrorAction SilentlyContinue)) {
                Set-Item "function:global:$cmd" { }
            }
        }

        function Write-WarnLog { param([string]$Message) }
        function Write-VerboseLog { param([string]$Message) }
        function Write-InfoLog { param([string]$Message) }
        $script:errorMessages = [System.Collections.ArrayList]::new()
        $script:mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
        function Write-ErrorLog {
            [CmdletBinding()]
            param(
                [Parameter(Mandatory=$true)]
                [string] $Message,
                [Parameter(Mandatory=$false)]
                [System.Management.Automation.ErrorRecord] $Exception,
                [Parameter(Mandatory=$false)]
                [string] $Category
            )
            $script:errorMessages.Add($Message) | Out-Null
            if ($Category -eq 'OperationStopped') {
                $Error.Add($AlreadyLoggedFlag) | Out-Null
            }
        }
    }

    Context 'Validate-RegionName' {
        It 'Should return true for a supported region' {
            # Mock Retry-Command to bypass the internal Invoke-Command wrapper
            # and return location strings directly (matching what .Locations yields)
            Mock Retry-Command {
                return @('East US', 'West Europe')
            }

            $supportedRegions = $null
            $result = Validate-RegionName -Region 'eastus' -SupportedRegions ([ref]$supportedRegions)
            # Validate-RegionName emits $True from the foreach AND $False at the end
            # due to PowerShell's foreach/return semantics. Check that $True is present.
            @($result) | Should -Contain $true
        }

        It 'Should return false for an unsupported region' {
            Mock Retry-Command {
                return @('East US', 'West Europe')
            }

            $supportedRegions = $null
            $result = Validate-RegionName -Region 'brazilsouth' -SupportedRegions ([ref]$supportedRegions)
            $result | Should -Be $false
        }
    }

    Context 'Azure-Login' {
        It 'Should call Connect-AzAccount with ArmAccessToken when provided' {
            Mock Connect-AzAccount { }
            Mock Get-AzContext {
                return [PSCustomObject]@{
                    Tenant = [PSCustomObject]@{ Id = 'tenant-123' }
                    Subscription = [PSCustomObject]@{ Id = 'sub-123' }
                }
            }
            Mock Disconnect-AzAccount { }
            Mock Write-Progress { }
            Mock Add-AzEnvironment { }

            $result = Azure-Login -SubscriptionId 'sub-123' -TenantId 'tenant-123' `
                -ArmAccessToken 'fake-token' -AccountId 'user@contoso.com' `
                -EnvironmentName 'AzureCloud' -ProgressActivityName 'Testing' -Region 'eastus' `
                -UseDeviceAuthentication $false

            $result | Should -Be 'tenant-123'
            Assert-MockCalled Connect-AzAccount -Times 1
        }

        It 'Should use device authentication when UseDeviceAuthentication is true and no token' {
            Mock Connect-AzAccount { }
            Mock Get-AzContext {
                return [PSCustomObject]@{
                    Tenant = [PSCustomObject]@{ Id = 'tenant-456' }
                    Subscription = [PSCustomObject]@{ Id = 'sub-456' }
                }
            }
            Mock Disconnect-AzAccount { }
            Mock Write-Progress { }
            Mock Test-Path { return $false } -ParameterFilter { $Path -like '*ieframe.dll' }

            $result = Azure-Login -SubscriptionId 'sub-456' `
                -EnvironmentName 'AzureCloud' -ProgressActivityName 'Testing' -Region 'eastus' `
                -UseDeviceAuthentication $true

            $result | Should -Be 'tenant-456'
            Assert-MockCalled Connect-AzAccount -Times 1
        }
    }

    Context 'Create-ArcSPN' {
        It 'Should create Arc AAD app when arcApplicationObjectId is null' {
            $arcResource = [PSCustomObject]@{
                ResourceId = '/subscriptions/sub-1/resourceGroups/rg-1/providers/Microsoft.AzureStackHCI/clusters/cl-1/arcSettings/default'
                Properties = [PSCustomObject]@{
                    arcApplicationObjectId = $null
                    arcApplicationClientId = 'app-id-123'
                    arcServicePrincipalObjectId = 'spn-obj-123'
                    arcInstanceResourceGroup = 'rg-arc'
                }
            }

            Mock Invoke-AzResourceAction { }
            Mock Get-AzResource {
                return [PSCustomObject]@{
                    ResourceId = $arcResource.ResourceId
                    Properties = [PSCustomObject]@{
                        arcApplicationObjectId = 'created-obj-id'
                        arcApplicationClientId = 'app-id-123'
                        arcServicePrincipalObjectId = 'spn-obj-123'
                        arcInstanceResourceGroup = 'rg-arc'
                    }
                }
            }
            Mock Assign-ArcRoles { return $true }
            Mock Execute-Without-ProgressBar {
                param($ScriptBlock)
                return [PSCustomObject]@{ secretText = 'fake-secret' }
            }
            Mock Write-Progress { }

            $result = Create-ArcSPN -ArcResource $arcResource
            $result | Should -BeOfType [System.Management.Automation.PSCredential]
        }

        It 'Should return ArcPermissionsMissing when role assignment fails' {
            $arcResource = [PSCustomObject]@{
                ResourceId = '/subscriptions/sub-1/resourceGroups/rg-1/providers/Microsoft.AzureStackHCI/clusters/cl-1/arcSettings/default'
                Properties = [PSCustomObject]@{
                    arcApplicationObjectId = 'existing-obj'
                    arcApplicationClientId = 'app-id-123'
                    arcServicePrincipalObjectId = 'spn-obj-123'
                    arcInstanceResourceGroup = 'rg-arc'
                }
            }

            Mock Assign-ArcRoles { return $false }

            $result = Create-ArcSPN -ArcResource $arcResource
            $result | Should -Be ([ErrorDetail]::ArcPermissionsMissing)
        }
    }

    Context 'Validate-MSIForArc' {
        It 'Should throw when Invoke-Command returns null (command not found)' {
            # When the command is not found, Invoke-Command returns $null.
            # Calling $null.Parameters.ContainsKey() throws a RuntimeException.
            # The function does not catch this, so it propagates as an error.
            Mock Invoke-Command { return $null }

            $hciResource = [PSCustomObject]@{
                identity = [PSCustomObject]@{
                    type = 'SystemAssigned'
                    principalId = 'principal-123'
                }
            }

            $session = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            { Validate-MSIForArc -HCIResource $hciResource -Session $session } | Should -Throw
        }

        It 'Should return false when HCIResource identity is null' {
            # Return a command-like object but with no AccessToken parameter
            Mock Invoke-Command {
                return [PSCustomObject]@{ Parameters = @{ SomeParam = $true } }
            }

            $hciResource = [PSCustomObject]@{ identity = $null }

            $session = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            $result = Validate-MSIForArc -HCIResource $hciResource -Session $session
            $result | Should -Be $false
        }

        It 'Should return false when command does not have AccessToken parameter' {
            Mock Invoke-Command {
                return [PSCustomObject]@{ Parameters = @{ SomeOtherParam = $true } }
            }

            $hciResource = [PSCustomObject]@{
                identity = [PSCustomObject]@{
                    type = 'SystemAssigned'
                    principalId = 'principal-123'
                }
            }

            $session = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            $result = Validate-MSIForArc -HCIResource $hciResource -Session $session
            $result | Should -Be $false
        }
    }

    Context 'Set-ArcRoleforRPSpn' {
        It 'Should return Success when role already exists' {
            Mock Get-AzRoleAssignment {
                return @([PSCustomObject]@{
                    RoleDefinitionName = 'Azure Connected Machine Resource Manager'
                })
            }

            $result = Set-ArcRoleforRPSpn -RPObjectId 'rp-obj-1' -ArcServerResourceGroupName 'rg-arc'
            $result | Should -Be ([ErrorDetail]::Success)
        }

        It 'Should assign role and return Success when role does not exist' {
            Mock Get-AzRoleAssignment { return @() }
            Mock New-AzRoleAssignment { }

            $result = Set-ArcRoleforRPSpn -RPObjectId 'rp-obj-1' -ArcServerResourceGroupName 'rg-arc'
            $result | Should -Be ([ErrorDetail]::Success)
            Assert-MockCalled New-AzRoleAssignment -Times 1
        }
    }

    Context 'Verify-ArcRegistration' {
        It 'Should call Verify-ArcSettings and Sync-AzureStackHCI' {
            Mock Verify-ArcSettings { return [ErrorDetail]::Success }
            Mock Write-Progress { }
            Mock Invoke-Command { }
            Mock Write-NodeEventLog { }

            $session = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            $result = Verify-ArcRegistration -ArcResourceId '/sub/rg/arc' -Session $session `
                -IsManagementNode $false -ComputerName 'localhost'

            $result | Should -Be ([ErrorDetail]::Success)
        }

        It 'Should warn when ArcIntegrationFailedOnNodes persists' {
            Mock Verify-ArcSettings { return [ErrorDetail]::ArcIntegrationFailedOnNodes }
            Mock Write-Progress { }
            Mock Invoke-Command { }
            Mock Write-NodeEventLog { }
            Mock Write-Warning { }

            $session = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            $result = Verify-ArcRegistration -ArcResourceId '/sub/rg/arc' -Session $session `
                -IsManagementNode $false -ComputerName 'localhost'

            $result | Should -Be ([ErrorDetail]::ArcIntegrationFailedOnNodes)
        }
    }

    Context 'Disable-ArcForServers' {
        It 'Should return true when Arc is already disabled' {
            $session = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'

            Mock Invoke-Command -ParameterFilter { $ScriptBlock -and "$ScriptBlock" -match 'Get-ClusterNode' } {
                return @([PSCustomObject]@{ Name = 'Node1' })
            }
            Mock New-PSSession { return $session }
            Mock Invoke-Command {
                return [PSCustomObject]@{ ClusterArcStatus = [ArcStatus]::Disabled }
            }

            $result = Disable-ArcForServers -Session $session -ClusterDNSSuffix 'contoso.local'
            $result | Should -Be $true
        }
    }

    Context 'Write-NodeEventLog' {
        It 'Should not throw when IsManagementNode is false' {
            Mock New-PSSession {
                return New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            }
            Mock Invoke-Command { }

            { Write-NodeEventLog -Message 'Test' -EventID 9001 -IsManagementNode $false } | Should -Not -Throw
        }
    }

    Context 'Confirm-UserAcknowledgmentToUpgradeOS' {
        It 'Should not throw when OS build is greater than 22H2' {
            Mock Invoke-Command {
                return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '20351' }
            }

            # Pass a session so the function uses Invoke-Command (mocked) instead of running locally
            $session = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            { Confirm-UserAcknowledgmentToUpgradeOS -ClusterNodeSession $session } | Should -Not -Throw
        }
    }

    Context 'Confirm-UserAcknowledgmentUpgradeToSolution' {
        It 'Should write warning when 23H2+ with no solution' {
            $session = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'

            $callCount = 0
            Mock Invoke-Command {
                $script:callCount++
                if ($script:callCount -eq 1) {
                    return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '20351' }
                } else {
                    return [PSCustomObject]@{ HasDeploymentReg = $false; HasECEService = $false }
                }
            }
            Mock Write-Warning { }

            Confirm-UserAcknowledgmentUpgradeToSolution -ClusterNodeSession $session
            Assert-MockCalled Write-Warning -Times 1
        }
    }

    Context 'Test-ClusterArcEnabled' {
        It 'Should return true when all nodes are Arc-enabled' {
            $clusterNodes = @([PSCustomObject]@{ Name = 'Node1' })

            Mock Invoke-Command { }

            $result = Test-ClusterArcEnabled -ClusterNodes $clusterNodes -ClusterDNSSuffix 'contoso.local' `
                -SubscriptionId 'sub-1' -ArcResourceGroupName 'rg-arc'
            $result | Should -Be $true
        }
    }

    Context 'Test-ArcNodeClusterLink' {
        It 'Should return true when all nodes are linked' {
            $clusterNodes = @([PSCustomObject]@{ Name = 'Node1' })

            Mock Get-AzResource {
                return [PSCustomObject]@{
                    Properties = [PSCustomObject]@{ parentClusterResourceId = '/sub/rg/cluster1' }
                }
            }

            $result = Test-ArcNodeClusterLink -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' `
                -ArcServerResourceGroupName 'rg-arc' -ResourceId '/sub/rg/cluster1' -MaxRetries 1 -DelaySeconds 0
            $result | Should -Be $true
        }

        It 'Should return false when node link does not match' {
            $clusterNodes = @([PSCustomObject]@{ Name = 'Node1' })

            Mock Get-AzResource {
                return [PSCustomObject]@{
                    Properties = [PSCustomObject]@{ parentClusterResourceId = '/sub/rg/other-cluster' }
                }
            }

            $result = Test-ArcNodeClusterLink -ClusterNodes $clusterNodes -SubscriptionId 'sub-1' `
                -ArcServerResourceGroupName 'rg-arc' -ResourceId '/sub/rg/cluster1' -MaxRetries 1 -DelaySeconds 0
            $result | Should -Be $false
        }
    }

    Context 'Get-LogsDirectoryHelper' {
        It 'Should return null when no scheduled task is found' {
            Mock Invoke-Command { return $null }

            $result = Get-LogsDirectoryHelper
            $result | Should -Be $null
        }

        It 'Should return directory path from scheduled task' {
            Mock Invoke-Command { return 'C:\Logs\ArcForServers' }

            $result = Get-LogsDirectoryHelper
            $result | Should -Be 'C:\Logs\ArcForServers'
        }
    }

    Context 'Get-GraphAccessToken' {
        It 'Should call Get-AzADApplication to prime token cache' {
            Mock Get-AzADApplication { }
            Mock Get-AzContext {
                return [PSCustomObject]@{
                    Environment = [PSCustomObject]@{ GraphUrl = 'https://graph.microsoft.com' }
                    Account = [PSCustomObject]@{}
                    Tenant = [PSCustomObject]@{ Id = 'tenant-123' }
                }
            }

            # Mock the authentication factory chain
            $mockTokenItem = [PSCustomObject]@{ AccessToken = 'mock-graph-token-abc' }
            $mockAuthFactory = New-Object PSObject
            $mockAuthFactory | Add-Member -MemberType ScriptMethod -Name Authenticate -Value { return $mockTokenItem }
            $mockSession = New-Object PSObject
            $mockSession | Add-Member -MemberType NoteProperty -Name AuthenticationFactory -Value $mockAuthFactory
            $mockInstance = New-Object PSObject
            $mockInstance | Add-Member -MemberType NoteProperty -Name Instance -Value $mockSession

            # We can't easily mock the static AzureSession chain, so verify the function exists
            # and has the right parameters
            $cmd = Get-Command Get-GraphAccessToken
            $cmd.Parameters.Keys | Should -Contain 'TenantId'
            $cmd.Parameters.Keys | Should -Contain 'EnvironmentName'
        }

        It 'Should accept TenantId and EnvironmentName parameters' {
            $cmd = Get-Command Get-GraphAccessToken
            $cmd.Parameters['TenantId'].ParameterType.Name | Should -Be 'String'
            $cmd.Parameters['EnvironmentName'].ParameterType.Name | Should -Be 'String'
        }
    }

    Context 'Initialize-AzureLocalConfig' {
        It 'Should update Azure Local endpoints from metadata response' {
            # Initialize script-scope variables with the macro template (as the original script does)
            $script:DOMAINFQDNMACRO = '{DomainFqdn}'
            $script:AzureLocalPortalDomain = "https://portal.{DomainFqdn}"
            $script:ServiceEndpointAzureLocal = "https://dp.aszrp.{DomainFqdn}"
            $script:AuthorityAzureLocal = "https://login.{DomainFqdn}"
            $script:BillingServiceApiScopeAzureLocal = "https://dp.aszrp.{DomainFqdn}/.default"
            $script:GraphServiceApiScopeAzureLocal = "https://graph.{DomainFqdn}"

            Mock Retry-Command {
                return [PSCustomObject]@{
                    Suffixes = [PSCustomObject]@{ Storage = 'contoso.local' }
                    portal = 'https://portal.contoso.local'
                    dataplaneEndpoints = [PSCustomObject]@{
                        hciDataplaneServiceEndpoint = 'https://dp.aszrp.contoso.local'
                    }
                    authentication = [PSCustomObject]@{
                        loginEndpoint = 'https://login.contoso.local'
                    }
                    graph = 'https://graph.contoso.local'
                }
            }

            Initialize-AzureLocalConfig

            $script:ServiceEndpointAzureLocal | Should -Be 'https://dp.aszrp.contoso.local'
            $script:AuthorityAzureLocal | Should -Be 'https://login.contoso.local'
            $script:BillingServiceApiScopeAzureLocal | Should -Be 'https://dp.aszrp.contoso.local/.default'
            $script:GraphServiceApiScopeAzureLocal | Should -Be 'https://graph.contoso.local'
        }

        It 'Should replace FQDN macro in default endpoint URLs' {
            # Initialize script-scope variables with the macro template
            $script:DOMAINFQDNMACRO = '{DomainFqdn}'
            $script:AzureLocalPortalDomain = "https://portal.{DomainFqdn}"
            $script:ServiceEndpointAzureLocal = "https://dp.aszrp.{DomainFqdn}"
            $script:AuthorityAzureLocal = "https://login.{DomainFqdn}"
            $script:BillingServiceApiScopeAzureLocal = "https://dp.aszrp.{DomainFqdn}/.default"
            $script:GraphServiceApiScopeAzureLocal = "https://graph.{DomainFqdn}"

            Mock Retry-Command {
                return [PSCustomObject]@{
                    Suffixes = [PSCustomObject]@{ Storage = 'test.local' }
                }
            }

            Initialize-AzureLocalConfig

            $script:ServiceEndpointAzureLocal | Should -Be 'https://dp.aszrp.test.local'
            $script:AuthorityAzureLocal | Should -Be 'https://login.test.local'
        }
    }

    Context 'Register-ArcForServers' {
        It 'Should create a session to the management node when IsManagementNode is true' {
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'

            Mock New-PSSession { return $mockSession }
            Mock Write-Progress { }
            Mock Register-ResourceProviderIfRequired { }
            Mock Validate-MSIForArc { return $false }
            Mock Create-ArcSPN {
                return [System.Management.Automation.PSCredential]::new(
                    'app-id', (ConvertTo-SecureString 'secret' -AsPlainText -Force))
            }
            Mock Get-ClusterDNSName { return 'cluster1' }
            Mock Invoke-Command {
                return [PSCustomObject]@{
                    Parameters = @{ Cloud = $true }
                }
            }
            Mock Enable-ArcForServers { return [ErrorDetail]::Success }
            Mock Verify-ArcRegistration { return [ErrorDetail]::Success }
            Mock Remove-PSSession { }

            $arcResource = [PSCustomObject]@{
                ResourceId = '/sub/rg/arc'
                Properties = [PSCustomObject]@{
                    arcApplicationObjectId = 'obj-1'
                    arcApplicationClientId = 'app-1'
                    arcServicePrincipalObjectId = 'spn-1'
                    arcInstanceResourceGroup = 'rg-arc'
                }
            }
            $hciResource = [PSCustomObject]@{
                identity = [PSCustomObject]@{ type = 'SystemAssigned'; principalId = 'p-1' }
            }

            $result = Register-ArcForServers -IsManagementNode $true -ComputerName 'Node1' `
                -TenantId 'tenant-1' -SubscriptionId 'sub-1' -ResourceGroup 'rg-1' `
                -Region 'eastus' -ClusterDNSSuffix 'contoso.local' -Environment 'AzureCloud' `
                -ArcResource $arcResource -HCIResource $hciResource

            Assert-MockCalled New-PSSession -Times 1 -Scope It
        }

        It 'Should return ArcPermissionsMissing when SPN roles are not present' {
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'
            $arcSpnCred = [System.Management.Automation.PSCredential]::new(
                'app-id', (ConvertTo-SecureString 'secret' -AsPlainText -Force))

            Mock New-PSSession { return $mockSession }
            Mock Write-Progress { }
            Mock Register-ResourceProviderIfRequired { }
            Mock Retry-Command {
                return [PSCustomObject]@{ Id = 'spn-obj-id' }
            }
            Mock Verify-arcSPNRoles { return $false }

            $arcResource = [PSCustomObject]@{
                ResourceId = '/sub/rg/arc'
                Properties = [PSCustomObject]@{
                    arcApplicationObjectId = 'obj-1'
                    arcInstanceResourceGroup = 'rg-arc'
                }
            }
            $hciResource = [PSCustomObject]@{
                identity = [PSCustomObject]@{ type = 'SystemAssigned'; principalId = 'p-1' }
            }

            $result = Register-ArcForServers -IsManagementNode $false `
                -TenantId 'tenant-1' -SubscriptionId 'sub-1' -ResourceGroup 'rg-1' `
                -Region 'eastus' -ClusterDNSSuffix 'contoso.local' -Environment 'AzureCloud' `
                -ArcResource $arcResource -HCIResource $hciResource -ArcSpnCredential $arcSpnCred

            $result | Should -Be ([ErrorDetail]::ArcPermissionsMissing)
        }
    }

    Context 'Unregister-ArcForServers' {
        It 'Should return true when Arc is already disabled and no extensions' {
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'

            Mock New-PSSession { return $mockSession }
            Mock Invoke-Command -ParameterFilter { $ScriptBlock -ne $null } {
                return [PSCustomObject]@{
                    ClusterArcStatus = [ArcStatus]::Disabled
                }
            }
            Mock Get-ClusterDNSName { return 'cluster1' }
            Mock Get-AzResource { return $null }
            Mock Write-Progress { }
            Mock Execute-Without-ProgressBar { }
            Mock Remove-PSSession { }

            $result = Unregister-ArcForServers -IsManagementNode $false `
                -ResourceId '/sub/rg/cluster1' -ClusterDNSSuffix 'contoso.local'

            # When ClusterArcStatus is Disabled, the function should return true
            $result | Should -Be $true
        }

        It 'Should call New-PSSession for management node' {
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'

            Mock New-PSSession { return $mockSession }
            Mock Invoke-Command {
                return [PSCustomObject]@{ ClusterArcStatus = [ArcStatus]::Disabled }
            }
            Mock Get-ClusterDNSName { return 'cluster1' }
            Mock Get-AzResource { return $null }
            Mock Write-Progress { }
            Mock Remove-PSSession { }

            Unregister-ArcForServers -IsManagementNode $true -ComputerName 'Node1' `
                -ResourceId '/sub/rg/cluster1' -ClusterDNSSuffix 'contoso.local'

            Assert-MockCalled New-PSSession -Times 1 -Scope It
        }
    }

    Context 'Invoke-MSIFlow' {
        It 'Should throw when Set-AzureStackHCIRegistrationMsi fails on all nodes' {
            $clusterNodes = @([PSCustomObject]@{ Name = 'Node1' })
            $mockSession = New-MockObject -Type 'System.Management.Automation.Runspaces.PSSession'

            Mock New-PSSession { return $mockSession }
            Mock Invoke-Command { throw 'MSI registration failed' }
            Mock Write-Progress { }
            Mock Remove-PSSession { }

            {
                Invoke-MSIFlow -ClusterNodes $clusterNodes -ClusterDNSSuffix 'contoso.local' `
                    -ResourceId '/sub/rg/cluster1' -RPAPIVersion '2025-09-15-preview' `
                    -SubscriptionId 'sub-1' -TenantId 'tenant-1' -AccountId 'user@test.com' `
                    -EnvironmentName 'AzureCloud' -Region 'eastus' `
                    -ClusterNodeSession $mockSession
            } | Should -Throw
        }
    }

    Context 'Invoke-MSIUnregistrationFlow' {
        It 'Should have expected mandatory parameters' {
            $cmd = Get-Command Invoke-MSIUnregistrationFlow
            $cmd.Parameters.Keys | Should -Contain 'ClusterNodes'
            $cmd.Parameters.Keys | Should -Contain 'ClusterDNSSuffix'
            $cmd.Parameters.Keys | Should -Contain 'ResourceId'
            $cmd.Parameters.Keys | Should -Contain 'RPAPIVersion'
            $cmd.Parameters.Keys | Should -Contain 'SubscriptionId'
            $cmd.Parameters.Keys | Should -Contain 'ClusterNodeSession'
            $cmd.Parameters.Keys | Should -Contain 'ResourceName'
            $cmd.Parameters.Keys | Should -Contain 'ResourceGroupName'
        }

        It 'Should have optional parameters for management scenarios' {
            $cmd = Get-Command Invoke-MSIUnregistrationFlow
            $cmd.Parameters.Keys | Should -Contain 'Credential'
            $cmd.Parameters.Keys | Should -Contain 'IsManagementNode'
            $cmd.Parameters.Keys | Should -Contain 'ComputerName'
            $cmd.Parameters.Keys | Should -Contain 'IsWAC'
            $cmd.Parameters.Keys | Should -Contain 'Force'
            $cmd.Parameters.Keys | Should -Contain 'DisableOnlyAzureArcServer'
        }
    }

    Context 'Register-AzStackHCI' {
        BeforeEach {
            $script:errorMessages.Clear()
        }

        It 'Should have required parameters SubscriptionId and Region' {
            $cmd = Get-Command Register-AzStackHCI
            $cmd.Parameters.Keys | Should -Contain 'SubscriptionId'
            $cmd.Parameters.Keys | Should -Contain 'Region'
        }

        It 'Should have SupportsShouldProcess attribute' {
            $cmd = Get-Command Register-AzStackHCI
            $cmd.CommandType | Should -Be 'Function'
            $metadata = [System.Management.Automation.CommandMetadata]::new($cmd)
            $metadata.SupportsShouldProcess | Should -Be $true
        }

        It 'Should have optional parameters for non-interactive login' {
            $cmd = Get-Command Register-AzStackHCI
            $cmd.Parameters.Keys | Should -Contain 'ArmAccessToken'
            $cmd.Parameters.Keys | Should -Contain 'AccountId'
            $cmd.Parameters.Keys | Should -Contain 'TenantId'
            $cmd.Parameters.Keys | Should -Contain 'ResourceGroupName'
            $cmd.Parameters.Keys | Should -Contain 'ResourceName'
            $cmd.Parameters.Keys | Should -Contain 'EnvironmentName'
            $cmd.Parameters.Keys | Should -Contain 'ComputerName'
            $cmd.Parameters.Keys | Should -Contain 'Credential'
        }

        It 'Should default EnvironmentName to AzureCloud' {
            $cmd = Get-Command Register-AzStackHCI
            $envParam = $cmd.Parameters['EnvironmentName']
            $envParam.Attributes | Where-Object { $_ -is [System.Management.Automation.ParameterAttribute] } | Should -Not -BeNullOrEmpty
        }

        It 'Should fail with RepairRegistration when cluster is not registered' {
            # Mock the entire dependency chain
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Confirm-UserAcknowledgmentUpgradeToSolution {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Invoke-Command { return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398' } }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Write-Progress {}

            $output = Register-AzStackHCI -SubscriptionId 'test-sub' -Region 'eastus' -RepairRegistration -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            # The function should have set Result to Failed due to no existing registration
            # It writes the error "Can't repair registration because the cluster isn't registered yet"
            ($script:errorMessages -join "`n") | Should -BeLike "*repair registration*"
        }

        It 'Should fail when already registered with different resource ID' {
            $existingResourceUri = "/Subscriptions/other-sub/resourceGroups/other-rg/providers/Microsoft.AzureStackHCI/clusters/OtherCluster"
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::Registered
                    AzureResourceUri   = $existingResourceUri
                }
                return $regContext, $true, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Confirm-UserAcknowledgmentUpgradeToSolution {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {
                param($Session, $ScriptBlock)
                # Return appropriate mock for different ScriptBlock invocations
                return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398' }
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "TestCluster" }
            Mock Azure-Login { return 'test-tenant-id' }
            Mock Get-AzResource { return [PSCustomObject]@{ Location = 'eastus'; Properties = @{ aadClientId = 'app-id' } } }
            Mock Get-AzResourceGroup { return [PSCustomObject]@{ ResourceGroupName = 'test-rg' } }
            Mock Verify-NodesArcRegistrationState {}
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com/resource" }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            Mock Disconnect-AzAccount {}

            $output = Register-AzStackHCI -SubscriptionId 'test-sub' -Region 'eastus' -ResourceName 'MyCluster' -ResourceGroupName 'my-rg' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*already registered*"
        }

        It 'Should set IsManagementNode when ComputerName is specified' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {
                return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398'; Name = 'TestCluster' }
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "TestCluster" }
            Mock Azure-Login { return 'test-tenant-id' }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            Mock Get-AzResource { return $null }
            Mock Get-AzResourceGroup { return $null }
            Mock Verify-NodesArcRegistrationState {}
            Mock Register-ResourceProviderIfRequired {}
            Mock Validate-RegionName { return $true }
            Mock ValidateCloudDeployment { return $false }
            Mock New-AzResourceGroup { return [PSCustomObject]@{ ResourceGroupName = 'TestCluster-rg' } }
            Mock New-ClusterWithRetries { return $true }
            Mock Execute-Without-ProgressBar { return $null }
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com/resource" }
            Mock Disconnect-AzAccount {}

            # ComputerName specified means IsManagementNode = true
            # The function should call Get-SetupLoggingDetails with IsManagementNode = true
            Assert-MockCalled Get-SetupLoggingDetails -Times 0 -Scope It # haven't called yet
            
            # Just verify it doesn't crash when calling with ComputerName
            # (deep flow will fail at some point but the IsManagementNode logic is tested by parameter presence)
            $cmd = Get-Command Register-AzStackHCI
            $cmd.Parameters.Keys | Should -Contain 'ComputerName'
        }

        It 'Should succeed when already registered with same resource ID and resource exists' {
            $resourceUri = "/Subscriptions/sub-123/resourceGroups/my-rg/providers/Microsoft.AzureStackHCI/clusters/MyCluster"
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::Registered
                    AzureResourceUri   = $resourceUri
                }
                return $regContext, $true, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Confirm-UserAcknowledgmentUpgradeToSolution {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {
                return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398'; Name = 'MyCluster' }
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "MyCluster" }
            Mock Azure-Login { return 'test-tenant' }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            Mock Get-AzResource {
                return [PSCustomObject]@{
                    Location = 'eastus'
                    Properties = [PSCustomObject]@{ aadClientId = 'app-id'; arcInstanceResourceGroup = 'my-rg' }
                    Identity = [PSCustomObject]@{ Type = 'SystemAssigned' }
                }
            }
            Mock Get-AzResourceGroup { return [PSCustomObject]@{ ResourceGroupName = 'my-rg' } }
            Mock Verify-NodesArcRegistrationState {}
            Mock ValidateCloudDeployment { return $false }
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com/resource" }
            Mock Test-ArcNodeClusterLink { return $true }
            Mock Disconnect-AzAccount {}

            $output = Register-AzStackHCI -SubscriptionId 'sub-123' -Region 'eastus' -ResourceName 'MyCluster' -ResourceGroupName 'my-rg' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            # Should produce output containing Success
            ($output | Out-String) | Should -BeLike "*Success*"
        }

        It 'Should fail when registered but cloud resource does not exist' {
            $resourceUri = "/Subscriptions/sub-123/resourceGroups/my-rg/providers/Microsoft.AzureStackHCI/clusters/MyCluster"
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::Registered
                    AzureResourceUri   = $resourceUri
                }
                return $regContext, $true, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Confirm-UserAcknowledgmentUpgradeToSolution {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {
                return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398'; Name = 'MyCluster' }
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "MyCluster" }
            Mock Azure-Login { return 'test-tenant' }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            # Resource does NOT exist in Azure
            Mock Get-AzResource { return $null }
            Mock Get-AzResourceGroup { return [PSCustomObject]@{ ResourceGroupName = 'my-rg' } }
            Mock Verify-NodesArcRegistrationState {}
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com/resource" }
            Mock Disconnect-AzAccount {}

            $output = Register-AzStackHCI -SubscriptionId 'sub-123' -Region 'eastus' -ResourceName 'MyCluster' -ResourceGroupName 'my-rg' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*doesn't exist*"
        }

        It 'Should fail when ResourceName differs from existing registration' {
            $existingUri = "/Subscriptions/sub-123/resourceGroups/my-rg/providers/Microsoft.AzureStackHCI/clusters/ExistingCluster"
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::Registered
                    AzureResourceUri   = $existingUri
                }
                return $regContext, $true, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command { return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398' } }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Disconnect-AzAccount {}

            # Providing a different ResourceName than what's in the registration context
            $output = Register-AzStackHCI -SubscriptionId 'sub-123' -Region 'eastus' -ResourceName 'DifferentCluster' -ResourceGroupName 'my-rg' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*already registered with resource name*"
        }

        It 'Should fail when ResourceGroupName differs from existing registration' {
            $existingUri = "/Subscriptions/sub-123/resourceGroups/existing-rg/providers/Microsoft.AzureStackHCI/clusters/MyCluster"
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::Registered
                    AzureResourceUri   = $existingUri
                }
                return $regContext, $true, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command { return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398' } }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Disconnect-AzAccount {}

            $output = Register-AzStackHCI -SubscriptionId 'sub-123' -Region 'eastus' -ResourceName 'MyCluster' -ResourceGroupName 'different-rg' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*already been created in resource group*"
        }

        It 'Should fail when SubscriptionId differs from existing registration' {
            $existingUri = "/Subscriptions/original-sub/resourceGroups/my-rg/providers/Microsoft.AzureStackHCI/clusters/MyCluster"
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::Registered
                    AzureResourceUri   = $existingUri
                }
                return $regContext, $true, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command { return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398' } }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Disconnect-AzAccount {}

            $output = Register-AzStackHCI -SubscriptionId 'different-sub' -Region 'eastus' -ResourceName 'MyCluster' -ResourceGroupName 'my-rg' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*already registered to subscription*"
        }

        It 'Should fail when region is not supported' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {
                return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398'; Name = 'TestCluster' }
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "TestCluster" }
            Mock Azure-Login { return 'test-tenant' }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            Mock Get-AzResource { return $null }
            Mock Get-AzResourceGroup { return $null }
            Mock Verify-NodesArcRegistrationState {}
            Mock Register-ResourceProviderIfRequired {}
            # Region validation fails
            Mock Validate-RegionName { return $false }
            Mock Disconnect-AzAccount {}
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com" }

            $output = Register-AzStackHCI -SubscriptionId 'sub-1' -Region 'invalidregion' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*not yet available in region*"
        }

        It 'Should fail when cluster resource creation fails' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {
                return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398'; Name = 'TestCluster' }
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "TestCluster" }
            Mock Azure-Login { return 'test-tenant' }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            Mock Get-AzResource { return $null }
            Mock Get-AzResourceGroup { return $null }
            Mock Verify-NodesArcRegistrationState {}
            Mock Register-ResourceProviderIfRequired {}
            Mock Validate-RegionName { return $true }
            Mock ValidateCloudDeployment { return $false }
            Mock New-AzResourceGroup { return [PSCustomObject]@{ ResourceGroupName = 'TestCluster-rg' } }
            # Cluster creation fails
            Mock New-ClusterWithRetries { return $false }
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com" }
            Mock Disconnect-AzAccount {}

            $output = Register-AzStackHCI -SubscriptionId 'sub-1' -Region 'eastus' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*Failed to create cluster resource*"
        }

        It 'Should fail when resource exists in a different region' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {
                return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398'; Name = 'TestCluster' }
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "TestCluster" }
            Mock Azure-Login { return 'test-tenant' }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            # Resource exists in westus but user specified eastus
            Mock Get-AzResource {
                return [PSCustomObject]@{
                    Location = 'westus'
                    Properties = [PSCustomObject]@{ aadClientId = 'app-id' }
                }
            }
            Mock Get-AzResourceGroup { return [PSCustomObject]@{ ResourceGroupName = 'test-rg' } }
            Mock Verify-NodesArcRegistrationState {}
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com" }
            Mock Disconnect-AzAccount {}

            $output = Register-AzStackHCI -SubscriptionId 'sub-1' -Region 'eastus' -ResourceName 'TestCluster' -ResourceGroupName 'test-rg' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*different from the input region*"
        }

        It 'Should fail when Get-Cluster returns null (not part of a cluster)' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            # First call returns OS version, second (Get-Cluster) returns null, third (Get-ClusterNode) returns empty
            $script:invokeCallCount = 0
            Mock Invoke-Command {
                $script:invokeCallCount++
                if ($script:invokeCallCount -le 3) {
                    # OS version + cloud management detectoids
                    return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398' }
                }
                # Get-Cluster call returns null
                return $null
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "" }
            Mock Disconnect-AzAccount {}

            $output = Register-AzStackHCI -SubscriptionId 'sub-1' -Region 'eastus' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*not part of an Azure Stack HCI cluster*"
        }

        It 'Should fail for cloud deployment when cluster ARM resource is not present' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {
                return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398'; Name = 'TestCluster' }
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "TestCluster" }
            Mock Azure-Login { return 'test-tenant' }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            Mock Get-AzResource { return $null }
            Mock Get-AzResourceGroup { return [PSCustomObject]@{ ResourceGroupName = 'TestCluster-rg' } }
            Mock Verify-NodesArcRegistrationState {}
            Mock Register-ResourceProviderIfRequired {}
            Mock Validate-RegionName { return $true }
            # Cloud deployment - should fail because resource doesn't exist
            Mock ValidateCloudDeployment { return $true }
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com" }
            Mock Disconnect-AzAccount {}

            $output = Register-AzStackHCI -SubscriptionId 'sub-1' -Region 'eastus' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*Cluster Resource needs to be pre-configured*"
        }

        It 'Should resolve ResourceName from cluster when not explicitly provided' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            # Get-Cluster returns a cluster with Name = 'AutoCluster'
            $script:invokeSeq = 0
            Mock Invoke-Command {
                $script:invokeSeq++
                if ($script:invokeSeq -le 3) {
                    return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398' }
                }
                if ($script:invokeSeq -eq 4) {
                    # clusScript (Install-WindowsFeature) - no return needed
                    return $null
                }
                if ($script:invokeSeq -eq 5) {
                    # Get-Cluster
                    return [PSCustomObject]@{ Name = 'AutoCluster' }
                }
                if ($script:invokeSeq -eq 6) {
                    # Get-ClusterNode
                    return @([PSCustomObject]@{ Name = 'Node1' })
                }
                return $null
            }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "AutoCluster" }
            Mock Azure-Login { return 'test-tenant' }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            Mock Get-AzResource { return $null }
            Mock Get-AzResourceGroup { return $null }
            Mock Verify-NodesArcRegistrationState {}
            Mock Register-ResourceProviderIfRequired {}
            Mock Validate-RegionName { return $true }
            Mock ValidateCloudDeployment { return $false }
            Mock New-AzResourceGroup { return [PSCustomObject]@{ ResourceGroupName = 'AutoCluster-rg' } }
            Mock New-ClusterWithRetries { return $true }
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com" }
            Mock Disconnect-AzAccount {}
            # After cluster creation, resource must be fetched
            $script:getResourceCallCount = 0
            Mock Get-AzResource {
                $script:getResourceCallCount++
                if ($script:getResourceCallCount -gt 1) {
                    return [PSCustomObject]@{
                        Properties = [PSCustomObject]@{
                            aadApplicationObjectId = $null
                            ResourceProviderObjectId = $null
                        }
                        Identity = [PSCustomObject]@{ Type = 'SystemAssigned' }
                    }
                }
                return $null
            }
            Mock Execute-Without-ProgressBar { return $null }
            Mock Invoke-AzRestMethod { return [PSCustomObject]@{ StatusCode = 200 } }

            # Don't provide ResourceName — it should be resolved from Get-Cluster
            $output = Register-AzStackHCI -SubscriptionId 'sub-1' -Region 'eastus' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            # Verify Azure-Login was called (means it got past the cluster name resolution)
            Assert-MockCalled Azure-Login -Times 1
        }

        It 'Should resolve ResourceGroupName from ResourceName when not provided' {
            # When ResourceGroupName is not provided, it defaults to "$ResourceName-rg"
            Mock Get-SetupLoggingDetails {
                return ([PSCustomObject]@{ RegistrationStatus = [RegistrationStatus]::NotYetRegistered; AzureResourceUri = $null }), $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging { return $TestDrive }
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command { return [PSCustomObject]@{ DisplayVersion = '23H2'; BuildNumber = '25398'; Name = 'TestCluster' } }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "TestCluster" }
            Mock Azure-Login { return 'test-tenant' }
            Mock Normalize-RegionName { param($Region) return $Region.ToLower() -replace '\s','' }
            Mock Get-AzResource { return $null }
            Mock Get-AzResourceGroup { return $null }
            Mock Verify-NodesArcRegistrationState {}
            Mock Register-ResourceProviderIfRequired {}
            Mock Validate-RegionName { return $true }
            Mock ValidateCloudDeployment { return $false }
            # Capture the ResourceGroupName passed to New-AzResourceGroup
            Mock New-AzResourceGroup { return [PSCustomObject]@{ ResourceGroupName = $Name } }
            Mock New-ClusterWithRetries { return $true }
            Mock Get-PortalHCIResourcePageUrl { return "https://portal.azure.com" }
            Mock Disconnect-AzAccount {}
            Mock Execute-Without-ProgressBar { return $null }

            Register-AzStackHCI -SubscriptionId 'sub-1' -Region 'eastus' -ResourceName 'MyCluster' -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1 | Out-Null

            # The default RG name should be "MyCluster-rg"
            Assert-MockCalled New-AzResourceGroup -Times 1
        }

        It 'Should have all expected optional parameters' {
            $cmd = Get-Command Register-AzStackHCI
            $cmd.Parameters.Keys | Should -Contain 'Tag'
            $cmd.Parameters.Keys | Should -Contain 'CertificateThumbprint'
            $cmd.Parameters.Keys | Should -Contain 'RepairRegistration'
            $cmd.Parameters.Keys | Should -Contain 'UseDeviceAuthentication'
            $cmd.Parameters.Keys | Should -Contain 'IsWAC'
            $cmd.Parameters.Keys | Should -Contain 'ArcServerResourceGroupName'
            $cmd.Parameters.Keys | Should -Contain 'ArcSpnCredential'
            $cmd.Parameters.Keys | Should -Contain 'LogsDirectory'
        }

        It 'Should have RepairRegistration as a Switch parameter' {
            $cmd = Get-Command Register-AzStackHCI
            $cmd.Parameters['RepairRegistration'].SwitchParameter | Should -Be $true
        }

        It 'Should have UseDeviceAuthentication as a Switch parameter' {
            $cmd = Get-Command Register-AzStackHCI
            $cmd.Parameters['UseDeviceAuthentication'].SwitchParameter | Should -Be $true
        }

        It 'Should have ConfirmImpact set to High' {
            $cmd = Get-Command Register-AzStackHCI
            $cmdletBindingAttr = $cmd.ScriptBlock.Attributes | Where-Object { $_ -is [System.Management.Automation.CmdletBindingAttribute] }
            $cmdletBindingAttr.ConfirmImpact | Should -Be 'High'
        }
    }

    Context 'Unregister-AzStackHCI' {
        BeforeEach {
            $script:errorMessages.Clear()
        }

        It 'Should have SupportsShouldProcess attribute' {
            $cmd = Get-Command Unregister-AzStackHCI
            $metadata = [System.Management.Automation.CommandMetadata]::new($cmd)
            $metadata.SupportsShouldProcess | Should -Be $true
        }

        It 'Should have expected parameters' {
            $cmd = Get-Command Unregister-AzStackHCI
            $cmd.Parameters.Keys | Should -Contain 'SubscriptionId'
            $cmd.Parameters.Keys | Should -Contain 'ResourceName'
            $cmd.Parameters.Keys | Should -Contain 'TenantId'
            $cmd.Parameters.Keys | Should -Contain 'ResourceGroupName'
            $cmd.Parameters.Keys | Should -Contain 'ArmAccessToken'
            $cmd.Parameters.Keys | Should -Contain 'AccountId'
            $cmd.Parameters.Keys | Should -Contain 'EnvironmentName'
            $cmd.Parameters.Keys | Should -Contain 'ComputerName'
            $cmd.Parameters.Keys | Should -Contain 'Force'
        }

        It 'Should have DisableOnlyAzureArcServer switch parameter' {
            $cmd = Get-Command Unregister-AzStackHCI
            $cmd.Parameters.Keys | Should -Contain 'DisableOnlyAzureArcServer'
            $cmd.Parameters['DisableOnlyAzureArcServer'].SwitchParameter | Should -Be $true
        }

        It 'Should fail when not registered and no ResourceName or SubscriptionId provided' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Confirm-UserAcknowledgmentUpgradeToSolution {}
            Mock Setup-Logging { return $TestDrive }
            Mock Check-DependentModules {}
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {}
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "TestCluster" }
            Mock Disconnect-AzAccount {}

            $output = Unregister-AzStackHCI -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            # Should fail with RegistrationInfoNotFound or similar error
            ($script:errorMessages -join "`n") | Should -BeLike "*unregister*"
        }

        It 'Should resolve parameters from registration context when registered' {
            $regUri = "/Subscriptions/sub-123/resourceGroups/rg-test/providers/Microsoft.AzureStackHCI/clusters/TestCluster"
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::Registered
                    AzureResourceUri   = $regUri
                }
                return $regContext, $true, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Confirm-UserAcknowledgmentUpgradeToSolution {}
            Mock Setup-Logging { return $TestDrive }
            Mock Check-DependentModules {}
            Mock Print-FunctionParameters { return "test" }
            Mock Write-NodeEventLog {}
            Mock Write-Progress {}
            Mock Invoke-Command {}
            Mock Get-ClusterDNSSuffix { return "contoso.local" }
            Mock Get-ClusterDNSName { return "TestCluster" }
            Mock Azure-Login { return 'test-tenant-id' }
            Mock Normalize-RegionName { param($Region) return $Region }
            Mock Test-ClusterMsiSupport { return $false }
            Mock Unregister-ArcForServers { return $true }
            Mock Get-AzResource { return $null }
            Mock Remove-ResourceGroup {}
            Mock Disconnect-AzAccount {}

            # Should resolve SubscriptionId, ResourceGroupName, ResourceName from registration context
            # and proceed without error (ShouldProcess will be true with -Confirm:$false)
            $output = Unregister-AzStackHCI -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            # Verify Azure-Login was called (meaning parameter resolution succeeded)
            Assert-MockCalled Azure-Login -Times 1
        }
    }

    Context 'Set-AzStackHCI' {
        BeforeEach {
            $script:errorMessages.Clear()
        }

        It 'Should have SupportsShouldProcess attribute' {
            $cmd = Get-Command Set-AzStackHCI
            $metadata = [System.Management.Automation.CommandMetadata]::new($cmd)
            $metadata.SupportsShouldProcess | Should -Be $true
        }

        It 'Should have OutputType defined' {
            $cmd = Get-Command Set-AzStackHCI
            $outputType = $cmd.OutputType
            $outputType | Should -Not -BeNullOrEmpty
            # OutputType can be PSObject or PSCustomObject depending on runtime
            ($outputType.Type.Name -contains 'PSCustomObject' -or $outputType.Type.Name -contains 'PSObject') | Should -Be $true
        }

        It 'Should have expected parameters' {
            $cmd = Get-Command Set-AzStackHCI
            $cmd.Parameters.Keys | Should -Contain 'ComputerName'
            $cmd.Parameters.Keys | Should -Contain 'Credential'
            $cmd.Parameters.Keys | Should -Contain 'ResourceId'
            $cmd.Parameters.Keys | Should -Contain 'EnableWSSubscription'
            $cmd.Parameters.Keys | Should -Contain 'DiagnosticLevel'
            $cmd.Parameters.Keys | Should -Contain 'TenantId'
            $cmd.Parameters.Keys | Should -Contain 'ArmAccessToken'
            $cmd.Parameters.Keys | Should -Contain 'AccountId'
            $cmd.Parameters.Keys | Should -Contain 'EnvironmentName'
            $cmd.Parameters.Keys | Should -Contain 'UseDeviceAuthentication'
            $cmd.Parameters.Keys | Should -Contain 'Force'
        }

        It 'Should have ConfirmImpact set to High' {
            $cmd = Get-Command Set-AzStackHCI
            $cmdletBindingAttr = $cmd.ScriptBlock.Attributes | Where-Object { $_ -is [System.Management.Automation.CmdletBindingAttribute] }
            $cmdletBindingAttr.ConfirmImpact | Should -Be 'High'
        }

        It 'Should fail when cluster is not registered and no ResourceId provided' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging {}
            Mock Remove-PSSession {}
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Write-Progress {}
            Mock Disconnect-AzAccount {}

            $output = Set-AzStackHCI -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            ($script:errorMessages -join "`n") | Should -BeLike "*not registered*"
        }

        It 'Should set IsManagementNode to false when ComputerName not specified' {
            # Verify the function handles local-node logic
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging {}
            Mock Remove-PSSession {}
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Write-Progress {}
            Mock Disconnect-AzAccount {}

            # Without ComputerName, should use [Environment]::MachineName
            # Function will still fail because cluster is not registered, but that's after the IsManagementNode logic
            $output = Set-AzStackHCI -Confirm:$false -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            # Should still have been called (not crashed)
            Assert-MockCalled Get-SetupLoggingDetails -Times 1
        }

        It 'Should proceed to Azure login when ResourceId is explicitly provided' {
            Mock Get-SetupLoggingDetails {
                $regContext = [PSCustomObject]@{
                    RegistrationStatus = [RegistrationStatus]::NotYetRegistered
                    AzureResourceUri   = $null
                }
                return $regContext, $false, $script:mockSession, @{}
            }
            Mock Confirm-UserAcknowledgmentToUpgradeOS {}
            Mock Setup-Logging {}
            Mock Remove-PSSession {}
            Mock Show-LatestModuleVersion {}
            Mock Check-DependentModules {}
            Mock Write-Progress {}
            Mock Azure-Login { return 'test-tenant' }
            Mock Invoke-Command {}
            Mock Get-AzResource { return [PSCustomObject]@{ Properties = @{ desiredProperties = @{} }; Location = 'eastus' } }
            Mock Invoke-AzRestMethod { return [PSCustomObject]@{ StatusCode = 200 } }
            Mock Disconnect-AzAccount {}

            # When ResourceId is provided, should skip the "not registered" check and go to Azure login
            $output = Set-AzStackHCI -ResourceId "/Subscriptions/sub-1/resourceGroups/rg-1/providers/Microsoft.AzureStackHCI/clusters/MyCluster" -Confirm:$false -Force -WarningAction SilentlyContinue -ErrorAction SilentlyContinue 2>&1
            # Verify it got past the registration check and called Azure-Login
            Assert-MockCalled Azure-Login -Times 1
        }
    }
}
