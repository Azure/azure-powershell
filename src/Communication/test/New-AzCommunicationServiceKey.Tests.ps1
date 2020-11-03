$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCommunicationServiceKey.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzCommunicationServiceKey' {
    It 'RegenerateExpanded' {
        $keys = New-AzCommunicationServiceKey -CommunicationServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -KeyType Primary
        $keys[0].PrimaryKey | Should -Not -Be $keyPair[0].PrimaryKey

        $keys = New-AzCommunicationServiceKey -CommunicationServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -KeyType Secondary
        $keys[0].SecondaryKey | Should -Not -Be $keyPair[0].SecondaryKey
    }

    It 'Regenerate' {
        $keys = New-AzCommunicationServiceKey -CommunicationServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -Parameter @{KeyType="Primary"}
        $keys[0].PrimaryKey | Should -Not -Be $keyPair[0].PrimaryKey

        $keys = New-AzCommunicationServiceKey -CommunicationServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup -Parameter @{KeyType="Secondary"}
        $keys[0].SecondaryKey | Should -Not -Be $keyPair[0].SecondaryKey
    }

    BeforeEach {
        $keyPair = Get-AzCommunicationServiceKey -CommunicationServiceName $env.persistentResourceName -ResourceGroupName $env.resourceGroup
    }
}
