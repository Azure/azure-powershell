$TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzsAzureBridgeDownloadedProduct.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Remove-AzsAzureBridgeDownloadedProduct' {
    
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

    It "TestRemoveAzsAzureBridgeDownloadedProduct" -Skip:$("TestRemoveAzsAzureBridgeDownloadedProduct" -in $global:SkippedTests) {
        $global:TestName = "TestRemoveAzsAzureBridgeDownloadedProduct"
        Remove-AzsAzureBridgeDownloadedProduct -ActivationName $global:ActivationName -ResourceGroupName $global:ResourceGroupName -Name $global:ProductName1 -Force
        Get-AzsAzureBridgeDownloadedProduct -ActivationName $global:ActivationName -ResourceGroupName $global:ResourceGroupName -Name $global:ProductName1 | Should Be $null
    }

    It "TestRemoveAzsAzureBridgeDownloadedProductPipeline" -Skip:$("TestRemoveAzsAzureBridgeDownloadedProductPipeline" -in $global:SkippedTests) {
        $global:TestName = "TestRemoveAzsAzureBridgeDownloadedProductPipeline"
        (Get-AzsAzureBridgeDownloadedProduct -ActivationName $global:ActivationName -Name $global:ProductName2 -ResourceGroupName $global:ResourceGroupName ) | Remove-AzsAzureBridgeDownloadedProduct  -Force
        Get-AzsAzureBridgeDownloadedProduct -ActivationName $global:ActivationName -ResourceGroupName $global:ResourceGroupName -Name $global:ProductName2 | Should Be $null
    }
}
