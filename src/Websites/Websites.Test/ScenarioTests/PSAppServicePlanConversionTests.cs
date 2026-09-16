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

using Microsoft.Azure.Commands.WebApps.Models.WebApp;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class PSAppServicePlanConversionTests
    {
        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(true, 3)]
        [InlineData(false, 0)]
        [InlineData(null, null)]
        public void WrappingPlanPreservesApiProperties(bool? enabled, int? workerCount)
        {
            var source = new AppServicePlan(
                location: "westus",
                id: "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/serverfarms/plan",
                name: "plan",
                type: "Microsoft.Web/serverfarms",
                systemData: new SystemData(createdBy: "creator"),
                tags: new Dictionary<string, string> { { "environment", "test" } },
                sku: new SkuDescription { Name = "P1v3", Tier = "PremiumV3", Capacity = 3 },
                extendedLocation: new ExtendedLocation(name: "custom-location", type: "CustomLocation"),
                kind: "app",
                identity: new ManagedServiceIdentity(type: ManagedServiceIdentityType.SystemAssigned),
                numberOfWorkers: workerCount,
                elasticScaleEnabled: enabled,
                maximumElasticWorkerCount: workerCount + 5,
                hyperV: enabled,
                kubeEnvironmentProfile: new KubeEnvironmentProfile(
                    id: "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Web/kubeEnvironments/environment",
                    name: "environment",
                    type: "Microsoft.Web/kubeEnvironments"),
                zoneRedundant: enabled,
                asyncScalingEnabled: enabled,
                planDefaultIdentity: new DefaultIdentity(identityType: ManagedServiceIdentityType.SystemAssigned),
                isCustomMode: enabled,
                registryAdapters: new List<RegistryAdapter> { new RegistryAdapter(registryKey: "key") },
                installScripts: new List<InstallScript> { new InstallScript(name: "setup") },
                network: new ServerFarmNetworkSettings(virtualNetworkSubnetId: "/subscriptions/sub/resourceGroups/rg/providers/Microsoft.Network/virtualNetworks/vnet/subnets/subnet"),
                storageMounts: new List<StorageMount> { new StorageMount(name: "content", destinationPath: "C:\\content") },
                rdpEnabled: enabled);

            var result = new PSAppServicePlan(new PSAppServicePlan(source));

            Assert.Equal(source.Id, result.Id);
            Assert.Equal(source.Name, result.Name);
            Assert.Equal(source.Type, result.Type);
            Assert.Equal(source.Location, result.Location);
            Assert.Equal(source.Kind, result.Kind);
            Assert.Same(source.Tags, result.Tags);
            Assert.Same(source.Sku, result.Sku);
            Assert.Same(source.ExtendedLocation, result.ExtendedLocation);
            Assert.Same(source.SystemData, result.SystemData);
            Assert.Same(source.Identity, result.Identity);
            Assert.Equal(source.NumberOfWorkers, result.NumberOfWorkers);
            Assert.Equal(source.ElasticScaleEnabled, result.ElasticScaleEnabled);
            Assert.Equal(source.MaximumElasticWorkerCount, result.MaximumElasticWorkerCount);
            Assert.Equal(source.HyperV, result.HyperV);
            Assert.Same(source.KubeEnvironmentProfile, result.KubeEnvironmentProfile);
            Assert.Equal(source.ZoneRedundant, result.ZoneRedundant);
            Assert.Equal(source.AsyncScalingEnabled, result.AsyncScalingEnabled);
            Assert.Same(source.PlanDefaultIdentity, result.PlanDefaultIdentity);
            Assert.Equal(source.IsCustomMode, result.IsCustomMode);
            Assert.Same(source.RegistryAdapters, result.RegistryAdapters);
            Assert.Same(source.InstallScripts, result.InstallScripts);
            Assert.Same(source.Network, result.Network);
            Assert.Same(source.StorageMounts, result.StorageMounts);
            Assert.Equal(source.RdpEnabled, result.RdpEnabled);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UnspecifiedApiPropertiesRemainUnset()
        {
            var result = new PSAppServicePlan(new AppServicePlan(location: "westus"));

            Assert.Null(result.SystemData);
            Assert.Null(result.ExtendedLocation);
            Assert.Null(result.Identity);
            Assert.Null(result.NumberOfWorkers);
            Assert.Null(result.ElasticScaleEnabled);
            Assert.Null(result.MaximumElasticWorkerCount);
            Assert.Null(result.HyperV);
            Assert.Null(result.KubeEnvironmentProfile);
            Assert.Null(result.ZoneRedundant);
            Assert.Null(result.AsyncScalingEnabled);
            Assert.Null(result.PlanDefaultIdentity);
            Assert.Null(result.IsCustomMode);
            Assert.Null(result.RegistryAdapters);
            Assert.Null(result.InstallScripts);
            Assert.Null(result.Network);
            Assert.Null(result.StorageMounts);
            Assert.Null(result.RdpEnabled);
        }
    }
}
