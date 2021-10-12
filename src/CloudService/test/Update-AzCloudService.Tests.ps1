$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzCloudService.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzCloudService' {

    It 'Update cloud service via identity' {
        # Create Network Profile
        $feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name "cscmdlettestLBFE" -PublicIPAddressId $env.PublicIpId
        $loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name "cscmdlettestLB" -FrontendIPConfiguration $feIpConfig
        $networkProfile = @{loadBalancerConfiguration = $loadBalancerConfig}

        $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cloudService.ExtensionProfile.Extension = @()
        # Keep the network profile that the cloud service was originally created with
        $cloudService.NetworkProfile = $networkProfile
        Update-AzCloudService -InputObject $cloudService -Parameter $cloudService
        $cloudService = Get-AzCloudService -ResourceGroupName $env.ResourceGroupName -CloudServiceName $env.CloudServiceName
        $cloudService.ExtensionProfile.Extension.Count | Should be 0
    }
}
