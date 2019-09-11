$TestRecordingFile = Join-Path 'C:\B\azure-powershell\src\Billing\test' 'Get-AzBudget.Recording.json'
. (Join-Path $PSScriptRoot '..\generated\runtime' 'HttpPipelineMocking.ps1')

Describe 'Get-AzBudget' {
    It 'ListBySubscription' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByResourceGroup' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByInvoiceSection' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByBillingProfile' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByEnrollmentAccount' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByDepartment' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByBillingAccount' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'ListByManagementGroup' {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
