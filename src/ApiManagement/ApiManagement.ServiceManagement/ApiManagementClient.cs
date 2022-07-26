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

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Management.Automation;
    using System.Net;
    using System.Text.RegularExpressions;
    using AutoMapper;
    using Common.Authentication;
    using Common.Authentication.Abstractions;
    using Management.ApiManagement;
    using Management.ApiManagement.Models;
    using Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using WindowsAzure.Commands.Common;

    public class ApiManagementClient
    {
        private const string PeriodGroupName = "period";
        private const string ValueGroupName = "value";

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
                lock (_lock)
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
                    .ForMember(dest => dest.Examples, opt => opt.Ignore())
                    .ForMember(dest => dest.FormParameters, opt => opt.Ignore())
                    .ForMember(dest => dest.SchemaId, opt => opt.MapFrom(src => src.SchemaId))
                    .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.TypeName))
                    .AfterMap((src, dest) =>
                        dest.FormParameters = src.FormParameters == null || !src.FormParameters.Any()
                            ? null
                            : ToParameterContract(src.FormParameters))
                    .AfterMap((src, dest) =>
                        dest.Examples = src.Examples == null || !src.Examples.Any()
                            ? null
                            : ToExampleContract(src.Examples));

                cfg
                    .CreateMap<ApiContract, PsApiManagementApi>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
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
                    .ForMember(dest => dest.ApiVersionSetDescription, opt => opt.MapFrom(src => src.ApiVersionDescription))
                    .ForMember(dest => dest.Protocols, opt => opt.MapFrom(src => src.Protocols.ToArray()))
                    .ForMember(dest => dest.TermsOfServiceUrl, opt => opt.MapFrom(src => src.TermsOfServiceUrl))
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
                                : null))
                    .ForMember(
                        dest => dest.OpenidProviderId,
                        opt => opt.MapFrom(
                            src => src.AuthenticationSettings != null && src.AuthenticationSettings.Openid != null
                                ? src.AuthenticationSettings.Openid.OpenidProviderId
                                : null))
                    .ForMember(
                        dest => dest.BearerTokenSendingMethod,
                        opt => opt.MapFrom(
                            src => src.AuthenticationSettings != null && src.AuthenticationSettings.Openid != null && src.AuthenticationSettings.Openid.BearerTokenSendingMethods != null &&
                                src.AuthenticationSettings.Openid.BearerTokenSendingMethods.Any()
                                ? src.AuthenticationSettings.Openid.BearerTokenSendingMethods.ToArray()
                                : null))
                    .ForMember(
                        dest => dest.ContactEmail,
                        opt => opt.MapFrom(
                            src => src.Contact != null
                                ? src.Contact.Email
                                : null))
                    .ForMember(
                        dest => dest.ContactName,
                        opt => opt.MapFrom(
                            src => src.Contact != null
                                ? src.Contact.Name
                                : null))
                    .ForMember(
                        dest => dest.ContactUrl,
                        opt => opt.MapFrom(
                            src => src.Contact != null
                                ? src.Contact.Url
                                : null))
                    .ForMember(
                        dest => dest.LicenseName,
                        opt => opt.MapFrom(
                            src => src.License != null
                                ? src.License.Name
                                : null))
                    .ForMember(
                        dest => dest.LicenseUrl,
                        opt => opt.MapFrom(
                            src => src.License != null
                                ? src.License.Url
                                : null));

                cfg
                    .CreateMap<PsApiManagementApi, ApiContract>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ApiId))
                    .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path))
                    .ForMember(dest => dest.ServiceUrl, opt => opt.MapFrom(src => src.ServiceUrl))
                    .ForMember(dest => dest.ApiRevision, opt => opt.MapFrom(src => src.ApiRevision))
                    .ForMember(dest => dest.ApiVersion, opt => opt.MapFrom(src => src.ApiVersion ?? string.Empty))
                    .ForMember(dest => dest.ApiType, opt => opt.MapFrom(src => src.ApiType ?? ApiType.Http))
                    .ForMember(dest => dest.IsCurrent, opt => opt.MapFrom(src => src.IsCurrent))
                    .ForMember(dest => dest.IsOnline, opt => opt.MapFrom(src => src.IsOnline))
                    .ForMember(dest => dest.ApiVersionDescription, opt => opt.MapFrom(src => src.ApiVersionSetDescription))
                    .ForMember(dest => dest.Protocols, opt => opt.MapFrom(src => src.Protocols.ToArray()))
                    .ForMember(dest => dest.TermsOfServiceUrl, opt => opt.MapFrom(src => src.TermsOfServiceUrl))
                    .AfterMap((src, dest) =>
                        dest.AuthenticationSettings = Utils.ToAuthenticationSettings(src))
                    .AfterMap((src, dest) =>
                        dest.SubscriptionKeyParameterNames = Utils.ToSubscriptionKeyParameterNamesContract(src))
                    .AfterMap((src, dest) =>
                        dest.Contact = Utils.ToContactInformation(src))
                    .AfterMap((src, dest) =>
                        dest.License = Utils.ToLicenseInformation(src));

                cfg
                    .CreateMap<PsApiManagementApi, ApiCreateOrUpdateParameter>()
                    .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.Path))
                    .ForMember(dest => dest.ServiceUrl, opt => opt.MapFrom(src => src.ServiceUrl))
                    .ForMember(dest => dest.ApiRevision, opt => opt.MapFrom(src => src.ApiRevision))
                    .ForMember(dest => dest.ApiVersion, opt => opt.MapFrom(src => src.ApiVersion ?? string.Empty))
                    .ForMember(dest => dest.ApiType, opt => opt.MapFrom(src => src.ApiType ?? ApiType.Http))
                    .ForMember(dest => dest.IsCurrent, opt => opt.MapFrom(src => src.IsCurrent))
                    .ForMember(dest => dest.IsOnline, opt => opt.MapFrom(src => src.IsOnline))
                    .ForMember(dest => dest.ApiVersionDescription, opt => opt.MapFrom(src => src.ApiVersionSetDescription))
                    .ForMember(dest => dest.Protocols, opt => opt.MapFrom(src => src.Protocols.ToArray()))
                    .ForMember(dest => dest.TermsOfServiceUrl, opt => opt.MapFrom(src => src.TermsOfServiceUrl))
                    .AfterMap((src, dest) =>
                        dest.AuthenticationSettings = Utils.ToAuthenticationSettings(src))
                    .AfterMap((src, dest) =>
                        dest.SubscriptionKeyParameterNames = Utils.ToSubscriptionKeyParameterNamesContract(src))
                    .AfterMap((src, dest) =>
                        dest.Contact = Utils.ToContactInformation(src))
                    .AfterMap((src, dest) =>
                        dest.License = Utils.ToLicenseInformation(src));

                cfg.CreateMap<ApiContract, ApiCreateOrUpdateParameter>();

                cfg
                   .CreateMap<RepresentationContract, PsApiManagementRepresentation>()
                   .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
                   .ForMember(dest => dest.Examples, opt => opt.Ignore())
                   .ForMember(dest => dest.FormParameters, opt => opt.Ignore())
                   .ForMember(dest => dest.SchemaId, opt => opt.MapFrom(src => src.SchemaId))
                   .ForMember(dest => dest.TypeName, opt => opt.MapFrom(src => src.TypeName))
                   .AfterMap((src, dest) =>
                       dest.FormParameters = src.FormParameters == null || !src.FormParameters.Any()
                           ? null
                           : ToParameterContract(src.FormParameters))
                    .AfterMap((src, dest) =>
                        dest.Examples = src.Examples == null || !src.Examples.Any()
                            ? null
                            : ToExampleContract(src.Examples));

                cfg
                    .CreateMap<RequestContract, PsApiManagementRequest>()
                    .AfterMap((src, dest) =>
                        dest.Representations = src != null ? ToRepresentationContract(src.Representations) : null)
                    .AfterMap((src, dest) =>
                        dest.QueryParameters = src != null ? ToParameterContract(src.QueryParameters) : null)
                    .AfterMap((src, dest) =>
                        dest.Headers = src != null ? ToParameterContract(src.Headers) : null);

                cfg
                    .CreateMap<ResponseContract, PsApiManagementResponse>()
                    .AfterMap((src, dest) =>
                        dest.Representations = src != null ? ToRepresentationContract(src.Representations) : null);

                cfg
                    .CreateMap<ParameterContract, PsApiManagementParameter>()
                    .ForMember(dest => dest.Values, opt => opt.MapFrom(src => src.Values == null ? null : src.Values.ToArray()));

                cfg
                    .CreateMap<OperationContract, PsApiManagementOperation>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
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
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ReleaseId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.ApiId, opt => opt.Ignore())
                    .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                    .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime))
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => src.UpdatedDateTime))
                    .AfterMap((src, dest) =>
                        dest.ApiId = Utils.TrimApiResourceIdentifier(src.ApiId));

                cfg
                    .CreateMap<PsApiManagementApiRelease, ApiReleaseContract>()
                    .ForMember(dest => dest.ApiId, opt => opt.MapFrom(src => src.ApiId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ReleaseId))
                    .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                    .ForMember(dest => dest.CreatedDateTime, opt => opt.MapFrom(src => src.CreatedDateTime))
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.MapFrom(src => src.UpdatedDateTime));

                // api schemas map

                cfg
                   .CreateMap<SchemaContract, PsApiManagementApiSchema>()
                   .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                   .ForMember(dest => dest.SchemaId, opt => opt.MapFrom(src => src.Name))
                   .ForMember(dest => dest.ApiId, opt => opt.Ignore())
                   .AfterMap((src, dest) =>
                       dest.SchemaDocumentContentType = Utils.GetPsSchemaContentTypeFromApiSchemaContentType(src.ContentType))
                   .AfterMap((src, dest) =>
                       dest.SchemaDocument = Utils.GetSchemaDocumentValue(src));

                cfg
                .CreateMap<PsApiManagementApiSchema, SchemaContract>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.SchemaDocument))
                .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => Utils.GetApiSchemaContentTypeFromPsSchemaContentType(src.SchemaDocumentContentType)));

                cfg
                    .CreateMap<ProductContract, PsApiManagementProduct>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                    .ForMember(dest => dest.SubscriptionRequired, opt => opt.MapFrom(src => src.SubscriptionRequired))
                    .ForMember(dest => dest.SubscriptionsLimit, opt => opt.MapFrom(src => src.SubscriptionsLimit))
                    .ForMember(dest => dest.LegalTerms, opt => opt.MapFrom(src => src.Terms));

                cfg
                    .CreateMap<SubscriptionContract, PsApiManagementSubscription>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.SubscriptionId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src.Scope))
                    .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName));

                cfg
                    .CreateMap<SubscriptionKeysContract, PsApiManagementSubscriptionKey>()
                    .ForMember(dest => dest.PrimaryKey, opt => opt.MapFrom(src => src.PrimaryKey))
                    .ForMember(dest => dest.SecondaryKey, opt => opt.MapFrom(src => src.SecondaryKey));

                cfg
                    .CreateMap<PsApiManagementSubscription, SubscriptionUpdateParameters>()
                    .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src.Scope))
                    .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.OwnerId))
                    .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));

                cfg
                    .CreateMap<UserContract, PsApiManagementUser>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                    .ForMember(dest => dest.RegistrationDate, opt => opt.MapFrom(src => src.RegistrationDate))
                    .ForMember(dest => dest.Identities, opt => opt.MapFrom(src => src.Identities.ToDictionary(key => key.Id, value => value.Provider)));

                cfg
                    .CreateMap<GroupContract, PsApiManagementGroup>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GroupContractType))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.System, opt => opt.MapFrom(src => src.BuiltIn));

                cfg
                    .CreateMap<CertificateContract, PsApiManagementCertificate>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Subject, opt => opt.MapFrom(src => src.Subject))
                    .ForMember(dest => dest.Thumbprint, opt => opt.MapFrom(src => src.Thumbprint))
                    .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate))
                    .ForMember(dest => dest.CertificateId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.KeyVault, opt => opt.MapFrom(src => src.KeyVault)
                    );

                cfg
                    .CreateMap<KeyVaultContractProperties, PsApiManagementKeyVaultEntity>()
                    .ForMember(dest => dest.IdentityClientId, opt => opt.MapFrom(src => src.IdentityClientId))
                    .ForMember(dest => dest.SecretIdentifier, opt => opt.MapFrom(src => src.SecretIdentifier))
                    .ForMember(dest => dest.LastStatus, opt => opt.MapFrom(src => src.LastStatus)
                    );
                
                cfg
                    .CreateMap<AuthorizationServerContract, PsApiManagementOAuth2AuthorizationServer>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
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
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.LoggerId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.IsBuffered, opt => opt.MapFrom(src => src.IsBuffered))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.LoggerType));

                cfg
                    .CreateMap<NamedValueContract, PsApiManagementNamedValue>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.NamedValueId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                    .ForMember(dest => dest.Secret, opt => opt.MapFrom(src => src.Secret))
                    .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags == null ? new string[0] : src.Tags.ToArray()))
                    .ForMember(dest => dest.KeyVault, opt => opt.MapFrom(src => src.KeyVault));

                cfg
                    .CreateMap<NamedValueSecretContract, PsApiManagementNamedValueSecretValue>()
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value));

                cfg
                    .CreateMap<OpenidConnectProviderContract, PsApiManagementOpenIdConnectProvider>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.OpenIdConnectProviderId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DisplayName))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                    .ForMember(dest => dest.ClientSecret, opt => opt.MapFrom(src => src.ClientSecret))
                    .ForMember(dest => dest.MetadataEndpoint, opt => opt.MapFrom(src => src.MetadataEndpoint));

                cfg
                    .CreateMap<AccessInformationContract, PsApiManagementAccessInformation>()
                    .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
                //.ForMember(dest => dest.PrimaryKey, opt => opt.MapFrom(src => src.PrimaryKey))
                //.ForMember(dest => dest.SecondaryKey, opt => opt.MapFrom(src => src.SecondaryKey));

                cfg
                    .CreateMap<AccessInformationSecretsContract, PsApiManagementAccessInformation>()
                    .ForMember(dest => dest.Enabled, opt => opt.MapFrom(src => src.Enabled))
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.PrimaryKey, opt => opt.MapFrom(src => src.PrimaryKey))
                    .ForMember(dest => dest.SecondaryKey, opt => opt.MapFrom(src => src.SecondaryKey));

                cfg.CreateMap<TenantConfigurationSyncStateContract, PsApiManagementTenantConfigurationSyncState>();

                cfg
                    .CreateMap<IdentityProviderContract, PsApiManagementIdentityProvider>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.ClientId, opt => opt.MapFrom(src => src.ClientId))
                    .ForMember(dest => dest.ClientSecret, opt => opt.MapFrom(src => src.ClientSecret))
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.IdentityProviderContractType))
                    .ForMember(dest => dest.SigninPolicyName, opt => opt.MapFrom(src => src.SigninPolicyName))
                    .ForMember(dest => dest.SignupPolicyName, opt => opt.MapFrom(src => src.SignupPolicyName))
                    .ForMember(dest => dest.ProfileEditingPolicyName, opt => opt.MapFrom(src => src.ProfileEditingPolicyName))
                    .ForMember(dest => dest.PasswordResetPolicyName, opt => opt.MapFrom(src => src.PasswordResetPolicyName))
                    .ForMember(dest => dest.Authority, opt => opt.MapFrom(src => src.Authority))
                    .ForMember(dest => dest.SigninTenant, opt => opt.MapFrom(src => src.SigninTenant))
                    .ForMember(dest => dest.AllowedTenants, opt => opt.MapFrom(src => src.AllowedTenants == null ? new string[0] : src.AllowedTenants.ToArray()));

                cfg
                    .CreateMap<PsApiManagementIdentityProvider, IdentityProviderUpdateParameters>()
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
                            : Utils.DictionaryToHashTable(src.Query))
                    .AfterMap((src, dest) =>
                        dest.Header = src.Header == null
                            ? (Hashtable)null
                            : Utils.DictionaryToHashTable(src.Header));
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
                        dest.ServerX509Names = src.ServerX509Names == null ? (Hashtable)null : Utils.X509CertificateToHashTable(src.ServerX509Names));

                cfg
                    .CreateMap<PsApiManagementServiceFabric, BackendServiceFabricClusterProperties>()
                    .ForMember(dest => dest.ClientCertificatethumbprint, opt => opt.MapFrom(src => src.ClientCertificateThumbprint))
                    .ForMember(dest => dest.MaxPartitionResolutionRetries, opt => opt.MapFrom(src => src.MaxPartitionResolutionRetries))
                    .ForMember(dest => dest.ManagementEndpoints, opt => opt.MapFrom(src => src.ManagementEndpoints))
                    .ForMember(dest => dest.ServerX509Names, opt => opt.MapFrom(src => Utils.HashTableToX509CertificateName(src.ServerX509Names)))
                    .ForMember(dest => dest.ServerCertificateThumbprints, opt => opt.MapFrom(src => src.ServerCertificateThumbprint));

                cfg
                    .CreateMap<BackendContract, PsApiManagementBackend>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
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
                        dest.Properties = Utils.ToBackendProperties(src.Tls));

                cfg
                    .CreateMap<GatewayContract, PsApiManagementGateway>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.GatewayId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.LocationData, opt => opt.MapFrom(src => src.LocationData));

                cfg
                    .CreateMap<PsApiManagementGateway, GatewayContract>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.GatewayId))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.LocationData, opt => opt.MapFrom(src => src.LocationData));


                cfg
                    .CreateMap<ResourceLocationDataContract, PsApiManagementResourceLocation>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                    .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
                    .ForMember(dest => dest.CountryOrRegion, opt => opt.MapFrom(src => src.CountryOrRegion));

                cfg
                    .CreateMap<PsApiManagementResourceLocation, ResourceLocationDataContract>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                    .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
                    .ForMember(dest => dest.CountryOrRegion, opt => opt.MapFrom(src => src.CountryOrRegion));

                cfg
                    .CreateMap<GatewayKeysContract, PsApiManagementGatewayKey>()
                    .ForMember(dest => dest.PrimaryKey, opt => opt.MapFrom(src => src.Primary))
                    .ForMember(dest => dest.SecondaryKey, opt => opt.MapFrom(src => src.Secondary));

                cfg
                    .CreateMap<GatewayHostnameConfigurationContract, PsApiManagementGatewayHostnameConfiguration>()
                    .ForMember(dest => dest.GatewayHostnameConfigurationId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.GatewayId, opt => opt.MapFrom(src => new PsApiManagementGatewayHostnameConfiguration(src.Id).GatewayId))
                    .ForMember(dest => dest.Hostname, opt => opt.MapFrom(src => src.Hostname))
                    .ForMember(dest => dest.CertificateResourceId, opt => opt.MapFrom(src => src.CertificateId))
                    .ForMember(dest => dest.NegotiateClientCertificate, opt => opt.MapFrom(src => src.NegotiateClientCertificate));

                cfg
                    .CreateMap<ApiVersionSetContract, PsApiManagementApiVersionSet>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
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

                cfg
                    .CreateMap<CacheContract, PsApiManagementCache>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.AzureRedisResourceId, opt => opt.MapFrom(src => src.ResourceId))
                    .ForMember(dest => dest.CacheId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.UseFromLocation, opt => opt.MapFrom(src => src.UseFromLocation));

                cfg
                    .CreateMap<PsApiManagementCache, CacheContract>()
                    .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.AzureRedisResourceId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CacheId))
                    .ForMember(dest => dest.UseFromLocation, opt => opt.MapFrom(src => src.UseFromLocation));

                cfg
                    .CreateMap<PsApiManagementCache, CacheUpdateParameters>()
                    .ForMember(dest => dest.ResourceId, opt => opt.MapFrom(src => src.AzureRedisResourceId));

                cfg
                    .CreateMap<PsApiManagementDiagnostic, DiagnosticContract>()
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DiagnosticId))
                    .ForMember(dest => dest.Sampling, opt => opt.MapFrom(src => src.SamplingSetting))
                    .ForMember(dest => dest.Frontend, opt => opt.MapFrom(src => src.FrontendSetting))
                    .ForMember(dest => dest.LoggerId, opt => opt.Ignore())
                    .ForMember(dest => dest.Backend, opt => opt.MapFrom(src => src.BackendSetting))
                    .AfterMap((src, dest) =>
                        dest.LoggerId = Utils.GetLoggerIdFullPath(src.LoggerId));

                cfg
                    .CreateMap<PsApiManagementSamplingSetting, SamplingSettings>()
                    .ForMember(dest => dest.Percentage, opt => opt.MapFrom(src => src.SamplingPercentage));

                cfg
                    .CreateMap<PsApiManagementHttpMessageDiagnostic, HttpMessageDiagnostic>()
                    .ForMember(dest => dest.Headers, opt => opt.MapFrom(src => src.HeadersToLog))
                    .ForMember(dest => dest.Body, opt => opt.MapFrom(src => src.Body));

                cfg
                    .CreateMap<PsApiManagementBodyDiagnosticSetting, BodyDiagnosticSettings>()
                    .ForMember(dest => dest.Bytes, opt => opt.MapFrom(src => src.BodyBytesToLog));

                cfg
                    .CreateMap<SamplingSettings, PsApiManagementSamplingSetting>()
                    .ForMember(dest => dest.SamplingPercentage, opt => opt.MapFrom(src => src.Percentage));

                cfg
                    .CreateMap<HttpMessageDiagnostic, PsApiManagementHttpMessageDiagnostic>()
                    .ForMember(dest => dest.HeadersToLog, opt => opt.MapFrom(src => src.Headers));

                cfg
                    .CreateMap<BodyDiagnosticSettings, PsApiManagementBodyDiagnosticSetting>()
                    .ForMember(dest => dest.BodyBytesToLog, opt => opt.MapFrom(src => src.Bytes));

                cfg
                    .CreateMap<DiagnosticContract, PsApiManagementDiagnostic>()
                    .ForMember(dest => dest.DiagnosticId, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.LoggerId, opt => opt.MapFrom(src => Utils.GetLoggerIdentifier(src.LoggerId)))
                    .ForMember(dest => dest.SamplingSetting, opt => opt.MapFrom(src => src.Sampling))
                    .ForMember(dest => dest.FrontendSetting, opt => opt.MapFrom(src => src.Frontend))
                    .ForMember(dest => dest.BackendSetting, opt => opt.MapFrom(src => src.Backend));

                cfg.CreateMap<Hashtable, Hashtable>();

                cfg
                    .CreateMap<ClientSecretContract, PsApiManagementClientSecret>()
                    .ForMember(dest => dest.ClientSecret, opt => opt.MapFrom(src => src.ClientSecret));

                cfg
                    .CreateMap<ParameterExampleContract, PsApiManagementParameterExample>()
                    .ForMember(dest => dest.Value , opt => opt.MapFrom(src => src.Value))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.ExternalValue, opt => opt.MapFrom(src => src.ExternalValue))
                    .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary));

                cfg
                    .CreateMap<PsApiManagementParameterExample, ParameterExampleContract>()
                    .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.ExternalValue, opt => opt.MapFrom(src => src.ExternalValue))
                    .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary));
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

        #region Service
        public ApiManagementServiceResource GetService(PsApiManagementContext context)
        {
            return Client.ApiManagementService.Get(
                context.ResourceGroupName,
                context.ServiceName);
        }

        #endregion

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
                        Filter = string.Format("properties/displayName eq '{0}'", name)
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

        public PsApiManagementApi ApiById(string resourcegroupName, string serviceName, string id)
        {
            var response = Client.Api.Get(resourcegroupName, serviceName, id);

            return Mapper.Map<PsApiManagementApi>(response);
        }

        public PsApiManagementApi ApiCreate(
            PsApiManagementContext context,
            string id,
            string name,
            string description,
            string serviceUrl,
            string urlSuffix,
            string sourceApiId,
            string sourceApiRevision,
            bool subscriptionRequired,
            string apiVersionDescription,
            string apiVersionSetId,
            string apiVersion,
            string apiType,
            PsApiManagementSchema[] urlSchema,
            string authorizationServerId,
            string authorizationScope,
            string subscriptionKeyHeaderName,
            string subscriptionKeyQueryParamName,
            string openIdProviderId,
            string[] bearerTokenSendingMethods,
            string termsOfServiceUrl,
            string contactName,
            string contactUrl,
            string contactEmail,
            string licenseName,
            string licenseUrl)
        {
            var api = new ApiCreateOrUpdateParameter
            {
                DisplayName = name,
                Description = description,
                ServiceUrl = serviceUrl,
                Path = urlSuffix,
                Protocols = Mapper.Map<IList<string>>(urlSchema)
            };
            if (!string.IsNullOrWhiteSpace(apiType))
            {
                api.ApiType = apiType;
            }
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

            if (!string.IsNullOrWhiteSpace(openIdProviderId))
            {
                // there is no scenario in which customer will have both OpenId authentication and Oauth authentication on the same API
                // so it is okay to override the Authentication settings here.
                api.AuthenticationSettings = new AuthenticationSettingsContract
                {
                    Openid = new OpenIdAuthenticationSettingsContract()
                    {
                        OpenidProviderId = openIdProviderId,
                        BearerTokenSendingMethods = bearerTokenSendingMethods
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

            if (subscriptionRequired)
            {
                api.SubscriptionRequired = subscriptionRequired;
            }

            if (!string.IsNullOrEmpty(sourceApiId))
            {
                api.SourceApiId = Utils.GetApiIdFullPath(sourceApiId, sourceApiRevision);
            }

            if (apiVersionDescription != null)
            {
                api.ApiVersionDescription = apiVersionDescription;
            }

            if (!string.IsNullOrWhiteSpace(apiVersionSetId))
            {
                api.ApiVersionSetId = Utils.GetApiVersionIdFullPath(apiVersionSetId);
            }

            if (!string.IsNullOrWhiteSpace(apiVersion))
            {
                api.ApiVersion = apiVersion;
            }

            if (!string.IsNullOrWhiteSpace(apiType))
            {
                api.ApiType = apiType;
            }

            if (!string.IsNullOrWhiteSpace(termsOfServiceUrl))
            {
                api.TermsOfServiceUrl = termsOfServiceUrl;
            }

            if (!string.IsNullOrWhiteSpace(contactEmail) || !string.IsNullOrWhiteSpace(contactName) || !string.IsNullOrWhiteSpace(contactUrl))
            {
                api.Contact = new ApiContactInformation
                {
                    Email = contactEmail,
                    Name = contactName,
                    Url = contactUrl
                };
            }

            if (!string.IsNullOrWhiteSpace(licenseName) || !string.IsNullOrWhiteSpace(licenseUrl))
            {
                api.License = new ApiLicenseInformation
                {
                    Name = licenseName,
                    Url = licenseUrl
                };
            }


            var getResponse = Client.Api.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, id, api, null);

            return Mapper.Map<PsApiManagementApi>(getResponse);
        }


        public void ApiRemove(PsApiManagementContext context, string apiId)
        {
            Client.Api.Delete(context.ResourceGroupName, context.ServiceName, apiId, "*", deleteRevisions: true);
        }

        public void ApiRemoveRevision(string resourceGroupName, string serviceName, string apiId)
        {
            Client.Api.Delete(resourceGroupName, serviceName, apiId, "*", deleteRevisions: false);
        }

        public PsApiManagementApi ApiSet(
            string resourceGroupName,
            string servicename,
            string id,
            string name,
            string description,
            string serviceUrl,
            string urlSuffix,
            bool subscriptionRequired,
            PsApiManagementSchema[] urlSchema,
            string authorizationServerId,
            string authorizationScope,
            string subscriptionKeyHeaderName,
            string subscriptionKeyQueryParamName,
            string openIdProviderId,
            string[] bearerTokenSendingMethods,
            PsApiManagementApi apiObject, 
            string apiType,
            string termsOfServiceUrl,
            string contactName,
            string contactUrl,
            string contactEmail,
            string licenseName,
            string licenseUrl)
        {
            ApiCreateOrUpdateParameter api;
            if (apiObject == null)
            {
                var apiContract = Client.Api.Get(
                    resourceGroupName,
                    servicename,
                    id);
                api = Mapper.Map<ApiCreateOrUpdateParameter>(apiContract);
            }
            else
            {
                id = apiObject.ApiId;
                if (!string.IsNullOrEmpty(apiObject.ApiRevision))
                {
                    id = apiObject.ApiId.ApiRevisionIdentifier(apiObject.ApiRevision);
                }
                api = Mapper.Map<ApiCreateOrUpdateParameter>(apiObject);
            }

            if (!string.IsNullOrEmpty(name))
            {
                api.DisplayName = name;
            }

            if (!string.IsNullOrEmpty(description))
            {
                api.Description = description;
            }

            if (!string.IsNullOrEmpty(serviceUrl))
            {
                api.ServiceUrl = serviceUrl;
            }

            if (!string.IsNullOrEmpty(urlSuffix))
            {
                api.Path = urlSuffix;
            }

            if (urlSchema != null)
            {
                urlSchema = urlSchema.Distinct().ToArray();
                api.Protocols = Mapper.Map<IList<string>>(urlSchema);
            }

            if (subscriptionRequired)
            {
                api.SubscriptionRequired = subscriptionRequired;
            }

            if (!string.IsNullOrEmpty(authorizationServerId))
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

            if (!string.IsNullOrEmpty(openIdProviderId))
            {
                api.AuthenticationSettings = new AuthenticationSettingsContract
                {
                    Openid = new OpenIdAuthenticationSettingsContract
                    {
                        OpenidProviderId = openIdProviderId,
                        BearerTokenSendingMethods = bearerTokenSendingMethods
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

            if (apiType != null)
            {
                api.ApiType = apiType;
            }

            if (!string.IsNullOrWhiteSpace(termsOfServiceUrl))
            {
                api.TermsOfServiceUrl = termsOfServiceUrl;
            }

            if (!string.IsNullOrWhiteSpace(contactEmail) || !string.IsNullOrWhiteSpace(contactName) || !string.IsNullOrWhiteSpace(contactUrl))
            {
                api.Contact = new ApiContactInformation
                {
                    Email = contactEmail,
                    Name = contactName,
                    Url = contactUrl
                };
            }

            if (!string.IsNullOrWhiteSpace(licenseName) || !string.IsNullOrWhiteSpace(licenseUrl))
            {
                api.License = new ApiLicenseInformation
                {
                    Name = licenseName,
                    Url = licenseUrl
                };
            }

            var updatedApiContract = Client.Api.CreateOrUpdate(
                resourceGroupName,
                servicename,
                id,
                api,
                "*");

            return Mapper.Map<PsApiManagementApi>(updatedApiContract);
        }

        public void ApiImportFromFile(
            PsApiManagementContext context,
            string apiId,
            PsApiManagementApiFormat specificationFormat,
            string specificationPath,
            string apiPath,
            string wsdlServiceName,
            string wsdlEndpointName,
            PsApiManagementApiType? apiType,
            PsApiManagementSchema[] protocols,
            string serviceUrl,
            string apiVersionSetId,
            string apiVersion)
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
                Format = contentFormat,
                Path = apiPath,
                Value = contentValue
            };

            if (protocols != null)
            {
                apiCreateOrUpdateParams.Protocols = Mapper.Map<IList<string>>(protocols);
            }

            if (!string.IsNullOrEmpty(serviceUrl))
            {
                apiCreateOrUpdateParams.ServiceUrl = serviceUrl;
            }

            if (!string.IsNullOrEmpty(soapApiType))
            {
                apiCreateOrUpdateParams.SoapApiType = soapApiType;
                apiCreateOrUpdateParams.WsdlSelector = new ApiCreateOrUpdatePropertiesWsdlSelector()
                {
                    WsdlServiceName = wsdlServiceName,
                    WsdlEndpointName = wsdlEndpointName
                };
            }

            if (!string.IsNullOrWhiteSpace(apiVersionSetId))
            {
                apiCreateOrUpdateParams.ApiVersionSetId = Utils.GetApiVersionIdFullPath(apiVersionSetId);
            }

            if (!string.IsNullOrWhiteSpace(apiVersion))
            {
                apiCreateOrUpdateParams.ApiVersion = apiVersion;
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
            PsApiManagementApiType? apiType,
            PsApiManagementSchema[] protocols,
            string serviceUrl,
            string apiVersionSetId,
            string apiVersion)
        {
            string contentFormat = GetContentFormatForApiImport(false, specificationFormat, wsdlServiceName, wsdlEndpointName, true);

            string soapApiType = GetApiTypeForImport(specificationFormat, apiType);

            var createOrUpdateContract = new ApiCreateOrUpdateParameter()
            {
                Format = contentFormat,
                Value = specificationUrl,
                Path = apiPath
            };

            if (protocols != null)
            {
                createOrUpdateContract.Protocols = Mapper.Map<IList<string>>(protocols);
            }

            if (!string.IsNullOrEmpty(serviceUrl))
            {
                createOrUpdateContract.ServiceUrl = serviceUrl;
            }

            if (!string.IsNullOrEmpty(soapApiType))
            {
                createOrUpdateContract.SoapApiType = soapApiType;
                createOrUpdateContract.WsdlSelector = new ApiCreateOrUpdatePropertiesWsdlSelector()
                {
                    WsdlServiceName = wsdlServiceName,
                    WsdlEndpointName = wsdlEndpointName
                };
            }

            if (!string.IsNullOrWhiteSpace(apiVersionSetId))
            {
                createOrUpdateContract.ApiVersionSetId = Utils.GetApiVersionIdFullPath(apiVersionSetId);
            }

            if (!string.IsNullOrWhiteSpace(apiVersion))
            {
                createOrUpdateContract.ApiVersion = apiVersion;
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
            var exportedFileContents = DownloadFileFromLink(response.Value.Link);
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
                case PsApiManagementApiFormat.OpenApi:
                    headerValue = fromFile ? ContentFormat.Openapi : ContentFormat.OpenapiLink;
                    break;
                case PsApiManagementApiFormat.OpenApiJson:
                    headerValue = fromFile ? ContentFormat.Openapijson : ContentFormat.OpenapijsonLink;
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
            switch (specificationFormat)
            {
                case PsApiManagementApiFormat.Swagger:
                    return ExportFormat.Swagger;
                case PsApiManagementApiFormat.OpenApi:
                    return ExportFormat.Openapi;
                case PsApiManagementApiFormat.OpenApiJson:
                    return ExportFormat.OpenapiJson;
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
                switch (apiType.Value)
                {
                    case PsApiManagementApiType.Http: return SoapApiType.SoapToRest;
                    case PsApiManagementApiType.Soap: return SoapApiType.SoapPassThrough;
                    default: return SoapApiType.SoapPassThrough;
                }
            }

            return PsApiManagementApiType.Http.ToString("g");
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
                () => Client.ApiRevision.ListByService(context.ResourceGroupName, context.ServiceName, apiId, null),
                nextLink => Client.ApiRevision.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementApi GetApiRevision(PsApiManagementContext context, string apiId, string revisionId)
        {
            return this.ApiById(context.ResourceGroupName, context.ServiceName, apiId.ApiRevisionIdentifier(revisionId));
        }

        public PsApiManagementApi ApiCreateRevision(
            PsApiManagementContext context,
            string apiId,
            string revisionId,
            string sourceRevisionId,
            string serviceUrl,
            string apiRevisiondescription)
        {
            var api = Client.Api.Get(context.ResourceGroupName, context.ServiceName, apiId);
            ApiCreateOrUpdateParameter apiCreateParams;
            if (string.IsNullOrEmpty(sourceRevisionId))
            {
                apiCreateParams = Mapper.Map<ApiCreateOrUpdateParameter>(api);
                apiCreateParams.IsCurrent = false;
            }
            else
            {
                apiCreateParams = new ApiCreateOrUpdateParameter(api.Path);
                apiCreateParams.SourceApiId = Utils.GetApiIdFullPath(apiId, sourceRevisionId);
            }

            if (serviceUrl != null)
            {
                apiCreateParams.ServiceUrl = serviceUrl;
            }

            if (!string.IsNullOrEmpty(apiRevisiondescription))
            {
                apiCreateParams.ApiRevisionDescription = apiRevisiondescription;
            }

            var getResponse = Client.Api.CreateOrUpdate(
                context.ResourceGroupName,
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
            var apiRelease = Client.ApiRelease.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                apiId,
                releaseId,
                apiReleaseCreateContract);

            return Mapper.Map<PsApiManagementApiRelease>(apiRelease);
        }

        public void UpdateApiRelease(
            string resourceGroupName,
            string serviceName,
            string apiId,
            string releaseId,
            string notes,
            PsApiManagementApiRelease release)
        {
            var apiReleaseContract = Client.ApiRelease.Get(
                resourceGroupName,
                serviceName,
                apiId,
                releaseId);

            if (!string.IsNullOrEmpty(notes))
            {
                apiReleaseContract.Notes = notes;
            }

            Client.ApiRelease.Update(
                resourceGroupName,
                serviceName,
                apiId,
                releaseId,
                apiReleaseContract,
                "*");
        }

        public PsApiManagementApiRelease GetApiReleaseById(string resourceGroupName, string serviceName, string apiId, string releaseId)
        {
            var response = Client.ApiRelease.Get(resourceGroupName, serviceName, apiId, releaseId);
            var apiRelease = Mapper.Map<PsApiManagementApiRelease>(response);

            return apiRelease;
        }

        public IList<PsApiManagementApiRelease> GetApiReleases(string resourceGroupName, string serviceName, string apiId)
        {
            var results = ListPagedAndMap<PsApiManagementApiRelease, ApiReleaseContract>(
                () => Client.ApiRelease.ListByService(resourceGroupName, serviceName, apiId),
                nextLink => Client.ApiRelease.ListByServiceNext(nextLink));

            return results;
        }

        public void ApiReleaseRemove(string resourceGroupName, string serviceName, string apiId, string releaseId)
        {
            Client.ApiRelease.Delete(resourceGroupName, serviceName, apiId, releaseId, "*");
        }

        #endregion

        #region API Schemas
        public IList<PsApiManagementApiSchema> ApiSchemaList(string resourceGroupName, string serviceName, string apiId)
        {
            var results = ListPagedAndMap<PsApiManagementApiSchema, SchemaContract>(
                () => Client.ApiSchema.ListByApi(resourceGroupName, serviceName, apiId),
                nextLink => Client.ApiSchema.ListByApiNext(nextLink));

            return results;
        }

        public PsApiManagementApiSchema ApiSchemaById(string resourcegroupName, string serviceName, string apiId, string schemaId)
        {
            var response = Client.ApiSchema.Get(resourcegroupName, serviceName, apiId, schemaId);

            return Mapper.Map<PsApiManagementApiSchema>(response);
        }

        public PsApiManagementApiSchema ApiSchemaCreate(
            string resourceGroupName,
            string serviceName,
            string apiId,
            string schemaId,
            string schemaDocumentContentType,
            string document)
        {
            var contentType = Utils.GetApiSchemaContentTypeFromPsSchemaContentType(schemaDocumentContentType);
            var apiSchemaCreateContract = new SchemaContract
            {
                ContentType = contentType,
                Value = document
            };

            var getResponse = Client.ApiSchema.CreateOrUpdate(
                resourceGroupName,
                serviceName,
                apiId,
                schemaId,
                apiSchemaCreateContract);

            return Mapper.Map<PsApiManagementApiSchema>(getResponse);
        }

        public PsApiManagementApiSchema ApiSchemaSet(
           string resourceGroupName,
           string serviceName,
           string apiId,
           string schemaId,
           string schemaDocumentContentType,
           string document,
           PsApiManagementApiSchema inputObject)
        {
            SchemaContract apiSchemaCreateOrUpdate;
            if (inputObject == null)
            {
                var apiSchemaContract = Client.ApiSchema.Get(
                    resourceGroupName,
                    serviceName,
                    apiId,
                    schemaId);

                apiSchemaCreateOrUpdate = new SchemaContract();
                apiSchemaCreateOrUpdate.ContentType = apiSchemaContract.ContentType;
                apiSchemaCreateOrUpdate.Value = Utils.GetSchemaDocumentValue(apiSchemaContract);
            }
            else
            {
                apiSchemaCreateOrUpdate = Mapper.Map<SchemaContract>(inputObject);
            }

            var contentType = Utils.GetApiSchemaContentTypeFromPsSchemaContentType(schemaDocumentContentType);
            if (!string.IsNullOrEmpty(document))
            {
                apiSchemaCreateOrUpdate.Value = document;
            }

            if (!string.IsNullOrEmpty(contentType))
            {
                apiSchemaCreateOrUpdate.ContentType = contentType;
            }

            var getResponse = Client.ApiSchema.CreateOrUpdate(
                resourceGroupName,
                serviceName,
                apiId,
                schemaId,
                apiSchemaCreateOrUpdate,
                "*");

            return Mapper.Map<PsApiManagementApiSchema>(getResponse);
        }

        public void ApiSchemaRemove(string resourceGroupName, string serviceName, string apiId, string schemaId)
        {
            Client.ApiSchema.Delete(resourceGroupName, serviceName, apiId, schemaId, "*");
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
            string resourceGroupName,
            string serviceName,
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
                    resourceGroupName,
                    serviceName,
                    versionSetId);
            }
            else
            {
                apiVersionContract = Mapper.Map<ApiVersionSetContract>(versionSetObject);
            }

            if (!string.IsNullOrEmpty(name))
            {
                apiVersionContract.DisplayName = name;
            }

            if (scheme.HasValue)
            {
                apiVersionContract.VersioningScheme = scheme.Value.ToString();

                if (PsApiManagementVersioningScheme.Header == scheme)
                {
                    if (string.IsNullOrEmpty(headerName))
                    {
                        throw new ArgumentNullException(nameof(headerName));
                    }

                    apiVersionContract.VersionHeaderName = headerName;
                    apiVersionContract.VersionQueryName = null;
                }

                if (PsApiManagementVersioningScheme.Query == scheme)
                {
                    if (string.IsNullOrEmpty(queryName))
                    {
                        throw new ArgumentNullException(nameof(queryName));
                    }

                    apiVersionContract.VersionHeaderName = null;
                    apiVersionContract.VersionQueryName = queryName;
                }
            }

            if (description != null)
            {
                apiVersionContract.Description = description;
            }

            var updatedApiVersionSet = Client.ApiVersionSet.CreateOrUpdate(
                resourceGroupName,
                serviceName,
                versionSetId,
                apiVersionContract,
                "*");

            return Mapper.Map<PsApiManagementApiVersionSet>(updatedApiVersionSet);
        }

        public PsApiManagementApiVersionSet GetApiVersionSet(string resourceGroupName, string serviceName, string apiVersionSetId)
        {
            var getApiVersionSet = Client.ApiVersionSet.Get(resourceGroupName, serviceName, apiVersionSetId);
            var apiVersionSet = Mapper.Map<PsApiManagementApiVersionSet>(getApiVersionSet);
            return apiVersionSet;
        }

        public IList<PsApiManagementApiVersionSet> GetApiVersionSets(string resourceGroupName, string serviceName)
        {
            var results = ListPagedAndMap<PsApiManagementApiVersionSet, ApiVersionSetContract>(
                () => Client.ApiVersionSet.ListByService(resourceGroupName, serviceName),
                nextLink => Client.ApiVersionSet.ListByServiceNext(nextLink));

            return results;
        }

        public void ApiVersionSetRemove(string resourceGroupName, string serviceName, string apiVersionSetId)
        {
            Client.ApiVersionSet.Delete(resourceGroupName, serviceName, apiVersionSetId, "*");
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
        public IList<PsApiManagementProduct> ProductList(PsApiManagementContext context, string title)
        {
            var query = new Rest.Azure.OData.ODataQuery<ProductContract>();
            if (!string.IsNullOrWhiteSpace(title))
            {
                query.Filter = string.Format("properties/displayName eq '{0}'", title);
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

        public IList<PsApiManagementSubscription> SubscriptionByScope(PsApiManagementContext context, string scope)
        {
            var query = new Rest.Azure.OData.ODataQuery<SubscriptionContract>();
            query.Filter = string.Format("properties/scope eq '{0}'", scope);

            var results = ListPagedAndMap<PsApiManagementSubscription, SubscriptionContract>(
                () => Client.Subscription.List(context.ResourceGroupName, context.ServiceName, query),
                nextLink => Client.UserSubscription.ListNext(nextLink));

            return results;
        }

        public IList<PsApiManagementSubscription> SubscriptionByProductAndUser(PsApiManagementContext context, string productId, string userId)
        {
            var query = new Rest.Azure.OData.ODataQuery<SubscriptionContract>();
            query.Filter = string.Format("properties/scope eq '/products/{0}' and properties/ownerId eq '{1}'", productId, userId);

            var results = ListPagedAndMap<PsApiManagementSubscription, SubscriptionContract>(
                () => Client.Subscription.List(context.ResourceGroupName, context.ServiceName, query),
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

        public PsApiManagementSubscription SubscriptionById(
            string resourceGroupName,
            string serviceName,
            string subscriptionId)
        {
            var response = Client.Subscription.Get(
                resourceGroupName,
                serviceName,
                subscriptionId);
            var subscription = Mapper.Map<PsApiManagementSubscription>(response);

            return subscription;
        }

        public PsApiManagementSubscriptionKey SubscriptionKeyById(
            string resourceGroupName,
            string serviceName,
            string subscriptionId)
        {
            var response = Client.Subscription.ListSecrets(
                resourceGroupName,
                serviceName,
                subscriptionId);
            var keys = Mapper.Map<PsApiManagementSubscriptionKey>(response);

            return keys;
        }

        public PsApiManagementSubscription SubscriptionCreate(
            PsApiManagementContext context,
            string subscriptionId,
            string scope,
            string productId,
            string userId,
            string name,
            string primaryKey,
            string secondaryKey,
            bool allowTracing,
            PsApiManagementSubscriptionState? state)
        {
            SubscriptionCreateParameters createParameters;

            if (productId != null)
            {
                createParameters = new SubscriptionCreateParameters(
                    Utils.GetProductIdFullPath(productId),
                    name);
            }
            else
            {
                createParameters = new SubscriptionCreateParameters(
                    scope,
                    name);
            }

            if (primaryKey != null)
            {
                createParameters.PrimaryKey = primaryKey;
            }

            if (secondaryKey != null)
            {
                createParameters.SecondaryKey = secondaryKey;
            }

            if (userId != null)
            {
                createParameters.OwnerId = Utils.GetUserIdFullPath(userId);
            }

            if (allowTracing)
            {
                createParameters.AllowTracing = allowTracing;
            }

            if (state.HasValue)
            {
                createParameters.State = Mapper.Map<SubscriptionState>(state.Value);
            }

            var response = Client.Subscription.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                subscriptionId,
                createParameters);

            return Mapper.Map<PsApiManagementSubscription>(response);
        }

        public void SubscriptionSet(
            string resourceGroupName,
            string serviceName,
            string subscriptionId,
            string name,
            string scope,
            string userId,
            string primaryKey,
            string secondaryKey,
            PsApiManagementSubscriptionState? state,
            DateTime? expiresOn,
            string stateComment,
            PsApiManagementSubscription inputObject)
        {
            SubscriptionUpdateParameters updateParameters;
            if (inputObject == null)
            {
                updateParameters = new SubscriptionUpdateParameters();
            }
            else
            {
                updateParameters = Mapper.Map<SubscriptionUpdateParameters>(inputObject);
            }

            if (!string.IsNullOrEmpty(name))
            {
                updateParameters.DisplayName = name;
            }

            if (!string.IsNullOrEmpty(primaryKey))
            {
                updateParameters.PrimaryKey = primaryKey;
            }

            if (!string.IsNullOrEmpty(secondaryKey))
            {
                updateParameters.SecondaryKey = secondaryKey;
            }

            if (expiresOn != null)
            {
                updateParameters.ExpirationDate = expiresOn;
            }

            if (!string.IsNullOrEmpty(stateComment))
            {
                updateParameters.StateComment = stateComment;
            }

            if (!string.IsNullOrEmpty(scope))
            {
                updateParameters.Scope = scope;
            }

            if (!string.IsNullOrEmpty(userId))
            {
                updateParameters.OwnerId = Utils.GetUserIdFullPath(userId);
            }

            if (state.HasValue)
            {
                updateParameters.State = Mapper.Map<SubscriptionState>(state.Value);
            }

            Client.Subscription.Update(resourceGroupName, serviceName, subscriptionId, updateParameters, "*");
        }

        public void SubscriptionRemove(string resourceGroupName, string serviceName, string subscriptionId)
        {
            Client.Subscription.Delete(resourceGroupName, serviceName, subscriptionId, "*");
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

        public PsApiManagementUserToken UserGetToken(PsApiManagementContext context, string userId, PsApiManagementUserKeyType keyType, DateTime expiry)
        {
            var userKeyType = Mapper.Map<KeyType>(keyType);
            var parameters = new UserTokenParameters(userKeyType, expiry);
            var response = Client.User.GetSharedAccessToken(
                context.ResourceGroupName,
                context.ServiceName,
                userId,
                parameters);

            var token = new PsApiManagementUserToken()
            {
                UserId = userId,
                KeyType = keyType,
                UserToken = response.Value,
                TokenExpiry = expiry
            };

            return token;
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

                return response.Value;
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

        public string PolicyGetTenantLevel(PsApiManagementContext context, string format)
        {
            return PolicyGetWrap(() => Client.Policy.Get(context.ResourceGroupName, context.ServiceName, format));
        }

        public string PolicyGetProductLevel(PsApiManagementContext context, string productId, string format)
        {
            return PolicyGetWrap(() => Client.ProductPolicy.Get(context.ResourceGroupName, context.ServiceName, productId, format));
        }

        public string PolicyGetApiLevel(PsApiManagementContext context, string apiId, string format)
        {
            return PolicyGetWrap(() => Client.ApiPolicy.Get(context.ResourceGroupName, context.ServiceName, apiId, format));
        }

        public string PolicyGetOperationLevel(PsApiManagementContext context, string apiId, string operationId, string format)
        {
            return PolicyGetWrap(() => Client.ApiOperationPolicy.Get(context.ResourceGroupName, context.ServiceName, apiId, operationId, format));
        }

        public void PolicySetTenantLevel(PsApiManagementContext context, string policyContent, string contentFormat)
        {
            var policyContract = new PolicyContract();
            policyContract.Value = policyContent;
            policyContract.Format = contentFormat;

            Client.Policy.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, policyContract);
        }

        public void PolicySetProductLevel(PsApiManagementContext context, string policyContent, string productId, string contentFormat)
        {
            var policyContract = new PolicyContract();
            policyContract.Value = policyContent;
            policyContract.Format = contentFormat;

            Client.ProductPolicy.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, productId, policyContract, "*");
        }

        public void PolicySetApiLevel(PsApiManagementContext context, string policyContent, string apiId, string contentFormat)
        {
            var policyContract = new PolicyContract();
            policyContract.Value = policyContent;
            policyContract.Format = contentFormat;

            Client.ApiPolicy.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, apiId, policyContract, "*");
        }

        public void PolicySetOperationLevel(PsApiManagementContext context, string policyContent, string apiId, string operationId, string contentFormat)
        {
            var policyContract = new PolicyContract();
            policyContract.Value = policyContent;
            policyContract.Format = contentFormat;

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
        public IList<PsApiManagementCertificate> CertificateList(string resourceGroupName, string serviceName)
        {
            var results = ListPagedAndMap<PsApiManagementCertificate, CertificateContract>(
                    () => Client.Certificate.ListByService(resourceGroupName, serviceName, null),
                    nextLink => Client.Certificate.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementCertificate CertificateById(string resourceGroupName, string serviceName, string certificateId)
        {
            var response = Client.Certificate.Get(resourceGroupName, serviceName, certificateId);

            var certificate = Mapper.Map<PsApiManagementCertificate>(response);

            return certificate;
        }

        public PsApiManagementCertificate CertificateCreate(
            PsApiManagementContext context,
            string certificateId,
            byte[] certificateBytes = null,
            string pfxPassword = null,
            PsApiManagementKeyVaultEntity keyvault = null)
        {
            CertificateCreateOrUpdateParameters createParameters;
            if (keyvault == null)
            {
                createParameters = new CertificateCreateOrUpdateParameters
                {
                    Data = Convert.ToBase64String(certificateBytes),
                    Password = pfxPassword
                };
            }
            else
            {
                createParameters = new CertificateCreateOrUpdateParameters
                {
                    KeyVault = new KeyVaultContractCreateProperties
                    {
                        IdentityClientId = keyvault?.IdentityClientId,
                        SecretIdentifier = keyvault?.SecretIdentifier
                    }
                };
            }

            Client.Certificate.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, certificateId, createParameters, null);

            var response = Client.Certificate.Get(context.ResourceGroupName, context.ServiceName, certificateId);
            var certificate = Mapper.Map<PsApiManagementCertificate>(response);

            return certificate;
        }

        public PsApiManagementCertificate CertificateSet(
            PsApiManagementContext context,
            string certificateId,
            byte[] certificateBytes = null,
            string pfxPassword = null,
            PsApiManagementKeyVaultEntity keyvault = null)
        {
            CertificateCreateOrUpdateParameters createParameters;
            if (keyvault == null)
            {
                createParameters = new CertificateCreateOrUpdateParameters
                {
                    Data = Convert.ToBase64String(certificateBytes),
                    Password = pfxPassword
                };
            }
            else
            {
                createParameters = new CertificateCreateOrUpdateParameters
                {
                    KeyVault = new KeyVaultContractCreateProperties
                    {
                        IdentityClientId = keyvault?.IdentityClientId,
                        SecretIdentifier = keyvault?.SecretIdentifier
                    }
                };
            }

            Client.Certificate.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, certificateId, createParameters, "*");

            var response = Client.Certificate.Get(context.ResourceGroupName, context.ServiceName, certificateId);
            var certificate = Mapper.Map<PsApiManagementCertificate>(response);

            return certificate;
        }

        public void CertificateRemove(PsApiManagementContext context, string certificateId)
        {
            Client.Certificate.Delete(context.ResourceGroupName, context.ServiceName, certificateId, "*");
        }

        public PsApiManagementKeyVaultEntity CertificateKeyVaultRefresh(string resourceGroupName, string serviceName, string certificateId)
        {
            Client.Certificate.RefreshSecret(resourceGroupName, serviceName, certificateId);
            var response = Client.Certificate.Get(resourceGroupName, serviceName, certificateId);
            var certificate = Mapper.Map<PsApiManagementKeyVaultEntity>(response.KeyVault);

            return certificate;
        }
        #endregion

        #region Authorization Servers

        public IList<PsApiManagementOAuth2AuthorizationServer> AuthorizationServerList(string resourceGroupName, string serviceName)
        {
            var results = ListPagedAndMap<PsApiManagementOAuth2AuthorizationServer, AuthorizationServerContract>(
                () => Client.AuthorizationServer.ListByService(resourceGroupName, serviceName, null),
                nextLink => Client.AuthorizationServer.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementOAuth2AuthorizationServer AuthorizationServerById(
            string resourceGroupName, string serviceName, string serverId)
        {
            var response = Client.AuthorizationServer.Get(resourceGroupName, serviceName, serverId);

            var server = Mapper.Map<PsApiManagementOAuth2AuthorizationServer>(response);
            return server;
        }

        public PsApiManagementClientSecret AuthorizationServerClientSecretById(
            string resourceGroupName, string serviceName, string serverId)
        {
            var response = Client.AuthorizationServer.ListSecrets(resourceGroupName, serviceName, serverId);

            var server = Mapper.Map<PsApiManagementClientSecret>(response);
            return server;
        }


        public PsApiManagementOAuth2AuthorizationServer AuthorizationServerCreate(
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

            var server = Mapper.Map<PsApiManagementOAuth2AuthorizationServer>(response);

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
                    case PsApiManagementAuthorizationRequestMethod.Get:
                        method = AuthorizationMethod.GET;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Post:
                        method = AuthorizationMethod.POST;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Head:
                        method = AuthorizationMethod.HEAD;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Options:
                        method = AuthorizationMethod.OPTIONS;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Trace:
                        method = AuthorizationMethod.TRACE;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Put:
                        method = AuthorizationMethod.PUT;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Patch:
                        method = AuthorizationMethod.PATCH;
                        break;
                    case PsApiManagementAuthorizationRequestMethod.Delete:
                        method = AuthorizationMethod.DELETE;
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
            var loggerCreateParameters = new LoggerContract()
            {
                LoggerType = loggerType,
                Credentials = credentials,
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
        public PsApiManagementNamedValue NamedValueCreate(
            PsApiManagementContext context,
            string propertyId,
            bool secret,
            string propertyName = null,
            string propertyValue = null,
            IList<string> tags = null,
            PsApiManagementKeyVaultEntity keyvault = null)

        {
            NamedValueCreateContract propertyCreateParameters;

            if (keyvault == null)
            {
                propertyCreateParameters = new NamedValueCreateContract
                {
                    DisplayName = propertyName,
                    Value = propertyValue,
                    Secret = secret,
                    Tags = tags
                };
            }
            else
            {
                propertyCreateParameters = new NamedValueCreateContract
                {
                    DisplayName = propertyName,
                    KeyVault = new KeyVaultContractCreateProperties
                    {
                        IdentityClientId = keyvault?.IdentityClientId,
                        SecretIdentifier = keyvault?.SecretIdentifier
                    },
                    Secret = secret,
                    Tags = tags
                };
            }

            var propertyResponse = Client.NamedValue.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                propertyId,
                propertyCreateParameters);

            var property = Mapper.Map<PsApiManagementNamedValue>(propertyResponse);

            return property;
        }

        public IList<PsApiManagementNamedValue> NamedValuesList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementNamedValue, NamedValueContract>(
                () => Client.NamedValue.ListByService(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.NamedValue.ListByServiceNext(nextLink));

            return results;
        }

        public IList<PsApiManagementNamedValue> NamedValueByName(PsApiManagementContext context, string propertyName)
        {
            var results = ListPagedAndMap<PsApiManagementNamedValue, NamedValueContract>(
               () => Client.NamedValue.ListByService(
                   context.ResourceGroupName,
                   context.ServiceName,
                   new Rest.Azure.OData.ODataQuery<NamedValueContract>()
                   {
                       Filter = string.Format("substringof('{0}',properties/displayName)", propertyName)
                   }),
               nextLink => Client.NamedValue.ListByServiceNext(nextLink));

            return results;
        }

        public IList<PsApiManagementNamedValue> NamedValueByTag(PsApiManagementContext context, string propertyTag)
        {
            var results = ListPagedAndMap<PsApiManagementNamedValue, NamedValueContract>(
                () => Client.NamedValue.ListByService(
                    context.ResourceGroupName,
                    context.ServiceName,
                    new Rest.Azure.OData.ODataQuery<NamedValueContract>()
                    {
                        Filter = string.Format("tags/any(t: t eq '{0}')", propertyTag)
                    }),
                nextLink => Client.NamedValue.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementNamedValue NamedValueById(PsApiManagementContext context, string propertyId)
        {
            var response = Client.NamedValue.Get(context.ResourceGroupName, context.ServiceName, propertyId);
            var property = Mapper.Map<PsApiManagementNamedValue>(response);

            return property;
        }

        public PsApiManagementNamedValueSecretValue NamedValueSecretValueById(PsApiManagementContext context, string propertyId)
        {
            var response = Client.NamedValue.ListValue(context.ResourceGroupName, context.ServiceName, propertyId);
            var property = Mapper.Map<PsApiManagementNamedValueSecretValue>(response);

            return property;
        }

        public void NamedValueRemove(PsApiManagementContext context, string propertyId)
        {
            Client.NamedValue.Delete(context.ResourceGroupName, context.ServiceName, propertyId, "*");
        }

        public void NamedValueSet(
            PsApiManagementContext context,
            string propertyId,
            bool? isSecret,
            string propertyName = null,
            string propertyValue = null,
            IList<string> tags = null,
            PsApiManagementKeyVaultEntity keyvault = null)
        {
            var existingProperty = Client.NamedValue.Get(context.ResourceGroupName, context.ServiceName, propertyId);
            if (existingProperty.KeyVault == null && existingProperty.Secret == true)
            {
                var existingPropertySecretValue = Client.NamedValue.ListValue(context.ResourceGroupName, context.ServiceName, propertyId);
                existingProperty.Value = existingPropertySecretValue.Value;
            }

            var propertyToUpdate = new NamedValueUpdateParameters();

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

            if (keyvault != null)
            {
                propertyToUpdate.KeyVault = new KeyVaultContractCreateProperties
                {
                    SecretIdentifier = keyvault.SecretIdentifier,
                    IdentityClientId = keyvault.IdentityClientId
                };
            }

            if (tags != null)
            {
                propertyToUpdate.Tags = tags;
            }

            Client.NamedValue.Update(
                context.ResourceGroupName,
                context.ServiceName,
                propertyId,
                propertyToUpdate,
                "*");
        }

        public PsApiManagementNamedValue NamedValueKeyVaultRefresh(string resourceGroupName, string serviceName, string namedvalueId)
        {
            Client.NamedValue.RefreshSecret(resourceGroupName, serviceName, namedvalueId);
            var response = Client.NamedValue.Get(resourceGroupName, serviceName, namedvalueId);
            var namedvalue = Mapper.Map<PsApiManagementNamedValue>(response);

            return namedvalue;
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

        public PsApiManagementClientSecret OpenIdConnectProviderClientSecretById(PsApiManagementContext context, string openIdConnectProviderId)
        {
            var response = Client.OpenIdConnectProvider.ListSecrets(
                context.ResourceGroupName,
                context.ServiceName,
                openIdConnectProviderId);

            var openIdConnectProvider = Mapper.Map<PsApiManagementClientSecret>(response);

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
        //replace with listsecret
        public PsApiManagementAccessInformation GetTenantGitAccessInformation(PsApiManagementContext context)
        {
            var response = Client.TenantAccess.ListSecrets(
                context.ResourceGroupName,
                context.ServiceName,
                "gitaccess");

            response.PrimaryKey = null;
            response.SecondaryKey = null;
            return Mapper.Map<PsApiManagementAccessInformation>(response);
        }

        public PsApiManagementAccessInformation GetTenantGitAccessInformationSecrets(PsApiManagementContext context)
        {
            var response = Client.TenantAccess.ListSecrets(
                context.ResourceGroupName,
                context.ServiceName,
                "gitaccess");

            return Mapper.Map<PsApiManagementAccessInformation>(response);
        }

        public void RegeneratePrimaryKey(PsApiManagementContext context)
        {
            Client.TenantAccessGit.RegeneratePrimaryKey(
                context.ResourceGroupName,
                context.ServiceName,
                "access");
        }

        public void RegenerateSecondaryKey(PsApiManagementContext context)
        {
            Client.TenantAccessGit.RegenerateSecondaryKey(
                context.ResourceGroupName,
                context.ServiceName,
                "access");
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
                context.ServiceName,
                "access");

            return Mapper.Map<PsApiManagementAccessInformation>(response);
        }

        public PsApiManagementAccessInformation GetTenantAccessInformationSecrets(PsApiManagementContext context)
        {
            var response = Client.TenantAccess.ListSecrets(
                context.ResourceGroupName,
                context.ServiceName,
                "access");

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
            Client.TenantAccess.Update(context.ResourceGroupName, context.ServiceName, accessInformationParams, "access", "*");
        }
        #endregion

        #region IdentityProvider
        public PsApiManagementIdentityProvider IdentityProviderCreate(
            PsApiManagementContext context,
            string identityProviderName,
            string clientId,
            string clientSecret,
            string[] allowedTenants,
            string authority,
            string signinPolicyName,
            string signupPolicyName,
            string passwordResetPolicyName,
            string profileEditPolicyName,
            string signinTenant)
        {
            var identityProviderCreateParameters = new IdentityProviderCreateContract(clientId, clientSecret);
            if (allowedTenants != null)
            {
                identityProviderCreateParameters.AllowedTenants = allowedTenants;
            }

            if (!string.IsNullOrEmpty(authority))
            {
                identityProviderCreateParameters.Authority = authority;
            }

            if (!string.IsNullOrEmpty(signinPolicyName))
            {
                identityProviderCreateParameters.SigninPolicyName = signinPolicyName;
            }

            if (!string.IsNullOrEmpty(signupPolicyName))
            {
                identityProviderCreateParameters.SignupPolicyName = signupPolicyName;
            }

            if (!string.IsNullOrEmpty(profileEditPolicyName))
            {
                identityProviderCreateParameters.ProfileEditingPolicyName = profileEditPolicyName;
            }

            if (!string.IsNullOrEmpty(passwordResetPolicyName))
            {
                identityProviderCreateParameters.PasswordResetPolicyName = passwordResetPolicyName;
            }

            if (!string.IsNullOrEmpty(signinTenant))
            {
                identityProviderCreateParameters.SigninTenant = signinTenant;
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

        public PsApiManagementIdentityProvider IdentityProviderByName(string resourceGroupName, string serviceName, string identityProviderName)
        {
            var response = Client.IdentityProvider.Get(
                resourceGroupName,
                serviceName,
                identityProviderName);
            var identityProvider = Mapper.Map<PsApiManagementIdentityProvider>(response);

            return identityProvider;
        }

        public PsApiManagementClientSecret IdentityProviderClientSecretByName(string resourceGroupName, string serviceName, string identityProviderName)
        {
            var response = Client.IdentityProvider.ListSecrets(
                resourceGroupName,
                serviceName,
                identityProviderName);
            var identityProvider = Mapper.Map<PsApiManagementClientSecret>(response);

            return identityProvider;
        }


        public void IdentityProviderRemove(PsApiManagementContext context, string identityProviderName)
        {
            Client.IdentityProvider.Delete(context.ResourceGroupName, context.ServiceName, identityProviderName, "*");
        }

        public void IdentityProviderSet(
            string resourceGroupName,
            string serviceName,
            string identityProviderName,
            string clientId,
            string clientSecret,
            string[] allowedTenant,
            string authority,
            string signinPolicyName,
            string signupPolicyName,
            string passwordResetPolicyName,
            string profileEditPolicyName,
            string signinTenant,
            PsApiManagementIdentityProvider identityProvider)
        {
            var parameters = new IdentityProviderUpdateParameters();

            if (identityProvider != null)
            {
                parameters = Mapper.Map<IdentityProviderUpdateParameters>(identityProvider);
            }

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

            if (!string.IsNullOrEmpty(authority))
            {
                parameters.Authority = authority;
            }

            if (!string.IsNullOrEmpty(signinPolicyName))
            {
                parameters.SigninPolicyName = signinPolicyName;
            }

            if (!string.IsNullOrEmpty(signupPolicyName))
            {
                parameters.SignupPolicyName = signupPolicyName;
            }

            if (!string.IsNullOrEmpty(profileEditPolicyName))
            {
                parameters.ProfileEditingPolicyName = profileEditPolicyName;
            }

            if (!string.IsNullOrEmpty(passwordResetPolicyName))
            {
                parameters.PasswordResetPolicyName = passwordResetPolicyName;
            }

            if (!string.IsNullOrEmpty(signinTenant))
            {
                parameters.SigninTenant = signinTenant;
            }

            Client.IdentityProvider.Update(
                resourceGroupName,
                serviceName,
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
                    backendCreateParams.Tls.ValidateCertificateChain = !skipCertificateChainValidation.Value;
                }
            }

            if (credential != null)
            {
                backendCreateParams.Credentials = new BackendCredentialsContract();
                if (credential.Query != null)
                {
                    backendCreateParams.Credentials.Query = Utils.HashTableToDictionary(credential.Query);
                }

                if (credential.Header != null)
                {
                    backendCreateParams.Credentials.Header = Utils.HashTableToDictionary(credential.Header);
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

        public IList<PsApiManagementBackend> BackendsList(string resourceGroupName, string serviceName)
        {
            var results = ListPagedAndMap<PsApiManagementBackend, BackendContract>(
                () => Client.Backend.ListByService(resourceGroupName, serviceName, null),
                nextLink => Client.Backend.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementBackend BackendById(string resourceGroupName, string serviceName, string backendId)
        {
            var response = Client.Backend.Get(resourceGroupName, serviceName, backendId);
            var backend = Mapper.Map<PsApiManagementBackend>(response);

            return backend;
        }

        public void BackendRemove(PsApiManagementContext context, string backendId)
        {
            Client.Backend.Delete(context.ResourceGroupName, context.ServiceName, backendId, "*");
        }

        public void BackendSet(
            string resourceGroupName,
            string serviceName,
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
                    backendUpdateParams.Credentials.Query = Utils.HashTableToDictionary(credential.Query);
                }

                if (credential.Header != null)
                {
                    backendUpdateParams.Credentials.Header = Utils.HashTableToDictionary(credential.Header);
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
                resourceGroupName,
                serviceName,
                backendId,
                backendUpdateParams,
                "*");
        }
        #endregion

        #region Caches
        public PsApiManagementCache CacheCreate(
            PsApiManagementContext context,
            string cacheId,
            string connectionString,
            string description,
            string resourceid,
            string UseFromLocation)
        {
            var cacheCreateParameters = new CacheContract(connectionString, UseFromLocation);
            if (description != null)
            {
                cacheCreateParameters.Description = description;
            }

            if (!string.IsNullOrEmpty(resourceid))
            {
                cacheCreateParameters.ResourceId = resourceid;
            }

            var response = Client.Cache.CreateOrUpdate(
                context.ResourceGroupName,
                context.ServiceName,
                cacheId,
                cacheCreateParameters);
            var cache = Mapper.Map<PsApiManagementCache>(response);

            return cache;
        }

        public IList<PsApiManagementCache> CacheList(string resourceGroupName, string serviceName)
        {
            var results = ListPagedAndMap<PsApiManagementCache, CacheContract>(
                 () => Client.Cache.ListByService(resourceGroupName, serviceName, null),
                 nextLink => Client.Cache.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementCache CacheGetById(
            string resourceGroupName,
            string serviceName,
            string cacheId)
        {
            var response = Client.Cache.Get(
                resourceGroupName,
                serviceName,
                cacheId);
            var cacheContract = Mapper.Map<PsApiManagementCache>(response);

            return cacheContract;
        }

        public void CacheRemove(string resourceGroupName, string serviceName, string cacheId)
        {
            Client.Cache.Delete(resourceGroupName, serviceName, cacheId, "*");
        }

        public void CacheSet(
            string resourceGroupName,
            string serviceName,
            string cacheId,
            string connectionString,
            string description,
            string resourceId,
            string UseFromLocation,
            PsApiManagementCache cacheObject)
        {
            CacheUpdateParameters parameters;
            if (cacheObject == null)
            {
                parameters = new CacheUpdateParameters();
            }
            else
            {
                parameters = Mapper.Map<CacheUpdateParameters>(cacheObject);
            }

            if (!string.IsNullOrEmpty(connectionString))
            {
                parameters.ConnectionString = connectionString;
            }

            if (description != null)
            {
                parameters.Description = description;
            }

            if (resourceId != null)
            {
                parameters.ResourceId = resourceId;
            }

            if (UseFromLocation != null)
            {
                parameters.UseFromLocation = UseFromLocation;
            }

            Client.Cache.Update(
                resourceGroupName,
                serviceName,
                cacheId,
                parameters,
                "*");
        }
        #endregion

        #region Diagnostics

        public PsApiManagementDiagnostic DiagnosticCreate(
            PsApiManagementContext context,
            string diagnosticId,
            string apiId,
            string loggerId,
            string alwaysLog,
            PsApiManagementSamplingSetting sampling,
            PsApiManagementPipelineDiagnosticSetting frontend,
            PsApiManagementPipelineDiagnosticSetting backend)
        {
            var diagnosticContract = new DiagnosticContract(Utils.GetLoggerIdFullPath(loggerId));
            if (!string.IsNullOrEmpty(alwaysLog))
            {
                diagnosticContract.AlwaysLog = Utils.GetAlwaysLog(alwaysLog);
            }

            if (sampling != null)
            {
                diagnosticContract.Sampling = Mapper.Map<SamplingSettings>(sampling);
            }

            if (frontend != null)
            {
                diagnosticContract.Frontend = Mapper.Map<PipelineDiagnosticSettings>(frontend);
            }

            if (backend != null)
            {
                diagnosticContract.Backend = Mapper.Map<PipelineDiagnosticSettings>(backend);
            }

            DiagnosticContract diagnosticResult;
            if (!string.IsNullOrEmpty(apiId))
            {
                diagnosticResult = Client.ApiDiagnostic.CreateOrUpdate(
                    context.ResourceGroupName,
                    context.ServiceName,
                    apiId,
                    diagnosticId,
                    diagnosticContract);
            }
            else
            {
                diagnosticResult = Client.Diagnostic.CreateOrUpdate(
                    context.ResourceGroupName,
                    context.ServiceName,
                    diagnosticId,
                    diagnosticContract);
            }

            var diagnostic = Mapper.Map<PsApiManagementDiagnostic>(diagnosticResult);

            return diagnostic;
        }

        public IList<PsApiManagementDiagnostic> DiagnosticListTenantLevel(
            string resourceGroupName,
            string serviceName)
        {
            var results = ListPagedAndMap<PsApiManagementDiagnostic, DiagnosticContract>(
                () => Client.Diagnostic.ListByService(resourceGroupName, serviceName, null),
                nextLink => Client.Diagnostic.ListByServiceNext(nextLink));

            return results;
        }

        public IList<PsApiManagementDiagnostic> DiagnosticListApiLevel(
            string resourceGroupName,
            string serviceName,
            string apiId)
        {
            var results = ListPagedAndMap<PsApiManagementDiagnostic, DiagnosticContract>(
                () => Client.ApiDiagnostic.ListByService(resourceGroupName, serviceName, apiId, null),
                nextLink => Client.ApiDiagnostic.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementDiagnostic DiagnosticSetTenantLevel(
            string resourceGroupName,
            string serviceName,
            string diagnosticId,
            string loggerId,
            string alwaysLog,
            PsApiManagementSamplingSetting sampling,
            PsApiManagementPipelineDiagnosticSetting frontend,
            PsApiManagementPipelineDiagnosticSetting backend,
            PsApiManagementDiagnostic psApiManagementDiagnostic)
        {
            DiagnosticContract diagnosticContract;
            if (psApiManagementDiagnostic == null)
            {
                diagnosticContract = Client.Diagnostic.Get(
                    resourceGroupName,
                    serviceName,
                    diagnosticId);
            }
            else
            {
                diagnosticContract = Mapper.Map<DiagnosticContract>(psApiManagementDiagnostic);
            }

            if (loggerId != null)
            {
                diagnosticContract.LoggerId = Utils.GetLoggerIdFullPath(loggerId);
            }

            if (alwaysLog != null)
            {
                diagnosticContract.AlwaysLog = Utils.GetAlwaysLog(alwaysLog);
            }

            if (sampling != null)
            {
                diagnosticContract.Sampling = Mapper.Map<SamplingSettings>(sampling);
            }

            if (frontend != null)
            {
                diagnosticContract.Frontend = Mapper.Map<PipelineDiagnosticSettings>(frontend);
            }

            if (backend != null)
            {
                diagnosticContract.Backend = Mapper.Map<PipelineDiagnosticSettings>(backend);
            }

            var response = Client.Diagnostic.CreateOrUpdate(
                resourceGroupName,
                serviceName,
                diagnosticId,
                diagnosticContract,
                "*");

            var psDiagnostic = Mapper.Map<PsApiManagementDiagnostic>(response);
            return psDiagnostic;
        }

        public PsApiManagementDiagnostic DiagnosticSetApiLevel(
           string resourceGroupName,
           string serviceName,
           string apiId,
           string diagnosticId,
           string loggerId,
           string alwaysLog,
           PsApiManagementSamplingSetting sampling,
           PsApiManagementPipelineDiagnosticSetting frontend,
           PsApiManagementPipelineDiagnosticSetting backend,
           PsApiManagementDiagnostic psApiManagementDiagnostic)
        {
            DiagnosticContract diagnosticContract;
            if (psApiManagementDiagnostic == null)
            {
                diagnosticContract = Client.ApiDiagnostic.Get(
                    resourceGroupName,
                    serviceName,
                    apiId,
                    diagnosticId);
            }
            else
            {
                diagnosticContract = Mapper.Map<DiagnosticContract>(psApiManagementDiagnostic);
            }

            if (loggerId != null)
            {
                diagnosticContract.LoggerId = Utils.GetLoggerIdFullPath(loggerId);
            }

            if (alwaysLog != null)
            {
                diagnosticContract.AlwaysLog = alwaysLog;
            }

            if (sampling != null)
            {
                diagnosticContract.Sampling = Mapper.Map<SamplingSettings>(sampling);
            }

            if (frontend != null)
            {
                diagnosticContract.Frontend = Mapper.Map<PipelineDiagnosticSettings>(frontend);
            }

            if (backend != null)
            {
                diagnosticContract.Backend = Mapper.Map<PipelineDiagnosticSettings>(backend);
            }

            var response = Client.ApiDiagnostic.CreateOrUpdate(
                resourceGroupName,
                serviceName,
                apiId,
                diagnosticId,
                diagnosticContract,
                "*");

            var psDiagnostic = Mapper.Map<PsApiManagementDiagnostic>(response);
            return psDiagnostic;
        }

        public PsApiManagementDiagnostic DiagnosticGetTenantLevel(
            string resourceGroupName,
            string serviceName,
            string diagnosticId)
        {
            var diagnostic = Client.Diagnostic.Get(
                resourceGroupName,
                serviceName,
                diagnosticId);

            var result = Mapper.Map<PsApiManagementDiagnostic>(diagnostic);
            return result;
        }

        public PsApiManagementDiagnostic DiagnosticGetApiLevel(
            string resourceGroupName,
            string serviceName,
            string apiId,
            string diagnosticId)
        {
            var diagnostic = Client.ApiDiagnostic.Get(
                resourceGroupName,
                serviceName,
                apiId,
                diagnosticId);

            var result = Mapper.Map<PsApiManagementDiagnostic>(diagnostic);
            return result;
        }

        public void DiagnosticRemoveTenantLevel(
            string resourceGroupName,
            string serviceName,
            string diagnosticId)
        {
            Client.Diagnostic.Delete(
                resourceGroupName,
                serviceName,
                diagnosticId,
                "*");
        }

        public void DiagnosticRemoveApiLevel(
            string resourceGroupName,
            string serviceName,
            string apiId,
            string diagnosticId)
        {
            Client.ApiDiagnostic.Delete(
                resourceGroupName,
                serviceName,
                apiId,
                diagnosticId,
                "*");
        }
        #endregion

        #region Mapper Extensions
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

        static PsApiManagementRepresentation[] ToRepresentationContract(IList<RepresentationContract> parameters)
        {
            if (parameters == null || !parameters.Any())
            {
                return null;
            }

            var parameterList = new List<PsApiManagementRepresentation>();
            foreach (var parameter in parameters)
            {
                parameterList.Add(Mapper.Map<PsApiManagementRepresentation>(parameter));
            }

            return parameterList.ToArray();
        }

        static IDictionary<string, ParameterExampleContract> ToExampleContract(PsApiManagementParameterExample[] examples)
        {
            if (examples == null || !examples.Any())
            {
                return null;
            }

            var examplesList = new Dictionary<string, ParameterExampleContract>();

            foreach (var example in examples)
            {
                examplesList.Add("default", Mapper.Map<ParameterExampleContract>(example));
            }

            return examplesList;
        }

        static PsApiManagementParameterExample[] ToExampleContract(IDictionary<string, ParameterExampleContract> examples)
        {
            if (examples == null || !examples.Any())
            {
                return null;
            }

            var examplesList = new List<PsApiManagementParameterExample>();
            foreach (var example in examples)
            {
                examplesList.Add(Mapper.Map<PsApiManagementParameterExample>(example.Value));
            }

            return examplesList.ToArray();
        }
        #endregion

        #region Gateways
        public PsApiManagementGateway GatewayCreate(
            PsApiManagementContext context,
            string gatewayId,
            string description,
            PsApiManagementResourceLocation locationData)
        {
            var gatewayCreateParameters = new GatewayContract()
            {
                Description = description,
                LocationData = Mapper.Map<ResourceLocationDataContract>(locationData)
            };

            var gatewayContract = Client.Gateway.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, gatewayId, gatewayCreateParameters);

            var gateway = Mapper.Map<PsApiManagementGateway>(gatewayContract);

            return gateway;
        }

        public IList<PsApiManagementGateway> GatewaysList(PsApiManagementContext context)
        {
            var results = ListPagedAndMap<PsApiManagementGateway, GatewayContract>(
                () => Client.Gateway.ListByService(context.ResourceGroupName, context.ServiceName, null),
                nextLink => Client.Gateway.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementGateway GatewayById(string resourceGroupName, string serviceName, string gatewayId)
        {
            var response = Client.Gateway.Get(resourceGroupName, serviceName, gatewayId);
            var gateway = Mapper.Map<PsApiManagementGateway>(response);

            return gateway;
        }

        public void GatewayRemove(string resourceGroupName, string serviceName, string gatewayId)
        {
            Client.Gateway.Delete(resourceGroupName, serviceName, gatewayId, "*");
        }

        public void GatewaySet(
            string resourceGroupName,
            string serviceName,
            string gatewayId,
            string description,
            PsApiManagementResourceLocation locationData,
            PsApiManagementGateway gatewayObject)
        {
            GatewayContract gatewayUpdateParameters;

            if (gatewayObject == null)
            {
                gatewayUpdateParameters = new GatewayContract();
            }
            else
            {
                gatewayUpdateParameters = Mapper.Map<GatewayContract>(gatewayObject);
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                gatewayUpdateParameters.Description = description;
            }

            if (locationData != null)
            {
                gatewayUpdateParameters.LocationData = Mapper.Map<ResourceLocationDataContract>(locationData);
            }

            Client.Gateway.Update(
                resourceGroupName,
                serviceName,
                gatewayId,
                gatewayUpdateParameters,
                "*");
        }

        public void ApiAddToGateway(PsApiManagementContext context, string gatewayId, string apiId, PsApiManagementGatewayApiProvisioningState? provisioningState)
        {
            AssociationContract association = null;
            if (provisioningState != null)
            {
                association = new AssociationContract();
                association.ProvisioningState = Mapper.Map<ProvisioningState>(provisioningState);
            }

            Client.GatewayApi.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, gatewayId, apiId, association);
        }

        public IList<PsApiManagementApi> ApiByGatewayId(PsApiManagementContext context, string gatewayId)
        {
            var results = ListPagedAndMap<PsApiManagementApi, ApiContract>(
                () => Client.GatewayApi.ListByService(context.ResourceGroupName, context.ServiceName, gatewayId),
                nextLink => Client.GatewayApi.ListByServiceNext(nextLink));

            return results;
        }

        public void ApiRemoveFromGateway(PsApiManagementContext context, string gatewayId, string apiId)
        {
            Client.GatewayApi.Delete(context.ResourceGroupName, context.ServiceName, gatewayId, apiId);
        }

        public PsApiManagementGatewayKey GatewayKeyById(
                   string resourceGroupName,
                   string serviceName,
                   string gatewayId)
        {
            var response = Client.Gateway.ListKeys(
                resourceGroupName,
                serviceName,
                gatewayId);
            var keys = Mapper.Map<PsApiManagementGatewayKey>(response);

            return keys;
        }

        public IList<PsApiManagementGatewayHostnameConfiguration> GatewayHostnameConfigurationByGateway(
                           string resourceGroupName,
                           string serviceName,
                           string gatewayId)
        {
            var results = ListPagedAndMap<PsApiManagementGatewayHostnameConfiguration, GatewayHostnameConfigurationContract>(
                () => Client.GatewayHostnameConfiguration.ListByService(resourceGroupName, serviceName, gatewayId),
                nextLink => Client.GatewayHostnameConfiguration.ListByServiceNext(nextLink));

            return results;
        }

        public PsApiManagementGatewayHostnameConfiguration GatewayHostnameConfigurationById(
                           string resourceGroupName,
                           string serviceName,
                           string gatewayId,
                           string hostnameConfigurationId)
        {
            var response = Client.GatewayHostnameConfiguration.Get(
                resourceGroupName,
                serviceName,
                gatewayId,
                hostnameConfigurationId);
            var hostnameConfig = Mapper.Map<PsApiManagementGatewayHostnameConfiguration>(response);

            return hostnameConfig;
        }

        public PsApiManagementGatewayHostnameConfiguration GatewayHostnameConfigurationCreate(
                    PsApiManagementContext context,
                    string gatewayId,
                    string hostnameConfigurationId,
                    string hostname,
                    string certificateId,
                    bool? negotiateClientCertificate
                    )
        {
            var hostnameCreateParameters = new GatewayHostnameConfigurationContract()
            {
                Hostname = hostname,
                CertificateId = certificateId,
                NegotiateClientCertificate = negotiateClientCertificate
            };

            var hostnameContract = Client.GatewayHostnameConfiguration.CreateOrUpdate(context.ResourceGroupName, context.ServiceName, gatewayId, hostnameConfigurationId, hostnameCreateParameters);

            var config = Mapper.Map<PsApiManagementGatewayHostnameConfiguration>(hostnameContract);

            return config;
        }

        public void GatewayHostnameConfigurationRemove(string resourceGroupName, string serviceName, string gatewayId, string hostnameConfigurationId)
        {
            Client.GatewayHostnameConfiguration.Delete(resourceGroupName, serviceName, gatewayId, hostnameConfigurationId, "*");
        }
        #endregion

    }
}