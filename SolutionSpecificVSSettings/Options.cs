using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace SolutionSpecificVSSettings
{
    public partial class Options : DialogPage
    {
        [Category("VS settings switching")]
        [DisplayName("Look for and apply .vssettings file on solution load")]
        [Description("If set to true, the Solution Specific VSSettings extension " +
            "will try to find a [SolutionName].vssettings file in the " +
            "solution's root directory and apply it to your Visual Studio. " +
            "If no .vssettings was found, it will try to apply the file " +
            "from a \"Default .vssettings file path\" option. No changes will " +
            "occur if the default file wasn't found either.")]
        [DefaultValue(true)]
        public bool ApplyCustomVSSettingsOnLoad { get; set; }

        [Category("VS settings switching")]
        [DisplayName("Default .vssettings file path")]
        [Description("Path to the default .vssettings file which will be " +
            "applied if \"Look for and apply .vssettings file on solution " +
            "load\" option is set to true, but no solution specific " +
            ".vssettings file was found in the root directory of a solution")]
        public string DefaultVSSettingsPath { get; set; }

        [Category("VS settings switching")]
        [DisplayName("Apply default .vssettings on close")]
        [Description("If set to true, Solution Specific VSSettings extension " +
            "will apply the file from a \"Default .vssettings file path\" " +
            "option on solution close. Important to note that this will " +
            "happen only if there was found and applied a solution specific " +
            ".vssettings file on solution load.")]
        [DefaultValue(true)]
        public bool ResotoreDefaultVSSettingsOnClose { get; set; }
    }
}