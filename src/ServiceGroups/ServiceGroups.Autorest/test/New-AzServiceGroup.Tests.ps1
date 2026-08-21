if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceGroup' {
    It 'CreateExpanded' {
        $serviceGroup = New-AzServiceGroup -Name $env.ServiceGroupNameForNew -DisplayName $env.ServiceGroupDisplayName -ParentResourceId $env.TenantParentId
        $serviceGroup | Should -Not -BeNullOrEmpty
        $serviceGroup.Name | Should -Be $env.ServiceGroupNameForNew
        $serviceGroup.DisplayName | Should -Be $env.ServiceGroupDisplayName
    }

    It 'CreateViaJsonString' {
        $jsonString = '{"properties":{"displayName":"Test SG From JSON","parent":{"resourceId":"' + $env.TenantParentId + '"}}}'
        $serviceGroup = New-AzServiceGroup -Name $env.ServiceGroupNameForNewJson -JsonString $jsonString
        $serviceGroup | Should -Not -BeNullOrEmpty
        $serviceGroup.Name | Should -Be $env.ServiceGroupNameForNewJson
    }

    It 'CreateViaJsonFilePath' {
        $jsonContent = '{"properties":{"displayName":"Test SG From JSON File","parent":{"resourceId":"' + $env.TenantParentId + '"}}}'
        $jsonFilePath = Join-Path -Path $PSScriptRoot -ChildPath 'New-AzServiceGroup-Params.json'
        $jsonContent | Out-File -FilePath $jsonFilePath -Encoding utf8
        try {
            $serviceGroup = New-AzServiceGroup -Name $env.ServiceGroupNameForNewJsonFile -JsonFilePath $jsonFilePath
            $serviceGroup | Should -Not -BeNullOrEmpty
            $serviceGroup.Name | Should -Be $env.ServiceGroupNameForNewJsonFile
            $serviceGroup.DisplayName | Should -Be 'Test SG From JSON File'
        } finally {
            Remove-Item -Path $jsonFilePath -Force -ErrorAction SilentlyContinue
        }
    }

    It 'CreateWithNonTenantParent' {
        $serviceGroup = New-AzServiceGroup -Name $env.ChildServiceGroupNameForNew -DisplayName 'Child Service Group' -ParentResourceId $env.ParentServiceGroupId
        $serviceGroup | Should -Not -BeNullOrEmpty
        $serviceGroup.Name | Should -Be $env.ChildServiceGroupNameForNew
    }
}
