namespace Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using Interfaces;

    /// <summary>
    /// Class OSVersionValidation.
    /// Implements the <see cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations.SystemValidationBase" />
    /// </summary>
    /// <seealso cref="Microsoft.Azure.Commands.StorageSync.Evaluation.Validations.SystemValidations.SystemValidationBase" />
    public class OSVersionValidation : SystemValidationBase
    {
        #region Fields and Properties
        /// <summary>
        /// The osversions
        /// </summary>
        private readonly Dictionary<string, string> _osversions;
        /// <summary>
        /// The editions
        /// </summary>
        private readonly Dictionary<uint, string> _editions;
        /// <summary>
        /// The valid os versions
        /// </summary>
        private readonly IList<string> _validOsVersions;
        /// <summary>
        /// The valid os skus
        /// </summary>
        private readonly IList<uint> _validOsSkus;
        /// <summary>
        /// The supported versions string
        /// </summary>
        private readonly string _supportedVersionsString;
        /// <summary>
        /// The supported editions strings
        /// </summary>
        private readonly string _supportedEditionsStrings;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OSVersionValidation" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public OSVersionValidation(IConfiguration configuration) : base(configuration, "OS version check", ValidationType.OsVersion)
        {
            _osversions = new Dictionary<string, string>();
            _osversions["10.0"] = "Windows Server 2016";
            _osversions["6.3"] = "Windows Server 2012 R2";

            _editions = new Dictionary<uint, string>();
            _editions[0] = "Undefined";
            _editions[1] = "Ultimate Edition";
            _editions[2] = "Home Basic Edition";
            _editions[3] = "Home Premium Edition";
            _editions[4] = "Enterprise Edition";
            _editions[5] = "Home Basic N Edition";
            _editions[6] = "Business Edition";
            _editions[7] = "Standard Server Edition";
            _editions[8] = "Datacenter Server Edition";
            _editions[9] = "Small Business Server Edition";
            _editions[10] = "Enterprise Server Edition";
            _editions[11] = "Starter Edition";
            _editions[12] = "Datacenter Server Core Edition";
            _editions[13] = "Standard Server Core Edition";
            _editions[14] = "Enterprise Server Core Edition";
            _editions[15] = "Enterprise Server Edition for Itanium-Based Systems";
            _editions[16] = "Business N Edition";
            _editions[17] = "Web Server Edition";
            _editions[18] = "Cluster Server Edition";
            _editions[19] = "Home Server Edition";
            _editions[20] = "Storage Express Server Edition";
            _editions[21] = "Storage Standard Server Edition";
            _editions[22] = "Storage Workgroup Server Edition";
            _editions[23] = "Storage Enterprise Server Edition";
            _editions[24] = "Server For Small Business Edition";
            _editions[25] = "Small Business Server Premium Edition";
            _editions[29] = "Web Server, Server Core";
            _editions[39] = "Datacenter Edition without Hyper-V, Server Core";
            _editions[40] = "Standard Edition without Hyper-V, Server Core";
            _editions[41] = "Enterprise Edition without Hyper-V, Server Core";
            _editions[42] = "Hyper-V Server";

            _validOsVersions = configuration.ValidOsVersions().ToList();
            _validOsSkus = configuration.ValidOsSKU().ToList();
            _supportedVersionsString = String.Join(", ", _validOsVersions.Where(o => _osversions.ContainsKey(o)).Select(o => _osversions[o]));
            _supportedEditionsStrings = String.Join(", ", _validOsSkus.Where(o => _editions.ContainsKey(o)).Select(o => _editions[o]));

        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Does the validate using.
        /// </summary>
        /// <param name="commandRunner">The command runner.</param>
        /// <returns>IValidationResult.</returns>
        protected override IValidationResult DoValidateUsing(IPowershellCommandRunner commandRunner)
        {
            string osVersion;
            UInt32 sku;
            try
            {
                commandRunner.AddScript("Get-CimInstance Win32_OperatingSystem");
                PSObject resultPSObject = commandRunner.Invoke().First();
                osVersion = (string)resultPSObject.Members["Version"].Value;
                sku = (UInt32)resultPSObject.Members["OperatingSystemSKU"].Value;
            }
            catch (Exception e)
            {
                return ValidationResult.UnavailableValidation(
                    ValidationType, 
                    ValidationKind,
                    $"The OS Version validation was not able to complete. Cause: {e.Message}");
            }


            if (!IsValidVersion(osVersion))
            {
                return new ValidationResult()
                {
                    Description = $"OS version {osVersion} is not supported. Supported versions are: {_supportedVersionsString}",
                    Level = ResultLevel.Error,
                    Type = ValidationType,
                    Kind = ValidationKind,
                    Result = Result.Fail
                };
            }

            if (!IsValidSKU(sku))
            {
                string skuEdition = _editions.ContainsKey(sku) ? _editions[sku] : sku.ToString();
                return new ValidationResult()
                {
                    Description = $"OS edition '{skuEdition}' is not supported. Supported editions are: {_supportedEditionsStrings}",
                    Level = ResultLevel.Error,
                    Type = ValidationType,
                    Kind = ValidationKind,
                    Result = Result.Fail
                };
            }

            return SuccessfulResult;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Determines whether [is valid version] [the specified os version].
        /// </summary>
        /// <param name="osVersion">The os version.</param>
        /// <returns><c>true</c> if [is valid version] [the specified os version]; otherwise, <c>false</c>.</returns>
        private bool IsValidVersion(string osVersion)
        {
            foreach (string supportedOsVersion in _validOsVersions)
            {
                if (osVersion.StartsWith($"{supportedOsVersion}."))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether [is valid sku] [the specified sku].
        /// </summary>
        /// <param name="sku">The sku.</param>
        /// <returns><c>true</c> if [is valid sku] [the specified sku]; otherwise, <c>false</c>.</returns>
        private bool IsValidSKU(uint sku)
        {
            return _validOsSkus.Contains(sku);
        }
        #endregion
    }
}