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

using System.Globalization;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement
{
    using AutoMapper;
    using Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using Microsoft.Azure.Management.ApiManagement;
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using System.Text.RegularExpressions;
    using Microsoft.Azure.Management.ApiManagement.Models;

    public class ApiManagementClient
    {
        private const string PeriodGroupName = "period";
        private const string ValueGroupName = "value";

        private const string ProductIdPathTemplate = "/products/{0}";
        private const string UserIdPathTemplate = "/users/{0}";

        // pattern: ^(?<period>[DdMmYy]{1})(?<value>\d+)$
        internal const string PeriodPattern = "^(?<" + PeriodGroupName + ">[DdMmYy]{1})(?<" + ValueGroupName + @">\d+)$";
        static readonly Regex PeriodRegex = new Regex(PeriodPattern, RegexOptions.Compiled);

        private readonly IAzureContext _context;
        private Management.ApiManagement.ApiManagementClient _client;

        private readonly JsonSerializerSettings _jsonSerializerSetting = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        private static IMapper _mapper;

        private static readonly object _lock = new object();

        public static IMapper Mapper
        {
            get
            {
                lock(_lock)
                {
                    if (_mapper == null)
                    {
                        ConfigureMappings();
                    }

                    return _mapper;
                }
            }
        }

        static ApiManagementClient()
        {
            ConfigureMappings();
        }

        private static void ConfigureMappings()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg
                    .CreateMap<PsApiManagementParameter, ParameterContract>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.DefaultValue, opt => opt.MapFrom(src => src.DefaultValue))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                    .ForMember(dest => dest.Required, opt => opt.MapFrom(src => src.Required))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

                cfg
                    .CreateMap<PsApiManagementRequest, RequestContract>()
                    .ForMember(dest => dest.Headers, opt => opt.MapFrom(src => src.Headers))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.QueryParameters, opt => opt.MapFrom(src => src.QueryParameters))
                    .ForMember(dest => dest.Representations, opt => opt.MapFrom(src => src.Representations));

                cfg
                    .CreateMap<PsApiManagementResponse, ResponseContract>()
                    .ForMember(dest => dest.StatusCode, opt => opt.MapFrom(src => src.StatusCode))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Representations, opt => opt.MapFrom(src => src.Representations));

                cfg
                    .CreateMap<PsApiManagementRepresentation, RepresentationContract>()
                    .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
                    .ForMember(dest => dest.Sample, opt => opt.MapFrom(src => src.Sample))
                    .ForMember(dest => dest.FormParameters, opt => opt.Ignore())
                    .ForMember(dest => dest.SchemaId, opt => opt.MapFrom(src => src.SchemaId))
                    .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.TypeName))
                    .AfterMap((src, dest) =>
                        dest.FormParameters = src.FormParameters == null || !src.FormParameters.Any()
                            ? null
                            : ToParameterContract(src.FormParameters));
                
                cfg
                    .CreateMap<ApiContract, PsApiManagementApi>()
                    .ForMember(dest => dest.ApiId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path))
                    .ForMember(dest => dest.ServiceUrl, opt => opt.MapFrom(src => src.ServiceUrl))
                    .ForMember(dest => dest.ApiRevision, opt => opt.MapFrom(src => src.ApiRevision))
                    .ForMember(dest => dest.ApiVersion, opt => opt.MapFrom(src => src.ApiVersion ?? string.Empty))
                    .ForMember(dest => dest.ApiType, opt => opt.MapFrom(src => src.ApiType ?? ApiType.Http))
                    .ForMember(dest => dest.IsCurrent, opt => opt.MapFrom(src => src.IsCurrent ?? false))
                    .ForMember(dest => dest.IsOnline, opt => opt.MapFrom(src => src.IsOnline ?? false))
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

                cfg.CreateMap<ApiContract, ApiCreateOrUpdateParameter>();
                cfg.CreateMap<RequestContract, PsApiManagementRequest>();
                cfg.CreateMap<ResponseContract, PsApiManagementResponse>();
                cfg
                    .CreateMap<RepresentationContract, PsApiManagementRepresentation>()
                    .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
                    .ForMember(dest => dest.Sample, opt => opt.MapFrom(src => src.Sample))
                    .ForMember(dest => dest.FormParameters, opt => opt.Ignore())
                    .ForMember(dest => dest.SchemaId, opt => opt.MapFrom(src => src.SchemaId))
                    .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.TypeName))
                    .AfterMap((src, dest) =>
                        dest.FormParameters = src.FormParameters == null || !src.FormParameters.Any()
                            ? null
                            : ToParameterContract(src.FormParameters));

                cfg.CreateMap<ParameterContract, PsApiManagementParameter>();

                cfg
                    .CreateMap<OperationContract, PsApiManagementOperation>()
                    .ForMember(dest => dest.ApiId, opt => opt.MapFrom(src => src.ApiIdentifier))
                    .ForMember(dest => dest.OperationId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.UrlTemplate, opt => opt.MapFrom(src => src.UrlTemplate))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.Request))
                    .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src.Responses))
                    .ForMember(dest => dest.TemplateParameters, opt => opt.MapFrom(src => src.TemplateParameters))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName));

                cfg
                    .CreateMap<PsApiManagementOperation, OperationContract>()
                    .ForMember(dest => dest.ApiIdentifier, opt => opt.MapFrom(src => src.ApiId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OperationId))
                    .ForMember(dest => dest.UrlTemplate, opt => opt.MapFrom(src => src.UrlTemplate))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.Request))
                    .ForMember(dest => dest.Responses, opt => opt.MapFrom(src => src.Responses))
                    .ForMember(dest => dest.TemplateParameters, opt => opt.MapFrom(src => src.TemplateParameters))
                    .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

                cfg
                    .CreateMap<ApiRevisionContract, PsApiManagementApiRevision>()
                    .ForMember(dest => dest.ApiId, opt => opt.MapFrom(src => src.ApiId))
                    .ForMember(dest => dest.ApiRevision, opt => opt.MapFrom(src => src.ApiRevision))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime))
                    .ForMember(dest => dest.IsCurrent, opt => opt.MapFrom(src => src.IsCurrent))
                    .ForMember(dest => dest.PrivateUrl, opt => opt.MapFrom(src => src.PrivateUrl))
                    .ForMember(dest => dest.IsOnline, opt => opt.MapFrom(src => src.IsOnline));

                cfg
                    .CreateMap<ApiReleaseContract, PsApiManagementApiRelease>()
                    .ForMember(dest => dest.ApiId, opt => opt.MapFrom(src => TrimApiResourceIdentifier(src.ApiId)))
                    .ForMember(dest => dest.ReleaseId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                    .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime))
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => src.UpdatedDateTime));

                cfg
                    .CreateMap<PsApiManagementApiRelease, ApiReleaseContract>()
                    .ForMember(dest => dest.ApiId, opt => opt.MapFrom(src => src.ApiId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ReleaseId))
                    .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                    .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime))
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => src.UpdatedDateTime));

                cfg
                    .CreateMap<ProductContract, PsApiManagementProduct>()
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                    .ForMember(dest => dest.SubscriptionRequired, opt => opt.MapFrom(src => src.SubscriptionRequired))
                    .ForMember(dest => dest.SubscriptionsLimit, opt => opt.MapFrom(src => src.SubscriptionsLimit))
                    .ForMember(dest => dest.LegalTerms, opt => opt.MapFrom(src => src.Terms));

                cfg
                    .CreateMap<SubscriptionContract, PsApiManagementSubscription>()
                    .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductIdentifier))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserIdentifier))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName));

                cfg
                    .CreateMap<UserContract, PsApiManagementUser>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.RegistrationDate))
                    .ForMember(dest => dest.Identities, opt => opt.MapFrom(src => src.Identities.ToDictionary(key => key.Id, value => value.Provider)));

                cfg
                    .CreateMap<GroupContract, PsApiManagementGroup>()
                    .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GroupContractType))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.System, opt => opt.MapFrom(src => src.BuiltIn));

                cfg
                    .CreateMap<CertificateContract, PsApiManagementCertificate>()
                    .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                    .ForMember(dest => dest.Thumbprint, opt => opt.MapFrom(src => src.Thumbprint))                    
                    .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                    .ForMember(dest => dest.CertificateId, opt => opt.MapFrom(src => src.Name));

                cfg
                    .CreateMap<AuthorizationServerContract, PsApiManagementOAuth2AuthrozationServer>()
                    .ForMember(dest => dest.ServerId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.AccessTokenSendingMethods, opt => opt.MapFrom(src => src.BearerTokenSendingMethods))
                    .ForMember(dest => dest.TokenEndpointUrl, opt => opt.MapFrom(src => src.TokenEndpoint))
                    .ForMember(dest => dest.AuthorizationEndpointUrl, opt => opt.MapFrom(src => src.AuthorizationEndpoint))
                    .ForMember(dest => dest.ClientRegistrationPageUrl, opt => opt.MapFrom(src => src.ClientRegistrationEndpoint))
                    .ForMember(dest => dest.ClientAuthenticationMethods, opt => opt.MapFrom(src => src.ClientAuthenticationMethod))
                    .ForMember(dest => dest.AuthorizationRequestMethods, opt => opt.MapFrom(src => src.AuthorizationMethods != null ?
                            GetAuthorizationMethods(src.AuthorizationMethods) : null))
                    .ForMember(dest => dest.TokenBodyParameters, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                        dest.TokenBodyParameters = src.TokenBodyParameters == null
                            ? (Hashtable)null
                            : new Hashtable(src.TokenBodyParameters.ToDictionary(key => key.Name, value => value.Value)));

                cfg
                    .CreateMap<LoggerContract, PsApiManagementLogger>()
                    .ForMember(dest => dest.LoggerId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.IsBuffered, opt => opt.MapFrom(src => src.IsBuffered))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.LoggerType));

                cfg
                    .CreateMap<PropertyContract, PsApiManagementProperty>()
                    .ForMember(dest => dest.PropertyId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                    .ForMember(dest => dest.Secret, opt => opt.MapFrom(src => src.Secret))
                    .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags == null ? new string[0] : src.Tags.ToArray()));

                cfg
                    .CreateMap<OpenidConnectProviderContract, PsApiManagementOpenIdConnectProvider>()
                    .ForMember(dest => dest.OpenIdConnectProviderId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                    .ForMember(dest => dest.ClientSecret, opt => opt.MapFrom(src => src.ClientSecret))                    
                    .ForMember(dest => dest.MetadataEndpoint, opt => opt.MapFrom(src => src.MetadataEndpoint));

                cfg
                    .CreateMap<AccessInformationContract, PsApiManagementAccessInformation>()
                    .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.PrimaryKey, opt => opt.MapFrom(src => src.PrimaryKey))
                    .ForMember(dest => dest.SecondaryKey, opt => opt.MapFrom(src => src.SecondaryKey));

                cfg.CreateMap<TenantConfigurationSyncStateContract, PsApiManagementTenantConfigurationSyncState>();

                cfg
                    .CreateMap<IdentityProviderContract, PsApiManagementIdentityProvider>()
                    .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                    .ForMember(dest => dest.ClientSecret, opt => opt.MapFrom(src => src.ClientSecret))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.IdentityProviderContractType))
                    .ForMember(dest => dest.AllowedTenants, opt => opt.MapFrom(src => src.AllowedTenants == null ? new string[0] : src.AllowedTenants.ToArray()));

                cfg
                    .CreateMap<BackendProxyContract, PsApiManagementBackendProxy>()
                    .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                    .ForMember(dest => dest.ProxyCredentials, opt => opt.MapFrom(src =>
                        string.IsNullOrEmpty(src.Password) ? PSCredential.Empty :
                        new PSCredential(src.Username, src.Password.ConvertToSecureString())));

                cfg
                    .CreateMap<PsApiManagementBackendProxy, BackendProxyContract>()
                    .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                    .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.ProxyCredentials == PSCredential.Empty ? null : src.ProxyCredentials.UserName))
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.ProxyCredentials == PSCredential.Empty ? null : src.ProxyCredentials.Password.ConvertToString()));

                cfg
                    .CreateMap<BackendCredentialsContract, PsApiManagementBackendCredential>()
                    .ForMember(dest => dest.Certificate, opt => opt.MapFrom(src => src.Certificate))
                    .ForMember(dest => dest.Authorization, opt => opt.MapFrom(src => src.Authorization))
                    .ForMember(dest => dest.Query, opt => opt.Ignore())
                    .ForMember(dest => dest.Header, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                        dest.Query = src.Query == null
                            ? (Hashtable)null
                            : DictionaryToHashTable(src.Query))
                    .AfterMap((src, dest) =>
                        dest.Header = src.Header == null
                            ? (Hashtable)null
                            : DictionaryToHashTable(src.Header));
                cfg
                    .CreateMap<BackendAuthorizationHeaderCredentials, PsApiManagementAuthorizationHeaderCredential>()
                    .ForMember(dest => dest.Scheme, opt => opt.MapFrom(src => src.Scheme))
                    .ForMember(dest => dest.Parameter, opt => opt.MapFrom(src => src.Parameter));

                cfg
                    .CreateMap<PsApiManagementAuthorizationHeaderCredential, BackendAuthorizationHeaderCredentials>()
                    .ForMember(dest => dest.Scheme, opt => opt.MapFrom(src => src.Scheme))
                    .ForMember(dest => dest.Parameter, opt => opt.MapFrom(src => src.Parameter));

                cfg
                    .CreateMap<BackendServiceFabricClusterProperties, PsApiManagementServiceFabric>()
                    .ForMember(dest => dest.ClientCertificateThumbprint, opt => opt.MapFrom(src => src.ClientCertificatethumbprint))
                    .ForMember(dest => dest.MaxPartitionResolutionRetries, opt => opt.MapFrom(src => src.MaxPartitionResolutionRetries))
                    .ForMember(dest => dest.ManagementEndpoints, opt => opt.MapFrom(src => src.ManagementEndpoints))
                    .ForMember(dest => dest.ServerX509Names, opt => opt.Ignore())
                    .ForMember(dest => dest.ServerCertificateThumbprint, opt => opt.MapFrom(src => src.ServerCertificateThumbprints))
                    .AfterMap((src, dest) => 
                        dest.ServerX509Names = src.ServerX509Names == null ? (Hashtable)null : X509CertificateToHashTable(src.ServerX509Names));

                cfg
                    .CreateMap<PsApiManagementServiceFabric, BackendServiceFabricClusterProperties>()
                    .ForMember(dest => dest.ClientCertificatethumbprint, opt => opt.MapFrom(src => src.ClientCertificateThumbprint))
                    .ForMember(dest => dest.MaxPartitionResolutionRetries, opt => opt.MapFrom(src => src.MaxPartitionResolutionRetries))
                    .ForMember(dest => dest.ManagementEndpoints, opt => opt.MapFrom(src => src.ManagementEndpoints))
                    .ForMember(dest => dest.ServerX509Names, opt => opt.MapFrom(src => HashTableToX509CertificateName(src.ServerX509Names)))
                    .ForMember(dest => dest.ServerCertificateThumbprints, opt => opt.MapFrom(src => src.ServerCertificateThumbprint));

                cfg
                    .CreateMap<BackendContract, PsApiManagementBackend>()
                    .ForMember(dest => dest.BackendId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.Url))
                    .ForMember(dest => dest.Protocol, opt => opt.MapFrom(src => src.Protocol))
                    .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.ResourceId))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Proxy, opt => opt.MapFrom(src => src.Proxy))
                    .ForMember(dest => dest.Properties, opt => opt.Ignore())
                    .ForMember(dest => dest.Credentials, opt => opt.MapFrom(src => src.Credentials))
                    .ForMember(dest => dest.ServiceFabricCluster, opt => opt.MapFrom(src => src.Properties.ServiceFabricCluster))
                    .AfterMap((src, dest) => 
                        dest.Properties = ToBackendProperties(src.Tls));
                
                cfg
                    .CreateMap<ApiVersionSetContract, PsApiManagementApiVersionSet>()
                    .ForMember(dest => dest.ApiVersionSetId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.VersionHeaderName, opt => opt.MapFrom(src => src.VersionHeaderName))
                    .ForMember(dest => dest.VersionQueryName, opt => opt.MapFrom(src => src.VersionQueryName))
                    .ForMember(dest => dest.VersioningScheme, opt => opt.MapFrom(src => src.VersioningScheme));

                cfg
                    .CreateMap<PsApiManagementApiVersionSet, ApiVersionSetContract>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ApiVersionSetId))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.VersionHeaderName, opt => opt.MapFrom(src => src.VersionHeaderName))
                    .ForMember(dest => dest.VersionQueryName, opt => opt.MapFrom(src => src.VersionQueryName))
                    .ForMember(dest => dest.VersioningScheme, opt => opt.MapFrom(src => src.VersioningScheme));

                cfg.CreateMap<Hashtable, Hashtable>();
            });

            _mapper = config.CreateMapper();
        }

        public ApiManagementClient(IAzureContext context)
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
            return AzureSession.Instance.ClientFactory.CreateArmClient<Management.ApiManagement.ApiManagementClient>(
                _context,
                AzureEnvironment.Endpoint.ResourceManager);
        }

        private static IList<T> ListPaged<T>(
            Func<Rest.Azure.IPage<T>> listFirstPage,
            Func<string, Rest.Azure.IPage<T>> listNextPage)
        {
            var resultsList = new List<T>();

            var pagedResponse = listFirstPage();
            resultsList.AddRange(pagedResponse);

            while (!string.IsNullOrEmpty(pagedResponse.NextPageLink))
            {
                pagedResponse = listNextPage(pagedResponse.NextPageLink);
                resultsList.AddRange(pagedResponse);
            }

            return resultsList;
        }

        private static IList<TOut> ListPagedAndMap<TOut, TIn>(
            Func<Rest.Azure.IPage<TIn>> listFirstPage,
            Func<string, Rest.Azure.IPage<TIn>> listNextPage)
        {
            IList<TIn> unmappedList = ListPaged(listFirstPage, listNextPage);

            var mappedList = Mapper.Map<IList<TOut>>(unmappedList);

            return mappedList;
        }

        #region APIs
        public IList<PsApiManagementApi> ApiList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementApi, ApiContract>(
                () => Client.Api.ListByService(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Api.ListByServiceNext(nextLink));

            return results;
        }

        public IList<PsApiManagementApi> ApiByName(PsApiManagementContext context, string name)
        {
            var results = ListPagedAndMap<PsApiManagementApi, ApiContract>(
                () => Client.Api.ListByService(
                    context.ResourceGroupName,
                    context.ServiceName,
                    new Rest.Azure.OData.ODataQuery<ApiContract>
                    {
                        Filter = string.Format("contains('{0}',properties/displayName)", name)
                    }),
                nextLink => Client.Api.ListByServiceNext(nextLink));

            return results;
        }

        public IList<PsApiManagementApi> ApiByProductId(PsApiManagementContext context, string productId)
        {
            var results = ListPagedAndMap<PsApiManagementApi, ApiContract>(
                () => Client.ProductApi.ListByProduct(context.ResourceGroupName, context.ServiceName, productId, null),
                nextLink => Client.ProductApi.ListByProductNext(nextLink));

            return results;
        }

        public PsApiManagementApi ApiById(PsApiManagementContext context, string id)
        {
            var response = Client.Api.Get(context.ResourceGroupName, context.ServiceName, id);

            return Mapper.Map<PsApiManagementApi>(response);
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
            var api = new ApiCreateOrUpdateParameter
            {
                DisplayName = name,
                Description = description,
                ServiceUrl = serviceUrl,
                Path = urlSuffix,
                Protocols = Mapper.Map<IList<Protocol?>>(urlSchema),
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

            var getResponse = Client.Api.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, id, api, null);

            return Mapper.Map<PsApiManagementApi>(getResponse);
        }


        public void ApiRemove(PsApiManagementContext context, string apiId)
        {
            Client.Api.Delete(context.ResourceGroupName, context.ServiceName, apiId, "*", deleteRevisions: true);
        }

        public void ApiRemoveRevision(PsApiManagementContext context, string apiId)
        {
            Client.Api.Delete(context.ResourceGroupName, context.ServiceName, apiId, "*", deleteRevisions: false);
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
            string subscriptionKeyQueryParamName,
            PsApiManagementApi apiObject)
        {
            ApiContract apiContract;
            if (apiObject == null)
            {
                apiContract = Client.Api.Get(
                    context.ResourceGroupName,
                    context.ServiceName,
                    id);
            }
            else
            {
                id = apiObject.ApiId;
                if (!string.IsNullOrEmpty(apiObject.ApiRevision))
                {
                    id = apiObject.ApiId.ApiRevisionIdentifier(apiObject.ApiRevision);
                }
                apiContract = Mapper.Map<ApiContract>(apiObject);
            }

            var api = new ApiCreateOrUpdateParameter
            {
                DisplayName = name ?? apiContract.Name,
                Description = description ?? apiContract.Description,
                ServiceUrl = serviceUrl ?? apiContract.ServiceUrl,
                Path = urlSuffix ?? apiContract.Path,
                Protocols = urlSchema != null ? Mapper.Map<IList<Protocol?>>(urlSchema) : apiContract.Protocols
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
            else
            {
                api.AuthenticationSettings = apiContract.AuthenticationSettings;
            }

            if (!string.IsNullOrWhiteSpace(subscriptionKeyHeaderName) || !string.IsNullOrWhiteSpace(subscriptionKeyQueryParamName))
            {
                api.SubscriptionKeyParameterNames = new SubscriptionKeyParameterNamesContract
                {
                    Header = subscriptionKeyHeaderName,
                    Query = subscriptionKeyQueryParamName
                };
            }
            else
            {
                api.SubscriptionKeyParameterNames = apiContract.SubscriptionKeyParameterNames;
            }
            
            Client.Api.CreateOrUpdate(
                context.ResourceGroupName, 
                context.ServiceName,
                id, 
                api,
                "*");
        }

        public void ApiImportFromFile(
            PsApiManagementContext context,
            string apiId,
            PsApiManagementApiFormat specificationFormat,
            string specificationPath,
            string apiPath,
            string wsdlServiceName,
            string wsdlEndpointName,
            PsApiManagementApiType? apiType)
        {
            string contentFormat = GetContentFormatForApiImport(true, specificationFormat, wsdlServiceName, wsdlEndpointName, true);

            string soapApiType = GetApiTypeForImport(specificationFormat, apiType);

            string contentValue;
            using (var fileStream = File.OpenRead(specificationPath))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    contentValue = streamReader.ReadToEnd();
                }
            }
            var apiCreateOrUpdateParams = new ApiCreateOrUpdateParameter()
            {
                ContentFormat = contentFormat,
                Path = apiPath,
                ContentValue = contentValue
            };

            if (!string.IsNullOrEmpty(soapApiType))
            {
                apiCreateOrUpdateParams.SoapApiType = soapApiType;
                apiCreateOrUpdateParams.WsdlSelector = new ApiCreateOrUpdatePropertiesWsdlSelector()
                {
                    WsdlServiceName = wsdlServiceName,
                    WsdlEndpointName = wsdlEndpointName
                };
            }

            Client.Api.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                apiCreateOrUpdateParams);            
        }

        public void ApiImportFromUrl(
            PsApiManagementContext context,
            string apiId,
            PsApiManagementApiFormat specificationFormat,
            string specificationUrl,
            string apiPath,
            string wsdlServiceName,
            string wsdlEndpointName,
            PsApiManagementApiType? apiType)
        {
            string contentFormat = GetContentFormatForApiImport(false, specificationFormat, wsdlServiceName, wsdlEndpointName, true);

            string soapApiType = GetApiTypeForImport(specificationFormat, apiType);
                       
            var createOrUpdateContract = new ApiCreateOrUpdateParameter()
            {
                ContentFormat = contentFormat,
                ContentValue = specificationUrl,
                Path = apiPath
            };

            if (!string.IsNullOrEmpty(soapApiType))
            {
                createOrUpdateContract.SoapApiType = soapApiType;
                createOrUpdateContract.WsdlSelector = new ApiCreateOrUpdatePropertiesWsdlSelector()
                {
                    WsdlServiceName = wsdlServiceName,
                    WsdlEndpointName = wsdlEndpointName
                };
            }

            Client.Api.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                createOrUpdateContract);
        }

        public byte[] ApiExportToFile(
            PsApiManagementContext context,
            string apiId,
            PsApiManagementApiFormat specificationFormat,
            string saveAs)
        {
            string exportFormat = GetFormatForApiExport(specificationFormat);

            var response = Client.ApiExport.Get(context.ResourceGroupName, context.ServiceName, apiId, exportFormat);
            var exportedFileContents = DownloadFileFromLink(response.Link);
            return exportedFileContents;
        }

        byte[] DownloadFileFromLink(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            using (WebResponse response = request.GetResponse())
            using (var stream = response.GetResponseStream())
            {
                using (var memStream = new MemoryStream())
                {
                    stream.CopyTo(memStream);
                    return memStream.ToArray();
                }
            }
        }

        private string GetContentFormatForApiImport(
            bool fromFile,
            PsApiManagementApiFormat specificationApiFormat, 
            string wsdlServiceName,
            string wsdlEndpointName,
            bool validateWsdlParams)
        {
            string headerValue;
            switch (specificationApiFormat)
            {
                case PsApiManagementApiFormat.Wadl:
                    headerValue = fromFile ? ContentFormat.WadlXml : ContentFormat.WadlLinkJson;
                    break;
                case PsApiManagementApiFormat.Swagger:
                    headerValue = fromFile ? ContentFormat.SwaggerJson : ContentFormat.SwaggerLinkJson; 
                    break;
                case PsApiManagementApiFormat.Wsdl:
                    headerValue = fromFile ? ContentFormat.Wsdl : ContentFormat.WsdlLink; 
                    if (validateWsdlParams && string.IsNullOrEmpty(wsdlServiceName))
                    {
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "WsdlServiceName cannot be Empty for Format : {0}", specificationApiFormat));
                    }

                    if (validateWsdlParams && string.IsNullOrEmpty(wsdlEndpointName))
                    {
                        throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "WsdlEndpointName cannot be Empty for Format : {0}", specificationApiFormat));
                    }
                    break;
                default:
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Format '{0}' is not supported.", specificationApiFormat));
            }

            return headerValue;
        }

        private string GetFormatForApiExport(
            PsApiManagementApiFormat specificationFormat)
        {
            switch(specificationFormat)
            {
                case PsApiManagementApiFormat.Swagger:
                    return ExportFormat.Swagger;
                case PsApiManagementApiFormat.Wadl:
                    return ExportFormat.Wadl;
                case PsApiManagementApiFormat.Wsdl:
                    return ExportFormat.Wsdl;
                default:
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Format '{0}' is not supported.", specificationFormat));
            }
        }

        private string GetApiTypeForImport(
            PsApiManagementApiFormat specificationFormat,
            PsApiManagementApiType? apiType)
        {
            if (specificationFormat != PsApiManagementApiFormat.Wsdl)
            {
                return null;
            }

            if (apiType.HasValue)
            {
               switch(apiType.Value)
                {
                    case PsApiManagementApiType.Http: return SoapApiType.SoapToRest;
                    case PsApiManagementApiType.Soap: return SoapApiType.SoapPassThrough;
                    default: return SoapApiType.SoapPassThrough;
                }
            }

            return apiType.HasValue ? apiType.Value.ToString("g") : PsApiManagementApiType.Http.ToString("g");
        }

        public void ApiAddToProduct(PsApiManagementContext context, string productId, string apiId)
        {
            Client.ProductApi.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, productId, apiId);
        }

        public void ApiRemoveFromProduct(PsApiManagementContext context, string productId, string apiId)
        {
            Client.ProductApi.Delete(context.ResourceGroupName, context.ServiceName, productId, apiId);
        }
        #endregion

        #region API Revisions
        public IList<PsApiManagementApiRevision> ApiRevisionsList(PsApiManagementContext context, string apiId)
        {
            var results = ListPagedAndMap<PsApiManagementApiRevision, ApiRevisionContract>(
                () => Client.ApiRevisions.List(context.ResourceGroupName, context.ServiceName, apiId, null),
                nextLink => Client.ApiRevisions.ListNext(nextLink));

            return results;
        }

        public PsApiManagementApi GetApiRevision(PsApiManagementContext context, string apiId, string revisionId)
        {
            return this.ApiById(context, apiId.ApiRevisionIdentifier(revisionId));
        }
        
        public PsApiManagementApi ApiCreateRevision(
            PsApiManagementContext context,
            string apiId,
            string revisionId)
        {
            var apiContract = Client.Api.Get(context.ResourceGroupName, context.ServiceName, apiId);
            var apiCreateParams = Mapper.Map<ApiCreateOrUpdateParameter>(apiContract);

            var getResponse = Client.Api.CreateOrUpdate(context.ResourceGroupName,
                context.ServiceName,
                apiId.ApiRevisionIdentifier(revisionId),
                apiCreateParams,
                null);

            return Mapper.Map<PsApiManagementApi>(getResponse);
        }
        
        #endregion

        #region API Releases
        public PsApiManagementApiRelease CreateApiRelease(
            PsApiManagementContext context,
            string apiId, 
            string revisionId,
            string releaseId,
            string notes)
        {
            var apiReleaseCreateContract = new ApiReleaseContract()
            {
                ApiId = apiId.ApiRevisionIdentifierFullPath(revisionId),
                Notes = notes
            };
            var apiRelease = Client.ApiRelease.Create(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                releaseId,
                apiReleaseCreateContract);

            return Mapper.Map<PsApiManagementApiRelease>(apiRelease);
        }

        public void UpdateApiRelease(
            PsApiManagementContext context,
            string apiId,
            string releaseId,
            string notes,
            PsApiManagementApiRelease release)
        {
            var apiReleaseContract = Client.ApiRelease.Get(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                releaseId);

            if (release == null)
            {
                if (!string.IsNullOrEmpty(notes))
                {
                    apiReleaseContract.Notes = notes;
                }
            }
            else
            {
                var updateReleaseContract = Mapper.Map<ApiReleaseContract>(release);
                // update notes
                apiReleaseContract.Notes = updateReleaseContract.Notes;                
                apiId = release.ApiId;
                releaseId = release.ReleaseId;
            }

            Client.ApiRelease.Update(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                releaseId,
                apiReleaseContract,
                "*");
        }

        public PsApiManagementApiRelease GetApiReleaseById(PsApiManagementContext context, string apiId, string releaseId)
        {
            var response = Client.ApiRelease.Get(context.ResourceGroupName, context.ServiceName, apiId, releaseId);
            var apiRelease = Mapper.Map<PsApiManagementApiRelease>(response);

            return apiRelease;
        }

        public IList<PsApiManagementApiRelease> GetApiReleases(PsApiManagementContext context, string apiId)
        {
            var results = ListPagedAndMap<PsApiManagementApiRelease, ApiReleaseContract>(
                () => Client.ApiRelease.List(context.ResourceGroupName, context.ServiceName, apiId),
                nextLink => Client.ApiRelease.ListNext(nextLink));

            return results;
        }

        public void ApiReleaseRemove(PsApiManagementContext context, string apiId, string releaseId)
        {
            Client.ApiRelease.Delete(context.ResourceGroupName, context.ServiceName, apiId, releaseId, "*");
        }

        #endregion

        #region API Version Sets
        public PsApiManagementApiVersionSet CreateApiVersionSet(
            PsApiManagementContext context,
            string versionSetId,
            string name,
            PsApiManagementVersioningScheme scheme,
            string headerName,
            string queryName,
            string description)
        {
            var apiVersionCreateContract = new ApiVersionSetContract()
            {
                DisplayName = name,
                VersioningScheme = scheme.ToString()
            };

            if (PsApiManagementVersioningScheme.Header == scheme)
            {
                apiVersionCreateContract.VersionHeaderName = headerName;
            }

            if (PsApiManagementVersioningScheme.Query == scheme)
            {
                apiVersionCreateContract.VersionQueryName = queryName;
            }

            apiVersionCreateContract.Description = description;

            var versionSet = Client.ApiVersionSet.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, versionSetId, apiVersionCreateContract);

            return Mapper.Map<PsApiManagementApiVersionSet>(versionSet);
        }

        public PsApiManagementApiVersionSet SetApiVersionSet(
            PsApiManagementContext context,
            string versionSetId,
            string name,
            PsApiManagementVersioningScheme? scheme,
            string headerName,
            string queryName,
            string description,
            PsApiManagementApiVersionSet versionSetObject)
        {
            ApiVersionSetContract apiVersionContract;
            if (versionSetObject == null)
            {
                apiVersionContract = Client.ApiVersionSet.Get(
                    context.ResourceGroupName,
                    context.ServiceName,
                    versionSetId);

                if (!string.IsNullOrEmpty(name))
                {
                    apiVersionContract.DisplayName = name;
                }

                if (scheme.HasValue)
                {
                    apiVersionContract.VersioningScheme = scheme.Value.ToString();
                }

                if (PsApiManagementVersioningScheme.Header == scheme)
                {
                    apiVersionContract.VersionHeaderName = headerName;
                }

                if (PsApiManagementVersioningScheme.Query == scheme)
                {
                    apiVersionContract.VersionQueryName = queryName;
                }

                if (!string.IsNullOrEmpty(description))
                {
                    apiVersionContract.Description = description;
                }
            }
            else
            {
                apiVersionContract = Mapper.Map<ApiVersionSetContract>(versionSetObject);
            }

            var updatedApiVersionSet = Client.ApiVersionSet.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName, 
                versionSetId,
                apiVersionContract, 
                "*");

            return Mapper.Map<PsApiManagementApiVersionSet>(updatedApiVersionSet);
        }

        public PsApiManagementApiVersionSet GetApiVersionSet(PsApiManagementContext context, string apiVersionSetId)
        {
            var getApiVersionSet = Client.ApiVersionSet.Get(context.ResourceGroupName, context.ServiceName, apiVersionSetId);
            var apiVersionSet = Mapper.Map<PsApiManagementApiVersionSet>(getApiVersionSet);
            return apiVersionSet;
        }

        public IList<PsApiManagementApiVersionSet> GetApiVersionSets(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementApiVersionSet, ApiVersionSetContract>(
                () => Client.ApiVersionSet.ListByService(context.ResourceGroupName, context.ServiceName),
                nextLink => Client.ApiVersionSet.ListByServiceNext(nextLink));

            return results;
        }

        public void ApiVersionSetRemove(PsApiManagementContext context, string apiVersionSetId)
        {
            Client.ApiVersionSet.Delete(context.ResourceGroupName, context.ServiceName, apiVersionSetId, "*");
        }

        #endregion

        #region Operations
        public IList<PsApiManagementOperation> OperationList(PsApiManagementContext context, string apiId)
        {
            var results = ListPagedAndMap<PsApiManagementOperation, OperationContract>(
                () => Client.ApiOperation.ListByApi(context.ResourceGroupName, context.ServiceName, apiId, null),
                nextLink => Client.ApiOperation.ListByApiNext(nextLink));

            return results;
        }

        public PsApiManagementOperation OperationById(PsApiManagementContext context, string apiId, string operationId)
        {
            var operationContract = Client.ApiOperation.Get(context.ResourceGroupName, context.ServiceName, apiId, operationId);

            return Mapper.Map<PsApiManagementOperation>(operationContract);
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
                DisplayName = name,
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

            var operationContractResponse = Client.ApiOperation.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                operationId,
                operationContract);

            return Mapper.Map<PsApiManagementOperation>(operationContractResponse);
        }

        public PsApiManagementOperation OperationCreate(
            PsApiManagementContext context,
            string apiId,
            string operationId,
            PsApiManagementOperation operation)
        {
            var operationContract = Mapper.Map<OperationContract>(operation);

            var operationContractResponse = Client.ApiOperation.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                operationId,
                operationContract);

            return Mapper.Map<PsApiManagementOperation>(operationContractResponse);
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
            var operationContract = new OperationUpdateContract
            {
                DisplayName = name,
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
            
            Client.ApiOperation.Update(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                operationId,
                operationContract,
                "*");
        }

        public void OperationRemove(PsApiManagementContext context, string apiId, string operationId)
        {
            Client.ApiOperation.Delete(context.ResourceGroupName, context.ServiceName, apiId, operationId, "*");
        }
        #endregion

        #region Products
        public IList<PsApiManagementProduct> ProductList (PsApiManagementContext context, string title)
        {
            var query = new Rest.Azure.OData.ODataQuery<ProductContract>();
            if (!string.IsNullOrWhiteSpace(title))
            {
                query.Filter = string.Format("contains('{0}',properties/displayName)", title);
            }

            var results = ListPagedAndMap<PsApiManagementProduct, ProductContract>(
                () => Client.Product.ListByService(context.ResourceGroupName, context.ServiceName, query),
                nextLink => Client.Product.ListByServiceNext(nextLink));

            return results;
        }

        public IList<PsApiManagementProduct> ProductListByApi(PsApiManagementContext context, string apiId)
        {
            var results = ListPagedAndMap<PsApiManagementProduct, ProductContract>(
                () => Client.ApiProduct.ListByApis(context.ResourceGroupName, context.ServiceName, apiId),
                nextLink => Client.ApiProduct.ListByApisNext(nextLink));

            return results;
        }

        public PsApiManagementProduct ProductById(PsApiManagementContext context, string productId)
        {
            var response = Client.Product.Get(context.ResourceGroupName, context.ServiceName, productId);
            var product = Mapper.Map<PsApiManagementProduct>(response);

            return product;
        }

        public void ProductRemove(PsApiManagementContext context, string productId, bool deleteSubscriptions)
        {
            Client.Product.Delete(context.ResourceGroupName, context.ServiceName, productId, "*", deleteSubscriptions);
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
                        productContract.State = ProductState.NotPublished;
                        break;
                    case PsApiManagementProductState.Published:
                        productContract.State = ProductState.Published;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("State '{0}' is not supported.", state));
                }
            }

            Client.Product.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, productId, productContract);
            var response = Client.Product.Get(context.ResourceGroupName, context.ServiceName, productId);

            return Mapper.Map<PsApiManagementProduct>(response);
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
                DisplayName = title,
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
                        productUpdateParameters.State = ProductState.NotPublished;
                        break;
                    case PsApiManagementProductState.Published:
                        productUpdateParameters.State = ProductState.Published;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(string.Format("State '{0}' is not supported.", state));
                }
            }

            Client.Product.Update(context.ResourceGroupName, context.ServiceName, productId, productUpdateParameters, "*");
        }

        public void ProductAddToGroup(PsApiManagementContext context, string groupId, string productId)
        {
            Client.ProductGroup.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, productId, groupId);
        }

        public void ProductRemoveFromGroup(PsApiManagementContext context, string groupId, string productId)
        {
            Client.ProductGroup.Delete(context.ResourceGroupName, context.ServiceName, productId, groupId);
        }
        #endregion

        #region Subscriptions
        public IList<PsApiManagementSubscription> SubscriptionList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementSubscription, SubscriptionContract>(
                () => Client.Subscription.List(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Subscription.ListNext(nextLink));

            return results;
        }

        public IList<PsApiManagementSubscription> SubscriptionByUser(PsApiManagementContext context, string userId)
        {
            var results = ListPagedAndMap<PsApiManagementSubscription, SubscriptionContract>(
                () => Client.UserSubscription.List(context.ResourceGroupName, context.ServiceName, userId, null),
                nextLink => Client.UserSubscription.ListNext(nextLink));

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
            var response = Client.Subscription.Get(context.ResourceGroupName, context.ServiceName, subscriptionId);
            var subscription = Mapper.Map<PsApiManagementSubscription>(response);

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
                DisplayName = name,
                PrimaryKey = primaryKey,
                SecondaryKey = secondaryKey
            };

            if (state.HasValue)
            {
                createParameters.State = Mapper.Map<SubscriptionState>(state.Value);
            }

            var response = Client.Subscription.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, subscriptionId, createParameters);
            
            return Mapper.Map<PsApiManagementSubscription>(response);
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
                DisplayName = name,
                PrimaryKey = primaryKey,
                SecondaryKey = secondaryKey,
                ExpirationDate = expiresOn,
                StateComment = stateComment
            };

            if (state.HasValue)
            {
                updateParameters.State = Mapper.Map<SubscriptionState>(state.Value);
            }

            Client.Subscription.Update(context.ResourceGroupName, context.ServiceName, subscriptionId, updateParameters, "*");
        }

        public void SubscriptionRemove(PsApiManagementContext context, string subscriptionId)
        {
            Client.Subscription.Delete(context.ResourceGroupName, context.ServiceName, subscriptionId, "*");
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
                userCreateParameters.State = Mapper.Map<string>(state.Value);
            }

            Client.User.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, userId, userCreateParameters);

            var response = Client.User.Get(context.ResourceGroupName, context.ServiceName, userId);
            var user = Mapper.Map<PsApiManagementUser>(response);

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
                userUpdateParameters.State = Mapper.Map<string>(state.Value);
            }
            else
            {
                // if state not specified, fetch state.
                // fix for issue https://github.com/Azure/azure-powershell/issues/2622
                var currentUser = Client.User.Get(context.ResourceGroupName, context.ServiceName, userId);
                userUpdateParameters.State = currentUser.State;
            }

            Client.User.Update(context.ResourceGroupName, context.ServiceName, userId, userUpdateParameters, "*");
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
                    () => Client.GroupUser.List(context.ResourceGroupName, context.ServiceName, groupId, query),
                    nextLink => Client.GroupUser.ListNext(nextLink))
                : ListPagedAndMap<PsApiManagementUser, UserContract>(
                    () => Client.User.ListByService(context.ResourceGroupName, context.ServiceName, query),
                    nextLink => Client.User.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementUser UserById(PsApiManagementContext context, string userId)
        {
            var response = Client.User.Get(context.ResourceGroupName, context.ServiceName, userId);

            var user = Mapper.Map<PsApiManagementUser>(response);
            return user;
        }

        public void UserRemove(PsApiManagementContext context, string userId, bool deleteSubscriptions)
        {
            Client.User.Delete(context.ResourceGroupName, context.ServiceName, userId, "*", deleteSubscriptions);
        }

        public string UserGetSsoUrl(PsApiManagementContext context, string userId)
        {
            var response = Client.User.GenerateSsoUrl(context.ResourceGroupName, context.ServiceName, userId);

            return response.Value;
        }

        public void UserAddToGroup(PsApiManagementContext context, string groupId, string userId)
        {
            Client.GroupUser.Create(context.ResourceGroupName, context.ServiceName, groupId, userId);
        }

        public void UserRemoveFromGroup(PsApiManagementContext context, string groupId, string userId)
        {
            Client.GroupUser.Delete(context.ResourceGroupName, context.ServiceName, groupId, userId);
        }

        private static Rest.Azure.OData.ODataQuery<UserContract> CreateQueryUserParameters(string firstName, string lastName, string email, PsApiManagementUserState? state)
        {
            var isFirstCondition = true;
            var query = new Rest.Azure.OData.ODataQuery<UserContract>();
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
                query.Filter = string.Format("email eq '{0}'", email);
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
        public PsApiManagementGroup GroupCreate(
            PsApiManagementContext context,
            string groupId,
            string name, 
            string description,
            PsApiManagementGroupType? type,
            string externalId)
        {
            var groupCreateParameters = new GroupCreateParameters(name)
            {
                Description = description
            };

            if (type.HasValue)
            {
                groupCreateParameters.Type = Mapper.Map<GroupType>(type.Value);
            }
            else
            {
                groupCreateParameters.Type = Mapper.Map<GroupType>(PsApiManagementGroupType.Custom);
            }

            if (!string.IsNullOrEmpty(externalId))
            {
                groupCreateParameters.ExternalId = externalId;
            }

            Client.Group.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, groupId, groupCreateParameters);

            var response = Client.Group.Get(context.ResourceGroupName, context.ServiceName, groupId);
            var group = Mapper.Map<PsApiManagementGroup>(response);

            return group;
        }

        public IList<PsApiManagementGroup> GroupsList(PsApiManagementContext context, string name, string userId, string productId)
        {
            var query = new Rest.Azure.OData.ODataQuery<GroupContract>();
            if (!string.IsNullOrEmpty(name))
            {
                query.Filter = string.Format("name eq '{0}'", name);
            }

            IList<PsApiManagementGroup> results;
            if (!string.IsNullOrWhiteSpace(userId))
            {
                results = ListPagedAndMap<PsApiManagementGroup, GroupContract>(
                    () => Client.UserGroup.List(context.ResourceGroupName, context.ServiceName, userId, query),
                    nextLink => Client.UserGroup.ListNext(nextLink));
            }
            else if (!string.IsNullOrEmpty(productId))
            {
                results = ListPagedAndMap<PsApiManagementGroup, GroupContract>(
                    () => Client.ProductGroup.ListByProduct(context.ResourceGroupName, context.ServiceName, productId, query),
                    nextLink => Client.ProductGroup.ListByProductNext(nextLink));
            }
            else
            {
                results = ListPagedAndMap<PsApiManagementGroup, GroupContract>(
                    () => Client.Group.ListByService(context.ResourceGroupName, context.ServiceName, query),
                    nextLink => Client.Group.ListByServiceNext(nextLink));
            }

            return results;
        }

        public PsApiManagementGroup GroupById(PsApiManagementContext context, string groupId)
        {
            var response = Client.Group.Get(context.ResourceGroupName, context.ServiceName, groupId);
            var group = Mapper.Map<PsApiManagementGroup>(response);

            return group;
        }

        public void GroupRemove(PsApiManagementContext context, string groupId)
        {
            Client.Group.Delete(context.ResourceGroupName, context.ServiceName, groupId, "*");
        }

        public void GroupSet(
            PsApiManagementContext context,
            string groupId,
            string name,
            string description)
        {
            var groupUpdate = new GroupUpdateParameters
            {
                DisplayName = name,
                Description = description
            };

            Client.Group.Update(
                context.ResourceGroupName,
                context.ServiceName,
                groupId,
                groupUpdate,
                "*");
        }
        #endregion

        #region Policy

        private static string PolicyGetWrap(Func<PolicyContract> getPolicyFunc)
        {
            try
            {
                var response = getPolicyFunc();

                return response.PolicyContent;
            }
            catch (ErrorResponseException ex)
            {
                if (ex.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }

                throw;
            }
        }

        public string PolicyGetTenantLevel(PsApiManagementContext context)
        {
            return PolicyGetWrap(() => Client.Policy.Get(context.ResourceGroupName, context.ServiceName));
        }

        public string PolicyGetProductLevel(PsApiManagementContext context, string productId)
        {
            return PolicyGetWrap(() => Client.ProductPolicy.Get(context.ResourceGroupName, context.ServiceName, productId));
        }

        public string PolicyGetApiLevel(PsApiManagementContext context, string apiId)
        {
            return PolicyGetWrap(() => Client.ApiPolicy.Get(context.ResourceGroupName, context.ServiceName, apiId));
        }

        public string PolicyGetOperationLevel(PsApiManagementContext context, string apiId, string operationId)
        {
            return PolicyGetWrap(() => Client.ApiOperationPolicy.Get(context.ResourceGroupName, context.ServiceName, apiId, operationId));
        }

        public void PolicySetTenantLevel(PsApiManagementContext context, string policyContent, string contentFormat)
        {
            var policyContract = new PolicyContract();
            policyContract.PolicyContent = policyContent;
            policyContract.ContentFormat = contentFormat;

            Client.Policy.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, policyContract);
        }

        public void PolicySetProductLevel(PsApiManagementContext context, string policyContent, string productId, string contentFormat)
        {
            var policyContract = new PolicyContract();
            policyContract.PolicyContent = policyContent;
            policyContract.ContentFormat = contentFormat;

            Client.ProductPolicy.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, productId, policyContract, "*");
        }

        public void PolicySetApiLevel(PsApiManagementContext context, string policyContent, string apiId, string contentFormat)
        {
            var policyContract = new PolicyContract();
            policyContract.PolicyContent = policyContent;
            policyContract.ContentFormat = contentFormat;

            Client.ApiPolicy.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, apiId, policyContract, "*");
        }

        public void PolicySetOperationLevel(PsApiManagementContext context, string policyContent, string apiId, string operationId, string contentFormat)
        {
            var policyContract = new PolicyContract();
            policyContract.PolicyContent = policyContent;
            policyContract.ContentFormat = contentFormat;

            Client.ApiOperationPolicy.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, apiId, operationId, policyContract, "*");
        }

        public void PolicyRemoveTenantLevel(PsApiManagementContext context)
        {
            Client.Policy.Delete(context.ResourceGroupName, context.ServiceName, "*");
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
                    () => Client.Certificate.ListByService(context.ResourceGroupName, context.ServiceName, null),
                    nextLink => Client.Certificate.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementCertificate CertificateById(PsApiManagementContext context, string certificateId)
        {
            var response = Client.Certificate.Get(context.ResourceGroupName, context.ServiceName, certificateId);

            var certificate = Mapper.Map<PsApiManagementCertificate>(response);

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

            Client.Certificate.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, certificateId, createParameters, null);

            var response = Client.Certificate.Get(context.ResourceGroupName, context.ServiceName, certificateId);
            var certificate = Mapper.Map<PsApiManagementCertificate>(response);

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

            Client.Certificate.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, certificateId, createParameters, "*");

            var response = Client.Certificate.Get(context.ResourceGroupName, context.ServiceName, certificateId);
            var certificate = Mapper.Map<PsApiManagementCertificate>(response);

            return certificate;
        }

        public void CertificateRemove(PsApiManagementContext context, string certificateId)
        {
            Client.Certificate.Delete(context.ResourceGroupName, context.ServiceName, certificateId, "*");
        }
        #endregion

        #region Authorization Servers

        public IList<PsApiManagementOAuth2AuthrozationServer> AuthorizationServerList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementOAuth2AuthrozationServer, AuthorizationServerContract>(
                () => Client.AuthorizationServer.ListByService(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.AuthorizationServer.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementOAuth2AuthrozationServer AuthorizationServerById(PsApiManagementContext context, string serverId)
        {
            var response = Client.AuthorizationServer.Get(context.ResourceGroupName, context.ServiceName, serverId);

            var server = Mapper.Map<PsApiManagementOAuth2AuthrozationServer>(response);
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
            var serverContract = new AuthorizationServerContract
            {
                DisplayName = name,
                Description = description,
                ClientRegistrationEndpoint = clientRegistrationPageUrl,
                AuthorizationEndpoint = authorizationEndpointUrl,
                TokenEndpoint = tokenEndpointUrl,
                ClientId = clientId,
                ClientSecret = clientSecret,
                AuthorizationMethods = GetAuthorizationMethods(authorizationRequestMethods),
                GrantTypes = Mapper.Map<IList<string>>(grantTypes),
                ClientAuthenticationMethod = Mapper.Map<IList<string>>(clientAuthenticationMethods),
                SupportState = supportState ?? false, 
                DefaultScope = defaultScope,
                BearerTokenSendingMethods = Mapper.Map<IList<string>>(accessTokenSendingMethods),
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

            var response = Client.AuthorizationServer.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                serverId,
                serverContract);

            var server = Mapper.Map<PsApiManagementOAuth2AuthrozationServer>(response);

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
            var serverUpdateContract = new AuthorizationServerUpdateContract
            {
                DisplayName = name,
                Description = description,
                ClientRegistrationEndpoint = clientRegistrationPageUrl,
                AuthorizationEndpoint = authorizationEndpointUrl,
                TokenEndpoint = tokenEndpointUrl,
                ClientId = clientId,
                ClientSecret = clientSecret,
                AuthorizationMethods = GetAuthorizationMethods(authorizationRequestMethods),
                GrantTypes = Mapper.Map<IList<string>>(grantTypes),
                ClientAuthenticationMethod = Mapper.Map<IList<string>>(clientAuthenticationMethods),
                SupportState = supportState ?? false,
                DefaultScope = defaultScope,
                BearerTokenSendingMethods = Mapper.Map<IList<string>>(accessTokenSendingMethods),
                ResourceOwnerUsername = resourceOwnerUsername,
                ResourceOwnerPassword = resourceOwnerPassword
            };

            if (tokenBodyParameters != null && tokenBodyParameters.Count > 0)
            {
                serverUpdateContract.TokenBodyParameters = new List<TokenBodyParameterContract>(tokenBodyParameters.Count);
                foreach (var key in tokenBodyParameters.Keys)
                {
                    serverUpdateContract.TokenBodyParameters.Add(
                        new TokenBodyParameterContract
                        {
                            Name = key.ToString(),
                            Value = tokenBodyParameters[key].ToString()
                        });
                }
            }

            Client.AuthorizationServer.Update(
                context.ResourceGroupName,
                context.ServiceName,
                serverId,
                serverUpdateContract,
                "*");
        }

        public void AuthorizationServerRemove(PsApiManagementContext context, string serverId)
        {
            Client.AuthorizationServer.Delete(context.ResourceGroupName, context.ServiceName, serverId, "*");
        }

        /// <summary>
        /// We have to define explicit mapping here, as the enums in the powershell mismatch the enum in the .NET client
        /// and hence direct mapping is not working.
        /// </summary>        
        private static IList<AuthorizationMethod?> GetAuthorizationMethods(PsApiManagementAuthorizationRequestMethod[] authorizationRequestMethods)
        {
            if (authorizationRequestMethods == null)
            {
                return null;
            }

            var result = new List<AuthorizationMethod?>();
            foreach (var requestMethod in authorizationRequestMethods)
            {
                AuthorizationMethod? method;
                switch (requestMethod)
                {
                    case PsApiManagementAuthorizationRequestMethod.Get: method = AuthorizationMethod.GET;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Post: method = AuthorizationMethod.POST;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Head: method = AuthorizationMethod.HEAD;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Options: method = AuthorizationMethod.OPTIONS;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Trace: method = AuthorizationMethod.TRACE;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Put: method = AuthorizationMethod.PUT;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Patch: method = AuthorizationMethod.PATCH;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Delete: method = AuthorizationMethod.DELETE;
                        break;
                    default: throw new Exception("Unknown Authorization Request Method found " + requestMethod);
                }

                result.Add(method);
            }

            return result;
        }

        /// <summary>
        /// We have to define explicit mapping here, as the enums in the powershell mismatch the enum in the .NET client
        /// and hence direct mapping is not working.
        /// </summary>        
        private static PsApiManagementAuthorizationRequestMethod[] GetAuthorizationMethods(IList<AuthorizationMethod?> authorizationRequestMethods)
        {
            if (authorizationRequestMethods == null)
            {
                return null;
            }

            var result = new List<PsApiManagementAuthorizationRequestMethod>();
            foreach (var requestMethod in authorizationRequestMethods)
            {
                PsApiManagementAuthorizationRequestMethod method;
                switch (requestMethod)
                {
                    case AuthorizationMethod.GET:
                        method = PsApiManagementAuthorizationRequestMethod.Get;
                        break;
                    case AuthorizationMethod.POST:
                        method = PsApiManagementAuthorizationRequestMethod.Post;
                        break;
                    case AuthorizationMethod.HEAD:
                        method = PsApiManagementAuthorizationRequestMethod.Head;
                        break;
                    case AuthorizationMethod.OPTIONS:
                        method = PsApiManagementAuthorizationRequestMethod.Options;
                        break;
                    case AuthorizationMethod.TRACE:
                        method = PsApiManagementAuthorizationRequestMethod.Trace;
                        break;
                    case AuthorizationMethod.PUT:
                        method = PsApiManagementAuthorizationRequestMethod.Put;
                        break;
                    case AuthorizationMethod.PATCH:
                        method = PsApiManagementAuthorizationRequestMethod.Patch;
                        break;
                    case AuthorizationMethod.DELETE:
                        method = PsApiManagementAuthorizationRequestMethod.Delete;
                        break;
                    default: throw new Exception("Unknown Authorization Request Method found " + requestMethod);
                }

                result.Add(method);
            }

            return result.ToArray();
        }
        #endregion

        #region Loggers
        public PsApiManagementLogger LoggerCreate(
            PsApiManagementContext context,
            string loggerType,
            string loggerId,
            string description,
            IDictionary<string, string> credentials,
            bool isBuffered)
        {
            var loggerCreateParameters = new LoggerContract(loggerType, credentials)
            {
                Description = description,
                IsBuffered = isBuffered
            };

            var loggerContract = Client.Logger.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, loggerId, loggerCreateParameters);

            var logger = Mapper.Map<PsApiManagementLogger>(loggerContract);

            return logger;
        }

        public IList<PsApiManagementLogger> LoggersList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementLogger, LoggerContract>(
                () => Client.Logger.ListByService(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Logger.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementLogger LoggerById(PsApiManagementContext context, string loggerId)
        {
            var response = Client.Logger.Get(context.ResourceGroupName, context.ServiceName, loggerId);
            var logger = Mapper.Map<PsApiManagementLogger>(response);

            return logger;
        }

        public void LoggerRemove(PsApiManagementContext context, string loggerId)
        {
            Client.Logger.Delete(context.ResourceGroupName, context.ServiceName, loggerId, "*");
        }

        public void LoggerSet(
            PsApiManagementContext context,
            string loggerType,
            string loggerId,
            string description,
            IDictionary<string, string> credentials,
            bool? isBuffered)
        {
            var loggerUpdateParameters = new LoggerUpdateContract();

            if (!string.IsNullOrEmpty(loggerType))
            {
                loggerUpdateParameters.LoggerType = loggerType;
            }

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

            Client.Logger.Update(
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
            var propertyCreateParameters = new PropertyContract(propertyName, propertyValue)
            {
                Secret = secret,
                Tags = tags
            };

            var propertyResponse = Client.Property.CreateOrUpdate(
                context.ResourceGroupName, 
                context.ServiceName, 
                propertyId,
                propertyCreateParameters);

            var property = Mapper.Map<PsApiManagementProperty>(propertyResponse);

            return property;
        }

        public IList<PsApiManagementProperty> PropertiesList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementProperty, PropertyContract>(
                () => Client.Property.ListByService(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Property.ListByServiceNext(nextLink));

            return results;
        }

        public IList<PsApiManagementProperty> PropertyByName(PsApiManagementContext context, string propertyName)
        {
            var results = ListPagedAndMap<PsApiManagementProperty, PropertyContract>(
               () => Client.Property.ListByService(
                   context.ResourceGroupName,
                   context.ServiceName,
                   new Rest.Azure.OData.ODataQuery<PropertyContract>()
                   {
                       Filter = string.Format("substringof('{0}',properties/displayName)", propertyName)
                   }),
               nextLink => Client.Property.ListByServiceNext(nextLink));

            return results;
        }

        public IList<PsApiManagementProperty> PropertyByTag(PsApiManagementContext context, string propertyTag)
        {
            var results = ListPagedAndMap<PsApiManagementProperty, PropertyContract>(
                () => Client.Property.ListByService(
                    context.ResourceGroupName,
                    context.ServiceName,
                    new Rest.Azure.OData.ODataQuery<PropertyContract>()
                    {
                        Filter = string.Format("tags/any(t: t eq '{0}')", propertyTag)
                    }),
                nextLink => Client.Property.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementProperty PropertyById(PsApiManagementContext context, string propertyId)
        {
            var response = Client.Property.Get(context.ResourceGroupName, context.ServiceName, propertyId);
            var property = Mapper.Map<PsApiManagementProperty>(response);

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
            var propertyToUpdate = Client.Property.Get(context.ResourceGroupName, context.ServiceName, propertyId);

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                propertyToUpdate.DisplayName = propertyName;
            }

            if (!string.IsNullOrWhiteSpace(propertyValue))
            {
                propertyToUpdate.Value = propertyValue;
            }

            if (isSecret.HasValue)
            {
                propertyToUpdate.Secret = isSecret.Value;
            }

            if (tags != null)
            {
                propertyToUpdate.Tags = tags;
            }

            Client.Property.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                propertyId,
                propertyToUpdate,
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
            var openIdProviderCreateParameters = new OpenidConnectProviderContract(name, metadataEndpointUri, clientId);

            if (!string.IsNullOrWhiteSpace(clientSecret))
            {
                openIdProviderCreateParameters.ClientSecret = clientSecret;
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                openIdProviderCreateParameters.Description = description;
            }

            Client.OpenIdConnectProvider.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                openIdProviderId,
                openIdProviderCreateParameters);

            var response = Client.OpenIdConnectProvider.Get(context.ResourceGroupName, context.ServiceName, openIdProviderId);
            var openIdConnectProvider = Mapper.Map<PsApiManagementOpenIdConnectProvider>(response);

            return openIdConnectProvider;
        }

        public IList<PsApiManagementOpenIdConnectProvider> OpenIdConnectProvidersList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementOpenIdConnectProvider, OpenidConnectProviderContract>(
                () => Client.OpenIdConnectProvider.ListByService(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.OpenIdConnectProvider.ListByServiceNext(nextLink));

            return results;
        }

        public IList<PsApiManagementOpenIdConnectProvider> OpenIdConnectProviderByName(PsApiManagementContext context, string openIdConnectProviderName)
        {
            var results = ListPagedAndMap<PsApiManagementOpenIdConnectProvider, OpenidConnectProviderContract>(
                () => Client.OpenIdConnectProvider.ListByService(
                    context.ResourceGroupName,
                    context.ServiceName,
                     new Rest.Azure.OData.ODataQuery<OpenidConnectProviderContract>
                     {
                         Filter = string.Format("substringof('{0}',properties/displayName)", openIdConnectProviderName)
                     }),
                nextLink => Client.OpenIdConnectProvider.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementOpenIdConnectProvider OpenIdConnectProviderById(PsApiManagementContext context, string openIdConnectProviderId)
        {
            var response = Client.OpenIdConnectProvider.Get(
                context.ResourceGroupName,
                context.ServiceName,
                openIdConnectProviderId);

            var openIdConnectProvider = Mapper.Map<PsApiManagementOpenIdConnectProvider>(response);

            return openIdConnectProvider;
        }

        public void OpenIdConnectProviderRemove(PsApiManagementContext context, string openIdConnectProviderId)
        {
            Client.OpenIdConnectProvider.Delete(context.ResourceGroupName, context.ServiceName, openIdConnectProviderId, "*");
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
                openIdConnectProviderUpdateParameters.DisplayName = name;
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

            Client.OpenIdConnectProvider.Update(
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

            return Mapper.Map<PsApiManagementAccessInformation>(response);
        }
        #endregion

        #region TenantConfiguration

        public PsApiManagementOperationResult SaveTenantGitConfiguration(
            PsApiManagementContext context,
            string branchName,
            bool force)
        {
            var saveConfigurationParams = new SaveConfigurationParameter(branchName)
            {
                Force = force
            };

            var operationResultContract = Client.TenantConfiguration.Save(
                context.ResourceGroupName,
                context.ServiceName,
                saveConfigurationParams);

            return new PsApiManagementOperationResult(operationResultContract);
        }

        public PsApiManagementOperationResult PublishGitConfiguration(
            PsApiManagementContext context,
            string branchName,
            bool force)
        {
            var deployConfigurationParams = new DeployConfigurationParameters(branchName)
            {
                Force = force
            };

            var operationResultContract = Client.TenantConfiguration.Deploy(
                context.ResourceGroupName,
                context.ServiceName,
                deployConfigurationParams);

            return new PsApiManagementOperationResult(operationResultContract);
        }

        public PsApiManagementOperationResult ValidateTenantGitConfiguration(
            PsApiManagementContext context,
            string branchName,
            bool force)
        {
            var deployConfigurationParams = new DeployConfigurationParameters(branchName)
            {
                Force = force
            };

            var operationResultContract = Client.TenantConfiguration.Validate(
                context.ResourceGroupName,
                context.ServiceName,
                deployConfigurationParams);

            return new PsApiManagementOperationResult(operationResultContract);
        }

        public PsApiManagementTenantConfigurationSyncState GetTenantConfigurationSyncState(
            PsApiManagementContext context)
        {
            var response = Client.TenantConfiguration.GetSyncState(
                context.ResourceGroupName,
                context.ServiceName);

            return Mapper.Map<PsApiManagementTenantConfigurationSyncState>(response);
        }

        #endregion

        #region TenantAccessInformation
        public PsApiManagementAccessInformation GetTenantAccessInformation(PsApiManagementContext context)
        {
            var response = Client.TenantAccess.Get(
                context.ResourceGroupName,
                context.ServiceName);

            return Mapper.Map<PsApiManagementAccessInformation>(response);
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

        #region IdentityProvider
        public PsApiManagementIdentityProvider IdentityProviderCreate(
            PsApiManagementContext context,
            string identityProviderName,
            string clientId,
            string clientSecret,
            string[] allowedTenants)
        {
            var identityProviderCreateParameters = new IdentityProviderContract(clientId, clientSecret);
            if (allowedTenants != null)
            {
                identityProviderCreateParameters.AllowedTenants = allowedTenants;
            }

            var response = Client.IdentityProvider.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                identityProviderName,
                identityProviderCreateParameters);            
            var identityProvider = Mapper.Map<PsApiManagementIdentityProvider>(response);

            return identityProvider;
        }

        public IList<PsApiManagementIdentityProvider> IdentityProviderList(PsApiManagementContext context)
        {
            var identityProviderListResponse = Client.IdentityProvider.ListByService(
                context.ResourceGroupName,
                context.ServiceName);

            var results = Mapper.Map<IList<PsApiManagementIdentityProvider>>(identityProviderListResponse);

            return results;
        }

        public PsApiManagementIdentityProvider IdentityProviderByName(PsApiManagementContext context, string identityProviderName)
        {
            var response = Client.IdentityProvider.Get(
                context.ResourceGroupName,
                context.ServiceName,
                identityProviderName);
            var identityProvider = Mapper.Map<PsApiManagementIdentityProvider>(response);

            return identityProvider;
        }

        public void IdentityProviderRemove(PsApiManagementContext context, string identityProviderName)
        {
            Client.IdentityProvider.Delete(context.ResourceGroupName, context.ServiceName, identityProviderName, "*");
        }

        public void IdentityProviderSet(PsApiManagementContext context, string identityProviderName, string clientId, string clientSecret, string[] allowedTenant)
        {
            var parameters = new IdentityProviderUpdateParameters();
            if (!string.IsNullOrEmpty(clientId))
            {
                parameters.ClientId = clientId;
            }

            if (!string.IsNullOrEmpty(clientSecret))
            {
                parameters.ClientSecret = clientSecret;
            }

            if (allowedTenant != null)
            {
                parameters.AllowedTenants = allowedTenant;
            }

            Client.IdentityProvider.Update(
                context.ResourceGroupName,
                context.ServiceName,
                identityProviderName,
                parameters,
                "*");
        }
        #endregion

        #region Backends
        public PsApiManagementBackend BackendCreate(
            PsApiManagementContext context,
            string backendId,
            string url,
            string protocol,
            string title,
            string description,
            string resourceId,
            bool? skipCertificateChainValidation,
            bool? skipCertificateNameValidation,
            PsApiManagementBackendCredential credential,
            PsApiManagementBackendProxy proxy,
            PsApiManagementServiceFabric serviceFabric)
        {
            var backendCreateParams = new BackendContract(url, protocol);
            if (!string.IsNullOrEmpty(resourceId))
            {
                backendCreateParams.ResourceId = resourceId;
            }

            if (!string.IsNullOrEmpty(title))
            {
                backendCreateParams.Title = title;
            }

            if (!string.IsNullOrEmpty(description))
            {
                backendCreateParams.Description = description;
            }

            if (skipCertificateChainValidation.HasValue || skipCertificateNameValidation.HasValue)
            {
                backendCreateParams.Tls = new BackendTlsProperties();
                if (skipCertificateNameValidation.HasValue)
                {
                    backendCreateParams.Tls.ValidateCertificateName = !skipCertificateNameValidation.Value;
                }

                if (skipCertificateChainValidation.HasValue)
                {
                    backendCreateParams.Tls.ValidateCertificateChain =  !skipCertificateChainValidation.Value;
                }
            }

            if (credential != null)
            {
                backendCreateParams.Credentials = new BackendCredentialsContract();
                if (credential.Query != null)
                {
                    backendCreateParams.Credentials.Query = HashTableToDictionary(credential.Query);
                }

                if (credential.Header != null)
                {
                    backendCreateParams.Credentials.Header = HashTableToDictionary(credential.Header);
                }

                if (credential.Certificate != null && credential.Certificate.Any())
                {
                    backendCreateParams.Credentials.Certificate = credential.Certificate.ToList();
                }

                if (credential.Authorization != null)
                {
                    backendCreateParams.Credentials.Authorization =
                        Mapper.Map<BackendAuthorizationHeaderCredentials>(credential.Authorization);
                }
            }

            if (proxy != null)
            {
                backendCreateParams.Proxy = Mapper.Map<PsApiManagementBackendProxy, BackendProxyContract>(proxy);
            }

            if (serviceFabric != null)
            {
                backendCreateParams.Properties = new BackendProperties();
                backendCreateParams.Properties.ServiceFabricCluster = Mapper.Map<BackendServiceFabricClusterProperties>(serviceFabric);
            }

            var response = Client.Backend.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, backendId, backendCreateParams);
            var backend = Mapper.Map<PsApiManagementBackend>(response);

            return backend;
        }

        public IList<PsApiManagementBackend> BackendsList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementBackend, BackendContract>(
                () => Client.Backend.ListByService(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Backend.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementBackend BackendById(PsApiManagementContext context, string backendId)
        {
            var response = Client.Backend.Get(context.ResourceGroupName, context.ServiceName, backendId);
            var backend = Mapper.Map<PsApiManagementBackend>(response);

            return backend;
        }

        public void BackendRemove(PsApiManagementContext context, string backendId)
        {
            Client.Backend.Delete(context.ResourceGroupName, context.ServiceName, backendId, "*");
        }

        public void BackendSet(
            PsApiManagementContext context,
            string backendId,
            string url,
            string protocol,
            string title,
            string description,
            string resourceId,
            bool? skipCertificateChainValidation,
            bool? skipCertificateNameValidation,
            PsApiManagementBackendCredential credential,
            PsApiManagementBackendProxy proxy,
            PsApiManagementServiceFabric serviceFabric)
        {
            var backendUpdateParams = new BackendUpdateParameters();
            if (!string.IsNullOrEmpty(url))
            {
                backendUpdateParams.Url = url;
            }

            if (!string.IsNullOrEmpty(protocol))
            {
                backendUpdateParams.Protocol = protocol;
            }

            if (!string.IsNullOrEmpty(resourceId))
            {
                backendUpdateParams.ResourceId = resourceId;
            }

            if (!string.IsNullOrEmpty(title))
            {
                backendUpdateParams.Title = title;
            }

            if (!string.IsNullOrEmpty(description))
            {
                backendUpdateParams.Description = description;
            }

            if (skipCertificateChainValidation.HasValue || skipCertificateNameValidation.HasValue)
            {
                backendUpdateParams.Tls = new BackendTlsProperties();
                if (skipCertificateNameValidation.HasValue)
                {
                    backendUpdateParams.Tls.ValidateCertificateName = !skipCertificateNameValidation.Value;
                }

                if (skipCertificateChainValidation.HasValue)
                {
                    backendUpdateParams.Tls.ValidateCertificateChain = !skipCertificateChainValidation.Value;
                }
            }

            if (credential != null)
            {
                backendUpdateParams.Credentials = new BackendCredentialsContract();
                if (credential.Query != null)
                {
                    backendUpdateParams.Credentials.Query = HashTableToDictionary(credential.Query);
                }

                if (credential.Header != null)
                {
                    backendUpdateParams.Credentials.Header = HashTableToDictionary(credential.Header);
                }

                if (credential.Certificate != null && credential.Certificate.Any())
                {
                    backendUpdateParams.Credentials.Certificate = credential.Certificate.ToList();
                }

                if (credential.Authorization != null)
                {
                    backendUpdateParams.Credentials.Authorization =
                        Mapper.Map<BackendAuthorizationHeaderCredentials>(credential.Authorization);
                }
            }

            if (proxy != null)
            {
                backendUpdateParams.Proxy = Mapper.Map<BackendProxyContract>(proxy);
            }

            if (serviceFabric != null)
            {
                backendUpdateParams.Properties = new BackendProperties();
                backendUpdateParams.Properties.ServiceFabricCluster = new BackendServiceFabricClusterProperties();
                backendUpdateParams.Properties.ServiceFabricCluster = Mapper.Map<BackendServiceFabricClusterProperties>(serviceFabric);
            }

            Client.Backend.Update(
                context.ResourceGroupName,
                context.ServiceName,
                backendId,
                backendUpdateParams,
                "*");
        }
        #endregion

        static IDictionary<string, object> ToBackendProperties(BackendTlsProperties tlsProperties)
        {
            if (tlsProperties == null)
            {
                return null;
            }

            var psTlsProperties = new Dictionary<string, object>();
            if (tlsProperties.ValidateCertificateChain.HasValue)
            {
                psTlsProperties.Add("skipCertificateChainValidation", !tlsProperties.ValidateCertificateChain.Value);
            }

            if (tlsProperties.ValidateCertificateName.HasValue)
            {
                psTlsProperties.Add("skipCertificateNameValidation", !tlsProperties.ValidateCertificateName.Value);
            }

            return psTlsProperties;
        }

        static Dictionary<string, IList<string>> HashTableToDictionary(Hashtable table)
        {
            if (table == null)
            {
                return null;
            }

            var result = new Dictionary<string, IList<string>>();
            foreach (var entry in table.Cast<DictionaryEntry>())
            {
                var entryValue = entry.Value as object[];
                if (entryValue == null)
                {
                    throw new ArgumentException(
                        string.Format(CultureInfo.InvariantCulture,
                            "Invalid input type specified for Key '{0}', expected string[]",
                            entry.Key));
                }
                result.Add(entry.Key.ToString(), entryValue.Select(i => i.ToString()).ToList());
            }

            return result;
        }

        static IList<X509CertificateName> HashTableToX509CertificateName(Hashtable certificates)
        {
            if (certificates == null)
            {
                return null;
            }

            var result = new List<X509CertificateName>();
            foreach (var keyEntry in certificates.Cast<DictionaryEntry>())
            {
                result.Add(new X509CertificateName()
                {
                    Name = keyEntry.Key.ToString(),
                    IssuerCertificateThumbprint = keyEntry.Value.ToString()
                });
            }

            return result.ToArray();
        }

        static Hashtable X509CertificateToHashTable(IEnumerable<X509CertificateName> certificates)
        {
            if (certificates == null || !certificates.Any())
            {
                return null;
            }

            var result = new Hashtable();
            foreach (var keyEntry in certificates)
            {
                result.Add(keyEntry.Name, keyEntry.IssuerCertificateThumbprint);
            }

            return result;
        }

        static Hashtable DictionaryToHashTable(IDictionary<string, IList<string>> dictionary)
        {
            if (dictionary == null)
            {
                return null;
            }

            var result = new Hashtable();
            foreach (var keyEntry in dictionary.Keys)
            {
                var keyValue = dictionary[keyEntry];

                result.Add(keyEntry, keyValue.Cast<object>().ToArray());
            }

            return result;
        }

        static IList<ParameterContract> ToParameterContract(PsApiManagementParameter[] parameters)
        {
            if (parameters == null || !parameters.Any())
            {
                return null;
            }

            var parameterList = new List<ParameterContract>();
            foreach (var parameter in parameters)
            {
                parameterList.Add(Mapper.Map<ParameterContract>(parameter));
            }

            return parameterList;
        }

        static PsApiManagementParameter[] ToParameterContract(IList<ParameterContract> parameters)
        {
            if (parameters == null || !parameters.Any())
            {
                return null;
            }

            var parameterList = new List<PsApiManagementParameter>();
            foreach (var parameter in parameters)
            {
                parameterList.Add(Mapper.Map<PsApiManagementParameter>(parameter));
            }

            return parameterList.ToArray();
        }

        static string TrimApiResourceIdentifier(string armApiId)
        {
            if (string.IsNullOrEmpty(armApiId))
            {
                return null;
            }

            var apiIdArrary = armApiId.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            return apiIdArrary.Last();
        }
    }
}