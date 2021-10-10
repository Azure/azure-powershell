if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMgApplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMgApplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMgApplication' {
    It 'EmptyParameterSet' -skip {
        $app = New-AzMgApplication -DisplayName 2021-10-08-testapp1 -ReplyUrls https://2021-10-08-reply1.com -HomePage https://2021-10-08-home1 -AvailableToOtherTenants $true -StartDate (Get-Date)
        Get-AzMgApplication -ObjectId $app.id
        Get-AzMgApplication -ApplicationId $app.AppId
        Get-AzMgApplication -DisplayNameStartWith $app.DisplayName
        Get-AzMgApplication -DisplayName $app.DisplayName

        $homepage2 = "https://2021-10-08-home2"
        $reply2 = "https://2021-10-08-reply2.com"
        update-azmgapplication -ObjectId $app.Id -ReplyUrl $reply2 -HomePage $homepage2 -AvailableToOtherTenants $false
        $appupdate = Get-AzMgApplication -ObjectId $app.id

        get-azmgappcredential -ObjectId $app.Id
        $cred = New-AzMgAppCredential -ObjectId $app.Id -StartDate (get-date)
        Remove-AzMgAppCredential -ObjectId $app.Id -KeyId $cred.KeyId

        New-AzMgServicePrincipal -ApplicationId $app.AppId -Role contributor
        $sp1 = Get-AzMgServiceprincipal -ApplicationId $app.AppId
        New-AzMgServicePrincipal -DisplayName 2021-10-10-testsp2
        $sp2=Get-AzMgServicePrincipal -DisplayName 2021-10-10-testsp2

        $sp2 | Remove-AzMgServicePrincipal
        Remove-AzMgServicePrincipal -ObjectId $sp1.Id

        $app | remove-azmgapplication
    }
}
