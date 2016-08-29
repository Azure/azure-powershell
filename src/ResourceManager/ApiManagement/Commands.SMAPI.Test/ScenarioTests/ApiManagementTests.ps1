# ----------------------------------------------------------------------------------
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
function Api-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all apis
    $apis = Get-AzureRmApiManagementApi -Context $context

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

    $api = Get-AzureRmApiManagementApi -Context $context -ApiId $apiId

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

    $apis = Get-AzureRmApiManagementApi -Context $context -Name $apiName

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
    try
    {
        $newApiName = getAssetName
        $newApiDescription = getAssetName
        $newApiPath = getAssetName
        $newApiServiceUrl = "http://newechoapi.cloudapp.net/newapi"
        $subscriptionKeyParametersHeader = getAssetName
        $subscriptionKeyQueryStringParamName = getAssetName

        $newApi = New-AzureRmApiManagementApi -Context $context -ApiId $newApiId -Name $newApiName -Description $newApiDescription `
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

        $newApi = Set-AzureRmApiManagementApi -Context $context -ApiId $newApiId -Name $newApiName -Description $newApiDescription `
        -Protocols @("https") -Path $newApiPath -ServiceUrl $newApiServiceUrl `
        -SubscriptionKeyHeaderName $subscriptionKeyParametersHeader -SubscriptionKeyQueryParamName $subscriptionKeyQueryStringParamName `
        -PassThru

        Assert-AreEqual $newApiId $newApi.ApiId
        Assert-AreEqual $newApiName $newApi.Name
        Assert-AreEqual $newApiDescription.Description
        Assert-AreEqual $newApiServiceUrl $newApi.ServiceUrl
        Assert-AreEqual $newApiPath $newApi.Path
        Assert-AreEqual 1 $newApi.Protocols.Length
        Assert-AreEqual https $newApi.Protocols[0]
        Assert-Null $newApi.AuthorizationServerId
        Assert-Null $newApi.AuthorizationScope
        Assert-AreEqual $subscriptionKeyParametersHeader $newApi.SubscriptionKeyHeaderName
        Assert-AreEqual $subscriptionKeyQueryStringParamName $newApi.SubscriptionKeyQueryParamName

        $product = Get-AzureRmApiManagementProduct -Context $context | Select -First 1
        Add-AzureRmApiManagementApiToProduct -Context $context -ApiId $newApiId -ProductId $product.ProductId

        #get by product id
        $found = 0
        $apis = Get-AzureRmApiManagementApi -Context $context -ProductId $product.ProductId
        for ($i = 0; $i -lt $apis.Count; $i++)
        {
            if($apis[$i].ApiId -eq $newApiId)
            {
                $found = 1
            }
        }
        Assert-AreEqual 1 $found

        Remove-AzureRmApiManagementApiFromProduct -Context $context -ApiId $newApiId -ProductId $product.ProductId
        $found = 0
        $apis = Get-AzureRmApiManagementApi -Context $context -ProductId $product.ProductId
        for ($i = 0; $i -lt $apis.Count; $i++)
        {
            if($apis[$i].ApiId -eq $newApiId)
            {
                $found = 1
            }
        }
        Assert-AreEqual 0 $found
    }
    finally
    {
        # remove created api
        $removed = Remove-AzureRmApiManagementApi -Context $context -ApiId $newApiId -PassThru -Force
        Assert-True {$removed}
    }
}

