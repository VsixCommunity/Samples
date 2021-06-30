using System;
using Community.VisualStudio.Toolkit;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Text.Editor;
using Task = System.Threading.Tasks.Task;

namespace InsertGuid
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            IWpfTextView view = await VS.Documents.GetCurrentTextViewAsync();
            var position = view.Selection.Start.Position.Position;

            view.TextBuffer.Insert(position, Guid.NewGuid().ToString());
        }
    }
}
