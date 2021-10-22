using System;
using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace InsertGuid
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            DocumentView docView = await VS.Documents.GetActiveDocumentViewAsync();
            var position = docView.TextView?.Selection.Start.Position.Position;

            if (position.HasValue)
            {
                docView.TextBuffer.Insert(position.Value, Guid.NewGuid().ToString());
            }
        }
    }
}
