using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Network;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Moq;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Commands.Network.Test.UnitTests
{
    public class ExpressRouteCrossConnectionMigrationCommandTests
    {
        private const string SubscriptionId = "11111111-1111-1111-1111-111111111111";
        private const string ResourceGroupName = "migration-rg";
        private const string ResourceName = "cross-connection";
        private readonly Mock<ICommandRuntime> runtime = new Mock<ICommandRuntime>();
        private readonly List<object> output = new List<object>();

        public ExpressRouteCrossConnectionMigrationCommandTests()
        {
            AzureSessionInitializer.InitializeAzureSession();
            runtime.Setup(value => value.ShouldProcess(It.IsAny<string>())).Returns(true);
            runtime.Setup(value => value.WriteObject(It.IsAny<object>())).Callback<object>(output.Add);
        }

        public static IEnumerable<object[]> Actions()
        {
            yield return new object[] { typeof(InvokeAzureRMExpressRouteCrossConnectionPrepareMigrationCommand), "prepareCircuitMigration", false };
            yield return new object[] { typeof(InvokeAzureRMExpressRouteCrossConnectionShutDownBgpForMigrationCommand), "shutDownBgpForCircuitMigration", true };
            yield return new object[] { typeof(InvokeAzureRMExpressRouteCrossConnectionMigrateCommand), "migrateCircuit", true };
            yield return new object[] { typeof(InvokeAzureRMExpressRouteCrossConnectionRestoreBgpForMigrationCommand), "restoreBgpForCircuitMigration", true };
            yield return new object[] { typeof(InvokeAzureRMExpressRouteCrossConnectionCommitMigrationCommand), "commitCircuitMigration", false };
            yield return new object[] { typeof(InvokeAzureRMExpressRouteCrossConnectionRollbackMigrationCommand), "rollbackCircuitMigration", true };
        }

        public static IEnumerable<object[]> ActionRoutes() => Actions().Select(action => action.Take(2).ToArray());

        public static IEnumerable<object[]> ActionTypes() => Actions().Select(action => action.Take(1).ToArray());

        [Theory]
        [MemberData(nameof(Actions))]
        public void ActionRoutesRequestAndMapsResult(Type commandType, string operation, bool supportsPort)
        {
            var handler = new MigrationHandler();
            using (var client = CreateClient(handler))
            {
                var command = Configure((ExpressRouteCrossConnectionMigrationActionBaseCmdlet)Activator.CreateInstance(commandType), client);
                command.TargetPeeringLocation = "target-location";
                command.TargetPortMapping = CreateMappings();
                if (supportsPort)
                {
                    ((ExpressRouteCrossConnectionMigrationPortActionBaseCmdlet)command).PortId = "source-port";
                }

                command.Execute();

                AssertRequest(Assert.Single(handler.Requests), operation);
                var body = JObject.Parse(handler.Bodies.Single());
                Assert.Equal("target-location", (string)body["targetPeeringLocation"]);
                Assert.Equal("source-port", (string)body["targetPortMapping"][0]["sourcePortId"]);
                Assert.Equal("target-port", (string)body["targetPortMapping"][0]["targetPortId"]);
                Assert.Equal(supportsPort ? "source-port" : null, (string)body["portId"]);
                AssertHealthResult();
            }
        }

        [Theory]
        [MemberData(nameof(ActionRoutes))]
        public void ActionAllowsOmittedFields(Type commandType, string operation)
        {
            var handler = new MigrationHandler();
            using (var client = CreateClient(handler))
            {
                Configure((ExpressRouteCrossConnectionMigrationActionBaseCmdlet)Activator.CreateInstance(commandType), client).Execute();
                AssertRequest(Assert.Single(handler.Requests), operation);
                Assert.Empty(JObject.Parse(handler.Bodies.Single()).Properties());
            }
        }

        [Theory]
        [MemberData(nameof(ActionTypes))]
        public void DeclinedActionMakesNoRequest(Type commandType)
        {
            runtime.Setup(value => value.ShouldProcess(It.IsAny<string>())).Returns(false);
            var handler = new MigrationHandler();
            using (var client = CreateClient(handler))
            {
                Configure((ExpressRouteCrossConnectionMigrationActionBaseCmdlet)Activator.CreateInstance(commandType), client).Execute();
                Assert.Empty(handler.Requests);
                Assert.Empty(output);
                runtime.Verify(value => value.ShouldProcess(ResourceGroupName + "/" + ResourceName), Times.Once);
            }
        }

        [Theory]
        [MemberData(nameof(ActionRoutes))]
        public void ActionCompletesLongRunningOperation(Type commandType, string operation)
        {
            var handler = new MigrationHandler { Accepted = true };
            using (var client = CreateClient(handler))
            {
                Configure((ExpressRouteCrossConnectionMigrationActionBaseCmdlet)Activator.CreateInstance(commandType), client).Execute();
                AssertRequest(handler.Requests.First(), operation);
                Assert.True(handler.Requests.Count > 1);
                Assert.Equal("/migration-result", handler.Requests.Last().AbsolutePath);
                AssertHealthResult();
            }
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void DiagnosticsUseRequiredRequestAndReturnTypedResult(bool validate)
        {
            var handler = new MigrationHandler();
            using (var client = CreateClient(handler))
            {
                ExpressRouteCrossConnectionMigrationDiagnosticBaseCmdlet command = validate
                    ? (ExpressRouteCrossConnectionMigrationDiagnosticBaseCmdlet)new TestAzureRMExpressRouteCrossConnectionMigrationCommand()
                    : new GetAzureRMExpressRouteCrossConnectionMigrationInfoCommand();
                Configure(command, client);
                command.TargetPeeringLocation = "target-location";
                command.TargetPortMapping = CreateMappings();
                command.Execute();

                AssertRequest(Assert.Single(handler.Requests), validate ? "validateCircuitMigration" : "getCircuitMigrationInfo");
                Assert.Equal("target-location", (string)JObject.Parse(handler.Bodies.Single())["targetPeeringLocation"]);
                if (validate)
                {
                    Assert.Equal("Succeeded", Assert.IsType<PSExpressRouteCircuitMigrationValidationResult>(Assert.Single(output)).Status);
                }
                else
                {
                    AssertHealthResult();
                }
            }
        }

        [Fact]
        public void InvalidMappingsFailBeforeDispatch()
        {
            var invalidMappings = new[]
            {
                new PSExpressRouteCrossConnectionPortMapping[] { null },
                new[] { new PSExpressRouteCrossConnectionPortMapping { SourcePortId = "source" } },
                new[] { new PSExpressRouteCrossConnectionPortMapping { SourcePortId = " ", TargetPortId = "target" } }
            };
            var handler = new MigrationHandler();
            using (var client = CreateClient(handler))
            {
                foreach (var mappings in invalidMappings)
                {
                    var command = Configure(new InvokeAzureRMExpressRouteCrossConnectionPrepareMigrationCommand(), client);
                    command.TargetPortMapping = mappings;
                    Assert.Throws<PSArgumentException>(() => command.Execute());
                }

                Assert.Empty(handler.Requests);
            }
        }

        [Fact]
        public void ServiceFailureIsNotConvertedToSuccess()
        {
            var handler = new MigrationHandler { Fail = true };
            using (var client = CreateClient(handler))
            {
                var command = Configure(new InvokeAzureRMExpressRouteCrossConnectionCommitMigrationCommand(), client);
                Assert.Throws<CloudException>(() => command.Execute());
                Assert.Empty(output);
            }
        }

        [Fact]
        public void MappingHelperReturnsPublicInputType()
        {
            var command = new NewAzureRMExpressRouteCrossConnectionPortMappingCommand
            {
                CommandRuntime = runtime.Object,
                SourcePortId = "source-port",
                TargetPortId = "target-port"
            };
            command.Execute();
            var mapping = Assert.IsType<PSExpressRouteCrossConnectionPortMapping>(Assert.Single(output));
            Assert.Equal("source-port", mapping.SourcePortId);
            Assert.Equal("target-port", mapping.TargetPortId);
        }

        [Fact]
        public void MetadataMatchesPublicContract()
        {
            var types = Actions().Select(action => (Type)action[0]).Concat(new[]
            {
                typeof(TestAzureRMExpressRouteCrossConnectionMigrationCommand),
                typeof(GetAzureRMExpressRouteCrossConnectionMigrationInfoCommand)
            });
            foreach (var type in types)
            {
                var diagnostic = typeof(ExpressRouteCrossConnectionMigrationDiagnosticBaseCmdlet).IsAssignableFrom(type);
                var attribute = type.GetCustomAttribute<CmdletAttribute>();
                Assert.DoesNotContain("Circuit", attribute.NounName);
                Assert.Equal(!diagnostic, attribute.SupportsShouldProcess);
                if (!diagnostic)
                {
                    Assert.Equal(ConfirmImpact.High, attribute.ConfirmImpact);
                }

                Assert.Equal(typeof(SwitchParameter), type.GetProperty("AsJob").PropertyType);
                foreach (var parameter in new[] { "TargetPeeringLocation", "TargetPortMapping" })
                {
                    Assert.Equal(diagnostic, type.GetProperty(parameter).GetCustomAttribute<ParameterAttribute>().Mandatory);
                }

                Assert.True(type.GetProperty("InputObject").GetCustomAttribute<ParameterAttribute>().ValueFromPipeline);
                Assert.True(type.GetProperty("ResourceId").GetCustomAttribute<ParameterAttribute>().ValueFromPipelineByPropertyName);
            }
        }

        private T Configure<T>(T command, INetworkManagementClient client) where T : ExpressRouteCrossConnectionMigrationBaseCmdlet
        {
            command.CommandRuntime = runtime.Object;
            command.NetworkClient = new NetworkClient(client);
            command.ResourceGroupName = ResourceGroupName;
            command.Name = ResourceName;
            return command;
        }

        private static NetworkManagementClient CreateClient(MigrationHandler handler)
        {
            return new NetworkManagementClient(new TokenCredentials("offline-test-token"), handler)
            {
                SubscriptionId = SubscriptionId,
                LongRunningOperationRetryTimeout = 0
            };
        }

        private static PSExpressRouteCrossConnectionPortMapping[] CreateMappings()
        {
            return new[] { new PSExpressRouteCrossConnectionPortMapping { SourcePortId = "source-port", TargetPortId = "target-port" } };
        }

        private static void AssertRequest(Uri request, string operation)
        {
            Assert.Equal($"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Network/expressRouteCrossConnections/{ResourceName}/{operation}", request.AbsolutePath);
            Assert.Equal("?api-version=2026-01-01", request.Query);
        }

        private void AssertHealthResult()
        {
            var result = Assert.IsType<PSExpressRouteCircuitMigrationResult>(Assert.Single(output));
            Assert.Equal("Succeeded", result.Status);
            Assert.Equal("FuturePhase", result.Phase);
            Assert.Equal("12345", result.NewSTag);
            Assert.Equal("/subscriptions/new-cross-connection", result.NewCrossConnectionUrl);
            Assert.Null(result.PreparedAt);
            Assert.Null(result.PrepareExpiryTime);
            Assert.Null(result.ShouldRollback);
            Assert.Equal("service guidance", result.FailureReason);
            var port = Assert.Single(result.Details.PortMigrationInfos);
            Assert.Equal("source-port", port.SourcePortId);
            var peering = Assert.Single(port.Peerings);
            Assert.Equal("FuturePeering", peering.Type);
            Assert.Equal(12.5, Assert.Single(peering.StatsCurrent.Metrics).Value);
            Assert.Null(Assert.Single(peering.StatsAtPrepare.Metrics).Value);
            Assert.Equal("FuturePeering", Assert.Single(port.SourcePortStats.Peerings).Type);
        }

        private sealed class MigrationHandler : DelegatingHandler
        {
            public List<Uri> Requests { get; } = new List<Uri>();
            public List<string> Bodies { get; } = new List<string>();
            public bool Accepted { get; set; }
            public bool Fail { get; set; }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Requests.Add(request.RequestUri);
                if (request.Method == HttpMethod.Post)
                {
                    Bodies.Add(await request.Content.ReadAsStringAsync());
                }

                if (Fail)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        RequestMessage = request,
                        Content = new StringContent("{\"error\":{\"code\":\"InvalidMigrationState\",\"message\":\"Cannot commit.\"}}")
                    };
                }

                if (Accepted && request.Method == HttpMethod.Post)
                {
                    var accepted = new HttpResponseMessage(HttpStatusCode.Accepted) { RequestMessage = request, Content = new StringContent(string.Empty) };
                    accepted.Headers.Location = new Uri("https://management.azure.com/migration-result");
                    accepted.Headers.TryAddWithoutValidation("Retry-After", "0");
                    return accepted;
                }

                var health = JObject.Parse(@"{
                    'status':'Succeeded', 'phase':'FuturePhase', 'newSTag':'12345',
                    'newCrossConnectionUrl':'/subscriptions/new-cross-connection', 'failureReason':'service guidance',
                    'details':{'portMigrationInfos':[{
                        'portId':'target-port', 'sourcePortId':'source-port', 'status':'FutureStatus', 'phase':'FuturePhase',
                        'peerings':[{'type':'FuturePeering',
                            'statsCurrent':{'timestamp':'2026-09-23T12:00:00Z','metrics':[{'name':'packets','value':12.5,'unit':'count'}]},
                            'statsAtPrepare':{'metrics':[{'name':'packets'}]}}],
                        'sourcePortStats':{'peerings':[{'type':'FuturePeering'}]}
                    }]}
                }");
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    RequestMessage = request,
                    Content = new StringContent(health.ToString(), System.Text.Encoding.UTF8, "application/json")
                };
            }
        }
    }
}