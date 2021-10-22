global using System;
global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
global using Task = System.Threading.Tasks.Task;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.VisualStudio.TextTemplating.VSHost;
using SingleFileGenerator.Generators;

namespace SingleFileGenerator
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.SingleFileGeneratorString)]
    [ProvideCodeGenerator(typeof(SassToCss), SassToCss.Name, SassToCss.Description, true, RegisterCodeBase = true)]
    [ProvideCodeGeneratorExtension(SassToCss.Name, ".scss")]
    [ProvideCodeGeneratorExtension(SassToCss.Name, ".sass")]
    [ProvideUIContextRule(PackageGuids.CommandVisisiblityString,
        name: "Sass files",
        expression: "Sass",
        termNames: new[] { "Sass" },
        termValues: new[] { "HierSingleSelectionName:.s(a|c)ss$" })]
    public sealed class SingleFileGeneratorPackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.RegisterCommandsAsync();
        }
    }
}