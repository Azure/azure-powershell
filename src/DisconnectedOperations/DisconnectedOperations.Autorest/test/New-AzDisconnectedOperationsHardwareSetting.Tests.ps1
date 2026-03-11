if(($null -eq $TestName) -or ($TestName -contains 'New-AzDisconnectedOperationsHardwareSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDisconnectedOperationsHardwareSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDisconnectedOperationsHardwareSetting' {
    It 'CreateExpanded' {
        $result = New-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -DeviceId "0f76428c-6fe6-476d-9943-6e994a1e849b" -DiskSpaceInGb 1024 -HardwareSku "MC-760" -MemoryInGb 64 -Node 3 -Oem "contoso" -SolutionBuilderExtension "xyz" -TotalCore 200 -VersionAtRegistration "2411.2"

        $result | Should -Not -BeNull
        $result.Id | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Name | Should -Be "default2"

        # Delete the Resource using Name and ResourceGroupName
        Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        # Verify the Resource is deleted by trying to get it using the HardwareSettingName, ResourceName and ResourceGroupName (should throw)
        { Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop} | Should -Throw

    }

    It 'CreateViaJsonString' {
        $result = New-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -JsonString '{"properties":{"totalCores":200,"diskSpaceInGb":1024,"memoryInGb":64,"oem":"Contoso","hardwareSku":"MC-760","nodes":3,"versionAtRegistration":"2411.2","solutionBuilderExtension":"xyz","deviceId":"0f76428c-6fe6-476d-9943-6e994a1e849b"}}'

        $result | Should -Not -BeNull
        $result.Id | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Name | Should -Be "default2"

        # Delete the Resource using Name and ResourceGroupName
        Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        # Verify the Resource is deleted by trying to get it using the HardwareSettingName, ResourceName and ResourceGroupName (should throw)
        { Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop} | Should -Throw
    }

    It 'CreateViaJsonFilePath' {
        $result = New-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -JsonFilePath (Join-Path $PSScriptRoot './jsonFiles/CreateHardwareSettings.json')

        $result | Should -Not -BeNull
        $result.Id | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Name | Should -Be "default2"

        # Delete the Resource using Name and ResourceGroupName
        Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        # Verify the Resource is deleted by trying to get it using the HardwareSettingName, ResourceName and ResourceGroupName (should throw)
        { Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop} | Should -Thro
    }

    It 'CreateViaIdentityDisconnectedOperationExpanded' {
        $disconnectedOperationInputObject = @{
            "Name" = $env.Name;
            "ResourceGroupName" = $env.ResourceGroupName;
            "SubscriptionId" = $env.SubscriptionId;
        }

        $result = New-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -DisconnectedOperationInputObject $disconnectedOperationInputObject -DeviceId "0f76428c-6fe6-476d-9943-6e994a1e849b" -DiskSpaceInGb 1024 -HardwareSku "MC-760" -MemoryInGb 64 -Node 3 -Oem "contoso" -SolutionBuilderExtension "xyz" -TotalCore 200 -VersionAtRegistration "2411.2"

        $result | Should -Not -BeNull
        $result.Id | Should -Not -BeNullOrEmpty
        $result.Type | Should -Be "microsoft.edge/disconnectedOperations/hardwareSettings"
        $result.ResourceGroupName | Should -Be $env.ResourceGroupName
        $result.Name | Should -Be "default2"

        # Delete the Resource using Name and ResourceGroupName
        Remove-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName

        # Verify the Resource is deleted by trying to get it using the HardwareSettingName, ResourceName and ResourceGroupName (should throw)
        { Get-AzDisconnectedOperationsHardwareSetting -HardwareSettingName "default2" -Name $env.Name -ResourceGroupName $env.ResourceGroupName -ErrorAction Stop} | Should -Throw
    }
}
