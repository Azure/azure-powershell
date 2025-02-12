if (($null -eq $TestName) -or ($TestName -contains 'New-AzNetworkCloudVirtualMachine')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzNetworkCloudVirtualMachine.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzNetworkCloudVirtualMachine' {
    It 'Create' {
        {
            $networkAttachment = New-AzNetworkCloudNetworkAttachmentObject `
                -AttachedNetworkId $global:config.AzNetworkCloudVirtualMachine.networkAttachmentId `
                -IpAllocationMethod $global:config.AzNetworkCloudVirtualMachine.ipAllocationMethod `
                -Name $global:config.AzNetworkCloudVirtualMachine.attachmentName

            $hint = New-AzNetworkCloudVirtualMachinePlacementHintObject `
                -HintType $global:config.AzNetworkCloudVirtualMachine.placementHint `
                -SchedulingExecution $global:config.AzNetworkCloudVirtualMachine.placementExecution `
                -ResourceId $global:config.AzNetworkCloudVirtualMachine.placementResourceId `
                -Scope $global:config.AzNetworkCloudVirtualMachine.placementScope

            $sshPublicKey = @{
                KeyData = $global:config.AzNetworkCloudVirtualMachine.sshPublicKey
            }

            $securePassword = ConvertTo-SecureString $global:config.AzNetworkCloudVirtualMachine.registryPassword -AsPlainText -Force
            New-AzNetworkCloudVirtualMachine -Name $global:config.AzNetworkCloudVirtualMachine.vmName `
                -ResourceGroupName $global:config.AzNetworkCloudVirtualMachine.vmResourceGroup `
                -AdminUsername $global:config.AzNetworkCloudVirtualMachine.adminUsername `
                -CloudServiceNetworkAttachmentAttachedNetworkId $global:config.AzNetworkCloudVirtualMachine.csnAttachedNetworkId `
                -CloudServiceNetworkAttachmentIPAllocationMethod $global:config.AzNetworkCloudVirtualMachine.ipAllocationMethod `
                -CpuCore $global:config.AzNetworkCloudVirtualMachine.cpuCore `
                -ExtendedLocationName $global:config.common.extendedLocation ` -ExtendedLocationType $global:config.common.customLocationType `
                -Location $global:config.common.location `
                -SubscriptionId $global:config.AzNetworkCloudVirtualMachine.subscriptionId `
                -MemorySizeGb $global:config.AzNetworkCloudVirtualMachine.memorySizeGb `
                -OSDiskSizeGb  $global:config.AzNetworkCloudVirtualMachine.osDiskSizeGb `
                -VMImage $global:config.AzNetworkCloudVirtualMachine.vmImage `
                -BootMethod $global:config.AzNetworkCloudVirtualMachine.bootMethod `
                -CloudServiceNetworkAttachmentDefaultGateway $global:config.AzNetworkCloudVirtualMachine.csnAttachmentDefaultGateway `
                -CloudServiceNetworkAttachmentName $global:config.AzNetworkCloudVirtualMachine.csnAttachmentName `
                -IsolateEmulatorThread $global:config.AzNetworkCloudVirtualMachine.isolateEmulatorThread `
                -NetworkAttachment $networkAttachment `
                -NetworkData $global:config.AzNetworkCloudVirtualMachine.networkData `
                -OSDiskCreateOption $global:config.AzNetworkCloudVirtualMachine.osDiskCreateOption `
                -OSDiskDeleteOption $global:config.AzNetworkCloudVirtualMachine.osDiskDeleteOption `
                -PlacementHint $hint `
                -SshPublicKey $sshPublicKey `
                -Tag @{tags = $global:config.AzNetworkCloudVirtualMachine.tags } `
                -UserData $global:config.AzNetworkCloudVirtualMachine.userData `
                -VirtioInterface $global:config.AzNetworkCloudVirtualMachine.virtioInterface `
                -VMDeviceModel $global:config.AzNetworkCloudVirtualMachine.vmDeviceModel `
                -VMImageRepositoryCredentialsUsername $global:config.AzNetworkCloudVirtualMachine.registryUsername `
                -VMImageRepositoryCredentialsPassword $securePassword `
                -VMImageRepositoryCredentialsRegistryUrl $global:config.AzNetworkCloudVirtualMachine.registryUrl`
        } | Should -Not -Throw
    }
}
