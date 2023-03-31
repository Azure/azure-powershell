
$hsmName = 'bezmhsm'
. $PSScriptRoot/ManagedHsmDataPlaneTests.ps1

function Get-KeyName{
    return GetRandomName "bez-key"
}


Describe "Exportable and ReleasePolicyPath shoud show up at the same time"{
    
    It "Both Exportable and ReleasePolicyPath don't show up"{
        {
            Add-AzKeyVaultKey -HsmName $hsmName -KeyName (Get-KeyName) -KeyType RSA
        } | Should -Not -Throw
    }

    It "Exportable shows up but ReleasePolicyPath not" -skip {
        {
            Add-AzKeyVaultKey -HsmName $hsmName -KeyName (Get-KeyName) -KeyType RSA -Exportable
        } | Should -Throw
    }

    It "ReleasePolicyPath shows up but Exportable not" -skip {
        {
            Add-AzKeyVaultKey -HsmName $hsmName -KeyName (Get-KeyName) -KeyType RSA -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json"
        }  | Should -Throw
    }
    
    It "Both ReleasePolicyPath and Exportable show up"{
        $keyName = Get-KeyName
        {
            Add-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -KeyType RSA -Exportable -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json"
        }  | Should -Not -Throw
        $key = Get-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName
        $key.ReleasePolicy | Should -Not -BeNullOrEmpty
        $key.Attributes.Exportable | Should -Be $true
    }
}

Describe "Create secure key"{
    It "Create a key without immutable property and release policy" {
        {
            Add-AzKeyVaultKey -HsmName $hsmName -KeyName (Get-KeyName) -KeyType RSA
        } | Should -Not -Throw
    }

    It "Create a key with immutable property but release policy" -skip {
        $keyName = Get-KeyName
        { 
            Add-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -KeyType RSA -Immutable
        } | Should -Throw "Please provide release policy when Immutable is present."
    }
    
    It "Create a key with release policy but immutable property" {
        $keyName = Get-KeyName
        { 
            Add-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -KeyType RSA -Exportable -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json" 
        } | Should -Not -Throw
        $key = Get-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName
        $key.ReleasePolicy | Should -Not -BeNullOrEmpty
        $key.ReleasePolicy.Immutable | Should -Be $false
    }

    It "Create a key with both release policy and immutable property" {
        $keyName = Get-KeyName
        { 
            Add-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -KeyType RSA -Exportable -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json" -Immutable
        } | Should -Not -Throw
        $key = Get-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName
        $key.ReleasePolicy | Should -Not -BeNullOrEmpty
        $key.ReleasePolicy.Immutable | Should -Be $true
    }
}

Describe "Update secure key"{
    
    It "Update a key with immutable property but release policy" -skip {
        $keyName = Get-KeyName
        Add-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -KeyType RSA -Exportable -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json"
        { Update-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -Immutable} | Should -Throw "Please provide release policy when Immutable is present."
    }

    
    It "Update a key with release policy but immutable property" {
        $keyName = Get-KeyName
        Add-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -KeyType RSA -Exportable -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json"
        { Update-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json"} | Should -Not -Throw
        $key = Get-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName
        $key.ReleasePolicy | Should -Not -BeNullOrEmpty
        $key.ReleasePolicy.Immutable | Should -Be $false
    }

    It "Update a key with both release policy and immutable property" {
        $keyName = Get-KeyName
        Add-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -KeyType RSA -Exportable -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json"
        { Update-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json" -Immutable} | Should -Not -Throw
        $updatedKey = Get-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName
        $updatedKey.ReleasePolicy | Should -Not -BeNullOrEmpty
        $updatedKey.ReleasePolicy.Immutable | Should -Be $true
    }

    It "Update an immutable release policy" -skip {
        $keyName = Get-KeyName
        $key =  Add-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -KeyType RSA -Exportable -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json" -Immutable
        $key.ReleasePolicy | Should -Not -BeNullOrEmpty
        $key.ReleasePolicy.Immutable | Should -Be $true
        { Update-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json" } | Should -Throw "Please provide release policy when Immutable is present."
    }

    It "Update a mutable release policy" {
        $keyName = Get-KeyName
        $key =  Add-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -KeyType RSA -Exportable -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json"
        $key.ReleasePolicy | Should -Not -BeNullOrEmpty
        $key.ReleasePolicy.Immutable | Should -Be $false
        { Update-AzKeyVaultKey -HsmName $hsmName -KeyName $keyName -ReleasePolicyPath "$PSScriptRoot\..\Resources\releasepolicy.json"} | Should -Not -Throw
    }
}