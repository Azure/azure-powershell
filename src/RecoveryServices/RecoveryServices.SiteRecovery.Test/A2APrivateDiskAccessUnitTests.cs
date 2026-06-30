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

using System.Linq;
using System.Management.Automation;
using System.Reflection;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Xunit;

// Disambiguate: there are multiple `Constants` types in scope through
// transitive usings; pin to the SiteRecovery PS-constants class.
using SrsConstants = Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Constants;

namespace RecoveryServices.SiteRecovery.Test
{
    /// <summary>
    /// Pure in-process unit tests covering the A2A Private Disk Access surface
    /// added in API version 2026-02-01.
    ///
    /// These tests do not require a recorded HTTP cassette or live Azure
    /// credentials and are safe to run on every CI build. They pin the
    /// behavioural contract of the three new properties exposed by:
    ///   * <see cref="ASRAzuretoAzureDiskReplicationConfig"/> (input PS object)
    ///   * <see cref="ASRAzureToAzureProtectedDiskDetails"/>  (output PS object)
    ///   * <see cref="AzureRmAsrAzureToAzureDiskReplicationConfig"/> (cmdlet
    ///     parameter binding via <c>[Parameter]</c> and <c>[ValidateSet]</c>)
    ///   * <see cref="Constants"/> (string-constant values consumed by the
    ///     <c>[ValidateSet]</c> attribute).
    /// </summary>
    public class A2APrivateDiskAccessUnitTests
    {
        // --- Constants in PSConstants.cs ----------------------------------------

        [Fact]
        public void Constants_AllowAll_HasExpectedValue()
        {
            Assert.Equal("AllowAll", SrsConstants.AllowAll);
        }

        [Fact]
        public void Constants_AllowPrivate_HasExpectedValue()
        {
            Assert.Equal("AllowPrivate", SrsConstants.AllowPrivate);
        }

        [Fact]
        public void Constants_DenyAll_HasExpectedValue()
        {
            Assert.Equal("DenyAll", SrsConstants.DenyAll);
        }

        // --- ASRAzureToAzureProtectedDiskDetails constructor copy ---------------

        [Fact]
        public void ProtectedDiskDetails_ManagedCtor_CopiesAllThreeNewFields()
        {
            var sdk = new A2AProtectedManagedDiskDetails
            {
                DiskId = "disk-id",
                RecoveryNetworkAccessPolicy = "AllowPrivate",
                RecoveryDiskAccessId = "/subscriptions/sub-1/resourceGroups/rg/providers/Microsoft.Compute/diskAccesses/da-1",
                RecoveryPublicNetworkAccess = "Disabled",
            };

            var ps = new ASRAzureToAzureProtectedDiskDetails(sdk);

            Assert.Equal("AllowPrivate", ps.RecoveryNetworkAccessPolicy);
            Assert.Equal(sdk.RecoveryDiskAccessId, ps.RecoveryDiskAccessId);
            Assert.Equal("Disabled", ps.RecoveryPublicNetworkAccess);
            Assert.True(ps.Managed);
        }

        [Fact]
        public void ProtectedDiskDetails_ManagedCtor_NullSourceFieldsPropagateAsNull()
        {
            var sdk = new A2AProtectedManagedDiskDetails
            {
                DiskId = "disk-id",
                // All three new fields left null — backward-compat read-back path.
            };

            var ps = new ASRAzureToAzureProtectedDiskDetails(sdk);

            Assert.Null(ps.RecoveryNetworkAccessPolicy);
            Assert.Null(ps.RecoveryDiskAccessId);
            Assert.Null(ps.RecoveryPublicNetworkAccess);
        }

        [Fact]
        public void ProtectedDiskDetails_UnmanagedCtor_DoesNotTouchTheThreeNewFields()
        {
            // The three new properties only apply to managed disks; the
            // unmanaged-disk constructor must leave them at their default
            // (null) so that read-back of pre-existing unmanaged disks is
            // not affected by this PR.
            var sdk = new A2AProtectedDiskDetails
            {
                DiskUri = "https://example/disk.vhd",
            };

            var ps = new ASRAzureToAzureProtectedDiskDetails(sdk);

            Assert.False(ps.Managed);
            Assert.Null(ps.RecoveryNetworkAccessPolicy);
            Assert.Null(ps.RecoveryDiskAccessId);
            Assert.Null(ps.RecoveryPublicNetworkAccess);
        }

        // --- ASRAzuretoAzureDiskReplicationConfig (input PS object) ------------

