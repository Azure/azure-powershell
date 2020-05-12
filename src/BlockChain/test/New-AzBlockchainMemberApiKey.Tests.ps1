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
        { New-AzBlockchainMemberApiKey -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup -KeyName $keyPair[0].KeyName -Value $keyPair[0].Value } | Should -Not -Throw
    }

    It 'RegenerateViaIdentityExpanded' -skip {
        #$PSDefaultParameterValues["Disabled"] = $True
        {  Get-AzBlockchainMember -Name $env.blockchainMember -ResourceGroupName $env.resourceGroup | New-AzBlockchainMemberApiKey -KeyName $keyPair[0].KeyName -Value $keyPair[0].Value } | Should -Not -Throw
        #$PSDefaultParameterValues["Disabled"] = $False
    }

    BeforeEach {
        $keyPair = Get-AzBlockchainMemberApiKey -BlockchainMemberName $env.blockchainMember -ResourceGroupName $env.resourceGroup
    }
}
