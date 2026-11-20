Describe 'HorizonDbSharedFixture' {
    BeforeEach {
        function Get-AzContext {}
        function New-AzResourceGroup {
            [CmdletBinding()]
            param($Name, $SubscriptionId, $Location)
        }
        function New-AzDeployment {
            [CmdletBinding()]
            param($Name, $ResourceGroupName, $SubscriptionId, $Mode, $TemplateFile, $TemplateParameterObject)
        }
        function Remove-AzResourceGroup {
            [CmdletBinding(SupportsShouldProcess)]
            param($Name, $SubscriptionId)
        }
        function Get-AzHorizonDbNode {
            [CmdletBinding()]
            param($ResourceGroupName, $ClusterName, $PoolName, $SubscriptionId)
        }
        function New-AzHorizonDbCluster {
            [CmdletBinding()]
            param($ResourceGroupName, $Name, $SubscriptionId, $Location, $PostgreSqlVersion, $BackupGeoRedundancy, $NetworkPublicAccess)
        }
        function New-AzHorizonDbParameterGroup {
            [CmdletBinding()]
            param($ResourceGroupName, $Name, $SubscriptionId, $Location, $PostgreSqlVersion, $Tag, $Description, $Parameter)
        }

        $fixtureDirectory = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $null = New-Item -ItemType Directory -Path $fixtureDirectory
        Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'utils.ps1') -Destination $fixtureDirectory
        Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'prereqs.json') -Destination $fixtureDirectory
        $TestMode = 'record'
        $TestName = @('Get-AzHorizonDbCluster')
        $UsePreviousConfigForRecord = $false
        . (Join-Path $fixtureDirectory 'utils.ps1')

        Mock Get-AzContext {
            @{
                Subscription = @{ Id = '00000000-0000-0000-0000-000000000001' }
                Tenant = @{ Id = '00000000-0000-0000-0000-000000000002' }
            }
        }
        Mock New-AzResourceGroup {}
        Mock New-AzDeployment { @{ ProvisioningState = 'Succeeded' } }
        Mock Remove-AzResourceGroup {}
        Mock Get-AzHorizonDbNode { @{ Name = 'fixture-node'; Id = 'fixture-node-id' } }
        Mock New-AzHorizonDbCluster { @{ ProvisioningState = 'Succeeded' } }
        Mock New-AzHorizonDbParameterGroup { @{ Name = $Name; Id = 'shared-parameter-group-id' } }
    }

    It 'Deploys and saves the shared fixture in <Mode> mode' -TestCases @(
        @{ Mode = 'record'; EnvFile = 'env.json' }
        @{ Mode = 'live'; EnvFile = 'localEnv.json' }
    ) {
        param($Mode, $EnvFile)
        $TestMode = $Mode

        setupEnv

        Assert-MockCalled New-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter {
            $Name -eq $env.sharedResourceGroup -and $SubscriptionId -eq $env.SubscriptionId -and $Location -eq 'indiasouthcentral'
        }
        Assert-MockCalled New-AzDeployment -Times 1 -Exactly -Scope It -ParameterFilter {
            $ResourceGroupName -eq $env.sharedResourceGroup -and
            $SubscriptionId -eq $env.SubscriptionId -and $Mode -eq 'Incremental' -and
            (Test-Path -LiteralPath $TemplateFile) -and
            $TemplateParameterObject.clusterName.value -eq $env.sharedClusterName -and
            $TemplateParameterObject.poolName.value -eq $env.sharedPoolName -and
            $TemplateParameterObject.location.value -eq $env.location
        }
        $saved = Get-Content -LiteralPath (Join-Path $fixtureDirectory $EnvFile) -Raw | ConvertFrom-Json
        $saved.sharedResourceGroup | Should -Be $env.sharedResourceGroup
        $saved.sharedClusterName | Should -Be $env.sharedClusterName
        $saved.sharedPoolName | Should -Be $env.sharedPoolName
        $saved.sharedNodeName | Should -Be 'fixture-node'
        $saved.sharedNodeId | Should -Be 'fixture-node-id'
        $saved.sharedResourceGroup | Should -Not -Be $saved.clusterResourceGroup
        $saved.sharedClusterName | Should -Not -Be $saved.clusterName
        Assert-MockCalled New-AzHorizonDbCluster -Times 0 -Exactly -Scope It
        Assert-MockCalled Get-AzHorizonDbNode -Times 1 -Exactly -Scope It -ParameterFilter {
            $ResourceGroupName -eq $env.sharedResourceGroup -and
            $ClusterName -eq $env.sharedClusterName -and
            $PoolName -eq $env.sharedPoolName -and $SubscriptionId -eq $env.SubscriptionId
        }
    }

    It 'Creates a shared parameter group for <SelectedTest> in <Mode> mode' -TestCases @(
        @{ SelectedTest = 'Get-AzHorizonDbParameterGroup'; Mode = 'record'; EnvFile = 'env.json' }
        @{ SelectedTest = 'Update-AzHorizonDbParameterGroup'; Mode = 'record'; EnvFile = 'env.json' }
        @{ SelectedTest = 'Get-AzHorizonDbParameterGroup'; Mode = 'live'; EnvFile = 'localEnv.json' }
    ) {
        param($SelectedTest, $Mode, $EnvFile)
        $TestName = @($SelectedTest)
        $TestMode = $Mode

        setupEnv

        Assert-MockCalled New-AzHorizonDbParameterGroup -Times 1 -Exactly -Scope It -ParameterFilter {
            $Name -eq $env.sharedParameterGroupName -and $ResourceGroupName -eq $env.sharedResourceGroup -and
            $SubscriptionId -eq $env.SubscriptionId -and $Location -eq $env.location -and
            $PostgreSqlVersion -eq '17' -and $Tag.environment -eq 'production' -and
            @($Parameter).Count -eq 4 -and
            @($Parameter | Where-Object { $_.Name -eq 'work_mem' -and $_.Value -eq '8192' }).Count -eq 1
        }
        $saved = Get-Content -LiteralPath (Join-Path $fixtureDirectory $EnvFile) -Raw | ConvertFrom-Json
        $saved.sharedParameterGroupName | Should -Be $env.sharedParameterGroupName
        $saved.sharedParameterGroupName | Should -Not -Be $saved.newParameterGroupName
        Assert-MockCalled New-AzResourceGroup -Times 0 -Exactly -Scope It -ParameterFilter { $Name -eq $env.clusterResourceGroup }
    }

    It 'Cleans up when shared parameter group creation fails' {
        $TestName = @('Get-AzHorizonDbParameterGroup')
        Mock New-AzHorizonDbParameterGroup { throw 'Parameter group creation failed' }

        { setupEnv } | Should -Throw 'Parameter group creation failed'
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.sharedResourceGroup }
    }

    It 'Rejects an invalid shared parameter group result' {
        $TestName = @('Update-AzHorizonDbParameterGroup')
        Mock New-AzHorizonDbParameterGroup { @{ Name = $Name } }

        { setupEnv } | Should -Throw 'expected name and resource ID'
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.sharedResourceGroup }
    }

    It 'Reuses cached fixture names for recording' {
        $UsePreviousConfigForRecord = $true
        $env.sharedResourceGroup = 'cached-fixture-rg'
        $env.sharedClusterName = 'cached-fixture-cluster'
        $env.sharedPoolName = 'cached-fixture-pool'

        setupEnv

        Assert-MockCalled New-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq 'cached-fixture-rg' }
        Assert-MockCalled New-AzDeployment -Times 1 -Exactly -Scope It -ParameterFilter {
            $TemplateParameterObject.clusterName.value -eq 'cached-fixture-cluster' -and
            $TemplateParameterObject.poolName.value -eq 'cached-fixture-pool'
        }
    }

    It 'Propagates deployment failures and cleans up the group only once' {
        Mock New-AzDeployment { throw 'Deployment failed' }

        { setupEnv } | Should -Throw 'Deployment failed'
        cleanupEnv
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter {
            $Name -eq $env.sharedResourceGroup -and $SubscriptionId -eq $env.SubscriptionId -and -not $Confirm
        }
    }

    It 'Rejects an unsuccessful deployment result' {
        Mock New-AzDeployment { @{ ProvisioningState = 'Failed' } }

        { setupEnv } | Should -Throw 'deployment did not succeed'
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It
    }

    It 'Does not delete resources when group creation fails' {
        Mock New-AzResourceGroup { throw 'Group creation failed' }

        { setupEnv } | Should -Throw 'Group creation failed'
        cleanupEnv

        Assert-MockCalled New-AzDeployment -Times 0 -Exactly -Scope It
        Assert-MockCalled Remove-AzResourceGroup -Times 0 -Exactly -Scope It
    }

    It 'Surfaces cleanup failures so deletion can be retried' {
        setupEnv
        Mock Remove-AzResourceGroup { throw 'Cleanup failed' }

        { cleanupEnv } | Should -Throw 'Cleanup failed'
        Mock Remove-AzResourceGroup {}
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 2 -Exactly -Scope It
    }

    It 'Cleans up when node discovery fails' {
        Mock Get-AzHorizonDbNode { throw 'Node discovery failed' }

        { setupEnv } | Should -Throw 'Node discovery failed'
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It
    }

    It 'Rejects invalid shared pool nodes: <Scenario>' -TestCases @(
        @{ Scenario = 'no nodes'; Nodes = @() }
        @{ Scenario = 'multiple nodes'; Nodes = @(@{ Name = 'node-1'; Id = 'id-1' }, @{ Name = 'node-2'; Id = 'id-2' }) }
        @{ Scenario = 'missing name'; Nodes = @(@{ Id = 'node-id' }) }
        @{ Scenario = 'missing resource ID'; Nodes = @(@{ Name = 'node-1' }) }
    ) {
        param($Scenario, $Nodes)
        $script:discoveredNodes = $Nodes
        Mock Get-AzHorizonDbNode { $script:discoveredNodes }

        { setupEnv } | Should -Throw 'Expected the shared pool to contain exactly one node'
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It
    }

    It 'Does not provision or delete resources during playback' {
        $TestMode = 'playback'

        setupEnv
        cleanupEnv

        Assert-MockCalled New-AzResourceGroup -Times 0 -Exactly -Scope It
        Assert-MockCalled New-AzDeployment -Times 0 -Exactly -Scope It
        Assert-MockCalled Remove-AzResourceGroup -Times 0 -Exactly -Scope It
        Assert-MockCalled Get-AzHorizonDbNode -Times 0 -Exactly -Scope It
        Assert-MockCalled New-AzHorizonDbCluster -Times 0 -Exactly -Scope It
        Assert-MockCalled New-AzHorizonDbParameterGroup -Times 0 -Exactly -Scope It
        Test-Path -LiteralPath (Join-Path $fixtureDirectory 'env.json') | Should -Be $false
    }

    It 'Keeps creation resources until suite cleanup for <Scenario>' -TestCases @(
        @{ Scenario = 'New-cluster'; SelectedTests = @('New-AzHorizonDbCluster'); PoolClusterCount = 0; FirewallDeploymentCount = 0 }
        @{ Scenario = 'New-parameter-group'; SelectedTests = @('New-AzHorizonDbParameterGroup'); PoolClusterCount = 0; FirewallDeploymentCount = 0 }
        @{ Scenario = 'New-pool'; SelectedTests = @('New-AzHorizonDbPool'); PoolClusterCount = 1; FirewallDeploymentCount = 0 }
        @{ Scenario = 'New-firewall'; SelectedTests = @('New-AzHorizonDbFirewallRule'); PoolClusterCount = 0; FirewallDeploymentCount = 1 }
        @{ Scenario = 'New-authentication'; SelectedTests = @('New-AzHorizonDbMicrosoftEntraAuthentication'); PoolClusterCount = 0; FirewallDeploymentCount = 0; AuthenticationClusterCount = 1 }
        @{ Scenario = 'New-password-authentication'; SelectedTests = @('New-AzHorizonDbPasswordAuthentication'); PoolClusterCount = 0; FirewallDeploymentCount = 0; AuthenticationClusterCount = 1 }
        @{ Scenario = 'both authentication tests'; SelectedTests = @('New-AzHorizonDbMicrosoftEntraAuthentication', 'New-AzHorizonDbPasswordAuthentication'); PoolClusterCount = 0; FirewallDeploymentCount = 0; AuthenticationClusterCount = 1 }
        @{ Scenario = 'New-authentication and firewall'; SelectedTests = @('New-AzHorizonDbMicrosoftEntraAuthentication', 'New-AzHorizonDbFirewallRule'); PoolClusterCount = 0; FirewallDeploymentCount = 1 }
        @{ Scenario = 'all creation tests'; SelectedTests = @('New-AzHorizonDbCluster', 'New-AzHorizonDbPool', 'New-AzHorizonDbFirewallRule', 'New-AzHorizonDbMicrosoftEntraAuthentication', 'New-AzHorizonDbPasswordAuthentication'); PoolClusterCount = 1; FirewallDeploymentCount = 1 }
        @{ Scenario = 'all tests'; SelectedTests = $null; PoolClusterCount = 1; FirewallDeploymentCount = 1 }
    ) {
        param($SelectedTests, $PoolClusterCount, $FirewallDeploymentCount, $AuthenticationClusterCount = 0)
        $TestName = $SelectedTests

        setupEnv

        Assert-MockCalled New-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter {
            $Name -eq $env.clusterResourceGroup -and $SubscriptionId -eq $env.SubscriptionId
        }
        Assert-MockCalled Remove-AzResourceGroup -Times 0 -Exactly -Scope It
        Assert-MockCalled New-AzHorizonDbParameterGroup -Times 0 -Exactly -Scope It -ParameterFilter {
            $ResourceGroupName -eq $env.clusterResourceGroup
        }
        $saved = Get-Content -LiteralPath (Join-Path $fixtureDirectory 'env.json') -Raw | ConvertFrom-Json
        $saved.newClusterName | Should -Not -BeNullOrEmpty
        $saved.newClusterName | Should -Not -Be $saved.clusterName
        $saved.newClusterName | Should -Not -Be $saved.sharedClusterName
        $saved.newClusterPoolName | Should -Not -BeNullOrEmpty
        $saved.newClusterPoolName | Should -Not -Be $saved.clusterName
        $saved.newClusterPoolName | Should -Not -Be $saved.newClusterName
        $saved.newClusterPoolName | Should -Not -Be $saved.sharedClusterName
        $saved.newPoolName | Should -Not -BeNullOrEmpty
        $saved.newPoolName | Should -Not -Be $saved.sharedPoolName
        Assert-MockCalled New-AzHorizonDbCluster -Times $PoolClusterCount -Exactly -Scope It -ParameterFilter {
            $ResourceGroupName -eq $env.clusterResourceGroup -and $Name -eq $env.newClusterPoolName -and
            $SubscriptionId -eq $env.SubscriptionId -and $Location -eq $env.location -and
            $PostgreSqlVersion -eq '17' -and $BackupGeoRedundancy -eq 'Disabled' -and $NetworkPublicAccess -eq 'Disabled'
        }
        Assert-MockCalled New-AzHorizonDbCluster -Times 0 -Exactly -Scope It -ParameterFilter { $Name -eq $env.clusterName }
        Assert-MockCalled New-AzHorizonDbCluster -Times $AuthenticationClusterCount -Exactly -Scope It -ParameterFilter {
            $ResourceGroupName -eq $env.clusterResourceGroup -and $Name -eq $env.newClusterName -and
            $SubscriptionId -eq $env.SubscriptionId -and $Location -eq $env.location -and
            $PostgreSqlVersion -eq '17' -and $BackupGeoRedundancy -eq 'Disabled' -and $NetworkPublicAccess -eq 'Disabled'
        }
        Assert-MockCalled New-AzDeployment -Times $FirewallDeploymentCount -Exactly -Scope It -ParameterFilter {
            $ResourceGroupName -eq $env.clusterResourceGroup -and $SubscriptionId -eq $env.SubscriptionId -and
            $Mode -eq 'Incremental' -and
            $TemplateParameterObject.clusterName.value -eq $env.newClusterName -and
            $TemplateParameterObject.poolName.value -eq $env.newPoolName
        }

        cleanupEnv
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter {
            $Name -eq $env.sharedResourceGroup -and $SubscriptionId -eq $env.SubscriptionId
        }
        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter {
            $Name -eq $env.clusterResourceGroup -and $SubscriptionId -eq $env.SubscriptionId -and -not $Confirm
        }
    }

    It 'Does not delete a creation group that could not be created' {
        $TestName = @('New-AzHorizonDbPool')
        Mock New-AzResourceGroup {
            if ($Name -eq $env.clusterResourceGroup) {
                throw 'Creation group failed'
            }
        }

        { setupEnv } | Should -Throw 'Creation group failed'
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.sharedResourceGroup }
        Assert-MockCalled Remove-AzResourceGroup -Times 0 -Exactly -Scope It -ParameterFilter { $Name -eq $env.clusterResourceGroup }
    }

    It 'Cleans up when the New-pool prerequisite cluster fails' {
        $TestName = @('New-AzHorizonDbPool')
        Mock New-AzHorizonDbCluster { @{ ProvisioningState = 'Failed' } }

        { setupEnv } | Should -Throw 'New-pool test cluster did not succeed'
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.clusterResourceGroup }
        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.sharedResourceGroup }
    }

    It 'Cleans up when the <AuthenticationTest> prerequisite cluster fails' -TestCases @(
        @{ AuthenticationTest = 'New-AzHorizonDbMicrosoftEntraAuthentication' }
        @{ AuthenticationTest = 'New-AzHorizonDbPasswordAuthentication' }
    ) {
        param($AuthenticationTest)
        $TestName = @($AuthenticationTest)
        Mock New-AzHorizonDbCluster { @{ ProvisioningState = 'Failed' } }

        { setupEnv } | Should -Throw 'New-authentication test cluster did not succeed'
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.clusterResourceGroup }
        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.sharedResourceGroup }
    }

    It 'Cleans up when the New-firewall prerequisite deployment fails' {
        $TestName = @('New-AzHorizonDbFirewallRule')
        Mock New-AzDeployment { @{ ProvisioningState = 'Failed' } } -ParameterFilter {
            $ResourceGroupName -eq $env.clusterResourceGroup
        }

        { setupEnv } | Should -Throw 'New-firewall test fixture deployment did not succeed'
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.clusterResourceGroup }
        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.sharedResourceGroup }
    }

    It 'Retries failed creation cleanup without deleting the shared group again' {
        $TestName = @('New-AzHorizonDbPool')
        setupEnv
        Mock Remove-AzResourceGroup {
            if ($Name -eq $env.clusterResourceGroup) {
                throw 'Creation cleanup failed'
            }
        }

        { cleanupEnv } | Should -Throw 'Creation cleanup failed'
        Mock Remove-AzResourceGroup {}
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.sharedResourceGroup }
        Assert-MockCalled Remove-AzResourceGroup -Times 2 -Exactly -Scope It -ParameterFilter { $Name -eq $env.clusterResourceGroup }
    }

    It 'Cleans up creation resources even when shared cleanup fails' {
        $TestName = @('New-AzHorizonDbPool')
        setupEnv
        Mock Remove-AzResourceGroup {
            if ($Name -eq $env.sharedResourceGroup) {
                throw 'Shared cleanup failed'
            }
        }

        { cleanupEnv } | Should -Throw 'Shared cleanup failed'
        Mock Remove-AzResourceGroup {}
        cleanupEnv

        Assert-MockCalled Remove-AzResourceGroup -Times 2 -Exactly -Scope It -ParameterFilter { $Name -eq $env.sharedResourceGroup }
        Assert-MockCalled Remove-AzResourceGroup -Times 1 -Exactly -Scope It -ParameterFilter { $Name -eq $env.clusterResourceGroup }
    }
}

