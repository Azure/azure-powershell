$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzBlockchainMember.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzBlockchainMember' {
    $passwd = 'strongMemberAccountPassword@1' | ConvertTo-SecureString -AsPlainText -Force
    $csPasswd = 'strongConsortiumManagementPassword@1' | ConvertTo-SecureString -AsPlainText -Force
    It 'Delete' {
        New-AzBlockchainMember -Name ("myblockchain" + $env.rstr3) -ResourceGroupName $env.resourceGroup -Consortium ("consortium" + $env.rstr3) -ConsortiumManagementAccountPassword $csPasswd -Location eastus -Password $passwd -Protocol Quorum -SkuName S0
        { Remove-AzBlockchainMember -Name ("myblockchain" + $env.rstr3) -ResourceGroupName $env.resourceGroup } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        #$PSDefaultParameterValues["Disabled"] = $True
        { Get-AzBlockchainMember -Name ("myblockchain" + $env.rstr4) -ResourceGroupName $env.resourceGroup | Remove-AzBlockchainMember } | Should -Not -Throw
        #$PSDefaultParameterValues["Disabled"] = $False
    }
}
