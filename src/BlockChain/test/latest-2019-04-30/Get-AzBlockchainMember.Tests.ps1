$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBlockchainMember.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzBlockchainMember' {
    It 'List1' {
        { Get-AzBlockchainMember } | Should -Not -Throw
    }

    It 'Get' {
        { Get-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'List' {
        { Get-AzBlockchainMember -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        #$PSDefaultParameterValues["Disabled"] = $True
        { Get-AzBlockchainMember -SubscriptionId $env.SubscriptionId -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup | Get-AzBlockchainMember } | Should -Not -Throw
        #$PSDefaultParameterValues["Disabled"] = $False
    }
}
