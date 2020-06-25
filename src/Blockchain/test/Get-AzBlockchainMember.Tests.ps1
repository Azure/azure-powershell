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
        $bcMember = Get-AzBlockchainMember
        $bcMember.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $bcMember = Get-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup
        $bcMember.Name  | Should -Be $env.blockchainMember
    }

    It 'List' {
        $bcMember = Get-AzBlockchainMember -ResourceGroupName $env.resourceGroup
        $bcMember.Count | Should -Be 2
    }

    It 'GetViaIdentity' {
        #$PSDefaultParameterValues["Disabled"] = $True
        $member = Get-AzBlockchainMember -SubscriptionId $env.SubscriptionId -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup 
        $bcMember = Get-AzBlockchainMember -InputObject $member
        $bcMember.Name  | Should -Be $env.blockchainMember
        #$PSDefaultParameterValues["Disabled"] = $False
    }
}
