using System;
using System.Runtime.InteropServices;
using System.Threading;
using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace Options
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.OptionsString)]
    [ProvideOptionPage(typeof(OptionsProvider.GeneralOptions), "MyExtension", "General", 0, 0, true)]
    [ProvideProfile(typeof(OptionsProvider.GeneralOptions), "MyExtension", "General", 0, 0, true)]
    public sealed class OptionsPackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);

            General.Saved += OnSettingsSaved;

        }

        private void OnSettingsSaved(General obj)
        {
           
        }

        private void InteractWithSettings()
        {
            // read settings
            var number = General.Instance.MyEnum;

            // write settings
            General.Instance.MyEnum = Numbers.Second;
            General.Instance.Save();
        }

        private async Task InteractWithSettingsAsync()
        {
            // read settings
            var general = await General.GetLiveInstanceAsync();
            var number = general.MyEnum;
            
            // write settings
            general.MyEnum = Numbers.Second;
            await general.SaveAsync();
        }
    }
}