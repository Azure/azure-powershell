$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzVMwareCloudLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzVMwareCloudLink' {
    It 'Delete' {
        {   
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AVS/privateClouds/$($env.privatecloudname2)/"
            New-AzVMwareCloudLink -Name $env.rstr2 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup -LinkedCloud $ID
            Remove-AzVMwareCloudLink -Name $env.rstr2 -PrivateCloudName $env.privatecloudname1 -resourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $ID = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AVS/privateClouds/$($env.privatecloudname2)/"
            New-AzVMwareCloudLink -Name $env.rstr2 -PrivateCloudName $env.privatecloudname1 -ResourceGroupName $env.resourceGroup -LinkedCloud $ID
            $ID2 = "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.AVS/privateClouds/$($env.privatecloudname1)/cloudLinks/$($env.rstr2)"
            Remove-AzVMwareCloudLink -InputObject $ID2
        } | Should -Not -Throw
    }
}
