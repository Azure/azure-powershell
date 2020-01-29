$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzsAzureBridgeProductDownload.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzsAzureBridgeProductDownload' {
    
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

    It "TestDownloadAzsAzureBridgeProduct" -Skip:$("TestDownloadAzsAzureBridgeProduct" -in $global:SkippedTests) {
        $global:TestName = "TestDownloadAzsAzureBridgeProduct"
        Invoke-AzsAzureBridgeProductDownload -ActivationName $global:ActivationName -Name $global:ProductName1 -ResourceGroupName $global:ResourceGroupName -Force -ErrorAction Stop
    }

    It "TestDownloadAzsAzureBridgeProductPipeline" -Skip:$("TestDownloadAzsAzureBridgeProductPipeline" -in $global:SkippedTests) {
        $global:TestName = "TestDownloadAzsAzureBridgeProductPipeline"
        $DownloadedProduct = (Get-AzsAzureBridgeProduct -ActivationName $global:ActivationName -Name $global:ProductName2 -ResourceGroupName $global:ResourceGroupName)  | Invoke-AzsAzureBridgeProductDownload -Force
        ValidateProductInfo $DownloadedProduct
    }
}
