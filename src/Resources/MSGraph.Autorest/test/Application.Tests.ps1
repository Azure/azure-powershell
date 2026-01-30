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
            New-AzADApplication -DisplayName $env.appName1 -ReplyUrls $env.reply1 -HomePage $env.homepage1 -AvailableToOtherTenants $true -StartDate (Get-Date)

            $app = Get-AzADApplication -DisplayName $env.appName1
            $app | Should -Not -Be $null
            $app.Web.RedirectUri | Should -Be $env.reply1
            $app.Web.HomePageUrl | should -Be $env.homepage1
            $app.SignInAudience | Should -Be 'AzureADMultipleOrgs'

            (Get-AzADApplication -ObjectId $app.id -Select Id).Id | Should -Be $app.Id
            (Get-AzADApplication -ApplicationId $app.AppId -Select Id).Id | Should -Be $app.Id

            
            Update-AzADApplication -ObjectId $app.Id -ReplyUrl $env.reply2 -HomePage $env.homepage2 -AvailableToOtherTenants $false

            $appUpdate = Get-AzADApplication -DisplayName $env.appName1
            $appUpdate.Web.RedirectUri | Should -Be $env.reply2
            $appUpdate.Web.HomePageUrl | should -Be $env.homepage2
            $appUpdate.SignInAudience | Should -Be 'AzureADMyOrg'

            (Get-AzADAppCredential -ObjectId $app.Id) | Should -Not -Be $null
            $pw = New-AzADAppCredential -ObjectId $app.Id -StartDate (get-date)
            

            $certFile = Join-Path $PSScriptRoot 'msgraphtest2.cer'
            $content=get-content $certFile -AsByteStream
            $certvalue=[System.Convert]::ToBase64String($content)
            $cert = New-AzADAppCredential -ObjectId $app.Id -CertValue $certvalue
            
            Remove-AzADAppCredential -ObjectId $app.Id -KeyId $pw.KeyId

            $sp1 = New-AzADServicePrincipal -ApplicationId $app.AppId
            $sp2 = New-AzADServicePrincipal -DisplayName $env.spName2

            Remove-AzADServicePrincipal -ServicePrincipalName $sp1.ServicePrincipalName[0]
            Remove-AzADServicePrincipal -ObjectId $sp2.Id
            Remove-AzADApplication -DisplayName $env.spName2
        } | Should -Not -Throw
    }

    AfterAll {
        Remove-AzADApplication -DisplayName $env.appName1
    }
}