        [Fact]
        public void ReplicationConfig_NewProperties_RoundTrip()
        {
            var cfg = new ASRAzuretoAzureDiskReplicationConfig
            {
                RecoveryNetworkAccessPolicy = "AllowPrivate",
                RecoveryDiskAccessId = "/subscriptions/sub-1/resourceGroups/rg/providers/Microsoft.Compute/diskAccesses/da-1",
                RecoveryPublicNetworkAccess = "Disabled",
            };

            Assert.Equal("AllowPrivate", cfg.RecoveryNetworkAccessPolicy);
            Assert.Equal("/subscriptions/sub-1/resourceGroups/rg/providers/Microsoft.Compute/diskAccesses/da-1", cfg.RecoveryDiskAccessId);
            Assert.Equal("Disabled", cfg.RecoveryPublicNetworkAccess);
        }

        [Fact]
        public void ReplicationConfig_NewProperties_DefaultsAreNull()
        {
            // Backward-compat: callers that don't set the new properties must
            // see nulls (so the enable-protection wire-up doesn't accidentally
            // send empty strings to the service).
            var cfg = new ASRAzuretoAzureDiskReplicationConfig();

            Assert.Null(cfg.RecoveryNetworkAccessPolicy);
            Assert.Null(cfg.RecoveryDiskAccessId);
            Assert.Null(cfg.RecoveryPublicNetworkAccess);
        }

        // --- AzureRmAsrAzureToAzureDiskReplicationConfig cmdlet attributes -----

        [Theory]
        [InlineData(nameof(AzureRmAsrAzureToAzureDiskReplicationConfig.RecoveryNetworkAccessPolicy))]
        [InlineData(nameof(AzureRmAsrAzureToAzureDiskReplicationConfig.RecoveryDiskAccessId))]
        [InlineData(nameof(AzureRmAsrAzureToAzureDiskReplicationConfig.RecoveryPublicNetworkAccess))]
        public void Cmdlet_NewParameters_AreOptionalAndInManagedDiskSet(string propertyName)
        {
            PropertyInfo property = typeof(AzureRmAsrAzureToAzureDiskReplicationConfig)
                .GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            Assert.NotNull(property);

            ParameterAttribute parameter = property
                .GetCustomAttributes<ParameterAttribute>(inherit: false)
                .SingleOrDefault();
            Assert.NotNull(parameter);

            Assert.Equal("AzureToAzureManagedDisk", parameter.ParameterSetName);
            Assert.False(parameter.Mandatory,
                $"{propertyName} must remain optional to preserve backward compatibility.");
        }

        [Fact]
        public void Cmdlet_RecoveryNetworkAccessPolicy_HasValidateSet_AllowAllAllowPrivateDenyAll()
        {
            PropertyInfo property = typeof(AzureRmAsrAzureToAzureDiskReplicationConfig)
                .GetProperty(nameof(AzureRmAsrAzureToAzureDiskReplicationConfig.RecoveryNetworkAccessPolicy));
            Assert.NotNull(property);

            ValidateSetAttribute validateSet = property
                .GetCustomAttributes<ValidateSetAttribute>(inherit: false)
                .SingleOrDefault();
            Assert.NotNull(validateSet);

            string[] valid = validateSet.ValidValues.OrderBy(v => v).ToArray();
            Assert.Equal(new[] { "AllowAll", "AllowPrivate", "DenyAll" }, valid);
        }

        [Fact]
        public void Cmdlet_RecoveryPublicNetworkAccess_HasValidateSet_EnabledDisabled()
        {
            PropertyInfo property = typeof(AzureRmAsrAzureToAzureDiskReplicationConfig)
                .GetProperty(nameof(AzureRmAsrAzureToAzureDiskReplicationConfig.RecoveryPublicNetworkAccess));
            Assert.NotNull(property);

            ValidateSetAttribute validateSet = property
                .GetCustomAttributes<ValidateSetAttribute>(inherit: false)
                .SingleOrDefault();
            Assert.NotNull(validateSet);

            string[] valid = validateSet.ValidValues.OrderBy(v => v).ToArray();
            Assert.Equal(new[] { "Disabled", "Enabled" }, valid);
        }

        [Fact]
        public void Cmdlet_RecoveryDiskAccessId_HasNoValidateSet_ButHasValidateNotNullOrEmpty()
        {
            // RecoveryDiskAccessId is an ARM resource id — free-form string,
            // so it should be guarded by [ValidateNotNullOrEmpty] but NOT
            // by [ValidateSet] (regression guard: a future refactor must
            // not accidentally narrow this to a closed list).
            PropertyInfo property = typeof(AzureRmAsrAzureToAzureDiskReplicationConfig)
                .GetProperty(nameof(AzureRmAsrAzureToAzureDiskReplicationConfig.RecoveryDiskAccessId));
            Assert.NotNull(property);

            Assert.Empty(property.GetCustomAttributes<ValidateSetAttribute>(inherit: false));
            Assert.NotEmpty(property.GetCustomAttributes<ValidateNotNullOrEmptyAttribute>(inherit: false));
        }
    }
}
