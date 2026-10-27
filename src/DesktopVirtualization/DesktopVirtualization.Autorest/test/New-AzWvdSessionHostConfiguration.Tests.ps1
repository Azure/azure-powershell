if (($null -eq $TestName) -or ($TestName -contains 'New-AzWvdSessionHostConfiguration')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWvdSessionHostConfiguration.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWvdSessionHostConfiguration' {
    BeforeAll{
        $managedHostPoolName = $env.HostPool + '-shc-create-managed'
        $ephemeralHostPoolName = $env.HostPool + '-shc-create-ephemeral'
        $configurationHostPoolNames = @($managedHostPoolName, $ephemeralHostPoolName)
        foreach ($hostPoolName in $configurationHostPoolNames) {
            $hostPool = New-TestSessionHostConfigurationHostPool -TestEnvironment $env -Name $hostPoolName
        }
    }


    It 'CreateExpanded' {
        $configuration = New-TestSessionHostConfiguration -TestEnvironment $env -HostPoolName $managedHostPoolName -DiskMode Managed

        $configuration = Get-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -HostPoolName $managedHostPoolName
        $configuration.VMNamePrefix | Should -Be "createTest"
        $configuration.ManagedDiskType | Should -Be "Standard_LRS"
    }

    It 'CreateExpanded_EphemeralOSDisk' {
        $configuration = New-TestSessionHostConfiguration -TestEnvironment $env -HostPoolName $ephemeralHostPoolName -DiskMode Ephemeral

        $configuration = Get-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
                -ResourceGroupName $env.ResourceGroup `
                -HostPoolName $ephemeralHostPoolName
        $configuration.DiffDiskSettingOption | Should -Be "Local"
        $configuration.DiffDiskSettingPlacement | Should -Be "TempDisk"
        $configuration.ManagedDiskType | Should -BeNullOrEmpty
    }

    AfterAll{
        foreach ($hostPoolName in $configurationHostPoolNames) {
            $hostPool = Remove-AzWvdHostPool -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroup `
            -Name $hostPoolName
        }
    }
}