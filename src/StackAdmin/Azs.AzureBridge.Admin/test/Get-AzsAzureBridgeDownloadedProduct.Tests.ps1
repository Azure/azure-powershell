$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsAzureBridgeDownloadedProduct.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzsAzureBridgeDownloadedProduct' {
   
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

    It "TestGetAzsAzureBridgeDownloadedProduct" -Skip:$("TestGetAzsAzureBridgeDownloadedProduct" -in $global:SkippedTests) {
        $global:TestName = "TestGetAzsAzureBridgeDownloadedProduct"
        $DownloadedProducts = (Get-AzsAzureBridgeDownloadedProduct -ActivationName $global:ActivationName -ResourceGroupName $global:ResourceGroupName  )
        foreach ($DownloadedProduct in $DownloadedProducts) {
            ValidateProductInfo $DownloadedProduct
        }
    }

    It "TestGetAzsAzureBridgeDownloadedProductByProductName" -Skip:$("TestGetAzsAzureBridgeDownloadedProductByProductName" -in $global:SkippedTests) {
        $global:TestName = "TestGetAzsAzureBridgeDownloadedProductByProductName"
        $DownloadedProduct = (Get-AzsAzureBridgeDownloadedProduct -ActivationName $global:ActivationName -Name $global:ProductName1 -ResourceGroupName $global:ResourceGroupName  )
        ValidateProductInfo $DownloadedProduct
    }
}
