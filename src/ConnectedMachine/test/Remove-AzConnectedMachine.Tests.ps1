$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConnectedMachine.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzConnectedMachine' {
    BeforeEach {
        $Location = $env.location
        $machineName = (New-Guid).Guid

        $azcmagentArgs = @(
            'connect'
            '--resource-group'
            $env.ResourceGroupName
            '--tenant-id'
            $env.TenantId
            '--location'
            $env.location
            '--subscription-id'
            $env.SubscriptionId
            '--access-token'
            $env.AccessToken
            '--resource-name'
            $machineName
        )

        if ($IsLinux) {
            return sudo $env.azcmagentPath @azcmagentArgs 
        }
        & $env.azcmagentPath @azcmagentArgs
    }

    AfterEach {
        if ($IsLinux) {
            return sudo $env.azcmagentPath disconnect --access-token $env.AccessToken
        }
        & $env.azcmagentPath disconnect --access-token $env.AccessToken 
    }

    It 'Remove a connected machine by name' {        
        Remove-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName
        { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Throw        
    }

    It 'Remove a connected machine by Input Object' {
        $machine = Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName
        Remove-AzConnectedMachine -InputObject $machine
        { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Throw        
    }

    It 'Remove a connected machine using pipelines' {
        Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName | Remove-AzConnectedMachine
        { Get-AzConnectedMachine -Name $machineName -ResourceGroupName $env.ResourceGroupName } | Should -Throw        
   }
}
