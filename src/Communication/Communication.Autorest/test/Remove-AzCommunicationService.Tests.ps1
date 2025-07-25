$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzCommunicationService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzCommunicationService' {
    It 'Delete' -skip {
        $name = "communicationService-test" + $env.rstr1
        $res = New-AzCommunicationService -ResourceGroupName $env.resourceGroup -Name $name -DataLocation $env.dataLocation -Location $env.location

        Remove-AzCommunicationService -Name $name -ResourceGroupName $env.resourceGroup

        $serviceList = Get-AzCommunicationService -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }

    It 'DeleteViaIdentity' -skip {
        $name = "communicationService-test" + $env.rstr2
        $res = New-AzCommunicationService -ResourceGroupName $env.resourceGroup -Name $name -DataLocation $env.dataLocation -Location $env.location

        Remove-AzCommunicationService -InputObject $res

        $serviceList = Get-AzCommunicationService -ResourceGroupName $env.resourceGroup
        $serviceList.Name | Should -Not -Contain $name
    }
}
