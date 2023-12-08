namespace Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120
{
    using static Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.Extensions;

    public partial class LoggingRuleHiddenPropertyPaths :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRuleHiddenPropertyPaths,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingRuleHiddenPropertyPathsInternal,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IValidates
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPath"
        /// />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPath __loggingHiddenPropertyPath = new Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.LoggingHiddenPropertyPath();

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string[] HiddenPathsOnRequest { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal)__loggingHiddenPropertyPath).HiddenPathsOnRequest; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal)__loggingHiddenPropertyPath).HiddenPathsOnRequest = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Origin(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.PropertyOrigin.Inherited)]
        public string[] HiddenPathsOnResponse { get => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal)__loggingHiddenPropertyPath).HiddenPathsOnResponse; set => ((Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal)__loggingHiddenPropertyPath).HiddenPathsOnResponse = value ?? null /* arrayOf */; }

        /// <summary>Creates an new <see cref="LoggingRuleHiddenPropertyPaths" /> instance.</summary>
        public LoggingRuleHiddenPropertyPaths()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A < see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__loggingHiddenPropertyPath), __loggingHiddenPropertyPath);
            await eventListener.AssertObjectIsValid(nameof(__loggingHiddenPropertyPath), __loggingHiddenPropertyPath);
        }
    }
    public partial interface ILoggingRuleHiddenPropertyPaths :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPath
    {

    }
    internal partial interface ILoggingRuleHiddenPropertyPathsInternal :
        Microsoft.Azure.PowerShell.Cmdlets.ProviderHub.Models.Api20201120.ILoggingHiddenPropertyPathInternal
    {

    }
}