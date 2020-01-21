$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsSubscriptionQuota.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'SubscriptionQuota' {

    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateQuota {
            param(
                [Parameter(Mandatory = $true)]
                $Quota
            )
            # Overall
            $Quota               | Should Not Be $null

            # Resource
            $Quota.Id            | Should Not Be $null
            $Quota.Name          | Should Not Be $null
            $Quota.Type          | Should Not Be $null
            $Quota.Location      | Should Not Be $null
        }
    }

    AfterEach {
        $global:Client = $null
    }

    it "TestListQuotas" -Skip:$('TestListQuotas' -in $global:SkippedTests) {
            $global:TestName = 'TestListQuotas'

            $allQuotas = Get-AzsSubscriptionQuota -Location $global:Location
            $global:ResourceGroupNames = New-Object -TypeName System.Collections.Generic.HashSet[System.String]

            foreach ($Quota in $allQuotas) {
                ValidateQuota $Quota
            }
        }

    It 'Get' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
