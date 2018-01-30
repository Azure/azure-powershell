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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Commands.Profile;
using Microsoft.Azure.Commands.Profile.Models;
using Microsoft.Azure.ServiceManagemenet.Common.Models;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using Microsoft.Azure.Commands.ScenarioTest.Extensions;
using Microsoft.Azure.Commands.Profile.Context;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication.ResourceManager;
using Microsoft.Azure.Commands.Profile.Common;

namespace Microsoft.Azure.Commands.ResourceManager.Profile.Test
{
    public class ContextCmdletTests : RMTestBase
    {
        private MemoryDataStore dataStore;
        private MockCommandRuntime commandRuntimeMock;
        const string guid1 = "a0cc8bd7-2c6a-47e9-a4c4-3f6ed136e240";
        const string guid2 = "eab635c0-a35a-4f70-9e46-e5351c7b5c8b";
        const string guid3 = "52f66548-2550-417b-941e-9d6e04f3ac8d";
        const string guid4 = "40e67ee2-1a1a-4517-9253-ab6f93c5710f";
        public ContextCmdletTests(ITestOutputHelper output)
        {
            XunitTracingInterceptor.AddToContext(new XunitTracingInterceptor(output));
            dataStore = new MemoryDataStore();
            AzureSession.Instance.DataStore = dataStore;
            commandRuntimeMock = new MockCommandRuntime();
            AzureSession.Instance.AuthenticationFactory = new MockTokenAuthenticationFactory();
            Environment.SetEnvironmentVariable("Azure_PS_Data_Collection", "True");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureContext()
        {
            var cmdlt = new GetAzureRMContextCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);
            var context = (PSAzureContext)commandRuntimeMock.OutputPipeline[0];
            Assert.Equal("test", context.Subscription.Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetAzureContextNoLogin()
        {
            var cmdlt = new GetAzureRMContextCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.DisableDataCollection();
            var profile = AzureRmProfileProvider.Instance.Profile;
            AzureRmProfileProvider.Instance.Profile = new AzureRmProfile();

            try
            {
                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();
            }
            finally
            {
                AzureRmProfileProvider.Instance.Profile = profile;
            }

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);
            var context = (PSAzureContext)commandRuntimeMock.OutputPipeline[0];
            Assert.True(context == null || context.Account == null || context.Account.Id == null);
            Assert.True(commandRuntimeMock.ErrorStream.Count == 1);
            var error = commandRuntimeMock.ErrorStream[0];
            Assert.Equal("Run Connect-AzureRmAccount to login.", error.Exception.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListAzureContextNoLogin()
        {
            var cmdlt = new GetAzureRMContextCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;
            cmdlt.DisableDataCollection();
            cmdlt.ListAvailable = true;
            var profile = AzureRmProfileProvider.Instance.Profile;
            AzureRmProfileProvider.Instance.Profile = new AzureRmProfile();

            try
            {
                // Act
                cmdlt.InvokeBeginProcessing();
                cmdlt.ExecuteCmdlet();
                cmdlt.InvokeEndProcessing();
            }
            finally
            {
                AzureRmProfileProvider.Instance.Profile = profile;
            }

            // Verify
            Assert.Equal(0, commandRuntimeMock.OutputPipeline.Count);
            Assert.True(commandRuntimeMock.ErrorStream.Count == 1);
            var error = commandRuntimeMock.ErrorStream[0];
            Assert.Equal("Run Connect-AzureRmAccount to login.", error.Exception.Message);
        }



        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureContextWithNoSubscriptionAndTenant()
        {
            var cmdlt = new SetAzureRMContextCommand();
            var tenantToSet = "72f988bf-86f1-41af-91ab-2d7cd011db47";

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Make sure that the tenant ID we are attempting to set is
            // valid for the account
            var account = AzureRmProfileProvider.Instance.Profile.DefaultContext.Account;
            var existingTenants = account.GetProperty(AzureAccount.Property.Tenants);
            var allowedTenants = existingTenants == null ? tenantToSet : existingTenants + "," + tenantToSet;
            account.SetProperty(AzureAccount.Property.Tenants, allowedTenants);
            account.SetProperty(AzureAccount.Property.Subscriptions, new string[0]);

            cmdlt.Tenant = tenantToSet;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);
            var context = (PSAzureContext)commandRuntimeMock.OutputPipeline[0];

            // TenantId is not sufficient to change the context.
            Assert.NotEqual(tenantToSet, context.Tenant.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectAzureContextWithNoSubscriptionAndNoTenant()
        {
            var cmdlt = new SetAzureRMContextCommand();

            // Setup
            cmdlt.CommandRuntime = commandRuntimeMock;

            // Act
            cmdlt.InvokeBeginProcessing();
            cmdlt.ExecuteCmdlet();
            cmdlt.InvokeEndProcessing();

            // Verify
            Assert.True(commandRuntimeMock.OutputPipeline.Count == 1);
            var context = (PSAzureContext)commandRuntimeMock.OutputPipeline[0];
            Assert.NotNull(context);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListMultipleContexts()
        {
            var cmdlet = new GetAzureRMContextCommand();
            var profile = CreateMultipleContextProfile();
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.ListAvailable = true;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.True(commandRuntimeMock.OutputPipeline != null && commandRuntimeMock.OutputPipeline.Count == profile.Contexts.Count);
            foreach (var output in commandRuntimeMock.OutputPipeline)
            {
                PSAzureContext testContext = output as PSAzureContext;
                Assert.NotNull(testContext);
                Assert.NotNull(testContext.Name);
                Assert.True(profile.Contexts.ContainsKey(testContext.Name));
                var validateContext = profile.Contexts[testContext.Name];
                Assert.NotNull(validateContext);
                Assert.True(validateContext.IsEqual(testContext));
                profile.TryRemoveContext(testContext.Name);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveDefaultContext()
        {
            var cmdlet = new RemoveAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var defaultContext = profile.DefaultContext;
            var defaultContextName = profile.DefaultContextKey;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.Force = true;
            cmdlet.PassThru = true;
            cmdlet.MyInvocation.BoundParameters.Add("Name", profile.DefaultContextKey);
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.True(commandRuntimeMock.OutputPipeline != null && commandRuntimeMock.OutputPipeline.Count ==1);
            PSAzureContext testContext = commandRuntimeMock.OutputPipeline[0] as PSAzureContext;
            Assert.NotNull(testContext);
            Assert.NotNull(testContext.Name);
            Assert.True(defaultContext.IsEqual(testContext));
            Assert.False(profile.Contexts.ContainsKey(defaultContextName));
            Assert.False(profile.Contexts.Any(c => defaultContext.IsEqual(c.Value)));
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.NotNull(profile.DefaultContext);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveNonDefaultContext()
        {
            var cmdlet = new RemoveAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var removedContextKey = profile.Contexts.Keys.First(k => !string.Equals(k, profile.DefaultContextKey));
            var removedContext = profile.Contexts[removedContextKey];
            var defaultContextKey = profile.DefaultContextKey;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.PassThru = true;
            cmdlet.MyInvocation.BoundParameters.Add("Name", removedContextKey);
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.True(commandRuntimeMock.OutputPipeline != null && commandRuntimeMock.OutputPipeline.Count == 1);
            PSAzureContext testContext = commandRuntimeMock.OutputPipeline[0] as PSAzureContext;
            Assert.NotNull(testContext);
            Assert.NotNull(testContext.Name);
            Assert.True(removedContext.IsEqual(testContext));
            Assert.False(profile.Contexts.ContainsKey(removedContextKey));
            Assert.False(profile.Contexts.Any(c => removedContext.IsEqual(c.Value)));
            Assert.Equal(defaultContextKey, profile.DefaultContextKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveNonExistentContext()
        {
            var cmdlet = new RemoveAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var removedContextKey = "This context does not exist";
            var defaultContextKey = profile.DefaultContextKey;
            var contextCount = profile.Contexts.Count;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.PassThru = true;
            cmdlet.MyInvocation.BoundParameters.Add("Name", removedContextKey);
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(0, commandRuntimeMock.OutputPipeline.Count);
            Assert.Equal(contextCount, profile.Contexts.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RemoveContextNoLogin()
        {
            var cmdlet = new RemoveAzureRmContext();
            var profile = new AzureRmProfile();
            var removedContextKey = "This context does not exist";
            var defaultContextKey = profile.DefaultContextKey;
            var contextCount = profile.Contexts.Count;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.PassThru = true;
            cmdlet.MyInvocation.BoundParameters.Add("Name", removedContextKey);
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(0, commandRuntimeMock.OutputPipeline.Count);
            Assert.Equal(contextCount, profile.Contexts.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectDefaultContext()
        {
            var cmdlet = new SelectAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var defaultContext = profile.DefaultContext;
            var defaultContextName = profile.DefaultContextKey;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.MyInvocation.BoundParameters.Add("Name", profile.DefaultContextKey);
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            PSAzureContext testContext = commandRuntimeMock.OutputPipeline[0] as PSAzureContext;
            Assert.NotNull(testContext);
            Assert.NotNull(testContext.Name);
            Assert.True(defaultContext.IsEqual(testContext));
            Assert.True(profile.Contexts.ContainsKey(defaultContextName));
            Assert.True(defaultContext.IsEqual(profile.DefaultContext));
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.Equal(defaultContextName, profile.DefaultContextKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectNonDefaultContext()
        {
            var cmdlet = new SelectAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var selectedContextName = profile.Contexts.Keys.First(k => !string.Equals(k, profile.DefaultContextKey));
            var selectedContext = profile.Contexts[selectedContextName];
            Assert.NotNull(selectedContext);
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.MyInvocation.BoundParameters.Add("Name", selectedContextName);
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            PSAzureContext testContext = commandRuntimeMock.OutputPipeline[0] as PSAzureContext;
            Assert.NotNull(testContext);
            Assert.NotNull(testContext.Name);
            Assert.True(selectedContext.IsEqual(testContext));
            Assert.True(profile.Contexts.ContainsKey(selectedContextName));
            Assert.True(selectedContext.IsEqual(profile.DefaultContext));
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.Equal(selectedContextName, profile.DefaultContextKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SelectNonExistentContext()
        {
            var cmdlet = new SelectAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var defaultContext = profile.DefaultContext;
            var defaultContextName = profile.DefaultContextKey;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.MyInvocation.BoundParameters.Add("Name", "This context does not exist");
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            PSAzureContext testContext = commandRuntimeMock.OutputPipeline[0] as PSAzureContext;
            Assert.NotNull(testContext);
            Assert.NotNull(testContext.Name);
            Assert.True(defaultContext.IsEqual(testContext));
            Assert.True(profile.Contexts.ContainsKey(defaultContextName));
            Assert.True(defaultContext.IsEqual(profile.DefaultContext));
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.Equal(defaultContextName, profile.DefaultContextKey);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RenameDefaultContext()
        {
            var cmdlet = new RenameAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var defaultContext = profile.DefaultContext;
            var newContextName = "New Context Name";
            var contextCount = profile.Contexts.Count;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.MyInvocation.BoundParameters.Add("SourceName", profile.DefaultContextKey);
            cmdlet.MyInvocation.BoundParameters.Add("TargetName", newContextName);
            cmdlet.PassThru = true;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            PSAzureContext testContext = commandRuntimeMock.OutputPipeline[0] as PSAzureContext;
            Assert.NotNull(testContext);
            Assert.NotNull(testContext.Name);
            Assert.True(defaultContext.IsEqual(testContext));
            Assert.True(profile.Contexts.ContainsKey(newContextName));
            Assert.True(defaultContext.IsEqual(profile.DefaultContext));
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.Equal(newContextName, profile.DefaultContextKey);
            Assert.Equal(contextCount, profile.Contexts.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RenameNonDefaultContext()
        {
            var cmdlet = new RenameAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var defaultContext = profile.DefaultContext;
            var defaultContextName = profile.DefaultContextKey;
            var contextNameToRename = profile.Contexts.Keys.First(k => !string.Equals(profile.DefaultContextKey, k));
            var contextToRename = profile.Contexts[contextNameToRename];
            var newContextName = "New Context Name";
            var contextCount = profile.Contexts.Count;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.MyInvocation.BoundParameters.Add("SourceName", contextNameToRename);
            cmdlet.MyInvocation.BoundParameters.Add("TargetName", newContextName);
            cmdlet.PassThru = true;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            PSAzureContext testContext = commandRuntimeMock.OutputPipeline[0] as PSAzureContext;
            Assert.NotNull(testContext);
            Assert.NotNull(testContext.Name);
            Assert.True(contextToRename.IsEqual(testContext));
            Assert.True(profile.Contexts.ContainsKey(newContextName));
            Assert.True(contextToRename.IsEqual(profile.Contexts[newContextName]));
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.Equal(defaultContextName, profile.DefaultContextKey);
            Assert.True(defaultContext.IsEqual(profile.DefaultContext));
            Assert.Equal(contextCount, profile.Contexts.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RenameOverwritesDefaultContext()
        {
            var cmdlet = new RenameAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var defaultContext = profile.DefaultContext;
            var defaultContextName = profile.DefaultContextKey;
            var contextNameToRename = profile.Contexts.Keys.First(k => !string.Equals(profile.DefaultContextKey, k));
            var contextToRename = profile.Contexts[contextNameToRename];
            var newContextName = defaultContextName;
            var contextCount = profile.Contexts.Count;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.MyInvocation.BoundParameters.Add("SourceName", contextNameToRename);
            cmdlet.MyInvocation.BoundParameters.Add("TargetName", newContextName);
            cmdlet.PassThru = true;
            cmdlet.Force = true;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            PSAzureContext testContext = commandRuntimeMock.OutputPipeline[0] as PSAzureContext;
            Assert.NotNull(testContext);
            Assert.NotNull(testContext.Name);
            Assert.True(contextToRename.IsEqual(testContext));
            Assert.True(profile.Contexts.ContainsKey(newContextName));
            Assert.True(contextToRename.IsEqual(profile.Contexts[newContextName]));
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.Equal(defaultContextName, profile.DefaultContextKey);
            Assert.True(contextToRename.IsEqual(profile.DefaultContext));
            Assert.Equal(contextCount - 1, profile.Contexts.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RenameNonExistentContext()
        {
            var cmdlet = new RenameAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var defaultContext = profile.DefaultContext;
            var defaultContextName = profile.DefaultContextKey;
            var contextNameToRename = profile.Contexts.Keys.First(k => !string.Equals(profile.DefaultContextKey, k));
            var contextToRename = profile.Contexts[contextNameToRename];
            var contextCount = profile.Contexts.Count;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.MyInvocation.BoundParameters.Add("SourceName", "This context does not exist");
            cmdlet.MyInvocation.BoundParameters.Add("TargetName", contextNameToRename);
            cmdlet.PassThru = true;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(0, commandRuntimeMock.OutputPipeline.Count);
            Assert.True(profile.Contexts.ContainsKey(contextNameToRename));
            Assert.True(contextToRename.IsEqual(profile.Contexts[contextNameToRename]));
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.Equal(defaultContextName, profile.DefaultContextKey);
            Assert.True(defaultContext.IsEqual(profile.DefaultContext));
            Assert.Equal(contextCount, profile.Contexts.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RenameContextSameName()
        {
            var cmdlet = new RenameAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var defaultContext = profile.DefaultContext;
            var defaultContextName = profile.DefaultContextKey;
            var contextNameToRename = profile.Contexts.Keys.First(k => !string.Equals(profile.DefaultContextKey, k));
            var contextToRename = profile.Contexts[contextNameToRename];
            var newContextName = contextNameToRename;
            var contextCount = profile.Contexts.Count;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.MyInvocation.BoundParameters.Add("SourceName", contextNameToRename);
            cmdlet.MyInvocation.BoundParameters.Add("TargetName", newContextName);
            cmdlet.PassThru = true;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(0, commandRuntimeMock.OutputPipeline.Count);
            Assert.True(profile.Contexts.ContainsKey(newContextName));
            Assert.True(contextToRename.IsEqual(profile.Contexts[newContextName]));
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.Equal(defaultContextName, profile.DefaultContextKey);
            Assert.True(defaultContext.IsEqual(profile.DefaultContext));
            Assert.Equal(contextCount, profile.Contexts.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RenameContextNoLogin()
        {
            var cmdlet = new RenameAzureRmContext();
            var profile = new AzureRmProfile();
            var defaultContextName = profile.DefaultContextKey;
            var contextCount = profile.Contexts.Count;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.MyInvocation.BoundParameters.Add("SourceName", "Default");
            cmdlet.MyInvocation.BoundParameters.Add("TargetName", "target context");
            cmdlet.PassThru = true;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(0, commandRuntimeMock.OutputPipeline.Count);
            Assert.False(string.IsNullOrEmpty(profile.DefaultContextKey));
            Assert.Equal(defaultContextName, profile.DefaultContextKey);
            Assert.Equal(contextCount, profile.Contexts.Count);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ClearMultipleContexts()
        {
            var cmdlet = new ClearAzureRmContext();
            var profile = CreateMultipleContextProfile();
            var defaultContext = profile.DefaultContext;
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.Scope = ContextModificationScope.Process;
            cmdlet.PassThru = true;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            bool testResult = (bool)commandRuntimeMock.OutputPipeline[0];
            Assert.True(testResult);
            Assert.Equal(1, profile.Contexts.Count);
            Assert.NotNull(profile.DefaultContext);
            Assert.Null(profile.DefaultContext.Account);
            Assert.Null(profile.DefaultContext.Subscription);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ClearContextNoLogin()
        {
            var cmdlet = new ClearAzureRmContext();
            var profile = new AzureRmProfile();
            cmdlet.CommandRuntime = commandRuntimeMock;
            cmdlet.DefaultProfile = profile;
            cmdlet.PassThru = true;
            cmdlet.Scope = ContextModificationScope.Process;
            cmdlet.InvokeBeginProcessing();
            cmdlet.ExecuteCmdlet();
            cmdlet.InvokeEndProcessing();
            Assert.NotNull(commandRuntimeMock.OutputPipeline);
            Assert.Equal(1, commandRuntimeMock.OutputPipeline.Count);
            bool testResult = (bool)commandRuntimeMock.OutputPipeline[0];
            Assert.True(testResult);
            Assert.Equal(1, profile.Contexts.Count);
            Assert.NotNull(profile.DefaultContext);
            Assert.Null(profile.DefaultContext.Account);
            Assert.Null(profile.DefaultContext.Subscription);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ImportContextNoDefaultKey()
        {
            var serializedContext = @"{
  ""EnvironmentTable"": {
    ""testCloud"": {
      ""Name"": ""testCloud"",
      ""OnPremise"": false,
      ""ServiceManagementUrl"": null,
      ""ResourceManagerUrl"": null,
      ""ManagementPortalUrl"": null,
      ""PublishSettingsFileUrl"": null,
      ""ActiveDirectoryAuthority"": ""http://contoso.com"",
      ""GalleryUrl"": null,
      ""GraphUrl"": null,
      ""ActiveDirectoryServiceEndpointResourceId"": null,
      ""StorageEndpointSuffix"": null,
      ""SqlDatabaseDnsSuffix"": null,
      ""TrafficManagerDnsSuffix"": null,
      ""AzureKeyVaultDnsSuffix"": null,
      ""AzureKeyVaultServiceEndpointResourceId"": null,
      ""GraphEndpointResourceId"": null,
      ""DataLakeEndpointResourceId"": null,
      ""AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix"": null,
      ""AzureDataLakeStoreFileSystemEndpointSuffix"": null,
      ""AdTenant"": null,
      ""VersionProfiles"": [],
      ""ExtendedProperties"": {}
    }
  },
  ""Contexts"": {
    ""Default"": {
      ""Account"": {
        ""Id"": ""me@contoso.com"",
        ""Credential"": null,
        ""Type"": ""User"",
        ""TenantMap"": {},
        ""ExtendedProperties"": {
          ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6""
        }
      },
      ""Tenant"": {
        ""Id"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6"",
        ""Directory"": ""contoso.com"",
        ""ExtendedProperties"": {}
      },
      ""Subscription"": {
        ""Id"": ""00000000-0000-0000-0000-000000000000"",
        ""Name"": ""Contoso Test Subscription"",
        ""State"": ""Enabled"",
        ""ExtendedProperties"": {
          ""Account"": ""me@contoso.com"",
          ""Tenants"": ""3c0ff8a7-e8bb-40e8-ae66-271343379af6"",
          ""Environment"": ""testCloud""
        }
      },
      ""Environment"": {
        ""Name"": ""testCloud"",
        ""OnPremise"": false,
        ""ServiceManagementUrl"": null,
        ""ResourceManagerUrl"": null,
        ""ManagementPortalUrl"": null,
        ""PublishSettingsFileUrl"": null,
        ""ActiveDirectoryAuthority"": ""http://contoso.com"",
        ""GalleryUrl"": null,
        ""GraphUrl"": null,
        ""ActiveDirectoryServiceEndpointResourceId"": null,
        ""StorageEndpointSuffix"": null,
        ""SqlDatabaseDnsSuffix"": null,
        ""TrafficManagerDnsSuffix"": null,
        ""AzureKeyVaultDnsSuffix"": null,
        ""AzureKeyVaultServiceEndpointResourceId"": null,
        ""GraphEndpointResourceId"": null,
        ""DataLakeEndpointResourceId"": null,
        ""AzureDataLakeAnalyticsCatalogAndJobEndpointSuffix"": null,
        ""AzureDataLakeStoreFileSystemEndpointSuffix"": null,
        ""AdTenant"": null,
        ""VersionProfiles"": [],
        ""ExtendedProperties"": {}
      },
      ""VersionProfile"": null,
      ""TokenCache"": {
        ""CacheData"": ""AgAAAAAAAAA=""
      },
      ""ExtendedProperties"": {}
    }
  },
  ""ExtendedProperties"": {}
}";
            var oldDataStore = AzureSession.Instance.DataStore;
            var store = new MemoryDataStore();
            var filePath = "c:\\myfile.json";
            store.VirtualStore[filePath] = serializedContext;
            try
            {
                AzureSession.Instance.DataStore = store;
                var cmdlet = new ImportAzureRMContextCommand();
                cmdlet.CommandRuntime = commandRuntimeMock;
                cmdlet.Path = filePath;
                cmdlet.DefaultProfile = new AzureRmProfile();
                cmdlet.MyInvocation.BoundParameters.Add("Path", filePath);
                cmdlet.InvokeBeginProcessing();
                cmdlet.ExecuteCmdlet();
                cmdlet.InvokeEndProcessing();

                var profile = cmdlet.DefaultProfile as AzureRmProfile;
                Assert.NotNull(profile);
                Assert.NotNull(profile.DefaultContextKey);
                var context = profile.DefaultContext;
                Assert.NotNull(context);
                var account = context.Account;
                Assert.NotNull(account);
                Assert.Equal("me@contoso.com", account.Id);
                Assert.Equal("User", account.Type);
                Assert.Contains("3c0ff8a7-e8bb-40e8-ae66-271343379af6", account.GetTenants());
                Assert.NotNull(context.Tenant);
                Assert.Equal("3c0ff8a7-e8bb-40e8-ae66-271343379af6", context.Tenant.Id);
                var subscription = context.Subscription;
                Assert.NotNull(subscription);
                Assert.Equal("Contoso Test Subscription", subscription.Name);
                Assert.Equal(Guid.Empty.ToString(), subscription.Id);
                Assert.NotNull(context.Environment);
                Assert.Equal("testCloud", context.Environment.Name);
                Assert.Equal(5, profile.EnvironmentTable.Count);
            }
            finally
            {
                AzureSession.Instance.DataStore = oldDataStore;
            }
        }

        AzureRmProfile CreateMultipleContextProfile()
        {
            var profile = new AzureRmProfile();
            string contextName1;
            var context1 = (new AzureContext { Environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureCloud] })
                .WithAccount(new AzureAccount { Id = "user1@contoso.com" })
                .WithTenant(new AzureTenant { Id = Guid.NewGuid().ToString(), Directory = "contoso.com" })
                .WithSubscription(new AzureSubscription { Id = Guid.NewGuid().ToString(), Name = "Contoso Subscription 1" });
            profile.TryAddContext(context1, out contextName1);
            string contextName2;
            var context2 = (new AzureContext { Environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureChinaCloud] })
                .WithAccount(new AzureAccount { Id = "user2@contoso.cn" })
                .WithTenant(new AzureTenant { Id = Guid.NewGuid().ToString(), Directory = "contoso.cn" })
                .WithSubscription(new AzureSubscription { Id = Guid.NewGuid().ToString(), Name = "Contoso Subscription 2" });
            profile.TryAddContext(context2, out contextName2);
            string contextName3;
            var context3 = (new AzureContext { Environment = AzureEnvironment.PublicEnvironments[EnvironmentName.AzureGermanCloud] })
                .WithAccount(new AzureAccount { Id = "user3@contoso.de" })
                .WithTenant(new AzureTenant { Id = Guid.NewGuid().ToString(), Directory = "contoso.de" })
                .WithSubscription(new AzureSubscription { Id = Guid.NewGuid().ToString(), Name = "Contoso Subscription 3" });
            profile.TryAddContext(context3, out contextName3);
            profile.TrySetDefaultContext(context1);
            return profile;
        }
    }
}
