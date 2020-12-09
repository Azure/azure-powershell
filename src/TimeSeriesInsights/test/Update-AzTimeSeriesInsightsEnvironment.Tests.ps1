$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzTimeSeriesInsightsEnvironment.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzTimeSeriesInsightsEnvironment' {
    It 'UpdateGen1' {
        $environmentName = $env.tsiEnvName
        $newTag = @{'key1'='val1'}
        Update-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName -Tag $newTag
        $updatedTsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName
        $val = ''
        $updatedTsiEnv.Tag.TryGetValue('key1',[ref]$val) | Should -Be $true
        $val | Should -Be 'val1'
    }

    It 'UpdateGen1InputObject' {
        $environmentName = $env.tsiEnvName
        $tsiEnvGen1 = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName
        $newTag = @{'key2'='val2'}
        Update-AzTimeSeriesInsightsEnvironment -InputObject $tsiEnvGen1 -Tag $newTag
        $updatedTsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName
        $val = ''
        $updatedTsiEnv.Tag.TryGetValue('key2',[ref]$val) | Should -Be $true
        $val | Should -Be 'val2'
    }

    It 'UpdateGen2' {
        $environmentName = $env.tsiEnvName01
        $newTag = @{'key3'='val3'}
        Update-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName -Tag $newTag
        $updatedTsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName
        $val = ''
        $updatedTsiEnv.Tag.TryGetValue('key3',[ref]$val) | Should -Be $true
        $val | Should -Be 'val3'
    }
    
    It 'UpdateGen2InputObject' {
        $environmentName = $env.tsiEnvName01
        $tsiEnvGen2 = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.resourceGroup -Name $environmentName
        $newTag = @{'key4'='val4'}
        Update-AzTimeSeriesInsightsEnvironment -InputObject $tsiEnvGen2 -Tag $newTag
        $updatedTsiEnv = Get-AzTimeSeriesInsightsEnvironment -ResourceGroupName $env.ResourceGroup -Name $environmentName 
        $val = ''
        $updatedTsiEnv.Tag.TryGetValue('key4',[ref]$val) | Should -Be $true
        $val | Should -Be 'val4'
    }
}
