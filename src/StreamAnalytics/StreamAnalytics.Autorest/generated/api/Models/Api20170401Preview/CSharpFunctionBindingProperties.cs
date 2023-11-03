namespace Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview
{
    using static Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Extensions;

    /// <summary>The binding properties associated with a CSharp function.</summary>
    public partial class CSharpFunctionBindingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingProperties,
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.ICSharpFunctionBindingPropertiesInternal
    {

        /// <summary>Backing field for <see cref="Class" /> property.</summary>
        private string _class;

        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Class { get => this._class; set => this._class = value; }

        /// <summary>Backing field for <see cref="DllPath" /> property.</summary>
        private string _dllPath;

        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string DllPath { get => this._dllPath; set => this._dllPath = value; }

        /// <summary>Backing field for <see cref="Method" /> property.</summary>
        private string _method;

        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Method { get => this._method; set => this._method = value; }

        /// <summary>Backing field for <see cref="Script" /> property.</summary>
        private string _script;

        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Origin(Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.PropertyOrigin.Owned)]
        public string Script { get => this._script; set => this._script = value; }

        /// <summary>Creates an new <see cref="CSharpFunctionBindingProperties" /> instance.</summary>
        public CSharpFunctionBindingProperties()
        {

        }
    }
    /// The binding properties associated with a CSharp function.
    public partial interface ICSharpFunctionBindingProperties :
        Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.IJsonSerializable
    {
        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Csharp code containing a single function definition.",
        SerializedName = @"class",
        PossibleTypes = new [] { typeof(string) })]
        string Class { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Csharp code containing a single function definition.",
        SerializedName = @"dllPath",
        PossibleTypes = new [] { typeof(string) })]
        string DllPath { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Csharp code containing a single function definition.",
        SerializedName = @"method",
        PossibleTypes = new [] { typeof(string) })]
        string Method { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The Csharp code containing a single function definition.",
        SerializedName = @"script",
        PossibleTypes = new [] { typeof(string) })]
        string Script { get; set; }

    }
    /// The binding properties associated with a CSharp function.
    internal partial interface ICSharpFunctionBindingPropertiesInternal

    {
        /// <summary>The Csharp code containing a single function definition.</summary>
        string Class { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        string DllPath { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        string Method { get; set; }
        /// <summary>The Csharp code containing a single function definition.</summary>
        string Script { get; set; }

    }
}