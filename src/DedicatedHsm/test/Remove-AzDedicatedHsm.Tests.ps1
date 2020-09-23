$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzDedicatedHsm.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzDedicatedHsm' {
    It 'Delete' {
        Remove-AzDedicatedHsm -Name $env.dedicatedHsmName02 -ResourceGroupName $env.resourceGroup
        $hsmList = Get-AzDedicatedHsm -ResourceGroupName $env.resourceGroup
        $hsmList.Name | Should -Not -Contain $env.dedicatedHsmName02

    }

    It 'DeleteViaIdentity' {
        $hsm = New-AzDedicatedHsm -Name  $env.dedicatedHsmName03 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId $env.vnetSubnetId -NetworkInterface @{PrivateIPAddress = '10.2.1.120' }
        # Wait DedicatedHsm create complete.
        do {
            # Message: The new cmdlet cmdlet will return immediately. But actually it's long operation. This is an bug on the server. 
            # TODO: Remove code when Server fix bug. 
            # Record enable and Playback disable
            if ($TestMode -ne 'playback') {
                Start-Sleep -Seconds 60 
              }
            $hsm = Get-AzDedicatedHsm -Name  $env.dedicatedHsmName03 -ResourceGroupName $env.resourceGroup
        } until ($hsm.ProvisioningState -eq 'Succeeded')
        Remove-AzDedicatedHsm -InputObject $hsm
        $hsmList = Get-AzDedicatedHsm -ResourceGroupName $env.resourceGroup
        $hsmList.Name | Should -Not -Contain $env.dedicatedHsmName03
    }
}
