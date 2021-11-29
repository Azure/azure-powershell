if(($null -eq $TestName) -or ($TestName -contains 'New-AzWebPubSubKey'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWebPubSubKey.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWebPubSubKey' {
    It 'RegenerateExpanded' {
        $name = $env.WpsPrefix + "new-key-RegenerateExpanded"
        New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location eastus -SkuName Standard_S1
        $oldKey = Get-AzWebPubSubKey -ResourceGroupName $env.ResourceGroupName -ResourceName $name

        $newKey = New-AzWebPubSubKey -ResourceGroupName $env.ResourceGroupName -ResourceName $name -KeyType Primary

        $newKey.PrimaryKey | Should -Not -Be $oldKey.PrimaryKey
    }

    It 'RegenerateViaIdentityExpanded' {
        $name = $env.WpsPrefix + "new-key-RegenerateViaIdentityExpanded"
        $wps = New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location eastus -SkuName Standard_S1
        $oldKey = Get-AzWebPubSubKey -ResourceGroupName $env.ResourceGroupName -ResourceName $name

        $newKey = New-AzWebPubSubKey -KeyType Primary -InputObject $wps

        $newKey.PrimaryKey | Should -Not -Be $oldKey.PrimaryKey
    }
}
