if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAstroOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAstroOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzAstroOrganization' {
    It 'UpdateExpanded' {
        {
            $key = "key"
            $val = "val"
            $tag = @{$key=$val}

            $update = Update-AzAstroOrganization -Name $env.ResourceName -ResourceGroupName $env.ResourceGroupName -Tag $tag
            $update.Name | Should -Be $env.ResourceName
            $update.Tag.ContainsKey($key) | Should -BeTrue
            $update.Tag["$key"] | Should -Be $val
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            $remove = Remove-AzAstroOrganization -Name $env.ResourceName -ResourceGroupName $env.ResourceGroupName -PassThru
            $remove | Should -Be $true
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
