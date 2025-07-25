$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStaticWebAppUser.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzStaticWebAppUser' {
    # NOTE:Before test. Invite user join the static web domian.
    It 'Delete' {
      $userList = Get-AzStaticWebAppUser -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Authprovider all
      $removeUserId = $userList[0].UserId
      Remove-AzStaticWebAppUser -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Authprovider $userList[0].Provider -Userid $userList[0].UserId
      $userList = Get-AzStaticWebAppUser -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Authprovider all
      $userList.UserId | Should -Not -Contain $removeUserId
    }

    It 'DeleteViaIdentity' {
      $userList = Get-AzStaticWebAppUser -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Authprovider all    
      Remove-AzStaticWebAppUser -InputObject $userList
      $userList = Get-AzStaticWebAppUser -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Authprovider all
      $userList | Should -BeNullOrEmpty
    }
}
