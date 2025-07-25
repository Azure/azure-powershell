$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCommunicationService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe -Verbose:$True 'New-AzCommunicationService' {
    It 'CreateExpanded' {        
        $linkedDomains1 = @(
	        $env.linkedDomain
        )
        $NewAzCommunicationService = New-AzCommunicationService -ResourceGroupName $env.resourceGroup -Name $env.resourceName -DataLocation $env.dataLocation -Location $env.location -LinkedDomain $linkedDomains1        
        $NewAzCommunicationService.Name | Should -Be $env.resourceName
    }
}
