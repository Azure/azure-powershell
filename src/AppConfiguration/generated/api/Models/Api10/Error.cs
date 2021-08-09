namespace Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10
{
    using static Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Extensions;

    /// <summary>Azure App Configuration error object.</summary>
    public partial class Error :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IError,
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Models.Api10.IErrorInternal
    {

        /// <summary>Backing field for <see cref="Detail" /> property.</summary>
        private string _detail;

        /// <summary>A detailed description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Detail { get => this._detail; set => this._detail = value; }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>The name of the parameter that resulted in the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Name { get => this._name; set => this._name = value; }

        /// <summary>Backing field for <see cref="Status" /> property.</summary>
        private int? _status;

        /// <summary>The HTTP status code that the error maps to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public int? Status { get => this._status; set => this._status = value; }

        /// <summary>Backing field for <see cref="Title" /> property.</summary>
        private string _title;

        /// <summary>A brief summary of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Title { get => this._title; set => this._title = value; }

        /// <summary>Backing field for <see cref="Type" /> property.</summary>
        private string _type;

        /// <summary>The type of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Origin(Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.PropertyOrigin.Owned)]
        public string Type { get => this._type; set => this._type = value; }

        /// <summary>Creates an new <see cref="Error" /> instance.</summary>
        public Error()
        {

        }
    }
    /// Azure App Configuration error object.
    public partial interface IError :
        Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.IJsonSerializable
    {
        /// <summary>A detailed description of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A detailed description of the error.",
        SerializedName = @"detail",
        PossibleTypes = new [] { typeof(string) })]
        string Detail { get; set; }
        /// <summary>The name of the parameter that resulted in the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The name of the parameter that resulted in the error.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get; set; }
        /// <summary>The HTTP status code that the error maps to.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The HTTP status code that the error maps to.",
        SerializedName = @"status",
        PossibleTypes = new [] { typeof(int) })]
        int? Status { get; set; }
        /// <summary>A brief summary of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A brief summary of the error.",
        SerializedName = @"title",
        PossibleTypes = new [] { typeof(string) })]
        string Title { get; set; }
        /// <summary>The type of the error.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.AppConfiguration.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The type of the error.",
        SerializedName = @"type",
        PossibleTypes = new [] { typeof(string) })]
        string Type { get; set; }

    }
    /// Azure App Configuration error object.
    internal partial interface IErrorInternal

    {
        /// <summary>A detailed description of the error.</summary>
        string Detail { get; set; }
        /// <summary>The name of the parameter that resulted in the error.</summary>
        string Name { get; set; }
        /// <summary>The HTTP status code that the error maps to.</summary>
        int? Status { get; set; }
        /// <summary>A brief summary of the error.</summary>
        string Title { get; set; }
        /// <summary>The type of the error.</summary>
        string Type { get; set; }

    }
}