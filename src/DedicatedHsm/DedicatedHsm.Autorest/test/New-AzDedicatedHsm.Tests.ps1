$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDedicatedHsm.Recording.json'
$currentPath = $PSScriptRoot
while (-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

# Dedicated HSM is very heavy resource to create
# so I combine all the CRUD tests together to minimize resource creation
# and save time when re-recording them

Describe 'New-AzDedicatedHsm' {
    It 'CreateExpanded' {
        $hsm = New-AzDedicatedHsm -Name  $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup -Location $env.location -Sku "SafeNet Luna Network HSM A790" -StampId stamp1 -SubnetId $env.vnetSubnetId -NetworkInterface @{PrivateIPAddress = '10.2.1.120' }
        $hsm.ProvisioningState | Should -Be 'Succeeded'
    }
}

Describe 'Get-AzDedicatedHsm' {
    It 'List1' {
        $hsmList = Get-AzDedicatedHsm
        $hsmList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $hsm = Get-AzDedicatedHsm -Name $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup
        $hsm.Name | Should -Be $env.dedicatedHsmName01
    }

    It 'List' {
        $hsmList = Get-AzDedicatedHsm -ResourceGroupName $env.resourceGroup
        $hsmList.Count | Should -BeGreaterOrEqual 1
    }

    It 'GetViaIdentity' {
        $hsm = Get-AzDedicatedHsm -Name $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup
        $hsm = Get-AzDedicatedHsm -InputObject $hsm
        $hsm.Name | Should -Be $env.dedicatedHsmName01
    }
}

Describe 'Update-AzDedicatedHsm' {
    It 'UpdateExpanded' {
        $tag = @{'key1' = '1'; 'key2' = 2; 'key3' = 3 }
        $hsm = Update-AzDedicatedHsm -Name  $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup -Tag $tag
        $hsm.Tag.Count | Should -Be $tag.Count
    }

    It 'UpdateViaIdentityExpanded' {
        $tag = @{'key1' = '1'; 'key2' = 2; 'key3' = 3; 'key4' = 4 }
        $hsm = Get-AzDedicatedHsm -Name  $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup
        $hsm = Update-AzDedicatedHsm -InputObject $hsm -Tag $tag
        $hsm.Tag.Count | Should -Be $tag.Count
    }
}

Describe 'Remove-AzDedicatedHsm' {
    It 'Delete' {
        Remove-AzDedicatedHsm -Name $env.dedicatedHsmName01 -ResourceGroupName $env.resourceGroup
        $hsmList = Get-AzDedicatedHsm -ResourceGroupName $env.resourceGroup
        $hsmList.Name | Should -Not -Contain $env.dedicatedHsmName01

    }
}
