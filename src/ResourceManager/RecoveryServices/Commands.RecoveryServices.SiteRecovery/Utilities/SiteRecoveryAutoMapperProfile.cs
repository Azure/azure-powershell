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
                        Initialize();
                    }

                    return _mapper;
                }
            }
        }

        public override string ProfileName => "SiteRecoveryAutoMapperProfile";

        private static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                var mappingExpression = cfg
                .CreateMap<Rest.Azure.AzureOperationResponse, PSSiteRecoveryLongRunningOperation>();

                mappingExpression.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionFabric = cfg
                    .CreateMap<AzureOperationResponse<Fabric>, PSSiteRecoveryLongRunningOperation>();

                mappingExpressionFabric.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionPolicy = cfg
                    .CreateMap<AzureOperationResponse<Policy>, PSSiteRecoveryLongRunningOperation>();

                mappingExpressionPolicy.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionProtectionContainer = cfg
                    .CreateMap<AzureOperationResponse<ProtectionContainer>,
                        PSSiteRecoveryLongRunningOperation>();

                mappingExpressionProtectionContainer.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionProtectableItem = cfg
                    .CreateMap<AzureOperationResponse<ProtectableItem>,
                        PSSiteRecoveryLongRunningOperation>();

                mappingExpressionProtectableItem.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionReplicationProtectedItem = cfg
                    .CreateMap<AzureOperationResponse<ReplicationProtectedItem>,
                        PSSiteRecoveryLongRunningOperation>();

                mappingExpressionReplicationProtectedItem.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionRecoveryPlan = cfg
                    .CreateMap<AzureOperationResponse<RecoveryPlan>, PSSiteRecoveryLongRunningOperation
                    >();

                mappingExpressionRecoveryPlan.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionJob = cfg
                    .CreateMap<AzureOperationResponse<Job>, PSSiteRecoveryLongRunningOperation>();

                mappingExpressionJob.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionProtectionContainerMapping = cfg
                    .CreateMap<AzureOperationResponse<ProtectionContainerMapping>,
                        PSSiteRecoveryLongRunningOperation>();

                mappingExpressionProtectionContainerMapping.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionProtectionNetworkMapping = cfg
                    .CreateMap<AzureOperationResponse<NetworkMapping>,
                        PSSiteRecoveryLongRunningOperation>();

                mappingExpressionProtectionNetworkMapping.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionProtectionStorageClassification = cfg
                    .CreateMap<AzureOperationResponse<StorageClassification>,
                        PSSiteRecoveryLongRunningOperation>();

                mappingExpressionProtectionStorageClassification.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionProtectionStorageClassificationMapping = cfg
                    .CreateMap<AzureOperationResponse<StorageClassificationMapping>,
                        PSSiteRecoveryLongRunningOperation>();

                mappingExpressionProtectionStorageClassificationMapping.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingExpressionvCenter = cfg
                    .CreateMap<AzureOperationResponse<VCenter>,
                        PSSiteRecoveryLongRunningOperation>();

                mappingExpressionvCenter.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingAzureSiteRecoveryAlert = cfg
                    .CreateMap<AzureOperationResponse<Alert>,
                        PSSiteRecoveryLongRunningOperation>();
                mappingAzureSiteRecoveryAlert.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));

                var mappingRecoveryServiceProvider = cfg
                   .CreateMap<AzureOperationResponse<RecoveryServicesProvider>,
                       PSSiteRecoveryLongRunningOperation>();
                mappingRecoveryServiceProvider.ForMember(
                        c => c.Location,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Location")
                                ? r.Response.Headers
                                    .GetValues("Location")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("x-ms-correlation-request-id")
                                ? r.Response
                                    .Headers.GetValues("x-ms-correlation-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.ClientRequestId,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("x-ms-request-id")
                                ? r.Response.Headers
                                    .GetValues("x-ms-request-id")
                                    .FirstOrDefault()
                                : string.Empty))
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
                            r => r.Response.Headers.Contains("Retry-After")
                                ? r.Response.Headers
                                    .GetValues("Retry-After")
                                    .FirstOrDefault()
                                : null))
                    .ForMember(
                        c => c.Date,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Date")
                                ? r.Response.Headers
                                    .GetValues("Date")
                                    .FirstOrDefault()
                                : string.Empty))
                    .ForMember(
                        c => c.AsyncOperation,
                        o => o.MapFrom(
                            r => r.Response.Headers.Contains("Azure-AsyncOperation")
                                ? r.Response
                                    .Headers.GetValues("Azure-AsyncOperation")
                                    .FirstOrDefault()
                                : string.Empty));
            });

            _mapper = config.CreateMapper();
        }
    }
}
