if(($null -eq $TestName) -or ($TestName -contains 'New-AzVMwareVcf5LicenseObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzVMwareVcf5LicenseObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzVMwareVcf5LicenseObject' {
    It 'creates a Vcf5License object and sets expected properties' {
        $license = New-AzVMwareVcf5LicenseObject -Core 16 -EndDate (Get-Date '2027-01-01Z').ToUniversalTime() -BroadcomSiteId 'site123' -BroadcomContractNumber 'contract123'
        $license | Should -BeOfType 'Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.Vcf5License'
        $license.Kind | Should -Be 'vcf5'
        $license.Core | Should -Be 16
        $license.BroadcomSiteId | Should -Be 'site123'
        $license.BroadcomContractNumber | Should -Be 'contract123'
    }
}
