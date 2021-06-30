$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStaticWebAppUser.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzStaticWebAppUser' {
    It 'UpdateExpanded' {
      $userList = Get-AzStaticWebAppUser -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Authprovider all
      { Update-AzStaticWebAppUser -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Authprovider $userList[0].Provider -Userid $userList[0].UserId -Role 'contributor' } | Should -Not -Throw
    }

    It 'UpdateViaIdentityExpanded' {
      $userList = Get-AzStaticWebAppUser -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Authprovider all
      { Update-AzStaticWebAppUser -InputObject $userList -Role 'contributor' } | Should -Not -Throw
    }
}
