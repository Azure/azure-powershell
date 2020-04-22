$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzBlockchainMemberApiKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzBlockchainMemberApiKey' {
    $keyPair = {}
    It 'RegenerateExpanded' {
        $keys = New-AzBlockchainMemberApiKey -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -KeyName $keyPair[0].KeyName
        $keys[0].Value | Should -Not -Be $keyPair[0].Value
    }

    It 'RegenerateViaIdentityExpanded' {
        #$PSDefaultParameterValues["Disabled"] = $True
        $bcMember = Get-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup 
        $keys = New-AzBlockchainMemberApiKey -InputObject $bcMember -KeyName $keyPair[0].KeyName
        $keys[0].Value | Should -Not -Be $keyPair[0].Value 
        #$PSDefaultParameterValues["Disabled"] = $False
    }

    BeforeEach {
        $keyPair = Get-AzBlockchainMemberApiKey -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup
    }
}
