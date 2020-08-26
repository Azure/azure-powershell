$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzSpringCloudApp.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzSpringCloudApp' {
    It 'CreateExpanded' {
        $app = New-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -Name $env.appGateway -Location $env.location `
        -TemporaryDiskMountPath "/mytemporarydisk" -TemporaryDiskSizeInGb 2 -PersistentDiskSizeInGb 2 -PersistentDiskMountPath "/mypersistentdisk"
        $app.ProvisioningState | Should -Be "Succeeded"

        $app = New-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -Name $env.appAccount -Location $env.location `
        -TemporaryDiskMountPath "/mytemporarydisk" -TemporaryDiskSizeInGb 2 -PersistentDiskSizeInGb 2 -PersistentDiskMountPath "/mypersistentdisk"
        $app.ProvisioningState | Should -Be "Succeeded"

        $app = New-AzSpringCloudApp -ResourceGroupName $env.resourceGroup -ServiceName $env.springName01 -Name $env.appAuth -Location $env.location `
        -TemporaryDiskMountPath "/mytemporarydisk" -TemporaryDiskSizeInGb 2 -PersistentDiskSizeInGb 2 -PersistentDiskMountPath "/mypersistentdisk"
        $app.ProvisioningState | Should -Be "Succeeded"
    }
}
