$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsAzureBridgeProduct.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsAzureBridgeProduct' {
    
    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateProductInfo {
            param(
                [Parameter(Mandatory = $true)]
                $Product
            )

            $Product          | Should Not Be $null

            # Resource
            $Product.Id       | Should Not Be $null
            $Product.Name     | Should Not Be $null
            $Product.Type     | Should Not Be $null

            $Product.GalleryItemIdentity    | Should Not Be $null
            $Product.ProductKind         | Should Not Be $null
            $Product.ProductProperties        | Should Not Be $null
            # $Product.Description  | Should Not Be $null
            $Product.DisplayName  | Should Not Be $null

        }
    }

    AfterEach {
        $global:Client = $null
    }

    It "TestListAzsAzureBridgeProduct" -Skip:$("TestListAzsAzureBridgeProduct" -in $global:SkippedTests) {
        $global:TestName = "TestListAzsAzureBridgeProduct"
        $Products = Get-AzsAzureBridgeProduct -ActivationName $global:ActivationName -ResourceGroupName $global:ResourceGroupName
        foreach ($Product in $Products) {
            ValidateProductInfo $Product
        }
    }

    It "TestGetAzsAzureBridgeProductByName" -Skip:$("TestGetAzsAzureBridgeProductByName" -in $global:SkippedTests) {
        $global:TestName = "TestGetAzsAzureBridgeProductByName"
        $Product = Get-AzsAzureBridgeProduct -ActivationName $global:ActivationName -ResourceGroupName $global:ResourceGroupName -Name $global:ProductName1
        ValidateProductInfo $Product
    }
}
