# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

Describe 'Restore-AzDocumentDBMongoCluster RestoreTime normalization' {
    BeforeAll {
        $modulePath = Join-Path $PSScriptRoot '..\Az.DocumentDB.psd1'
        $customCmdletPath = Join-Path $PSScriptRoot '..\custom\Restore-AzDocumentDBMongoCluster.ps1'

        Remove-Module Az.DocumentDB -Force -ErrorAction SilentlyContinue
        $captureModule = New-Module -Name Az.DocumentDB -ScriptBlock {
            function New-AzDocumentDBMongoCluster {
                param([System.DateTime] ${RestoreParameterPointInTimeUtc})

                [PSCustomObject]@{
                    RestoreParameterPointInTimeUtc = $RestoreParameterPointInTimeUtc
                }
            }
            Export-ModuleMember -Function New-AzDocumentDBMongoCluster
        }
        Import-Module $captureModule
        . $customCmdletPath
    }

    AfterAll {
        Remove-Item Function:\Restore-AzDocumentDBMongoCluster -Force -ErrorAction SilentlyContinue
        Remove-Module Az.DocumentDB -Force -ErrorAction SilentlyContinue
        Import-Module $modulePath -Force
    }

    BeforeEach {
        $restoreParameters = @{
            Name                  = 'restored-cluster'
            ResourceGroupName     = 'test-resource-group'
            Location              = 'eastus'
            SourceCluster         = 'source-cluster'
            AdministratorUserName = 'testadmin'
            AdministratorPassword = ConvertTo-SecureString ("A1!{0}" -f [System.Guid]::NewGuid().ToString('N')) -AsPlainText -Force
            SubscriptionId        = '00000000-0000-0000-0000-000000000000'
            Confirm               = $false
        }
    }

    It 'preserves unspecified wall-clock ticks and marks the value as UTC' {
        $restoreTime = [System.DateTime]::SpecifyKind(
            [System.DateTime]::ParseExact(
                '2026-06-30T10:00:00.1234567',
                'yyyy-MM-ddTHH:mm:ss.fffffff',
                [System.Globalization.CultureInfo]::InvariantCulture),
            [System.DateTimeKind]::Unspecified)

        $result = Restore-AzDocumentDBMongoCluster @restoreParameters -RestoreTime $restoreTime

        $result.RestoreParameterPointInTimeUtc.ToString('o') | Should -Be '2026-06-30T10:00:00.1234567Z'
        $result.RestoreParameterPointInTimeUtc.Ticks | Should -Be $restoreTime.Ticks
        $result.RestoreParameterPointInTimeUtc.Kind | Should -Be ([System.DateTimeKind]::Utc)
    }

    It 'keeps an existing UTC value unchanged' {
        $restoreTime = [System.DateTime]::Parse(
            '2026-06-30T10:00:00.1234567Z',
            [System.Globalization.CultureInfo]::InvariantCulture,
            [System.Globalization.DateTimeStyles]::RoundtripKind)

        $result = Restore-AzDocumentDBMongoCluster @restoreParameters -RestoreTime $restoreTime

        $result.RestoreParameterPointInTimeUtc.ToString('o') | Should -Be '2026-06-30T10:00:00.1234567Z'
        $result.RestoreParameterPointInTimeUtc.Ticks | Should -Be $restoreTime.Ticks
        $result.RestoreParameterPointInTimeUtc.Kind | Should -Be ([System.DateTimeKind]::Utc)
    }

    It 'normalizes an offset-bearing input to the same UTC instant' {
        $result = Restore-AzDocumentDBMongoCluster @restoreParameters `
            -RestoreTime '2026-06-30T10:00:00.1234567-07:00'

        $result.RestoreParameterPointInTimeUtc.ToString('o') | Should -Be '2026-06-30T17:00:00.1234567Z'
        $result.RestoreParameterPointInTimeUtc.Kind | Should -Be ([System.DateTimeKind]::Utc)
    }
}