<#
.SYNOPSIS
Tests API import/export.
#>
function Api-ImportExportTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    $wadlPath = "./Resources/WADLYahoo.xml"
    $path = "wadlapi"
    $wadlApiId = getAssetName

    try
    {
        # import api from file
        $api = Import-AzureRmApiManagementApi -Context $context -ApiId $wadlApiId -SpecificationPath $wadlPath -SpecificationFormat Wadl -Path $path

        Assert-AreEqual $wadlApiId $api.ApiId
        Assert-AreEqual $path $api.Path

        # export api to pipline
        $result = Export-AzureRmApiManagementApi -Context $context -ApiId $wadlApiId -SpecificationFormat Wadl

        Assert-True {$result -like '*<doc title="Yahoo News Search">Yahoo News Search API</doc>*'}
    }
    finally
    {
        # remove created api
        $removed = Remove-AzureRmApiManagementApi -Context $context -ApiId $wadlApiId -PassThru -Force
        Assert-True {$removed}
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Operations.
#>
function Operations-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get api
    $api = Get-AzureRmApiManagementApi -Context $context -Name 'Echo API'| Select -First 1

    # get all api operations
    $operations = Get-AzureRmApiManagementOperation -Context $context -ApiId $api.ApiId

    Assert-AreEqual 6 $operations.Count
    for ($i = 0; $i -lt $operations.Count; $i++)
    {
        Assert-AreEqual $api.ApiId $operations[$i].ApiId

        $operation = Get-AzureRmApiManagementOperation -Context $context -ApiId $api.ApiId -OperationId $operations[$i].OperationId

        Assert-AreEqual $api.ApiId $operation.ApiId
        Assert-AreEqual $operations[$i].OperationId $operation.OperationId
        Assert-AreEqual $operations[$i].Name $operation.Name
        Assert-AreEqual $operations[$i].Description $operation.Description
        Assert-AreEqual $operations[$i].Method $operation.Method
        Assert-AreEqual $operations[$i].UrlTemplate $operation.UrlTemplate
    }

    #add new operation
    $newOperationId = getAssetName
    try
    {
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

        $newOperation = New-AzureRmApiManagementOperation –Context $context –ApiId $api.ApiId –OperationId $newOperationId –Name $newOperationName `
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

        $newOperation = Set-AzureRmApiManagementOperation –Context $context –ApiId $api.ApiId –OperationId $newOperationId –Name $newOperationName `
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
    finally
    {
        #remove created operation
        $removed = Remove-AzureRmApiManagementOperation -Context $context -ApiId $api.ApiId -OperationId $newOperationId -Force -PassThru
        Assert-True {$removed}

        $operation = $null
        try
        {
            # check it was removed
            $operation = Get-AzureRmApiManagementOperation -Context $context -ApiId $api.ApiId -OperationId $newOperationId
        }
        catch
        {
        }

        Assert-Null $operation
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Product.
#>
function Product-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all products
    $products = Get-AzureRmApiManagementProduct -Context $context

    # there should be 2 products
    Assert-AreEqual 2 $products.Count

    $found = 0
    for ($i = 0; $i -lt $products.Count; $i++)
    {
        Assert-NotNull $products[$i].ProductId
        Assert-NotNull $products[$i].Description
        Assert-AreEqual Published $products[$i].State
        
        if($products[$i].Title -eq 'Starter')
        {
            $found += 1;
        }

        if($products[$i].Title -eq 'Unlimited')
        {
            $found += 1;
        }
    }
    Assert-AreEqual 2 $found

    #create new product
    $productId = getAssetName
    try
    {
        $productName = getAssetName
        $productApprovalRequired = $TRUE
        $productDescription = getAssetName
        $productState = "Published"
        $productSubscriptionRequired = $TRUE
        $productSubscriptionsLimit = 10
        $productTerms = getAssetName

        $newProduct = New-AzureRmApiManagementProduct -Context $context –ProductId $productId –Title $productName –Description $productDescription `
            –LegalTerms $productTerms –SubscriptionRequired $productSubscriptionRequired `
            –ApprovalRequired $productApprovalRequired –State $productState -SubscriptionsLimit $productSubscriptionsLimit

        Assert-AreEqual $productId $newProduct.ProductId 
        Assert-AreEqual $productName $newProduct.Title
        Assert-AreEqual $productApprovalRequired $newProduct.ApprovalRequired
        Assert-AreEqual $productDescription $newProduct.Description
        Assert-AreEqual "NotPublished" $newProduct.State #product must contain at least one api to be published
        Assert-AreEqual $productSubscriptionRequired $newProduct.SubscriptionRequired
        Assert-AreEqual $productSubscriptionsLimit $newProduct.SubscriptionsLimit
        Assert-AreEqual $productTerms $newProduct.LegalTerms

        #add api to product
        $apis = Get-AzureRmApiManagementApi -Context $context -ProductId $productId
        Assert-AreEqual 0 $apis.Count

        Get-AzureRmApiManagementApi -Context $context | Add-AzureRmApiManagementApiToProduct -Context $context -ProductId $productId

        $apis = Get-AzureRmApiManagementApi -Context $context -ProductId $productId
        Assert-AreEqual 1 $apis.Count

        #modify product
        $productName = getAssetName
        $productApprovalRequired = $FALSE
        $productDescription = getAssetName
        $productState = "Published"
        $productSubscriptionRequired = $TRUE
        $productSubscriptionsLimit = 20
        $productTerms = getAssetName

        $newProduct = Set-AzureRmApiManagementProduct -Context $context –ProductId $productId –Title $productName –Description $productDescription `
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

        #remove api from product
        Get-AzureRmApiManagementApi -Context $context | Remove-AzureRmApiManagementApiFromProduct -Context $context -ProductId $productId

        $apis = Get-AzureRmApiManagementApi -Context $context -ProductId $productId
        Assert-AreEqual 0 $apis.Count
    } 
    finally
    {
        # remove created product
        $removed = Remove-AzureRmApiManagementProduct -Context $context -ProductId $productId -DeleteSubscriptions -PassThru -Force
        Assert-True {$removed}
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Subscription.
#>
function Subscription-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all subscriptions
    $subs = Get-AzureRmApiManagementSubscription -Context $context

    Assert-AreEqual 2 $subs.Count
    for($i = 0; $i -lt $subs.Count; $i++)
    {
        Assert-NotNull $subs[$i]
        Assert-NotNull $subs[$i].UserId
        Assert-NotNull $subs[$i].SubscriptionId
        Assert-NotNull $subs[$i].ProductId
        Assert-NotNull $subs[$i].State
        Assert-NotNull $subs[$i].CreatedDate
        Assert-NotNull $subs[$i].PrimaryKey
        Assert-NotNull $subs[$i].SecondaryKey

        # get by id
        $sub = Get-AzureRmApiManagementSubscription -Context $context -SubscriptionId $subs[$i].SubscriptionId

        Assert-AreEqual $subs[$i].SubscriptionId $sub.SubscriptionId
        Assert-AreEqual $subs[$i].UserId $sub.UserId
        Assert-AreEqual $subs[$i].ProductId $sub.ProductId
        Assert-AreEqual $subs[$i].State $sub.State
        Assert-AreEqual $subs[$i].CreatedDate $sub.CreatedDate
        Assert-AreEqual $subs[$i].PrimaryKey $sub.PrimaryKey
        Assert-AreEqual $subs[$i].SecondaryKey $sub.SecondaryKey
    }

    # update product to accept unlimited number or subscriptions
    Set-AzureRmApiManagementProduct -Context $context -ProductId $subs[0].ProductId -SubscriptionsLimit 100

    # add new subscription
    $newSubscriptionId = getAssetName
    try
    {
        $newSubscriptionName = getAssetName
        $newSubscriptionPk = getAssetName
        $newSubscriptionSk = getAssetName
        $newSubscriptionState = "Active"

        $sub = New-AzureRmApiManagementSubscription -Context $context -SubscriptionId $newSubscriptionId -UserId $subs[0].UserId `
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

        $sub = Set-AzureRmApiManagementSubscription -Context $context -SubscriptionId $newSubscriptionId -Name $patchedName `
            -PrimaryKey $patchedPk -SecondaryKey $patchedSk -ExpiresOn $patchedExpirationDate -PassThru

        Assert-AreEqual $newSubscriptionId $sub.SubscriptionId
        Assert-AreEqual $patchedName $sub.Name
        Assert-AreEqual $patchedPk $sub.PrimaryKey
        Assert-AreEqual $patchedSk $sub.SecondaryKey
        Assert-AreEqual $newSubscriptionState $sub.State
        Assert-AreEqual $patchedExpirationDate $sub.ExpirationDate
    }
    finally
    {
        # remove created subscription
        $removed = Remove-AzureRmApiManagementSubscription -Context $context -SubscriptionId $newSubscriptionId -Force -PassThru
        Assert-True {$removed}

        $sub = $null
        try
        {
            # check it was removed
            $sub = Get-AzureRmApiManagementSubscripiton -Context $context -SubscriptionId $newSubscriptionId
        }
        catch
        {
        }

        Assert-Null $sub
    }
}

<#
.SYNOPSIS
Tests CRUD operations of User.
#>
function User-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all users
    $users = Get-AzureRmApiManagementUser -Context $context

    Assert-AreEqual 1 $users.Count
    Assert-NotNull $users[0].UserId
    Assert-NotNull $users[0].FirstName
    Assert-NotNull $users[0].LastName
    Assert-NotNull $users[0].Email
    Assert-NotNull $users[0].State
    Assert-NotNull $users[0].RegistrationDate

    # get by id
    $user = Get-AzureRmApiManagementUser -Context $context -UserId $users[0].UserId

    Assert-AreEqual $users[0].UserId $user.UserId
    Assert-AreEqual $users[0].FirstName $user.FirstName
    Assert-AreEqual $users[0].LastName $user.LastName
    Assert-AreEqual $users[0].Email $user.Email
    Assert-AreEqual $users[0].State $user.State
    Assert-AreEqual $users[0].RegistrationDate $user.RegistrationDate

    # create user
    $userId = getAssetName
    try
    {
        $userEmail = "contoso@microsoft.com"
        $userFirstName = getAssetName
        $userLastName = getAssetName
        $userPassword = getAssetName
        $userNote = getAssetName
        $userSate = "Active"

        $user = New-AzureRmApiManagementUser -Context $context -UserId $userId -FirstName $userFirstName -LastName $userLastName `
            -Password $userPassword -State $userSate -Note $userNote -Email $userEmail

        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userFirstName $user.FirstName
        Assert-AreEqual $userLastName $user.LastName
        Assert-AreEqual $userNote $user.Note
        Assert-AreEqual $userSate $user.State

        #update user
        $userEmail = "changed.contoso@microsoft.com"
        $userFirstName = getAssetName
        $userLastName = getAssetName
        $userPassword = getAssetName
        $userNote = getAssetName
        $userSate = "Active"

        $user = Set-AzureRmApiManagementUser -Context $context -UserId $userId -FirstName $userFirstName -LastName $userLastName `
            -Password $userPassword -State $userSate -Note $userNote -PassThru -Email $userEmail

        Assert-AreEqual $userId $user.UserId
        Assert-AreEqual $userEmail $user.Email
        Assert-AreEqual $userFirstName $user.FirstName
        Assert-AreEqual $userLastName $user.LastName
        Assert-AreEqual $userNote $user.Note
        Assert-AreEqual $userSate $user.State

        #generate SSO URL for the user
        $ssoUrl = Get-AzureRmApiManagementUserSsoUrl -Context $context -UserId $userId

        Assert-NotNull $ssoUrl
        Assert-AreEqual $true [System.Uri]::IsWellFormedUriString($ssoUrl, 'Absolute')
    }
    finally
    {
        # remove created user
        $removed = Remove-AzureRmApiManagementUser -Context $context -UserId $userId -DeleteSubscriptions -Force -PassThru
        Assert-True {$removed}

        $user = $null
        try
        {
            # check it was removed
            $user = Get-AzureRmApiManagementUser -Context $context -UserId $userId
        }
        catch
        {
        }

        Assert-Null $user
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Group.
#>
function Group-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all groups
    $groups = Get-AzureRmApiManagementGroup -Context $context

    Assert-AreEqual 3 $groups.Count
    for($i = 0; $i -lt 3; $i++)
    {
        Assert-NotNull $groups[$i].GroupId
        Assert-NotNull $groups[$i].Name
        Assert-NotNull $groups[$i].Description
        Assert-NotNull $groups[$i].System
        Assert-NotNull $groups[$i].Type
        
        # get by id
        $group = Get-AzureRmApiManagementGroup -Context $context -GroupId $groups[$i].GroupId

        Assert-AreEqual $group.GroupId $groups[$i].GroupId
        Assert-AreEqual $group.Name $groups[$i].Name
        Assert-AreEqual $group.Description $groups[$i].Description
        Assert-AreEqual $group.System $groups[$i].System
        Assert-AreEqual $group.Type $groups[$i].Type
    }

    # create group with default parameters
    $groupId = getAssetName
    try
    {
        $newGroupName = getAssetName
        $newGroupDescription = getAssetName

        $group = New-AzureRmApiManagementGroup -GroupId $groupId -Context $context -Name $newGroupName -Description $newGroupDescription

        Assert-AreEqual $groupId $group.GroupId
        Assert-AreEqual $newGroupName $group.Name
        Assert-AreEqual $newGroupDescription $group.Description
        Assert-AreEqual $false $group.System
        Assert-AreEqual 'Custom' $group.Type

        # update group
        $newGroupName = getAssetName
        $newGroupDescription = getAssetName

        $group = Set-AzureRmApiManagementGroup -Context $context -GroupId $groupId -Name $newGroupName -Description $newGroupDescription -PassThru

        Assert-AreEqual $groupId $group.GroupId
        Assert-AreEqual $newGroupName $group.Name
        Assert-AreEqual $newGroupDescription $group.Description
        Assert-AreEqual $false $group.System
        Assert-AreEqual 'Custom' $group.Type

        # add Product to Group
        $product = Get-AzureRmApiManagementProduct -Context $context | Select -First 1
        Add-AzureRmApiManagementProductToGroup -Context $context -GroupId $groupId -ProductId $product.ProductId

        #check group products
        $groups = Get-AzureRmApiManagementGroup -Context $context -ProductId $product.ProductId
        Assert-AreEqual 4 $groups.Count

        # remove Product to Group
        Remove-AzureRmApiManagementProductFromGroup -Context $context -GroupId $groupId -ProductId $product.ProductId

        #check group products
        $groups = Get-AzureRmApiManagementGroup -Context $context -ProductId $product.ProductId
        Assert-AreEqual 3 $groups.Count

        # add User to Group
        $user = Get-AzureRmApiManagementUser -Context $context | Select -First 1
        Add-AzureRmApiManagementUserToGroup -Context $context -GroupId $groupId -UserId $user.UserId

        $groups = Get-AzureRmApiManagementGroup -Context $context -UserId $user.UserId
        Assert-AreEqual 3 $groups.Count

        #remove user from group
        Remove-AzureRmApiManagementUserFromGroup -Context $context -GroupId $groupId -UserId $user.UserId
        $groups = Get-AzureRmApiManagementGroup -Context $context -UserId $user.UserId
        Assert-AreEqual 2 $groups.Count
    }
    finally
    {
        # remove created group
        $removed = Remove-AzureRmApiManagementGroup -Context $context -GroupId $groupId -Force -PassThru
        Assert-True {$removed}

        $group = $null
        try
        {
            # check it was removed
            $group = Get-AzureRmApiManagementGroup -Context $context -GroupId $groupId
        }
        catch
        {
        }

        Assert-Null $group
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Policy.
#>
function Policy-CrudTest
{
Param($resourceGroupName, $serviceName)

    # load from file get to pipeline scenarios

    $tenantValidPath = "./Resources/TenantValidPolicy.xml"
    $productValidPath = "./Resources/ProductValidPolicy.xml"
    $apiValidPath = "./Resources/ApiValidPolicy.xml"
    $operationValidPath = "./Resources/OperationValidPolicy.xml"

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # test tenant policy
    try
    {
        $set = Set-AzureRmApiManagementPolicy -Context $context  -PolicyFilePath $tenantValidPath -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzureRmApiManagementPolicy -Context $context 
        Assert-NotNull $policy
        Assert-True {$policy -like '*<find-and-replace from="aaa" to="BBB" />*'}
    }
    finally
    {
        $removed = Remove-AzureRmApiManagementPolicy -Context $context -PassThru -Force
        Assert-AreEqual $true $removed

        $policy = Get-AzureRmApiManagementPolicy -Context $context 
        Assert-Null $policy
    }

    # test product policy
    $product = Get-AzureRmApiManagementProduct -Context $context -Title 'Unlimited' | Select -First 1
    try
    {
        $set = Set-AzureRmApiManagementPolicy -Context $context  -PolicyFilePath $productValidPath -ProductId $product.ProductId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ProductId $product.ProductId
        Assert-NotNull $policy
        Assert-True {$policy -like '*<rate-limit calls="5" renewal-period="60" />*'}
    }
    finally
    {
        $removed = Remove-AzureRmApiManagementPolicy -Context $context -ProductId $product.ProductId -PassThru -Force
        Assert-AreEqual $true $removed

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ProductId $product.ProductId
        Assert-Null $policy
    }

    # test api policy
    $api = Get-AzureRmApiManagementApi -Context $context | Select -First 1
    try
    {
        $set = Set-AzureRmApiManagementPolicy -Context $context  -PolicyFilePath $apiValidPath -ApiId $api.ApiId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ApiId $api.ApiId
        Assert-NotNull $policy
        Assert-True {$policy -like '*<cache-lookup vary-by-developer="false" vary-by-developer-groups="false" downstream-caching-type="none">*'}
    }
    finally
    {
        $removed = Remove-AzureRmApiManagementPolicy -Context $context -ApiId $api.ApiId -PassThru -Force
        Assert-AreEqual $true $removed

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ApiId $api.ApiId
        Assert-Null $policy
    }

    # test operation policy
    $api = Get-AzureRmApiManagementApi -Context $context | Select -First 1
    $operation = Get-AzureRmApiManagementOperation -Context $context -ApiId $api.ApiId | Select -First 1
    try
    {
        $set = Set-AzureRmApiManagementPolicy -Context $context  -PolicyFilePath $operationValidPath -ApiId $api.ApiId `
            -OperationId $operation.OperationId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ApiId $api.ApiId -OperationId $operation.OperationId
        Assert-NotNull $policy
        Assert-True {$policy -like '*<rewrite-uri template="/resource" />*'}
    }
    finally
    {
        $removed = Remove-AzureRmApiManagementPolicy -Context $context -ApiId $api.ApiId -OperationId $operation.OperationId -PassThru -Force
        Assert-AreEqual $true $removed

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ApiId $api.ApiId -OperationId $operation.OperationId
        Assert-Null $policy
    }

    # load from string save to file scenarios

    # test tenant policy
    $tenantValid = '<policies><inbound><find-and-replace from="aaa" to="BBB" /><set-header name="ETag" exists-action="skip"><value>bbyby</value><!-- for multiple headers with the same name add additional value elements --></set-header><set-query-parameter name="additional" exists-action="append"><value>xxbbcczc</value><!-- for multiple parameters with the same name add additional value elements --></set-query-parameter><cross-domain /></inbound><outbound /></policies>'
    try
    {
        $set = Set-AzureRmApiManagementPolicy -Context $context  -Policy $tenantValid -PassThru
        Assert-AreEqual $true $set

        Get-AzureRmApiManagementPolicy -Context $context  -SaveAs 'TenantPolicy.xml' -Force
        $exists = [System.IO.File]::Exists('TenantPolicy.xml')
        $policy = gc 'TenantPolicy.xml'
        Assert-True {$policy -like '*<find-and-replace from="aaa" to="BBB" />*'}
    }
    finally
    {
        $removed = Remove-AzureRmApiManagementPolicy -Context $context -PassThru -Force
        Assert-AreEqual $true $removed

        $policy = Get-AzureRmApiManagementPolicy -Context $context 
        Assert-Null $policy
    }

    # test product policy
    $productValid = '<policies><inbound><rate-limit calls="5" renewal-period="60" /><quota calls="100" renewal-period="604800" /><base /></inbound><outbound><base /></outbound></policies>'
    $product = Get-AzureRmApiManagementProduct -Context $context -Title 'Unlimited' | Select -First 1
    try
    {
        $set = Set-AzureRmApiManagementPolicy -Context $context  -Policy $productValid -ProductId $product.ProductId -PassThru
        Assert-AreEqual $true $set

        Get-AzureRmApiManagementPolicy -Context $context  -ProductId $product.ProductId -SaveAs 'ProductPolicy.xml' -Force
        $exists = [System.IO.File]::Exists('ProductPolicy.xml')
        $policy = gc 'ProductPolicy.xml'
        Assert-True {$policy -like '*<rate-limit calls="5" renewal-period="60" />*'}
    }
    finally
    {
        $removed = Remove-AzureRmApiManagementPolicy -Context $context -ProductId $product.ProductId -PassThru -Force
        Assert-AreEqual $true $removed

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ProductId $product.ProductId
        Assert-Null $policy

        try
        {
            rm 'ProductPolicy.xml'
        }
        catch{}
    }

    # test api policy
    $apiValid = '<policies><inbound><base /><cache-lookup vary-by-developer="false" vary-by-developer-groups="false" downstream-caching-type="none"><vary-by-query-parameter>version</vary-by-query-parameter><vary-by-header>Accept</vary-by-header><vary-by-header>Accept-Charset</vary-by-header></cache-lookup></inbound><outbound><cache-store duration="10" /><base /></outbound></policies>'
    $api = Get-AzureRmApiManagementApi -Context $context | Select -First 1
    try
    {
        $set = Set-AzureRmApiManagementPolicy -Context $context  -Policy $apiValid -ApiId $api.ApiId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ApiId $api.ApiId -SaveAs 'ApiPolicy.xml'
        $exists = [System.IO.File]::Exists('ApiPolicy.xml')
        $policy = gc 'ApiPolicy.xml'
        Assert-True {$policy -like '*<cache-lookup vary-by-developer="false" vary-by-developer-groups="false" downstream-caching-type="none">*'}
    }
    finally
    {
        $removed = Remove-AzureRmApiManagementPolicy -Context $context -ApiId $api.ApiId -PassThru -Force
        Assert-AreEqual $true $removed

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ApiId $api.ApiId
        Assert-Null $policy

        try
        {
            rm 'ApiPolicy.xml'
        }
        catch{}
    }

    # test operation policy
    $operationValid = '<policies><inbound><base /><rewrite-uri template="/resource" /></inbound><outbound><base /></outbound></policies>'
    $api = Get-AzureRmApiManagementApi -Context $context | Select -First 1
    $operation = Get-AzureRmApiManagementOperation -Context $context -ApiId $api.ApiId | Select -First 1
    try
    {
        $set = Set-AzureRmApiManagementPolicy -Context $context  -Policy $operationValid -ApiId $api.ApiId `
            -OperationId $operation.OperationId -PassThru
        Assert-AreEqual $true $set

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ApiId $api.ApiId -OperationId $operation.OperationId `
            -SaveAs 'OperationPolicy.xml'
        $exists = [System.IO.File]::Exists('OperationPolicy.xml')
        $policy = gc 'OperationPolicy.xml'
        Assert-True {$policy -like '*<rewrite-uri template="/resource" />*'}
    }
    finally
    {
        $removed = Remove-AzureRmApiManagementPolicy -Context $context -ApiId $api.ApiId -OperationId $operation.OperationId -PassThru -Force
        Assert-AreEqual $true $removed

        $policy = Get-AzureRmApiManagementPolicy -Context $context  -ApiId $api.ApiId -OperationId $operation.OperationId
        Assert-Null $policy

        try
        {
            rm 'OperationPolicy.xml'
        }
        catch{}
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Certificate.
#>
function Certificate-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all certificates
    $certificates = Get-AzureRmApiManagementCertificate -Context $context

    Assert-AreEqual 0 $certificates.Count

    $certPath = "$TestOutputRoot\Resources\testcertificate.pfx"
    $certPassword = 'powershelltest'
    $certThumbprint = '51A702569BADEDB90A75141B070F2D4B5DDFA447'
    $certSubject = 'CN=ailn.redmond.corp.microsoft.com'

    $certId = getAssetName
    try
    {
        # upload certificate
        $cert = New-AzureRmApiManagementCertificate -Context $context -CertificateId $certId -PfxFilePath $certPath -PfxPassword $certPassword

        Assert-AreEqual $certId $cert.CertificateId
        Assert-AreEqual $certThumbprint $cert.Thumbprint
        Assert-AreEqual $certSubject $cert.Subject

        # get certificate
        $cert = Get-AzureRmApiManagementCertificate -Context $context -CertificateId $certId

        Assert-AreEqual $certId $cert.CertificateId
        Assert-AreEqual $certThumbprint $cert.Thumbprint
        Assert-AreEqual $certSubject $cert.Subject

        # update certificate
        $cert = Set-AzureRmApiManagementCertificate -Context $context -CertificateId $certId -PfxFilePath $certPath -PfxPassword $certPassword -PassThru

        Assert-AreEqual $certId $cert.CertificateId
        Assert-AreEqual $certThumbprint $cert.Thumbprint
        Assert-AreEqual $certSubject $cert.Subject

        # list certificates
        $certificates = Get-AzureRmApiManagementCertificate -Context $context
        Assert-AreEqual 1 $certificates.Count

        Assert-AreEqual $certId $certificates[0].CertificateId
        Assert-AreEqual $certThumbprint $certificates[0].Thumbprint
        Assert-AreEqual $certSubject $certificates[0].Subject
    }
    finally
    {
        # remove uploaded certificate
        $removed = Remove-AzureRmApiManagementCertificate -Context $context -CertificateId $certId -Force -PassThru
        Assert-True {$removed}

        $cert = $null
        try
        {
            # check it was removed
            $cert = Get-AzureRmApiManagementCertificate -Context $context -CertificateId $certId
        }
        catch
        {
        }

        Assert-Null $cert
    }
}

<#
.SYNOPSIS
Tests CRUD operations of AuthorizationServer.
#>
function AuthorizationServer-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName

    # get all authoriaztion servers
    $servers = Get-AzureRmApiManagementAuthorizationServer -Context $context

    Assert-AreEqual 0 $servers.Count

    # create server
    $serverId = getAssetName
    try
    {
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
        $tokenBodyParameters = @{'tokenname'='tokenvalue'}

        $server = New-AzureRmApiManagementAuthorizationServer -Context $context -ServerId $serverId -Name $name -Description $description `
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

        $server = Get-AzureRmApiManagementAuthorizationServer -Context $context -ServerId $serverId

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
        $tokenBodyParameters = @{'tokenname1'='tokenvalue1'}

        $server = Set-AzureRmApiManagementAuthorizationServer -Context $context -ServerId $serverId -Name $name -Description $description `
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
        Assert-AreEqual $clientSecret $server.ClientSecret
        #Assert-AreEqual $resourceOwnerPassword $server.ResourceOwnerPassword
        #Assert-AreEqual $resourceOwnerUsername $server.ResourceOwnerUsername
        Assert-AreEqual $supportState $server.SupportState
        Assert-AreEqual $tokenBodyParameters.Count $server.TokenBodyParameters.Count

        $server = Get-AzureRmApiManagementAuthorizationServer -Context $context -ServerId $serverId

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
        #Assert-AreEqual $resourceOwnerPassword $server.ResourceOwnerPassword
        #Assert-AreEqual $resourceOwnerUsername $server.ResourceOwnerUsername
        Assert-AreEqual $supportState $server.SupportState
        Assert-AreEqual $tokenBodyParameters.Count $server.TokenBodyParameters.Count
    }
    finally
    {
        # remove created server
        $removed = Remove-AzureRmApiManagementAuthorizationServer -Context $context -ServerId $serverId -Force -PassThru
        Assert-True {$removed}

        $server = $null
        try
        {
            # check it was removed
            $server = Get-AzureRmApiManagementAuthorizationServer -Context $context -ServerId $serverId
        }
        catch
        {
        }

        Assert-Null $server
    }
}

<#
.SYNOPSIS
Tests CRUD operations of Logger.
#>
function Logger-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName
	
    # create logger
    $loggerId = getAssetName
    try
    {        
        $newLoggerDescription = getAssetName
		$eventHubName = "sdkeventhub"
		$eventHubConnectionString = "TestConnectionString"

        $logger = New-AzureRmApiManagementLogger -Context $context -LoggerId $loggerId -Name $eventHubName -ConnectionString $eventHubConnectionString -Description $newLoggerDescription

        Assert-AreEqual $loggerId $logger.LoggerId
        Assert-AreEqual $newLoggerDescription $logger.Description
        Assert-AreEqual 'AzureEventHub' $logger.Type
		Assert-AreEqual $true $logger.IsBuffered
        
        # update logger to non-buffered
        $newLoggerDescription = getAssetName

		$logger = $null
        $logger = Set-AzureRmApiManagementLogger -Context $context -LoggerId $loggerId -Description $newLoggerDescription -PassThru

        Assert-AreEqual $loggerId $logger.LoggerId
        Assert-AreEqual $newLoggerDescription $logger.Description
        Assert-AreEqual 'AzureEventHub' $logger.Type
		Assert-AreEqual $false $logger.IsBuffered
       
        # get all Loggers
        $loggers = Get-AzureRmApiManagementLogger -Context $context
		
		Assert-NotNull $loggers
		Assert-AreEqual 1 $loggers.Count
		
		# get a specific logger
		$logger = $null
		$logger = Get-AzureRmApiManagementLogger -Context $context -LoggerId $loggerId
		Assert-AreEqual $loggerId $logger.LoggerId
        Assert-AreEqual $newLoggerDescription $logger.Description
        Assert-AreEqual 'AzureEventHub' $logger.Type
		Assert-AreEqual $false $logger.IsBuffered
        
    }
    finally
    {
        # remove created logger
        $removed = Remove-AzureRmApiManagementLogger -Context $context -LoggerId $loggerId -Force -PassThru
        Assert-True {$removed}

        $logger = $null
        try
        {
            # check it was removed
            $logger = Get-AzureRmApiManagementLogger -Context $context -LoggerId $loggerId
        }
        catch
        {
        }

        Assert-Null $logger
    }
}

<#
.SYNOPSIS
Tests CRUD operations of OpenId Connect Provider.
#>
function OpenIdConnectProvider-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName
	
    # create openIdConnectProvider with default parameters
    $openIdConnectProviderId = getAssetName
    try
    {        
        $openIdConnectProviderName = getAssetName
		$metadataEndpoint = "https://login.microsoftonline.com/contoso.onmicrosoft.com/v2.0/.well-known/openid-configuration"
		$clientId = getAssetName
		$openIdDescription = getAssetName

        $openIdConectProvider = New-AzureRmApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId -Name $openIdConnectProviderName -MetadataEndpointUri $metadataEndpoint -ClientId $clientId -Description $openIdDescription

        Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId
        Assert-AreEqual $openIdConnectProviderName $openIdConectProvider.Name
        Assert-AreEqual $metadataEndpoint $openIdConectProvider.MetadataEndpoint
        Assert-AreEqual $clientId $openIdConectProvider.ClientId
		Assert-AreEqual $openIdDescription $openIdConectProvider.Description
        Assert-Null $openIdConectProvider.ClientSecret

        # get openIdConnectProvider using Name
		$openIdConectProvider = $null
		$openIdConectProvider = Get-AzureRmApiManagementOpenIdConnectProvider -Context $context -Name $openIdConnectProviderName
		
		Assert-NotNull $openIdConectProvider
		Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId
		
		# get OpenId Connect Provider using Id
		$openIdConectProvider = Get-AzureRmApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId
		
		Assert-NotNull $openIdConectProvider
		Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId
				
		#get all openId Connect Providers
		$openIdConectProviders = Get-AzureRmApiManagementOpenIdConnectProvider -Context $context
		Assert-AreEqual 1 $openIdConectProviders.Count
		        
		Assert-NotNull $openIdConectProviders
		Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId

		#update the provider with Secret
		$clientSecret = getAssetName
        $openIdConectProvider = Set-AzureRmApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId -ClientSecret $clientSecret -PassThru

        Assert-AreEqual $openIdConnectProviderId $openIdConectProvider.OpenIdConnectProviderId
        Assert-AreEqual $clientSecret $openIdConectProvider.ClientSecret
		Assert-AreEqual $clientId $openIdConectProvider.ClientId
		Assert-AreEqual $metadataEndpoint $openIdConectProvider.MetadataEndpoint
		Assert-AreEqual $openIdConnectProviderName $openIdConectProvider.Name
        
        #remove openIdConnectProvider
        $removed = Remove-AzureRmApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId -PassThru
		Assert-True {$removed}
        
		$openIdConectProvider = $null
        try
        {
            # check it was removed
            $openIdConectProvider = Get-AzureRmApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId
        }
        catch
        {
        }
		
		Assert-Null $openIdConectProvider
    }
    finally
    {
        $removed = Remove-AzureRmApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId -PassThru -Force
		Assert-True {$removed}
        
		$openIdConectProvider = $null
        try
        {
            # check it was removed
            $openIdConectProvider = Get-AzureRmApiManagementOpenIdConnectProvider -Context $context -OpenIdConnectProviderId $openIdConnectProviderId
        }
        catch
        {
        }
		
		Assert-Null $openIdConectProvider
    }
}

