if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebPubSubKey'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebPubSubKey.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWebPubSubKey' {
    It 'List' {
        $key = Get-AzWebPubSubKey -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1
        $key.PrimaryConnectionString | Should -BeTrue
        $key.PrimaryKey | Should -BeTrue
        $key.SecondaryConnectionString | Should -BeTrue
        $key.SecondaryKey | Should -BeTrue
    }

    It 'ListViaIdentity' {
        $wps = Get-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1
        $key = Get-AzWebPubSubKey -InputObject $wps
        $key.PrimaryConnectionString | Should -BeTrue
        $key.PrimaryKey | Should -BeTrue
        $key.SecondaryConnectionString | Should -BeTrue
        $key.SecondaryKey | Should -BeTrue
    }
}
