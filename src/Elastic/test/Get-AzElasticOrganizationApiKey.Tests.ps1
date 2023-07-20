if(($null -eq $TestName) -or ($TestName -contains 'Get-AzElasticOrganizationApiKey'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzElasticOrganizationApiKey.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzElasticOrganizationApiKey' {
    It 'GetExpanded' -skip {
        {
            Get-AzElasticOrganizationApiKey -EmailId $env.userEmail
        } | Should -Not -Throw
    }

    It 'GetViaJsonString' -skip {
        {
            $orgApiKeyProps = @{
                emailId = $env.userEmail
            }
            $orgApiKeyPropsJson = ConvertTo-Json -InputObject $orgApiKeyProps
            Get-AzElasticOrganizationApiKey -JsonString $orgApiKeyPropsJson
        } | Should -Not -Throw
    }

    It 'GetViaJsonFilePath' -Skip {

    }
}
