if(($null -eq $TestName) -or ($TestName -contains 'New-AzAlbAssociation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAlbAssociation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAlbAssociation' {
    It 'CreateExpanded' {
        { 
            $albAssoc = New-AzAlbAssociation -Name $env.albAssociationName -AlbName $env.associationAlbName -ResourceGroupName $env.resourceGroup -Location $env.Region -SubnetId $env.extraSubnetId
            $albAssoc.ProvisioningState | Should -Be 'Succeeded'
         } | Should -Not -Throw
    }
}
