$TestRecordingFile = Join-Path $PSScriptRoot 'Scenario.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Scenario' {
    It 'Scenario' {
        # SETUP
        # Set-AzContext -Subscription 'Azure SDK Powershell Test'
        # New-AzResourceGroup -Name 'miyanni-test' -Location 'West US 2'

        { $script:zoneCreate = New-AzDnsZone -Name 'www.miyanni.zone' -ResourceGroupName 'miyanni-test' -Location 'global' } | Should -Not -Throw
        ($zoneGet = Get-AzDnsZone -Name 'www.miyanni.zone' -ResourceGroupName 'miyanni-test') | Should -Not -Be $null
        $zoneGet.Id | Should -Be $script:zoneCreate.Id
        [Console]::WriteLine("New-AzDnsZone done")

        { $script:recordSetCreate = New-AzDnsRecordSet -TxtRecord @{ Value = '0101','9898','TestMe' } -Name 'miyanni-record-set' -ResourceGroupName 'miyanni-test' -ZoneName 'www.miyanni.zone' -TimeToLive 3600 } | Should -Not -Throw
        ($recordSetGet = Get-AzDnsRecordSet -ResourceGroupName 'miyanni-test' -ZoneName 'www.miyanni.zone' -Name 'miyanni-record-set' -RecordType TXT) | Should -Not -Be $null
        $recordSetGet.Id | Should -Be $script:recordSetCreate.Id
        [Console]::WriteLine("New-AzDnsRecordSet done")

        # Get-AzDnsResourceReference -> The request was invalid.
        ($resourceReferenceGet = Get-AzDnsResourceReference -TargetResourceId $recordSetGet.Id) | Should -Not -Be $null
        $resourceReferenceGet.TargetResourceId | Should -Be $recordSetGet.Id
        [Console]::WriteLine("Get-AzDnsResourceReference done")

        # Set-AzDnsRecordSet -> Didn't test because didn't understand how to override resources. Overriding is based on the IfMatch/IfNoneMatch logic.
        { $script:recordSetUpdate = Update-AzDnsRecordSet -ResourceGroupName 'miyanni-test' -ZoneName 'www.miyanni.zone' -Name 'miyanni-record-set' -TxtRecord @{ Value = '1234','5678' } } | Should -Not -Throw
        $script:recordSetUpdate.TxtRecord | Should -Not -Be $recordSetGet.TxtRecord
        [Console]::WriteLine("Update-AzDnsRecordSet done")

        # Update-AzDnsZone -> Cmdlet should be removed. Only updates tags.
        { $script:zoneSet = Set-AzDnsZone -Name 'www.miyanni.zone' -ResourceGroupName 'miyanni-test' -Location 'global' } | Should -Not -Throw
        $script:zoneSet.Name | Should -Be $zoneGet.Name
        [Console]::WriteLine("Set-AzDnsRecordSet done")

        Remove-AzDnsRecordSet -ResourceGroupName 'miyanni-test' -ZoneName 'www.miyanni.zone' -Name 'miyanni-record-set' -RecordType TXT -PassThru | Should -Be $true
        { Get-AzDnsRecordSet -ResourceGroupName 'miyanni-test' -ZoneName 'www.miyanni.zone' -Name 'miyanni-record-set' -RecordType TXT } | Should -Throw
        [Console]::WriteLine("Remove-AzDnsRecordSet done")

        Remove-AzDnsZone -Name 'www.miyanni.zone' -ResourceGroupName 'miyanni-test' -PassThru | Should -Be $true
        { Get-AzDnsZone -Name 'www.miyanni.zone' -ResourceGroupName 'miyanni-test' } | Should -Throw
        [Console]::WriteLine("Remove-AzDnsZone done")

        # TEARDOWN
        # Remove-AzResourceGroup -Name 'miyanni-test'
    }
}
