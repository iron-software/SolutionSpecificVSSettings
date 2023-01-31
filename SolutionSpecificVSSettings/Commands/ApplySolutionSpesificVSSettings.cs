using Community.VisualStudio.Toolkit;
using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using System.IO;
using SolutionEvents = Microsoft.VisualStudio.Shell.Events.SolutionEvents;

namespace SolutionSpecificVSSettings
{
    public class ApplySolutionSpesificVSSettings
    {
        private const string VS_SETTINGS = ".vssettings";
        private const string SLN = ".sln";

        private readonly DTE2 _dte;
        private readonly Options _options;
        private bool _settingsWereApplied = false;

        public static ApplySolutionSpesificVSSettings Instance
        {
            get;
            private set;
        }

        public static void Initialize(DTE2 dte, Options options)
        {
            Instance = new ApplySolutionSpesificVSSettings(dte, options);
        }

        private ApplySolutionSpesificVSSettings(DTE2 dte, Options options)
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            _dte = dte;
            _options = options;

            SolutionEvents.OnAfterOpenSolution += (s, e) => ApplySolutionSpecificSettings();
            SolutionEvents.OnAfterCloseSolution += (s, e) => ApplyDefaultSettings();
        }

        private void ApplySolutionSpecificSettings()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            if (!_options.ApplyCustomVSSettingsOnLoad)
            {
                return;
            }

            string vsSettingsFileName =
                _dte?.Solution?.FileName?.Replace(SLN, VS_SETTINGS);

            if (TryApplyVSSettings(vsSettingsFileName))
            {
                _settingsWereApplied = true;

                VS.StatusBar
                    .ShowMessageAsync($"{Vsix.Name}: Imported " +
                    $"{Path.GetFileName(vsSettingsFileName)}")
                    .FireAndForget();

                return;
            }

            if (_options.ResotoreDefaultVSSettingsIfSolutionSpecificNotFound)
            {
                VS.StatusBar
                    .ShowMessageAsync($"{Vsix.Name}: Couldn't find or import " +
                    $"solution-specific .vssettings, applying default " +
                    $".vssettings")
                    .FireAndForget();

            _ = TryApplyVSSettings(_options.DefaultVSSettingsPath);

                return;
            }

            VS.StatusBar
                .ShowMessageAsync($"{Vsix.Name}: Couldn't find or import " +
                $"solution-specific .vssettings")
                .FireAndForget();
        }

        private void ApplyDefaultSettings()
        {
            if (!_settingsWereApplied || !_options.ResotoreDefaultVSSettingsOnClose)
            {
                return;
            }

            if (TryApplyVSSettings(_options.DefaultVSSettingsPath))
            {
                VS.StatusBar
                    .ShowMessageAsync($"{Vsix.Name}: Imported " +
                    $"{Path.GetFileName(_options.DefaultVSSettingsPath)}")
                    .FireAndForget();
            }

            _settingsWereApplied = false;
        }

        private bool TryApplyVSSettings(string vsSettingsFileName)
        {
            if (!FileIsValid(vsSettingsFileName))
            {
                return false;
            }

            try
            {
                _dte.ExecuteCommand(
                    "Tools.ImportandExportSettings",
                    $"/import:\"{vsSettingsFileName}\"");

                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool FileIsValid(string filePath)
        {
            return !string.IsNullOrEmpty(filePath)
                && filePath.EndsWith(VS_SETTINGS)
                && File.Exists(filePath);
        }
    }
}
