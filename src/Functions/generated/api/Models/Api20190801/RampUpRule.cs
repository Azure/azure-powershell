namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Extensions;

    /// <summary>
    /// Routing rules for ramp up testing. This rule allows to redirect static traffic % to a slot or to gradually change routing
    /// % based on performance.
    /// </summary>
    public partial class RampUpRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRule,
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20190801.IRampUpRuleInternal
    {

        /// <summary>Backing field for <see cref="ActionHostName" /> property.</summary>
        private string _actionHostName;

        /// <summary>
        /// Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ActionHostName { get => this._actionHostName; set => this._actionHostName = value; }

        /// <summary>Backing field for <see cref="ChangeDecisionCallbackUrl" /> property.</summary>
        private string _changeDecisionCallbackUrl;

        /// <summary>
        /// Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site
        /// extension for the scaffold and contracts.
        /// https://www.siteextensions.net/packages/TiPCallback/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string ChangeDecisionCallbackUrl { get => this._changeDecisionCallbackUrl; set => this._changeDecisionCallbackUrl = value; }

        /// <summary>Backing field for <see cref="ChangeIntervalInMinute" /> property.</summary>
        private int? _changeIntervalInMinute;

        /// <summary>Specifies interval in minutes to reevaluate ReroutePercentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public int? ChangeIntervalInMinute { get => this._changeIntervalInMinute; set => this._changeIntervalInMinute = value; }

        /// <summary>Backing field for <see cref="ChangeStep" /> property.</summary>
        private double? _changeStep;

        /// <summary>
        /// In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code>
        /// or
        /// <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom
        /// decision algorithm
        /// can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? ChangeStep { get => this._changeStep; set => this._changeStep = value; }

        /// <summary>Backing field for <see cref="MaxReroutePercentage" /> property.</summary>
        private double? _maxReroutePercentage;

        /// <summary>Specifies upper boundary below which ReroutePercentage will stay.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? MaxReroutePercentage { get => this._maxReroutePercentage; set => this._maxReroutePercentage = value; }

        /// <summary>Backing field for <see cref="MinReroutePercentage" /> property.</summary>
        private double? _minReroutePercentage;

        /// <summary>Specifies lower boundary above which ReroutePercentage will stay.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? MinReroutePercentage { get => this._minReroutePercentage; set => this._minReroutePercentage = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="ReroutePercentage" /> property.</summary>
        private double? _reroutePercentage;

        /// <summary>
        /// Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Origin(Microsoft.Azure.PowerShell.Cmdlets.Functions.PropertyOrigin.Owned)]
        public double? ReroutePercentage { get => this._reroutePercentage; set => this._reroutePercentage = value; }

        /// <summary>Creates an new <see cref="RampUpRule" /> instance.</summary>
        public RampUpRule()
        {

        }
    }
    /// Routing rules for ramp up testing. This rule allows to redirect static traffic % to a slot or to gradually change routing
    /// % based on performance.
    public partial interface IRampUpRule :
        Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.IJsonSerializable
    {
        /// <summary>
        /// Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.",
        SerializedName = @"actionHostName",
        PossibleTypes = new [] { typeof(string) })]
        string ActionHostName { get; set; }
        /// <summary>
        /// Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site
        /// extension for the scaffold and contracts.
        /// https://www.siteextensions.net/packages/TiPCallback/
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.
        https://www.siteextensions.net/packages/TiPCallback/",
        SerializedName = @"changeDecisionCallbackUrl",
        PossibleTypes = new [] { typeof(string) })]
        string ChangeDecisionCallbackUrl { get; set; }
        /// <summary>Specifies interval in minutes to reevaluate ReroutePercentage.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies interval in minutes to reevaluate ReroutePercentage.",
        SerializedName = @"changeIntervalInMinutes",
        PossibleTypes = new [] { typeof(int) })]
        int? ChangeIntervalInMinute { get; set; }
        /// <summary>
        /// In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code>
        /// or
        /// <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom
        /// decision algorithm
        /// can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or
        <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom decision algorithm
        can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.",
        SerializedName = @"changeStep",
        PossibleTypes = new [] { typeof(double) })]
        double? ChangeStep { get; set; }
        /// <summary>Specifies upper boundary below which ReroutePercentage will stay.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies upper boundary below which ReroutePercentage will stay.",
        SerializedName = @"maxReroutePercentage",
        PossibleTypes = new [] { typeof(double) })]
        double? MaxReroutePercentage { get; set; }
        /// <summary>Specifies lower boundary above which ReroutePercentage will stay.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Specifies lower boundary above which ReroutePercentage will stay.",
        SerializedName = @"minReroutePercentage",
        PossibleTypes = new [] { typeof(double) })]
        double? MinReroutePercentage { get; set; }
        /// <summary>
        /// Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>
        /// Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Percentage of the traffic which will be redirected to <code>ActionHostName</code>.",
        SerializedName = @"reroutePercentage",
        PossibleTypes = new [] { typeof(double) })]
        double? ReroutePercentage { get; set; }

    }
    /// Routing rules for ramp up testing. This rule allows to redirect static traffic % to a slot or to gradually change routing
    /// % based on performance.
    internal partial interface IRampUpRuleInternal

    {
        /// <summary>
        /// Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
        /// </summary>
        string ActionHostName { get; set; }
        /// <summary>
        /// Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site
        /// extension for the scaffold and contracts.
        /// https://www.siteextensions.net/packages/TiPCallback/
        /// </summary>
        string ChangeDecisionCallbackUrl { get; set; }
        /// <summary>Specifies interval in minutes to reevaluate ReroutePercentage.</summary>
        int? ChangeIntervalInMinute { get; set; }
        /// <summary>
        /// In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code>
        /// or
        /// <code>MaxReroutePercentage</code>. Site metrics are checked every N minutes specified in <code>ChangeIntervalInMinutes</code>.\nCustom
        /// decision algorithm
        /// can be provided in TiPCallback site extension which URL can be specified in <code>ChangeDecisionCallbackUrl</code>.
        /// </summary>
        double? ChangeStep { get; set; }
        /// <summary>Specifies upper boundary below which ReroutePercentage will stay.</summary>
        double? MaxReroutePercentage { get; set; }
        /// <summary>Specifies lower boundary above which ReroutePercentage will stay.</summary>
        double? MinReroutePercentage { get; set; }
        /// <summary>
        /// Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
        /// </summary>
        double? ReroutePercentage { get; set; }

    }
}