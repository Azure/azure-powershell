using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    [CmdletOutputBreakingChangeWithVersion(typeof(PSRulesEngineAction), "15.0.0", "6.0.0", ReplacementCmdletOutputTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.RulesEngineAction", ChangeDescription = "no longer has output type 'Microsoft.Azure.Commands.FrontDoor.Models.PSRulesEngineAction'.")]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoor" + "RulesEngineActionObject", DefaultParameterSetName = FieldsWithRegularActionParameterSet), OutputType(typeof(PSRulesEngineAction))]
    public class NewFrontDoorRulesEngineActionObject : AzureFrontDoorCmdletBase
    {
        [CmdletParameterBreakingChangeWithVersion("RequestHeaderAction", "15.0.0", "6.0.0", NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHeaderAction[]", ChangeDescription = "no longer supports the type 'System.Collections.Generic.List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]' for parameter 'RequestHeaderAction'.")]
        [Parameter(Mandatory = false, HelpMessage = "A list of header actions to apply from the request from AFD to the origin.")]
        public List<PSHeaderAction> RequestHeaderAction { get; set; }

        [CmdletParameterBreakingChangeWithVersion("ResponseHeaderAction", "15.0.0", "6.0.0", NewParameterTypeName = "Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IHeaderAction[]", ChangeDescription = "no longer supports the type 'System.Collections.Generic.List`1[Microsoft.Azure.Commands.FrontDoor.Models.PSHeaderAction]' for parameter 'ResponseHeaderAction'.")]
        [Parameter(Mandatory = false, HelpMessage = "A list of header actions to apply from the response from AFD to the client.")]
        public List<PSHeaderAction> ResponseHeaderAction { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithForwardingParameterSet,
            HelpMessage = "The custom path used to rewrite resource paths matched by this rule. Leave empty to use incoming path.")]
        public string CustomForwardingPath { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithForwardingParameterSet,
            HelpMessage = "The protocol this rule will use when forwarding traffic to backends. Default value is MatchRequest")]
        [PSArgumentCompleter("HttpOnly", "HttpsOnly", "MatchRequest")]
        public string ForwardingProtocol { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsWithForwardingParameterSet,
            HelpMessage = "The resource group name that the RoutingRule will be created in.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsWithForwardingParameterSet,
            HelpMessage = "The name of the Front Door to which this routing rule belongs.")]
        [ValidateNotNullOrEmpty]
        public string FrontDoorName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FieldsWithForwardingParameterSet,
            HelpMessage = "The name of the BackendPool which this rule routes to")]
        [ValidateNotNullOrEmpty]
        public string BackendPoolName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithForwardingParameterSet,
            HelpMessage = "Whether to enable caching for this route. Default value is false")]
        public bool EnableCaching { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithForwardingParameterSet,
            HelpMessage = "The treatment of URL query terms when forming the cache key. Default value is StripAll")]
        [PSArgumentCompleter("StripNone", "StripAll")]
        public string QueryParameterStripDirective { get; set; }

        [CmdletParameterBreakingChangeWithVersion("DynamicCompression", "15.0.0", "6.0.0", NewParameterTypeName = "System.String", ChangeDescription = "no longer supports the type 'Microsoft.Azure.Commands.FrontDoor.Models.PSEnabledState' for parameter 'DynamicCompression'.")]
        [Parameter(Mandatory = false, ParameterSetName = FieldsWithForwardingParameterSet,
            HelpMessage = "Whether to enable dynamic compression for cached content. Default value is Enabled")]
        public PSEnabledState DynamicCompression { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithRedirectParameterSet,
            HelpMessage = "The redirect type the rule will use when redirecting traffic. Default Value is Moved")]
        [PSArgumentCompleter("Moved", "Found", "TemporaryRedirect", "PermanentRedirect")]
        public string RedirectType { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithRedirectParameterSet,
            HelpMessage = "The protocol of the destination to where the traffic is redirected. Default value is MatchRequest")]
        [PSArgumentCompleter("HttpOnly", "HttpsOnly", "MatchRequest")]
        public string RedirectProtocol { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithRedirectParameterSet,
            HelpMessage = "Host to redirect. Leave empty to use the incoming host as the destination host.")]
        public string CustomHost { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithRedirectParameterSet,
            HelpMessage = "The full path to redirect. Path cannot be empty and must start with /. Leave empty to use the incoming path as destination path.")]
        public string CustomPath { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithRedirectParameterSet,
            HelpMessage = "Fragment to add to the redirect URL. Fragment is the part of the URL that comes after #. Do not include the #.")]
        public string CustomFragment { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = FieldsWithRedirectParameterSet,
            HelpMessage = @"The set of query strings to be placed in the redirect URL. Setting this value would replace any existing query string;
                                leave empty to preserve the incoming query string. Query string must be in <key>=<value> format. The first ? and & 
                                will be added automatically so do not include them in the front, but do separate multiple query strings with &.")]
        public string CustomQueryString { get; set; }

        public override void ExecuteCmdlet()
        {
            var action = new PSRulesEngineAction
            {
                RequestHeaderActions = this.IsParameterBound(c => c.RequestHeaderAction) ? RequestHeaderAction : new List<PSHeaderAction>(),
                ResponseHeaderActions = this.IsParameterBound(c => c.ResponseHeaderAction) ? ResponseHeaderAction : new List<PSHeaderAction>(),
            };

            if (ParameterSetName == FieldsWithForwardingParameterSet)
            {
                string BackendPoolId = string.Format("/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/frontDoors/{2}/BackendPools/{3}",
                  DefaultContext.Subscription.Id, ResourceGroupName, FrontDoorName, BackendPoolName);

                action.RouteConfigurationOverride = new PSForwardingConfiguration
                {
                    CustomForwardingPath = CustomForwardingPath,
                    ForwardingProtocol = !this.IsParameterBound(c => c.ForwardingProtocol) ? PSForwardingProtocol.MatchRequest.ToString() : ForwardingProtocol,
                    QueryParameterStripDirective = !this.IsParameterBound(c => c.QueryParameterStripDirective) ? PSQueryParameterStripDirective.StripAll.ToString() : QueryParameterStripDirective,
                    DynamicCompression = !this.IsParameterBound(c => c.DynamicCompression) ? PSEnabledState.Enabled : DynamicCompression,
                    BackendPoolId = BackendPoolId,
                    EnableCaching = !this.IsParameterBound(c => c.EnableCaching) ? false : EnableCaching
                };
            }
            else if (ParameterSetName == FieldsWithRedirectParameterSet)
            {
                action.RouteConfigurationOverride = new PSRedirectConfiguration
                {
                    RedirectProtocol = !this.IsParameterBound(c => c.RedirectProtocol) ? PSRedirectProtocol.MatchRequest.ToString() : RedirectProtocol,
                    RedirectType = !this.IsParameterBound(c => c.RedirectType) ? PSRedirectType.Moved.ToString() : RedirectType,
                    CustomHost = !this.IsParameterBound(c => c.CustomHost) ? "" : CustomHost,
                    CustomFragment = CustomFragment,
                    CustomPath = !this.IsParameterBound(c => c.CustomPath) ? "" : CustomPath,
                    CustomQueryString = CustomQueryString
                };
            }

            // At least one of the 3 possible actions much be present
            if (action.RequestHeaderActions.Count == 0 && action.ResponseHeaderActions.Count == 0
                && action.RouteConfigurationOverride == null)
            {
                throw new PSArgumentException(
                    "Rules engine action must contain at least one of the following actions: RequestHeaderActions, ResponseHeaderActions, or RouteConfigurationOverride ");
            }

            WriteObject(action);
        }
    }
}
