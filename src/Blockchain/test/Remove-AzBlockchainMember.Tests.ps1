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
        $bcMemberName = "myblockchain" + $env.rstr3
        New-AzBlockchainMember -Name $bcMemberName -ResourceGroupName $env.resourceGroup -Consortium ("consortium" + $env.rstr3) -ConsortiumManagementAccountPassword $csPasswd -Location eastus -Password $passwd -Protocol Quorum -Sku S0
        Remove-AzBlockchainMember -Name $bcMemberName -ResourceGroupName $env.resourceGroup 
        $bcMemberList = Get-AzBlockchainMember -ResourceGroupName $env.resourceGroup
        $bcMemberList.Name | Should -Not -Contain $bcMemberName
    }

    It 'DeleteViaIdentity' {
        #$PSDefaultParameterValues["Disabled"] = $True
        $bcMemberName = "myblockchain" + $env.rstr4
        $member = Get-AzBlockchainMember -Name $bcMemberName -ResourceGroupName $env.resourceGroup 
        Remove-AzBlockchainMember -InputObject $member
        $bcMemberList = Get-AzBlockchainMember -ResourceGroupName $env.resourceGroup
        $bcMemberList.Name | Should -Not -Contain $bcMemberName
        #$PSDefaultParameterValues["Disabled"] = $False
    }
}
