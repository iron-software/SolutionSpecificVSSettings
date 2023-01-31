using Microsoft.VisualStudio.Shell;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SolutionSpecificVSSettings
{
    [ComVisible(true)]
    public partial class Options : DialogPage
    {
        private const string VS_SETTINGS_CATEGORY = "VS settings switching";

        [Category(VS_SETTINGS_CATEGORY)]
        [DisplayName(applyCustomVSSettingsOnLoadDisplayName)]
        [Description("If set to true, " + Vsix.Name + " will try to find " +
            "a [SolutionName].vssettings file in the solution's root " +
            "directory and apply it to your Visual Studio. If no .vssettings " +
            "was found, it will try to apply the file from a \"" +
            defaultVSSettingsPathDisplayName + "\" option. No changes will " +
            "occur if the default file wasn't found either.")]
        [DefaultValue(true)]
        public bool ApplyCustomVSSettingsOnLoad { get; set; }
        private const string applyCustomVSSettingsOnLoadDisplayName =
            "Look for and apply .vssettings file on solution load";

        [Category(VS_SETTINGS_CATEGORY)]
        [DisplayName(defaultVSSettingsPathDisplayName)]
        [Description("Path to the default .vssettings file")]
        public string DefaultVSSettingsPath { get; set; }
        private const string defaultVSSettingsPathDisplayName =
            "Default .vssettings file path";

        [Category(VS_SETTINGS_CATEGORY)]
        [DisplayName(resotoreDefaultVSSettingsOnCloseDisplayName)]
        [Description("If set to true, " + Vsix.Name + " will apply the file " +
            "from a \"" + defaultVSSettingsPathDisplayName + "\" option on " +
            "solution close. Important to note that this will .vssettings " +
            "file on solution load.")]
        [DefaultValue(true)]
        public bool ResotoreDefaultVSSettingsOnClose { get; set; }
        private const string resotoreDefaultVSSettingsOnCloseDisplayName =
            "Apply default .vssettings on close";

        [Category(VS_SETTINGS_CATEGORY)]
        [DisplayName(resotoreDefaultVSSettingsIfSolutionSpecificNotFoundDisplayName)]
        [Description("If set to true, " + Vsix.Name + " will apply the file " +
            "from a \"" + defaultVSSettingsPathDisplayName + "\" option if no " +
            "solution specific .vssettings were found.")]
        [DefaultValue(true)]
        public bool ResotoreDefaultVSSettingsIfSolutionSpecificNotFound { get; set; }
        private const string resotoreDefaultVSSettingsIfSolutionSpecificNotFoundDisplayName =
            "Apply default .vssettings if solution has no specific .vssettings";
    }
}