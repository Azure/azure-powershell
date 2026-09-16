if(($null -eq $TestName) -or ($TestName -contains 'Update-AzDiscoverySupercomputer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDiscoverySupercomputer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDiscoverySupercomputer' {
    It 'UpdateExpanded' {
        $original = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $original.Tag) {
            foreach ($key in $original.Tag.Keys) {
                $originalTags[$key] = $original.Tag[$key]
            }
        }

        try {
            Update-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -Tag @{ psTest = 'true'; SkipAssociateKeyVaultToNsp = 'True' } | Out-Null
            $updated = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'true'
        }
        finally {
            Update-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -Tag $originalTags | Out-Null
        }
    }

    It 'UpdateViaIdentityExpanded' {
        $resource = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -ErrorAction Stop
        $originalTags = @{}
        if ($null -ne $resource.Tag) {
            foreach ($key in $resource.Tag.Keys) {
                $originalTags[$key] = $resource.Tag[$key]
            }
        }

        try {
            Update-AzDiscoverySupercomputer -InputObject $resource -Tag @{ psTest = 'viaIdentity'; SkipAssociateKeyVaultToNsp = 'True' } | Out-Null
            $updated = Get-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -ErrorAction Stop
            $updated | Should -Not -BeNullOrEmpty
            $updated.Tag['psTest'] | Should -Be 'viaIdentity'
        }
        finally {
            Update-AzDiscoverySupercomputer -ResourceGroupName $env.ResourceGroupName -Name $env.SupercomputerNameForGet -Tag $originalTags | Out-Null
        }
    }
}