<#
.SYNOPSIS
Tests CRUD operations on Properties.
#>
function Properties-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName
	
    # create non-Secret Property
    $propertyId = getAssetName
	$secretPropertyId = $null
    try
    {        
        $propertyName = getAssetName
		$propertyValue = getAssetName
		$tags = 'sdk', 'powershell'
        $property = New-AzureRmApiManagementProperty -Context $context -PropertyId $propertyId -Name $propertyName -Value $propertyValue -Tags $tags

		Assert-NotNull $property
        Assert-AreEqual $propertyId $property.PropertyId
        Assert-AreEqual $propertyName $property.Name
        Assert-AreEqual $propertyValue $property.Value
        Assert-AreEqual $false  $property.Secret
		Assert-AreEqual 2 $property.Tags.Count
		
		#create Secret Property
		$secretPropertyId = getAssetName
		$secretPropertyName = getAssetName
		$secretPropertyValue = getAssetName		
        $secretProperty = New-AzureRmApiManagementProperty -Context $context -PropertyId $secretPropertyId -Name $secretPropertyName -Value $secretPropertyValue -Secret

		Assert-NotNull $secretProperty
        Assert-AreEqual $secretPropertyId $secretProperty.PropertyId
        Assert-AreEqual $secretPropertyName $secretProperty.Name
        Assert-AreEqual $secretPropertyValue $secretProperty.Value
        Assert-AreEqual $true  $secretProperty.Secret
		Assert-NotNull $secretProperty.Tags
		Assert-AreEqual 0 $secretProperty.Tags.Count

        # get all properties
		$properties = Get-AzureRmApiManagementProperty -Context $context
		
		Assert-NotNull $properties
		# there should be 2 properties
		Assert-AreEqual 2 $properties.Count
		
		# get properties by name
		$properties = $null
		$properties = Get-AzureRmApiManagementProperty -Context $context -Name 'onesdk'
		
		Assert-NotNull $properties
		# both the properties created start with 'onesdk'
		Assert-AreEqual 2 $properties.Count
		
		# get properties by tag
		$properties = $null
		$properties = Get-AzureRmApiManagementProperty -Context $context -Tag 'sdk'
		
		Assert-NotNull $property
		Assert-AreEqual 1 $properties.Count
		
		# get property by Id
		$secretProperty = $null
		$secretProperty = Get-AzureRmApiManagementProperty -Context $context -PropertyId $secretPropertyId
		
		Assert-NotNull $secretProperty
        Assert-AreEqual $secretPropertyId $secretProperty.PropertyId
        Assert-AreEqual $secretPropertyName $secretProperty.Name
        Assert-AreEqual $secretPropertyValue $secretProperty.Value
        Assert-AreEqual $true  $secretProperty.Secret
		Assert-NotNull $secretProperty.Tags
		Assert-AreEqual 0 $secretProperty.Tags.Count
		
		# update the secret property with a tag
		$secretProperty = $null
		$secretProperty = Set-AzureRmApiManagementProperty -Context $context -PropertyId $secretPropertyId -Tags $tags -PassThru
				
		Assert-NotNull $secretProperty
        Assert-AreEqual $secretPropertyId $secretProperty.PropertyId
        Assert-AreEqual $secretPropertyName $secretProperty.Name
        Assert-AreEqual $secretPropertyValue $secretProperty.Value
        Assert-AreEqual $true  $secretProperty.Secret
		Assert-NotNull $secretProperty.Tags
		Assert-AreEqual 2 $secretProperty.Tags.Count
		
		#convert a non secret property to secret
		$property = $null
		$property = Set-AzureRmApiManagementProperty -Context $context -PropertyId $propertyId -Secret $true -PassThru
				
		Assert-NotNull $property
        Assert-AreEqual $propertyId $property.PropertyId
        Assert-AreEqual $propertyName $property.Name
        Assert-AreEqual $propertyValue $property.Value
        Assert-AreEqual $true  $property.Secret
		Assert-NotNull $property.Tags
		Assert-AreEqual 2 $property.Tags.Count
				
        #remove secret property
        $removed = Remove-AzureRmApiManagementProperty -Context $context -PropertyId $secretPropertyId -PassThru
		Assert-True {$removed}
        
		$secretProperty = $null
        try
        {
            # check it was removed
            $secretProperty = Get-AzureRmApiManagementProperty -Context $context -PropertyId $secretPropertyId
        }
        catch
        {
        }
		
		Assert-Null $secretProperty
    }
    finally
    {
		$removed = Remove-AzureRmApiManagementProperty -Context $context -PropertyId $propertyId -PassThru -Force
		Assert-True {$removed}
        
		$property = $null
        try
        {
            # check it was removed
            $property = Get-AzureRmApiManagementProperty -Context $context -PropertyId $propertyId
        }
        catch
        {
        }
		
		Assert-Null $property
		
		# cleanup other Property
		try
		{
			Remove-AzureRmApiManagementProperty -Context $context -PropertyId $secretPropertyId -PassThru -Force
		}
		catch
		{
		}
    }
}

