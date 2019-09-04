$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzBudget.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzBudget' {
    It 'ListBySubscription' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Get' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'List' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByBillingAccount' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByDepartment' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByEnrollmentAccount' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByBillingProfile' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByInvoiceSection' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByManagementGroup' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
