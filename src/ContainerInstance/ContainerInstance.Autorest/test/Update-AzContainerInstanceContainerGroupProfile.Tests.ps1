if(($null -eq $TestName) -or ($TestName -contains 'Update-AzContainerInstanceContainerGroupProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzContainerInstanceContainerGroupProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzContainerInstanceContainerGroupProfile' {
    It 'PatchExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
        # The Update-AzContainerInstanceContainerGroupProfile operation supports the PATCH method.
        # This parameters are required -Name, -ResourceGroupName, -Tag
        # Tag is of type Modesl.Api20240501Preview.ContainerGroupPatchTags
        # However, defining Tag like this @{"k"="v"} is throwing this error - 'Required property 'properties' not found in JSON.
        # So, how exactly should tag be defined in json is looks like this properties={"tags": {"tag1key": "tag1Value", "tag2key": "tag2Value"}}
        # So, how to define this in powershell?
        


    }

    It 'Patch' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PatchViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
