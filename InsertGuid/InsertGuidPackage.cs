using Community.VisualStudio.Toolkit;

using Microsoft.VisualStudio.Shell;

using System;
using System.Runtime.InteropServices;
using System.Threading;

using Task = System.Threading.Tasks.Task;

namespace InsertGuid
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.InsertGuidString)]
    public sealed class InsertGuidPackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await MyCommand.InitializeAsync(this);
        }
    }
}