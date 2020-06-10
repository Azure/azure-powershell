$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzBlockchainMember.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzBlockchainMember' {
    $passwd2 = 'strongMemberAccountPassword@2' | ConvertTo-SecureString -AsPlainText -Force
    $passwd3 = 'strongMemberAccountPassword@3' | ConvertTo-SecureString -AsPlainText -Force
    It 'UpdateExpanded' {
        $tag = @{'update'='password'}
        Update-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup -Password $passwd2 
        Update-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup -Tag $tag
        $member = Get-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup
        $member.Tag.ContainsKey('update') | Should -Be $True
    }

    It 'UpdateViaIdentityExpanded' {
        #$PSDefaultParameterValues["Disabled"] = $True
        $tag = @{'againupdate'='password'}
        $member = Get-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup
        Update-AzBlockchainMember -InputObject $member -Password $passwd3
        Update-AzBlockchainMember -InputObject $member -Tag $tag
        $member = Get-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup
        $member.Tag.ContainsKey('againupdate') | Should -Be $True
    }
}
