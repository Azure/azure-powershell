if(($null -eq $TestName) -or ($TestName -contains 'AzHealthcareFhirService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzHealthcareFhirService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzHealthcareFhirService' {
    It 'CreateExpanded' {
        {
            $config = New-AzHealthcareFhirService -Name $env.fhirService2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Location $env.location -Kind 'fhir-R4' -Authority "https://login.microsoftonline.com/$($env.Tenant)" -Audience "https://azpshcws-$($env.fhirService2).fhir.azurehealthcareapis.com"
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.fhirService2)"

            $config = New-AzHealthcareFhirService -Name $env.fhirService3 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Location $env.location -Kind 'fhir-R4' -Authority "https://login.microsoftonline.com/$($env.Tenant)" -Audience "https://azpshcws-$($env.fhirService3).fhir.azurehealthcareapis.com"
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.fhirService3)"
        } | Should -Not -Throw
    }

    It 'List' {
        {
            $config = Get-AzHealthcareFhirService -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $config = Get-AzHealthcareFhirService -Name $env.fhirService2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.fhirService2)"
        } | Should -Not -Throw
    }

    It 'UpdateExpanded' {
        {
            $config = Update-AzHealthcareFhirService -Name $env.fhirService2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1 -Tag @{"123"="abc"}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.fhirService2)"
        } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
        {
            $config = Get-AzHealthcareFhirService -Name $env.fhirService3 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            $config = Update-AzHealthcareFhirService -InputObject $config -Tag @{"123"="abc"}
            $config.Name | Should -Be "$($env.apiWorkspace1)/$($env.fhirService3)"
        } | Should -Not -Throw
    }

    It 'Delete' {
        {
            Remove-AzHealthcareFhirService -Name $env.fhirService2 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
        } | Should -Not -Throw
    }

    It 'DeleteViaIdentity' {
        {
            $config = Get-AzHealthcareFhirService -Name $env.fhirService3 -ResourceGroupName $env.resourceGroup -WorkspaceName $env.apiWorkspace1
            Remove-AzHealthcareFhirService -InputObject $config
        } | Should -Not -Throw
    }
}