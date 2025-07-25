$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCloudServiceRemoteDesktopExtensionObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzCloudServiceRemoteDesktopExtensionObject' {
    It '__AllParameterSets' {
        $Username = -join ((48..57) + (97..122) | Get-Random -Count 8 | % {[char]$_})
        $Password = -join ((48..57) + (97..122) | Get-Random -Count 8 | % {[char]$_})
        $SecureStringPassword = ConvertTo-SecureString $Password -AsPlainText -Force
        $PsCredential = New-Object System.Management.Automation.PSCredential($Username, $SecureStringPassword)
        $RemoteDesktopExtensionObject = New-AzCloudServiceRemoteDesktopExtensionObject -Name RemoteDesktopExtensionObject -Credential $PsCredential
        $RemoteDesktopExtensionObject.ProtectedSetting | Should Be "<PrivateConfig><Password>$Password</Password></PrivateConfig>"
    }
}
