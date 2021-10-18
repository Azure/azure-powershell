if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebPubSub'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebPubSub.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWebPubSub' {
    It 'List' {
        $WpsList = Get-AzWebPubSub -SubscriptionId $env.SubscriptionId
        $WpsList.Count | Should -BeGreaterOrEqual 2
    }

    It 'List1' {
        $WpsList = Get-AzWebPubSub -ResourceGroupName $env.ResourceGroupName
        $WpsList.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $Wps = Get-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $env.Wps1
        $Wps.Name | Should -Be $env.Wps1
    }

    It 'GetViaIdentity' {
        $Wps = Get-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $env.Wps1
        $NewWps = Get-AzWebPubSub -InputObject $Wps
        $NewWps.Name | Should -Be $Wps.Name
    }
}
