﻿# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Tests CRUD operations of API.
#>
function Api-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all apis
    $apis = Get-AzApiManagementApi -Context $context

    # there should be one API
    Assert-AreEqual 1 $apis.Count
    Assert-NotNull $apis[0].ApiId
    Assert-AreEqual "Echo API" $apis[0].Name
    Assert-Null $apis[0].Description
    Assert-AreEqual "http://echoapi.cloudapp.net/api" $apis[0].ServiceUrl
    Assert-AreEqual echo $apis[0].Path
    Assert-AreEqual 1 $apis[0].Protocols.Length
    Assert-AreEqual https $apis[0].Protocols[0]
    Assert-Null $apis[0].AuthorizationServerId
    Assert-Null $apis[0].AuthorizationScope
    Assert-Null $apis[0].SubscriptionKeyHeaderName
    Assert-Null $apis[0].SubscriptionKeyQueryParamName

    # get by ID
    $apiId = $apis[0].ApiId

    $api = Get-AzApiManagementApi -Context $context -ApiId $apiId

    Assert-AreEqual $apiId $api.ApiId
    Assert-AreEqual "Echo API" $api.Name
    Assert-Null $api.Description
    Assert-AreEqual "http://echoapi.cloudapp.net/api" $api.ServiceUrl
    Assert-AreEqual echo $api.Path
    Assert-AreEqual 1 $api.Protocols.Length
    Assert-AreEqual https $api.Protocols[0]
    Assert-Null $api.AuthorizationServerId
    Assert-Null $api.AuthorizationScope
    Assert-NotNull $api.SubscriptionKeyHeaderName       #TODO: this is odd
    Assert-NotNull $api.SubscriptionKeyQueryParamName   #TODO: this is odd

    # get by Name
    $apiName = $apis[0].Name

    $apis = Get-AzApiManagementApi -Context $context -Name $apiName

    Assert-AreEqual 1 $apis.Count
    Assert-NotNull $apis[0].ApiId
    Assert-AreEqual $apiName $apis[0].Name
    Assert-Null $apis[0].Description
    Assert-AreEqual "http://echoapi.cloudapp.net/api" $apis[0].ServiceUrl
    Assert-AreEqual echo $apis[0].Path
    Assert-AreEqual 1 $apis[0].Protocols.Length
    Assert-AreEqual https $apis[0].Protocols[0]
    Assert-Null $apis[0].AuthorizationServerId
    Assert-Null $apis[0].AuthorizationScope
    Assert-Null $apis[0].SubscriptionKeyHeaderName
    Assert-Null $apis[0].SubscriptionKeyQueryParamName

    # create new api
    $newApiId = getAssetName
    try {
        $newApiName = getAssetName
        $newApiDescription = getAssetName
        $newApiPath = getAssetName
        $newApiServiceUrl = "http://newechoapi.cloudapp.net/newapi"
        $subscriptionKeyParametersHeader = getAssetName
        $subscriptionKeyQueryStringParamName = getAssetName

        $newApi = New-AzApiManagementApi -Context $context -ApiId $newApiId -Name $newApiName -Description $newApiDescription `
            -Protocols @("http", "https") -Path $newApiPath -ServiceUrl $newApiServiceUrl `
            -SubscriptionKeyHeaderName $subscriptionKeyParametersHeader -SubscriptionKeyQueryParamName $subscriptionKeyQueryStringParamName

        Assert-AreEqual $newApiId $newApi.ApiId
        Assert-AreEqual $newApiName $newApi.Name
        Assert-AreEqual $newApiDescription.Description
        Assert-AreEqual $newApiServiceUrl $newApi.ServiceUrl
        Assert-AreEqual $newApiPath $newApi.Path
        Assert-AreEqual 2 $newApi.Protocols.Length
        Assert-AreEqual http $newApi.Protocols[0]
        Assert-AreEqual https $newApi.Protocols[1]
        Assert-Null $newApi.AuthorizationServerId
        Assert-Null $newApi.AuthorizationScope
        Assert-AreEqual $subscriptionKeyParametersHeader $newApi.SubscriptionKeyHeaderName
        Assert-AreEqual $subscriptionKeyQueryStringParamName $newApi.SubscriptionKeyQueryParamName

        # set api
        $newApiName = getAssetName
        $newApiDescription = getAssetName
        $newApiPath = getAssetName
        $newApiServiceUrl = "http://newechoapi.cloudapp.net/newapinew"
        $subscriptionKeyParametersHeader = getAssetName
        $subscriptionKeyQueryStringParamName = getAssetName

        $newApi = Set-AzApiManagementApi -Context $context -ApiId $newApiId -Name $newApiName -Description $newApiDescription `
            -Protocols @("https") -Path $newApiPath -ServiceUrl $newApiServiceUrl `
            -SubscriptionKeyHeaderName $subscriptionKeyParametersHeader -SubscriptionKeyQueryParamName $subscriptionKeyQueryStringParamName `
            -PassThru

        Assert-AreEqual $newApiId $newApi.ApiId
        Assert-AreEqual $newApiName $newApi.Name
        Assert-AreEqual $newApiDescription $newApi.Description
        Assert-AreEqual $newApiServiceUrl $newApi.ServiceUrl
        Assert-AreEqual $newApiPath $newApi.Path
        Assert-AreEqual 1 $newApi.Protocols.Length
        Assert-AreEqual https $newApi.Protocols[0]
        Assert-Null $newApi.AuthorizationServerId
        Assert-Null $newApi.AuthorizationScope
        Assert-AreEqual $subscriptionKeyParametersHeader $newApi.SubscriptionKeyHeaderName
        Assert-AreEqual $subscriptionKeyQueryStringParamName $newApi.SubscriptionKeyQueryParamName
                
        $updatedApiServiceUrl = "http://newechoapi.cloudapp.net/updateapi"
        $updatedApi = Set-AzApiManagementApi -Context $context -ApiId $newApiId -ServiceUrl $updatedApiServiceUrl -PassThru
        Assert-AreEqual $newApiId $updatedApi.ApiId
        Assert-AreEqual $newApiName $updatedApi.Name
        Assert-AreEqual $newApiDescription $updatedApi.Description
        Assert-AreEqual $updatedApiServiceUrl $updatedApi.ServiceUrl
        Assert-AreEqual $newApiPath $updatedApi.Path
        Assert-AreEqual 1 $updatedApi.Protocols.Length
        Assert-AreEqual https $updatedApi.Protocols[0]

        $product = Get-AzApiManagementProduct -Context $context | Select-Object -First 1
        Add-AzApiManagementApiToProduct -Context $context -ApiId $newApiId -ProductId $product.ProductId

        #get by product id
        $found = 0
        $apis = Get-AzApiManagementApi -Context $context -ProductId $product.ProductId
        for ($i = 0; $i -lt $apis.Count; $i++) {
            if ($apis[$i].ApiId -eq $newApiId) {
                $found = 1
            }
        }
        Assert-AreEqual 1 $found

        Remove-AzApiManagementApiFromProduct -Context $context -ApiId $newApiId -ProductId $product.ProductId
        $found = 0
        $apis = Get-AzApiManagementApi -Context $context -ProductId $product.ProductId
        for ($i = 0; $i -lt $apis.Count; $i++) {
            if ($apis[$i].ApiId -eq $newApiId) {
                $found = 1
            }
        }
        Assert-AreEqual 0 $found
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $newApiId -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests CRUD operations for Cloning an API into a ApiVersionSet.
#>
function ApiClone-Test {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all apis
    $apis = Get-AzApiManagementApi -Context $context

    # there should be one API
    Assert-AreEqual 1 $apis.Count
    Assert-NotNull $apis[0].ApiId
    Assert-AreEqual "Echo API" $apis[0].Name
    Assert-Null $apis[0].Description
    Assert-AreEqual "http://echoapi.cloudapp.net/api" $apis[0].ServiceUrl
    Assert-AreEqual echo $apis[0].Path
    Assert-AreEqual 1 $apis[0].Protocols.Length
    Assert-AreEqual https $apis[0].Protocols[0]
    Assert-Null $apis[0].AuthorizationServerId
    Assert-Null $apis[0].AuthorizationScope
    Assert-Null $apis[0].SubscriptionKeyHeaderName
    Assert-Null $apis[0].SubscriptionKeyQueryParamName

    # get by ID
    $apiId = $apis[0].ApiId

    $api = Get-AzApiManagementApi -Context $context -ApiId $apiId

    Assert-AreEqual $apiId $api.ApiId
    Assert-AreEqual "Echo API" $api.Name
    Assert-Null $api.Description
    Assert-AreEqual "http://echoapi.cloudapp.net/api" $api.ServiceUrl
    Assert-AreEqual echo $api.Path
    Assert-AreEqual 1 $api.Protocols.Length
    Assert-AreEqual https $api.Protocols[0]
    Assert-Null $api.AuthorizationServerId
    Assert-Null $api.AuthorizationScope
    Assert-NotNull $api.SubscriptionKeyHeaderName       #TODO: this is odd
    Assert-NotNull $api.SubscriptionKeyQueryParamName   #TODO: this is odd

    $echoapiOperations = Get-AzApiManagementOperation -Context $context -ApiId $apiId

    Assert-NotNull $echoapiOperations

    # create new api clone
    $newApiId = getAssetName
    # create new apiverionset
    $newApiVersionSetId = getAssetName
    # create an api clone into a version Set
    $newApiInVersionId = getAssetName

    try {

        $newVersionSetName = getAssetName
        $queryName = getAssetName
        $description = getAssetName

        #create a new version set
        $newApiVersionSet = New-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId -Name $newVersionSetName -Scheme Query `
            -QueryName $queryName -Description $description

        Assert-AreEqual $newApiVersionSetId $newApiVersionSet.ApiVersionSetId
        Assert-AreEqual $newVersionSetName $newApiVersionSet.DisplayName
        Assert-AreEqual $description $newApiVersionSet.Description
        Assert-AreEqual Query $newApiVersionSet.VersioningScheme
        Assert-AreEqual $queryName $newApiVersionSet.VersionQueryName
        Assert-Null $newApiVersionSet.VersionHeaderName

        $newApiName = getAssetName
        $newApiDescription = getAssetName
        $newApiPath = getAssetName
        $newApiServiceUrl = "http://newechoapi.cloudapp.net/newapi"

        # create a clone of the echo-api copying all operations, tags, policies but with new ServiceUrl and Path
        $newApi = New-AzApiManagementApi -Context $context -ApiId $newApiId -Name $newApiName -Description $newApiDescription `
            -Protocols @("http", "https") -Path $newApiPath -ServiceUrl $newApiServiceUrl `
            -SourceApiId $apiId

        Assert-AreEqual $newApiId $newApi.ApiId
        Assert-AreEqual $newApiName $newApi.Name
        Assert-AreEqual $newApiDescription.Description
        Assert-AreEqual $newApiServiceUrl $newApi.ServiceUrl
        Assert-AreEqual $newApiPath $newApi.Path
        Assert-AreEqual 2 $newApi.Protocols.Length
        Assert-AreEqual http $newApi.Protocols[0]
        Assert-AreEqual https $newApi.Protocols[1]
        Assert-Null $newApi.AuthorizationServerId
        Assert-Null $newApi.AuthorizationScope

        # compare all operations got copied
        $newApiOperations = Get-AzApiManagementOperation -Context $context -ApiId $newApiId

        Assert-AreEqual $echoapiOperations.Count $newApiOperations.Count

        for ($i = 0; $i -lt $newApiOperations.Count; $i++) {
            Assert-AreEqual $newApiId $newApiOperations[$i].ApiId

            $operation = Get-AzApiManagementOperation -Context $context -ApiId $newApiId -OperationId $newApiOperations[$i].OperationId

            Assert-AreEqual $newApiId $operation.ApiId
            Assert-AreEqual $newApiOperations[$i].OperationId $operation.OperationId
            Assert-AreEqual $newApiOperations[$i].Name $operation.Name
            Assert-AreEqual $newApiOperations[$i].Description $operation.Description
            Assert-AreEqual $newApiOperations[$i].Method $operation.Method
            Assert-AreEqual $newApiOperations[$i].UrlTemplate $operation.UrlTemplate
        }

        # create a version of the Cloned Api
        $newApiCloneName = getAssetName
        $newApiCloneDescription = getAssetName
        $newApiClonePath = getAssetName
        $newApiCloneServiceUrl = "http://newechoapi.cloudapp.net/newapiv2"
        
        # create a Version of the new API in a Version Set 
        $newApiVersion = New-AzApiManagementApi -Context $context -ApiId $newApiInVersionId -Name $newApiCloneName -Description $newApiCloneDescription `
            -Protocols @("http", "https") -Path $newApiClonePath -ServiceUrl $newApiCloneServiceUrl `
            -SourceApiId $apiId -ApiVersion "2" -ApiVersionSetId $newApiVersionSet.ApiVersionSetId -SubscriptionRequired

        Assert-AreEqual $newApiInVersionId $newApiVersion.ApiId
        Assert-AreEqual $newApiCloneName $newApiVersion.Name
        Assert-AreEqual $newApiCloneDescription $newApiVersion.Description
        Assert-AreEqual $newApiCloneServiceUrl $newApiVersion.ServiceUrl
        Assert-AreEqual $newApiClonePath $newApiVersion.Path
        Assert-AreEqual 2 $newApiVersion.Protocols.Length
        Assert-AreEqual http $newApiVersion.Protocols[0]
        Assert-AreEqual https $newApiVersion.Protocols[1]
        Assert-AreEqual "2" $newApiVersion.APIVersion
        Assert-AreEqual $newApiVersionSet.Id $newApiVersion.ApiVersionSetId
		Assert-AreEqual $TRUE $newApiVersion.SubscriptionRequired
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $newApiId -PassThru
        Assert-True { $removed }

        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $newApiInVersionId -PassThru
        Assert-True { $removed }

        # remove created apiversionset
        $removed = Remove-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests API import/export for Wadl Type Api.
#>
function Api-ImportExportWadlTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    $wadlPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "WADLYahoo.xml"
    $path = "wadlapi"
    $wadlApiId = getAssetName

    try {
        # import api from file
        $api = Import-AzApiManagementApi -Context $context -ApiId $wadlApiId -SpecificationPath $wadlPath -SpecificationFormat Wadl -Path $path

        Assert-AreEqual $wadlApiId $api.ApiId
        Assert-AreEqual $path $api.Path
        
        $apiSchemas = Get-AzApiManagementApiSchema -Context $context -ApiId $wadlApiId
        Assert-NotNull $apiSchemas
        Assert-AreEqual 1 $apiSchemas.Count
        Assert-AreEqual WadlGrammar $apiSchemas[0].SchemaDocumentContentType
        Assert-AreEqual $wadlApiId $apiSchemas[0].ApiId

        # commented as powershell test framework on running test in playback mode, throws 403, as the exported link of file
        # gets expired
        # export api to pipeline
        # $result = Export-AzApiManagementApi -Context $context -ApiId $wadlApiId -SpecificationFormat Wadl

        # Assert-True {$result -like '*<doc title="Yahoo News Search">Yahoo News Search API</doc>*'}
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $wadlApiId -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests API import/export for Swagger Type Api.
#>
function Api-ImportExportSwaggerTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    $swaggerPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "SwaggerPetStoreV2.json"
    $swaggerUrl = "http://petstore.swagger.io/v2/swagger.json"
    $path1 = "swaggerapifromFile"
    $path2 = "swaggerapifromUrl"
    $swaggerApiId1 = getAssetName
    $swaggerApiId2 = getAssetName

    try {
        # import api from file
        $api = Import-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -SpecificationPath $swaggerPath -SpecificationFormat Swagger -Path $path1

        Assert-AreEqual $swaggerApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path

        # commented as powershell test framework on running test in playback mode, throws 403, as the exported link of file
        # gets expired
        # export api to pipeline
        #$result = Export-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -SpecificationFormat Swagger
        #Assert-NotNull $result
        #Assert-True {$result -like '*"title": "Swagger Petstore Extensive"*'}

        # import api from Url
        $api = Import-AzApiManagementApi -Context $context -ApiId $swaggerApiId2 -SpecificationUrl $swaggerUrl -SpecificationFormat Swagger -Path $path2

        Assert-AreEqual $swaggerApiId2 $api.ApiId
        Assert-AreEqual $path2 $api.Path

        $newName = "apimPetstore"
        $newDescription = "Swagger api via Apim"
        $api = Set-AzApiManagementApi -InputObject $api -Name $newName -Description $newDescription -ServiceUrl $api.ServiceUrl -Protocols $api.Protocols -PassThru
        Assert-AreEqual $swaggerApiId2 $api.ApiId
        Assert-AreEqual $path2 $api.Path
        Assert-AreEqual $newName $api.Name
        Assert-AreEqual $newDescription $api.Description
        Assert-AreEqual 'Http' $api.ApiType
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -PassThru
        Assert-True { $removed }

        $removed = Remove-AzApiManagementApi -Context $context -ApiId $swaggerApiId2 -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests API import from Wsdl type and export Api.
#>
function Api-ImportExportWsdlTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName
    $wsdlUrl = "http://fazioapisoap.azurewebsites.net/fazioService.svc?singleWSDL"   
    $wsdlPath1 = Join-Path (Join-Path "$TestOutputRoot" "Resources") "Weather.wsdl"
    $path1 = "soapapifromFile"
    $path2 = "soapapifromUrl"
    $wsdlApiId1 = getAssetName
    $wsdlApiId2 = getAssetName
    $wsdlServiceName1 = "Weather" # from file Weather.wsdl
    $wsdlEndpointName1 = "WeatherSoap" # from file Weather.wsdl
    $wsdlServiceName2 = "OrdersAPI" # from url FazioSoap
    $wsdlEndpointName2 = "basic" # from url FazioSoap
    
    try {
        # import api from file
        $api = Import-AzApiManagementApi -Context $context -ApiId $wsdlApiId1 -SpecificationPath $wsdlPath1 -SpecificationFormat Wsdl -Path $path1 `
            -WsdlServiceName $wsdlServiceName1 -WsdlEndpointName $wsdlEndpointName1 -ApiType Soap

        Assert-AreEqual $wsdlApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path
        Assert-AreEqual 'Soap' $api.ApiType
      
        # commented as powershell test framework on running test in playback mode, throws 403, as the exported link of file
        # gets expired
        # export api to pipeline
        #$result = Export-AzApiManagementApi -Context $context -ApiId $wsdlApiId1 -SpecificationFormat Wsdl
        #Assert-NotNull $result
        #Assert-True {$result -like '*<wsdl:service name="Weather"*'}

        # import api from Url
        $api = Import-AzApiManagementApi -Context $context -ApiId $wsdlApiId2 -SpecificationUrl $wsdlUrl -SpecificationFormat Wsdl -Path $path2 `
            -WsdlServiceName $wsdlServiceName2 -WsdlEndpointName $wsdlEndpointName2 -ApiType Soap

        Assert-AreEqual $wsdlApiId2 $api.ApiId
        Assert-AreEqual $path2 $api.Path

        $apiSchemas = Get-AzApiManagementApiSchema -Context $context -ApiId $wsdlApiId2
        Assert-NotNull $apiSchemas
        Assert-AreEqual 4 $apiSchemas.Count
        Assert-AreEqual XsdSchema $apiSchemas[0].SchemaDocumentContentType
        Assert-AreEqual $wsdlApiId2 $apiSchemas[0].ApiId

        $newName = "apimSoap"
        $newDescription = "Soap api via Apim"
        $api = Set-AzApiManagementApi -InputObject $api -Name $newName -Description $newDescription -ServiceUrl $api.ServiceUrl -Protocols $api.Protocols -PassThru
        Assert-AreEqual $wsdlApiId2 $api.ApiId
        Assert-AreEqual $path2 $api.Path
        Assert-AreEqual $newName $api.Name
        Assert-AreEqual $newDescription $api.Description
        Assert-AreEqual 'Soap' $api.ApiType

        # commented as powershell test framework on running test in playback mode, throws 403, as the exported link of file
        # gets expired
        # export api to pipeline
        #$result = Export-AzApiManagementApi -Context $context -ApiId $wsdlApiId2 -SpecificationFormat Wsdl
        #Assert-NotNull $result
        #Assert-True {$result -like '*<wsdl:service name="OrdersAPI"*'}
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $wsdlApiId1 -PassThru
        Assert-True { $removed }

        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $wsdlApiId2 -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests API import from OpenApi type and export Api.
#>
function Api-ImportExportOpenApiTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName
    $openApiUrl = "https://raw.githubusercontent.com/OAI/OpenAPI-Specification/master/examples/v3.0/petstore.yaml"   
    $yamlPath1 = Join-Path (Join-Path "$TestOutputRoot" "Resources") "uspto.yml"
    $path1 = "openapifromFile"
    $path2 = "openapifromUrl"
    $openApiId1 = getAssetName
    $openApiId2 = getAssetName
    
    try {
        # import api from file
        $api = Import-AzApiManagementApi -Context $context -ApiId $openApiId1 -SpecificationPath $yamlPath1 -SpecificationFormat OpenApi -Path $path1

        Assert-AreEqual $openApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path

        # import api from Url
        $api = Import-AzApiManagementApi -Context $context -ApiId $openApiId2 -SpecificationUrl $openApiUrl -SpecificationFormat OpenApi -Path $path2

        Assert-AreEqual $openApiId2 $api.ApiId
        Assert-AreEqual $path2 $api.Path

         # get openapi schema
        $apiSchemas = Get-AzApiManagementApiSchema -Context $context -ApiId $openApiId1
        Assert-NotNull $apiSchemas
        Assert-AreEqual 1 $apiSchemas.Count
        Assert-AreEqual OpenApiComponents $apiSchemas[0].SchemaDocumentContentType
        Assert-AreEqual $openApiId1 $apiSchemas[0].ApiId

        $newName = "apimPetstore"
        $newDescription = "Open api via Apim"
        $api = Set-AzApiManagementApi -InputObject $api -Name $newName -Description $newDescription -ServiceUrl $api.ServiceUrl -Protocols $api.Protocols -PassThru
        Assert-AreEqual $openApiId2 $api.ApiId
        Assert-AreEqual $path2 $api.Path
        Assert-AreEqual $newName $api.Name
        Assert-AreEqual $newDescription $api.Description
        Assert-AreEqual 'Http' $api.ApiType
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $openApiId1 -PassThru
        Assert-True { $removed }

        $removed = Remove-AzApiManagementApi -Context $context -ApiId $openApiId2 -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests API import from OpenApi Json type and export Api.
#>
function Api-ImportExportOpenApiJsonTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName
    $jsonPath1 = Join-Path (Join-Path "$TestOutputRoot" "Resources") "petstoreOpenApi.json"
    $path1 = "openapifromFile"
    $openApiId1 = getAssetName
    
    try {
        # import api from file
        $api = Import-AzApiManagementApi -Context $context -ApiId $openApiId1 -SpecificationPath $jsonPath1 -SpecificationFormat OpenApi -Path $path1

        Assert-AreEqual $openApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path

         # get openapi schema
        $apiSchemas = Get-AzApiManagementApiSchema -Context $context -ApiId $openApiId1
        Assert-NotNull $apiSchemas
        Assert-AreEqual 1 $apiSchemas.Count
        Assert-AreEqual OpenApiComponents $apiSchemas[0].SchemaDocumentContentType
        Assert-AreEqual $openApiId1 $apiSchemas[0].ApiId

        $newName = "apimPetstore"
        $newDescription = "Open api via Apim"
        $api = Set-AzApiManagementApi -InputObject $api -Name $newName -Description $newDescription -ServiceUrl $api.ServiceUrl -Protocols $api.Protocols -PassThru
        Assert-AreEqual $openApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path
        Assert-AreEqual $newName $api.Name
        Assert-AreEqual $newDescription $api.Description
        Assert-AreEqual 'Http' $api.ApiType

        # commented as powershell test framework on running test in playback mode, throws 403, as the exported link of file
        # gets expired
        # export api to pipeline
        #$result = Export-AzApiManagementApi -Context $context -ApiId $openApiId1 -SpecificationFormat OpenApiJson
        #Assert-NotNull $result
        #Assert-True {$result -like '*<wsdl:service name="OrdersAPI"*'}
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $openApiId1 -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests API Schema for Swagger Type Api.
#>
function ApiSchema-SwaggerCRUDTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    $swaggerDefinitionsFilePath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "petstoreschema.json"

    # create new api
    $newApiId = getAssetName
    $newSchemaId = getAssetName
    try {
        $newApiName = getAssetName
        $newApiDescription = getAssetName
        $newApiPath = getAssetName
        $newApiServiceUrl = "http://newechoapi.cloudapp.net/newapi"
        $subscriptionKeyParametersHeader = getAssetName
        $subscriptionKeyQueryStringParamName = getAssetName

        $newApi = New-AzApiManagementApi -Context $context -ApiId $newApiId -Name $newApiName -Description $newApiDescription `
            -Protocols @("http", "https") -Path $newApiPath -ServiceUrl $newApiServiceUrl `
            -SubscriptionKeyHeaderName $subscriptionKeyParametersHeader -SubscriptionKeyQueryParamName $subscriptionKeyQueryStringParamName

        Assert-AreEqual $newApiId $newApi.ApiId
        Assert-AreEqual $newApiName $newApi.Name
        Assert-AreEqual $newApiDescription.Description
        Assert-AreEqual $newApiServiceUrl $newApi.ServiceUrl
        Assert-AreEqual $newApiPath $newApi.Path
        Assert-AreEqual 2 $newApi.Protocols.Length

        # there should be no schema initially
        $apiSchemas = Get-AzApiManagementApiSchema -Context $context -ApiId $newApiId
        Assert-AreEqual 0 $apiSchemas.Count

        $apiSchema = New-AzApiManagementApiSchema -Context $context -ApiId $newApiId -SchemaId $newSchemaId -SchemaDocumentContentType SwaggerDefinition `
            -SchemaDocumentFilePath $swaggerDefinitionsFilePath
        
        Assert-NotNull $apiSchema
        Assert-AreEqual $newSchemaId $apiSchema.SchemaId
        Assert-AreEqual $newApiId $apiSchema.ApiId
        Assert-AreEqual SwaggerDefinition $apiSchema.SchemaDocumentContentType
        Assert-NotNull $apiSchema.SchemaDocument

        #get api schema by Id
        $getApiSchema = Get-AzApiManagementApiSchema -ResourceId $apiSchema.Id
        Assert-AreEqual $apiSchema.SchemaId $getApiSchema.SchemaId
        Assert-AreEqual $apiSchema.ApiId $getApiSchema.ApiId
        Assert-AreEqual SwaggerDefinition $getApiSchema.SchemaDocumentContentType        

        #get schema list
        $apiSchemas = Get-AzApiManagementApiSchema -Context $context -ApiId $newApiId
        Assert-AreEqual 1 $apiSchemas.Count
        Assert-AreEqual $getApiSchema.SchemaId $apiSchemas[0].SchemaId
        Assert-AreEqual SwaggerDefinition $apiSchema.SchemaDocumentContentType
        Assert-AreEqual $getApiSchema.ApiId $apiSchemas[0].ApiId

        # set api Schema
        $apiSchema = Set-AzApiManagementApiSchema -InputObject $getApiSchema -SchemaDocumentContentType "application/json" -PassThru
        Assert-NotNull $apiSchema
        Assert-AreEqual $getApiSchema.SchemaId $apiSchema.SchemaId
        Assert-AreEqual $newApiId $apiSchema.ApiId
        Assert-AreEqual "application/json" $apiSchema.SchemaDocumentContentType

        Remove-AzApiManagementApiSchema -ResourceId $apiSchema.Id
    }
    finally {
        # remove created api schema
        $removed = Remove-AzApiManagementApiSchema -Context $context -ApiId $newApiId -SchemaId $newSchemaId -PassThru
        Assert-True { $removed }

        $removed = Remove-AzApiManagementApi -Context $context -ApiId $newApiId -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests API Schema for WSDL Type Api.
#>
function ApiSchema-WsdlCRUDTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    $wsdlPath1 = Join-Path (Join-Path "$TestOutputRoot" "Resources") "Weather.wsdl"
    $wsdlFileSchema = Join-Path (Join-Path "$TestOutputRoot" "Resources") "weather.xsl"
    $path1 = "soapapifromFile"
    $wsdlServiceName1 = "Weather" # from file Weather.wsdl
    $wsdlEndpointName1 = "WeatherSoap" # from file Weather.wsdl

    # create new api
    $newApiId = getAssetName
    $newSchemaId = getAssetName
    try {
        
        # import api from file
        $api = Import-AzApiManagementApi -Context $context -ApiId $newApiId -SpecificationPath $wsdlPath1 -SpecificationFormat Wsdl -Path $path1 `
               -WsdlServiceName $wsdlServiceName1 -WsdlEndpointName $wsdlEndpointName1 -ApiType Soap

        Assert-AreEqual $newApiId $api.ApiId
        Assert-AreEqual $path1 $api.Path
        Assert-AreEqual 'Soap' $api.ApiType

        # there should be one schema initially
        $apiSchemas = Get-AzApiManagementApiSchema -Context $context -ApiId $newApiId
        Assert-AreEqual 1 $apiSchemas.Count
        Assert-AreEqual XsdSchema $apiSchemas[0].SchemaDocumentContentType
        Assert-AreEqual $newApiId $apiSchemas[0].ApiId

        $newSchemaId = $apiSchemas[0].SchemaId
        $apiSchema = New-AzApiManagementApiSchema -Context $context -ApiId $newApiId -SchemaId $newSchemaId -SchemaDocumentContentType XsdSchema `
            -SchemaDocumentFilePath $wsdlFileSchema
        
        Assert-NotNull $apiSchema
        Assert-AreEqual $newSchemaId $apiSchema.SchemaId
        Assert-AreEqual $newApiId $apiSchema.ApiId
        Assert-AreEqual XsdSchema $apiSchema.SchemaDocumentContentType
        Assert-NotNull $apiSchema.SchemaDocument

        #get api schema by Id
        $getApiSchema = Get-AzApiManagementApiSchema -ResourceId $apiSchema.Id
        Assert-AreEqual $apiSchema.SchemaId $getApiSchema.SchemaId
        Assert-AreEqual $apiSchema.ApiId $getApiSchema.ApiId
        Assert-AreEqual XsdSchema $getApiSchema.SchemaDocumentContentType
        Assert-AreEqual $apiSchema.SchemaDocument $getApiSchema.SchemaDocument

        #get schema list
        $apiSchemas = Get-AzApiManagementApiSchema -Context $context -ApiId $newApiId
        Assert-AreEqual 1 $apiSchemas.Count
        Assert-AreEqual $getApiSchema.SchemaId $apiSchemas[0].SchemaId
        Assert-AreEqual $getApiSchema.ApiId $apiSchemas[0].ApiId
        Assert-AreEqual $getApiSchema.SchemaDocumentContentType $apiSchemas[0].SchemaDocumentContentType

        # set api Schema
        $apiSchema = Set-AzApiManagementApiSchema -InputObject $getApiSchema -SchemaDocumentContentType "application/json" -PassThru
        Assert-NotNull $apiSchema
        Assert-AreEqual $getApiSchema.SchemaId $apiSchema.SchemaId
        Assert-AreEqual $newApiId $apiSchema.ApiId
        Assert-AreEqual "application/json" $apiSchema.SchemaDocumentContentType
        Assert-AreEqual $getApiSchema.SchemaDocument $apiSchema.SchemaDocument
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $newApiId -PassThru
        Assert-True { $removed }
    }
}


<#
.SYNOPSIS
Tests CRUD operations of Operations.
#>
function Operations-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get api
    $api = Get-AzApiManagementApi -Context $context -Name 'Echo API' | Select-Object -First 1

    # get all api operations
    $operations = Get-AzApiManagementOperation -Context $context -ApiId $api.ApiId

    Assert-AreEqual 6 $operations.Count
    for ($i = 0; $i -lt $operations.Count; $i++) {
        Assert-AreEqual $api.ApiId $operations[$i].ApiId

        $operation = Get-AzApiManagementOperation -Context $context -ApiId $api.ApiId -OperationId $operations[$i].OperationId

        Assert-AreEqual $api.ApiId $operation.ApiId
        Assert-AreEqual $operations[$i].OperationId $operation.OperationId
        Assert-AreEqual $operations[$i].Name $operation.Name
        Assert-AreEqual $operations[$i].Description $operation.Description
        Assert-AreEqual $operations[$i].Method $operation.Method
        Assert-AreEqual $operations[$i].UrlTemplate $operation.UrlTemplate
    }

    #add new operation
    $newOperationId = getAssetName
    try {
        $newOperationName = getAssetName
        $newOperationMethod = "PATCH"
        $newperationUrlTemplate = "/resource/{rid}?q={query}"
        $newOperationDescription = getAssetName
        $newOperationRequestDescription = getAssetName

        $newOperationRequestHeaderParamName = getAssetName
        $newOperationRequestHeaderParamDescr = getAssetName
        $newOperationRequestHeaderParamIsRequired = $TRUE
        $newOperationRequestHeaderParamDefaultValue = getAssetName
        $newOperationRequestHeaderParamType = "string"

        $newOperationRequestParmName = getAssetName
        $newOperationRequestParamDescr = getAssetName
        $newOperationRequestParamIsRequired = $TRUE
        $newOperationRequestParamDefaultValue = getAssetName
        $newOperationRequestParamType = "string"

        $newOperationRequestRepresentationContentType = "application/json"
        $newOperationRequestRepresentationSample = getAssetName

        $newOperationResponseDescription = getAssetName
        $newOperationResponseStatusCode = 1980785443;
        $newOperationResponseRepresentationContentType = getAssetName
        $newOperationResponseRepresentationSample = getAssetName

        #create parameters declared in UrlTemplate
        $rid = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementParameter
        $rid.Name = "rid"
        $rid.Description = "Resource identifier"
        $rid.Type = "string"

        $query = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementParameter
        $query.Name = "query"
        $query.Description = "Query string"
        $query.Type = "string"

        #create request
        $request = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementRequest
        $request.Description = "Create/update resource request"

        #create query parameters for the request
        $dummyQp = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementParameter
        $dummyQp.Name = $newOperationRequestParmName
        $dummyQp.Description = $newOperationRequestParamDescr
        $dummyQp.Type = $newOperationRequestParamType
        $dummyQp.Required = $newOperationRequestParamIsRequired
        $dummyQp.DefaultValue = $newOperationRequestParamDefaultValue
        $dummyQp.Values = @($newOperationRequestParamDefaultValue)
        $request.QueryParameters = @($dummyQp)

        #create headers for the request
        $header = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementParameter
        $header.Name = $newOperationRequestHeaderParamName
        $header.Description = $newOperationRequestHeaderParamDescr
        $header.DefaultValue = $newOperationRequestHeaderParamDefaultValue
        $header.Values = @($newOperationRequestHeaderParamDefaultValue)
        $header.Type = $newOperationRequestHeaderParamType
        $header.Required = $newOperationRequestHeaderParamIsRequired
        $request.Headers = @($header)

        #create request representation
        $requestRepresentation = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementRepresentation
        $requestRepresentation.ContentType = $newOperationRequestRepresentationContentType
        $requestRepresentation.Sample = $newOperationRequestRepresentationSample
        $request.Representations = @($requestRepresentation)

        #create response
        $response = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementResponse
        $response.StatusCode = $newOperationResponseStatusCode
        $response.Description = $newOperationResponseDescription

        #create response representation
        $responseRepresentation = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementRepresentation
        $responseRepresentation.ContentType = $newOperationResponseRepresentationContentType
        $responseRepresentation.Sample = $newOperationResponseRepresentationSample
        $response.Representations = @($responseRepresentation)

        $newOperation = New-AzApiManagementOperation –Context $context –ApiId $api.ApiId –OperationId $newOperationId –Name $newOperationName `
            –Method $newOperationMethod –UrlTemplate $newperationUrlTemplate –Description $newOperationDescription –TemplateParameters @($rid, $query) –Request $request –Responses @($response)

        Assert-AreEqual $api.ApiId $newOperation.ApiId
        Assert-AreEqual $newOperationId $newOperation.OperationId
        Assert-AreEqual $newOperationName $newOperation.Name
        Assert-AreEqual $newOperationMethod $newOperation.Method
        Assert-AreEqual $newperationUrlTemplate $newOperation.UrlTemplate
        Assert-AreEqual $newOperationDescription $newOperation.Description

        Assert-NotNull $newOperation.TemplateParameters
        Assert-AreEqual 2 $newOperation.TemplateParameters.Count
        Assert-AreEqual $rid.Name $newOperation.TemplateParameters[0].Name
        Assert-AreEqual $rid.Description $newOperation.TemplateParameters[0].Description
        Assert-AreEqual $rid.Type $newOperation.TemplateParameters[0].Type
        Assert-AreEqual $query.Name $newOperation.TemplateParameters[1].Name
        Assert-AreEqual $query.Description $newOperation.TemplateParameters[1].Description
        Assert-AreEqual $query.Type $newOperation.TemplateParameters[1].Type

        Assert-NotNull $newOperation.Request
        Assert-AreEqual $request.Description $newOperation.Request.Description
        Assert-NotNull $newOperation.Request.QueryParameters
        Assert-AreEqual 1 $newOperation.Request.QueryParameters.Count
        Assert-AreEqual $dummyQp.Name $newOperation.Request.QueryParameters[0].Name
        Assert-AreEqual $dummyQp.Description $newOperation.Request.QueryParameters[0].Description
        Assert-AreEqual $dummyQp.Type $newOperation.Request.QueryParameters[0].Type
        Assert-AreEqual $dummyQp.Required $newOperation.Request.QueryParameters[0].Required
        Assert-AreEqual $dummyQp.DefaultValue $newOperation.Request.QueryParameters[0].DefaultValue

        Assert-AreEqual 1 $newOperation.Request.Headers.Count
        Assert-AreEqual $header.Name $newOperation.Request.Headers[0].Name
        Assert-AreEqual $header.Description $newOperation.Request.Headers[0].Description
        Assert-AreEqual $header.Type $newOperation.Request.Headers[0].Type
        Assert-AreEqual $header.Required $newOperation.Request.Headers[0].Required
        Assert-AreEqual $header.DefaultValue $newOperation.Request.Headers[0].DefaultValue

        Assert-NotNull $newOperation.Responses
        Assert-AreEqual 1 $newOperation.Responses.Count
        Assert-AreEqual $newOperationResponseStatusCode $newOperation.Responses[0].StatusCode
        Assert-AreEqual $newOperationResponseDescription $newOperation.Responses[0].Description
        Assert-NotNull $newOperation.Responses[0].Representations
        Assert-AreEqual 1 $newOperation.Responses[0].Representations.Count
        Assert-AreEqual $newOperationResponseRepresentationContentType $newOperation.Responses[0].Representations[0].ContentType
        Assert-AreEqual $newOperationResponseRepresentationSample $newOperation.Responses[0].Representations[0].Sample

        #change operation

        $newOperationName = getAssetName
        $newOperationMethod = "PUT"
        $newperationUrlTemplate = "/resource/{xrid}?q={xquery}"
        $newOperationDescription = getAssetName
        $newOperationRequestDescription = getAssetName

        $newOperationRequestHeaderParamName = getAssetName
        $newOperationRequestHeaderParamDescr = getAssetName
        $newOperationRequestHeaderParamIsRequired = $TRUE
        $newOperationRequestHeaderParamDefaultValue = getAssetName
        $newOperationRequestHeaderParamType = "string"

        $newOperationRequestParmName = getAssetName
        $newOperationRequestParamDescr = getAssetName
        $newOperationRequestParamIsRequired = $TRUE
        $newOperationRequestParamDefaultValue = getAssetName
        $newOperationRequestParamType = "string"

        $newOperationRequestRepresentationContentType = "application/json"
        $newOperationRequestRepresentationSample = getAssetName

        $newOperationResponseDescription = getAssetName
        $newOperationResponseStatusCode = 1980785443;
        $newOperationResponseRepresentationContentType = getAssetName
        $newOperationResponseRepresentationSample = getAssetName

        #create parameters declared in UrlTemplate
        $rid = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementParameter
        $rid.Name = "xrid"
        $rid.Description = "Resource identifier modified"
        $rid.Type = "string"

        $query = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementParameter
        $query.Name = "xquery"
        $query.Description = "Query string modified"
        $query.Type = "string"

        #create request
        $request = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementRequest
        $request.Description = "Create/update resource request modified"

        #create query parameters for the request
        $dummyQp = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementParameter
        $dummyQp.Name = $newOperationRequestParmName
        $dummyQp.Description = $newOperationRequestParamDescr
        $dummyQp.Type = $newOperationRequestParamType
        $dummyQp.Required = $newOperationRequestParamIsRequired
        $dummyQp.DefaultValue = $newOperationRequestParamDefaultValue
        $dummyQp.Values = @($newOperationRequestParamDefaultValue)
        $request.QueryParameters = @($dummyQp)

        #create headers for the request
        $header = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementParameter
        $header.Name = $newOperationRequestHeaderParamName
        $header.Description = $newOperationRequestHeaderParamDescr
        $header.DefaultValue = $newOperationRequestHeaderParamDefaultValue
        $header.Values = @($newOperationRequestHeaderParamDefaultValue)
        $header.Type = $newOperationRequestHeaderParamType
        $header.Required = $newOperationRequestHeaderParamIsRequired
        $request.Headers = @($header)

        #create request representation
        $requestRepresentation = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementRepresentation
        $requestRepresentation.ContentType = $newOperationRequestRepresentationContentType
        $requestRepresentation.Sample = $newOperationRequestRepresentationSample
        $request.Representations = @($requestRepresentation)

        #create response
        $response = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementResponse
        $response.StatusCode = $newOperationResponseStatusCode
        $response.Description = $newOperationResponseDescription

        #create response representation
        $responseRepresentation = New-Object –TypeName Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models.PsApiManagementRepresentation
        $responseRepresentation.ContentType = $newOperationResponseRepresentationContentType
        $responseRepresentation.Sample = $newOperationResponseRepresentationSample
        $response.Representations = @($responseRepresentation)

        $newOperation = Set-AzApiManagementOperation –Context $context –ApiId $api.ApiId –OperationId $newOperationId –Name $newOperationName `
            –Method $newOperationMethod –UrlTemplate $newperationUrlTemplate –Description $newOperationDescription –TemplateParameters @($rid, $query) –Request $request –Responses @($response) -PassThru

        Assert-AreEqual $api.ApiId $newOperation.ApiId
        Assert-AreEqual $newOperationId $newOperation.OperationId
        Assert-AreEqual $newOperationName $newOperation.Name
        Assert-AreEqual $newOperationMethod $newOperation.Method
        Assert-AreEqual $newperationUrlTemplate $newOperation.UrlTemplate
        Assert-AreEqual $newOperationDescription $newOperation.Description

        Assert-NotNull $newOperation.TemplateParameters
        Assert-AreEqual 2 $newOperation.TemplateParameters.Count
        Assert-AreEqual $rid.Name $newOperation.TemplateParameters[0].Name
        Assert-AreEqual $rid.Description $newOperation.TemplateParameters[0].Description
        Assert-AreEqual $rid.Type $newOperation.TemplateParameters[0].Type
        Assert-AreEqual $query.Name $newOperation.TemplateParameters[1].Name
        Assert-AreEqual $query.Description $newOperation.TemplateParameters[1].Description
        Assert-AreEqual $query.Type $newOperation.TemplateParameters[1].Type

        Assert-NotNull $newOperation.Request
        Assert-AreEqual $request.Description $newOperation.Request.Description
        Assert-NotNull $newOperation.Request.QueryParameters
        Assert-AreEqual 1 $newOperation.Request.QueryParameters.Count
        Assert-AreEqual $dummyQp.Name $newOperation.Request.QueryParameters[0].Name
        Assert-AreEqual $dummyQp.Description $newOperation.Request.QueryParameters[0].Description
        Assert-AreEqual $dummyQp.Type $newOperation.Request.QueryParameters[0].Type
        Assert-AreEqual $dummyQp.Required $newOperation.Request.QueryParameters[0].Required
        Assert-AreEqual $dummyQp.DefaultValue $newOperation.Request.QueryParameters[0].DefaultValue

        Assert-AreEqual 1 $newOperation.Request.Headers.Count
        Assert-AreEqual $header.Name $newOperation.Request.Headers[0].Name
        Assert-AreEqual $header.Description $newOperation.Request.Headers[0].Description
        Assert-AreEqual $header.Type $newOperation.Request.Headers[0].Type
        Assert-AreEqual $header.Required $newOperation.Request.Headers[0].Required
        Assert-AreEqual $header.DefaultValue $newOperation.Request.Headers[0].DefaultValue

        Assert-NotNull $newOperation.Responses
        Assert-AreEqual 1 $newOperation.Responses.Count
        Assert-AreEqual $newOperationResponseStatusCode $newOperation.Responses[0].StatusCode
        Assert-AreEqual $newOperationResponseDescription $newOperation.Responses[0].Description
        Assert-NotNull $newOperation.Responses[0].Representations
        Assert-AreEqual 1 $newOperation.Responses[0].Representations.Count
        Assert-AreEqual $newOperationResponseRepresentationContentType $newOperation.Responses[0].Representations[0].ContentType
        Assert-AreEqual $newOperationResponseRepresentationSample $newOperation.Responses[0].Representations[0].Sample
    }
    finally {
        #remove created operation
        $removed = Remove-AzApiManagementOperation -Context $context -ApiId $api.ApiId -OperationId $newOperationId  -PassThru
        Assert-True { $removed }

        $operation = $null
        try {
            # check it was removed
            $operation = Get-AzApiManagementOperation -Context $context -ApiId $api.ApiId -OperationId $newOperationId
        }
        catch {
        }

        Assert-Null $operation
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Product.
#>
function Product-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all products
    $products = Get-AzApiManagementProduct -Context $context

    # there should be 2 products
    Assert-AreEqual 2 $products.Count

    $found = 0
    for ($i = 0; $i -lt $products.Count; $i++) {
        Assert-NotNull $products[$i].ProductId
        Assert-NotNull $products[$i].Description
        Assert-AreEqual Published $products[$i].State

        if ($products[$i].Title -eq 'Starter') {
            $found += 1;
        }

        if ($products[$i].Title -eq 'Unlimited') {
            $found += 1;
        }
    }
    Assert-AreEqual 2 $found

    #create new product
    $productId = getAssetName
    try {
        $productName = getAssetName
        $productApprovalRequired = $TRUE
        $productDescription = getAssetName
        $productState = "Published"
        $productSubscriptionRequired = $TRUE
        $productSubscriptionsLimit = 10
        $productTerms = getAssetName

        $newProduct = New-AzApiManagementProduct -Context $context –ProductId $productId –Title $productName –Description $productDescription `
            –LegalTerms $productTerms –SubscriptionRequired $productSubscriptionRequired `
            –ApprovalRequired $productApprovalRequired –State $productState -SubscriptionsLimit $productSubscriptionsLimit

        Assert-AreEqual $productId $newProduct.ProductId
        Assert-AreEqual $productName $newProduct.Title
        Assert-AreEqual $productApprovalRequired $newProduct.ApprovalRequired
        Assert-AreEqual $productDescription $newProduct.Description
        Assert-AreEqual $productState $newProduct.State
        Assert-AreEqual $productSubscriptionRequired $newProduct.SubscriptionRequired
        Assert-AreEqual $productSubscriptionsLimit $newProduct.SubscriptionsLimit
        Assert-AreEqual $productTerms $newProduct.LegalTerms

        #add api to product
        $apis = Get-AzApiManagementApi -Context $context -ProductId $productId
        Assert-AreEqual 0 $apis.Count

        Get-AzApiManagementApi -Context $context | Add-AzApiManagementApiToProduct -Context $context -ProductId $productId

        $apis = Get-AzApiManagementApi -Context $context -ProductId $productId
        Assert-AreEqual 1 $apis.Count
        
        #modify product
        $productName = getAssetName
        $productApprovalRequired = $FALSE
        $productDescription = getAssetName
        $productState = "Published"
        $productSubscriptionRequired = $TRUE
        $productSubscriptionsLimit = 20
        $productTerms = getAssetName

        $newProduct = Set-AzApiManagementProduct -Context $context –ProductId $productId –Title $productName –Description $productDescription `
            –LegalTerms $productTerms -ApprovalRequired $productApprovalRequired `
            –SubscriptionRequired $TRUE –State $productState -SubscriptionsLimit $productSubscriptionsLimit -PassThru

        Assert-AreEqual $productId $newProduct.ProductId
        Assert-AreEqual $productName $newProduct.Title
        Assert-AreEqual $productApprovalRequired $newProduct.ApprovalRequired
        Assert-AreEqual $productDescription $newProduct.Description
        Assert-AreEqual $productState $newProduct.State
        Assert-AreEqual $productSubscriptionRequired $newProduct.SubscriptionRequired
        Assert-AreEqual $productSubscriptionsLimit $newProduct.SubscriptionsLimit
        Assert-AreEqual $productTerms $newProduct.LegalTerms

        # get the product by name
        $newProduct = Get-AzApiManagementProduct -Context $context -Title $productName
        Assert-NotNull $newProduct
        Assert-AreEqual $productName $newProduct.Title

		# get the product by apiId
		$products = Get-AzApiManagementProduct -Context $context -ApiId $apis[0].ApiId
		Assert-NotNull $products

		# there should be 3 products
		Assert-AreEqual 3 $products.Count
		
		$found = 0
		for ($i = 0; $i -lt $products.Count; $i++) {
			Assert-NotNull $products[$i].ProductId
			Assert-NotNull $products[$i].Description
			Assert-AreEqual Published $products[$i].State

			if ($products[$i].Title -eq 'Starter') {
	            $found += 1;
			}

	        if ($products[$i].Title -eq 'Unlimited') {
		        $found += 1;
			}

			if ($products[$i].Title -eq $productName) {
		        $found += 1;
			}
		}
		Assert-AreEqual 3 $found

        #remove api from product
        Get-AzApiManagementApi -Context $context | Remove-AzApiManagementApiFromProduct -Context $context -ProductId $productId

        $apis = Get-AzApiManagementApi -Context $context -ProductId $productId
        Assert-AreEqual 0 $apis.Count
    }
    finally {
        # remove created product
        $removed = Remove-AzApiManagementProduct -Context $context -ProductId $productId -DeleteSubscriptions -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Subscription.
#>
function SubscriptionOldModel-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all subscriptions
    $subs = Get-AzApiManagementSubscription -Context $context

    Assert-AreEqual 3 $subs.Count
    for ($i = 0; $i -lt $subs.Count; $i++) {
        Assert-NotNull $subs[$i]
        Assert-NotNull $subs[$i].SubscriptionId
        Assert-NotNull $subs[$i].Scope
        Assert-NotNull $subs[$i].State
        Assert-NotNull $subs[$i].CreatedDate
        Assert-Null $subs[$i].PrimaryKey
        Assert-Null $subs[$i].SecondaryKey

        # get by id
        $sub = Get-AzApiManagementSubscription -Context $context -SubscriptionId $subs[$i].SubscriptionId

        Assert-AreEqual $subs[$i].SubscriptionId $sub.SubscriptionId
        Assert-NotNull $subs[$i].Scope
        Assert-AreEqual $subs[$i].State $sub.State
        Assert-AreEqual $subs[$i].CreatedDate $sub.CreatedDate
        Assert-Null $subs[$i].PrimaryKey $sub.PrimaryKey
        Assert-Null $subs[$i].SecondaryKey $sub.SecondaryKey

        $sub = Get-AzApiManagementSubscriptionKey -Context $context -SubscriptionId $subs[$i].SubscriptionId
        Assert-NotNull $sub.PrimaryKey
        Assert-NotNull $sub.SecondaryKey
    }

    # update product to accept unlimited number or subscriptions
    Set-AzApiManagementProduct -Context $context -ProductId $subs[0].ProductId -SubscriptionsLimit 100

    # add new subscription
    $newSubscriptionId = getAssetName
    try {
        $newSubscriptionName = getAssetName
        $newSubscriptionPk = getAssetName
        $newSubscriptionSk = getAssetName
        $newSubscriptionState = "Active"

        $sub = New-AzApiManagementSubscription -Context $context -SubscriptionId $newSubscriptionId -UserId $subs[0].UserId `
            -ProductId $subs[0].ProductId -Name $newSubscriptionName -PrimaryKey $newSubscriptionPk -SecondaryKey $newSubscriptionSk `
            -State $newSubscriptionState

        Assert-AreEqual $newSubscriptionId $sub.SubscriptionId
        Assert-AreEqual $newSubscriptionName $sub.Name
        Assert-AreEqual $newSubscriptionPk $sub.PrimaryKey
        Assert-AreEqual $newSubscriptionSk $sub.SecondaryKey
        Assert-AreEqual $newSubscriptionState $sub.State

        # update subscription
        $patchedName = getAssetName
        $patchedPk = getAssetName
        $patchedSk = getAssetName
        $patchedExpirationDate = [DateTime]::Parse('2025-7-20')

        $sub = Set-AzApiManagementSubscription -Context $context -SubscriptionId $newSubscriptionId -Name $patchedName `
            -PrimaryKey $patchedPk -SecondaryKey $patchedSk -ExpiresOn $patchedExpirationDate -PassThru

        Assert-AreEqual $newSubscriptionId $sub.SubscriptionId
        Assert-AreEqual $patchedName $sub.Name
        Assert-Null $sub.PrimaryKey
        Assert-Null $sub.SecondaryKey
        Assert-AreEqual $newSubscriptionState $sub.State
        Assert-AreEqual $patchedExpirationDate $sub.ExpirationDate

        $subKeys = Get-AzApiManagementSubscriptionKey -Context $context -SubscriptionId $newSubscriptionId
        Assert-AreEqual $patchedPk $subKeys.PrimaryKey
        Assert-AreEqual $patchedSk $subKeys.SecondaryKey

        # Get subscriptions by product id
        $productSubs = Get-AzApiManagementSubscription -Context $context -ProductId $subs[0].ProductId

        Assert-AreEqual 2 $productSubs.Count
        for ($i = 0; $i -lt $productSubs.Count; $i++) 
        {
            Assert-NotNull $productSubs[$i]
            Assert-NotNull $productSubs[$i].SubscriptionId
            Assert-NotNull $productSubs[$i].Scope
            Assert-NotNull $productSubs[$i].State
            Assert-NotNull $productSubs[$i].CreatedDate
            Assert-Null $productSubs[$i].PrimaryKey
            Assert-Null $productSubs[$i].SecondaryKey

            Assert-AreEqual $subs[0].ProductId $productSubs[$i].ProductId
        }

        # Get subscriptions by user id
        $userSubs = Get-AzApiManagementSubscription -Context $context -UserId $subs[0].UserId

        Assert-AreEqual 3 $userSubs.Count
        for ($i = 0; $i -lt $userSubs.Count; $i++) 
        {
            Assert-NotNull $userSubs[$i]
            Assert-NotNull $userSubs[$i].SubscriptionId
            Assert-NotNull $userSubs[$i].Scope
            Assert-NotNull $userSubs[$i].State
            Assert-NotNull $userSubs[$i].CreatedDate
            Assert-Null $userSubs[$i].PrimaryKey
            Assert-Null $userSubs[$i].SecondaryKey

            Assert-AreEqual $subs[0].UserId $userSubs[$i].UserId
        }

        # get Subscriptions by User and Product
        $productUserSubs = Get-AzApiManagementSubscription -Context $context -UserId $subs[0].UserId -ProductId $subs[0].ProductId

        Assert-AreEqual 2 $productUserSubs.Count
        for ($i = 0; $i -lt $productUserSubs.Count; $i++) 
        {
            Assert-NotNull $productUserSubs[$i]
            Assert-NotNull $productUserSubs[$i].SubscriptionId
            Assert-NotNull $productUserSubs[$i].Scope
            Assert-NotNull $productUserSubs[$i].State
            Assert-NotNull $productUserSubs[$i].CreatedDate
            Assert-Null $productUserSubs[$i].PrimaryKey
            Assert-Null $productUserSubs[$i].SecondaryKey

            Assert-AreEqual $subs[0].UserId $productUserSubs[$i].UserId
            Assert-AreEqual $subs[0].ProductId $productUserSubs[$i].ProductId
        }
    }
    finally {
        # remove created subscription
        $removed = Remove-AzApiManagementSubscription -Context $context -SubscriptionId $newSubscriptionId  -PassThru
        Assert-True { $removed }

        $sub = $null
        try {
            # check it was removed
            $sub = Get-AzApiManagementSubscripiton -Context $context -SubscriptionId $newSubscriptionId
        }
        catch {
        }

        Assert-Null $sub
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Subscription using the new Scope Model.
#>
function SubscriptionNewModel-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all subscriptions
    $subs = Get-AzApiManagementSubscription -Context $context

    Assert-AreEqual 3 $subs.Count
    for ($i = 0; $i -lt $subs.Count; $i++) {
        Assert-NotNull $subs[$i]
        Assert-NotNull $subs[$i].SubscriptionId
        Assert-NotNull $subs[$i].Scope
        Assert-NotNull $subs[$i].State
        Assert-NotNull $subs[$i].CreatedDate
        Assert-Null $subs[$i].PrimaryKey
        Assert-Null $subs[$i].SecondaryKey

        # get by id
        $sub = Get-AzApiManagementSubscription -Context $context -SubscriptionId $subs[$i].SubscriptionId

        Assert-AreEqual $subs[$i].SubscriptionId $sub.SubscriptionId
        Assert-NotNull $subs[$i].Scope
        Assert-AreEqual $subs[$i].State $sub.State
        Assert-AreEqual $subs[$i].CreatedDate $sub.CreatedDate
        Assert-Null $subs[$i].PrimaryKey
        Assert-Null $subs[$i].SecondaryKey
    }

    # add new subscription
    $newSubscriptionId = getAssetName
    try {
        $newSubscriptionName = getAssetName
        $newSubscriptionPk = getAssetName
        $newSubscriptionSk = getAssetName
        $newSubscriptionState = "Active"
        $allApisScope = "/apis"

        $sub = New-AzApiManagementSubscription -Context $context -SubscriptionId $newSubscriptionId `
            -Scope $allApisScope -Name $newSubscriptionName -PrimaryKey $newSubscriptionPk -SecondaryKey $newSubscriptionSk `
            -State $newSubscriptionState

        Assert-AreEqual $newSubscriptionId $sub.SubscriptionId
        Assert-AreEqual $newSubscriptionName $sub.Name
        Assert-AreEqual $newSubscriptionPk $sub.PrimaryKey
        Assert-AreEqual $newSubscriptionSk $sub.SecondaryKey
        Assert-AreEqual $newSubscriptionState $sub.State
        Assert-Null $sub.UserId
        Assert-Null $sub.OwnerId

        # get keys
        $subKeys = Get-AzApiManagementSubscriptionKey -Context $context -SubscriptionId $newSubscriptionId
        Assert-AreEqual $newSubscriptionPk $subKeys.PrimaryKey
        Assert-AreEqual $newSubscriptionSk $subKeys.SecondaryKey

        # update global apis subscription to only Admin Scope
        $patchedName = getAssetName
        $patchedPk = getAssetName
        $patchedSk = getAssetName
        $patchedExpirationDate = [DateTime]::Parse('2025-7-20')

        $sub = Set-AzApiManagementSubscription -Context $context -SubscriptionId $newSubscriptionId -Name $patchedName `
            -UserId $subs[0].UserId -PrimaryKey $patchedPk -SecondaryKey $patchedSk -ExpiresOn $patchedExpirationDate -PassThru

        Assert-AreEqual $newSubscriptionId $sub.SubscriptionId
        Assert-AreEqual $patchedName $sub.Name
        Assert-Null $sub.PrimaryKey
        Assert-Null $sub.SecondaryKey
        Assert-AreEqual $newSubscriptionState $sub.State
        Assert-AreEqual $patchedExpirationDate $sub.ExpirationDate
        Assert-NotNull $sub.UserId
        Assert-AreEqual 1 $sub.UserId
        Assert-NotNull $sub.OwnerId

        # get keys
        $subKeys = Get-AzApiManagementSubscriptionKey -Context $context -SubscriptionId $newSubscriptionId
        Assert-AreEqual $patchedPk $subKeys.PrimaryKey
        Assert-AreEqual $patchedSk $subKeys.SecondaryKey

        # get subscription by apiId
        $sub = Get-AzApiManagementSubscription -Context $context -Scope $allApisScope

        Assert-AreEqual $newSubscriptionId $sub.SubscriptionId
        Assert-AreEqual $patchedName $sub.Name
        Assert-Null $sub.PrimaryKey
        Assert-Null $sub.SecondaryKey
        Assert-AreEqual $newSubscriptionState $sub.State
        Assert-AreEqual $patchedExpirationDate $sub.ExpirationDate
        Assert-NotNull $sub.UserId
        Assert-AreEqual 1 $sub.UserId
        Assert-NotNull $sub.OwnerId
    }
    finally {
        # remove created subscription
        $removed = Remove-AzApiManagementSubscription -Context $context -SubscriptionId $newSubscriptionId  -PassThru
        Assert-True { $removed }

        $sub = $null
        try {
            # check it was removed
            $sub = Get-AzApiManagementSubscripiton -Context $context -SubscriptionId $newSubscriptionId
        }
        catch {
        }

        Assert-Null $sub
    }
}

<#
.SYNOPSIS
Tests CRUD operations of User.
#>
function User-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all users
    $users = Get-AzApiManagementUser -Context $context

    Assert-AreEqual 1 $users.Count
    Assert-NotNull $users[0].UserId
    Assert-NotNull $users[0].FirstName
    Assert-NotNull $users[0].LastName
    Assert-NotNull $users[0].Email
    Assert-NotNull $users[0].State
    Assert-NotNull $users[0].RegistrationDate

    # get by id
    $user = Get-AzApiManagementUser -Context $context -UserId $users[0].UserId

    Assert-AreEqual $users[0].UserId $user.UserId
    Assert-AreEqual $users[0].FirstName $user.FirstName
    Assert-AreEqual $users[0].LastName $user.LastName
    Assert-AreEqual $users[0].Email $user.Email
    Assert-AreEqual $users[0].State $user.State
    Assert-AreEqual $users[0].RegistrationDate $user.RegistrationDate

    # create user
    $userId = getAssetName
    try {
        $userEmail = "contoso@microsoft.com"
        $userFirstName = getAssetName
        $userLastName = getAssetName
        $userPassword = getAssetName
        $userNote = getAssetName
        $userState = "Active"

        $secureUserPassword = ConvertTo-SecureString -String $userPassword -AsPlainText -Force

        $user = New-AzApiManagementUser -Context $context -UserId $userId -FirstName $userFirstName -LastName $userLastName `
            -Password $secureUserPassword -State $userState -Note $userNote -Email $userEmail

        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userFirstName $user.FirstName
        Assert-AreEqual $userLastName $user.LastName
        Assert-AreEqual $userNote $user.Note
        Assert-AreEqual $userState $user.State

        #update user
        $userEmail = "changed.contoso@microsoft.com"
        $userFirstName = getAssetName
        $userLastName = getAssetName
        $userPassword = getAssetName
        $userNote = getAssetName
        $userState = "Active"

        $secureUserPassword = ConvertTo-SecureString -String $userPassword -AsPlainText -Force

        $user = Set-AzApiManagementUser -Context $context -UserId $userId -FirstName $userFirstName -LastName $userLastName `
            -Password $secureUserPassword -State $userState -Note $userNote -PassThru -Email $userEmail

        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userFirstName $user.FirstName
        Assert-AreEqual $userLastName $user.LastName
        Assert-AreEqual $userNote $user.Note
        Assert-AreEqual $userState $user.State

        #find user by email
        $user = Get-AzApiManagementUser -Context $context -Email $userEmail

        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userFirstName $user.FirstName

        #find user by FirstName
        $user = Get-AzApiManagementUser -Context $context -FirstName $userFirstName

        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userFirstName $user.FirstName

        #find user by LastName
        $user = Get-AzApiManagementUser -Context $context -LastName $userLastName

        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userLastName $user.LastName

        #find user by FirstName and LastName
        $user = Get-AzApiManagementUser -Context $context -LastName $userLastName -FirstName $userFirstName

        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userLastName $user.LastName
        Assert-AreEqual $userFirstName $user.FirstName

        # update State to Blocked
        $userState = "Blocked"
        $user = Set-AzApiManagementUser -Context $context -UserId $userId -State $userState -PassThru
        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userFirstName $user.FirstName
        Assert-AreEqual $userLastName $user.LastName
        Assert-AreEqual $userNote $user.Note
        Assert-AreEqual $userState $user.State

        #find user by State
        $user = Get-AzApiManagementUser -Context $context -State $userState

        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userLastName $user.LastName
        Assert-AreEqual $userState $user.State

        # update State to Active
        $userState = "Active"
        $user = Set-AzApiManagementUser -Context $context -UserId $userId -State $userState -PassThru
        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userFirstName $user.FirstName
        Assert-AreEqual $userLastName $user.LastName
        Assert-AreEqual $userNote $user.Note
        Assert-AreEqual $userState $user.State

        #generate SSO URL for the user
        $ssoUrl = Get-AzApiManagementUserSsoUrl -Context $context -UserId $userId

        Assert-NotNull $ssoUrl
        Assert-AreEqual $true [System.Uri]::IsWellFormedUriString($ssoUrl, 'Absolute')

        #generate SSO Token for the user
        $token = New-AzApiManagementUserToken -Context $context -UserId $userId

        Assert-NotNull $token
    }
    finally {
        # remove created user
        $removed = Remove-AzApiManagementUser -Context $context -UserId $userId -DeleteSubscriptions  -PassThru
        Assert-True { $removed }

        $user = $null
        try {
            # check it was removed
            $user = Get-AzApiManagementUser -Context $context -UserId $userId
        }
        catch {
        }

        Assert-Null $user
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Group.
#>
function Group-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all groups
    $groups = Get-AzApiManagementGroup -Context $context

    Assert-AreEqual 3 $groups.Count
    for ($i = 0; $i -lt 3; $i++) {
        Assert-NotNull $groups[$i].GroupId
        Assert-NotNull $groups[$i].Name
        Assert-NotNull $groups[$i].Description
        Assert-NotNull $groups[$i].System
        Assert-NotNull $groups[$i].Type

        # get by id
        $group = Get-AzApiManagementGroup -Context $context -GroupId $groups[$i].GroupId

        Assert-AreEqual $group.GroupId $groups[$i].GroupId
        Assert-AreEqual $group.Name $groups[$i].Name
        Assert-AreEqual $group.Description $groups[$i].Description
        Assert-AreEqual $group.System $groups[$i].System
        Assert-AreEqual $group.Type $groups[$i].Type
    }

    # create group with default parameters
    $groupId = getAssetName
    $externalgroupId = getAssetName
    try {
        $newGroupName = getAssetName
        $newGroupDescription = getAssetName

        # create a custom group
        $group = New-AzApiManagementGroup -GroupId $groupId -Context $context -Name $newGroupName -Description $newGroupDescription

        Assert-AreEqual $groupId $group.GroupId
        Assert-AreEqual $newGroupName $group.Name
        Assert-AreEqual $newGroupDescription $group.Description
        Assert-AreEqual $false $group.System
        Assert-AreEqual 'Custom' $group.Type

        # update group
        $newGroupName = getAssetName
        $newGroupDescription = getAssetName

        $group = Set-AzApiManagementGroup -Context $context -GroupId $groupId -Name $newGroupName -Description $newGroupDescription -PassThru

        Assert-AreEqual $groupId $group.GroupId
        Assert-AreEqual $newGroupName $group.Name
        Assert-AreEqual $newGroupDescription $group.Description
        Assert-AreEqual $false $group.System
        Assert-AreEqual 'Custom' $group.Type

        # add Product to Group
        $product = Get-AzApiManagementProduct -Context $context | Select -First 1
        Add-AzApiManagementProductToGroup -Context $context -GroupId $groupId -ProductId $product.ProductId

        #check group products
        $groups = Get-AzApiManagementGroup -Context $context -ProductId $product.ProductId
        Assert-AreEqual 4 $groups.Count

        # remove Product to Group
        Remove-AzApiManagementProductFromGroup -Context $context -GroupId $groupId -ProductId $product.ProductId

        #check group products
        $groups = Get-AzApiManagementGroup -Context $context -ProductId $product.ProductId
        Assert-AreEqual 3 $groups.Count

        # add User to Group
        $user = Get-AzApiManagementUser -Context $context | Select -First 1
        Add-AzApiManagementUserToGroup -Context $context -GroupId $groupId -UserId $user.UserId

        $groups = Get-AzApiManagementGroup -Context $context -UserId $user.UserId
        Assert-AreEqual 3 $groups.Count

        #remove user from group
        Remove-AzApiManagementUserFromGroup -Context $context -GroupId $groupId -UserId $user.UserId
        $groups = Get-AzApiManagementGroup -Context $context -UserId $user.UserId
        Assert-AreEqual 2 $groups.Count

        # create an external group
        $externalgroupname = getAssetName
        $externalgroupdescription = getAssetName
        $externalgroup = New-AzApiManagementGroup -GroupId $externalgroupId -Context $context -Name $externalgroupname -Type 'External' -Description $externalgroupdescription

        Assert-AreEqual $externalgroupId $externalgroup.GroupId
        Assert-AreEqual $externalgroupname $externalgroup.Name
        Assert-AreEqual $externalgroupdescription $externalgroup.Description
        Assert-AreEqual $false $externalgroup.System
        Assert-AreEqual 'External' $externalgroup.Type
    }
    finally {
        # remove created group
        $removed = Remove-AzApiManagementGroup -Context $context -GroupId $groupId -PassThru
        Assert-True { $removed }

        $group = $null
        try {
            # check it was removed
            $group = Get-AzApiManagementGroup -Context $context -GroupId $groupId
        }
        catch {
        }

        Assert-Null $group

        # remove created external group
        $removed = Remove-AzApiManagementGroup -Context $context -GroupId $externalgroupId -PassThru
        Assert-True { $removed }
        $group = $null
        try {
            # check it was removed
            $group = Get-AzApiManagementGroup -Context $context -GroupId $externalgroupId
        }
        catch {
        }

        Assert-Null $group
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Policy.
#>
function Policy-CrudTest {
    Param($resourceGroupName, $serviceName)

    # load from file get to pipeline scenarios

    $tenantValidPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "TenantValidPolicy.xml"
    $productValidPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "ProductValidPolicy.xml"
    $apiValidPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "ApiValidPolicy.xml"
    $operationValidPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "OperationValidPolicy.xml"

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # test tenant policy
    try {
        $set = Set-AzApiManagementPolicy -Context $context  -PolicyFilePath $tenantValidPath -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzApiManagementPolicy -Context $context
        Assert-NotNull $policy
        Assert-True { $policy -like '*<find-and-replace from="aaa" to="BBB" />*' }
    }
    finally {
        $removed = Remove-AzApiManagementPolicy -Context $context -PassThru
        Assert-AreEqual $true $removed

        $policy = Get-AzApiManagementPolicy -Context $context
        Assert-Null $policy
    }

    # test product policy
    $product = Get-AzApiManagementProduct -Context $context -Title 'Unlimited' | Select-Object -First 1
    try {
        $set = Set-AzApiManagementPolicy -Context $context  -PolicyFilePath $productValidPath -ProductId $product.ProductId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzApiManagementPolicy -Context $context  -ProductId $product.ProductId
        Assert-NotNull $policy
        Assert-True { $policy -like '*<rate-limit calls="5" renewal-period="60" />*' }
    }
    finally {
        $removed = Remove-AzApiManagementPolicy -Context $context -ProductId $product.ProductId -PassThru
        Assert-AreEqual $true $removed

        $policy = Get-AzApiManagementPolicy -Context $context  -ProductId $product.ProductId
        Assert-Null $policy
    }

    # test api policy
    $api = Get-AzApiManagementApi -Context $context | Select-Object -First 1
    try {
        $set = Set-AzApiManagementPolicy -Context $context  -PolicyFilePath $apiValidPath -ApiId $api.ApiId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzApiManagementPolicy -Context $context  -ApiId $api.ApiId
        Assert-NotNull $policy
        Assert-True { $policy -like '*<cache-lookup vary-by-developer="false" vary-by-developer-groups="false" downstream-caching-type="none">*' }
    }
    finally {
        $removed = Remove-AzApiManagementPolicy -Context $context -ApiId $api.ApiId -PassThru
        Assert-AreEqual $true $removed

        $policy = Get-AzApiManagementPolicy -Context $context  -ApiId $api.ApiId
        Assert-Null $policy
    }

    # test operation policy
    $api = Get-AzApiManagementApi -Context $context | Select-Object -First 1
    $operation = Get-AzApiManagementOperation -Context $context -ApiId $api.ApiId | Select-Object -First 1
    try {
        $set = Set-AzApiManagementPolicy -Context $context  -PolicyFilePath $operationValidPath -ApiId $api.ApiId `
            -OperationId $operation.OperationId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzApiManagementPolicy -Context $context  -ApiId $api.ApiId -OperationId $operation.OperationId
        Assert-NotNull $policy
        Assert-True { $policy -like '*<rewrite-uri template="/resource" />*' }
    }
    finally {
        $removed = Remove-AzApiManagementPolicy -Context $context -ApiId $api.ApiId -OperationId $operation.OperationId -PassThru
        Assert-AreEqual $true $removed

        $policy = Get-AzApiManagementPolicy -Context $context  -ApiId $api.ApiId -OperationId $operation.OperationId
        Assert-Null $policy
    }

    # load from string save to file scenarios

    # test tenant policy
    $tenantValid = '<policies><inbound><find-and-replace from="aaa" to="BBB" /><set-header name="ETag" exists-action="skip"><value>bbyby</value><!-- for multiple headers with the same name add additional value elements --></set-header><set-query-parameter name="additional" exists-action="append"><value>xxbbcczc</value><!-- for multiple parameters with the same name add additional value elements --></set-query-parameter><cross-domain /></inbound><outbound /></policies>'
    try {
        $set = Set-AzApiManagementPolicy -Context $context  -Policy $tenantValid -PassThru
        Assert-AreEqual $true $set

        Get-AzApiManagementPolicy -Context $context  -SaveAs "$TestOutputRoot/TenantPolicy.xml" -Force
        $exists = [System.IO.File]::Exists((Join-Path "$TestOutputRoot" "TenantPolicy.xml"))
        $policy = gc (Join-Path "$TestOutputRoot" "TenantPolicy.xml")
        Assert-True { $policy -like '*<find-and-replace from="aaa" to="BBB" />*' }
    }
    finally {
        $removed = Remove-AzApiManagementPolicy -Context $context -PassThru
        Assert-AreEqual $true $removed

        $policy = Get-AzApiManagementPolicy -Context $context
        Assert-Null $policy
    }

    # test product policy
    $productValid = '<policies><inbound><rate-limit calls="5" renewal-period="60" /><quota calls="100" renewal-period="604800" /><base /></inbound><outbound><base /></outbound></policies>'
    $product = Get-AzApiManagementProduct -Context $context -Title 'Unlimited' | Select-Object -First 1
    try {
        $set = Set-AzApiManagementPolicy -Context $context  -Policy $productValid -ProductId $product.ProductId -PassThru
        Assert-AreEqual $true $set

        Get-AzApiManagementPolicy -Context $context  -ProductId $product.ProductId -SaveAs "$TestOutputRoot/ProductPolicy.xml" -Format 'RawXml' -Force
        $exists = [System.IO.File]::Exists((Join-Path "$TestOutputRoot" "ProductPolicy.xml"))
        $policy = gc (Join-Path "$TestOutputRoot" "ProductPolicy.xml")
        Assert-True { $policy -like '*<rate-limit calls="5" renewal-period="60" />*' }
    }
    finally {
        $removed = Remove-AzApiManagementPolicy -Context $context -ProductId $product.ProductId -PassThru
        Assert-AreEqual $true $removed

        $policy = Get-AzApiManagementPolicy -Context $context  -ProductId $product.ProductId
        Assert-Null $policy

        try {
            rm (Join-Path "$TestOutputRoot" "ProductPolicy.xml")
        }
        catch { }
    }

    # test api policy
    $apiValid = '<policies><inbound><base /><cache-lookup vary-by-developer="false" vary-by-developer-groups="false" downstream-caching-type="none"><vary-by-query-parameter>version</vary-by-query-parameter><vary-by-header>Accept</vary-by-header><vary-by-header>Accept-Charset</vary-by-header></cache-lookup></inbound><outbound><cache-store duration="10" /><base /></outbound></policies>'
    $api = Get-AzApiManagementApi -Context $context | Select-Object -First 1
    try {
        $set = Set-AzApiManagementPolicy -Context $context  -Policy $apiValid -ApiId $api.ApiId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzApiManagementPolicy -Context $context  -ApiId $api.ApiId -SaveAs (Join-Path "$TestOutputRoot" "ApiPolicy.xml") -Format 'RawXml' -Force
        $exists = [System.IO.File]::Exists((Join-Path "$TestOutputRoot" "ApiPolicy.xml"))
        $policy = gc (Join-Path "$TestOutputRoot" "ApiPolicy.xml")
        Assert-True { $policy -like '*<cache-lookup vary-by-developer="false" vary-by-developer-groups="false" downstream-caching-type="none">*' }
    }
    finally {
        $removed = Remove-AzApiManagementPolicy -Context $context -ApiId $api.ApiId -PassThru
        Assert-AreEqual $true $removed

        $policy = Get-AzApiManagementPolicy -Context $context  -ApiId $api.ApiId
        Assert-Null $policy

        try {
            rm (Join-Path "$TestOutputRoot" "ApiPolicy.xml")
        }
        catch { }
    }

    # test operation policy
    $operationValid = '<policies><inbound><base /><rewrite-uri template="/resource" /></inbound><outbound><base /></outbound></policies>'
    $api = Get-AzApiManagementApi -Context $context | Select -First 1
    $operation = Get-AzApiManagementOperation -Context $context -ApiId $api.ApiId | Select-Object -First 1
    try {
        $set = Set-AzApiManagementPolicy -Context $context  -Policy $operationValid -ApiId $api.ApiId `
            -OperationId $operation.OperationId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzApiManagementPolicy -Context $context  -ApiId $api.ApiId -OperationId $operation.OperationId `
            -SaveAs (Join-Path "$TestOutputRoot" "OperationPolicy.xml") -Format 'RawXml' -Force
        $exists = [System.IO.File]::Exists((Join-Path "$TestOutputRoot" "OperationPolicy.xml"))
        $policy = gc (Join-Path "$TestOutputRoot" "OperationPolicy.xml")
        Assert-True { $policy -like '*<rewrite-uri template="/resource" />*' }
    }
    finally {
        $removed = Remove-AzApiManagementPolicy -Context $context -ApiId $api.ApiId -OperationId $operation.OperationId -PassThru
        Assert-AreEqual $true $removed

        $policy = Get-AzApiManagementPolicy -Context $context  -ApiId $api.ApiId -OperationId $operation.OperationId
        Assert-Null $policy

        try {
            rm (Join-Path "$TestOutputRoot" "OperationPolicy.xml")
        }
        catch { }
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Certificate.
#>
function Certificate-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all certificates
    $certificates = Get-AzApiManagementCertificate -Context $context

    Assert-AreEqual 0 $certificates.Count

    $certPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "powershelltest.pfx"
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $certPassword = 'Password'
    $certSubject = "CN=*.msitesting.net"
    $certThumbprint = '8E989652CABCF585ACBFCB9C2C91F1D174FDB3A2'

    $certId = getAssetName
    try {
        # upload certificate
        $cert = New-AzApiManagementCertificate -Context $context -CertificateId $certId -PfxFilePath $certPath -PfxPassword $certPassword

        Assert-AreEqual $certId $cert.CertificateId
        Assert-AreEqual $certThumbprint $cert.Thumbprint
        Assert-AreEqual $certSubject $cert.Subject

        # get certificate by context
        $cert = Get-AzApiManagementCertificate -Context $context -CertificateId $certId

        Assert-AreEqual $certId $cert.CertificateId
        Assert-AreEqual $certThumbprint $cert.Thumbprint
        Assert-AreEqual $certSubject $cert.Subject

        # get certificate by ResourceId
        $cert = Get-AzApiManagementCertificate -ResourceId $cert.Id

        Assert-AreEqual $certId $cert.CertificateId
        Assert-AreEqual $certThumbprint $cert.Thumbprint
        Assert-AreEqual $certSubject $cert.Subject

        # update certificate
        $cert = Set-AzApiManagementCertificate -Context $context -CertificateId $certId -PfxFilePath $certPath -PfxPassword $certPassword -PassThru

        Assert-AreEqual $certId $cert.CertificateId
        Assert-AreEqual $certThumbprint $cert.Thumbprint
        Assert-AreEqual $certSubject $cert.Subject

        # list certificates
        $certificates = Get-AzApiManagementCertificate -Context $context
        Assert-AreEqual 1 $certificates.Count

        Assert-AreEqual $certId $certificates[0].CertificateId
        Assert-AreEqual $certThumbprint $certificates[0].Thumbprint
        Assert-AreEqual $certSubject $certificates[0].Subject
    }
    finally {
        # remove uploaded certificate
        $removed = Remove-AzApiManagementCertificate -Context $context -CertificateId $certId  -PassThru
        Assert-True { $removed }

        $cert = $null
        try {
            # check it was removed
            $cert = Get-AzApiManagementCertificate -Context $context -CertificateId $certId
        }
        catch {
        }

        Assert-Null $cert
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Certificate.
#>
function Cache-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all caches
    $caches = Get-AzApiManagementCache -Context $context

    Assert-AreEqual 0 $caches.Count

    $cacheDescription = getAssetName
    $cacheConnectionString = 'teamdemo.redis.cache.windows.net:6380,password=xxxxxx+xxxxx=,ssl=True,abortConnect=False'

    $cacheId = "default"
    try {
        # create a new cache
        $cache = New-AzApiManagementCache -Context $context -CacheId $cacheId -ConnectionString $cacheConnectionString -Description $cacheDescription

        Assert-AreEqual $cacheId $cache.CacheId
        Assert-NotNull $cache.ConnectionString
        Assert-AreEqual $cacheDescription $cache.Description

        # get cache
        $cache = Get-AzApiManagementCache -Context $context -CacheId $cacheId

        Assert-AreEqual $cacheId $cache.CacheId
        Assert-NotNull $cache.ConnectionString
        Assert-AreEqual $cacheDescription $cache.Description

		# get cache by Id
		$cache = Get-AzApiManagementCache -ResourceId $cache.Id

		Assert-AreEqual $cacheId $cache.CacheId
        Assert-NotNull $cache.ConnectionString
        Assert-AreEqual $cacheDescription $cache.Description

        # update cache
        $newDescription = getAssetName
        $cache.Description = $newDescription
        $cache = Update-AzApiManagementCache -InputObject $cache -PassThru

        Assert-AreEqual $cacheId $cache.CacheId
        Assert-NotNull $cache.ConnectionString
        Assert-AreEqual $newDescription $cache.Description

        # list caches
        $caches = Get-AzApiManagementCache -Context $context
        Assert-AreEqual 1 $caches.Count

        Assert-AreEqual $cacheId $caches[0].CacheId
        Assert-NotNull $caches[0].ConnectionString
        Assert-AreEqual $newDescription $caches[0].Description
    }
    finally {
        # remove uploaded certificate
        $removed = Remove-AzApiManagementCache -Context $context -CacheId $cacheId  -PassThru
        Assert-True { $removed }

        $cache = $null
        try {
            # check it was removed
            $cache = Get-AzApiManagementCache -Context $context -CacheId $cacheId
        }
        catch {
        }

        Assert-Null $cache

        # remove all properties
        $properties = Get-AzApiManagementNamedValue -Context $context
        for ($i = 0; $i -lt $properties.Count; $i++) {
            Remove-AzApiManagementNamedValue -Context $context -NamedValueId $properties[$i].NamedValueId
        }
    }
}

<#
.SYNOPSIS
Tests CRUD operations of AuthorizationServer.
#>
function AuthorizationServer-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all authoriaztion servers
    $servers = Get-AzApiManagementAuthorizationServer -Context $context

    Assert-AreEqual 0 $servers.Count

    # create server
    $serverId = getAssetName
    try {
        $name = getAssetName
        $defaultScope = getAssetName
        $authorizationEndpoint = 'https://contoso.com/auth'
        $tokenEndpoint = 'https://contoso.com/token'
        $clientRegistrationEndpoint = 'https://contoso.com/clients/reg'
        $grantTypes = @('AuthorizationCode', 'Implicit', 'ResourceOwnerPassword')
        $authorizationMethods = @('Post', 'Get')
        $bearerTokenSendingMethods = @('AuthorizationHeader', 'Query')
        $clientId = getAssetName
        $description = getAssetName
        $clientAuthenticationMethods = @('Basic')
        $clientSecret = getAssetName
        $resourceOwnerPassword = getAssetName
        $resourceOwnerUsername = getAssetName
        $supportState = $true
        $tokenBodyParameters = @{'tokenname' = 'tokenvalue' }

        $server = New-AzApiManagementAuthorizationServer -Context $context -ServerId $serverId -Name $name -Description $description `
            -ClientRegistrationPageUrl $clientRegistrationEndpoint -AuthorizationEndpointUrl $authorizationEndpoint `
            -TokenEndpointUrl $tokenEndpoint -ClientId $clientId -ClientSecret $clientSecret -AuthorizationRequestMethods $authorizationMethods `
            -GrantTypes $grantTypes -ClientAuthenticationMethods $clientAuthenticationMethods -TokenBodyParameters $tokenBodyParameters `
            -SupportState $supportState -DefaultScope $defaultScope -AccessTokenSendingMethods $bearerTokenSendingMethods `
            -ResourceOwnerUsername $resourceOwnerUsername -ResourceOwnerPassword $resourceOwnerPassword

        Assert-AreEqual $serverId $server.ServerId
        Assert-AreEqual $name $server.Name
        Assert-AreEqual $defaultScope $server.DefaultScope
        Assert-AreEqual $authorizationEndpoint $server.AuthorizationEndpointUrl
        Assert-AreEqual $tokenEndpoint $server.TokenEndpointUrl
        Assert-AreEqual $clientRegistrationEndpoint $server.ClientRegistrationPageUrl
        Assert-AreEqual $grantTypes.Count $server.GrantTypes.Count
        Assert-AreEqual $grantTypes[0] $server.GrantTypes[0]
        Assert-AreEqual $grantTypes[1] $server.GrantTypes[1]
        Assert-AreEqual $grantTypes[2] $server.GrantTypes[2]
        Assert-AreEqual $authorizationMethods.Count $server.AuthorizationRequestMethods.Count
        Assert-AreEqual $authorizationMethods[0] $server.AuthorizationRequestMethods[0]
        Assert-AreEqual $authorizationMethods[1] $server.AuthorizationRequestMethods[1]
        Assert-AreEqual $bearerTokenSendingMethods.Count $server.AccessTokenSendingMethods.Count
        Assert-AreEqual $bearerTokenSendingMethods[0] $server.AccessTokenSendingMethods[0]
        Assert-AreEqual $bearerTokenSendingMethods[1] $server.AccessTokenSendingMethods[1]
        Assert-AreEqual $clientId $server.ClientId
        Assert-AreEqual $description $server.Description
        Assert-AreEqual $clientAuthenticationMethods.Count $server.ClientAuthenticationMethods.Count
        Assert-AreEqual $clientAuthenticationMethods[0] $server.ClientAuthenticationMethods[0]
        Assert-AreEqual $clientSecret $server.ClientSecret
        Assert-AreEqual $resourceOwnerPassword $server.ResourceOwnerPassword
        Assert-AreEqual $resourceOwnerUsername $server.ResourceOwnerUsername
        Assert-AreEqual $supportState $server.SupportState
        Assert-AreEqual $tokenBodyParameters.Count $server.TokenBodyParameters.Count

        $server = Get-AzApiManagementAuthorizationServer -Context $context -ServerId $serverId

        Assert-AreEqual $serverId $server.ServerId
        Assert-AreEqual $name $server.Name
        Assert-AreEqual $defaultScope $server.DefaultScope
        Assert-AreEqual $authorizationEndpoint $server.AuthorizationEndpointUrl
        Assert-AreEqual $tokenEndpoint $server.TokenEndpointUrl
        Assert-AreEqual $clientRegistrationEndpoint $server.ClientRegistrationPageUrl
        Assert-AreEqual $grantTypes.Count $server.GrantTypes.Count
        Assert-AreEqual $grantTypes[0] $server.GrantTypes[0]
        Assert-AreEqual $grantTypes[1] $server.GrantTypes[1]
        Assert-AreEqual $grantTypes[2] $server.GrantTypes[2]
        Assert-AreEqual $authorizationMethods.Count $server.AuthorizationRequestMethods.Count
        Assert-AreEqual $authorizationMethods[0] $server.AuthorizationRequestMethods[0]
        Assert-AreEqual $authorizationMethods[1] $server.AuthorizationRequestMethods[1]
        Assert-AreEqual $bearerTokenSendingMethods.Count $server.AccessTokenSendingMethods.Count
        Assert-AreEqual $bearerTokenSendingMethods[0] $server.AccessTokenSendingMethods[0]
        Assert-AreEqual $bearerTokenSendingMethods[1] $server.AccessTokenSendingMethods[1]
        Assert-AreEqual $clientId $server.ClientId
        Assert-AreEqual $description $server.Description
        Assert-AreEqual $clientAuthenticationMethods.Count $server.ClientAuthenticationMethods.Count
        Assert-AreEqual $clientAuthenticationMethods[0] $server.ClientAuthenticationMethods[0]
        Assert-Null $server.ClientSecret
        Assert-AreEqual $resourceOwnerPassword $server.ResourceOwnerPassword
        Assert-AreEqual $resourceOwnerUsername $server.ResourceOwnerUsername
        Assert-AreEqual $supportState $server.SupportState
        Assert-AreEqual $tokenBodyParameters.Count $server.TokenBodyParameters.Count

        $server = Get-AzApiManagementAuthorizationServerClientSecret -Context $context -ServerId $serverId
        Assert-AreEqual $clientSecret $server.ClientSecret

        # update server
        $name = getAssetName
        $defaultScope = getAssetName
        $authorizationEndpoint = 'https://contoso.com/authv2'
        $tokenEndpoint = 'https://contoso.com/tokenv2'
        $clientRegistrationEndpoint = 'https://contoso.com/clients/regv2'
        $grantTypes = @('AuthorizationCode', 'Implicit', 'ClientCredentials')
        $authorizationMethods = @('Get')
        $bearerTokenSendingMethods = @('AuthorizationHeader')
        $clientId = getAssetName
        $description = getAssetName
        $clientAuthenticationMethods = @('Basic')
        $clientSecret = getAssetName
        $supportState = $false
        $tokenBodyParameters = @{'tokenname1' = 'tokenvalue1' }

        $server = Set-AzApiManagementAuthorizationServer -Context $context -ServerId $serverId -Name $name -Description $description `
            -ClientRegistrationPageUrl $clientRegistrationEndpoint -AuthorizationEndpointUrl $authorizationEndpoint `
            -TokenEndpointUrl $tokenEndpoint -ClientId $clientId -ClientSecret $clientSecret -AuthorizationRequestMethods $authorizationMethods `
            -GrantTypes $grantTypes -ClientAuthenticationMethods $clientAuthenticationMethods -TokenBodyParameters $tokenBodyParameters `
            -SupportState $supportState -DefaultScope $defaultScope -AccessTokenSendingMethods $bearerTokenSendingMethods -PassThru

        Assert-AreEqual $serverId $server.ServerId
        Assert-AreEqual $name $server.Name
        Assert-AreEqual $defaultScope $server.DefaultScope
        Assert-AreEqual $authorizationEndpoint $server.AuthorizationEndpointUrl
        Assert-AreEqual $tokenEndpoint $server.TokenEndpointUrl
        Assert-AreEqual $clientRegistrationEndpoint $server.ClientRegistrationPageUrl
        Assert-AreEqual $grantTypes.Count $server.GrantTypes.Count
        Assert-AreEqual $grantTypes[0] $server.GrantTypes[0]
        Assert-AreEqual $grantTypes[1] $server.GrantTypes[1]
        Assert-AreEqual $grantTypes[2] $server.GrantTypes[2]
        Assert-AreEqual $authorizationMethods.Count $server.AuthorizationRequestMethods.Count
        Assert-AreEqual $authorizationMethods[0] $server.AuthorizationRequestMethods[0]
        Assert-AreEqual $bearerTokenSendingMethods.Count $server.AccessTokenSendingMethods.Count
        Assert-AreEqual $bearerTokenSendingMethods[0] $server.AccessTokenSendingMethods[0]
        Assert-AreEqual $clientId $server.ClientId
        Assert-AreEqual $description $server.Description
        Assert-AreEqual $clientAuthenticationMethods.Count $server.ClientAuthenticationMethods.Count
        Assert-AreEqual $clientAuthenticationMethods[0] $server.ClientAuthenticationMethods[0]
        Assert-Null $server.ClientSecret
        #Assert-AreEqual $resourceOwnerPassword $server.ResourceOwnerPassword
        #Assert-AreEqual $resourceOwnerUsername $server.ResourceOwnerUsername
        Assert-AreEqual $supportState $server.SupportState
        Assert-AreEqual $tokenBodyParameters.Count $server.TokenBodyParameters.Count

        $server = Get-AzApiManagementAuthorizationServer -Context $context -ServerId $serverId

        Assert-AreEqual $serverId $server.ServerId
        Assert-AreEqual $name $server.Name
        Assert-AreEqual $defaultScope $server.DefaultScope
        Assert-AreEqual $authorizationEndpoint $server.AuthorizationEndpointUrl
        Assert-AreEqual $tokenEndpoint $server.TokenEndpointUrl
        Assert-AreEqual $clientRegistrationEndpoint $server.ClientRegistrationPageUrl
        Assert-AreEqual $grantTypes.Count $server.GrantTypes.Count
        Assert-AreEqual $grantTypes[0] $server.GrantTypes[0]
        Assert-AreEqual $grantTypes[1] $server.GrantTypes[1]
        Assert-AreEqual $grantTypes[2] $server.GrantTypes[2]
        Assert-AreEqual $authorizationMethods.Count $server.AuthorizationRequestMethods.Count
        Assert-AreEqual $authorizationMethods[0] $server.AuthorizationRequestMethods[0]
        Assert-AreEqual $authorizationMethods[1] $server.AuthorizationRequestMethods[1]
        Assert-AreEqual $bearerTokenSendingMethods.Count $server.AccessTokenSendingMethods.Count
        Assert-AreEqual $bearerTokenSendingMethods[0] $server.AccessTokenSendingMethods[0]
        Assert-AreEqual $bearerTokenSendingMethods[1] $server.AccessTokenSendingMethods[1]
        Assert-AreEqual $clientId $server.ClientId
        Assert-AreEqual $description $server.Description
        Assert-AreEqual $clientAuthenticationMethods.Count $server.ClientAuthenticationMethods.Count
        Assert-AreEqual $clientAuthenticationMethods[0] $server.ClientAuthenticationMethods[0]
        Assert-Null $server.ClientSecret
        #Assert-AreEqual $resourceOwnerPassword $server.ResourceOwnerPassword
        #Assert-AreEqual $resourceOwnerUsername $server.ResourceOwnerUsername
        Assert-AreEqual $supportState $server.SupportState
        Assert-AreEqual $tokenBodyParameters.Count $server.TokenBodyParameters.Count

        $server = Get-AzApiManagementAuthorizationServerClientSecret -Context $context -ServerId $serverId
        Assert-AreEqual $clientSecret $server.ClientSecret
    }
    finally {
        # remove created server
        $removed = Remove-AzApiManagementAuthorizationServer -Context $context -ServerId $serverId  -PassThru
        Assert-True { $removed }

        $server = $null
        try {
            # check it was removed
            $server = Get-AzApiManagementAuthorizationServer -Context $context -ServerId $serverId
        }
        catch {
        }

        Assert-Null $server
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Logger.
#>
function Logger-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # create logger
    $loggerId = getAssetName
    $appInsightsLoggerId = getAssetName
    $instrumentationKey = [guid]::newguid()
    try {        
        $newLoggerDescription = getAssetName
        $eventHubName = "powershell"
        # Replace the Connection string with actual EventHub connection string when recording tests
        $eventHubConnectionString = "Test-ConnectionString"

        $logger = New-AzApiManagementLogger -Context $context -LoggerId $loggerId -Name $eventHubName -ConnectionString $eventHubConnectionString -Description $newLoggerDescription

        Assert-AreEqual $loggerId $logger.LoggerId
        Assert-AreEqual $newLoggerDescription $logger.Description
        Assert-AreEqual 'AzureEventHub' $logger.Type
        Assert-AreEqual $true $logger.IsBuffered

        # update logger to non-buffered
        $newLoggerDescription = getAssetName

        $logger = $null
        $logger = Set-AzApiManagementLogger -Context $context -LoggerId $loggerId -Description $newLoggerDescription -PassThru

        Assert-AreEqual $loggerId $logger.LoggerId
        Assert-AreEqual $newLoggerDescription $logger.Description
        Assert-AreEqual 'AzureEventHub' $logger.Type
        Assert-AreEqual $false $logger.IsBuffered

        # get all Loggers
        $loggers = Get-AzApiManagementLogger -Context $context

        Assert-NotNull $loggers
        Assert-AreEqual 1 $loggers.Count

        # get a specific logger
        $logger = $null
        $logger = Get-AzApiManagementLogger -Context $context -LoggerId $loggerId
        Assert-AreEqual $loggerId $logger.LoggerId
        Assert-AreEqual $newLoggerDescription $logger.Description
        Assert-AreEqual 'AzureEventHub' $logger.Type
        Assert-AreEqual $false $logger.IsBuffered

        # create an Application Insights Logger
        $appInsightsLoggerDescription = getAssetName
        $applogger = New-AzApiManagementLogger -Context $context -LoggerId $appInsightsLoggerId -InstrumentationKey $instrumentationKey.Guid -Description $appInsightsLoggerDescription
        Assert-NotNull $applogger
        Assert-AreEqual 'ApplicationInsights' $applogger.Type
        Assert-AreEqual $appInsightsLoggerId $applogger.LoggerId
        Assert-AreEqual $appInsightsLoggerDescription $applogger.Description
    }
    finally {
        # remove created logger
        $removed = Remove-AzApiManagementLogger -Context $context -LoggerId $loggerId  -PassThru
        Assert-True { $removed }

        $logger = $null
        try {
            # check it was removed
            $logger = Get-AzApiManagementLogger -Context $context -LoggerId $loggerId
        }
        catch {
        }

        Assert-Null $logger

        # remove created logger
        $removed = Remove-AzApiManagementLogger -Context $context -LoggerId $appInsightsLoggerId  -PassThru
        Assert-True { $removed }
 
        $logger = $null
        try {
            # check it was removed
            $logger = Get-AzApiManagementLogger -Context $context -LoggerId $appInsightsLoggerId
        }
        catch {
        }
 
        Assert-Null $logger

        # remove all properties
        $properties = Get-AzApiManagementNamedValue -Context $context
        for ($i = 0; $i -lt $properties.Count; $i++) {

            Remove-AzApiManagementNamedValue -Context $context -NamedValueId $properties[$i].NamedValueId
        }
    }
}

<#
.SYNOPSIS
Tests CRUD operations of OpenId Connect Provider.
#>
function OpenIdConnectProvider-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # create openIdConnectProvider with default parameters
    $openIdConnectProviderId = getAssetName
    $yamlPath1 = Join-Path (Join-Path "$TestOutputRoot" "Resources") "uspto.yml"
    $path1 = "openapifromFile"
    $openApiId1 = getAssetName
    
    try {
        $openIdConnectProviderName = getAssetName
        $metadataEndpoint = "https://login.microsoftonline.com/contoso.onmicrosoft.com/v2.0/.well-known/openid-configuration"
        $clientId = getAssetName
        $openIdDescription = getAssetName

        $openIdConectProvider = New-AzApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId -Name $openIdConnectProviderName -MetadataEndpointUri $metadataEndpoint -ClientId $clientId -Description $openIdDescription

        Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId
        Assert-AreEqual $openIdConnectProviderName $openIdConectProvider.Name
        Assert-AreEqual $metadataEndpoint $openIdConectProvider.MetadataEndpoint
        Assert-AreEqual $clientId $openIdConectProvider.ClientId
        Assert-AreEqual $openIdDescription $openIdConectProvider.Description
        Assert-Null $openIdConectProvider.ClientSecret

        # get openIdConnectProvider using Name
        $openIdConectProvider = $null
        $openIdConectProvider = Get-AzApiManagementOpenIdConnectProvider -Context $context -Name $openIdConnectProviderName

        Assert-NotNull $openIdConectProvider
        Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId
        Assert-Null $openIdConectProvider.ClientSecret

        # get OpenId Connect Provider using Id
        $openIdConectProvider = Get-AzApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId

        Assert-NotNull $openIdConectProvider
        Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId
        Assert-Null $openIdConectProvider.ClientSecret

        #get all openId Connect Providers
        $openIdConectProviders = Get-AzApiManagementOpenIdConnectProvider -Context $context
        Assert-AreEqual 1 $openIdConectProviders.Count

        Assert-NotNull $openIdConectProviders
        Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId

        #get all openId Connect Providers secret
        $openIdConectProvider = Get-AzApiManagementOpenIdConnectProviderClientSecret -Context $context -OpenIdConnectProviderId $openIdConnectProviderId
        Assert-Null $openIdConectProvider.ClientSecret

        # import api from file
        $api = Import-AzApiManagementApi -Context $context -ApiId $openApiId1 -SpecificationPath $yamlPath1 -SpecificationFormat OpenApi -Path $path1

        Assert-AreEqual $openApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path
        Assert-NotNull $api.ServiceUrl

        # update the api to use open-id connect authentication
        $api = Set-AzApiManagementApi -InputObject $api -Name $api.Name -ServiceUrl $api.ServiceUrl -Protocols $api.Protocols -OpenIdProviderId $openIdConnectProviderId -BearerTokenSendingMethod 'query' -PassThru
        Assert-AreEqual $openApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path
        Assert-AreEqual $openIdConnectProviderId $api.OpenIdProviderId
        Assert-AreEqual 'query' $api.BearerTokenSendingMethod[0]

        #update the provider with Secret
        $clientSecret = getAssetName
        $openIdConectProvider = Set-AzApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId -ClientSecret $clientSecret -PassThru

        Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId
        Assert-Null $openIdConectProvider.ClientSecret
        Assert-AreEqual $clientId $openIdConectProvider.ClientId
        Assert-AreEqual $metadataEndpoint $openIdConectProvider.MetadataEndpoint
        Assert-AreEqual $openIdConnectProviderName $openIdConectProvider.Name

        $openIdConectProvider = Get-AzApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId
        Assert-Null $openIdConectProvider.ClientSecret

        $openIdConectProvider = Get-AzApiManagementOpenIdConnectProviderClientSecret -Context $context -OpenIdConnectProviderId $openIdConnectProviderId
        Assert-AreEqual $clientSecret $openIdConectProvider.ClientSecret

        # first remove the api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $openApiId1 -PassThru
        Assert-True { $removed }

        # remove openIdConnectProvider
        $removed = Remove-AzApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId -PassThru
        Assert-True { $removed }

        $openIdConectProvider = $null
        try {
            # check it was removed
            $openIdConectProvider = Get-AzApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId
        }
        catch {
        }

        Assert-Null $openIdConectProvider
    }
    finally {

        $removed = Remove-AzApiManagementApi -Context $context -ApiId $openApiId1 -PassThru
        Assert-True { $removed }

        $removed = Remove-AzApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId -PassThru
        Assert-True { $removed }

        $openIdConectProvider = $null
        try {
            # check it was removed
            $openIdConectProvider = Get-AzApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId
        }
        catch {
        }

        Assert-Null $openIdConectProvider
    }
}

<#
.SYNOPSIS
Tests CRUD operations on Properties.
#>
function Properties-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # create non-Secret Property
    $namedValueId = getAssetName
    $secretNamedValueId = $null
    try {
        $propertyName = getAssetName
        $propertyValue = getAssetName
        $tags = 'sdk', 'powershell', 'test'
        $property = New-AzApiManagementNamedValue -Context $context -NamedValueId $namedValueId -Name $propertyName -Value $propertyValue -Tag $tags

        Assert-NotNull $property
        Assert-AreEqual $namedValueId $property.NamedValueId
        Assert-AreEqual $propertyName $property.Name
        Assert-AreEqual $propertyValue $property.Value
        Assert-AreEqual $false  $property.Secret
        Assert-AreEqual 3 $property.Tags.Count

        $property = Get-AzApiManagementNamedValueSecretValue -Context $context -NamedValueId $namedValueId
        Assert-AreEqual $propertyValue $property.Value

        #create Secret Property
        $secretNamedValueId = getAssetName
        $secretPropertyName = getAssetName
        $secretPropertyValue = getAssetName
        $secretProperty = New-AzApiManagementNamedValue -Context $context -NamedValueId $secretNamedValueId -Name $secretPropertyName -Value $secretPropertyValue -Secret

        Assert-NotNull $secretProperty
        Assert-AreEqual $secretNamedValueId $secretProperty.NamedValueId
        Assert-AreEqual $secretPropertyName $secretProperty.Name
        Assert-Null $secretProperty.Value
        Assert-AreEqual $true  $secretProperty.Secret
        Assert-NotNull $secretProperty.Tags
        Assert-AreEqual 0 $secretProperty.Tags.Count

        # get all properties
        $properties = Get-AzApiManagementNamedValue -Context $context

        Assert-NotNull $properties
        # there should be 2 properties
        Assert-AreEqual 2 $properties.Count

        # get properties by name
        $properties = $null
        $properties = Get-AzApiManagementNamedValue -Context $context -Name 'ps'
		
        Assert-NotNull $properties
        # both the properties created start with 'ps'
        Assert-AreEqual 2 $properties.Count

        # get properties by tag
        $properties = $null
        $properties = Get-AzApiManagementNamedValue -Context $context -Tag 'sdk'

        Assert-NotNull $property
        Assert-AreEqual 1 $properties.Count

        # get property by Id
        $secretProperty = $null
        $secretProperty = Get-AzApiManagementNamedValue -Context $context -NamedValueId $secretNamedValueId

        Assert-NotNull $secretProperty
        Assert-AreEqual $secretNamedValueId $secretProperty.NamedValueId
        Assert-AreEqual $secretPropertyName $secretProperty.Name
        Assert-Null $secretProperty.Value
        Assert-AreEqual $true  $secretProperty.Secret
        Assert-NotNull $secretProperty.Tags
        Assert-AreEqual 0 $secretProperty.Tags.Count

        $secretProperty = Get-AzApiManagementNamedValueSecretValue -Context $context -NamedValueId $secretNamedValueId
        Assert-AreEqual $secretPropertyValue $secretProperty.Value

        # update the secret property with a tag
        $secretProperty = $null
        $secretProperty = Set-AzApiManagementNamedValue -Context $context -NamedValueId $secretNamedValueId -Tag $tags -PassThru

        Assert-NotNull $secretProperty
        Assert-AreEqual $secretNamedValueId $secretProperty.NamedValueId
        Assert-AreEqual $secretPropertyName $secretProperty.Name        
        Assert-Null $secretProperty.Value
        Assert-AreEqual $true  $secretProperty.Secret
        Assert-NotNull $secretProperty.Tags
        Assert-AreEqual 3 $secretProperty.Tags.Count

        $secretProperty = Get-AzApiManagementNamedValueSecretValue -Context $context -NamedValueId $secretNamedValueId
        Assert-AreEqual $secretPropertyValue $secretProperty.Value

        #convert a non secret property to secret
        $property = $null
        $property = Set-AzApiManagementNamedValue -Context $context -NamedValueId $namedValueId -Secret $true -PassThru

        Assert-NotNull $property
        Assert-AreEqual $namedValueId $property.NamedValueId
        Assert-AreEqual $propertyName $property.Name
        Assert-Null $property.Value
        Assert-AreEqual $true  $property.Secret
        Assert-NotNull $property.Tags
        Assert-AreEqual 3 $property.Tags.Count

        $property = Get-AzApiManagementNamedValueSecretValue -Context $context -NamedValueId $namedValueId
        Assert-AreEqual $propertyValue $property.Value

        #remove secret property
        $removed = Remove-AzApiManagementNamedValue -Context $context -NamedValueId $secretNamedValueId -PassThru
        Assert-True { $removed }

        $secretProperty = $null
        try {
            # check it was removed
            $secretProperty = Get-AzApiManagementNamedValue -Context $context -NamedValueId $secretNamedValueId
        }
        catch {
        }

        Assert-Null $secretProperty
    }
    finally {
        $removed = Remove-AzApiManagementNamedValue -Context $context -NamedValueId $namedValueId -PassThru
        Assert-True { $removed }

        $property = $null
        try {
            # check it was removed
            $property = Get-AzApiManagementNamedValue -Context $context -NamedValueId $namedValueId
        }
        catch {
        }

        Assert-Null $property

        # cleanup other Property
        try {
            Remove-AzApiManagementNamedValue -Context $context -NamedValueId $secretNamedValueId -PassThru
        }
        catch {
        }
    }
}

<#
.SYNOPSIS
Tests CRUD operations on Tenant Git Configuration.
#>
function TenantGitConfiguration-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    try {
        $tenantGitAccess = Get-AzApiManagementTenantGitAccess -Context $context

        Assert-NotNull $tenantGitAccess
        Assert-AreEqual $true $tenantGitAccess.Enabled

        #get Tenant Sync state
        $tenantSyncState = Get-AzApiManagementTenantSyncState -Context $context
        Assert-NotNull $tenantSyncState
        Assert-AreEqual $true $tenantSyncState.IsGitEnabled

        # Do a initial Save to populate the master Branch with current state of Configuration database
        $saveResponse = Save-AzApiManagementTenantGitConfiguration -Context $context -Branch 'master' -PassThru

        Assert-NotNull $saveResponse
        Assert-AreEqual "Succeeded" $saveResponse.State
        Assert-Null $saveResponse.Error

        #get Tenant Sync state after Save
        $tenantSyncState = $null
        $tenantSyncState = Get-AzApiManagementTenantSyncState -Context $context
        Assert-NotNull $tenantSyncState
        Assert-AreEqual $true $tenantSyncState.IsGitEnabled
        Assert-AreEqual "master" $tenantSyncState.Branch

        # Do a Validate to populate the master Branch with current state of Configuration database
        $validateResponse = Publish-AzApiManagementTenantGitConfiguration -Context $context -Branch 'master' -ValidateOnly -PassThru

        Assert-NotNull $validateResponse
        Assert-AreEqual "Succeeded" $validateResponse.State
        Assert-Null $validateResponse.Error

        # Do a Deploy to populate the master Branch with current state of Configuration database
        $deployResponse = Publish-AzApiManagementTenantGitConfiguration -Context $context -Branch 'master' -PassThru

        Assert-NotNull $deployResponse
        Assert-AreEqual "Succeeded" $deployResponse.State
        Assert-Null $deployResponse.Error

        #get Tenant Sync state after Publish
        $tenantSyncState = $null
        $tenantSyncState = Get-AzApiManagementTenantSyncState -Context $context
        Assert-NotNull $tenantSyncState
        Assert-AreEqual $true $tenantSyncState.IsGitEnabled
        Assert-AreEqual "master" $tenantSyncState.Branch
        Assert-AreEqual $true $tenantSyncState.IsSynced
    }
    finally {

    }
}

<#
.SYNOPSIS
Tests operations on Tenant Access.
#>
function TenantAccessConfiguration-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    try {
        $tenantAccess = Get-AzApiManagementTenantAccess -Context $context

        Assert-NotNull $tenantAccess
        Assert-AreEqual $false $tenantAccess.Enabled

        #enable Tenant Access
        $tenantAccess = $null
        $tenantAccess = Set-AzApiManagementTenantAccess -Context $context -Enabled $true -PassThru

        Assert-NotNull $tenantAccess
        Assert-AreEqual $true $tenantAccess.Enabled
    }
    finally {
        Set-AzApiManagementTenantAccess -Context $context -Enabled $false -PassThru
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Identity Provider Configuration.
#>
function IdentityProvider-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # create facebook identity provider configuration with default parameters
    $identityProviderName = 'Facebook'
    try {
        $clientId = getAssetName
        $clientSecret = getAssetName

        $identityProvider = New-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName -ClientId $clientId -ClientSecret $clientSecret

        Assert-NotNull $identityProvider
        Assert-AreEqual $identityProviderName $identityProvider.Type
        Assert-AreEqual $clientId $identityProvider.ClientId
        Assert-AreEqual $clientSecret $identityProvider.ClientSecret

        # get identity provider using Name
        $identityProvider = $null
        $identityProvider = Get-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName

        Assert-NotNull $identityProvider
        Assert-AreEqual $identityProviderName $identityProvider.Type
        Assert-Null $identityProvider.ClientSecret

        $identityProvider = Get-AzApiManagementIdentityProviderClientSecret -Context $context -Type $identityProviderName
        Assert-AreEqual $clientSecret $identityProvider.ClientSecret

        #get all Identity Providers
        $identityProviders = Get-AzApiManagementIdentityProvider -Context $context

        Assert-NotNull $identityProviders
        Assert-AreEqual 1 $identityProviders.Count

        #update the provider with Secret
        $clientSecret = getAssetName
        $identityProvider = Set-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName -ClientSecret $clientSecret -PassThru

        Assert-AreEqual $identityProviderName $identityProvider.Type
        Assert-Null $identityProvider.ClientSecret
        Assert-AreEqual $clientId $identityProvider.ClientId

        $identityProvider = Get-AzApiManagementIdentityProviderClientSecret -Context $context -Type $identityProviderName
        Assert-AreEqual $clientSecret $identityProvider.ClientSecret

        #remove identity provider configuration
        $removed = Remove-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName -PassThru
        Assert-True { $removed }

        $identityProvider = $null
        try {
            # check it was removed
            $identityProvider = Get-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName
        }
        catch {
        }

        Assert-Null $identityProvider
    }
    finally {
        $removed = Remove-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName -PassThru
        Assert-True { $removed }

        $identityProvider = $null
        try {
            # check it was removed
            $identityProvider = Get-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName
        }
        catch {
        }

        Assert-Null $identityProvider
    }
}

<#
.SYNOPSIS
Tests CRUD operations on AadB2C Identity Provider Configuration.
#>
function IdentityProvider-AadB2C-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # create facebook identity provider configuration with default parameters
    $identityProviderName = 'AadB2C'
    try {
        $clientId = getAssetName
        $clientSecret = getAssetName
        $allowedTenants = 'alzaslon.onmicrosoft.com'
        $signupPolicyName = 'B2C_1_signuppolicy'
        $signinPolicyName = 'B2C_1_signinpolicy'

        $identityProvider = New-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName -ClientId $clientId -ClientSecret $clientSecret `
            -AllowedTenants $allowedTenants -SignupPolicyName $signupPolicyName -SigninPolicyName $signinPolicyName 

        Assert-NotNull $identityProvider
        Assert-AreEqual $identityProviderName $identityProvider.Type
        Assert-AreEqual $clientId $identityProvider.ClientId
        Assert-AreEqual $clientSecret $identityProvider.ClientSecret
        Assert-AreEqual $signinPolicyName $identityProvider.SigninPolicyName
        Assert-AreEqual $signupPolicyName $identityProvider.SignupPolicyName
        Assert-AreEqual 'login.microsoftonline.com' $identityProvider.Authority
        Assert-AreEqual $allowedTenants $identityProvider.AllowedTenants[0]

        # get identity provider using Name
        $identityProvider = $null
        $identityProvider = Get-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName

        Assert-NotNull $identityProvider
        Assert-AreEqual $identityProviderName $identityProvider.Type
        Assert-Null $identityProvider.ClientSecret

        $identityProvider = Get-AzApiManagementIdentityProviderClientSecret -Context $context -Type $identityProviderName
        Assert-AreEqual $clientSecret $identityProvider.ClientSecret

        #get all Identity Providers
        $identityProviders = Get-AzApiManagementIdentityProvider -Context $context

        Assert-NotNull $identityProviders
        Assert-AreEqual 1 $identityProviders.Count

        #update the provider with Secret
        $profileEditingPolicy = 'B2C_1_profileediting'
        $identityProvider = Set-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName -ProfileEditingPolicyName $profileEditingPolicy -PassThru

        Assert-AreEqual $identityProviderName $identityProvider.Type
        Assert-Null $identityProvider.ClientSecret
        Assert-AreEqual $clientId $identityProvider.ClientId
        Assert-AreEqual $signinPolicyName $identityProvider.SigninPolicyName
        Assert-AreEqual $signupPolicyName $identityProvider.SignupPolicyName
        Assert-AreEqual 'login.microsoftonline.com' $identityProvider.Authority
        Assert-AreEqual $allowedTenants $identityProvider.AllowedTenants[0]
        Assert-AreEqual $profileEditingPolicy $identityProvider.ProfileEditingPolicyName

        $identityProvider = Get-AzApiManagementIdentityProviderClientSecret -Context $context -Type $identityProviderName
        Assert-AreEqual $clientSecret $identityProvider.ClientSecret

        #remove identity provider configuration
        $removed = Remove-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName -PassThru
        Assert-True { $removed }

        $identityProvider = $null
        try {
            # check it was removed
            $identityProvider = Get-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName
        }
        catch {
        }

        Assert-Null $identityProvider
    }
    finally {
        $removed = Remove-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName -PassThru
        Assert-True { $removed }

        $identityProvider = $null
        try {
            # check it was removed
            $identityProvider = Get-AzApiManagementIdentityProvider -Context $context -Type $identityProviderName
        }
        catch {
        }

        Assert-Null $identityProvider
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Backend.
#>
function Backend-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # create backend
    $backendId = getAssetName
    try {
        $title = getAssetName
        $urlEndpoint = 'https://contoso.com/awesomeapi'
        $description = getAssetName
        $skipCertificateChainValidation = $true

        $credential = New-AzApiManagementBackendCredential -AuthorizationHeaderScheme basic -AuthorizationHeaderParameter opensesame -Query @{"sv" = @('xx', 'bb'); "sr" = @('cc') } -Header @{"x-my-1" = @('val1', 'val2') }
        $backend = New-AzApiManagementBackend -Context $context -BackendId $backendId -Url $urlEndpoint -Protocol http -Title $title -SkipCertificateChainValidation $skipCertificateChainValidation -Credential $credential -Description $description

        Assert-AreEqual $backendId $backend.BackendId
        Assert-AreEqual $description $backend.Description
        Assert-AreEqual $urlEndpoint $backend.Url
        Assert-AreEqual "http" $backend.Protocol
        Assert-NotNull $backend.Credentials
        Assert-NotNull $backend.Credentials.Authorization
        Assert-NotNull $backend.Credentials.Query
        Assert-NotNull $backend.Credentials.Header
        Assert-AreEqual 2 $backend.Credentials.Query.Count
        Assert-AreEqual 1 $backend.Credentials.Header.Count
        Assert-NotNull $backend.Properties
        Assert-AreEqual 1 $backend.Properties.Count

        # update backend description
        $newBackendDescription = getAssetName

        $backend = $null
        $backend = Set-AzApiManagementBackend -Context $context -BackendId $backendId -Description $newBackendDescription -PassThru

        Assert-AreEqual $backendId $backend.BackendId
        Assert-AreEqual $newBackendDescription $backend.Description

        # get all backends
        $backends = Get-AzApiManagementBackend -Context $context

        Assert-NotNull $backends
        Assert-AreEqual 1 $backends.Count

        # get a specific backend
        $backend = $null
        $backend = Get-AzApiManagementBackend -Context $context -BackendId $backendId

        Assert-AreEqual $backendId $backend.BackendId
        Assert-AreEqual $newBackendDescription $backend.Description
        Assert-AreEqual $urlEndpoint $backend.Url
        Assert-AreEqual http $backend.Protocol
        Assert-NotNull $backend.Credentials
        Assert-NotNull $backend.Credentials.Authorization
        Assert-NotNull $backend.Credentials.Query
        Assert-NotNull $backend.Credentials.Header
        Assert-AreEqual 2 $backend.Credentials.Query.Count
        Assert-AreEqual 1 $backend.Credentials.Header.Count
        Assert-NotNull $backend.Properties
        Assert-AreEqual 1 $backend.Properties.Count

        #backend with proxy
        $secpassword = ConvertTo-SecureString "PlainTextPassword" -AsPlainText -Force; <#[SuppressMessage("Microsoft.Security", "CS001:SecretInline", Justification="Secret used in recorded tests only")]#>
        $proxyCreds = New-Object System.Management.Automation.PSCredential ("foo", $secpassword)
        $credential = New-AzApiManagementBackendProxy -Url "http://12.168.1.1:8080" -ProxyCredential $proxyCreds

        $backend = Set-AzApiManagementBackend -Context $context -BackendId $backendId -Proxy $credential -PassThru
        Assert-AreEqual $backendId $backend.BackendId
        Assert-AreEqual $newBackendDescription $backend.Description
        Assert-AreEqual $urlEndpoint $backend.Url
        Assert-AreEqual http $backend.Protocol
        Assert-NotNull $backend.Credentials
        Assert-NotNull $backend.Credentials.Authorization
        Assert-NotNull $backend.Credentials.Query
        Assert-NotNull $backend.Credentials.Header
        Assert-AreEqual 2 $backend.Credentials.Query.Count
        Assert-AreEqual 1 $backend.Credentials.Header.Count
        Assert-NotNull $backend.Properties
        Assert-AreEqual 1 $backend.Properties.Count
        Assert-NotNull $backend.Proxy
        Assert-AreEqual $backend.Proxy.Url "http://12.168.1.1:8080"
        Assert-NotNull $backend.Proxy.ProxyCredentials
    }
    finally {
        # remove created backend
        $removed = Remove-AzApiManagementBackend -Context $context -BackendId $backendId -PassThru
        Assert-True { $removed }

        $backend = $null
        try {
            # check it was removed
            $backend = Get-AzApiManagementBackend -Context $context -BackendId $backendId
        }
        catch {
        }

        Assert-Null $backend
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Backend of type service fabric.
#>
function BackendServiceFabric-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all backends
    $backends = Get-AzApiManagementBackend -Context $context
    Assert-AreEqual 0 $backends.Count

    # create certificate
    $certId = getAssetName    
    $certPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "powershelltest.pfx"
    #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
    $certPassword = 'Password'
    $certSubject = "CN=*.msitesting.net"
    $certThumbprint = '8E989652CABCF585ACBFCB9C2C91F1D174FDB3A2'

    # create backend
    $backendId = getAssetName
    
    try {
        # upload the client certificate
        $cert = New-AzApiManagementCertificate -Context $context -CertificateId $certId -PfxFilePath $certPath -PfxPassword $certPassword

        Assert-AreEqual $certId $cert.CertificateId
        Assert-AreEqual $certThumbprint $cert.Thumbprint
        Assert-AreEqual $certSubject $cert.Subject

        $title = getAssetName
        $urlEndpoint = 'fabric:/mytestapp/mytestservice'
        $description = getAssetName

        $ManagementEndpoints = 'https://sfbackend-01.net:443', 'https://sfbackend-02.net:443'
        $ServerCertificateThumbprints = $cert.Thumbprint
        $serviceFabric = New-AzApiManagementBackendServiceFabric -ManagementEndpoint  $ManagementEndpoints -ClientCertificateThumbprint $cert.Thumbprint `
            -ServerX509Name @{"CN=foobar.net" = $cert.Thumbprint }

        $backend = New-AzApiManagementBackend -Context $context -BackendId $backendId -Url $urlEndpoint -Protocol http -Title $title -ServiceFabricCluster $serviceFabric  `
            -Description $description

        Assert-AreEqual $backendId $backend.BackendId
        Assert-AreEqual $description $backend.Description
        Assert-AreEqual $urlEndpoint $backend.Url
        Assert-AreEqual "http" $backend.Protocol
        Assert-Null $backend.Credentials
        Assert-NotNull $backend.ServiceFabricCluster
        Assert-AreEqual 2 $backend.ServiceFabricCluster.ManagementEndpoints.Count
        Assert-AreEqual $cert.Thumbprint $backend.ServiceFabricCluster.ClientCertificateThumbprint
        Assert-Null $backend.ServiceFabricCluster.ServerCertificateThumbprint
        Assert-NotNull $backend.ServiceFabricCluster.ServerX509Names
        Assert-AreEqual 1 $backend.ServiceFabricCluster.ServerX509Names.Count
        # default partition resolution retries is 3
        Assert-AreEqual 3 $backend.ServiceFabricCluster.MaxPartitionResolutionRetries
        Assert-Null $backend.Properties

        # update backend description
        $newBackendDescription = getAssetName

        $backend = $null
        $backend = Set-AzApiManagementBackend -Context $context -BackendId $backendId -Description $newBackendDescription -PassThru

        Assert-AreEqual $backendId $backend.BackendId
        Assert-AreEqual $newBackendDescription $backend.Description
       
        # get all backends
        $backends = Get-AzApiManagementBackend -Context $context
		
        Assert-NotNull $backends
        Assert-AreEqual 1 $backends.Count
		
        # get a specific backend
        $backend = $null
        $backend = Get-AzApiManagementBackend -Context $context -BackendId $backendId

        Assert-AreEqual $backendId $backend.BackendId
        Assert-AreEqual $newBackendDescription $backend.Description
        Assert-AreEqual $urlEndpoint $backend.Url
        Assert-AreEqual http $backend.Protocol
        Assert-Null $backend.Credentials
        Assert-NotNull $backend.ServiceFabricCluster
        Assert-AreEqual 2 $backend.ServiceFabricCluster.ManagementEndpoints.Count
        Assert-AreEqual $cert.Thumbprint $backend.ServiceFabricCluster.ClientCertificateThumbprint
        Assert-NotNull $backend.ServiceFabricCluster.ServerCertificateThumbprint
        Assert-NotNull $backend.ServiceFabricCluster.ServerX509Names
        Assert-AreEqual 1 $backend.ServiceFabricCluster.ServerX509Names.Count
        # default partition resolution retries is 3
        Assert-AreEqual 3 $backend.ServiceFabricCluster.MaxPartitionResolutionRetries 
        Assert-Null $backend.Properties       
    }
    finally {
        # remove created backend
        $removed = Remove-AzApiManagementBackend -Context $context -BackendId $backendId -PassThru
        Assert-True { $removed }

        $backend = $null
        try {
            # check it was removed
            $backend = Get-AzApiManagementBackend -Context $context -BackendId $backendId
        }
        catch {
        }

        Assert-Null $backend

        # remove created backend
        $removed = Remove-AzApiManagementCertificate -Context $context -CertificateId $certId -PassThru
        Assert-True { $removed }

        $certificate = $null
        try {
            # check it was removed
            $certificate = Get-AzApiManagementCertificate -Context $context -CertificateId $certId
        }
        catch {
        }

        Assert-Null $certificate
    }
}

<#
.SYNOPSIS
Tests CRUD operations of APIVersion set when performing Set ON Api
#>
function ApiVersionSet-SetCrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all apis
    $apiversionsets = Get-AzApiManagementApiVersionSet -Context $context
    # there should be no API Version sets initially
    Assert-AreEqual 0 $apiversionsets.Count

    # new api details
    $swaggerPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "SwaggerPetStoreV2.json"
    $path1 = "swaggerapifromFile"
    $swaggerApiId1 = getAssetName        
    $newApiVersionSetId = getAssetName
    try {
        $newVersionSetName = getAssetName
        $queryName = getAssetName
        $description = getAssetName

        $newApiVersionSet = New-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId -Name $newVersionSetName -Scheme Query `
            -QueryName $queryName -Description $description

        Assert-AreEqual $newApiVersionSetId $newApiVersionSet.ApiVersionSetId
        Assert-AreEqual $newVersionSetName $newApiVersionSet.DisplayName
        Assert-AreEqual $description $newApiVersionSet.Description
        Assert-AreEqual Query $newApiVersionSet.VersioningScheme
        Assert-AreEqual $queryName $newApiVersionSet.VersionQueryName
        Assert-Null $newApiVersionSet.VersionHeaderName

        # update the versioning scheme to be header based
        $versionHeaderName = getAssetName
        $newApiVersionSet = Set-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId  `
            -Scheme Header -HeaderName $versionHeaderName -PassThru

        Assert-AreEqual $newApiVersionSetId $newApiVersionSet.ApiVersionSetId
        Assert-AreEqual $newVersionSetName $newApiVersionSet.DisplayName
        Assert-AreEqual $description $newApiVersionSet.Description
        Assert-AreEqual Header $newApiVersionSet.VersioningScheme
        Assert-AreEqual $versionHeaderName $newApiVersionSet.VersionHeaderName

        # get the api version set using id
        $newApiVersionSet = Get-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId
        Assert-AreEqual $newApiVersionSetId $newApiVersionSet.ApiVersionSetId
        Assert-AreEqual $newVersionSetName $newApiVersionSet.DisplayName
        Assert-AreEqual $description $newApiVersionSet.Description
        Assert-AreEqual Header $newApiVersionSet.VersioningScheme
        Assert-AreEqual $versionHeaderName $newApiVersionSet.VersionHeaderName
        
        # import api from file
        $api = Import-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -SpecificationPath $swaggerPath -SpecificationFormat Swagger -Path $path1
        Assert-AreEqual $swaggerApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path

        # now add the api to the version set
        $api.ApiVersionSetId = $newApiVersionSet.Id
        $api.APIVersion = "v1"
        $api.ApiVersionSetDescription = $newApiVersionSet.Description
        $updatedApi = Set-AzApiManagementApi -InputObject $api -PassThru
        Assert-NotNull $updatedApi
        Assert-AreEqual $newApiVersionSet.Id $updatedApi.ApiVersionSetId
        Assert-AreEqual $newApiVersionSet.Description $updatedApi.ApiVersionSetDescription
        Assert-AreEqual "v1" $updatedApi.ApiVersion
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -PassThru
        Assert-True { $removed }

        # remove created api version set
        $removed = Remove-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests CRUD operations of APIVersion set when Importing an API
#>
function ApiVersionSet-ImportCrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all apis
    $apiversionsets = Get-AzApiManagementApiVersionSet -Context $context

    # there should be no API Version sets initially
    Assert-AreEqual 0 $apiversionsets.Count
    
    # create new api and apiVersionSet
    $swaggerApiId1 = getAssetName
    $newApiVersionSetId = getAssetName
    try {
        $newVersionSetName = getAssetName
        $queryName = getAssetName
        $description = getAssetName

        $newApiVersionSet = New-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId -Name $newVersionSetName -Scheme Query `
            -QueryName $queryName -Description $description

        Assert-AreEqual $newApiVersionSetId $newApiVersionSet.ApiVersionSetId
        Assert-AreEqual $newVersionSetName $newApiVersionSet.DisplayName
        Assert-AreEqual $description $newApiVersionSet.Description
        Assert-AreEqual Query $newApiVersionSet.VersioningScheme
        Assert-AreEqual $queryName $newApiVersionSet.VersionQueryName
        Assert-Null $newApiVersionSet.VersionHeaderName

        # update the versioning scheme to be header based
        $versionHeaderName = getAssetName
        $newApiVersionSet = Set-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId  `
            -Scheme Header -HeaderName $versionHeaderName -PassThru

        Assert-AreEqual $newApiVersionSetId $newApiVersionSet.ApiVersionSetId
        Assert-AreEqual $newVersionSetName $newApiVersionSet.DisplayName
        Assert-AreEqual $description $newApiVersionSet.Description
        Assert-AreEqual Header $newApiVersionSet.VersioningScheme
        Assert-AreEqual $versionHeaderName $newApiVersionSet.VersionHeaderName

        # get the api version set using id
        $newApiVersionSet = Get-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId
        Assert-AreEqual $newApiVersionSetId $newApiVersionSet.ApiVersionSetId
        Assert-AreEqual $newVersionSetName $newApiVersionSet.DisplayName
        Assert-AreEqual $description $newApiVersionSet.Description
        Assert-AreEqual Header $newApiVersionSet.VersioningScheme
        Assert-AreEqual $versionHeaderName $newApiVersionSet.VersionHeaderName

        # now import an api into the ApiVersionSet
        $swaggerPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "SwaggerPetStoreV2.json"
        $path1 = "swaggerapifromFile"        
        $apiVersion = "2"

        $api = Import-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -SpecificationPath $swaggerPath -SpecificationFormat Swagger -Path $path1 -ApiVersion $apiVersion -ApiVersionSetId $newApiVersionSetId
        Assert-NotNull $api
        Assert-AreEqual $apiVersion $api.ApiVersion
        Assert-AreEqual $swaggerApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path
        Assert-AreEqual $newApiVersionSet.Id $api.ApiVersionSetId
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -PassThru
        Assert-True { $removed }

        # remove created api version set
        $removed = Remove-AzApiManagementApiVersionSet -Context $context -ApiVersionSetId $newApiVersionSetId -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests CRUD operations of API.
#>
function ApiRevision-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName
   
    $swaggerPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "SwaggerPetStoreV2.json"
    $path1 = "swaggerapifromFile"
    $swaggerApiId1 = getAssetName
    $apiRevisionId = "2"
    $apiReleaseId = getAssetName
	$apiRevisionDescription = getAssetName

    try {
        # import api from file
        $api = Import-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -SpecificationPath $swaggerPath -SpecificationFormat Swagger -Path $path1

        Assert-AreEqual $swaggerApiId1 $api.ApiId
        Assert-AreEqual $path1 $api.Path

        # add the api to a product
        $product = Get-AzApiManagementProduct -Context $context | Select-Object -First 1
        Add-AzApiManagementApiToProduct -Context $context -ApiId $swaggerApiId1 -ProductId $product.ProductId

        #get by product id
        $found = 0
        $apis = Get-AzApiManagementApi -Context $context -ProductId $product.ProductId
        for ($i = 0; $i -lt $apis.Count; $i++) {
            if ($apis[$i].ApiId -eq $swaggerApiId1) {
                $found = 1
            }
        }
        Assert-AreEqual 1 $found

        # get the number of operations
        $originalOps = Get-AzApiManagementOperation -Context $context -ApiId $swaggerApiId1
        Assert-NotNull $originalOps

        # now lets create an api revision
        $expectedApiId = [string]::Format("{0};rev={1}", $swaggerApiId1, $apiRevisionId) 
        $apiRevision = New-AzApiManagementApiRevision -Context $context -ApiId $swaggerApiId1 -ApiRevision $apiRevisionId -SourceApiRevision "1" -ApiRevisionDescription $apiRevisionDescription
        Assert-AreEqual $expectedApiId $apiRevision.ApiId
        Assert-AreEqual $apiRevisionId $apiRevision.ApiRevision
        Assert-NotNull $apiRevision.ApiRevisionDescription
        Assert-AreEqual $apiRevisionDescription $apiRevision.ApiRevisionDescription
        Assert-AreEqual $path1 $apiRevision.Path        
        Assert-False { $apiRevision.IsCurrent }

        $revisionOperations = Get-AzApiManagementOperation -Context $context -ApiId $swaggerApiId1 -ApiRevision $apiRevisionId
        Assert-NotNull $revisionOperations
        # operations should be copied in the new revision
        Assert-AreEqual $originalOps.Count $revisionOperations.Count 

        # get the api revision details
        $apiRevisionDetails = Get-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -ApiRevision $apiRevisionId
        Assert-AreEqual $expectedApiId $apiRevisionDetails.ApiId
        Assert-AreEqual $path1 $apiRevisionDetails.Path
        Assert-AreEqual $apiRevisionId $apiRevisionDetails.ApiRevision
        Assert-False { $apiRevisionDetails.IsCurrent }

        # get the api revisions. There should be 2 now.
        $apiRevisions = Get-AzApiManagementApiRevision -Context $context -ApiId $swaggerApiId1
        Assert-AreEqual 2 $apiRevisions.Count

        # now lets promote the second revision to current by creating a release
        $apiReleaseNote = getAssetName
        $apiRelease = New-AzApiManagementApiRelease -Context $context -ApiId $swaggerApiId1 -ApiRevision $apiRevisionId `
            -ReleaseId $apiReleaseId -Note $apiReleaseNote
        Assert-AreEqual $apiReleaseId $apiRelease.ReleaseId
        Assert-AreEqual $swaggerApiId1 $apiRelease.ApiId

        # update the api release notes
        $updateReleaseNote = getAssetName        
        $updateApiRelease = Update-AzApiManagementApiRelease -InputObject $apiRelease -Note $updateReleaseNote -PassThru
        Assert-NotNull $updateApiRelease
        Assert-AreEqual $apiReleaseId $updateApiRelease.ReleaseId
        Assert-AreEqual $swaggerApiId1 $updateApiRelease.ApiId
        Assert-AreEqual $updateReleaseNote $updateApiRelease.Notes

        # get the api releases
        $apiReleases = Get-AzApiManagementApiRelease -Context $context -ApiId $swaggerApiId1
        Assert-AreEqual 1 $apiReleases.Count
        
        # remove the non current revision 1
        $result = Remove-AzApiManagementApiRevision -Context $context -ApiId $swaggerApiId1 -ApiRevision "1" -PassThru
        Assert-True { $result }        
    }
    finally {
        # remove created api
        $removed = Remove-AzApiManagementApi -Context $context -ApiId $swaggerApiId1 -PassThru
        Assert-True { $removed }
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Diagnostics set.
#>
function Diagnostic-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all global diagnostics
    $diagnostics = Get-AzApiManagementDiagnostic -Context $context

    # there should be no Diagnostic sets initially
    Assert-AreEqual 0 $diagnostics.Count
    
    # create new applicationinsights diagnostics
    $appInsightsLoggerId = getAssetName
    $newDiagnosticId = 'ApplicationInsights'

    try {
        $instrumentationKey = [guid]::newguid()

        $appInsightsLoggerDescription = getAssetName
        $applogger = New-AzApiManagementLogger -Context $context -LoggerId $appInsightsLoggerId -InstrumentationKey $instrumentationKey.Guid -Description $appInsightsLoggerDescription
        Assert-NotNull $applogger
        Assert-AreEqual 'ApplicationInsights' $applogger.Type
        Assert-AreEqual $appInsightsLoggerId $applogger.LoggerId
        Assert-AreEqual $appInsightsLoggerDescription $applogger.Description

        #create a sampling setting
        $samplingSetting = New-AzApiManagementSamplingSetting -SamplingType Fixed -SamplingPercentage 100
        Assert-NotNull $samplingSetting
        
        #create a http message diagnostics
        $httpMessageDiagnostic = New-AzApiManagementHttpMessageDiagnostic -HeadersToLog 'Content-Type', 'UserAgent' -BodyBytesToLog 100
        Assert-NotNull $httpMessageDiagnostic

        #create pipeline diagnostic
        $pipelineDiagnostic = New-AzApiManagementPipelineDiagnosticSetting -Request $httpMessageDiagnostic -Response $httpMessageDiagnostic
        Assert-NotNull $pipelineDiagnostic

        #create a diagnostic
        $diagnostic = New-AzApiManagementDiagnostic -LoggerId $applogger.LoggerId -Context $context -AlwaysLog AllErrors -SamplingSetting $samplingSetting `
            -FrontEndSetting $pipelineDiagnostic -BackendSetting $pipelineDiagnostic -DiagnosticId $newDiagnosticId
        Assert-NotNull $diagnostic

        Assert-NotNull $diagnostic
        Assert-AreEqual $newDiagnosticId $diagnostic.DiagnosticId
		Assert-AreEqual $applogger.LoggerId $diagnostic.LoggerId
        Assert-AreEqual allErrors $diagnostic.AlwaysLog
        Assert-NotNull $diagnostic.SamplingSetting
        Assert-AreEqual fixed $diagnostic.SamplingSetting.SamplingType
        Assert-AreEqual 100 $diagnostic.SamplingSetting.SamplingPercentage
        Assert-NotNull $diagnostic.FrontendSetting
        Assert-AreEqual 'Content-Type' $diagnostic.FrontendSetting.Request.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $diagnostic.FrontendSetting.Request.HeadersToLog[1]
        Assert-AreEqual 'Content-Type' $diagnostic.FrontendSetting.Response.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $diagnostic.FrontendSetting.Response.HeadersToLog[1]
        Assert-NotNull $diagnostic.BackendSetting
        Assert-AreEqual 'Content-Type' $diagnostic.BackendSetting.Request.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $diagnostic.BackendSetting.Request.HeadersToLog[1]
        Assert-AreEqual 'Content-Type' $diagnostic.BackendSetting.Response.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $diagnostic.BackendSetting.Response.HeadersToLog[1]

        # remove pipeline diagnostic from backend and reduce Sampling percentage to 50%
        $diagnostic.BackendSetting = $null
        $diagnostic.SamplingSetting.SamplingPercentage = 50
        $updateDiagnostic = Set-AzApiManagementDiagnostic -InputObject $diagnostic -PassThru

        Assert-NotNull $updateDiagnostic        
        Assert-AreEqual $newDiagnosticId $updateDiagnostic.DiagnosticId
        Assert-Null $updateDiagnostic.BackendSetting
		Assert-AreEqual $applogger.LoggerId $updateDiagnostic.LoggerId
        Assert-AreEqual fixed $updateDiagnostic.SamplingSetting.SamplingType
        Assert-AreEqual 50 $updateDiagnostic.SamplingSetting.SamplingPercentage        
        Assert-NotNull $updateDiagnostic.FrontEndSetting
        Assert-AreEqual 'Content-Type' $updateDiagnostic.FrontendSetting.Request.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $updateDiagnostic.FrontendSetting.Request.HeadersToLog[1]
        Assert-AreEqual 'Content-Type' $updateDiagnostic.FrontendSetting.Response.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $updateDiagnostic.FrontendSetting.Response.HeadersToLog[1]

        # get the global diagnostic set using id
        $diagnostic = Get-AzApiManagementDiagnostic -Context $context -DiagnosticId $newDiagnosticId
        Assert-NotNull $diagnostic
        Assert-AreEqual $newDiagnosticId $diagnostic.DiagnosticId
		Assert-AreEqual $applogger.LoggerId $diagnostic.LoggerId
        Assert-AreEqual allErrors $diagnostic.AlwaysLog
        Assert-NotNull $diagnostic.SamplingSetting
        Assert-AreEqual fixed $diagnostic.SamplingSetting.SamplingType
        Assert-AreEqual 50 $diagnostic.SamplingSetting.SamplingPercentage
        Assert-NotNull $diagnostic.FrontendSetting
        Assert-Null $diagnostic.BackendSetting

		# get global Diagnostic using ResourceId
		$diagnostic = Get-AzApiManagementDiagnostic -ResourceId $diagnostic.Id
        Assert-NotNull $diagnostic
        Assert-AreEqual $newDiagnosticId $diagnostic.DiagnosticId
		Assert-AreEqual $applogger.LoggerId $diagnostic.LoggerId
        Assert-AreEqual allErrors $diagnostic.AlwaysLog
        Assert-NotNull $diagnostic.SamplingSetting
        Assert-AreEqual fixed $diagnostic.SamplingSetting.SamplingType
        Assert-AreEqual 50 $diagnostic.SamplingSetting.SamplingPercentage
        Assert-NotNull $diagnostic.FrontendSetting
        Assert-Null $diagnostic.BackendSetting

		# remove using Context
        Remove-AzApiManagementDiagnostic -Context $context -DiagnosticId $newDiagnosticId

        $diagnostics = Get-AzApiManagementDiagnostic -Context $context
        Assert-AreEqual 0 $diagnostics.Count
    }
    finally {
        # remove created diagnostic
        $removed = Remove-AzApiManagementDiagnostic -Context $context -DiagnosticId $newDiagnosticId -PassThru
        Assert-True { $removed }

        # remove the logger
        $removed = Remove-AzApiManagementLogger -Context $context -LoggerId $appInsightsLoggerId -PassThru
        Assert-True { $removed }

        # remove all properties
        $properties = Get-AzApiManagementNamedValue -Context $context
        for ($i = 0; $i -lt $properties.Count; $i++) {

            Remove-AzApiManagementNamedValue -Context $context -NamedValueId $properties[$i].NamedValueId
        }
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Diagnostics set.
#>
function ApiDiagnostic-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all apis
    $apis = Get-AzApiManagementApi -Context $context

    # there should be one API
    Assert-AreEqual 1 $apis.Count
    Assert-NotNull $apis[0].ApiId
    Assert-AreEqual "Echo API" $apis[0].Name
    Assert-Null $apis[0].Description

    # get all api diagnostics
    $diagnostics = Get-AzApiManagementDiagnostic -Context $context -ApiId $apis[0].ApiId
    
    # there should be no Diagnostic sets initially
    Assert-AreEqual 0 $diagnostics.Count
    
    # create new applicationinsights diagnostics
    $appInsightsLoggerId = getAssetName
    $newDiagnosticId = 'ApplicationInsights'

    try {
        $instrumentationKey = [guid]::newguid()

        $appInsightsLoggerDescription = getAssetName
        $applogger = New-AzApiManagementLogger -Context $context -LoggerId $appInsightsLoggerId -InstrumentationKey $instrumentationKey.Guid `
            -Description $appInsightsLoggerDescription
        Assert-NotNull $applogger
        Assert-AreEqual 'ApplicationInsights' $applogger.Type
        Assert-AreEqual $appInsightsLoggerId $applogger.LoggerId
        Assert-AreEqual $appInsightsLoggerDescription $applogger.Description

        #create a sampling setting
        $samplingSetting = New-AzApiManagementSamplingSetting -SamplingType Fixed -SamplingPercentage 100
        Assert-NotNull $samplingSetting
        
        #create a http message diagnostics
        $httpMessageDiagnostic = New-AzApiManagementHttpMessageDiagnostic -HeadersToLog 'Content-Type', 'UserAgent' -BodyBytesToLog 100
        Assert-NotNull $httpMessageDiagnostic

        #create pipeline diagnostic
        $pipelineDiagnostic = New-AzApiManagementPipelineDiagnosticSetting -Request $httpMessageDiagnostic -Response $httpMessageDiagnostic
        Assert-NotNull $pipelineDiagnostic

        #create a diagnostic
        $apiDiagnostic = New-AzApiManagementDiagnostic -Context $context -ApiId $apis[0].ApiId -LoggerId $applogger.LoggerId -AlwaysLog AllErrors -SamplingSetting $samplingSetting `
            -FrontEndSetting $pipelineDiagnostic -BackendSetting $pipelineDiagnostic -DiagnosticId $newDiagnosticId
        Assert-NotNull $apiDiagnostic

        Assert-NotNull $apiDiagnostic
        Assert-AreEqual $apis[0].ApiId $apiDiagnostic.ApiId
		Assert-AreEqual $applogger.LoggerId $apiDiagnostic.LoggerId
        Assert-AreEqual $newDiagnosticId $apiDiagnostic.DiagnosticId
        Assert-AreEqual allErrors $apiDiagnostic.AlwaysLog
        Assert-NotNull $apiDiagnostic.SamplingSetting
        Assert-AreEqual fixed $apiDiagnostic.SamplingSetting.SamplingType
        Assert-NotNull $apiDiagnostic.FrontendSetting
        Assert-AreEqual 'Content-Type' $apiDiagnostic.FrontendSetting.Request.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $apiDiagnostic.FrontendSetting.Request.HeadersToLog[1]
        Assert-AreEqual 'Content-Type' $apiDiagnostic.FrontendSetting.Response.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $apiDiagnostic.FrontendSetting.Response.HeadersToLog[1]
        Assert-NotNull $apiDiagnostic.BackendSetting
        Assert-AreEqual 'Content-Type' $apiDiagnostic.BackendSetting.Request.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $apiDiagnostic.BackendSetting.Request.HeadersToLog[1]
        Assert-AreEqual 'Content-Type' $apiDiagnostic.BackendSetting.Response.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $apiDiagnostic.BackendSetting.Response.HeadersToLog[1]

        # remove pipeline diagnostic from backend and reduce Sampling percentage to 50%
        $apiDiagnostic.BackendSetting = $null
        $apiDiagnostic.SamplingSetting.SamplingPercentage = 50
        $updateDiagnostic = Set-AzApiManagementDiagnostic -InputObject $apiDiagnostic -PassThru

        Assert-NotNull $updateDiagnostic  
        Assert-AreEqual $apis[0].ApiId $updateDiagnostic.ApiId      
        Assert-AreEqual $newDiagnosticId $updateDiagnostic.DiagnosticId
		Assert-AreEqual $applogger.LoggerId $updateDiagnostic.LoggerId
        Assert-Null $updateDiagnostic.BackendSetting
        Assert-AreEqual fixed $updateDiagnostic.SamplingSetting.SamplingType
        Assert-AreEqual 50 $updateDiagnostic.SamplingSetting.SamplingPercentage        
        Assert-NotNull $updateDiagnostic.FrontendSetting
        Assert-AreEqual 'Content-Type' $updateDiagnostic.FrontendSetting.Request.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $updateDiagnostic.FrontendSetting.Request.HeadersToLog[1]
        Assert-AreEqual 'Content-Type' $updateDiagnostic.FrontendSetting.Response.HeadersToLog[0]
        Assert-AreEqual 'UserAgent' $updateDiagnostic.FrontendSetting.Response.HeadersToLog[1]

        # get the api diagnostic set using id
        $diagnostic = Get-AzApiManagementDiagnostic -Context $context -DiagnosticId $newDiagnosticId -ApiId $apis[0].ApiId
        Assert-NotNull $diagnostic
        Assert-AreEqual $apis[0].ApiId $diagnostic.ApiId
		Assert-AreEqual $applogger.LoggerId $diagnostic.LoggerId
        Assert-AreEqual $newDiagnosticId $diagnostic.DiagnosticId
        Assert-AreEqual allErrors $diagnostic.AlwaysLog
        Assert-NotNull $diagnostic.SamplingSetting
        Assert-AreEqual fixed $diagnostic.SamplingSetting.SamplingType
        Assert-AreEqual 50 $diagnostic.SamplingSetting.SamplingPercentage
        Assert-NotNull $diagnostic.FrontendSetting
        Assert-Null $diagnostic.BackendSetting

		#get api diagnostic using ResourceId
		$diagnostic = Get-AzApiManagementDiagnostic -ResourceId $diagnostic.Id
        Assert-NotNull $diagnostic
        Assert-AreEqual $newDiagnosticId $diagnostic.DiagnosticId
        Assert-AreEqual allErrors $diagnostic.AlwaysLog
        Assert-NotNull $diagnostic.SamplingSetting
        Assert-AreEqual fixed $diagnostic.SamplingSetting.SamplingType
        Assert-AreEqual 50 $diagnostic.SamplingSetting.SamplingPercentage
        Assert-NotNull $diagnostic.FrontendSetting
        Assert-Null $diagnostic.BackendSetting

        Remove-AzApiManagementDiagnostic -Context $context -DiagnosticId $newDiagnosticId -ApiId $apis[0].ApiId

        $diagnostics = Get-AzApiManagementDiagnostic -Context $context -ApiId $apis[0].ApiId
        Assert-AreEqual 0 $diagnostics.Count
    }
    finally {
        # remove created diagnostic
        $removed = Remove-AzApiManagementDiagnostic -Context $context -DiagnosticId $newDiagnosticId -ApiId $apis[0].ApiId -PassThru
        Assert-True { $removed }

        # remove the logger
        $removed = Remove-AzApiManagementLogger -Context $context -LoggerId $appInsightsLoggerId -PassThru
        Assert-True { $removed }

        # remove all properties
        $properties = Get-AzApiManagementNamedValue -Context $context
        for ($i = 0; $i -lt $properties.Count; $i++) {

            Remove-AzApiManagementNamedValue -Context $context -NamedValueId $properties[$i].NamedValueId
        }
    }
}

<#
.SYNOPSIS
Tests CRUD operations on Gateway.
#>
function Gateway-CrudTest {
    Param($resourceGroupName, $serviceName)

    $context = New-AzApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # create non-Secret Property
    $gatewayId = getAssetName
    $hostnameConfigId = getAssetName
    $certId = getAssetName


    $gateways = Get-AzApiManagementGateway -Context $context

   # Assert-AreEqual 0 $gateways.Count

    #for ($i = 0; $i -lt $gateways.Count; $i++) {
    #     Remove-AzApiManagementGateway -Context $context -GatewayId $gateways[$i].GatewayId -PassThru
    #}
       #Remove-AzApiManagementCertificate -Context $context -CertificateId 'ps9906'  -PassThru
    

    try {
        $description = getAssetName
        $locationCity = getAssetName
        $locationName = getAssetName
        $locationRegion = getAssetName
        $locationDistrict = getAssetName

        $hostname = 'contoso.com'

        #create
        $location = New-AzApiManagementResourceLocationObject -Name $locationName -City $locationCity -District $locationDistrict -CountryOrRegion $locationRegion
        $gateway = New-AzApiManagementGateway -Context $context -GatewayId $gatewayId -Description $description -LocationData $location 

        Assert-NotNull $gateway
        Assert-AreEqual $description $gateway.Description
        Assert-AreEqual $locationCity $gateway.LocationData.City
        Assert-AreEqual $locationName $gateway.LocationData.Name
        Assert-AreEqual $locationDistrict $gateway.LocationData.District
        Assert-AreEqual $locationRegion $gateway.LocationData.CountryOrRegion

        #get list
        $gateways = Get-AzApiManagementGateway -Context $context
        Assert-AreEqual 1 $gateways.Count
        $gateway = $gateways[0]
        Assert-NotNull $gateway
        Assert-AreEqual $description $gateway.Description
        Assert-AreEqual $locationCity $gateway.LocationData.City
        Assert-AreEqual $locationName $gateway.LocationData.Name
        Assert-AreEqual $locationDistrict $gateway.LocationData.District
        Assert-AreEqual $locationRegion $gateway.LocationData.CountryOrRegion

        #get
        $gateway = Get-AzApiManagementGateway -Context $context -GatewayId $gatewayId
        Assert-NotNull $gateway
        Assert-AreEqual $description $gateway.Description
        Assert-AreEqual $locationCity $gateway.LocationData.City
        Assert-AreEqual $locationName $gateway.LocationData.Name
        Assert-AreEqual $locationDistrict $gateway.LocationData.District
        Assert-AreEqual $locationRegion $gateway.LocationData.CountryOrRegion

        #update pipeline
        $newDescription = getAssetName
        $gateway = Get-AzApiManagementGateway -Context $context -GatewayId $gatewayId | Update-AzApiManagementGateway -Description $newDescription -PassThru
        Assert-NotNull $gateway
        Assert-AreEqual $newDescription $gateway.Description
        Assert-AreEqual $locationCity $gateway.LocationData.City

        #update
        $newDescription = getAssetName
        $gateway = Update-AzApiManagementGateway -Context $context -GatewayId $gatewayId -Description $newDescription -PassThru
        Assert-NotNull $gateway
        Assert-AreEqual $newDescription $gateway.Description
        Assert-AreEqual $locationCity $gateway.LocationData.City
        Assert-AreEqual $locationName $gateway.LocationData.Name
        Assert-AreEqual $locationDistrict $gateway.LocationData.District
        Assert-AreEqual $locationRegion $gateway.LocationData.CountryOrRegion

        #update location
        $newLocationCity = getAssetName
        $location = New-AzApiManagementResourceLocationObject -Name $locationName -City $newLocationCity
        $gateway = Update-AzApiManagementGateway -Context $context -GatewayId $gatewayId -LocationData @location -PassThru
        Assert-NotNull $gateway
        Assert-AreEqual $newDescription $gateway.Description
        Assert-AreEqual $newLocationCity $gateway.LocationData.City
        Assert-AreEqual $locationName $gateway.LocationData.Name
        Assert-Null $gateway.LocationData.District
        Assert-Null $gateway.LocationData.CountryOrRegion

        #get keys
        $key = Get-AzApiManagementGatewayKey -Context $context -GatewayId $gatewayId
        Assert-NotNull $key
        Assert-NotNull $key.PrimaryKey
        Assert-NotNull $key.SecondaryKey

        #attach to api
        $apis = Get-AzApiManagementApi -Context $context
        $apiId = $apis[0].ApiId

        Add-AzApiManagementApiToGateway -Context $context -GatewayId $gatewayId -ApiId $apiId  

        $apis = Get-AzApiManagementApi -Context $context -GatewayId $gatewayId
        Assert-AreEqual 1 $apis.Count

        #detach from api
        Remove-AzApiManagementApiFromGateway -Context $context -GatewayId $gatewayId -ApiId $apiId -PassThru

        $apis = Get-AzApiManagementApi -Context $context -GatewayId $gatewayId
        Assert-AreEqual 0 $apis.Count

        $certPath = Join-Path (Join-Path "$TestOutputRoot" "Resources") "powershelltest.pfx"
        #[SuppressMessage("Microsoft.Security", "CS002:SecretInNextLine")]
        $certPassword = 'Password'
        $certSubject = "CN=*.msitesting.net"
        # upload certificate
        $cert = New-AzApiManagementCertificate -Context $context -CertificateId $certId -PfxFilePath $certPath -PfxPassword $certPassword

        #create hostname config
        $hostnameConfig = New-AzApiManagementGatewayHostnameConfiguration -Context $context -GatewayId $gatewayId -CertificateResourceId $cert.Id -GatewayHostnameConfigurationId $hostnameConfigId -Hostname $hostname
        Assert-NotNull $hostnameConfig
        Assert-AreEqual $hostname $hostnameConfig.Hostname
        Assert-AreEqual $cert.Id $hostnameConfig.CertificateResourceId
        Assert-AreEqual $false $hostnameConfig.NegotiateClientCertificate

        #get config
        $hostnameConfig = Get-AzApiManagementGatewayHostnameConfiguration -Context $context -GatewayId $gatewayId -GatewayHostnameConfigurationId $hostnameConfigId
        Assert-NotNull $hostnameConfig
        Assert-AreEqual $hostname $hostnameConfig.Hostname
        Assert-AreEqual $cert.Id $hostnameConfig.CertificateResourceId
        Assert-AreEqual $false $hostnameConfig.NegotiateClientCertificate

        #list config
        $hostnameConfigs = Get-AzApiManagementGatewayHostnameConfiguration -Context $context -GatewayId $gatewayId
        Assert-AreEqual 1 $hostnameConfigs.Count
        $hostnameConfig = $hostnameConfigs[0]
        Assert-AreEqual $hostname $hostnameConfig.Hostname
        Assert-AreEqual $cert.Id $hostnameConfig.CertificateResourceId
        Assert-AreEqual $false $hostnameConfig.NegotiateClientCertificate
    }
    finally {
        Remove-AzApiManagementGatewayHostnameConfiguration -Context $context -GatewayId $gatewayId -GatewayHostnameConfigurationId $hostnameConfigId -PassThru

        Remove-AzApiManagementCertificate -Context $context -CertificateId $certId  -PassThru

        $removed = Remove-AzApiManagementGateway -Context $context -GatewayId $gatewayId -PassThru
        Assert-True { $removed }

        $gateway = $null
        try {
            # check it was removed
            $gateway = Get-AzApiManagementGateway -Context $context -GatewayId $gatewayId
        }
        catch {
        }

        Assert-Null $gateway
    }
}