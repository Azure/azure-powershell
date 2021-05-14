namespace Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101
{
    using static Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Extensions;

    /// <summary>Item Level target info for restore operation</summary>
    public partial class RangeBasedItemLevelRestoreCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRangeBasedItemLevelRestoreCriteria,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IRangeBasedItemLevelRestoreCriteriaInternal,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria __itemLevelRestoreCriteria = new Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.ItemLevelRestoreCriteria();

        /// <summary>Backing field for <see cref="MaxMatchingValue" /> property.</summary>
        private string _maxMatchingValue;

        /// <summary>maximum value for range prefix match</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string MaxMatchingValue { get => this._maxMatchingValue; set => this._maxMatchingValue = value; }

        /// <summary>Backing field for <see cref="MinMatchingValue" /> property.</summary>
        private string _minMatchingValue;

        /// <summary>minimum value for range prefix match</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Owned)]
        public string MinMatchingValue { get => this._minMatchingValue; set => this._minMatchingValue = value; }

        /// <summary>Type of the specific object - used for deserializing</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Origin(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.PropertyOrigin.Inherited)]
        public string ObjectType { get => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteriaInternal)__itemLevelRestoreCriteria).ObjectType; set => ((Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteriaInternal)__itemLevelRestoreCriteria).ObjectType = value ; }

        /// <summary>Creates an new <see cref="RangeBasedItemLevelRestoreCriteria" /> instance.</summary>
        public RangeBasedItemLevelRestoreCriteria()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__itemLevelRestoreCriteria), __itemLevelRestoreCriteria);
            await eventListener.AssertObjectIsValid(nameof(__itemLevelRestoreCriteria), __itemLevelRestoreCriteria);
        }
    }
    /// Item Level target info for restore operation
    public partial interface IRangeBasedItemLevelRestoreCriteria :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteria
    {
        /// <summary>maximum value for range prefix match</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"maximum value for range prefix match",
        SerializedName = @"maxMatchingValue",
        PossibleTypes = new [] { typeof(string) })]
        string MaxMatchingValue { get; set; }
        /// <summary>minimum value for range prefix match</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"minimum value for range prefix match",
        SerializedName = @"minMatchingValue",
        PossibleTypes = new [] { typeof(string) })]
        string MinMatchingValue { get; set; }

    }
    /// Item Level target info for restore operation
    internal partial interface IRangeBasedItemLevelRestoreCriteriaInternal :
        Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202101.IItemLevelRestoreCriteriaInternal
    {
        /// <summary>maximum value for range prefix match</summary>
        string MaxMatchingValue { get; set; }
        /// <summary>minimum value for range prefix match</summary>
        string MinMatchingValue { get; set; }

    }
}