using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Xunit;


namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.UnitTests.Cmdlets.IaaS.Extensions.DSC
{
    using NSM = Management.Compute.Models;

    public class GetAzureVmDscExtensionStatusUnitTest
    {
        private readonly GetAzureVmDscExtensionStatusCommand getAzureVmDscExtensionStatusCmdlet;
        private const string ServiceName = "dsc-service";

        public GetAzureVmDscExtensionStatusUnitTest()
        {
            getAzureVmDscExtensionStatusCmdlet = new GetAzureVmDscExtensionStatusCommand();
        }

        [Fact]
        public void TestGetService()
        {
            //when service name is passed as argument in the cmdlet
            getAzureVmDscExtensionStatusCmdlet.GetService(ServiceName, null);
            Assert.Equal(ServiceName, getAzureVmDscExtensionStatusCmdlet.ServiceName);

            //when vm object is passed as argument in the cmdlet
            getAzureVmDscExtensionStatusCmdlet.GetService("", GetAzureVM(ServiceName, ServiceName));
            Assert.Equal(ServiceName, getAzureVmDscExtensionStatusCmdlet.ServiceName);
        }

        [Fact]
        public void TestGetVirtualMachineDscStatusContextListWithServiceName()
        {
            getAzureVmDscExtensionStatusCmdlet.ServiceName = ServiceName;

            // service has multiple vm's
            var roles = new List<NSM.Role> {CreateRole("dscmachine01"), CreateRole("dscmachine02")};
            var roleInstances = new List<NSM.RoleInstance>
            {
                CreateRoleInstance("dscmachine01"),
                CreateRoleInstance("dscmachine02")
            };

            var deploymentResponse = CreateDeploymentGetResponse(ServiceName, roles, roleInstances);
            var dscExtensionStatusContexts =
                getAzureVmDscExtensionStatusCmdlet
                    .GetVirtualMachineDscStatusContextList(deploymentResponse);
            Assert.Null(getAzureVmDscExtensionStatusCmdlet.Name);
            Assert.Null(getAzureVmDscExtensionStatusCmdlet.VmName);
            Assert.NotNull(dscExtensionStatusContexts);
            Assert.Equal(dscExtensionStatusContexts.Count, 2);

        }

        [Fact]
        public void TestGetVirtualMachineDscStatusContextListWithServiceNameAndVmName()
        {
            getAzureVmDscExtensionStatusCmdlet.ServiceName = ServiceName;
            getAzureVmDscExtensionStatusCmdlet.Name = "dscmachine01";

            // service has multiple vm's
            var roles = new List<NSM.Role> {CreateRole("dscmachine01"), CreateRole("dscmachine02")};
            var roleInstances = new List<NSM.RoleInstance>
            {
                CreateRoleInstance("dscmachine01"),
                CreateRoleInstance("dscmachine02")
            };

            var deploymentResponse = CreateDeploymentGetResponse(ServiceName, roles, roleInstances);
            var dscExtensionStatusContexts =
                getAzureVmDscExtensionStatusCmdlet
                    .GetVirtualMachineDscStatusContextList(deploymentResponse);
            Assert.NotNull(getAzureVmDscExtensionStatusCmdlet.Name);
            Assert.Null(getAzureVmDscExtensionStatusCmdlet.VmName);
            Assert.NotNull(dscExtensionStatusContexts);
            Assert.Equal(dscExtensionStatusContexts.Count, 1);

        }

        [Fact]
        public void TestGetVirtualMachineDscStatusContextListWithServiceNameAndIncorrectVmName()
        {
            getAzureVmDscExtensionStatusCmdlet.ServiceName = ServiceName;
            getAzureVmDscExtensionStatusCmdlet.Name = "some-blah";

            // service has multiple vm's
            var roles = new List<NSM.Role> {CreateRole("dscmachine01"), CreateRole("dscmachine02")};
            var roleInstances = new List<NSM.RoleInstance>
            {
                CreateRoleInstance("dscmachine01"),
                CreateRoleInstance("dscmachine02")
            };

            var deploymentResponse = CreateDeploymentGetResponse(ServiceName, roles, roleInstances);
            var dscExtensionStatusContexts =
                getAzureVmDscExtensionStatusCmdlet
                    .GetVirtualMachineDscStatusContextList(deploymentResponse);
            Assert.NotNull(getAzureVmDscExtensionStatusCmdlet.Name);
            Assert.Null(getAzureVmDscExtensionStatusCmdlet.VmName);
            Assert.Equal(dscExtensionStatusContexts.Count, 0);

        }

        [Fact]
        public void TestGetVirtualMachineDscStatusContextListWithVm()
        {
            getAzureVmDscExtensionStatusCmdlet.ServiceName = ServiceName;
            getAzureVmDscExtensionStatusCmdlet.VmName = "dscmachine02";

            // service has multiple vm's
            var roles = new List<NSM.Role> {CreateRole("dscmachine02")};
            var roleInstances = new List<NSM.RoleInstance> {CreateRoleInstance("dscmachine02")};

            var deploymentResponse = CreateDeploymentGetResponse(ServiceName, roles, roleInstances);
            var dscExtensionStatusContexts =
                getAzureVmDscExtensionStatusCmdlet
                    .GetVirtualMachineDscStatusContextList(deploymentResponse);
            Assert.Null(getAzureVmDscExtensionStatusCmdlet.Name);
            Assert.NotNull(getAzureVmDscExtensionStatusCmdlet.VmName);
            Assert.Equal(dscExtensionStatusContexts.Count, 1);
        }

        [Fact]
        public void TestCreateDscStatusContext()
        {
            getAzureVmDscExtensionStatusCmdlet.ServiceName = ServiceName;

            var roles = new List<NSM.Role> {CreateRole("dscmachine02")};
            var roleInstances = new List<NSM.RoleInstance> {CreateRoleInstance("dscmachine02")};
            var context =
                getAzureVmDscExtensionStatusCmdlet.CreateDscStatusContext(
                    roles[0], roleInstances[0]);
            Assert.NotNull(context);
            Assert.Equal(context.Name, "dscmachine02");
            Assert.Equal(context.StatusCode, 1);
            Assert.Equal(context.ServiceName, ServiceName);
            Assert.Equal(context.Status, "Success");
            Assert.Equal(context.StatusMessage, "Dsc Configuration was applied successful");
            Assert.Equal(context.DscConfigurationLog.Count(), GetFormattedMessage().Count());
        }

        private IPersistentVM GetAzureVM(String roleName, String serviceName)
        {
            var vm = new PersistentVM {RoleName = roleName};
            var vmContext = new PersistentVMRoleContext
            {
                DeploymentName = roleName,
                Name = roleName,
                ServiceName = serviceName,
                VM = vm
            };

            return vmContext;
        }

        private NSM.DeploymentGetResponse CreateDeploymentGetResponse(string serviceName, IList<NSM.Role> roles,
            IList<NSM.RoleInstance> roleInstances)
        {
            var response = new NSM.DeploymentGetResponse
            {
                Name = serviceName,
                Configuration = "config",
                Status = Management.Compute.Models.DeploymentStatus.Starting,
                PersistentVMDowntime = new NSM.PersistentVMDowntime
                {
                    EndTime = DateTime.Now,
                    StartTime = DateTime.Now,
                    Status = "",
                },
                LastModifiedTime = DateTime.Now,
                Roles = roles,
                RoleInstances = roleInstances
            };

            return response;
        }

        private NSM.RoleInstance CreateRoleInstance(String roleName)
        {
            var roleInstance = new NSM.RoleInstance
            {
                RoleName = roleName,
                ResourceExtensionStatusList = CreateResourceExtensionStatus()
            };
            return roleInstance;
        }

        private NSM.Role CreateRole(String roleName)
        {
            var role = new NSM.Role
            {
                RoleName = roleName
            };

            return role;
        }

        private List<NSM.ResourceExtensionStatus> CreateResourceExtensionStatus()
        {
            var resourceExtensionStatusList = new List<NSM.ResourceExtensionStatus>();

            var resourceBgiExtensionStatus = new NSM.ResourceExtensionStatus
            {
                HandlerName = "BGIInfo"
            };
            var resourceDscExtensionStatus = new NSM.ResourceExtensionStatus
            {
                HandlerName = "Microsoft.Powershell.DSC",
                ExtensionSettingStatus = CreateExtensionSettingStatus()
            };

            resourceExtensionStatusList.Add(resourceBgiExtensionStatus);
            resourceExtensionStatusList.Add(resourceDscExtensionStatus);

            return resourceExtensionStatusList;
        }

        private NSM.ResourceExtensionConfigurationStatus CreateExtensionSettingStatus()
        {
            var extensionSettingStatus = new NSM.ResourceExtensionConfigurationStatus
            {
                Code = 1,
                Status = "Success",
                FormattedMessage = new NSM.GuestAgentFormattedMessage
                {
                    Message = "Dsc Configuration was applied successful"
                },
                Timestamp = new DateTime(),
                SubStatusList = CreateResourceExtensionSubStatus(1, CreateGuestAgentFormattedMessage())
            };

            return extensionSettingStatus;
        }

        private List<NSM.ResourceExtensionSubStatus> CreateResourceExtensionSubStatus(int code,
            NSM.GuestAgentFormattedMessage formattedMessage)
        {
            var resourceExtensionSubStatusList = new List<NSM.ResourceExtensionSubStatus>();
            var resourceExtensionSubStatus = new NSM.ResourceExtensionSubStatus
            {
                Code = code,
                FormattedMessage = formattedMessage,
                Status = "Success",
                Name = "DSC Status"
            };
            resourceExtensionSubStatusList.Add(resourceExtensionSubStatus);
            return resourceExtensionSubStatusList;
        }

        private NSM.GuestAgentFormattedMessage CreateGuestAgentFormattedMessage()
        {
            var formattedMessage = new NSM.GuestAgentFormattedMessage
            {
                Message =
                    "[ESPARMAR-2012R2]:LCM:[Start Set]\r\n[ESPARMAR-2012R2]:LCM:[Start Resource] " +
                    "[[WindowsFeature]IIS]\r\n[ESPARMAR-2012R2]:LCM:[Start Test] [[WindowsFeature]IIS]\r\n[ESPARMAR-2012R2]"
            };
            return formattedMessage;
        }

        private IEnumerable<string> GetFormattedMessage()
        {
            const string message = "[ESPARMAR-2012R2]:LCM:[Start Set]\r\n[ESPARMAR-2012R2]:LCM:[Start Resource] " +
                                   "[[WindowsFeature]IIS]\r\n[ESPARMAR-2012R2]:LCM:[Start Test] [[WindowsFeature]IIS]\r\n[ESPARMAR-2012R2]";

            return message.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None);
        }
    }
}
