function GetAzManagedHsm{
    Param(
        [parameter(Mandatory=$false)]
        [String]
        $HsmName,
        [parameter(Mandatory=$false)]
        [String]
        $ResourceGroupName,
        [parameter(Mandatory=$false)]
        [String]
        $Location,
        [parameter(Mandatory=$false)]
        [String[]]
        $Administrator
    )
    $hsmName = GetRandomName -Prefix "hsm"
    $resourceGroupName = GetRandomName -Prefix "rg"
    $Location = "eastus2euap"
    $administrator = "c1be1392-39b8-4521-aafc-819a47008545"
    $hsm = New-AzManagedHsm -Name $HsmName -ResourceGroupName $ResourceGroupName -Location $r -Administrator $Administrator
    return $hsm
}

function GetRandomName{
    Param(
        [parameter(Mandatory=$false)]
        [String]
        $Prefix
    )
    $randomNum = Get-Random -Minimum 100 -Maximum 99999
    return "$Prefix$randomNum"
}

function ImportModules{
    $psd1Path = Join-Path $PSScriptRoot "../../../../artifacts/Debug/" -Resolve
    $accountsPsd1 = Join-Path $psd1Path "./Az.Accounts/Az.Accounts.psd1" -Resolve
    $keyVaultPsd1 = Join-Path $psd1Path "./Az.KeyVault/Az.KeyVault.psd1" -Resolve
    Import-Module $accountsPsd1
    Import-Module $keyVaultPsd1
}