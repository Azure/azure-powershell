$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsDirectoryTenant.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'DirectoryTenant' {

    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateDirectoryTenant {
            param(
                [Parameter(Mandatory = $true)]
                $DirectoryTenant
            )
            # Overall
            $DirectoryTenant               | Should Not Be $null
            # Resource
            $DirectoryTenant.Id            | Should Not Be $null
            $DirectoryTenant.Name          | Should Not Be $null
            $DirectoryTenant.Type          | Should Not Be $null
            $DirectoryTenant.Location      | Should Not Be $null
            # DirectoryTenant
            $DirectoryTenant.TenantId      | Should Not Be $null
        }

        function AssertDirectoryTenantsSame {
            param(
                [Parameter(Mandatory = $true)]
                $Expected,
                [Parameter(Mandatory = $true)]
                $Found
            )
            if ($Expected -eq $null) {
                $Found | Should Be $null
            }
            else {
                $Found                | Should Not Be $null
                # Resource
                $Found.Id             | Should Be $Expected.Id
                $Found.Location       | Should Be $Expected.Location
                $Found.Name           | Should Be $Expected.Name
                $Found.Type           | Should Be $Expected.Type
                # DirectoryTenant
                $Found.TenantId       | Should Be $Expected.TenantId
            }
        }
    }

    AfterEach {
        $global:Client = $null
    }

    it "TestListDirectoryTenants" -Skip:$('TestListDirectoryTenants' -in $global:SkippedTests) {
        $global:TestName = 'TestListDirectoryTenants'

        $allDirectoryTenants = Get-AzsDirectoryTenant -ResourceGroupName $global:ResourceGroupName

        foreach ($DirectoryTenant in $allDirectoryTenants) {
            ValidateDirectoryTenant $DirectoryTenant
        }
    }

    it "TestGetAllDirectoryTenants" -Skip:$('TestGetAllDirectoryTenants' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllDirectoryTenants'

        $allDirectoryTenants = Get-AzsDirectoryTenant -ResourceGroupName $global:ResourceGroupName

        foreach ($DirectoryTenant in $allDirectoryTenants) {
            $tenant2 = Get-AzsDirectoryTenant -Name $DirectoryTenant.Name -ResourceGroupName $global:ResourceGroupName
            AssertDirectoryTenantsSame $DirectoryTenant $tenant2
        }
    }

    it "TestGetDirectoryTenant" -Skip:$('TestGetDirectoryTenant' -in $global:SkippedTests) {
        <# $global:TestName = 'TestGetDirectoryTenant'

        $tenant = Get-AzsDirectoryTenant -ResourceGroupName $global:ResourceGroupName
        $tenant2 = Get-AzsDirectoryTenant -ResourceGroupName $global:ResourceGroupName -Name $tenant.Name
        AssertDirectoryTenantsSame $tenant $tenant2 #>
    }

    It 'GetViaIdentity' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
