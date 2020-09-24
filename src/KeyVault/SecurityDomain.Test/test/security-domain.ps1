# Invoke-Pester @{ path = '.\src\KeyVault\SecurityDomain.Test\test\security-domain.ps1'; Parameters = @{sdPath = "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd.ps.json"}} -TestName 'Backup'

param(
    $rgName,
    $hsmName,
    $hsm2Name,
    $sdPath
)

function RandomName {
    param ($prefix)
    return $prefix + (Get-Random -Minimum 0 -Maximum 1000)
}

$location = 'eastus2euap'
$rgName ??= RandomName 'rg'
$hsmName ??= RandomName 'hsm'
$hsm2Name = RandomName 'hsm'
$certificates = "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd1.cer", "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd2.cer", "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd3.cer"
$sdPath ??= "C:\Users\yeliu\code\azure-powershell\src\KeyVault\SecurityDomain.Test\test\sd.ps.json1"

BeforeAll {
    New-AzResourceGroup -Name $rgName -Location $location
    New-AzKeyVault -Hsm ResourceGroupName $rgName -Name $hsmName -Location $location -Administrator 'd7e17135-d5a7-4b8b-89e5-252aa15b7e01', 'c1be1392-39b8-4521-aafc-819a47008545'
}

Describe "Backup" {
    It "Should backup successfully" {
        # $sdPath | Should -Not -Exist

        # Backup-AzManagedHsmSecurityDomain -Name $hsmName -Certificates $certificates -OutputPath $sdPath -Quorum 2

        $sdPath | Should -Exist
        Get-Content $sdPath | ConvertFrom-Json | Should -Not -BeNullOrEmpty
    }
}

Describe 'Restore' {
    It 'Should restore correctly' {
        Restore-AzManagedHsmSecurityDomain
    }
}