Describe 'HorizonDbCreationTests' {
    BeforeEach {
        function New-AzHorizonDbCluster {
            [CmdletBinding()]
            param($ResourceGroupName, $Name, $SubscriptionId, $Location, $PostgreSqlVersion, $BackupGeoRedundancy, $NetworkPublicAccess)
        }
        function Remove-AzHorizonDbCluster {
            [CmdletBinding(SupportsShouldProcess)]
            param($ResourceGroupName, $Name, $SubscriptionId, [switch]$PassThru)
        }
        function Get-AzHorizonDbCluster {
            [CmdletBinding()]
            param($ResourceGroupName, $SubscriptionId)
        }
        function New-AzHorizonDbPool {
            [CmdletBinding()]
            param($ResourceGroupName, $ClusterName, $Name, $SubscriptionId, $JsonString)
        }
        function New-AzHorizonDbFirewallRule {
            [CmdletBinding()]
            param($ResourceGroupName, $ClusterName, $PoolName, $Name, $SubscriptionId, $StartIPAddress, $EndIPAddress, $Description)
        }
        function Remove-AzHorizonDbFirewallRule {
            [CmdletBinding(SupportsShouldProcess)]
            param($ResourceGroupName, $ClusterName, $PoolName, $Name, $SubscriptionId, [switch]$PassThru)
        }
        function Get-AzHorizonDbFirewallRule {
            [CmdletBinding()]
            param($ResourceGroupName, $ClusterName, $PoolName, $SubscriptionId)
        }
        function New-AzHorizonDbMicrosoftEntraAuthentication {
            [CmdletBinding()]
            param($ResourceGroupName, $ClusterName, $SubscriptionId, $State)
        }
        function New-AzHorizonDbPasswordAuthentication {
            [CmdletBinding()]
            param($ResourceGroupName, $ClusterName, $SubscriptionId, $State, $AdministratorLogin, [System.Security.SecureString]$AdministratorLoginPassword)
        }
        $TestMode = 'playback'
        $UsePreviousConfigForRecord = $false
        . (Join-Path $PSScriptRoot 'utils.ps1')
        $env = @{
            clusterResourceGroup = 'creation-rg'
            clusterName = 'standalone-cluster'
            newClusterName = 'firewall-cluster'
            newClusterPoolName = 'pool-cluster'
            newPoolName = 'new-pool'
            SubscriptionId = '00000000-0000-0000-0000-000000000001'
            location = 'indiasouthcentral'
        }
        Mock New-AzHorizonDbCluster {
            @{
                Name = $Name
                ResourceGroupName = $ResourceGroupName
                Location = $Location
                PostgreSqlVersion = $PostgreSqlVersion
                BackupGeoRedundancy = $BackupGeoRedundancy
                NetworkPublicAccess = $NetworkPublicAccess
                ProvisioningState = 'Succeeded'
            }
        }
        Mock Remove-AzHorizonDbCluster { $true }
        Mock Get-AzHorizonDbCluster { @{ Name = 'unrelated-cluster' } }
        Mock New-AzHorizonDbPool {
            $properties = ($JsonString | ConvertFrom-Json).properties
            @{
                Name = $Name
                ResourceGroupName = $ResourceGroupName
                ComputeModelType = $properties.computeModel.type
                ComputeModelComputeProcessor = $properties.computeModel.computeProcessor
                ComputeModelComputeGeneration = $properties.computeModel.computeGeneration
                ComputeModelVCore = $properties.computeModel.vCores
                NodeCount = $properties.nodeCount
                HighAvailabilityMode = $properties.highAvailability.mode
                State = 'Ready'
                ProvisioningState = 'Succeeded'
            }
        }
        Mock New-AzHorizonDbFirewallRule {
            @{
                Name = $Name
                ResourceGroupName = $ResourceGroupName
                Id = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.HorizonDb/clusters/$ClusterName/pools/$PoolName/firewallRules/$Name"
                Type = 'Microsoft.HorizonDb/clusters/pools/firewallRules'
                StartIPAddress = $StartIPAddress
                EndIPAddress = $EndIPAddress
                Description = 'CustomerFirewallRule'
                ProvisioningState = 'Succeeded'
            }
        }
        Mock Remove-AzHorizonDbFirewallRule { $true }
        Mock Get-AzHorizonDbFirewallRule { @{ Name = 'unrelated-rule' } }
        Mock New-AzHorizonDbMicrosoftEntraAuthentication {
            @{
                Name = 'microsoftEntra'
                ResourceGroupName = $ResourceGroupName
                Id = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.HorizonDb/clusters/$ClusterName/authentications/microsoftEntra"
                Type = 'Microsoft.HorizonDb/clusters/authentications'
                State = $State
                ProvisioningState = 'Succeeded'
            }
        }
        Mock New-AzHorizonDbPasswordAuthentication {
            @{
                Name = 'passwordMethod'
                ResourceGroupName = $ResourceGroupName
                Id = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.HorizonDb/clusters/$ClusterName/authentications/passwordMethod"
                Type = 'Microsoft.HorizonDb/clusters/authentications'
                State = $State
                AdministratorLogin = $AdministratorLogin
            }
        }
    }

    It 'Uses isolated resources for <Cmdlet>' -TestCases @(
        @{ Cmdlet = 'New-AzHorizonDbCluster'; TestCase = 'CreateExpanded'; ExpectedCluster = 'standalone-cluster' }
        @{ Cmdlet = 'New-AzHorizonDbCluster'; TestCase = 'Delete'; ExpectedCluster = 'standalone-cluster-delete' }
        @{ Cmdlet = 'New-AzHorizonDbPool'; TestCase = 'CreateViaJsonString'; ExpectedCluster = 'pool-cluster' }
        @{ Cmdlet = 'New-AzHorizonDbFirewallRule'; TestCase = 'CreateExpanded'; ExpectedCluster = 'firewall-cluster' }
        @{ Cmdlet = 'New-AzHorizonDbFirewallRule'; TestCase = 'Delete'; ExpectedCluster = 'firewall-cluster' }
        @{ Cmdlet = 'New-AzHorizonDbMicrosoftEntraAuthentication'; TestCase = 'CreateExpanded'; ExpectedCluster = 'firewall-cluster' }
        @{ Cmdlet = 'New-AzHorizonDbPasswordAuthentication'; TestCase = 'CreateExpanded'; ExpectedCluster = 'firewall-cluster' }
    ) {
        param($Cmdlet, $TestCase, $ExpectedCluster)
        # Execute the integration test body without its HTTP-recording bootstrap.
        $tokens = $null
        $parseErrors = $null
        $ast = [System.Management.Automation.Language.Parser]::ParseFile((Join-Path $PSScriptRoot "$Cmdlet.Tests.ps1"), [ref]$tokens, [ref]$parseErrors)
        $test = $ast.Find({
            param($node)
            $node -is [System.Management.Automation.Language.CommandAst] -and
            $node.GetCommandName() -eq 'It' -and $node.CommandElements[1].Value -eq $TestCase
        }, $true)
        & $test.CommandElements[-1].ScriptBlock.GetScriptBlock()

        if ($Cmdlet -eq 'New-AzHorizonDbCluster') {
            Assert-MockCalled New-AzHorizonDbCluster -Times 1 -Exactly -Scope It -ParameterFilter {
                $Name -eq $ExpectedCluster -and $ResourceGroupName -eq $env.clusterResourceGroup
            }
            if ($TestCase -eq 'Delete') {
                Assert-MockCalled Remove-AzHorizonDbCluster -Times 1 -Exactly -Scope It -ParameterFilter {
                    $Name -eq $ExpectedCluster -and $ResourceGroupName -eq $env.clusterResourceGroup -and
                    $SubscriptionId -eq $env.SubscriptionId -and $PassThru -and -not $Confirm
                }
                Assert-MockCalled Get-AzHorizonDbCluster -Times 1 -Exactly -Scope It -ParameterFilter {
                    $ResourceGroupName -eq $env.clusterResourceGroup -and $SubscriptionId -eq $env.SubscriptionId
                }
            }
        } elseif ($Cmdlet -eq 'New-AzHorizonDbPool') {
            Assert-MockCalled New-AzHorizonDbPool -Times 1 -Exactly -Scope It -ParameterFilter {
                $ClusterName -eq $ExpectedCluster -and $Name -eq $env.newPoolName -and
                $ResourceGroupName -eq $env.clusterResourceGroup
            }
            Assert-MockCalled New-AzHorizonDbCluster -Times 0 -Exactly -Scope It
        } elseif ($Cmdlet -eq 'New-AzHorizonDbFirewallRule') {
            Assert-MockCalled New-AzHorizonDbFirewallRule -Times 1 -Exactly -Scope It -ParameterFilter {
                $ClusterName -eq $ExpectedCluster -and $PoolName -eq $env.newPoolName -and
                $ResourceGroupName -eq $env.clusterResourceGroup -and
                $StartIPAddress -eq '10.0.0.1' -and $EndIPAddress -eq '10.0.0.254' -and
                $Description -eq 'Allow access from the corporate network'
            }
            if ($TestCase -eq 'Delete') {
                Assert-MockCalled Remove-AzHorizonDbFirewallRule -Times 1 -Exactly -Scope It -ParameterFilter {
                    $ClusterName -eq $ExpectedCluster -and $PoolName -eq $env.newPoolName -and
                    $ResourceGroupName -eq $env.clusterResourceGroup -and $SubscriptionId -eq $env.SubscriptionId -and
                    $Name -eq 'example-firewall-rule-delete-01' -and $PassThru -and -not $Confirm
                }
                Assert-MockCalled Get-AzHorizonDbFirewallRule -Times 1 -Exactly -Scope It -ParameterFilter {
                    $ClusterName -eq $ExpectedCluster -and $PoolName -eq $env.newPoolName -and
                    $ResourceGroupName -eq $env.clusterResourceGroup -and $SubscriptionId -eq $env.SubscriptionId
                }
            }
        } elseif ($Cmdlet -eq 'New-AzHorizonDbMicrosoftEntraAuthentication') {
            Assert-MockCalled New-AzHorizonDbMicrosoftEntraAuthentication -Times 1 -Exactly -Scope It -ParameterFilter {
                $ClusterName -eq $ExpectedCluster -and $ResourceGroupName -eq $env.clusterResourceGroup -and
                $SubscriptionId -eq $env.SubscriptionId -and $State -eq 'Enabled'
            }
        } else {
            Assert-MockCalled New-AzHorizonDbPasswordAuthentication -Times 1 -Exactly -Scope It -ParameterFilter {
                $ClusterName -eq $ExpectedCluster -and $ResourceGroupName -eq $env.clusterResourceGroup -and
                $SubscriptionId -eq $env.SubscriptionId -and $State -eq 'Enabled' -and
                $AdministratorLogin -eq 'adminlogin1' -and $AdministratorLoginPassword -is [System.Security.SecureString]
            }
        }
    }

    It 'Redacts password recordings after <Outcome>' -TestCases @(
        @{ Outcome = 'success'; Fails = $false }
        @{ Outcome = 'failure'; Fails = $true }
    ) {
        param($Fails)
        $TestMode = 'record'
        $TestRecordingFile = Join-Path $TestDrive 'password.Recording.json'
        $recording = @{
            Create = @{
                Request = @{
                    RequestUri = 'https://management.azure.com/clusters/test/authentications/passwordMethod?api-version=2026-10-01-preview'
                    Content = '{"properties":{"state":"Enabled","administratorLogin":"adminlogin1","administratorLoginPassword":"test-only-value"}}'
                }
                Response = @{ Content = '{"properties":{"state":"Enabled","administratorLogin":"adminlogin1","provisioningState":"Succeeded"}}' }
            }
        }
        Set-Content -LiteralPath $TestRecordingFile -Value ($recording | ConvertTo-Json -Depth 10)
        $tokens = $null
        $parseErrors = $null
        $ast = [System.Management.Automation.Language.Parser]::ParseFile((Join-Path $PSScriptRoot 'New-AzHorizonDbPasswordAuthentication.Tests.ps1'), [ref]$tokens, [ref]$parseErrors)
        $test = $ast.Find({
            param($node)
            $node -is [System.Management.Automation.Language.CommandAst] -and
            $node.GetCommandName() -eq 'It' -and $node.CommandElements[1].Value -eq 'CreateExpanded'
        }, $true)
        if ($Fails) {
            Mock New-AzHorizonDbPasswordAuthentication { throw 'Password authentication failed' }
            { & $test.CommandElements[-1].ScriptBlock.GetScriptBlock() } | Should -Throw 'Password authentication failed'
        } else {
            & $test.CommandElements[-1].ScriptBlock.GetScriptBlock()
        }

        $saved = Get-Content -LiteralPath $TestRecordingFile -Raw | ConvertFrom-Json
        $body = $saved.Create.Request.Content | ConvertFrom-Json
        $body.properties.administratorLoginPassword | Should -Be '[REDACTED]'
        $body.properties.state | Should -Be 'Enabled'
        $body.properties.administratorLogin | Should -Be 'adminlogin1'
        $saved.Create.Response.Content | Should -Be $recording.Create.Response.Content
    }
}

