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

        $fixtureDirectory = Join-Path $TestDrive ([guid]::NewGuid().ToString())
        $null = New-Item -ItemType Directory -Path $fixtureDirectory
        Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'utils.ps1') -Destination $fixtureDirectory
        Copy-Item -LiteralPath (Join-Path $PSScriptRoot 'prereqs.json') -Destination $fixtureDirectory
        $TestMode = 'record'
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
        Assert-MockCalled Get-AzHorizonDbNode -Times 1 -Exactly -Scope It -ParameterFilter {
            $ResourceGroupName -eq $env.sharedResourceGroup -and
            $ClusterName -eq $env.sharedClusterName -and
            $PoolName -eq $env.sharedPoolName -and $SubscriptionId -eq $env.SubscriptionId
        }
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
        Test-Path -LiteralPath (Join-Path $fixtureDirectory 'env.json') | Should -Be $false
    }
}
