using System;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Net.Http;
using System.Threading;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Compute.Automation;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Moq;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class SnapshotImmutabilityPolicyTests
    {
        public SnapshotImmutabilityPolicyTests()
        {
            AzureSessionInitializer.InitializeAzureSession();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SnapshotPolicyMappingPreservesNullableAndFutureValues()
        {
            DateTime start = new DateTime(2026, 10, 1, 12, 0, 0, DateTimeKind.Utc);
            var policy = new ImmutabilityPolicy(14, "FuturePolicyType", start, null, null);
            var snapshot = new Snapshot("eastus", immutabilityPolicy: policy);

            PSSnapshot output = ComputeAutomationAutoMapperProfile.Mapper.Map<PSSnapshot>(snapshot);
            PSSnapshotList listOutput = ComputeAutomationAutoMapperProfile.Mapper.Map<PSSnapshotList>(snapshot);

            Assert.IsType<PSSnapshotImmutabilityPolicy>(output.ImmutabilityPolicy);
            Assert.Equal(14, output.ImmutabilityPolicy.ImmutabilityDurationDays);
            Assert.Equal("FuturePolicyType", output.ImmutabilityPolicy.Type);
            Assert.Equal(start, output.ImmutabilityPolicy.PolicyStartTime);
            Assert.Null(output.ImmutabilityPolicy.PolicyExpirationTime);
            Assert.Null(output.ImmutabilityPolicy.IsPolicyExpired);
            Assert.Equal("FuturePolicyType", listOutput.ImmutabilityPolicy.Type);
            Assert.Null(ComputeAutomationAutoMapperProfile.Mapper.Map<PSSnapshot>(new Snapshot("eastus")).ImmutabilityPolicy);
            Assert.Null(ComputeAutomationAutoMapperProfile.Mapper.Map<PSSnapshotList>(new Snapshot("eastus")).ImmutabilityPolicy);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SnapshotPolicyIsNotMappedToWritableSnapshotInput()
        {
            var input = new PSSnapshot
            {
                Location = "eastus",
                ImmutabilityPolicy = new PSSnapshotImmutabilityPolicy
                {
                    ImmutabilityDurationDays = 10,
                    Type = "Locked",
                    IsPolicyExpired = false
                }
            };

            Snapshot mapped = ComputeAutomationAutoMapperProfile.Mapper.Map<Snapshot>(input);

            Assert.Null(mapped.ImmutabilityPolicy);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PolicyMutationCommandsUseThreeSeparateIdentitySets()
        {
            foreach (Type cmdletType in new[] { typeof(SetAzSnapshotImmutabilityPolicy), typeof(RemoveAzSnapshotImmutabilityPolicy) })
            {
                Assert.Equal("DefaultParameterSet", GetParameter(cmdletType, "Name").ParameterSetName);
                Assert.Equal("DefaultParameterSet", GetParameter(cmdletType, "ResourceGroupName").ParameterSetName);
                Assert.Equal("InputObjectParameterSet", GetParameter(cmdletType, "InputObject").ParameterSetName);
                Assert.Equal("ResourceIdParameterSet", GetParameter(cmdletType, "ResourceId").ParameterSetName);
                var input = GetParameter(cmdletType, "InputObject");
                var id = GetParameter(cmdletType, "ResourceId");
                Assert.True(input.ValueFromPipeline);
                Assert.False(id.ValueFromPipeline);
                Assert.True(id.ValueFromPipelineByPropertyName);
                Assert.False(GetParameter(cmdletType, "Name").ValueFromPipelineByPropertyName);
                Assert.False(GetParameter(cmdletType, "ResourceGroupName").ValueFromPipelineByPropertyName);
            }
        }

        [Theory]
        [InlineData("ResourceIdParameterSet")]
        [InlineData("InputObjectParameterSet")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void IdentityInputsUseFreshServiceState(string parameterSet)
        {
            DateTime start = DateTime.UtcNow.AddHours(-1);
            var harness = new PolicyHarness(Policy("Unlocked", 14, start), Policy("Unlocked", 7, start));
            var cmdlet = harness.Set("Unlocked", 7);
            string id = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Compute/snapshots/snapshot";
            cmdlet.Name = null;
            cmdlet.ResourceGroupName = null;
            if (parameterSet == "ResourceIdParameterSet")
            {
                cmdlet.ResourceId = id;
            }
            else
            {
                cmdlet.InputObject = new PSSnapshot
                {
                    Id = id,
                    ImmutabilityPolicy = new PSSnapshotImmutabilityPolicy { Type = "Locked", ImmutabilityDurationDays = 90 }
                };
            }
            cmdlet.SetParameterSet(parameterSet);

            cmdlet.ExecuteCmdlet();

            harness.VerifyMutation("Unlocked", 7);
            harness.VerifyOutput(7, false);
        }

        [Theory]
        [InlineData("/subscriptions/other/resourceGroups/rg/providers/Microsoft.Compute/snapshots/snapshot")]
        [InlineData("/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Compute/disks/snapshot")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void InvalidResourceIdentityDoesNotCallService(string resourceId)
        {
            var harness = new PolicyHarness(null, null);
            var cmdlet = harness.Set("Unlocked", 7);
            cmdlet.ResourceId = resourceId;
            cmdlet.SetParameterSet("ResourceIdParameterSet");

            Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());

            Assert.Empty(harness.Operations.Invocations);
        }

        [Theory]
        [InlineData(false, "Microsoft.Compute/snapshots", "00000000-0000-0000-0000-000000000001", true)]
        [InlineData(true, "Microsoft.Compute/snapshots", "00000000-0000-0000-0000-000000000001", true)]
        [InlineData(false, "Microsoft.Compute/snapshots", "other", false)]
        [InlineData(true, "Microsoft.Compute/snapshots", "other", false)]
        [InlineData(false, "Microsoft.Compute/disks", "00000000-0000-0000-0000-000000000001", false)]
        [InlineData(true, "Microsoft.Compute/disks", "00000000-0000-0000-0000-000000000001", false)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GenericResourcePipelineUsesValidatedIdentity(bool remove, string resourceType, string subscription, bool valid)
        {
            var resource = new GenericResource
            {
                Name = "snapshot",
                ResourceGroupName = "rg",
                ResourceId = $"/subscriptions/{subscription}/resourceGroups/rg/providers/{resourceType}/snapshot"
            };
            var state = InitialSessionState.CreateDefault();
            state.Commands.Add(new SessionStateCmdletEntry("Test-Policy",
                remove ? typeof(PipelineRemovePolicy) : typeof(PipelineSetPolicy), null));

            using (var runspace = RunspaceFactory.CreateRunspace(state))
            using (var powershell = System.Management.Automation.PowerShell.Create())
            {
                runspace.Open();
                powershell.Runspace = runspace;
                powershell.AddCommand("Test-Policy");
                if (!remove)
                {
                    powershell.AddParameter("PolicyType", "Unlocked").AddParameter("DurationInDays", 7);
                }
                if (valid)
                {
                    var output = powershell.Invoke(new[] { resource });
                    Assert.Empty(powershell.Streams.Error);
                    Assert.Equal("ResourceIdParameterSet:rg:snapshot", Assert.Single(output).BaseObject);
                }
                else
                {
                    var error = Assert.Throws<CmdletInvocationException>(() => powershell.Invoke(new[] { resource }));
                    Assert.IsType<InvalidOperationException>(error.InnerException);
                }
            }
        }

        [Theory]
        [InlineData("Pending")]
        [InlineData("Unknown")]
        [InlineData("InstantAccess")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ReadinessGuardPreventsSetAndRemove(string accessState)
        {
            var policy = Policy("Unlocked", 7, DateTime.UtcNow);
            var set = new PolicyHarness(policy, null, accessState);
            var remove = new PolicyHarness(policy, null, accessState);

            var setError = Assert.Throws<InvalidOperationException>(() => set.Set("Unlocked", 7).ExecuteCmdlet());
            var removeError = Assert.Throws<InvalidOperationException>(() => remove.Remove().ExecuteCmdlet());

            Assert.Contains(accessState, setError.Message);
            Assert.Contains(accessState, removeError.Message);
            set.VerifyNoMutation();
            remove.VerifyNoMutation();
        }

        [Theory]
        [InlineData("Unlocked", 0, 7, "Available")]
        [InlineData("Unlocked", 7, 14, "AvailableWithInstantAccess")]
        [InlineData("Unlocked", 14, 7, "Available")]
        [InlineData("Locked", 0, 7, "Available")]
        [InlineData("Locked", 7, 7, "Available")]
        [InlineData("Locked", 7, 14, "Available")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SetUsesPolicyTypeRouteAndReturnsVerifiedSnapshot(string type, int previousDuration, int duration, string accessState)
        {
            DateTime start = DateTime.UtcNow.AddHours(-1);
            var previous = previousDuration == 0 ? null : Policy(type, previousDuration, start);
            var persisted = Policy(type, duration, start);
            var harness = new PolicyHarness(previous, persisted, accessState);
            var cmdlet = harness.Set(type.ToLowerInvariant(), duration);

            cmdlet.ExecuteCmdlet();

            harness.VerifyMutation(type, duration);
            harness.VerifyOutput(duration, false);
        }

        [Theory]
        [InlineData("Unlocked")]
        [InlineData("Locked")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SameTypeUpdateRetainsStartWhenPreflightExpiryIsUnknown(string type)
        {
            DateTime start = DateTime.UtcNow.AddHours(-1);
            var harness = new PolicyHarness(Policy(type, 7, start, null), Policy(type, 14, start));

            harness.Set(type, 14).ExecuteCmdlet();

            harness.VerifyMutation(type, 14);
            harness.VerifyOutput(14, false);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UnlockedShorteningCanImmediatelyExpirePolicy()
        {
            DateTime start = DateTime.UtcNow.AddDays(-10);
            var harness = new PolicyHarness(Policy("Unlocked", 14, start), Policy("Unlocked", 7, start, true));

            harness.Set("Unlocked", 7).ExecuteCmdlet();

            harness.VerifyMutation("Unlocked", 7);
            harness.VerifyOutput(7, true);
        }

        [Theory]
        [InlineData(false, 14, false)]
        [InlineData(null, 14, false)]
        [InlineData(false, 1, true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LockingUnlockedPolicyRetainsOriginalStart(bool? previousExpired, int duration, bool expired)
        {
            DateTime start = DateTime.UtcNow.AddDays(-2);
            var harness = new PolicyHarness(Policy("Unlocked", 7, start, previousExpired),
                Policy("Locked", duration, start, expired));

            harness.Set("Locked", duration).ExecuteCmdlet();

            harness.VerifyMutation("Locked", duration);
            harness.VerifyOutput(duration, expired);
        }

        [Theory]
        [InlineData("Unlocked")]
        [InlineData("Locked")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ExpiredPolicyReplacementRequiresNewServiceStart(string previousType)
        {
            DateTime oldStart = DateTime.UtcNow.AddDays(-10);
            DateTime newStart = DateTime.UtcNow;
            var harness = new PolicyHarness(Policy(previousType, 7, oldStart, true), Policy("Locked", 7, newStart));

            harness.Set("Locked", 7).ExecuteCmdlet();

            harness.VerifyMutation("Locked", 7);
            harness.VerifyOutput(7, false);
        }

        [Theory]
        [InlineData("Unlocked", 7)]
        [InlineData("Locked", 6)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void LockedRestrictionsFailBeforeMutationEvenWithForce(string requestedType, int duration)
        {
            var harness = new PolicyHarness(Policy("Locked", 7, DateTime.UtcNow), null);
            var cmdlet = harness.Set(requestedType, duration);
            cmdlet.Force = true;

            Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());

            harness.VerifyNoMutation();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveUsesAdministrativeZeroDurationAndReturnsRemainingSnapshot()
        {
            DateTime start = DateTime.UtcNow.AddDays(-1);
            var harness = new PolicyHarness(Policy("Unlocked", 7, start), Policy("Unlocked", 0, start, true));

            harness.Remove().ExecuteCmdlet();

            harness.VerifyMutation("Locked", 0);
            harness.VerifyOutput(0, true);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("Unlocked", true)]
        [InlineData("Unlocked", null)]
        [InlineData("Locked", false)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveRejectsMissingExpiredUnknownAndLockedPolicy(string type, bool? expired)
        {
            var harness = new PolicyHarness(type == null ? null : Policy(type, 7, DateTime.UtcNow, expired), null);

            Assert.Throws<InvalidOperationException>(() => harness.Remove().ExecuteCmdlet());

            harness.VerifyNoMutation();
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PermissionFailureIdentifiesAdministrativeActionWithoutFallback(bool remove)
        {
            var harness = new PolicyHarness(Policy("Unlocked", 7, DateTime.UtcNow), null);
            harness.Operations.Setup(client => client.UpdateImmutabilityPolicyLockWithHttpMessagesAsync(
                    "rg", "snapshot", It.IsAny<ImmutabilityPolicyLockData>(), null, It.IsAny<CancellationToken>()))
                .ThrowsAsync(new CloudException("Denied by service")
                {
                    Response = new HttpResponseMessageWrapper(new HttpResponseMessage(HttpStatusCode.Forbidden), string.Empty)
                });
            SnapshotImmutabilityPolicyBaseCmdlet cmdlet = remove
                ? (SnapshotImmutabilityPolicyBaseCmdlet)harness.Remove() : harness.Set("Locked", 7);

            var error = Assert.Throws<UnauthorizedAccessException>(() => cmdlet.ExecuteCmdlet());

            Assert.Contains("Microsoft.Compute/snapshots/updateImmutabilityPolicyLock/action", error.Message);
            Assert.IsType<CloudException>(error.InnerException);
            harness.VerifyNoOutput();
            harness.Operations.Verify(client => client.UpdateImmutabilityPolicyWithHttpMessagesAsync(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ImmutabilityPolicyData>(), null,
                It.IsAny<CancellationToken>()), Times.Never());
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UnconfirmedReadbackTerminatesWithoutOutputOrMutationReplay(bool remove, bool failedGet)
        {
            DateTime start = DateTime.UtcNow.AddHours(-1);
            var harness = new PolicyHarness(Policy("Unlocked", 7, start), Policy("Unlocked", 14, start), failReadback: failedGet);
            SnapshotImmutabilityPolicyBaseCmdlet cmdlet = remove
                ? (SnapshotImmutabilityPolicyBaseCmdlet)harness.Remove() : harness.Set("Unlocked", 7);

            Assert.Throws<InvalidOperationException>(() => cmdlet.ExecuteCmdlet());

            harness.Runtime.Verify(runtime => runtime.ThrowTerminatingError(It.Is<ErrorRecord>(error =>
                error.FullyQualifiedErrorId == "SnapshotImmutabilityPolicyVerificationFailed"
                && error.Exception.Message.Contains("/resourceGroups/rg/providers/Microsoft.Compute/snapshots/snapshot")
                && error.Exception.Message.Contains("Get-AzSnapshot")
                && error.Exception.Message.Contains("before retrying"))), Times.Once());
            harness.VerifyMutation(remove ? "Locked" : "Unlocked", remove ? 0 : 7);
            harness.VerifyNoOutput();
        }

        [Theory]
        [InlineData("Unlocked", false)]
        [InlineData("Locked", false)]
        [InlineData("Locked", true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerificationRejectsUnexpectedStartAndMissingExpiry(string previousType, bool missingExpiry)
        {
            DateTime start = DateTime.UtcNow.AddHours(-1);
            var previous = Policy(previousType, 7, start);
            var persisted = Policy("Locked", 7, start.AddMinutes(1));
            if (missingExpiry)
            {
                persisted = new ImmutabilityPolicy(7, "Locked", start, null, false);
            }
            var harness = new PolicyHarness(previous, persisted);

            Assert.Throws<InvalidOperationException>(() => harness.Set("Locked", 7).ExecuteCmdlet());

            harness.VerifyNoOutput();
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerificationUsesServiceExpiryDespiteClientClockSkew(bool reportedExpired)
        {
            DateTime start = DateTime.UtcNow.AddDays(reportedExpired ? -1 : -10);
            var harness = new PolicyHarness(Policy("Unlocked", 14, start),
                Policy("Unlocked", 7, start, reportedExpired));

            harness.Set("Unlocked", 7).ExecuteCmdlet();

            harness.VerifyOutput(7, reportedExpired);
        }

        [Theory]
        [InlineData("Unlocked", false)]
        [InlineData("Locked", false)]
        [InlineData("Unlocked", true)]
        [InlineData("Locked", true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VerificationAcceptsNaturalExpiryAndReplacementAfterPreflight(string type, bool replacement)
        {
            DateTime previousStart = DateTime.UtcNow.AddDays(-7);
            DateTime persistedStart = replacement ? previousStart.AddDays(7) : previousStart;
            var harness = new PolicyHarness(Policy(type, 7, previousStart),
                Policy(type, 7, persistedStart, !replacement));

            harness.Set(type, 7).ExecuteCmdlet();

            harness.VerifyMutation(type, 7);
            harness.VerifyOutput(7, !replacement);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemovalVerificationUsesServiceExpiryDespiteClientClockSkew()
        {
            DateTime start = DateTime.UtcNow.AddDays(1);
            var harness = new PolicyHarness(Policy("Unlocked", 7, start), Policy("Unlocked", 0, start, true));

            harness.Remove().ExecuteCmdlet();

            harness.VerifyMutation("Locked", 0);
            harness.VerifyOutput(0, true);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeclinedShouldProcessDoesNotCallClientPromptOrQueueJob(bool remove)
        {
            var harness = new PolicyHarness(null, null);
            SnapshotImmutabilityPolicyBaseCmdlet cmdlet = remove
                ? (SnapshotImmutabilityPolicyBaseCmdlet)harness.Remove() : harness.Set("Locked", 7);
            cmdlet.AsJob = true;
            cmdlet.MyInvocation.BoundParameters.Add("AsJob", true);

            InvokeProcessRecord(cmdlet);

            Assert.Empty(harness.Operations.Invocations);
            harness.Runtime.Verify(runtime => runtime.ShouldContinue(It.IsAny<string>(), It.IsAny<string>()), Times.Never());
            harness.Runtime.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Never());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DeclinedRiskAcknowledgementDoesNotCallClientOrQueueJob(bool remove)
        {
            var harness = new PolicyHarness(null, null);
            harness.Runtime.Setup(runtime => runtime.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            SnapshotImmutabilityPolicyBaseCmdlet cmdlet = remove
                ? (SnapshotImmutabilityPolicyBaseCmdlet)harness.Remove() : harness.Set("Locked", 7);
            cmdlet.AsJob = true;
            cmdlet.MyInvocation.BoundParameters.Add("AsJob", true);
            cmdlet.MyInvocation.BoundParameters.Add("Confirm", false);

            InvokeProcessRecord(cmdlet);

            Assert.Empty(harness.Operations.Invocations);
            harness.Runtime.Verify(runtime => runtime.ShouldContinue(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
            harness.Runtime.Verify(runtime => runtime.WriteObject(It.IsAny<object>()), Times.Never());
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void JobAcknowledgementIsForegroundOnlyAndWorkerReturnsVerifiedSnapshot(bool remove, bool force)
        {
            DateTime start = DateTime.UtcNow.AddHours(-1);
            var harness = new PolicyHarness(Policy("Unlocked", 7, start),
                Policy(remove ? "Unlocked" : "Locked", remove ? 0 : 7, start, remove));
            int foregroundThread = Thread.CurrentThread.ManagedThreadId;
            harness.Runtime.Setup(runtime => runtime.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            harness.Runtime.Setup(runtime => runtime.ShouldContinue(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(() =>
                {
                    Assert.Equal(foregroundThread, Thread.CurrentThread.ManagedThreadId);
                    return true;
                });
            SnapshotImmutabilityPolicyBaseCmdlet cmdlet = remove
                ? (SnapshotImmutabilityPolicyBaseCmdlet)harness.Remove() : harness.Set("Locked", 7);
            cmdlet.Force = force;
            cmdlet.AsJob = true;
            cmdlet.MyInvocation.BoundParameters.Add("AsJob", true);
            Job job = null;
            harness.Runtime.Setup(runtime => runtime.WriteObject(It.IsAny<object>()))
                .Callback<object>(output => job = Assert.IsAssignableFrom<Job>(output));

            InvokeProcessRecord(cmdlet);

            Assert.NotNull(job);
            using (job)
            {
                Assert.True(job.Finished.WaitOne(TimeSpan.FromSeconds(15)), "The policy job did not finish without a background prompt.");
                Assert.Equal(JobState.Completed, job.JobStateInfo.State);
                Assert.Empty(job.Error);
                var output = Assert.IsType<PSSnapshot>(Assert.Single(job.Output).BaseObject);
                Assert.Equal(remove ? 0 : 7, output.ImmutabilityPolicy.ImmutabilityDurationDays);
                Assert.Equal(remove, output.ImmutabilityPolicy.IsPolicyExpired);
            }
            harness.Runtime.Verify(runtime => runtime.ShouldContinue(It.IsAny<string>(), It.IsAny<string>()),
                force ? Times.Never() : Times.Once());
            harness.VerifyMutation("Locked", remove ? 0 : 7);
        }

        private static ImmutabilityPolicy Policy(string type, int duration, DateTime start, bool? expired = false)
        {
            return new ImmutabilityPolicy(duration, type, start, start.AddDays(duration), expired);
        }

        private static ParameterAttribute GetParameter(Type type, string name)
        {
            return Assert.Single(type.GetProperty(name).GetCustomAttributes(typeof(ParameterAttribute), true).Cast<ParameterAttribute>());
        }

        private static void InvokeProcessRecord(SnapshotImmutabilityPolicyBaseCmdlet cmdlet)
        {
            typeof(SnapshotImmutabilityPolicyBaseCmdlet).GetMethod("ProcessRecord",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).Invoke(cmdlet, null);
        }

        private static IAzureContext TestContext()
        {
            var subscription = new AzureSubscription { Id = "00000000-0000-0000-0000-000000000001" };
            var context = new Mock<IAzureContext>();
            context.SetupGet(value => value.Subscription).Returns(subscription);
            return context.Object;
        }

        public class TestSetPolicy : SetAzSnapshotImmutabilityPolicy
        {
            protected override IAzureContext DefaultContext => TestContext();
        }

        public class TestRemovePolicy : RemoveAzSnapshotImmutabilityPolicy
        {
            protected override IAzureContext DefaultContext => TestContext();
        }

        public class GenericResource
        {
            public string Name { get; set; }
            public string ResourceGroupName { get; set; }
            public string ResourceId { get; set; }
        }

        [Cmdlet(VerbsDiagnostic.Test, "PipelineSetPolicy", DefaultParameterSetName = "DefaultParameterSet")]
        public class PipelineSetPolicy : TestSetPolicy
        {
            protected override void BeginProcessing() { }
            protected override void EndProcessing() { }

            protected override void ProcessRecord()
            {
                GetSnapshotIdentity(out string resourceGroup, out string snapshot);
                WriteObject($"{ParameterSetName}:{resourceGroup}:{snapshot}");
            }
        }

        [Cmdlet(VerbsDiagnostic.Test, "PipelineRemovePolicy", DefaultParameterSetName = "DefaultParameterSet")]
        public class PipelineRemovePolicy : TestRemovePolicy
        {
            protected override void BeginProcessing() { }
            protected override void EndProcessing() { }

            protected override void ProcessRecord()
            {
                GetSnapshotIdentity(out string resourceGroup, out string snapshot);
                WriteObject($"{ParameterSetName}:{resourceGroup}:{snapshot}");
            }
        }

        private sealed class PolicyHarness
        {
            internal readonly Mock<ISnapshotsOperations> Operations = new Mock<ISnapshotsOperations>(MockBehavior.Strict);
            internal readonly Mock<ICommandRuntime> Runtime = new Mock<ICommandRuntime>();
            private readonly ComputeClient client;

            internal PolicyHarness(ImmutabilityPolicy previous, ImmutabilityPolicy persisted,
                string accessState = "Available", bool failReadback = false)
            {
                var management = new Mock<IComputeManagementClient>();
                management.SetupGet(value => value.Snapshots).Returns(Operations.Object);
                client = new ComputeClient(management.Object);
                var reads = Operations.SetupSequence(value => value.GetWithHttpMessagesAsync(
                    "rg", "snapshot", null, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new AzureOperationResponse<Snapshot>
                    {
                        Body = new Snapshot("eastus", immutabilityPolicy: previous, snapshotAccessState: accessState)
                    });
                if (failReadback)
                {
                    reads.ThrowsAsync(new HttpRequestException("Readback unavailable"));
                }
                else
                {
                    reads.ReturnsAsync(new AzureOperationResponse<Snapshot>
                    {
                        Body = new Snapshot("eastus", immutabilityPolicy: persisted)
                    });
                }
                Operations.Setup(value => value.UpdateImmutabilityPolicyWithHttpMessagesAsync(
                    "rg", "snapshot", It.IsAny<ImmutabilityPolicyData>(), null, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new AzureOperationResponse<Snapshot, SnapshotsUpdateImmutabilityPolicyHeaders>());
                Operations.Setup(value => value.UpdateImmutabilityPolicyLockWithHttpMessagesAsync(
                    "rg", "snapshot", It.IsAny<ImmutabilityPolicyLockData>(), null, It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new AzureOperationResponse<Snapshot, SnapshotsUpdateImmutabilityPolicyLockHeaders>());
                Runtime.Setup(value => value.ThrowTerminatingError(It.IsAny<ErrorRecord>()))
                    .Callback<ErrorRecord>(error => throw error.Exception);
            }

            internal TestSetPolicy Set(string type, int duration)
            {
                var cmdlet = new TestSetPolicy { PolicyType = type, DurationInDays = duration };
                Initialize(cmdlet);
                return cmdlet;
            }

            internal TestRemovePolicy Remove()
            {
                var cmdlet = new TestRemovePolicy();
                Initialize(cmdlet);
                return cmdlet;
            }

            private void Initialize(SnapshotImmutabilityPolicyBaseCmdlet cmdlet)
            {
                cmdlet.Name = "snapshot";
                cmdlet.ResourceGroupName = "rg";
                cmdlet.ComputeClient = client;
                cmdlet.CommandRuntime = Runtime.Object;
                cmdlet.SetParameterSet("DefaultParameterSet");
            }

            internal void VerifyMutation(string route, int duration)
            {
                if (route == "Unlocked")
                {
                    Operations.Verify(value => value.UpdateImmutabilityPolicyWithHttpMessagesAsync(
                        "rg", "snapshot", It.Is<ImmutabilityPolicyData>(data => data.Type == "Unlocked"
                            && data.ImmutabilityDurationDays == duration), null, It.IsAny<CancellationToken>()), Times.Once());
                    Operations.Verify(value => value.UpdateImmutabilityPolicyLockWithHttpMessagesAsync(
                        It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ImmutabilityPolicyLockData>(), null,
                        It.IsAny<CancellationToken>()), Times.Never());
                }
                else
                {
                    Operations.Verify(value => value.UpdateImmutabilityPolicyLockWithHttpMessagesAsync(
                        "rg", "snapshot", It.Is<ImmutabilityPolicyLockData>(data => data.Type == (duration == 0 ? "Unlocked" : "Locked")
                            && data.ImmutabilityDurationDays == duration), null, It.IsAny<CancellationToken>()), Times.Once());
                    Operations.Verify(value => value.UpdateImmutabilityPolicyWithHttpMessagesAsync(
                        It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ImmutabilityPolicyData>(), null,
                        It.IsAny<CancellationToken>()), Times.Never());
                }
                Operations.Verify(value => value.GetWithHttpMessagesAsync("rg", "snapshot", null,
                    It.IsAny<CancellationToken>()), Times.Exactly(2));
            }

            internal void VerifyNoMutation()
            {
                Operations.Verify(value => value.UpdateImmutabilityPolicyWithHttpMessagesAsync(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ImmutabilityPolicyData>(), null,
                    It.IsAny<CancellationToken>()), Times.Never());
                Operations.Verify(value => value.UpdateImmutabilityPolicyLockWithHttpMessagesAsync(
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<ImmutabilityPolicyLockData>(), null,
                    It.IsAny<CancellationToken>()), Times.Never());
                VerifyNoOutput();
            }

            internal void VerifyOutput(int duration, bool expired)
            {
                Runtime.Verify(value => value.WriteObject(It.Is<object>(output => output is PSSnapshot
                    && ((PSSnapshot)output).ImmutabilityPolicy.ImmutabilityDurationDays == duration
                    && ((PSSnapshot)output).ImmutabilityPolicy.IsPolicyExpired == expired)), Times.Once());
            }

            internal void VerifyNoOutput()
            {
                Runtime.Verify(value => value.WriteObject(It.IsAny<object>()), Times.Never());
            }
        }
    }
}
