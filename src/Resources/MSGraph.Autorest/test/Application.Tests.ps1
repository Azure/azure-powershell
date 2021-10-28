if(($null -eq $TestName) -or ($TestName -contains 'Application'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Application.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Application' -Tag 'LiveOnly' {
    It 'CRUD' {
        { 
            New-AzMgApplication -DisplayName $env.appName1 -ReplyUrls $env.reply1 -HomePage $env.homepage1 -AvailableToOtherTenants $true -StartDate (Get-Date)

            $app = Get-AzMgApplication -DisplayName $env.appName1
            $app | Should -Not -Be $null
            $app.Web.RedirectUri | Should -Be $env.reply1
            $app.Web.HomePageUrl | should -Be $env.homepage1
            $app.SignInAudience | Should -Be 'AzureADMultipleOrgs'

            (Get-AzMgApplication -ObjectId $app.id -Select Id).Id | Should -Be $app.Id
            (Get-AzMgApplication -ApplicationId $app.AppId -Select Id).Id | Should -Be $app.Id

            
            Update-AzMgApplication -ObjectId $app.Id -ReplyUrl $env.reply2 -HomePage $env.homepage2 -AvailableToOtherTenants $false

            $appUpdate = Get-AzMgApplication -DisplayName $env.appName1
            $appUpdate.Web.RedirectUri | Should -Be $env.reply2
            $appUpdate.Web.HomePageUrl | should -Be $env.homepage2
            $appUpdate.SignInAudience | Should -Be 'AzureADMyOrg'

            (Get-AzMgAppCredential -ObjectId $app.Id) | Should -Not -Be $null
            $cred = New-AzMgAppCredential -ObjectId $app.Id -StartDate (get-date)
            Remove-AzMgAppCredential -ObjectId $app.Id -KeyId $cred.KeyId

        } | Should -Not -Throw
    }

    AfterAll {
        Remove-AzMgApplication -DisplayName $env.appName1
    }
}
