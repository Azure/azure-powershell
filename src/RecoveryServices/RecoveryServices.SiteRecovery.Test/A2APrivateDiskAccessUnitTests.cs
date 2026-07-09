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
using System.Collections.Generic;
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

        // --- Utilities.CreateA2AVmManagedDiskInputDetails helper ---------------
        //
        // The helper centralises the ASRAzuretoAzureDiskReplicationConfig ->
        // A2AVmManagedDiskInputDetails mapping used by AddDisks, Reprotect
        // and ClusterReprotect. Tests below pin the contract so a future
        // refactor cannot silently drop any Private Disk Access field.

        private static ASRAzuretoAzureDiskReplicationConfig BuildAsrConfigWithPda(bool includeEncryption)
        {
            var cfg = new ASRAzuretoAzureDiskReplicationConfig
            {
                DiskId = "/subscriptions/sub-1/resourceGroups/src-rg/providers/Microsoft.Compute/disks/osdisk-1",
                RecoveryResourceGroupId = "/subscriptions/sub-1/resourceGroups/target-rg",
                LogStorageAccountId = "/subscriptions/sub-1/resourceGroups/staging-rg/providers/Microsoft.Storage/storageAccounts/staging",
                RecoveryReplicaDiskAccountType = "Premium_LRS",
                RecoveryTargetDiskAccountType = "Premium_LRS",
                RecoveryDiskEncryptionSetId = "/subscriptions/sub-1/resourceGroups/target-rg/providers/Microsoft.Compute/diskEncryptionSets/des-1",
                RecoveryNetworkAccessPolicy = "AllowPrivate",
                RecoveryDiskAccessId = "/subscriptions/sub-1/resourceGroups/net-rg/providers/Microsoft.Compute/diskAccesses/da-1",
                RecoveryPublicNetworkAccess = "Disabled",
            };
            if (includeEncryption)
            {
                cfg.DiskEncryptionSecretUrl = "https://kv.vault.azure.net/secrets/secret/abcdef";
                cfg.DiskEncryptionVaultId = "/subscriptions/sub-1/resourceGroups/kv-rg/providers/Microsoft.KeyVault/vaults/kv";
            }
            return cfg;
        }

        [Fact]
        public void Helper_WithoutEncryption_ForwardsAllPdaFieldsAndSkipsDiskEncryptionInfo()
        {
            var disk = BuildAsrConfigWithPda(includeEncryption: true);

            var sdk = Utilities.CreateA2AVmManagedDiskInputDetails(disk, includeDiskEncryption: false);

            Assert.Equal(disk.DiskId, sdk.DiskId);
            Assert.Equal(disk.RecoveryResourceGroupId, sdk.RecoveryResourceGroupId);
            Assert.Equal(disk.LogStorageAccountId, sdk.PrimaryStagingAzureStorageAccountId);
            Assert.Equal(disk.RecoveryReplicaDiskAccountType, sdk.RecoveryReplicaDiskAccountType);
            Assert.Equal(disk.RecoveryTargetDiskAccountType, sdk.RecoveryTargetDiskAccountType);
            Assert.Equal(disk.RecoveryDiskEncryptionSetId, sdk.RecoveryDiskEncryptionSetId);
            Assert.Equal("AllowPrivate", sdk.RecoveryNetworkAccessPolicy);
            Assert.Equal(disk.RecoveryDiskAccessId, sdk.RecoveryDiskAccessId);
            Assert.Equal("Disabled", sdk.RecoveryPublicNetworkAccess);
            // AddDisks does not surface encryption inputs, so DiskEncryptionInfo
            // must remain null even when the config carries encryption fields.
            Assert.Null(sdk.DiskEncryptionInfo);
        }

        [Fact]
        public void Helper_WithEncryption_ForwardsAllPdaFieldsAndPopulatesDiskEncryptionInfo()
        {
            var disk = BuildAsrConfigWithPda(includeEncryption: true);

            var sdk = Utilities.CreateA2AVmManagedDiskInputDetails(disk, includeDiskEncryption: true);

            Assert.Equal("AllowPrivate", sdk.RecoveryNetworkAccessPolicy);
            Assert.Equal(disk.RecoveryDiskAccessId, sdk.RecoveryDiskAccessId);
            Assert.Equal("Disabled", sdk.RecoveryPublicNetworkAccess);
            Assert.NotNull(sdk.DiskEncryptionInfo);
            Assert.Equal(disk.DiskEncryptionSecretUrl, sdk.DiskEncryptionInfo.DiskEncryptionKeyInfo.SecretIdentifier);
            Assert.Equal(disk.DiskEncryptionVaultId, sdk.DiskEncryptionInfo.DiskEncryptionKeyInfo.KeyVaultResourceArmId);
        }

        [Fact]
        public void Helper_WithNullPdaInputs_PropagatesNullsOnSdk()
        {
            // Backward-compat: when PDA fields are not supplied on the ASR
            // config, the SDK object must carry nulls (so the wire request
            // does not send empty strings or accidental defaults).
            var disk = new ASRAzuretoAzureDiskReplicationConfig
            {
                DiskId = "/subscriptions/sub-1/disks/osdisk-1",
                RecoveryResourceGroupId = "/subscriptions/sub-1/resourceGroups/target-rg",
            };

            var sdk = Utilities.CreateA2AVmManagedDiskInputDetails(disk, includeDiskEncryption: false);

            Assert.Null(sdk.RecoveryNetworkAccessPolicy);
            Assert.Null(sdk.RecoveryDiskAccessId);
            Assert.Null(sdk.RecoveryPublicNetworkAccess);
        }

        [Fact]
        public void Helper_WithNullDisk_ThrowsArgumentNullException()
        {
            // The shared helper is called from three cmdlets that iterate over
            // a user-supplied collection. A null element in that collection
            // must surface as a clear ArgumentNullException naming the "disk"
            // parameter, not a NullReferenceException from the first property
            // dereference inside the initializer.
            var ex = Assert.Throws<ArgumentNullException>(
                () => Utilities.CreateA2AVmManagedDiskInputDetails(null, includeDiskEncryption: false));
            Assert.Equal("disk", ex.ParamName);
        }

        // --- Per-cmdlet regression tests --------------------------------------
        //
        // The reviewer's concern is that a future edit to any one of the three
        // cmdlets could re-introduce an inline mapping that silently drops a
        // PDA field again. These tests invoke each cmdlet's private mapping
        // code with an input configuration that carries PDA values and assert
        // the outgoing SDK object retains them.

        [Fact]
        public void AddDisks_AzureToAzureReplication_ForwardsPdaFieldsOntoAddDisksInput()
        {
            var disk = BuildAsrConfigWithPda(includeEncryption: false);
            // AddDisks branches on IsManagedDisk to select the managed-disk
            // mapping path that this test targets; force it on explicitly.
            disk.IsManagedDisk = true;

            var cmdlet = new AddAzureRmRecoveryServicesAsrReplicationProtectedItemDisk
            {
                AzureToAzureDiskReplicationConfiguration = new[] { disk },
            };

            var input = new AddDisksInput
            {
                Properties = new AddDisksInputProperties
                {
                    ProviderSpecificDetails = new AddDisksProviderSpecificInput(),
                },
            };

            MethodInfo method = typeof(AddAzureRmRecoveryServicesAsrReplicationProtectedItemDisk)
                .GetMethod("AzureToAzureReplication",
                    BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);

            method.Invoke(cmdlet, new object[] { input });

            var providerSettings = Assert.IsType<A2AAddDisksInput>(input.Properties.ProviderSpecificDetails);
            var managed = Assert.Single(providerSettings.VMManagedDisks);
            Assert.Equal("AllowPrivate", managed.RecoveryNetworkAccessPolicy);
            Assert.Equal(disk.RecoveryDiskAccessId, managed.RecoveryDiskAccessId);
            Assert.Equal("Disabled", managed.RecoveryPublicNetworkAccess);
            // AddDisks path does not surface encryption inputs.
            Assert.Null(managed.DiskEncryptionInfo);
        }

        [Fact]
        public void Reprotect_PopulateManagedDiskInputDetails_ForwardsPdaFieldsOntoA2ASwitchInput()
        {
            var disk = BuildAsrConfigWithPda(includeEncryption: true);

            var cmdlet = new UpdateAzureRmRecoveryServicesAsrProtection
            {
                AzureToAzureDiskReplicationConfiguration = new[] { disk },
            };

            var a2aSwitchInput = new A2ASwitchProtectionInput
            {
                VMDisks = new List<A2AVmDiskInputDetails>(),
                VMManagedDisks = new List<A2AVmManagedDiskInputDetails>(),
            };

            MethodInfo method = typeof(UpdateAzureRmRecoveryServicesAsrProtection)
                .GetMethod("populateManagedDiskInputDetails",
                    BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);

            // With AzureToAzureDiskReplicationConfiguration supplied the "else"
            // branch runs and does not touch the second parameter, so passing
            // null is safe.
            method.Invoke(cmdlet, new object[] { a2aSwitchInput, null });

            var managed = Assert.Single(a2aSwitchInput.VMManagedDisks);
            Assert.Equal("AllowPrivate", managed.RecoveryNetworkAccessPolicy);
            Assert.Equal(disk.RecoveryDiskAccessId, managed.RecoveryDiskAccessId);
            Assert.Equal("Disabled", managed.RecoveryPublicNetworkAccess);
            Assert.NotNull(managed.DiskEncryptionInfo);
        }

        [Fact]
        public void ClusterReprotect_A2ARPCReprotect_DelegatesDiskMappingToSharedHelper()
        {
            // The cluster-reprotect mapping is embedded inside the large
            // A2ARPCReprotect orchestration method and is impractical to
            // invoke in isolation. Two complementary checks give strong
            // regression coverage without invoking the orchestration:
            //
            //   1. Structural (compiled IL) — the containing type must call
            //      Utilities.CreateA2AVmManagedDiskInputDetails somewhere. A
            //      refactor that reverts the cluster site to an inline
            //      mapping (silently dropping a PDA field) will fail this
            //      check because only three call sites are expected across
            //      the whole assembly and removing one drops the count.
            //   2. Semantic (source) — when the source tree is co-located
            //      with the test binaries (as in a CI checkout), also
            //      inspect the source to confirm the call sits inside the
            //      cluster's per-item disk-config loop.
            //
            // The two together make it structurally hard to regress this
            // path silently.

            AssertHelperIsCalledAtLeastThreeTimesInAssembly();
            TryAssertClusterSourceCallsHelper();
        }

        private static void AssertHelperIsCalledAtLeastThreeTimesInAssembly()
        {
            MethodInfo helper = typeof(Utilities).GetMethod(
                nameof(Utilities.CreateA2AVmManagedDiskInputDetails),
                BindingFlags.Public | BindingFlags.Static);
            Assert.NotNull(helper);

            Assembly siteRecoveryAssembly = typeof(Utilities).Assembly;

            int callSiteCount = 0;
            var callersDetected = new List<string>();

            foreach (Type type in siteRecoveryAssembly.GetTypes())
            {
                MethodInfo[] methods;
                try
                {
                    methods = type.GetMethods(
                        BindingFlags.Public | BindingFlags.NonPublic |
                        BindingFlags.Instance | BindingFlags.Static |
                        BindingFlags.DeclaredOnly);
                }
                catch
                {
                    continue;
                }

                foreach (MethodInfo m in methods)
                {
                    if (MethodCallsHelperViaIL(m, helper))
                    {
                        callSiteCount++;
                        callersDetected.Add($"{type.FullName}.{m.Name}");
                    }
                }
            }

            Assert.True(callSiteCount >= 3,
                $"Utilities.CreateA2AVmManagedDiskInputDetails is expected to be called from at " +
                $"least three sites (AddDisks, Reprotect, ClusterReprotect) — found {callSiteCount}. " +
                $"Callers detected: {string.Join(", ", callersDetected)}. A missing call likely " +
                $"means a cmdlet regressed to an inline A2AVmManagedDiskInputDetails initializer " +
                $"and may be silently dropping a Private Disk Access field; restore the shared " +
                $"helper call in the affected cmdlet.");
        }

        private static bool MethodCallsHelperViaIL(MethodInfo method, MethodInfo helper)
        {
            MethodBody body;
            try
            {
                body = method.GetMethodBody();
            }
            catch
            {
                return false;
            }
            if (body == null)
            {
                return false;
            }
            byte[] il = body.GetILAsByteArray();
            if (il == null || il.Length < 5)
            {
                return false;
            }
            Module module = method.Module;
            Type[] gt = method.DeclaringType != null && method.DeclaringType.IsGenericType
                ? method.DeclaringType.GetGenericArguments() : null;
            Type[] gm = method.IsGenericMethod
                ? method.GetGenericArguments() : null;

            const byte OpCodeCall = 0x28;
            const byte OpCodeCallvirt = 0x6F;

            for (int i = 0; i <= il.Length - 5; i++)
            {
                if (il[i] != OpCodeCall && il[i] != OpCodeCallvirt)
                {
                    continue;
                }
                int token = BitConverter.ToInt32(il, i + 1);
                try
                {
                    MethodBase resolved = module.ResolveMethod(token, gt, gm);
                    if (resolved != null &&
                        resolved.DeclaringType == helper.DeclaringType &&
                        resolved.Name == helper.Name)
                    {
                        return true;
                    }
                }
                catch
                {
                    // Not every 4-byte payload after 0x28/0x6F is a metadata
                    // token — most are operands of other opcodes. Skip.
                }
            }
            return false;
        }

        private static void TryAssertClusterSourceCallsHelper()
        {
            // Locate the source file relative to the test assembly. When the
            // assembly is executed outside a source checkout (e.g. a shipped
            // NuGet), skip this half of the check silently — the IL-level
            // assertion above still provides regression coverage.
            string sourcePath = TryLocateRepoFile(
                "src", "RecoveryServices", "RecoveryServices.SiteRecovery",
                "ProtectionCluster",
                "UpdateAzureRmRecoveryServicesAsrClusterProtectionDirection.cs");
            if (sourcePath == null)
            {
                return;
            }

            string source = System.IO.File.ReadAllText(sourcePath);

            int loopIdx = source.IndexOf(
                "foreach (ASRAzuretoAzureDiskReplicationConfig disk in rpi.AzureToAzureDiskReplicationConfiguration)",
                StringComparison.Ordinal);
            Assert.True(loopIdx >= 0,
                "Could not locate the per-item disk-config foreach loop in ClusterProtection " +
                "source — the source layout has changed. Review this test and adjust the anchor.");

            // Look at the ~1 KB window immediately following the loop header.
            int windowEnd = Math.Min(source.Length, loopIdx + 1024);
            string window = source.Substring(loopIdx, windowEnd - loopIdx);

            Assert.Contains("Utilities.CreateA2AVmManagedDiskInputDetails", window);
        }

        private static string TryLocateRepoFile(params string[] relativeSegments)
        {
            string current = System.IO.Path.GetDirectoryName(
                typeof(A2APrivateDiskAccessUnitTests).Assembly.Location);
            for (int depth = 0; depth < 10 && current != null; depth++)
            {
                string candidate = System.IO.Path.Combine(
                    new[] { current }.Concat(relativeSegments).ToArray());
                if (System.IO.File.Exists(candidate))
                {
                    return candidate;
                }
                current = System.IO.Path.GetDirectoryName(current);
            }
            return null;
        }
    }
}
