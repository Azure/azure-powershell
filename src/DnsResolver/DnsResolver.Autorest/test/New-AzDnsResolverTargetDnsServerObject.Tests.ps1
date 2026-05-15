$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDnsResolverTargetDnsServerObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) { $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File; $currentPath = Split-Path -Path $currentPath -Parent }
. ($mockingPath | Select-Object -First 1).FullName
Describe 'New-AzDnsResolverTargetDnsServerObject' {
    It 'Create a target DNS server object' {
        $server = New-AzDnsResolverTargetDnsServerObject -IPAddress "10.0.0.1" -Port 53
        $server | Should -Not -BeNullOrEmpty
        $server.IPAddress | Should -Be "10.0.0.1"
    }
}

