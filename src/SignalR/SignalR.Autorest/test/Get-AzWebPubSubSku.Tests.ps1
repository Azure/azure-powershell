if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWebPubSubSku'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWebPubSubSku.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWebPubSubSku' {
    It 'List' {
        $SkuList = Get-AzWebPubSubSku -ResourceGroupName $env.ResourceGroupName -ResourceName $env.Wps1
        $SkuList.Count | Should -BeGreaterOrEqual 1
        $SkuList[0].Tier | Should -BeTrue
    }
}
