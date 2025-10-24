if (($null -eq $TestName) -or ($TestName -contains 'AzDatabricksWorkspace')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzDatabricksWorkspace.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDatabricksWorkspace' {
    It 'CreateExpanded' {
        {
            $config = New-AzDatabricksWorkspace -Name $env.workSpaceName2 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku premium
            $config.Name | Should -Be $env.workSpaceName2
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzDatabricksWorkspace -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzDatabricksWorkspace
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDatabricksWorkspace -Name $env.workSpaceName2 -ResourceGroupName $env.resourceGroup
            $config.Name | Should -Be $env.workSpaceName2
        } | Should -Not -Throw
    }

    It 'OutboundNetworkDependenciesEndpointList' {
        {
            $config = Get-AzDatabricksOutboundNetworkDependenciesEndpoint -WorkspaceName $env.workSpaceName1 -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzDatabricksWorkspace -Name $env.workSpaceName2 -ResourceGroupName $env.resourceGroup -Tag @{"key" = "value" }
            $config.Name | Should -Be $env.workSpaceName2
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzDatabricksWorkspace -Name $env.workSpaceName2 -ResourceGroupName $env.resourceGroup
            $config = Update-AzDatabricksWorkspace -InputObject $config -Tag @{"key" = "value" }
            $config.Name | Should -Be $env.workSpaceName2
        } | Should -Not -Throw
    }

    It 'UpdateRequiredNsgRule-EnableNoPublicIP-PublicNetworkAccess' {
        {
            $config = Update-AzDatabricksWorkspace -Name $env.workSpaceName1 -ResourceGroupName $env.resourceGroup -RequiredNsgRule 'AllRules' -EnableNoPublicIP:$false -PublicNetworkAccess 'Enabled' -Tag @{"key" = "value" }
            $config.RequiredNsgRule | Should -Be 'AllRules'
            $config.EnableNoPublicIP | Should -Be 'false'
            $config.PublicNetworkAccess | Should -Be 'Enabled'

            $config = Update-AzDatabricksWorkspace -Name $env.workSpaceName1 -ResourceGroupName $env.resourceGroup -RequiredNsgRule 'NoAzureDatabricksRules' -EnableNoPublicIP:$true -PublicNetworkAccess 'Disabled'
            $config.RequiredNsgRule | Should -Be 'NoAzureDatabricksRules'
            $config.EnableNoPublicIP | Should -Be 'true'
            $config.PublicNetworkAccess | Should -Be 'Disabled'
        }
    }

    It 'Delete' {
        { 
            Remove-AzDatabricksWorkspace -Name $env.workSpaceName2 -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }
}