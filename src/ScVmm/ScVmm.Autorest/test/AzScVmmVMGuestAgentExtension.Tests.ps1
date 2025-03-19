if(($null -eq $TestName) -or ($TestName -contains 'AzScVmmVMGuestAgentExtension'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzScVmmVMGuestAgentExtension.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzScVmmVMGuestAgentExtension' -Tag 'LiveOnly' {
    # VM Guest Agent

    It 'NewGuestAgent - New-AzScVmmVMGuestAgent' {
        {
            # To install Guest Agent, VM should be in running state
            Start-AzScVmmVM -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
            # Sleep to have stability in VM start operation and IP updation if any from DHCP Server on Lab setup
            Start-TestSleep -Seconds 30

            $guestSecurePassword = ConvertTo-SecureString -String $env.GuestPassword -AsPlainText -Force
            $result = New-AzScVmmVMGuestAgent -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest -CredentialsPassword $guestSecurePassword -CredentialsUsername $env.GuestUsername
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.Status | Should -Be 'Enabled'
        } | Should -Not -Throw
    }

    It 'GetGuestAgent - Get-AzScVmmVMGuestAgent' {
        {
            $result = Get-AzScVmmVMGuestAgent -Name $env.VmName -ResourceGroupName $env.ResourceGroupVmTest
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.Status | Should -Be 'Enabled'
        } | Should -Not -Throw
    }

    # VM Extension

    It 'NewVMExtension - New-AzScVmmVMExtension' {
        {
            $extensionSetting = ConvertFrom-Json $env.CommandWhoami -AsHashtable
            $result = New-AzScVmmVMExtension -vmName $env.VmName -ResourceGroupName $env.ResourceGroupVmTest -Location $env.location -ExtensionName $env.ExtensionName -Type $env.ExtensionType -Publisher $env.Publisher -Setting $extensionSetting 
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'ListExtension - Get-AzScVmmVMExtension' {
        {
            $result = Get-AzScVmmVMExtension -vmName $env.VmName -ResourceGroupName $env.ResourceGroupVmTest 
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'UpdateExtension - Update-AzScVmmVMExtension' {
        {
            $extensionSetting = ConvertFrom-Json $env.CommandSysroot -AsHashtable
            $result = Update-AzScVmmVMExtension -vmName $env.VmName -ResourceGroupName $env.ResourceGroupVmTest  -ExtensionName $env.ExtensionName -Setting $extensionSetting
            $result.ProvisioningState | Should -Be 'Succeeded'
        } | Should -Not -Throw
    }

    It 'GetExtension - Get-AzScVmmVMExtension' {
        {
            $result = Get-AzScVmmVMExtension -vmName $env.VmName -ResourceGroupName $env.ResourceGroupVmTest -ExtensionName $env.ExtensionName
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.Name | Should -Be $env.ExtensionName
        } | Should -Not -Throw
    }

    It 'RemoveExtension - Remove-AzScVmmVMExtension' {
        {
            Remove-AzScVmmVMExtension -vmName $env.VmName -ResourceGroupName $env.ResourceGroupVmTest -ExtensionName $env.ExtensionName
        } | Should -Not -Throw
    }
}
