if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAksManagedClusterMeshRevisionProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAksManagedClusterMeshRevisionProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAksManagedClusterMeshRevisionProfile' {
    It 'List' {
        $profile = Get-AzAksManagedClusterMeshRevisionProfile -Location eastus
        $profile.Count | Should -Be 1
        $profile.Name| Should -Be 'istio'
        $profile.MeshRevision.Count | Should -Be 3
    }

    It 'Get' {
        $profile = Get-AzAksManagedClusterMeshRevisionProfile -Location eastus -Mode asm-1-25
        $profile.Count | Should -Be 1
        $profile.Name| Should -Be 'istio'
        $profile.MeshRevision.Count | Should -Be 3
    }

    It 'GetViaIdentityLocation' {
        $location = @{Id = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.ContainerService/locations/eastus" }
        $profile = Get-AzAksManagedClusterMeshRevisionProfile -LocationInputObject $location -Mode asm-1-25
        $profile.Count | Should -Be 1
        $profile.Name| Should -Be 'istio'
        $profile.MeshRevision.Count | Should -Be 3
    }

    It 'GetViaIdentity' {
        $profile = @{Id = "/subscriptions/$($env.SubscriptionId)/providers/Microsoft.ContainerService/locations/eastus/meshRevisionProfiles/istio" }
        $profile = $profile | Get-AzAksManagedClusterMeshRevisionProfile
        $profile.Count | Should -Be 1
        $profile.Name| Should -Be 'istio'
        $profile.MeshRevision.Count | Should -Be 3
    }
}