<#
.SYNOPSIS
Tests CRUD operations on Tenant Git Configuration.
#>
function TenantGitConfiguration-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName
	
    try
    {        
        $tenantGitAccess = Get-AzureRmApiManagementTenantGitAccess -Context $context

		Assert-NotNull $tenantGitAccess
        Assert-AreEqual $true $tenantGitAccess.Enabled        
		
		#get Tenant Sync state
		$tenantSyncState = Get-AzureRmApiManagementTenantSyncState -Context $context
		Assert-NotNull $tenantSyncState
		Assert-AreEqual $true $tenantSyncState.IsGitEnabled

        # Do a initial Save to populate the master Branch with current state of Configuration database		
		$saveResponse = Save-AzureRmApiManagementTenantGitConfiguration -Context $context -Branch 'master' -PassThru
		
		Assert-NotNull $saveResponse
		Assert-AreEqual "Succeeded" $saveResponse.State
		Assert-Null $saveResponse.Error

		#get Tenant Sync state after Save
		$tenantSyncState = $null
		$tenantSyncState = Get-AzureRmApiManagementTenantSyncState -Context $context
		Assert-NotNull $tenantSyncState
		Assert-AreEqual $true $tenantSyncState.IsGitEnabled
		Assert-AreEqual "master" $tenantSyncState.Branch
		
		# Do a Validate to populate the master Branch with current state of Configuration database
		$validateResponse = Publish-AzureRmApiManagementTenantGitConfiguration -Context $context -Branch 'master' -ValidateOnly -PassThru
		
		Assert-NotNull $validateResponse
		Assert-AreEqual "Succeeded" $validateResponse.State
		Assert-Null $validateResponse.Error
		
		# Do a Deploy to populate the master Branch with current state of Configuration database
		$deployResponse = Publish-AzureRmApiManagementTenantGitConfiguration -Context $context -Branch 'master' -PassThru
		
		Assert-NotNull $deployResponse
		Assert-AreEqual "Succeeded" $deployResponse.State
		Assert-Null $deployResponse.Error

		#get Tenant Sync state after Publish
		$tenantSyncState = $null
		$tenantSyncState = Get-AzureRmApiManagementTenantSyncState -Context $context
		Assert-NotNull $tenantSyncState
		Assert-AreEqual $true $tenantSyncState.IsGitEnabled
		Assert-AreEqual "master" $tenantSyncState.Branch
		Assert-AreEqual $true $tenantSyncState.IsSynced
    }
    finally
    {
		
    }
}

<#
.SYNOPSIS
Tests operations on Tenant Access.
#>
function TenantAccessConfiguration-CrudTest
{
Param($resourceGroupName, $serviceName)

    $context = New-AzureRmApiManagementContext -ResourceGroupName $resourceGroupName -ServiceName $serviceName
	
    try
    {        
        $tenantAccess = Get-AzureRmApiManagementTenantAccess -Context $context

		Assert-NotNull $tenantAccess
        Assert-AreEqual $false $tenantAccess.Enabled
		
		#enable Tenant Access
		$tenantAccess = $null
        $tenantAccess = Set-AzureRmApiManagementTenantAccess -Context $context -Enabled $true -PassThru

		Assert-NotNull $tenantAccess
		Assert-AreEqual $true $tenantAccess.Enabled
    }
    finally
    {
		Set-AzureRmApiManagementTenantAccess -Context $context -Enabled $false -PassThru
    }
}