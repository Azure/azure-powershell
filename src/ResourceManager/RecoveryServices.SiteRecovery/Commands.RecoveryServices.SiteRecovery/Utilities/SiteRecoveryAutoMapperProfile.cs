// ----------------------------------------------------------------------------------
// 
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    public static class SiteRecoveryMapperExtension
    {
        public static IMappingExpression<TSource, TDestination> ForItems<TSource, TDestination, T>(
            this IMappingExpression<TSource, TDestination> mapper) where TSource : IEnumerable
            where TDestination : ICollection<T>
        {
            mapper.AfterMap(
                (
                    c,
                    s) =>
                {
                    if ((c != null) &&
                        (s != null))
                    {
                        foreach (var t in c)
                        {
                            s.Add(Mapper.Map<T>(t));
                        }
                    }
                });

            return mapper;
        }
    }

    public class SiteRecoveryAutoMapperProfile : AutoMapper.Profile
    {
        private static readonly Lazy<bool> initialize;

        static SiteRecoveryAutoMapperProfile()
        {
            initialize = new Lazy<bool>(
                () =>
                {
                    Mapper.AddProfile<SiteRecoveryAutoMapperProfile>();
                    return true;
                });
        }

        public override string ProfileName => "SiteRecoveryAutoMapperProfile";

        public static bool Initialize()
        {
            return initialize.Value;
        }

        protected override void Configure()
        {
            var mappingExpression = Mapper
                .CreateMap<Rest.Azure.AzureOperationResponse, PSSiteRecoveryLongRunningOperation>();

            mappingExpression.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionFabric = Mapper
                .CreateMap<AzureOperationResponse<Fabric>, PSSiteRecoveryLongRunningOperation>();

            mappingExpressionFabric.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionPolicy = Mapper
                .CreateMap<AzureOperationResponse<Policy>, PSSiteRecoveryLongRunningOperation>();

            mappingExpressionPolicy.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionProtectionContainer = Mapper
                .CreateMap<AzureOperationResponse<ProtectionContainer>,
                    PSSiteRecoveryLongRunningOperation>();

            mappingExpressionProtectionContainer.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionProtectableItem = Mapper
                .CreateMap<AzureOperationResponse<ProtectableItem>,
                    PSSiteRecoveryLongRunningOperation>();

            mappingExpressionProtectableItem.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionReplicationProtectedItem = Mapper
                .CreateMap<AzureOperationResponse<ReplicationProtectedItem>,
                    PSSiteRecoveryLongRunningOperation>();

            mappingExpressionReplicationProtectedItem.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionRecoveryPlan = Mapper
                .CreateMap<AzureOperationResponse<RecoveryPlan>, PSSiteRecoveryLongRunningOperation
                >();

            mappingExpressionRecoveryPlan.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionJob = Mapper
                .CreateMap<AzureOperationResponse<Job>, PSSiteRecoveryLongRunningOperation>();

            mappingExpressionJob.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionProtectionContainerMapping = Mapper
                .CreateMap<AzureOperationResponse<ProtectionContainerMapping>,
                    PSSiteRecoveryLongRunningOperation>();

            mappingExpressionProtectionContainerMapping.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionProtectionNetworkMapping = Mapper
                .CreateMap<AzureOperationResponse<NetworkMapping>,
                    PSSiteRecoveryLongRunningOperation>();

            mappingExpressionProtectionNetworkMapping.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionProtectionStorageClassification = Mapper
                .CreateMap<AzureOperationResponse<StorageClassification>,
                    PSSiteRecoveryLongRunningOperation>();

            mappingExpressionProtectionStorageClassification.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));

            var mappingExpressionProtectionStorageClassificationMapping = Mapper
                .CreateMap<AzureOperationResponse<StorageClassificationMapping>,
                    PSSiteRecoveryLongRunningOperation>();

            mappingExpressionProtectionStorageClassificationMapping.ForMember(
                    c => c.Location,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Location") ? r.Response.Headers
                            .GetValues("Location")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.Status,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .Status))
                .ForMember(
                    c => c.CorrelationRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-correlation-request-id") ? r.Response
                            .Headers.GetValues("x-ms-correlation-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ClientRequestId,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("x-ms-request-id") ? r.Response.Headers
                            .GetValues("x-ms-request-id")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.ContentType,
                    o => o.MapFrom(
                        r => JsonConvert.DeserializeObject<PSSiteRecoveryLongRunningOperation>(
                                r.Response.Content.ReadAsStringAsync()
                                    .Result)
                            .ContentType))
                .ForMember(
                    c => c.RetryAfter,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Retry-After") ? r.Response.Headers
                            .GetValues("Retry-After")
                            .FirstOrDefault() : null))
                .ForMember(
                    c => c.Date,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Date") ? r.Response.Headers
                            .GetValues("Date")
                            .FirstOrDefault() : ""))
                .ForMember(
                    c => c.AsyncOperation,
                    o => o.MapFrom(
                        r => r.Response.Headers.Contains("Azure-AsyncOperation") ? r.Response
                            .Headers.GetValues("Azure-AsyncOperation")
                            .FirstOrDefault() : ""));
        }
    }
}