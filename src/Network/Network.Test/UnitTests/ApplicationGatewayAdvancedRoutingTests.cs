// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class ApplicationGatewayAdvancedRoutingTests
    {
        private const string PoolId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/applicationGateways/appgw/backendAddressPools/pool01";
        private const string SettingsId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/applicationGateways/appgw/backendHttpSettingsCollection/settings01";
        private const string ConditionSetId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/applicationGateways/appgw/advancedRoutingConditionSets/cs01";
        private const string MapId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/applicationGateways/appgw/advancedRoutingMaps/map01";

        private static PSApplicationGatewayAdvancedRoutingMap BuildMap()
        {
            return new PSApplicationGatewayAdvancedRoutingMap
            {
                Name = "map01",
                Id = MapId,
                DefaultBackendAddressPool = new PSResourceId { Id = PoolId },
                DefaultBackendHttpSettings = new PSResourceId { Id = SettingsId },
                AdvancedRoutingRules = new List<PSApplicationGatewayAdvancedRoutingRule>
                {
                    new PSApplicationGatewayAdvancedRoutingRule
                    {
                        Name = "rule01",
                        Priority = 100,
                        AdvancedRoutingConditionSet = new PSResourceId { Id = ConditionSetId },
                        BackendAddressPool = new PSResourceId { Id = PoolId },
                        BackendHttpSettings = new PSResourceId { Id = SettingsId }
                    }
                }
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AdvancedRoutingMapIsMappedOntoNestedSdkProperties()
        {
            var sdkMap = NetworkResourceManagerProfile.Mapper.Map<ApplicationGatewayAdvancedRoutingMap>(BuildMap());

            Assert.Equal("map01", sdkMap.Name);
            Assert.Equal(MapId, sdkMap.Id);

            // Unlike other application gateway child resources, this model nests its payload under Properties.
            Assert.NotNull(sdkMap.Properties);
            Assert.Equal(PoolId, sdkMap.Properties.DefaultBackendAddressPool.Id);
            Assert.Equal(SettingsId, sdkMap.Properties.DefaultBackendHttpSettings.Id);

            var sdkRule = Assert.Single(sdkMap.Properties.AdvancedRoutingRules);
            Assert.Equal("rule01", sdkRule.Name);
            Assert.NotNull(sdkRule.Properties);
            Assert.Equal(100, sdkRule.Properties.Priority);
            Assert.Equal(ConditionSetId, sdkRule.Properties.AdvancedRoutingConditionSet.Id);
            Assert.Equal(PoolId, sdkRule.Properties.BackendAddressPool.Id);
            Assert.Equal(SettingsId, sdkRule.Properties.BackendHttpSettings.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AdvancedRoutingMapRoundTripsThroughSdkMapping()
        {
            var sdkMap = NetworkResourceManagerProfile.Mapper.Map<ApplicationGatewayAdvancedRoutingMap>(BuildMap());
            var psMap = NetworkResourceManagerProfile.Mapper.Map<PSApplicationGatewayAdvancedRoutingMap>(sdkMap);

            Assert.Equal("map01", psMap.Name);
            Assert.Equal(PoolId, psMap.DefaultBackendAddressPool.Id);
            Assert.Equal(SettingsId, psMap.DefaultBackendHttpSettings.Id);

            var psRule = Assert.Single(psMap.AdvancedRoutingRules);
            Assert.Equal("rule01", psRule.Name);
            Assert.Equal(100, psRule.Priority);
            Assert.Equal(ConditionSetId, psRule.AdvancedRoutingConditionSet.Id);
            Assert.Equal(PoolId, psRule.BackendAddressPool.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AdvancedRoutingMapSupportsRedirectInsteadOfBackend()
        {
            const string redirectId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/applicationGateways/appgw/redirectConfigurations/redirect01";
            var map = new PSApplicationGatewayAdvancedRoutingMap
            {
                Name = "map01",
                DefaultRedirectConfiguration = new PSResourceId { Id = redirectId },
                AdvancedRoutingRules = new List<PSApplicationGatewayAdvancedRoutingRule>()
            };

            var sdkMap = NetworkResourceManagerProfile.Mapper.Map<ApplicationGatewayAdvancedRoutingMap>(map);

            Assert.Equal(redirectId, sdkMap.Properties.DefaultRedirectConfiguration.Id);
            Assert.Null(sdkMap.Properties.DefaultBackendAddressPool);
            Assert.Null(sdkMap.Properties.DefaultBackendHttpSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AdvancedRoutingConditionSetRoundTripsWithPropertyValueMatcher()
        {
            var conditionSet = new PSApplicationGatewayAdvancedRoutingConditionSet
            {
                Name = "cs01",
                Id = ConditionSetId,
                RoutingConditions = new List<PSApplicationGatewayAdvancedRoutingCondition>
                {
                    new PSApplicationGatewayAdvancedRoutingCondition
                    {
                        ConditionType = "Header",
                        PropertyName = "X-Region",
                        PropertyValueMatcher = new PSApplicationGatewayAdvancedRoutingPropertyValueMatcher
                        {
                            Pattern = "^emea$",
                            IgnoreCase = true,
                            Negate = false
                        }
                    }
                }
            };

            var sdkSet = NetworkResourceManagerProfile.Mapper.Map<ApplicationGatewayAdvancedRoutingConditionSet>(conditionSet);

            Assert.NotNull(sdkSet.Properties);
            var sdkCondition = Assert.Single(sdkSet.Properties.RoutingConditions);
            Assert.Equal("Header", sdkCondition.ConditionType);
            Assert.Equal("X-Region", sdkCondition.PropertyName);
            Assert.Equal("^emea$", sdkCondition.PropertyValueMatcher.Pattern);
            Assert.True(sdkCondition.PropertyValueMatcher.IgnoreCase);
            Assert.False(sdkCondition.PropertyValueMatcher.Negate);

            var psSet = NetworkResourceManagerProfile.Mapper.Map<PSApplicationGatewayAdvancedRoutingConditionSet>(sdkSet);
            var psCondition = Assert.Single(psSet.RoutingConditions);
            Assert.Equal("Header", psCondition.ConditionType);
            Assert.Equal("^emea$", psCondition.PropertyValueMatcher.Pattern);
            Assert.True(psCondition.PropertyValueMatcher.IgnoreCase);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AdvancedRoutingConditionSetRoundTripsWithPropertyValues()
        {
            var conditionSet = new PSApplicationGatewayAdvancedRoutingConditionSet
            {
                Name = "cs01",
                RoutingConditions = new List<PSApplicationGatewayAdvancedRoutingCondition>
                {
                    new PSApplicationGatewayAdvancedRoutingCondition
                    {
                        ConditionType = "QueryString",
                        PropertyName = "region",
                        PropertyValues = new List<string> { "emea", "apac" }
                    }
                }
            };

            var sdkSet = NetworkResourceManagerProfile.Mapper.Map<ApplicationGatewayAdvancedRoutingConditionSet>(conditionSet);
            var sdkCondition = Assert.Single(sdkSet.Properties.RoutingConditions);
            Assert.Equal(new[] { "emea", "apac" }, sdkCondition.PropertyValues);
            Assert.Null(sdkCondition.PropertyValueMatcher);

            var psSet = NetworkResourceManagerProfile.Mapper.Map<PSApplicationGatewayAdvancedRoutingConditionSet>(sdkSet);
            var psCondition = Assert.Single(psSet.RoutingConditions);
            Assert.Equal(new[] { "emea", "apac" }, psCondition.PropertyValues);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void RequestRoutingRuleAdvancedRoutingMapIsPreservedThroughSdkMapping()
        {
            var rule = new PSApplicationGatewayRequestRoutingRule
            {
                Name = "rule01",
                RuleType = "AdvancedRouting",
                Priority = 100,
                AdvancedRoutingMap = new PSResourceId { Id = MapId }
            };

            var sdkRule = NetworkResourceManagerProfile.Mapper.Map<ApplicationGatewayRequestRoutingRule>(rule);
            Assert.Equal("AdvancedRouting", sdkRule.RuleType);
            Assert.Equal(MapId, sdkRule.AdvancedRoutingMap.Id);

            var psRule = NetworkResourceManagerProfile.Mapper.Map<PSApplicationGatewayRequestRoutingRule>(sdkRule);
            Assert.Equal("AdvancedRouting", psRule.RuleType);
            Assert.Equal(MapId, psRule.AdvancedRoutingMap.Id);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ApplicationGatewayCarriesAdvancedRoutingCollections()
        {
            var gateway = new PSApplicationGateway
            {
                Name = "appgw",
                AdvancedRoutingMaps = new List<PSApplicationGatewayAdvancedRoutingMap> { BuildMap() },
                AdvancedRoutingConditionSets = new List<PSApplicationGatewayAdvancedRoutingConditionSet>
                {
                    new PSApplicationGatewayAdvancedRoutingConditionSet
                    {
                        Name = "cs01",
                        RoutingConditions = new List<PSApplicationGatewayAdvancedRoutingCondition>
                        {
                            new PSApplicationGatewayAdvancedRoutingCondition { ConditionType = "Path", PropertyValues = new List<string> { "/api" } }
                        }
                    }
                }
            };

            var sdkGateway = NetworkResourceManagerProfile.Mapper.Map<ApplicationGateway>(gateway);

            var sdkMap = Assert.Single(sdkGateway.AdvancedRoutingMaps);
            Assert.Equal("map01", sdkMap.Name);
            Assert.Equal(100, sdkMap.Properties.AdvancedRoutingRules[0].Properties.Priority);

            var sdkSet = Assert.Single(sdkGateway.AdvancedRoutingConditionSets);
            Assert.Equal("Path", sdkSet.Properties.RoutingConditions[0].ConditionType);

            var psGateway = NetworkResourceManagerProfile.Mapper.Map<PSApplicationGateway>(sdkGateway);
            Assert.Single(psGateway.AdvancedRoutingMaps);
            Assert.Single(psGateway.AdvancedRoutingConditionSets);
            Assert.Equal(100, psGateway.AdvancedRoutingMaps[0].AdvancedRoutingRules[0].Priority);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAdvancedRoutingConditionBuildsMatcherFromPattern()
        {
            var command = new NewAzureApplicationGatewayAdvancedRoutingConditionCommand
            {
                ConditionType = "Header",
                PropertyName = "X-Region",
                Pattern = "^emea$",
                IgnoreCase = true,
                Negate = true
            };

            var condition = command.NewObject();

            Assert.Equal("Header", condition.ConditionType);
            Assert.Equal("X-Region", condition.PropertyName);
            Assert.Null(condition.PropertyValues);
            Assert.Equal("^emea$", condition.PropertyValueMatcher.Pattern);
            Assert.True(condition.PropertyValueMatcher.IgnoreCase);
            Assert.True(condition.PropertyValueMatcher.Negate);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAdvancedRoutingConditionUsesPropertyValuesWhenSupplied()
        {
            var command = new NewAzureApplicationGatewayAdvancedRoutingConditionCommand
            {
                ConditionType = "QueryString",
                PropertyName = "region",
                PropertyValues = new[] { "emea", "apac" }
            };

            var condition = command.NewObject();

            Assert.Equal(new[] { "emea", "apac" }, condition.PropertyValues);
            Assert.Null(condition.PropertyValueMatcher);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAdvancedRoutingConditionRequiresPropertyNameForHeaderAndQueryString()
        {
            foreach (var conditionType in new[] { "Header", "QueryString" })
            {
                var command = new NewAzureApplicationGatewayAdvancedRoutingConditionCommand
                {
                    ConditionType = conditionType,
                    PropertyValues = new[] { "emea" }
                };

                var ex = Assert.Throws<PSArgumentException>(() => command.NewObject());
                Assert.Contains("PropertyName is required", ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAdvancedRoutingConditionRejectsPropertyNameWhenNotApplicable()
        {
            foreach (var conditionType in new[] { "Path", "ClientIP", "Method" })
            {
                var command = new NewAzureApplicationGatewayAdvancedRoutingConditionCommand
                {
                    ConditionType = conditionType,
                    PropertyName = "X-Region",
                    PropertyValues = new[] { "emea" }
                };

                var ex = Assert.Throws<PSArgumentException>(() => command.NewObject());
                Assert.Contains("PropertyName is not applicable", ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAdvancedRoutingConditionRejectsPatternForClientIpAndMethod()
        {
            foreach (var conditionType in new[] { "ClientIP", "Method" })
            {
                var command = new NewAzureApplicationGatewayAdvancedRoutingConditionCommand
                {
                    ConditionType = conditionType,
                    Pattern = "^10\\..*"
                };

                var ex = Assert.Throws<PSArgumentException>(() => command.NewObject());
                Assert.Contains("Pattern is not applicable", ex.Message);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAdvancedRoutingRuleConfigSupportsRedirect()
        {
            const string redirectId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Network/applicationGateways/appgw/redirectConfigurations/redirect01";
            var command = new NewAzureApplicationGatewayAdvancedRoutingRuleConfigCommand
            {
                Name = "rule01",
                Priority = 100,
                RedirectConfigurationId = redirectId
            };

            var rule = command.NewObject();

            Assert.Equal(redirectId, rule.RedirectConfiguration.Id);
            Assert.Null(rule.BackendAddressPool);
            Assert.Null(rule.BackendHttpSettings);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AdvancedRoutingRuleConfigSeparatesBackendAndRedirectParameterSets()
        {
            var cmdletType = typeof(NewAzureApplicationGatewayAdvancedRoutingRuleConfigCommand);

            var setsFor = new Func<string, string[]>(parameterName =>
                cmdletType.GetProperty(parameterName)
                    .GetCustomAttributes(typeof(ParameterAttribute), true)
                    .Cast<ParameterAttribute>()
                    .Select(a => a.ParameterSetName)
                    .ToArray());

            // Backend and redirect parameters must never share a set, otherwise they could be combined.
            foreach (var backendParam in new[] { "BackendAddressPool", "BackendHttpSettings", "BackendAddressPoolId", "BackendHttpSettingsId" })
            {
                foreach (var redirectParam in new[] { "RedirectConfiguration", "RedirectConfigurationId" })
                {
                    Assert.Empty(setsFor(backendParam).Intersect(setsFor(redirectParam)));
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAdvancedRoutingConditionAllowsPathWithoutPropertyName()
        {
            var command = new NewAzureApplicationGatewayAdvancedRoutingConditionCommand
            {
                ConditionType = "Path",
                Pattern = "^/api/.*"
            };

            var condition = command.NewObject();

            Assert.Equal("Path", condition.ConditionType);
            Assert.Null(condition.PropertyName);
            Assert.Equal("^/api/.*", condition.PropertyValueMatcher.Pattern);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void NewAdvancedRoutingRuleConfigResolvesResourceIds()
        {
            var command = new NewAzureApplicationGatewayAdvancedRoutingRuleConfigCommand
            {
                Name = "rule01",
                Priority = 100,
                AdvancedRoutingConditionSetId = ConditionSetId,
                BackendAddressPoolId = PoolId,
                BackendHttpSettingsId = SettingsId
            };

            var rule = command.NewObject();

            Assert.Equal("rule01", rule.Name);
            Assert.Equal(100, rule.Priority);
            Assert.Equal(ConditionSetId, rule.AdvancedRoutingConditionSet.Id);
            Assert.Equal(PoolId, rule.BackendAddressPool.Id);
            Assert.Equal(SettingsId, rule.BackendHttpSettings.Id);
            Assert.Null(rule.RedirectConfiguration);
            Assert.Null(rule.RewriteRuleSet);
        }
    }
}
