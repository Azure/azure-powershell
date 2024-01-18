/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime
{
    using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.generated.runtime.Properties;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Management.Automation;
    using System.Text;

    [AttributeUsage(AttributeTargets.All)]
    public class GenericBreakingChangeAttribute : Attribute
    {
        private string _message;
        //A dexcription of what the change is about, non mandatory
        public string ChangeDescription { get; set; } = null;

        //The version the change is effective from, non mandatory
        public string DeprecateByVersion { get; }
        public string DeprecateByAzVersion { get; }

        //The date on which the change comes in effect
        public DateTime ChangeInEfectByDate { get; }
        public bool ChangeInEfectByDateSet { get; } = false;

        //Old way of calling the cmdlet
        public string OldWay { get; set; }
        //New way fo calling the cmdlet
        public string NewWay { get; set; }

        public GenericBreakingChangeAttribute(string message, string deprecateByAzVersion, string deprecateByVersion)
        {
            _message = message;
            this.DeprecateByAzVersion = deprecateByAzVersion;
            this.DeprecateByVersion = deprecateByVersion;
        }

        public GenericBreakingChangeAttribute(string message, string deprecateByAzVersion, string deprecateByVersion, string changeInEfectByDate)
        {
            _message = message;
            this.DeprecateByVersion = deprecateByVersion;
            this.DeprecateByAzVersion = deprecateByAzVersion;

            if (DateTime.TryParse(changeInEfectByDate, new CultureInfo("en-US"), DateTimeStyles.None, out DateTime result))
            {
                this.ChangeInEfectByDate = result;
                this.ChangeInEfectByDateSet = true;
            }
        }

        public DateTime getInEffectByDate()
        {
            return this.ChangeInEfectByDate.Date;
        }


        /**
        * This function prints out the breaking change message for the attribute on the cmdline
        * */
        public void PrintCustomAttributeInfo(Action<string> writeOutput)
        {

            if (!GetAttributeSpecificMessage().StartsWith(Environment.NewLine))
            {
                writeOutput(Environment.NewLine);
            }
            writeOutput(string.Format(Resources.BreakingChangesAttributesDeclarationMessage, GetAttributeSpecificMessage()));


            if (!string.IsNullOrWhiteSpace(ChangeDescription))
            {
                writeOutput(string.Format(Resources.BreakingChangesAttributesChangeDescriptionMessage, this.ChangeDescription));
            }

            if (ChangeInEfectByDateSet)
            {
                writeOutput(string.Format(Resources.BreakingChangesAttributesInEffectByDateMessage, this.ChangeInEfectByDate.ToString("d")));
            }

            writeOutput(string.Format(Resources.BreakingChangesAttributesInEffectByAzVersion, this.DeprecateByAzVersion));
            writeOutput(string.Format(Resources.BreakingChangesAttributesInEffectByVersion, this.DeprecateByVersion));

            if (OldWay != null && NewWay != null)
            {
                writeOutput(string.Format(Resources.BreakingChangesAttributesUsageChangeMessageConsole, OldWay, NewWay));
            }
        }

        public virtual bool IsApplicableToInvocation(InvocationInfo invocation)
        {
            return true;
        }

        protected virtual string GetAttributeSpecificMessage()
        {
            return _message;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class CmdletBreakingChangeAttribute : GenericBreakingChangeAttribute
    {

        public string ReplacementCmdletName { get; set; }

        public CmdletBreakingChangeAttribute(string deprecateByAzVersion, string deprecateByVersion) :
             base(string.Empty, deprecateByAzVersion, deprecateByVersion)
        {
        }

        public CmdletBreakingChangeAttribute(string deprecateByAzVersion, string deprecateByVersion, string changeInEfectByDate) :
             base(string.Empty, deprecateByAzVersion, deprecateByVersion, changeInEfectByDate)
        {
        }

        protected override string GetAttributeSpecificMessage()
        {
            if (string.IsNullOrWhiteSpace(ReplacementCmdletName))
            {
                return Resources.BreakingChangesAttributesCmdLetDeprecationMessageNoReplacement;
            }
            else
            {
                return string.Format(Resources.BreakingChangesAttributesCmdLetDeprecationMessageWithReplacement, ReplacementCmdletName);
            }
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class ParameterSetBreakingChangeAttribute : GenericBreakingChangeAttribute
    {
        public string[] ChangedParameterSet { set; get; }

        public ParameterSetBreakingChangeAttribute(string[] changedParameterSet, string deprecateByAzVersion, string deprecateByVersion) :
             base(string.Empty, deprecateByAzVersion, deprecateByVersion)
        {
            ChangedParameterSet = changedParameterSet;
        }

        public ParameterSetBreakingChangeAttribute(string[] changedParameterSet, string deprecateByAzVersion, string deprecateByVersion, string changeInEfectByDate) :
             base(string.Empty, deprecateByAzVersion, deprecateByVersion, changeInEfectByDate)
        {
            ChangedParameterSet = changedParameterSet;
        }

        protected override string GetAttributeSpecificMessage()
        {

            return Resources.BreakingChangesAttributesParameterSetDeprecationMessageNoReplacement;

        }

        public bool IsApplicableToInvocation(InvocationInfo invocation, string parameterSetName)
        {
            if (ChangedParameterSet != null)
                return ChangedParameterSet.Contains(parameterSetName);
            return false;
        }

    }

    [AttributeUsage(AttributeTargets.All)]
    public class PreviewMessageAttribute : Attribute
    {
        public string _message;

        public DateTime EstimatedGaDate { get; }

        public bool IsEstimatedGaDateSet { get; } = false;


        public PreviewMessageAttribute()
        {
            this._message = Resources.PreviewCmdletMessage;
        }

        public PreviewMessageAttribute(string message)
        {
            this._message = string.IsNullOrEmpty(message) ? Resources.PreviewCmdletMessage : message;
        }

        public PreviewMessageAttribute(string message, string estimatedDateOfGa) : this(message)
        {
            if (DateTime.TryParse(estimatedDateOfGa, new CultureInfo("en-US"), DateTimeStyles.None, out DateTime result))
            {
                this.EstimatedGaDate = result;
                this.IsEstimatedGaDateSet = true;
            }
        }
        
        public void PrintCustomAttributeInfo(Action<string> writeOutput)
        {
            writeOutput(this._message);
            
            if (IsEstimatedGaDateSet)
            {
                writeOutput(string.Format(Resources.PreviewCmdletETAMessage, this.EstimatedGaDate.ToShortDateString()));
            }
        }

        public virtual bool IsApplicableToInvocation(InvocationInfo invocation)
        {
            return true;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ParameterBreakingChangeAttribute : GenericBreakingChangeAttribute
    {
        public string NameOfParameterChanging { get; }

        public string ReplaceMentCmdletParameterName { get; set; } = null;

        public bool IsBecomingMandatory { get; set; } = false;

        public String OldParamaterType { get; set; }

        public String NewParameterType { get; set; }

        public ParameterBreakingChangeAttribute(string nameOfParameterChanging, string deprecateByAzVersion, string deprecateByVersion) :
             base(string.Empty, deprecateByAzVersion, deprecateByVersion)
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        public ParameterBreakingChangeAttribute(string nameOfParameterChanging, string deprecateByAzVersion, string deprecateByVersion, string changeInEfectByDate) :
             base(string.Empty, deprecateByAzVersion, deprecateByVersion, changeInEfectByDate)
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        protected override string GetAttributeSpecificMessage()
        {
            StringBuilder message = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(ReplaceMentCmdletParameterName))
            {
                if (IsBecomingMandatory)
                {
                    message.Append(string.Format(Resources.BreakingChangeAttributeParameterReplacedMandatory, NameOfParameterChanging, ReplaceMentCmdletParameterName));
                }
                else
                {
                    message.Append(string.Format(Resources.BreakingChangeAttributeParameterReplaced, NameOfParameterChanging, ReplaceMentCmdletParameterName));
                }
            }
            else
            {
                if (IsBecomingMandatory)
                {
                    message.Append(string.Format(Resources.BreakingChangeAttributeParameterMandatoryNow, NameOfParameterChanging));
                }
                else
                {
                    message.Append(string.Format(Resources.BreakingChangeAttributeParameterChanging, NameOfParameterChanging));
                }
            }

            //See if the type of the param is changing
            if (OldParamaterType != null && !string.IsNullOrWhiteSpace(NewParameterType))
            {
                message.Append(string.Format(Resources.BreakingChangeAttributeParameterTypeChange, OldParamaterType, NewParameterType));
            }
            return message.ToString();
        }

        /// <summary>
        /// See if the bound parameters contain the current parameter, if they do
        /// then the attribbute is applicable
        /// If the invocationInfo is null we return true
        /// </summary>
        /// <param name="invocationInfo"></param>
        /// <returns>bool</returns>
        public override bool IsApplicableToInvocation(InvocationInfo invocationInfo)
        {
            bool? applicable = invocationInfo == null ? true : invocationInfo.BoundParameters?.Keys?.Contains(this.NameOfParameterChanging);
            return applicable.HasValue ? applicable.Value : false;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class OutputBreakingChangeAttribute : GenericBreakingChangeAttribute
    {
        public string DeprecatedCmdLetOutputType { get; }

        //This is still a String instead of a Type as this 
        //might be undefined at the time of adding the attribute
        public string ReplacementCmdletOutputType { get; set; }

        public string[] DeprecatedOutputProperties { get; set; }

        public string[] NewOutputProperties { get; set; }

        public OutputBreakingChangeAttribute(string deprecatedCmdletOutputType, string deprecateByAzVersion, string deprecateByVersion) :
             base(string.Empty, deprecateByAzVersion, deprecateByVersion)
        {
            this.DeprecatedCmdLetOutputType = deprecatedCmdletOutputType;
        }

        public OutputBreakingChangeAttribute(string deprecatedCmdletOutputType, string deprecateByAzVersion, string deprecateByVersion, string changeInEfectByDate) :
             base(string.Empty, deprecateByAzVersion, deprecateByVersion, changeInEfectByDate)
        {
            this.DeprecatedCmdLetOutputType = deprecatedCmdletOutputType;
        }

        protected override string GetAttributeSpecificMessage()
        {
            StringBuilder message = new StringBuilder();

            //check for the deprecation scenario
            if (string.IsNullOrWhiteSpace(ReplacementCmdletOutputType) && NewOutputProperties == null && DeprecatedOutputProperties == null && string.IsNullOrWhiteSpace(ChangeDescription))
            {
                message.Append(string.Format(Resources.BreakingChangesAttributesCmdLetOutputTypeDeprecated, DeprecatedCmdLetOutputType));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(ReplacementCmdletOutputType))
                {
                    message.Append(string.Format(Resources.BreakingChangesAttributesCmdLetOutputChange1, DeprecatedCmdLetOutputType, ReplacementCmdletOutputType));
                }
                else
                {
                    message.Append(string.Format(Resources.BreakingChangesAttributesCmdLetOutputChange2, DeprecatedCmdLetOutputType));
                }

                if (DeprecatedOutputProperties != null && DeprecatedOutputProperties.Length > 0)
                {
                    message.Append(Resources.BreakingChangesAttributesCmdLetOutputPropertiesRemoved);
                    foreach (string property in DeprecatedOutputProperties)
                    {
                        message.Append(" '" + property + "'");
                    }
                }

                if (NewOutputProperties != null && NewOutputProperties.Length > 0)
                {
                    message.Append(Resources.BreakingChangesAttributesCmdLetOutputPropertiesAdded);
                    foreach (string property in NewOutputProperties)
                    {
                        message.Append(" '" + property + "'");
                    }
                }
            }
            return message.ToString();
        }
    }
}