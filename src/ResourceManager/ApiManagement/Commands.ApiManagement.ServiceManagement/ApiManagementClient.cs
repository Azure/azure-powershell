//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement
{
    using AutoMapper;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Management.ApiManagement;
    using Microsoft.Azure.Management.ApiManagement.SmapiModels;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ApiManagementClient
    {
        private const string PeriodGroupName = "period";
        private const string ValueGroupName = "value";

        private const string ProductIdPathTemplate = "/products/{0}";
        private const string UserIdPathTemplate = "/users/{0}";

        // pattern: ^(?<period>[DdMmYy]{1})(?<value>\d+)$
        internal const string PeriodPattern = "^(?<" + PeriodGroupName + ">[DdMmYy]{1})(?<" + ValueGroupName + @">\d+)$";
        static readonly Regex PeriodRegex = new Regex(PeriodPattern, RegexOptions.Compiled);

        private readonly AzureContext _context;
        private Management.ApiManagement.ApiManagementClient _client;

        static ApiManagementClient()
        {
            ConfugureMappings();
        }

        private static void ConfugureMappings()
        {
            ConfigureSmapiToPowershellMappings();
            ConfigurePowershellToSmapiMappings();
        }

        private static void ConfigurePowershellToSmapiMappings()
        {
            Mapper.CreateMap<PsApiManagementParameter, ParameterContract>();
            Mapper.CreateMap<PsApiManagementRequest, RequestContract>();
            Mapper.CreateMap<PsApiManagementResponse, ResponseContract>();
            Mapper.CreateMap<PsApiManagementRepresentation, RepresentationContract>();
        }

        private static void ConfigureSmapiToPowershellMappings()
        {
            Mapper
                .CreateMap<ApiContract, PsApiManagementApi>()
                .ForMember(dest => dest.ApiId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Protocols, opt => opt.MapFrom(src => src.Protocols.ToArray()))
                .ForMember(
                    dest => dest.AuthorizationServerId,
                    opt => opt.MapFrom(
                        src => src.AuthenticationSettings != null && src.AuthenticationSettings.OAuth2 != null
                            ? src.AuthenticationSettings.OAuth2.AuthorizationServerId
                            : null))
                .ForMember(
                    dest => dest.AuthorizationScope,
                    opt => opt.MapFrom(
                        src => src.AuthenticationSettings != null && src.AuthenticationSettings.OAuth2 != null
                            ? src.AuthenticationSettings.OAuth2.AuthorizationServerId
                            : null))
                .ForMember(
                    dest => dest.SubscriptionKeyHeaderName,
                    opt => opt.MapFrom(
                        src => src.SubscriptionKeyParameterNames != null
                            ? src.SubscriptionKeyParameterNames.Header
                            : null))
                .ForMember(
                    dest => dest.SubscriptionKeyQueryParamName,
                    opt => opt.MapFrom(
                        src => src.SubscriptionKeyParameterNames != null
                            ? src.SubscriptionKeyParameterNames.Query
                            : null));

            Mapper.CreateMap<RequestContract, PsApiManagementRequest>();
            Mapper.CreateMap<ResponseContract, PsApiManagementResponse>();
            Mapper.CreateMap<RepresentationContract, PsApiManagementRepresentation>();
            Mapper.CreateMap<ParameterContract, PsApiManagementParameter>();
            Mapper.CreateMap<OperationContract, PsApiManagementOperation>();

            Mapper
                .CreateMap<ProductContract, PsApiManagementProduct>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LegalTerms, opt => opt.MapFrom(src => src.Terms));

            Mapper
                .CreateMap<SubscriptionContract, PsApiManagementSubscription>()
                .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.Id));

            Mapper
                .CreateMap<UserContract, PsApiManagementUser>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Identities, opt => opt.MapFrom(src => src.Identities.ToDictionary(key => key.Id, value => value.Provider)));

            Mapper
                .CreateMap<GroupContract, PsApiManagementGroup>()
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Id));

            Mapper
                .CreateMap<CertificateContract, PsApiManagementCertificate>()
                .ForMember(dest => dest.CertificateId, opt => opt.MapFrom(src => src.Id));

            Mapper
                .CreateMap<OAuth2AuthorizationServerContract, PsApiManagementOAuth2AuthrozationServer>()
                .ForMember(dest => dest.ServerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.AccessTokenSendingMethods, opt => opt.MapFrom(src => src.BearerTokenSendingMethods))
                .ForMember(dest => dest.TokenEndpointUrl, opt => opt.MapFrom(src => src.TokenEndpoint))
                .ForMember(dest => dest.AuthorizationEndpointUrl, opt => opt.MapFrom(src => src.AuthorizationEndpoint))
                .ForMember(dest => dest.ClientRegistrationPageUrl, opt => opt.MapFrom(src => src.ClientRegistrationEndpoint))
                .ForMember(dest => dest.ClientAuthenticationMethods, opt => opt.MapFrom(src => src.ClientAuthenticationMethod))
                .ForMember(dest => dest.AuthorizationRequestMethods, opt => opt.MapFrom(src => src.AuthorizationMethods))
                .ForMember(dest => dest.TokenBodyParameters, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                    dest.TokenBodyParameters = src.TokenBodyParameters == null
                        ? (Hashtable)null
                        : new Hashtable(src.TokenBodyParameters.ToDictionary(key => key.Name, value => value.Value)));

            Mapper
                .CreateMap<LoggerGetContract, PsApiManagementLogger>()
                .ForMember(dest => dest.LoggerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsBuffered, opt => opt.MapFrom(src => src.IsBuffered))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            Mapper
                .CreateMap<PropertyContract, PsApiManagementProperty>()
                .ForMember(dest => dest.PropertyId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Secret, opt => opt.MapFrom(src => src.Secret))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags == null ? new string[0] : src.Tags.ToArray()));

            Mapper
                .CreateMap<OpenidConnectProviderContract, PsApiManagementOpenIdConnectProvider>()
                .ForMember(dest => dest.OpenIdConnectProviderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                .ForMember(dest => dest.ClientSecret, opt => opt.MapFrom(src => src.ClientSecret))
                .ForMember(dest => dest.MetadataEndpoint, opt => opt.MapFrom(src => src.MetadataEndpoint));

            Mapper
                .CreateMap<AccessInformationContract, PsApiManagementAccessInformation>()
                .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PrimaryKey, opt => opt.MapFrom(src => src.PrimaryKey))
                .ForMember(dest => dest.SecondaryKey, opt => opt.MapFrom(src => src.SecondaryKey));

            Mapper.CreateMap<TenantConfigurationSyncStateContract, PsApiManagementTenantConfigurationSyncState>();
        }

        public ApiManagementClient(AzureContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("AzureProfile");
            }

            _context = context;
            _client = CreateClient();

        }

        private IApiManagementClient Client
        {
            get { return _client ?? (_client = CreateClient()); }
        }

        private Management.ApiManagement.ApiManagementClient CreateClient()
        {
            return AzureSession.ClientFactory.CreateClient<Management.ApiManagement.ApiManagementClient>(
                _context,
                AzureEnvironment.Endpoint.ResourceManager);
        }

        internal TenantConfigurationLongRunningOperation GetLongRunningOperationStatus(TenantConfigurationLongRunningOperation longRunningOperation)
        {
            var response =
                Client.TenantConfiguration
                    .GetTenantConfigurationLongRunningOperationStatusAsync(longRunningOperation.OperationLink)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

            return TenantConfigurationLongRunningOperation.CreateLongRunningOperation(longRunningOperation.OperationName, response);
        }

        private static IList<T> ListPaged<T>(
            Func<IPagedListResponse<T>> listFirstPage,
            Func<string, IPagedListResponse<T>> listNextPage)
        {
            var resultsList = new List<T>();

            var pagedResponse = listFirstPage();
            resultsList.AddRange(pagedResponse.Result.Values);

            while (!string.IsNullOrEmpty(pagedResponse.Result.NextLink))
            {
                pagedResponse = listNextPage(pagedResponse.Result.NextLink);
                resultsList.AddRange(pagedResponse.Result.Values);
            }

            return resultsList;
        }

        private static IList<TOut> ListPagedAndMap<TOut, TIn>(
            Func<IPagedListResponse<TIn>> listFirstPage,
            Func<string, IPagedListResponse<TIn>> listNextPage)
        {
            IList<TIn> unmappedList = ListPaged(listFirstPage, listNextPage);

            var mappedList = Mapper.Map<IList<TOut>>(unmappedList);

            return mappedList;
        }

        #region APIs
        public IList<PsApiManagementApi> ApiList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementApi, ApiContract>(
                () => Client.Apis.List(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Apis.ListNext(nextLink));

            return results;
        }

        public IList<PsApiManagementApi> ApiByName(PsApiManagementContext context, string name)
        {
            var results = ListPagedAndMap<PsApiManagementApi, ApiContract>(
                () => Client.Apis.List(
                    context.ResourceGroupName,
                    context.ServiceName,
                    new QueryParameters
                    {
                        Filter = string.Format("name eq '{0}'", name)
                    }),
                nextLink => Client.ProductApis.ListNext(nextLink));

            return results;
        }

        public IList<PsApiManagementApi> ApiByProductId(PsApiManagementContext context, string productId)
        {
            var results = ListPagedAndMap<PsApiManagementApi, ApiContract>(
                () => Client.ProductApis.List(context.ResourceGroupName, context.ServiceName, productId, null),
                nextLink => Client.ProductApis.ListNext(nextLink));

            return results;
        }

        public PsApiManagementApi ApiById(PsApiManagementContext context, string id)
        {
            var response = Client.Apis.Get(context.ResourceGroupName, context.ServiceName, id);

            return Mapper.Map<PsApiManagementApi>(response.Value);
        }

        public PsApiManagementApi ApiCreate(
            PsApiManagementContext context,
            string id,
            string name,
            string description,
            string serviceUrl,
            string urlSuffix,
            PsApiManagementSchema[] urlSchema,
            string authorizationServerId,
            string authorizationScope,
            string subscriptionKeyHeaderName,
            string subscriptionKeyQueryParamName)
        {
            var api = new ApiContract
            {
                Name = name,
                Description = description,
                ServiceUrl = serviceUrl,
                Path = urlSuffix,
                Protocols = Mapper.Map<IList<ApiProtocolContract>>(urlSchema),
            };

            if (!string.IsNullOrWhiteSpace(authorizationServerId))
            {
                api.AuthenticationSettings = new AuthenticationSettingsContract
                {
                    OAuth2 = new OAuth2AuthenticationSettingsContract
                    {
                        AuthorizationServerId = authorizationServerId,
                        Scope = authorizationScope
                    }
                };
            }

            if (!string.IsNullOrWhiteSpace(subscriptionKeyHeaderName) || !string.IsNullOrWhiteSpace(subscriptionKeyQueryParamName))
            {
                api.SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract
                {
                    Header = subscriptionKeyHeaderName,
                    Query = subscriptionKeyQueryParamName
                };
            }

            Client.Apis.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, id, new ApiCreateOrUpdateParameters(api), null);

            var getResponse = Client.Apis.Get(context.ResourceGroupName, context.ServiceName, id);

            return Mapper.Map<PsApiManagementApi>(getResponse.Value);
        }

        public void ApiRemove(PsApiManagementContext context, string id)
        {
            Client.Apis.Delete(context.ResourceGroupName, context.ServiceName, id, "*");
        }

        public void ApiSet(
            PsApiManagementContext context,
            string id,
            string name,
            string description,
            string serviceUrl,
            string urlSuffix,
            PsApiManagementSchema[] urlSchema,
            string authorizationServerId,
            string authorizationScope,
            string subscriptionKeyHeaderName,
            string subscriptionKeyQueryParamName)
        {
            var api = new ApiContract
            {
                Name = name,
                Description = description,
                ServiceUrl = serviceUrl,
                Path = urlSuffix,
                Protocols = Mapper.Map<IList<ApiProtocolContract>>(urlSchema),
            };

            if (!string.IsNullOrWhiteSpace(authorizationServerId))
            {
                api.AuthenticationSettings = new AuthenticationSettingsContract
                {
                    OAuth2 = new OAuth2AuthenticationSettingsContract
                    {
                        AuthorizationServerId = authorizationServerId,
                        Scope = authorizationScope
                    }
                };
            }

            if (!string.IsNullOrWhiteSpace(subscriptionKeyHeaderName) || !string.IsNullOrWhiteSpace(subscriptionKeyQueryParamName))
            {
                api.SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract
                {
                    Header = subscriptionKeyHeaderName,
                    Query = subscriptionKeyQueryParamName
                };
            }

            Client.Apis.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, id, new ApiCreateOrUpdateParameters(api), "*");
        }

        public void ApiImportFromFile(
            PsApiManagementContext context,
            string apiId,
            PsApiManagementApiFormat specificationFormat,
            string specificationPath,
            string urlSuffix)
        {
            string contentType;
            switch (specificationFormat)
            {
                case PsApiManagementApiFormat.Wadl:
                    contentType = "application/vnd.sun.wadl+xml";
                    break;
                case PsApiManagementApiFormat.Swagger:
                    contentType = "application/vnd.swagger.doc+json";
                    break;
                default:
                    throw new ArgumentException(string.Format("Format '{0}' is not supported.", specificationFormat));
            }

            using (var fileStream = File.OpenRead(specificationPath))
            {
                Client.Apis.Import(context.ResourceGroupName, context.ServiceName, apiId, contentType, fileStream, urlSuffix);
            }
        }

        public void ApiImportFromUrl(
            PsApiManagementContext context,
            string apiId,
            PsApiManagementApiFormat specificationFormat,
            string specificationUrl,
            string urlSuffix)
        {
            string contentType;
            switch (specificationFormat)
            {
                case PsApiManagementApiFormat.Wadl:
                    contentType = "application/vnd.sun.wadl.link+json";
                    break;
                case PsApiManagementApiFormat.Swagger:
                    contentType = "application/vnd.swagger.link+json";
                    break;
                default:
                    throw new ArgumentException(string.Format("Format '{0}' is not supported.", specificationFormat));
            }

            var jobj = JObject.FromObject(
                new
                {
                    link = specificationUrl
                });

            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(jobj.ToString(Formatting.None))))
            {
                Client.Apis.Import(context.ResourceGroupName, context.ServiceName, apiId, contentType, memoryStream, urlSuffix);
            }
        }

        public byte[] ApiExportToFile(
            PsApiManagementContext context,
            string apiId,
            PsApiManagementApiFormat specificationFormat,
            string saveAs)
        {
            string contentType;
            switch (specificationFormat)
            {
                case PsApiManagementApiFormat.Wadl:
                    contentType = "application/vnd.sun.wadl+xml";
                    break;
                case PsApiManagementApiFormat.Swagger:
                    contentType = "application/vnd.swagger.doc+json";
                    break;
                default:
                    throw new ArgumentException(string.Format("Format '{0}' is not supported.", specificationFormat));
            }

            var response = Client.Apis.Export(context.ResourceGroupName, context.ServiceName, apiId, contentType);
            return response.Content;
        }

        public void ApiAddToProduct(PsApiManagementContext context, string productId, string apiId)
        {
            Client.ProductApis.Add(context.ResourceGroupName, context.ServiceName, productId, apiId);
        }

        public void ApiRemoveFromProduct(PsApiManagementContext context, string productId, string apiId)
        {
            Client.ProductApis.Remove(context.ResourceGroupName, context.ServiceName, productId, apiId);
        }
        #endregion

        #region Operations
        public IList<PsApiManagementOperation> OperationList(PsApiManagementContext context, string apiId)
        {
            var results = ListPagedAndMap<PsApiManagementOperation, OperationContract>(
                () => Client.ApiOperations.List(context.ResourceGroupName, context.ServiceName, apiId, null),
                nextLink => Client.ApiOperations.ListNext(nextLink));

            return results;
        }

        public PsApiManagementOperation OperationById(PsApiManagementContext context, string apiId, string operationId)
        {
            var response = Client.ApiOperations.Get(context.ResourceGroupName, context.ServiceName, apiId, operationId);

            return Mapper.Map<PsApiManagementOperation>(response.Value);
        }

        public PsApiManagementOperation OperationCreate(
            PsApiManagementContext context,
            string apiId,
            string operationId,
            string name,
            string method,
            string urlTemplate,
            string description,
            PsApiManagementParameter[] templateParameters,
            PsApiManagementRequest request,
            PsApiManagementResponse[] responses)
        {
            var operationContract = new OperationContract
            {
                Name = name,
                Description = description,
                Method = method,
                UrlTemplate = urlTemplate,
            };

            if (templateParameters != null)
            {
                operationContract.TemplateParameters = Mapper.Map<IList<ParameterContract>>(templateParameters);
            }

            if (request != null)
            {
                operationContract.Request = Mapper.Map<RequestContract>(request);
            }

            if (responses != null)
            {
                operationContract.Responses = Mapper.Map<IList<ResponseContract>>(responses);
            }

            Client.ApiOperations.Create(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                operationId,
                new OperationCreateOrUpdateParameters(operationContract));

            var getResponse = Client.ApiOperations.Get(context.ResourceGroupName, context.ServiceName, apiId, operationId);

            return Mapper.Map<PsApiManagementOperation>(getResponse.Value);
        }

        public void OperationSet(
            PsApiManagementContext context,
            string apiId,
            string operationId,
            string name,
            string method,
            string urlTemplate,
            string description,
            PsApiManagementParameter[] templateParameters,
            PsApiManagementRequest request,
            PsApiManagementResponse[] responses)
        {
            var operationContract = new OperationContract
            {
                Name = name,
                Description = description,
                Method = method,
                UrlTemplate = urlTemplate,
            };

            if (templateParameters != null)
            {
                operationContract.TemplateParameters = Mapper.Map<IList<ParameterContract>>(templateParameters);
            }

            if (request != null)
            {
                operationContract.Request = Mapper.Map<RequestContract>(request);
            }

            if (responses != null)
            {
                operationContract.Responses = Mapper.Map<IList<ResponseContract>>(responses);
            }

            Client.ApiOperations.Update(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                operationId,
                new OperationCreateOrUpdateParameters(operationContract),
                "*");
        }

        public void OperationRemove(PsApiManagementContext context, string apiId, string operationId)
        {
            Client.ApiOperations.Delete(context.ResourceGroupName, context.ServiceName, apiId, operationId, "*");
        }
        #endregion

        #region Products
        public IList<PsApiManagementProduct> ProductList(PsApiManagementContext context, string title)
        {
            var query = new QueryParameters();
            if (!string.IsNullOrWhiteSpace(title))
            {
                query.Filter = string.Format("name eq '{0}'", title);
            }

            var results = ListPagedAndMap<PsApiManagementProduct, ProductContract>(
                () => Client.Products.List(context.ResourceGroupName, context.ServiceName, query),
                nextLink => Client.Products.ListNext(nextLink));

            return results;
        }

        public PsApiManagementProduct ProductById(PsApiManagementContext context, string productId)
        {
            var response = Client.Products.Get(context.ResourceGroupName, context.ServiceName, productId);
            var product = Mapper.Map<PsApiManagementProduct>(response.Value);

            return product;
        }

        public void ProductRemove(PsApiManagementContext context, string productId, bool deleteSubscriptions)
        {
            Client.Products.Delete(context.ResourceGroupName, context.ServiceName, productId, "*", deleteSubscriptions);
        }

        public PsApiManagementProduct ProductCreate(
            PsApiManagementContext context,
            string productId,
            string title,
            string description,
            string legalTerms,
            bool? subscriptionRequired,
            bool? approvalRequired,
            int? subscriptionsLimit,
            PsApiManagementProductState? state)
        {
            var productContract = new ProductContract(title)
            {
                ApprovalRequired = approvalRequired,
                Description = description,
                SubscriptionRequired = subscriptionRequired,
                SubscriptionsLimit = subscriptionsLimit,
                Terms = legalTerms
            };

            if (state.HasValue)
            {
                switch (state)
                {
                    case PsApiManagementProductState.NotPublished:
                        productContract.State = ProductStateContract.NotPublished;
                        break;
                    case PsApiManagementProductState.Published:
                        productContract.State = ProductStateContract.Published;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("State '{0}' is not supported.", state));
                }
            }

            Client.Products.Create(context.ResourceGroupName, context.ServiceName, productId, new ProductCreateParameters(productContract));
            var response = Client.Products.Get(context.ResourceGroupName, context.ServiceName, productId);

            return Mapper.Map<PsApiManagementProduct>(response.Value);
        }

        public void ProductSet(
            PsApiManagementContext context,
            string productId,
            string title,
            string description,
            string legalTerms,
            bool? subscriptionRequired,
            bool? approvalRequired,
            int? subscriptionsLimit,
            PsApiManagementProductState? state)
        {
            var productUpdateParameters = new ProductUpdateParameters
            {
                Name = title,
                ApprovalRequired = approvalRequired,
                Description = description,
                SubscriptionRequired = subscriptionRequired,
                SubscriptionsLimit = subscriptionsLimit,
                Terms = legalTerms
            };

            if (state.HasValue)
            {
                switch (state)
                {
                    case PsApiManagementProductState.NotPublished:
                        productUpdateParameters.State = ProductStateContract.NotPublished;
                        break;
                    case PsApiManagementProductState.Published:
                        productUpdateParameters.State = ProductStateContract.Published;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("State '{0}' is not supported.", state));
                }
            }

            Client.Products.Update(context.ResourceGroupName, context.ServiceName, productId, productUpdateParameters, "*");
        }

        public void ProductAddToGroup(PsApiManagementContext context, string groupId, string productId)
        {
            Client.ProductGroups.Add(context.ResourceGroupName, context.ServiceName, productId, groupId);
        }

        public void ProductRemoveFromGroup(PsApiManagementContext context, string groupId, string productId)
        {
            Client.ProductGroups.Remove(context.ResourceGroupName, context.ServiceName, productId, groupId);
        }
        #endregion

        #region Subscriptions
        public IList<PsApiManagementSubscription> SubscriptionList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementSubscription, SubscriptionContract>(
                () => Client.Subscriptions.List(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Subscriptions.ListNext(nextLink));

            return results;
        }

        public IList<PsApiManagementSubscription> SubscriptionByUser(PsApiManagementContext context, string userId)
        {
            var results = ListPagedAndMap<PsApiManagementSubscription, SubscriptionContract>(
                () => Client.UserSubscriptions.List(context.ResourceGroupName, context.ServiceName, userId, null),
                nextLink => Client.UserSubscriptions.ListNext(nextLink));

            return results;
        }

        public IList<PsApiManagementSubscription> SubscriptionByProduct(PsApiManagementContext context, string productId)
        {
            var results = ListPagedAndMap<PsApiManagementSubscription, SubscriptionContract>(
                () => Client.ProductSubscriptions.List(context.ResourceGroupName, context.ServiceName, productId, null),
                nextLink => Client.ProductSubscriptions.ListNext(nextLink));

            return results;
        }

        public PsApiManagementSubscription SubscriptionById(PsApiManagementContext context, string subscriptionId)
        {
            var response = Client.Subscriptions.Get(context.ResourceGroupName, context.ServiceName, subscriptionId);
            var subscription = Mapper.Map<PsApiManagementSubscription>(response.Value);

            return subscription;
        }

        public PsApiManagementSubscription SubscriptionCreate(
            PsApiManagementContext context,
            string subscriptionId,
            string productId,
            string userId,
            string name,
            string primaryKey,
            string secondaryKey,
            PsApiManagementSubscriptionState? state)
        {
            var createParameters = new SubscriptionCreateParameters(
                string.Format(UserIdPathTemplate, userId),
                string.Format(ProductIdPathTemplate, productId),
                name)
            {
                Name = name,
                PrimaryKey = primaryKey,
                SecondaryKey = secondaryKey
            };

            if (state.HasValue)
            {
                createParameters.State = Mapper.Map<SubscriptionStateContract>(state.Value);
            }

            Client.Subscriptions.Create(context.ResourceGroupName, context.ServiceName, subscriptionId, createParameters);

            var response = Client.Subscriptions.Get(context.ResourceGroupName, context.ServiceName, subscriptionId);

            return Mapper.Map<PsApiManagementSubscription>(response.Value);
        }

        public void SubscriptionSet(
            PsApiManagementContext context,
            string subscriptionId,
            string name,
            string primaryKey,
            string secondaryKey,
            PsApiManagementSubscriptionState? state,
            DateTime? expiresOn,
            string stateComment)
        {
            var updateParameters = new SubscriptionUpdateParameters
            {
                Name = name,
                PrimaryKey = primaryKey,
                SecondaryKey = secondaryKey,
                ExpiresOn = expiresOn,
                StateComment = stateComment
            };

            if (state.HasValue)
            {
                updateParameters.State = Mapper.Map<SubscriptionStateContract>(state.Value);
            }

            Client.Subscriptions.Update(context.ResourceGroupName, context.ServiceName, subscriptionId, updateParameters, "*");
        }

        public void SubscriptionRemove(PsApiManagementContext context, string subscriptionId)
        {
            Client.Subscriptions.Delete(context.ResourceGroupName, context.ServiceName, subscriptionId, "*");
        }
        #endregion

        #region Users
        public PsApiManagementUser UserCreate(
            PsApiManagementContext context,
            string userId,
            string firstName,
            string lastName,
            string password,
            string email,
            PsApiManagementUserState? state,
            string note)
        {
            var userCreateParameters = new UserCreateParameters
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Note = note,
                Password = password
            };

            if (state.HasValue)
            {
                userCreateParameters.State = Mapper.Map<UserStateContract>(state.Value);
            }

            Client.Users.Create(context.ResourceGroupName, context.ServiceName, userId, userCreateParameters);

            var response = Client.Users.Get(context.ResourceGroupName, context.ServiceName, userId);
            var user = Mapper.Map<PsApiManagementUser>(response.Value);

            return user;
        }

        public void UserSet(
            PsApiManagementContext context,
            string userId,
            string firstName,
            string lastName,
            string password,
            string email,
            PsApiManagementUserState? state,
            string note)
        {
            var userUpdateParameters = new UserUpdateParameters
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Note = note,
                Password = password,
            };

            if (state.HasValue)
            {
                userUpdateParameters.State = Mapper.Map<UserStateContract>(state.Value);
            }

            Client.Users.Update(context.ResourceGroupName, context.ServiceName, userId, userUpdateParameters, "*");
        }

        public IList<PsApiManagementUser> UsersList(
            PsApiManagementContext context,
            string firstName,
            string lastName,
            string email,
            PsApiManagementUserState? state,
            string groupId)
        {
            var query = CreateQueryUserParameters(firstName, lastName, email, state);

            var results = !string.IsNullOrEmpty(groupId)
                ? ListPagedAndMap<PsApiManagementUser, UserContract>(
                    () => Client.GroupUsers.List(context.ResourceGroupName, context.ServiceName, groupId, query),
                    nextLink => Client.GroupUsers.ListNext(nextLink))
                : ListPagedAndMap<PsApiManagementUser, UserContract>(
                    () => Client.Users.List(context.ResourceGroupName, context.ServiceName, query),
                    nextLink => Client.Users.ListNext(nextLink));

            return results;
        }

        public PsApiManagementUser UserById(PsApiManagementContext context, string userId)
        {
            var response = Client.Users.Get(context.ResourceGroupName, context.ServiceName, userId);

            var user = Mapper.Map<PsApiManagementUser>(response.Value);
            return user;
        }

        public void UserRemove(PsApiManagementContext context, string userId, bool deleteSubscriptions)
        {
            Client.Users.Delete(context.ResourceGroupName, context.ServiceName, userId, "*", deleteSubscriptions);
        }

        public string UserGetSsoUrl(PsApiManagementContext context, string userId)
        {
            var response = Client.Users.GenerateSsoUrl(context.ResourceGroupName, context.ServiceName, userId);

            return response.Value;
        }

        public void UserAddToGroup(PsApiManagementContext context, string groupId, string userId)
        {
            Client.UserGroups.AddToGroup(context.ResourceGroupName, context.ServiceName, userId, groupId);
        }

        public void UserRemoveFromGroup(PsApiManagementContext context, string groupId, string userId)
        {
            Client.UserGroups.RemoveFromGroup(context.ResourceGroupName, context.ServiceName, userId, groupId);
        }

        private static QueryParameters CreateQueryUserParameters(string firstName, string lastName, string email, PsApiManagementUserState? state)
        {
            var isFirstCondition = true;
            var query = new QueryParameters();
            if (!string.IsNullOrEmpty(firstName))
            {
                query.Filter = string.Format("firstName eq '{0}'", firstName);
                isFirstCondition = false;
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                if (!isFirstCondition)
                {
                    query.Filter += "&";
                }
                query.Filter = string.Format("lastName eq '{0}'", lastName);
                isFirstCondition = false;
            }

            if (!string.IsNullOrEmpty(email))
            {
                if (!isFirstCondition)
                {
                    query.Filter += "&";
                }
                query.Filter = string.Format("lastName eq '{0}'", email);
                isFirstCondition = false;
            }

            if (state.HasValue)
            {
                if (!isFirstCondition)
                {
                    query.Filter += "&";
                }
                query.Filter = string.Format("state eq '{0}'", state.Value.ToString().ToLowerInvariant());
            }
            return query;
        }
        #endregion

        #region Groups
        public PsApiManagementGroup GroupCreate(PsApiManagementContext context, string groupId, string name, string description)
        {
            var groupCreateParameters = new GroupCreateParameters(name)
            {
                Description = description
            };

            Client.Groups.Create(context.ResourceGroupName, context.ServiceName, groupId, groupCreateParameters);

            var response = Client.Groups.Get(context.ResourceGroupName, context.ServiceName, groupId);
            var group = Mapper.Map<PsApiManagementGroup>(response.Value);

            return group;
        }

        public IList<PsApiManagementGroup> GroupsList(PsApiManagementContext context, string name, string userId, string productId)
        {
            var query = new QueryParameters();
            if (!string.IsNullOrEmpty(name))
            {
                query.Filter = string.Format("name eq '{0}'", name);
            }

            IList<PsApiManagementGroup> results;
            if (!string.IsNullOrWhiteSpace(userId))
            {
                results = ListPagedAndMap<PsApiManagementGroup, GroupContract>(
                    () => Client.UserGroups.List(context.ResourceGroupName, context.ServiceName, userId, query),
                    nextLink => Client.UserGroups.ListNext(nextLink));
            }
            else if (!string.IsNullOrEmpty(productId))
            {
                results = ListPagedAndMap<PsApiManagementGroup, GroupContract>(
                    () => Client.ProductGroups.List(context.ResourceGroupName, context.ServiceName, productId, query),
                    nextLink => Client.ProductGroups.ListNext(nextLink));
            }
            else
            {
                results = ListPagedAndMap<PsApiManagementGroup, GroupContract>(
                    () => Client.Groups.List(context.ResourceGroupName, context.ServiceName, query),
                    nextLink => Client.Groups.ListNext(nextLink));
            }

            return results;
        }

        public PsApiManagementGroup GroupById(PsApiManagementContext context, string groupId)
        {
            var response = Client.Groups.Get(context.ResourceGroupName, context.ServiceName, groupId);
            var group = Mapper.Map<PsApiManagementGroup>(response.Value);

            return group;
        }

        public void GroupRemove(PsApiManagementContext context, string groupId)
        {
            Client.Groups.Delete(context.ResourceGroupName, context.ServiceName, groupId, "*");
        }

        public void GroupSet(PsApiManagementContext context, string groupId, string name, string description)
        {
            Client.Groups.Update(
                context.ResourceGroupName,
                context.ServiceName,
                groupId,
                new GroupUpdateParameters
                {
                    Name = name,
                    Description = description
                },
                "*");
        }
        #endregion

        #region Policy

        private static byte[] PolicyGetWrap(Func<PolicyGetResponse> getPolicyFunc)
        {
            try
            {
                var response = getPolicyFunc();

                return response.PolicyBytes;
            }
            catch (Hyak.Common.CloudException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw;
            }
        }

        public byte[] PolicyGetTenantLevel(PsApiManagementContext context, string format)
        {
            return PolicyGetWrap(() => Client.TenantPolicy.Get(context.ResourceGroupName, context.ServiceName, format));
        }

        public byte[] PolicyGetProductLevel(PsApiManagementContext context, string format, string productId)
        {
            return PolicyGetWrap(() => Client.ProductPolicy.Get(context.ResourceGroupName, context.ServiceName, productId, format));
        }

        public byte[] PolicyGetApiLevel(PsApiManagementContext context, string format, string apiId)
        {
            return PolicyGetWrap(() => Client.ApiPolicy.Get(context.ResourceGroupName, context.ServiceName, apiId, format));
        }

        public byte[] PolicyGetOperationLevel(PsApiManagementContext context, string format, string apiId, string operationId)
        {
            return PolicyGetWrap(() => Client.ApiOperationPolicy.Get(context.ResourceGroupName, context.ServiceName, apiId, operationId, format));
        }

        public void PolicySetTenantLevel(PsApiManagementContext context, string format, Stream stream)
        {
            Client.TenantPolicy.Set(context.ResourceGroupName, context.ServiceName, format, stream, "*");
        }

        public void PolicySetProductLevel(PsApiManagementContext context, string format, Stream stream, string productId)
        {
            Client.ProductPolicy.Set(context.ResourceGroupName, context.ServiceName, productId, format, stream, "*");
        }

        public void PolicySetApiLevel(PsApiManagementContext context, string format, Stream stream, string apiId)
        {
            Client.ApiPolicy.Set(context.ResourceGroupName, context.ServiceName, apiId, format, stream, "*");
        }

        public void PolicySetOperationLevel(PsApiManagementContext context, string format, Stream stream, string apiId, string operationId)
        {
            Client.ApiOperationPolicy.Set(context.ResourceGroupName, context.ServiceName, apiId, operationId, format, stream, "*");
        }

        public void PolicyRemoveTenantLevel(PsApiManagementContext context)
        {
            Client.TenantPolicy.Delete(context.ResourceGroupName, context.ServiceName, "*");
        }

        public void PolicyRemoveProductLevel(PsApiManagementContext context, string productId)
        {
            Client.ProductPolicy.Delete(context.ResourceGroupName, context.ServiceName, productId, "*");
        }

        public void PolicyRemoveApiLevel(PsApiManagementContext context, string apiId)
        {
            Client.ApiPolicy.Delete(context.ResourceGroupName, context.ServiceName, apiId, "*");
        }

        public void PolicyRemoveOperationLevel(PsApiManagementContext context, string apiId, string operationId)
        {
            Client.ApiOperationPolicy.Delete(context.ResourceGroupName, context.ServiceName, apiId, operationId, "*");
        }
        #endregion

        #region Certificates
        public IList<PsApiManagementCertificate> CertificateList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementCertificate, CertificateContract>(
                    () => Client.Certificates.List(context.ResourceGroupName, context.ServiceName, null),
                    nextLink => Client.Certificates.ListNext(nextLink));

            return results;
        }

        public PsApiManagementCertificate CertificateById(PsApiManagementContext context, string certificateId)
        {
            var response = Client.Certificates.Get(context.ResourceGroupName, context.ServiceName, certificateId);

            var certificate = Mapper.Map<PsApiManagementCertificate>(response.Value);

            return certificate;
        }

        public PsApiManagementCertificate CertificateCreate(
            PsApiManagementContext context,
            string certificateId,
            byte[] certificateBytes,
            string pfxPassword)
        {
            var createParameters = new CertificateCreateOrUpdateParameters
            {
                Data = Convert.ToBase64String(certificateBytes),
                Password = pfxPassword
            };

            Client.Certificates.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, certificateId, createParameters, null);

            var response = Client.Certificates.Get(context.ResourceGroupName, context.ServiceName, certificateId);
            var certificate = Mapper.Map<PsApiManagementCertificate>(response.Value);

            return certificate;
        }

        public PsApiManagementCertificate CertificateSet(
            PsApiManagementContext context,
            string certificateId,
            byte[] certificateBytes,
            string pfxPassword)
        {
            var createParameters = new CertificateCreateOrUpdateParameters
            {
                Data = Convert.ToBase64String(certificateBytes),
                Password = pfxPassword
            };

            Client.Certificates.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, certificateId, createParameters, "*");

            var response = Client.Certificates.Get(context.ResourceGroupName, context.ServiceName, certificateId);
            var certificate = Mapper.Map<PsApiManagementCertificate>(response.Value);

            return certificate;
        }

        public void CertificateRemove(PsApiManagementContext context, string certificateId)
        {
            Client.Certificates.Delete(context.ResourceGroupName, context.ServiceName, certificateId, "*");
        }
        #endregion

        #region Authorization Servers

        public IList<PsApiManagementOAuth2AuthrozationServer> AuthorizationServerList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementOAuth2AuthrozationServer, OAuth2AuthorizationServerContract>(
                () => Client.AuthorizationServers.List(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.AuthorizationServers.ListNext(nextLink));

            return results;
        }

        public PsApiManagementOAuth2AuthrozationServer AuthorizationServerById(PsApiManagementContext context, string serverId)
        {
            var response = Client.AuthorizationServers.Get(context.ResourceGroupName, context.ServiceName, serverId);

            var server = Mapper.Map<PsApiManagementOAuth2AuthrozationServer>(response.Value);
            return server;
        }

        public PsApiManagementOAuth2AuthrozationServer AuthorizationServerCreate(
            PsApiManagementContext context,
            string serverId,
            string name,
            string description,
            string clientRegistrationPageUrl,
            string authorizationEndpointUrl,
            string tokenEndpointUrl,
            string clientId,
            string clientSecret,
            PsApiManagementAuthorizationRequestMethod[] authorizationRequestMethods,
            PsApiManagementGrantType[] grantTypes,
            PsApiManagementClientAuthenticationMethod[] clientAuthenticationMethods,
            Hashtable tokenBodyParameters,
            bool? supportState,
            string defaultScope,
            PsApiManagementAccessTokenSendingMethod[] accessTokenSendingMethods,
            string resourceOwnerUsername,
            string resourceOwnerPassword)
        {
            var serverContract = new OAuth2AuthorizationServerContract
            {
                Name = name,
                Description = description,
                ClientRegistrationEndpoint = clientRegistrationPageUrl,
                AuthorizationEndpoint = authorizationEndpointUrl,
                TokenEndpoint = tokenEndpointUrl,
                ClientId = clientId,
                ClientSecret = clientSecret,
                AuthorizationMethods = Mapper.Map<IList<MethodContract>>(authorizationRequestMethods),
                GrantTypes = Mapper.Map<IList<GrantTypesContract>>(grantTypes),
                ClientAuthenticationMethod = Mapper.Map<IList<ClientAuthenticationMethodContract>>(clientAuthenticationMethods),
                SupportState = supportState ?? false,
                DefaultScope = defaultScope,
                BearerTokenSendingMethods = Mapper.Map<IList<BearerTokenSendingMethodsContract>>(accessTokenSendingMethods),
                ResourceOwnerUsername = resourceOwnerUsername,
                ResourceOwnerPassword = resourceOwnerPassword
            };

            if (tokenBodyParameters != null && tokenBodyParameters.Count > 0)
            {
                serverContract.TokenBodyParameters = new List<TokenBodyParameterContract>(tokenBodyParameters.Count);
                foreach (var key in tokenBodyParameters.Keys)
                {
                    serverContract.TokenBodyParameters.Add(
                        new TokenBodyParameterContract
                        {
                            Name = key.ToString(),
                            Value = tokenBodyParameters[key].ToString()
                        });
                }
            }

            Client.AuthorizationServers.Create(
                context.ResourceGroupName,
                context.ServiceName,
                serverId,
                new AuthorizationServerCreateOrUpdateParameters(serverContract));

            var response = Client.AuthorizationServers.Get(context.ResourceGroupName, context.ServiceName, serverId);
            var server = Mapper.Map<PsApiManagementOAuth2AuthrozationServer>(response.Value);

            return server;
        }

        public void AuthorizationServerSet(
            PsApiManagementContext context,
            string serverId,
            string name,
            string description,
            string clientRegistrationPageUrl,
            string authorizationEndpointUrl,
            string tokenEndpointUrl,
            string clientId,
            string clientSecret,
            PsApiManagementAuthorizationRequestMethod[] authorizationRequestMethods,
            PsApiManagementGrantType[] grantTypes,
            PsApiManagementClientAuthenticationMethod[] clientAuthenticationMethods,
            Hashtable tokenBodyParameters,
            bool? supportState,
            string defaultScope,
            PsApiManagementAccessTokenSendingMethod[] accessTokenSendingMethods,
            string resourceOwnerUsername,
            string resourceOwnerPassword)
        {
            var serverContract = new OAuth2AuthorizationServerContract
            {
                Name = name,
                Description = description,
                ClientRegistrationEndpoint = clientRegistrationPageUrl,
                AuthorizationEndpoint = authorizationEndpointUrl,
                TokenEndpoint = tokenEndpointUrl,
                ClientId = clientId,
                ClientSecret = clientSecret,
                AuthorizationMethods = Mapper.Map<IList<MethodContract>>(authorizationRequestMethods),
                GrantTypes = Mapper.Map<IList<GrantTypesContract>>(grantTypes),
                ClientAuthenticationMethod = Mapper.Map<IList<ClientAuthenticationMethodContract>>(clientAuthenticationMethods),
                SupportState = supportState ?? false,
                DefaultScope = defaultScope,
                BearerTokenSendingMethods = Mapper.Map<IList<BearerTokenSendingMethodsContract>>(accessTokenSendingMethods),
                ResourceOwnerUsername = resourceOwnerUsername,
                ResourceOwnerPassword = resourceOwnerPassword
            };

            if (tokenBodyParameters != null && tokenBodyParameters.Count > 0)
            {
                serverContract.TokenBodyParameters = new List<TokenBodyParameterContract>(tokenBodyParameters.Count);
                foreach (var key in tokenBodyParameters.Keys)
                {
                    serverContract.TokenBodyParameters.Add(
                        new TokenBodyParameterContract
                        {
                            Name = key.ToString(),
                            Value = tokenBodyParameters[key].ToString()
                        });
                }
            }

            Client.AuthorizationServers.Update(
                context.ResourceGroupName,
                context.ServiceName,
                serverId,
                new AuthorizationServerCreateOrUpdateParameters(serverContract),
                "*");
        }

        public void AuthorizationServerRemove(PsApiManagementContext context, string serverId)
        {
            Client.AuthorizationServers.Delete(context.ResourceGroupName, context.ServiceName, serverId, "*");
        }
        #endregion

        #region Loggers
        public PsApiManagementLogger LoggerCreate(
            PsApiManagementContext context,
            LoggerTypeContract type,
            string loggerId,
            string description,
            IDictionary<string, string> credentials,
            bool isBuffered)
        {
            var loggerCreateParameters = new LoggerCreateParameters(type, credentials)
            {
                Description = description,
                IsBuffered = isBuffered
            };

            Client.Loggers.Create(context.ResourceGroupName, context.ServiceName, loggerId, loggerCreateParameters);

            var response = Client.Loggers.Get(context.ResourceGroupName, context.ServiceName, loggerId);
            var logger = Mapper.Map<PsApiManagementLogger>(response.Value);

            return logger;
        }

        public IList<PsApiManagementLogger> LoggersList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementLogger, LoggerGetContract>(
                () => Client.Loggers.List(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Loggers.ListNext(nextLink));

            return results;
        }

        public PsApiManagementLogger LoggerById(PsApiManagementContext context, string loggerId)
        {
            var response = Client.Loggers.Get(context.ResourceGroupName, context.ServiceName, loggerId);
            var logger = Mapper.Map<PsApiManagementLogger>(response.Value);

            return logger;
        }

        public void LoggerRemove(PsApiManagementContext context, string loggerId)
        {
            Client.Loggers.Delete(context.ResourceGroupName, context.ServiceName, loggerId, "*");
        }

        public void LoggerSet(
            PsApiManagementContext context,
            LoggerTypeContract type,
            string loggerId,
            string description,
            IDictionary<string, string> credentials,
            bool? isBuffered)
        {
            var loggerUpdateParameters = new LoggerUpdateParameters(type);

            if (!string.IsNullOrWhiteSpace(description))
            {
                loggerUpdateParameters.Description = description;
            }

            if (isBuffered.HasValue)
            {
                loggerUpdateParameters.IsBuffered = isBuffered.Value;
            }

            if (credentials != null && credentials.Count != 0)
            {
                loggerUpdateParameters.Credentials = credentials;
            }

            Client.Loggers.Update(
                context.ResourceGroupName,
                context.ServiceName,
                loggerId,
                loggerUpdateParameters,
                "*");
        }
        #endregion

        #region Properties
        public PsApiManagementProperty PropertyCreate(
            PsApiManagementContext context,
            string propertyId,
            string propertyName,
            string propertyValue,
            bool secret,
            IList<string> tags = null)
        {
            var propertyCreateParameters = new PropertyCreateParameters(propertyName, propertyValue)
            {
                Secret = secret,
                Tags = tags
            };

            Client.Property.Create(context.ResourceGroupName, context.ServiceName, propertyId, propertyCreateParameters);

            var response = Client.Property.Get(context.ResourceGroupName, context.ServiceName, propertyId);
            var property = Mapper.Map<PsApiManagementProperty>(response.Value);

            return property;
        }

        public IList<PsApiManagementProperty> PropertiesList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementProperty, PropertyContract>(
                () => Client.Property.List(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Property.ListNext(nextLink));

            return results;
        }

        public IList<PsApiManagementProperty> PropertyByName(PsApiManagementContext context, string propertyName)
        {
            var results = ListPagedAndMap<PsApiManagementProperty, PropertyContract>(
               () => Client.Property.List(
                   context.ResourceGroupName,
                   context.ServiceName,
                   new QueryParameters
                   {
                       Filter = string.Format("substringof('{0}',name)", propertyName)
                   }),
               nextLink => Client.Property.ListNext(nextLink));

            return results;
        }

        public IList<PsApiManagementProperty> PropertyByTag(PsApiManagementContext context, string propertyTag)
        {
            var results = ListPagedAndMap<PsApiManagementProperty, PropertyContract>(
                () => Client.Property.List(
                    context.ResourceGroupName,
                    context.ServiceName,
                    new QueryParameters
                    {
                        Filter = string.Format("tags/any(t: t eq '{0}')", propertyTag)
                    }),
                nextLink => Client.Property.ListNext(nextLink));

            return results;
        }

        public PsApiManagementProperty PropertyById(PsApiManagementContext context, string propertyId)
        {
            var response = Client.Property.Get(context.ResourceGroupName, context.ServiceName, propertyId);
            var property = Mapper.Map<PsApiManagementProperty>(response.Value);

            return property;
        }

        public void PropertyRemove(PsApiManagementContext context, string propertyId)
        {
            Client.Property.Delete(context.ResourceGroupName, context.ServiceName, propertyId, "*");
        }

        public void PropertySet(
            PsApiManagementContext context,
            string propertyId,
            string propertyName,
            string propertyValue,
            bool? isSecret,
            IList<string> tags = null)
        {
            var propertyUpdateParameters = new PropertyUpdateParameters();

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                propertyUpdateParameters.Name = propertyName;
            }

            if (!string.IsNullOrWhiteSpace(propertyValue))
            {
                propertyUpdateParameters.Value = propertyValue;
            }

            if (isSecret.HasValue)
            {
                propertyUpdateParameters.Secret = isSecret.Value;
            }

            if (tags != null)
            {
                propertyUpdateParameters.Tags = tags;
            }

            Client.Property.Update(
                context.ResourceGroupName,
                context.ServiceName,
                propertyId,
                propertyUpdateParameters,
                "*");
        }
        #endregion

        #region OpenIdConnectProvider
        public PsApiManagementOpenIdConnectProvider OpenIdProviderCreate(
            PsApiManagementContext context,
            string openIdProviderId,
            string name,
            string metadataEndpointUri,
            string clientId,
            string clientSecret,
            string description)
        {
            var openIdProviderCreateParameters = new OpenidConnectProviderCreateContract(name, metadataEndpointUri, clientId);

            if (!string.IsNullOrWhiteSpace(clientSecret))
            {
                openIdProviderCreateParameters.ClientSecret = clientSecret;
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                openIdProviderCreateParameters.Description = description;
            }

            Client.OpenIdConnectProviders.Create(
                context.ResourceGroupName,
                context.ServiceName,
                openIdProviderId,
                openIdProviderCreateParameters);

            var response = Client.OpenIdConnectProviders.Get(context.ResourceGroupName, context.ServiceName, openIdProviderId);
            var openIdConnectProvider = Mapper.Map<PsApiManagementOpenIdConnectProvider>(response.Value);

            return openIdConnectProvider;
        }

        public IList<PsApiManagementOpenIdConnectProvider> OpenIdConnectProvidersList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementOpenIdConnectProvider, OpenidConnectProviderContract>(
                () => Client.OpenIdConnectProviders.List(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.OpenIdConnectProviders.ListNext(nextLink));

            return results;
        }

        public IList<PsApiManagementOpenIdConnectProvider> OpenIdConnectProviderByName(PsApiManagementContext context, string openIdConnectProviderName)
        {
            var results = ListPagedAndMap<PsApiManagementOpenIdConnectProvider, OpenidConnectProviderContract>(
                () => Client.OpenIdConnectProviders.List(
                    context.ResourceGroupName,
                    context.ServiceName,
                     new QueryParameters
                     {
                         Filter = string.Format("substringof('{0}',name)", openIdConnectProviderName)
                     }),
                nextLink => Client.OpenIdConnectProviders.ListNext(nextLink));

            return results;
        }

        public PsApiManagementOpenIdConnectProvider OpenIdConnectProviderById(PsApiManagementContext context, string openIdConnectProviderId)
        {
            var response = Client.OpenIdConnectProviders.Get(
                context.ResourceGroupName,
                context.ServiceName,
                openIdConnectProviderId);

            var openIdConnectProvider = Mapper.Map<PsApiManagementOpenIdConnectProvider>(response.Value);

            return openIdConnectProvider;
        }

        public void OpenIdConnectProviderRemove(PsApiManagementContext context, string openIdConnectProviderId)
        {
            Client.OpenIdConnectProviders.Delete(context.ResourceGroupName, context.ServiceName, openIdConnectProviderId, "*");
        }

        public void OpenIdConnectProviderSet(
            PsApiManagementContext context,
            string openIdConnectProviderId,
            string name,
            string description,
            string clientId,
            string clientSecret,
            string metadataEndpoint)
        {
            var openIdConnectProviderUpdateParameters = new OpenidConnectProviderUpdateContract();

            if (!string.IsNullOrWhiteSpace(name))
            {
                openIdConnectProviderUpdateParameters.Name = name;
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                openIdConnectProviderUpdateParameters.Description = description;
            }

            if (!string.IsNullOrWhiteSpace(clientId))
            {
                openIdConnectProviderUpdateParameters.ClientId = clientId;
            }

            if (!string.IsNullOrWhiteSpace(clientSecret))
            {
                openIdConnectProviderUpdateParameters.ClientSecret = clientSecret;
            }

            if (!string.IsNullOrWhiteSpace(metadataEndpoint))
            {
                openIdConnectProviderUpdateParameters.MetadataEndpoint = metadataEndpoint;
            }

            Client.OpenIdConnectProviders.Update(
                context.ResourceGroupName,
                context.ServiceName,
                openIdConnectProviderId,
                openIdConnectProviderUpdateParameters,
                "*");
        }
        #endregion

        #region TenantAccessInformation
        public PsApiManagementAccessInformation GetTenantGitAccessInformation(PsApiManagementContext context)
        {
            var response = Client.TenantAccessGit.Get(
                context.ResourceGroupName,
                context.ServiceName);

            return Mapper.Map<PsApiManagementAccessInformation>(response.Value);
        }
        #endregion

        #region TenantConfiguration

        public TenantConfigurationLongRunningOperation BeginSaveTenantGitConfiguration(
            PsApiManagementContext context,
            string branchName,
            bool force)
        {
            var saveConfigurationParams = new SaveConfigurationParameter(branchName)
            {
                Force = force
            };

            var longrunningResponse = Client.TenantConfiguration.BeginSave(
                context.ResourceGroupName,
                context.ServiceName,
                saveConfigurationParams);

            return TenantConfigurationLongRunningOperation.CreateLongRunningOperation("Save-AzureRmApiManagementTenantGitConfiguration", longrunningResponse);
        }

        public TenantConfigurationLongRunningOperation BeginPublishTenantGitConfiguration(
            PsApiManagementContext context,
            string branchName,
            bool force)
        {
            var deployConfigurationParams = new DeployConfigurationParameters(branchName)
            {
                Force = force
            };

            var longrunningResponse = Client.TenantConfiguration.BeginDeploy(
                context.ResourceGroupName,
                context.ServiceName,
                deployConfigurationParams);

            return TenantConfigurationLongRunningOperation.CreateLongRunningOperation("Publish-AzureRmApiManagementTenantGitConfiguration", longrunningResponse);
        }

        public TenantConfigurationLongRunningOperation BeginValidateTenantGitConfiguration(
            PsApiManagementContext context,
            string branchName,
            bool force)
        {
            var deployConfigurationParams = new DeployConfigurationParameters(branchName)
            {
                Force = force
            };

            var longrunningResponse = Client.TenantConfiguration.BeginValidate(
                context.ResourceGroupName,
                context.ServiceName,
                deployConfigurationParams);

            return TenantConfigurationLongRunningOperation.CreateLongRunningOperation("Publish-AzureRmApiManagementTenantGitConfiguration -ValidateOnly", longrunningResponse);
        }

        public PsApiManagementTenantConfigurationSyncState GetTenantConfigurationSyncState(
            PsApiManagementContext context)
        {
            var response = Client.TenantConfigurationSyncState.Get(
                context.ResourceGroupName,
                context.ServiceName);

            return Mapper.Map<PsApiManagementTenantConfigurationSyncState>(response.Value);
        }

        #endregion

        #region TenantAccessInformation
        public PsApiManagementAccessInformation GetTenantAccessInformation(PsApiManagementContext context)
        {
            var response = Client.TenantAccess.Get(
                context.ResourceGroupName,
                context.ServiceName);

            return Mapper.Map<PsApiManagementAccessInformation>(response.Value);
        }

        public void TenantAccessSet(
            PsApiManagementContext context,
            bool enabledTenantAccess)
        {
            var accessInformationParams = new AccessInformationUpdateParameters
            {
                Enabled = enabledTenantAccess
            };
            Client.TenantAccess.Update(context.ResourceGroupName, context.ServiceName, accessInformationParams, "*");
        }
        #endregion
    }
}