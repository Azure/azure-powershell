$TestRecordingFile = Join-Path $PSScriptRoot 'C:\Code\azps-generation\src\Dns\test' 'Get-AzDnsTestMe.Recording.json'

. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzDnsTestMe' {
    It 'Scenario' {
        # Set-AzContext -Subscription 'Azure SDK Powershell Test'
        # New-AzResourceGroup -Name miyanni-test -Location 'West US 2'
        { New-AzDnsZone -Name www.miyanni.zone -ResourceGroupName miyanni-test -Location 'global' } | Should -Not -Throw
        Get-AzDnsZone -Name www.miyanni.zone -ResourceGroupName miyanni-test | Should -Not -Be $null

        { New-AzDnsRecordSet -RecordType TXT -RelativeRecordSetName 'miyanni-zone' -ResourceGroupName miyanni-test -ZoneName www.miyanni.zone -TimeToLive 3600 } | Should -Not -Throw
        Get-AzDnsRecordSet -ResourceGroupName miyanni-test -ZoneName www.miyanni.zone -RelativeRecordSetName 'miyanni-zone' -RecordType TXT | Should -Not -Be $null

        Remove-AzDnsRecordSet -ResourceGroupName miyanni-test -ZoneName www.miyanni.zone -RelativeRecordSetName 'miyanni-zone' -RecordType TXT -PassThru | Should -Be $true
        { Get-AzDnsRecordSet -ResourceGroupName miyanni-test -ZoneName www.miyanni.zone -RelativeRecordSetName 'miyanni-zone' -RecordType TXT } | Should -Throw

        Remove-AzDnsZone -Name www.miyanni.zone -ResourceGroupName miyanni-test -PassThru | Should -Be $true
        { Get-AzDnsZone -Name www.miyanni.zone -ResourceGroupName miyanni-test } | Should -Throw
    }

    # It 'List2' {
    #     { throw [System.NotImplementedException] } | Should -Not -Throw
    # }

    # It 'Get1' {
    #     { throw [System.NotImplementedException] } | Should -Not -Throw
    # }

    # It 'List4' {
    #     { throw [System.NotImplementedException] } | Should -Not -Throw
    # }

    # It 'GetViaIdentity1' {
    #     { throw [System.NotImplementedException] } | Should -Not -Throw
    # }
}
