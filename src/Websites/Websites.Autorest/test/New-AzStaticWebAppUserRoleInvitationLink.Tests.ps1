$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStaticWebAppUserRoleInvitationLink.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzStaticWebAppUserRoleInvitationLink' {
    It 'CreateExpanded' {
      $web = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $link = New-AzStaticWebAppUserRoleInvitationLink -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -Domain $web.DefaultHostname -Provider 'github' -UserDetail 'LucasYao93' -Role 'reader' -NumHoursToExpiration 1
      $link.InvitationUrl | Should -Not -BeNullOrEmpty
    }

    It 'CreateViaIdentityExpanded' {
      $web = Get-AzStaticWebApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00
      $link = New-AzStaticWebAppUserRoleInvitationLink -InputObject $web -Domain $web.DefaultHostname -Provider 'github' -UserDetail 'LucasYao93' -Role 'admin,contributor' -NumHoursToExpiration 1
      $link.InvitationUrl | Should -Not -BeNullOrEmpty
    }
}
