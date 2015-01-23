using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Extensions.Test.DSC.UnitTests
{
    using NSM = Management.Compute.Models;

    [TestClass]
    public class GetAzureVmDscExtensionStatusUnitTest
    {
        private readonly GetAzureVmDscExtensionStatusCommand getAzureVmDscExtensionStatusCmdlet;
        private const string ServiceName = "dsc-service";

        public GetAzureVmDscExtensionStatusUnitTest()
        {
            getAzureVmDscExtensionStatusCmdlet = new GetAzureVmDscExtensionStatusCommand();
        }

        public TestContext TestContext { get; set; }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion

        [TestMethod]
        public void TestGetService()
        {
            //when service name is passed as argument in the cmdlet
            getAzureVmDscExtensionStatusCmdlet.GetService(ServiceName, null);   
            Assert.AreEqual(ServiceName, getAzureVmDscExtensionStatusCmdlet.Service);

            //when vm object is passed as argument in the cmdlet
            getAzureVmDscExtensionStatusCmdlet.GetService("", GetAzureVM(ServiceName, ServiceName));
            Assert.AreEqual(ServiceName, getAzureVmDscExtensionStatusCmdlet.Service);
        }

        [TestMethod]
        public void TestGetVirtualMachineDscStatusContextListWithServiceName()
        {
            getAzureVmDscExtensionStatusCmdlet.Service = ServiceName;

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
            Assert.IsNull(getAzureVmDscExtensionStatusCmdlet.Name);
            Assert.IsNull(getAzureVmDscExtensionStatusCmdlet.VmName);
            Assert.IsNotNull(dscExtensionStatusContexts);
            Assert.AreEqual(dscExtensionStatusContexts.Count, 2);

        }

        [TestMethod]
        public void TestGetVirtualMachineDscStatusContextListWithServiceNameAndVmName()
        {
            getAzureVmDscExtensionStatusCmdlet.Service = ServiceName;
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
            Assert.IsNotNull(getAzureVmDscExtensionStatusCmdlet.Name);
            Assert.IsNull(getAzureVmDscExtensionStatusCmdlet.VmName);
            Assert.IsNotNull(dscExtensionStatusContexts);
            Assert.AreEqual(dscExtensionStatusContexts.Count, 1);

        }

        [TestMethod]
        public void TestGetVirtualMachineDscStatusContextListWithServiceNameAndIncorrectVmName()
        {
            getAzureVmDscExtensionStatusCmdlet.Service = ServiceName;
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
            Assert.IsNotNull(getAzureVmDscExtensionStatusCmdlet.Name);
            Assert.IsNull(getAzureVmDscExtensionStatusCmdlet.VmName);
            Assert.AreEqual(dscExtensionStatusContexts.Count, 0);

        }

        [TestMethod]
        public void TestGetVirtualMachineDscStatusContextListWithVm()
        {
            getAzureVmDscExtensionStatusCmdlet.Service = ServiceName;
            getAzureVmDscExtensionStatusCmdlet.VmName = "dscmachine02";

            // service has multiple vm's
            var roles = new List<NSM.Role> {CreateRole("dscmachine02")};
            var roleInstances = new List<NSM.RoleInstance> {CreateRoleInstance("dscmachine02")};

            var deploymentResponse = CreateDeploymentGetResponse(ServiceName, roles, roleInstances);
            var dscExtensionStatusContexts =
                getAzureVmDscExtensionStatusCmdlet
                    .GetVirtualMachineDscStatusContextList(deploymentResponse);
            Assert.IsNull(getAzureVmDscExtensionStatusCmdlet.Name);
            Assert.IsNotNull(getAzureVmDscExtensionStatusCmdlet.VmName);
            Assert.AreEqual(dscExtensionStatusContexts.Count, 1);

        }

        [TestMethod]
        public void TestCreateDscStatusContext()
        {
            getAzureVmDscExtensionStatusCmdlet.Service = ServiceName;

            var roles = new List<NSM.Role> {CreateRole("dscmachine02")};
            var roleInstances = new List<NSM.RoleInstance> {CreateRoleInstance("dscmachine02")};
            var context =
                getAzureVmDscExtensionStatusCmdlet.CreateDscStatusContext(
                    roles[0], roleInstances[0]);
            Assert.IsNotNull(context);
            Assert.AreEqual(context.Name, "dscmachine02");
            Assert.AreEqual(context.StatusCode, 1);
            Assert.AreEqual(context.ServiceName, ServiceName);
            Assert.AreEqual(context.Status, "Success");
            Assert.AreEqual(context.StatusMessage, "Dsc Configuration was applied successful");
            Assert.AreEqual(context.DscConfigurationLog.Count(), GetFormattedMessage().Count());
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
