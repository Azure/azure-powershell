if (($null -eq $TestName) -or ($TestName -contains 'AzDatabricksAccessConnector')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'AzDatabricksAccessConnector.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzDatabricksAccessConnector' {
    It 'CreateExpanded' {
        {
            $config = New-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorName1 -Location $env.location -IdentityType 'SystemAssigned'
            $config.Name | Should -Be $env.accessConnectorName1
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            $config = Get-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorName1
            $config.Name | Should -Be $env.accessConnectorName1
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzDatabricksAccessConnector
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        { 
            $config = Update-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorName1 -Tag @{'key' = 'value' }
            $config.Name | Should -Be $env.accessConnectorName1
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorName1
            $config = Update-AzDatabricksAccessConnector -InputObject $config -Tag @{'key' = 'value' }
            $config.Name | Should -Be $env.accessConnectorName1
        } | Should -Not -Throw
    }

    It 'Delete' {
        { 
            Remove-AzDatabricksAccessConnector -ResourceGroupName $env.resourceGroup -Name $env.accessConnectorName1 
        } | Should -Not -Throw
    }
}