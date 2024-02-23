if(($null -eq $TestName) -or ($TestName -contains 'Update-AzEmailService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzEmailService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzEmailService' {
    It 'UpdateExpanded' {
        $tag = @{$env.exampleKey1=$env.exampleValue1; $env.exampleKey2=$env.exampleValue2}
        $UpdatedAzEmailService = Update-AzEmailService -Name $env.persistentResourceName -ResourceGroupName $env.resourceGroup -Tag $tag

        $UpdatedAzEmailService.Tag[$env.exampleKey1] | Should -Be $env.exampleValue1
        $UpdatedAzEmailService.Tag[$env.exampleKey2] | Should -Be $env.exampleValue2
    }

    It 'UpdateViaJsonString' -skip  {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaJsonFilePath' -skip  {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        $tag = @{$env.exampleKey1=$env.exampleValue1; $env.exampleKey2=$env.exampleValue2}
        $res = Get-AzEmailService -Name $env.persistentResourceName -ResourceGroupName $env.resourceGroup
        $UpdatedAzEmailService = Update-AzEmailService -InputObject $res -Tag $tag

        $UpdatedAzEmailService.Tag[$env.exampleKey1] | Should -Be $env.exampleValue1
        $UpdatedAzEmailService.Tag[$env.exampleKey2] | Should -Be $env.exampleValue2
    }
}
