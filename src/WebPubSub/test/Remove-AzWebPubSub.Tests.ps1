if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzWebPubSub'))
{
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath))
    {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzWebPubSub.Recording.json'
    $currentPath = $PSScriptRoot
    while(-not $mockingPath)
    {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzWebPubSub' {
    It 'Delete' {
        Set-ItResult -Skipped -Because  "The resoure provider is not ready."

        $name = $env.WpsPrefix + "remove-wps-" + "Delete"
        New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location eastus -SkuName Standard_S1

        Remove-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name

        $wpsList = Get-AzWebPubSub -ResourceGroupName $env.ResourceGroupName
        $wpsList.Name | Should -Not -Contain $name
    }

    It 'DeleteViaIdentity' {
        Set-ItResult -Skipped -Because  "The resoure provider is not ready."

        $name = $env.WpsPrefix + "remove-wps-" + "DeleteViaIdentity"
        $wps = New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location eastus -SkuName Standard_S1

        Remove-AzWebPubSub -InputObject $wps

        $wpsList = Get-AzWebPubSub -ResourceGroupName $env.ResourceGroupName
        $wpsList.Name | Should -Not -Contain $name
    }
}