Describe 'HorizonDbParameterGroupTests' {
    BeforeEach {
        function New-AzHorizonDbParameterGroup {
            [CmdletBinding()]
            param($ResourceGroupName, $Name, $SubscriptionId, $Location, $PostgreSqlVersion, $Tag, $Description, $Parameter)
        }
        function Get-AzHorizonDbParameterGroup {
            [CmdletBinding()]
            param($ResourceGroupName, $Name, $SubscriptionId)
        }
        function Update-AzHorizonDbParameterGroup {
            [CmdletBinding(SupportsShouldProcess)]
            param($ResourceGroupName, $Name, $SubscriptionId, $Parameter)
        }
        function Remove-AzHorizonDbParameterGroup {
            [CmdletBinding(SupportsShouldProcess)]
            param($ResourceGroupName, $Name, $SubscriptionId, [switch]$PassThru)
        }
        $TestMode = 'playback'
        $UsePreviousConfigForRecord = $false
        . (Join-Path $PSScriptRoot 'utils.ps1')
        $env = @{
            clusterResourceGroup = 'creation-rg'
            sharedResourceGroup = 'shared-rg'
            newParameterGroupName = 'production-parameters'
            sharedParameterGroupName = 'shared-parameters'
            SubscriptionId = '00000000-0000-0000-0000-000000000001'
            location = 'indiasouthcentral'
        }
        $script:parameterGroups = @{
            'shared-parameters' = @{
                Name = $env.sharedParameterGroupName
                ResourceGroupName = $env.sharedResourceGroup
                Id = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.sharedResourceGroup)/providers/Microsoft.HorizonDb/parameterGroups/$($env.sharedParameterGroupName)"
                PostgreSqlVersion = '17'
                Parameter = @(Get-HorizonDbTestParameter)
            }
        }
        Mock New-AzHorizonDbParameterGroup {
            $result = @{
                Name = $Name
                ResourceGroupName = $ResourceGroupName
                Id = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.HorizonDb/parameterGroups/$Name"
                Type = 'Microsoft.HorizonDb/parameterGroups'
                Location = $Location
                PostgreSqlVersion = $PostgreSqlVersion
                Tag = $Tag
                Description = $Description
                Parameter = @($Parameter) + @(@{ Name = 'allow_alter_system'; Value = 'on' })
            }
            $script:parameterGroups[$Name] = $result
            $result
        }
        Mock Get-AzHorizonDbParameterGroup {
            if ($Name) {
                $script:parameterGroups[$Name]
            } else {
                $script:parameterGroups.Values | Where-Object { $_.ResourceGroupName -eq $ResourceGroupName }
            }
        }
        Mock Update-AzHorizonDbParameterGroup {
            foreach ($change in $Parameter) {
                foreach ($existing in $script:parameterGroups[$Name].Parameter) {
                    if ($existing.Name -eq $change.Name) {
                        $existing.Value = $change.Value
                    }
                }
            }
            $script:parameterGroups[$Name]
        }
        Mock Remove-AzHorizonDbParameterGroup {
            $script:parameterGroups.Remove($Name)
            $true
        }
    }

    It 'Runs <Cmdlet> <TestCase> using the correct fixture' -TestCases @(
        @{ Cmdlet = 'New-AzHorizonDbParameterGroup'; TestCase = 'CreateExpanded' }
        @{ Cmdlet = 'New-AzHorizonDbParameterGroup'; TestCase = 'Delete' }
        @{ Cmdlet = 'Get-AzHorizonDbParameterGroup'; TestCase = 'List' }
        @{ Cmdlet = 'Get-AzHorizonDbParameterGroup'; TestCase = 'Get' }
        @{ Cmdlet = 'Update-AzHorizonDbParameterGroup'; TestCase = 'UpdateExpanded' }
    ) {
        param($Cmdlet, $TestCase)
        $tokens = $null
        $parseErrors = $null
        $ast = [System.Management.Automation.Language.Parser]::ParseFile((Join-Path $PSScriptRoot "$Cmdlet.Tests.ps1"), [ref]$tokens, [ref]$parseErrors)
        $test = $ast.Find({
            param($node)
            $node -is [System.Management.Automation.Language.CommandAst] -and
            $node.GetCommandName() -eq 'It' -and $node.CommandElements[1].Value -eq $TestCase
        }, $true)
        & $test.CommandElements[-1].ScriptBlock.GetScriptBlock()

        if ($Cmdlet -eq 'New-AzHorizonDbParameterGroup') {
            Assert-MockCalled New-AzHorizonDbParameterGroup -Times 1 -Exactly -Scope It -ParameterFilter {
                $ResourceGroupName -eq $env.clusterResourceGroup -and $SubscriptionId -eq $env.SubscriptionId -and
                $Name -ne $env.sharedParameterGroupName -and $PostgreSqlVersion -eq '17' -and @($Parameter).Count -eq 4
            }
            ($script:parameterGroups[$env.sharedParameterGroupName].Parameter | Where-Object { $_.Name -eq 'work_mem' }).Value | Should -Be '8192'
            if ($TestCase -eq 'Delete') {
                Assert-MockCalled Remove-AzHorizonDbParameterGroup -Times 1 -Exactly -Scope It -ParameterFilter {
                    $Name -eq ($env.newParameterGroupName + '-delete') -and
                    $ResourceGroupName -eq $env.clusterResourceGroup -and $PassThru -and -not $Confirm
                }
                $script:parameterGroups.ContainsKey($env.newParameterGroupName + '-delete') | Should -Be $false
            }
        } else {
            Assert-MockCalled Get-AzHorizonDbParameterGroup -Times 1 -Exactly -Scope It -ParameterFilter {
                $ResourceGroupName -eq $env.sharedResourceGroup -and $SubscriptionId -eq $env.SubscriptionId
            }
            Assert-MockCalled New-AzHorizonDbParameterGroup -Times 0 -Exactly -Scope It
            Assert-MockCalled Remove-AzHorizonDbParameterGroup -Times 0 -Exactly -Scope It
            if ($Cmdlet -eq 'Update-AzHorizonDbParameterGroup') {
                Assert-MockCalled Update-AzHorizonDbParameterGroup -Times 1 -Exactly -Scope It -ParameterFilter {
                    $Name -eq $env.sharedParameterGroupName -and $ResourceGroupName -eq $env.sharedResourceGroup -and
                    @($Parameter).Count -eq 1 -and $Parameter[0].Name -eq 'work_mem' -and
                    $Parameter[0].Value -eq '16384' -and -not $Confirm
                }
            }
        }
    }
}
