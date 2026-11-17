// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License").

extern alias BackupSdk;
extern alias CrrSdk;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.RecoveryServices.Backup.Cmdlets.ServiceClientAdapterNS;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Newtonsoft.Json;
using Xunit;
using Sdk = BackupSdk::Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using CrrModels = CrrSdk::Microsoft.Azure.Management.RecoveryServices.Backup.CrossRegionRestore.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.Backup.Test.UnitTests
{
    public class QueryBuilderTests
    {
        public static IEnumerable<object[]> ServiceQueryProperties()
        {
            foreach (Type type in new[]
            {
                typeof(Sdk.BmsrpQueryObject), typeof(CrrModels.BmsrpQueryObject),
                typeof(Sdk.JobQueryObject), typeof(CrrModels.JobQueryObject)
            })
            {
                foreach (var property in type.GetProperties())
                {
                    yield return new object[] { type, property.Name };
                }
            }
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [MemberData(nameof(ServiceQueryProperties))]
        public void ServiceQueriesUseExactSerializedNames(Type type, string propertyName)
        {
            var query = Activator.CreateInstance(type);
            var property = type.GetProperty(propertyName);
            Type valueType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            object value = valueType == typeof(DateTime) ? (object)new DateTime(2026, 10, 23, 8, 0, 0, DateTimeKind.Utc)
                : valueType == typeof(bool) ? (object)true : "test-value";
            property.SetValue(query, value);
            string name = property.GetCustomAttributes(typeof(JsonPropertyAttribute), false)
                .Cast<JsonPropertyAttribute>().Single().PropertyName;

            string filter = QueryBuilder.Instance.GetQueryString(query);

            Assert.StartsWith(name + " eq '", filter);
            Assert.DoesNotContain(" and ", filter);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UnannotatedQueriesRetainCamelCaseAndOmitNulls()
        {
            string filter = QueryBuilder.Instance.GetQueryString(new PlainQuery { BackupManagementType = "AzureWorkload" });

            Assert.Equal("backupManagementType eq 'AzureWorkload'", filter);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void JobQueryFormattingIsUnchanged()
        {
            var query = new Sdk.JobQueryObject
            {
                Status = "Completed", BackupManagementType = "AzureWorkload", Operation = "Backup",
                JobId = "job-id", StartTime = new DateTime(2026, 10, 23, 8, 0, 0, DateTimeKind.Utc),
                EndTime = new DateTime(2026, 10, 23, 9, 0, 0, DateTimeKind.Utc)
            };

            Assert.Equal("status eq 'Completed' and backupManagementType eq 'AzureWorkload' and operation eq 'Backup'" +
                " and jobId eq 'job-id' and startTime eq '2026-10-23 08:00:00 AM' and endTime eq '2026-10-23 09:00:00 AM'",
                QueryBuilder.Instance.GetQueryString(query));
        }

        private class PlainQuery
        {
            public string BackupManagementType { get; set; }
            public string MissingValue { get; set; }
        }
    }
}
