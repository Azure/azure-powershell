namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The properties that are associated with a scalar function.</summary>
    public partial class ScalarFunctionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IScalarFunctionProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IScalarFunctionPropertiesInternal,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionProperties"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionProperties __functionProperties = new Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.FunctionProperties();

        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionConfiguration Property { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionPropertiesInternal)__functionProperties).Property; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionPropertiesInternal)__functionProperties).Property = value ?? null /* model class */; }

        /// <summary>Indicates the type of function.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionPropertiesInternal)__functionProperties).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionPropertiesInternal)__functionProperties).Type = value ; }

        /// <summary>Creates an new <see cref="ScalarFunctionProperties" /> instance.</summary>
        public ScalarFunctionProperties()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__functionProperties), __functionProperties);
            await eventListener.AssertObjectIsValid(nameof(__functionProperties), __functionProperties);
        }
    }
    /// The properties that are associated with a scalar function.
    public partial interface IScalarFunctionProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionProperties
    {

    }
    /// The properties that are associated with a scalar function.
    internal partial interface IScalarFunctionPropertiesInternal :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IFunctionPropertiesInternal
    {

    }
}