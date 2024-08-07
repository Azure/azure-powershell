$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCommunicationService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzCommunicationService' {
    It 'UpdateExpanded' {
        $tag = @{$env.exampleKey1=$env.exampleValue1; $env.exampleKey2=$env.exampleValue2}
        $linkedDomains1 = @(
	        $env.linkedDomain
        )
        $UpdatedAzCommunicationService = Update-AzCommunicationService -Name $env.persistentResourceName -ResourceGroupName $env.resourceGroup -Tag $tag -LinkedDomain $linkedDomains1

        $UpdatedAzCommunicationService.Tag[$env.exampleKey1] | Should -Be $env.exampleValue1
        $UpdatedAzCommunicationService.Tag[$env.exampleKey2] | Should -Be $env.exampleValue2
    }

    It 'UpdateViaIdentityExpanded' {
        $tag = @{$env.exampleKey1=$env.exampleValue1; $env.exampleKey2=$env.exampleValue2}
        $res = Get-AzCommunicationService -Name $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $UpdatedAzCommunicationService = Update-AzCommunicationService -InputObject $res -Tag $tag

        $UpdatedAzCommunicationService.Tag[$env.exampleKey1] | Should -Be $env.exampleValue1
        $UpdatedAzCommunicationService.Tag[$env.exampleKey2] | Should -Be $env.exampleValue2
    }
}
