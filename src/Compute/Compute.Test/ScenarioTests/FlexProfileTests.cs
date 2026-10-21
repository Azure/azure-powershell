// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the Apache License, Version 2.0.

using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.Commands.Compute.Strategies.Network;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public class FlexProfileTests : ComputeTestRunner
    {
        private const string PreferredSize = "Standard_D2s_v5";
        private const string DeployedSize = "Standard_D4s_v5";

        public FlexProfileTests(Xunit.Abstractions.ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileConfigBinding()
        {
            TestRunner.RunTestScript("Test-FlexProfileConfigBinding");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileLifecycle()
        {
            TestRunner.RunTestScript("Test-FlexProfileLifecycle");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileUnsupportedPlacement()
        {
            TestRunner.RunTestScript("Test-FlexProfileUnsupportedPlacement");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfigCreatesPreferredProfileWithoutFixedSize(bool cpuOptions)
        {
            PSVirtualMachine output = null;
            var runtime = new Mock<ICommandRuntime>();
            runtime.Setup(r => r.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => output = Assert.IsType<PSVirtualMachine>(value));
            var command = new NewAzureVMConfigCommand
            {
                CommandRuntime = runtime.Object,
                VMName = "flex-vm",
                PreferredVMSize = PreferredSize
            };
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);
            if (cpuOptions)
            {
                command.vCPUCountAvailable = 2;
                command.vCPUCountPerCore = 1;
                command.ProcessorMode = "Deterministic";
                command.MyInvocation.BoundParameters.Add("vCPUCountAvailable", 2);
                command.MyInvocation.BoundParameters.Add("vCPUCountPerCore", 1);
                command.MyInvocation.BoundParameters.Add("ProcessorMode", "Deterministic");
            }

            command.ExecuteCmdlet();

            Assert.NotNull(output);
            Assert.Equal(PreferredSize, output.FlexProfile.PreferredVMSize);
            Assert.Null(output.HardwareProfile?.VmSize);
            if (cpuOptions)
            {
                Assert.Equal(2, output.HardwareProfile.VmSizeProperties.VCPUsAvailable);
                Assert.Equal(1, output.HardwareProfile.VmSizeProperties.VCPUsPerCore);
                Assert.Equal("Deterministic", output.HardwareProfile.ProcessorMode);
            }
            runtime.Verify(r => r.WriteObject(It.IsAny<object>()), Times.Once());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfigRequiresExactlyOneBoundSize(bool bothBound)
        {
            var command = new NewAzureVMConfigCommand { VMName = "flex-vm" };
            if (bothBound)
            {
                command.VMSize = DeployedSize;
                command.PreferredVMSize = PreferredSize;
                command.MyInvocation.BoundParameters.Add("VMSize", DeployedSize);
                command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);
            }

            var error = Assert.Throws<ArgumentException>(() => command.ExecuteCmdlet());
            Assert.Contains("VMSize", error.Message);
            Assert.Contains("PreferredVMSize", error.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PreferredSizeMetadataPreservesExistingBinding()
        {
            var size = Assert.Single(typeof(NewAzureVMConfigCommand).GetProperty("VMSize")
                .GetCustomAttributes(typeof(ParameterAttribute), false).Cast<ParameterAttribute>());
            Assert.False(size.Mandatory);
            Assert.Equal(1, size.Position);
            Assert.True(size.ValueFromPipelineByPropertyName);
            var preferred = Assert.Single(typeof(NewAzureVMConfigCommand).GetProperty("PreferredVMSize")
                .GetCustomAttributes(typeof(ParameterAttribute), false).Cast<ParameterAttribute>());
            Assert.False(preferred.Mandatory);
            Assert.True(preferred.ValueFromPipelineByPropertyName);
            Assert.Equal(ParameterAttribute.AllParameterSets, preferred.ParameterSetName);
            Assert.Equal(typeof(FlexProfile), typeof(PSVirtualMachine).GetProperty("FlexProfile").PropertyType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SimpleNewRejectsBothSizesBeforeCallingAzure()
        {
            var command = new NewAzureVMCommand { Size = DeployedSize, PreferredVMSize = PreferredSize };
            command.MyInvocation.BoundParameters.Add("Size", DeployedSize);
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);

            var error = Assert.Throws<ArgumentException>(() => command.ExecuteCmdlet());

            Assert.Contains("Size", error.Message);
            Assert.Contains("PreferredVMSize", error.Message);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(null, true)]
        [InlineData("", false)]
        [InlineData("", true)]
        [InlineData("Standard_D2s_v5", false)]
        [InlineData("Standard_D2s_v5", true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SimpleCreateStrategySerializesExactlyOneSize(string preferredSize, bool cpuOptions)
        {
            const string nicId = "/subscriptions/test/resourceGroups/flex-rg/providers/Microsoft.Network/networkInterfaces/flex-nic";
            var group = ResourceGroupStrategy.CreateResourceGroupConfig("flex-rg");
            var nic = new ResourceConfig<Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Network.Models.NetworkInterface>(
                NetworkInterfaceStrategy.Strategy, group, "flex-nic", _ => null, null);
            var flex = preferredSize == null ? null : new FlexProfile(preferredSize);
            var config = VirtualMachineStrategy.CreateVirtualMachineConfig(
                resourceGroup: group,
                name: "flex-vm",
                networkInterface: nic,
                imageAndOsType: null,
                adminUsername: "admin01",
                adminPassword: null,
                size: DeployedSize,
                availabilitySet: null,
                identity: null,
                dataDisks: null,
                zones: null,
                proximityPlacementGroup: _ => null,
                hostId: null,
                hostGroupId: null,
                capacityReservationGroupId: null,
                VmssId: null,
                priority: null,
                evictionPolicy: null,
                maxPrice: null,
                encryptionAtHostPresent: null,
                sshPublicKeys: null,
                vCPUsAvailable: cpuOptions ? 2 : (int?)null,
                vCPUsPerCore: cpuOptions ? 1 : (int?)null,
                processorMode: cpuOptions ? "Deterministic" : null,
                flexProfile: flex);
            var engine = new Mock<IEngine>();
            engine.Setup(e => e.GetId(nic)).Returns(nicId);

            var request = config.CreateModel(engine.Object);

            Assert.Same(flex, request.FlexProfile);
            Assert.Equal(preferredSize == null ? DeployedSize : null, request.HardwareProfile.VmSize);
            Assert.Equal(nicId, Assert.Single(request.NetworkProfile.NetworkInterfaces).Id);
            Assert.Equal(cpuOptions ? 2 : (int?)null, request.HardwareProfile.VmSizeProperties?.VCPUsAvailable);
            Assert.Equal(cpuOptions ? 1 : (int?)null, request.HardwareProfile.VmSizeProperties?.VCPUsPerCore);
            Assert.Equal(cpuOptions ? "Deterministic" : null, request.HardwareProfile.ProcessorMode);
            var json = SerializeRequest(request);
            Assert.Equal(preferredSize == null ? DeployedSize : null,
                (string)json.SelectToken("properties.hardwareProfile.vmSize"));
            Assert.Equal(preferredSize, (string)json.SelectToken("properties.flexProfile.preferredVMSize"));
            Assert.Equal(preferredSize == null, json.SelectToken("properties.flexProfile") == null);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Standard_D2s_v5")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MappingPreservesPreferredAndActualSizes(string preferredSize)
        {
            var model = new VirtualMachine(location: "eastus2", name: "flex-vm")
            {
                HardwareProfile = new HardwareProfile(DeployedSize),
                FlexProfile = preferredSize == null ? null : new FlexProfile(preferredSize)
            };

            var output = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachine>(model);
            var list = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachineList>(output);
            var roundTrip = list.ToPSVirtualMachine();
            var status = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachineListStatus>(model);

            Assert.Equal(DeployedSize, output.HardwareProfile.VmSize);
            Assert.Equal(DeployedSize, roundTrip.HardwareProfile.VmSize);
            Assert.Equal(DeployedSize, status.HardwareProfile.VmSize);
            Assert.Equal(preferredSize, output.FlexProfile?.PreferredVMSize);
            Assert.Equal(preferredSize, roundTrip.FlexProfile?.PreferredVMSize);
            Assert.Equal(preferredSize, status.FlexProfile?.PreferredVMSize);
            Assert.Equal(model.FlexProfile == null, roundTrip.FlexProfile == null);
        }

        [Theory]
        [InlineData(false, "Standard_D2s_v5")]
        [InlineData(true, "Standard_D2s_v5")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatePreferredSizeOmitsFixedSizeWithoutMutatingInput(bool noWait, string preferredSize)
        {
            var vm = CreateInput();
            var hardware = vm.HardwareProfile;
            var flex = vm.FlexProfile;
            var before = JsonConvert.SerializeObject(vm);
            var command = CreateUpdate(vm, noWait, out var operations, out var runtime);
            command.PreferredVMSize = preferredSize;
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", preferredSize);

            command.ExecuteCmdlet();

            var request = GetRequest(operations, noWait);
            Assert.NotSame(hardware, request.HardwareProfile);
            Assert.NotSame(flex, request.FlexProfile);
            Assert.Null(request.HardwareProfile.VmSize);
            Assert.Equal(preferredSize, request.FlexProfile.PreferredVMSize);
            Assert.Equal(2, request.HardwareProfile.VmSizeProperties.VCPUsAvailable);
            Assert.Equal(1, request.HardwareProfile.VmSizeProperties.VCPUsPerCore);
            Assert.Equal("Deterministic", request.HardwareProfile.ProcessorMode);
            Assert.Same(hardware, vm.HardwareProfile);
            Assert.Same(flex, vm.FlexProfile);
            Assert.Equal(before, JsonConvert.SerializeObject(vm));
            var json = SerializeRequest(request);
            Assert.Null(json.SelectToken("properties.hardwareProfile.vmSize"));
            Assert.Equal(preferredSize, (string)json.SelectToken("properties.flexProfile.preferredVMSize"));
            runtime.Verify(r => r.WriteObject(It.IsAny<object>()), Times.Once());
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateWithoutPreferredSizeForwardsExistingProfiles(bool noWait, bool fixedSize)
        {
            var vm = CreateInput();
            if (fixedSize)
            {
                vm.FlexProfile = null;
            }
            var command = CreateUpdate(vm, noWait, out var operations, out _);
            command.Tag = new Hashtable { { "purpose", "flex-test" } };

            command.ExecuteCmdlet();

            var request = GetRequest(operations, noWait);
            Assert.Same(vm.FlexProfile, request.FlexProfile);
            Assert.Same(vm.HardwareProfile, request.HardwareProfile);
            Assert.Equal(DeployedSize, request.HardwareProfile.VmSize);
            Assert.Equal("flex-test", request.Tags["purpose"]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatePreferredSizeHandlesMissingHardwareProfile()
        {
            var vm = CreateInput();
            vm.HardwareProfile = null;
            vm.FlexProfile = null;
            var command = CreateUpdate(vm, false, out var operations, out _);
            command.PreferredVMSize = PreferredSize;
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);

            command.ExecuteCmdlet();

            var request = GetRequest(operations, false);
            Assert.Equal(PreferredSize, request.FlexProfile.PreferredVMSize);
            Assert.Null(request.HardwareProfile.VmSize);
            Assert.Null(vm.HardwareProfile);
            Assert.Null(vm.FlexProfile);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateConvertsFixedSizeVmWithoutChangingItsInput()
        {
            var vm = CreateInput();
            vm.FlexProfile = null;
            var command = CreateUpdate(vm, false, out var operations, out _);
            command.PreferredVMSize = PreferredSize;
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);

            command.ExecuteCmdlet();

            var request = GetRequest(operations, false);
            Assert.Equal(PreferredSize, request.FlexProfile.PreferredVMSize);
            Assert.Null(request.HardwareProfile.VmSize);
            Assert.Equal(DeployedSize, vm.HardwareProfile.VmSize);
            Assert.Null(vm.FlexProfile);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatePreferredSizeAndCpuOptionsDoesNotMutateOriginalHardware(bool noWait)
        {
            var vm = CreateInput();
            var before = JsonConvert.SerializeObject(vm);
            var command = CreateUpdate(vm, noWait, out var operations, out _);
            command.PreferredVMSize = PreferredSize;
            command.vCPUCountAvailable = 1;
            command.vCPUCountPerCore = 2;
            command.ProcessorMode = "Opportunistic";
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);
            command.MyInvocation.BoundParameters.Add("vCPUCountAvailable", 1);
            command.MyInvocation.BoundParameters.Add("vCPUCountPerCore", 2);
            command.MyInvocation.BoundParameters.Add("ProcessorMode", "Opportunistic");

            command.ExecuteCmdlet();

            var request = GetRequest(operations, noWait);
            Assert.Null(request.HardwareProfile.VmSize);
            Assert.NotSame(vm.HardwareProfile.VmSizeProperties, request.HardwareProfile.VmSizeProperties);
            Assert.Equal(1, request.HardwareProfile.VmSizeProperties.VCPUsAvailable);
            Assert.Equal(2, request.HardwareProfile.VmSizeProperties.VCPUsPerCore);
            Assert.Equal("Opportunistic", request.HardwareProfile.ProcessorMode);
            Assert.Equal(before, JsonConvert.SerializeObject(vm));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateOptOutOmitsFlexProfileAndSendsSelectedFixedSize(bool noWait)
        {
            var vm = CreateInput();
            vm.FlexProfile = null;
            vm.HardwareProfile.VmSize = PreferredSize;
            var before = JsonConvert.SerializeObject(vm);
            var command = CreateUpdate(vm, noWait, out var operations, out _);

            command.ExecuteCmdlet();

            var request = GetRequest(operations, noWait);
            Assert.Null(request.FlexProfile);
            Assert.Equal(PreferredSize, request.HardwareProfile.VmSize);
            var json = SerializeRequest(request);
            Assert.Null(json.SelectToken("properties.flexProfile"));
            Assert.Equal(PreferredSize, (string)json.SelectToken("properties.hardwareProfile.vmSize"));
            Assert.Equal(before, JsonConvert.SerializeObject(vm));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateDirectFixedToFlowSwitchForwardsConflictingSizesToService(bool noWait)
        {
            var vm = CreateInput();
            vm.FlexProfile = new FlexProfile(PreferredSize);
            var serviceError = new CloudException("InvalidParameter: hardwareProfile.vmSize must be cleared.");
            var command = CreateUpdate(vm, noWait, out var operations, out var runtime, serviceError);

            var error = Assert.Throws<ComputeCloudException>(() => command.ExecuteCmdlet());

            Assert.Same(serviceError, error.InnerException);
            var request = GetRequest(operations, noWait);
            Assert.Equal(PreferredSize, request.FlexProfile.PreferredVMSize);
            Assert.Equal(DeployedSize, request.HardwareProfile.VmSize);
            runtime.Verify(r => r.WriteObject(It.IsAny<object>()), Times.Never());
        }

        [Theory]
        [InlineData(false, "InvalidParameter", "Not_A_Real_VM_Size")]
        [InlineData(true, "InvalidParameter", "Not_A_Real_VM_Size")]
        [InlineData(false, "OperationNotAllowed", "Standard_D2s_v5")]
        [InlineData(true, "OperationNotAllowed", "Standard_D2s_v5")]
        [InlineData(false, "RequiredParameterMissing", "")]
        [InlineData(true, "RequiredParameterMissing", "")]
        [InlineData(false, "SubscriptionNotRegisteredForFeature", "Standard_D2s_v5")]
        [InlineData(true, "SubscriptionNotRegisteredForFeature", "Standard_D2s_v5")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateForwardsPreferredSizeServiceErrors(bool noWait, string errorCode, string preferredSize)
        {
            var message = errorCode == "SubscriptionNotRegisteredForFeature"
                ? "The subscription is not registered for the requested Microsoft.Compute preview feature."
                : errorCode == "RequiredParameterMissing"
                    ? "Required parameter 'flexProfile.preferredVMSize' is missing."
                    : "The requested flexProfile.preferredVMSize is not allowed.";
            var serviceError = new CloudException(message)
            {
                Body = new CloudError
                {
                    Code = errorCode,
                    Message = message,
                    Target = "flexProfile.preferredVMSize"
                }
            };
            var vm = CreateInput();
            var before = JsonConvert.SerializeObject(vm);
            var command = CreateUpdate(vm, noWait, out var operations, out var runtime, serviceError);
            command.PreferredVMSize = preferredSize;
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", preferredSize);

            var error = Assert.Throws<ComputeCloudException>(() => command.ExecuteCmdlet());

            Assert.Same(serviceError, error.InnerException);
            Assert.Contains(message, error.Message);
            var inner = Assert.IsType<CloudException>(error.InnerException);
            Assert.Equal(errorCode, inner.Body.Code);
            Assert.Equal("flexProfile.preferredVMSize", inner.Body.Target);
            Assert.Equal(preferredSize, GetRequest(operations, noWait).FlexProfile.PreferredVMSize);
            Assert.Equal(before, JsonConvert.SerializeObject(vm));
            runtime.Verify(r => r.WriteObject(It.IsAny<object>()), Times.Never());
        }

        private static PSVirtualMachine CreateInput()
        {
            return new PSVirtualMachine
            {
                Name = "flex-vm",
                Location = "eastus2",
                HardwareProfile = new HardwareProfile(DeployedSize,
                    new VMSizeProperties(2, 1), "Deterministic"),
                FlexProfile = new FlexProfile(DeployedSize)
            };
        }

        private static UpdateAzureVMCommand CreateUpdate(PSVirtualMachine vm, bool noWait,
            out Mock<IVirtualMachinesOperations> operations, out Mock<ICommandRuntime> runtime,
            Exception requestError = null)
        {
            operations = new Mock<IVirtualMachinesOperations>(MockBehavior.Strict);
            var response = new AzureOperationResponse<VirtualMachine, VirtualMachinesCreateOrUpdateHeaders>
            {
                Body = new VirtualMachine(location: vm.Location, name: vm.Name),
                Response = new HttpResponseMessage(HttpStatusCode.OK),
                Headers = new VirtualMachinesCreateOrUpdateHeaders()
            };
            var task = requestError == null
                ? Task.FromResult(response)
                : Task.FromException<AzureOperationResponse<VirtualMachine, VirtualMachinesCreateOrUpdateHeaders>>(requestError);
            if (noWait)
            {
                operations.Setup(o => o.BeginCreateOrUpdateWithHttpMessagesAsync(
                    "flex-rg", vm.Name, It.IsAny<VirtualMachine>(), null, null, null, It.IsAny<CancellationToken>()))
                    .Returns(task);
            }
            else
            {
                operations.Setup(o => o.CreateOrUpdateWithHttpMessagesAsync(
                    "flex-rg", vm.Name, It.IsAny<VirtualMachine>(), null, null, null, It.IsAny<CancellationToken>()))
                    .Returns(task);
            }
            var client = new Mock<IComputeManagementClient>();
            client.SetupGet(c => c.VirtualMachines).Returns(operations.Object);
            runtime = new Mock<ICommandRuntime>();
            runtime.Setup(r => r.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            runtime.Setup(r => r.WriteObject(It.IsAny<object>())).Callback<object>(value =>
            {
                var output = Assert.IsType<PSAzureOperationResponse>(value);
                Assert.Equal(HttpStatusCode.OK, output.StatusCode);
                Assert.True(output.IsSuccessStatusCode);
            });
            var command = new UpdateAzureVMCommand
            {
                CommandRuntime = runtime.Object,
                ComputeClient = new ComputeClient(client.Object),
                ResourceGroupName = "flex-rg",
                VM = vm,
                NoWait = new SwitchParameter(noWait)
            };
            // Direct ExecuteCmdlet tests bypass the binder, which normally initializes this field.
            var type = typeof(PSCmdlet);
            FieldInfo parameterSet = null;
            while (type != null && parameterSet == null)
            {
                parameterSet = type.GetField("_parameterSetName", BindingFlags.Instance | BindingFlags.NonPublic);
                type = type.BaseType;
            }
            Assert.NotNull(parameterSet);
            parameterSet.SetValue(command, "ResourceGroupNameParameterSetName");
            return command;
        }

        private static VirtualMachine GetRequest(Mock<IVirtualMachinesOperations> operations, bool noWait)
        {
            var invocation = Assert.Single(operations.Invocations);
            Assert.Equal(noWait ? "BeginCreateOrUpdateWithHttpMessagesAsync" : "CreateOrUpdateWithHttpMessagesAsync",
                invocation.Method.Name);
            return Assert.IsType<VirtualMachine>(invocation.Arguments[2]);
        }

        private static JObject SerializeRequest(VirtualMachine request)
        {
            using (var client = new ComputeManagementClient(new Microsoft.Rest.TokenCredentials("unused")))
            {
                return JObject.Parse(Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(
                    request, client.SerializationSettings));
            }
        }
    }
}
