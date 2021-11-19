using Microsoft.VisualStudio.Shell.Interop;

namespace ShowHelpContext
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        public static Guid DebugHelpContextToolWindowGuid = new Guid("66dba47c-61df-11d2-aa79-00c04f990343");

        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            IVsUIShell vsUIShell = await VS.Services.GetUIShellAsync();
            vsUIShell.FindToolWindow((uint)__VSFINDTOOLWIN.FTW_fForceCreate, ref DebugHelpContextToolWindowGuid, out IVsWindowFrame vsWindowFrame);

            if (null != vsWindowFrame)
            {
                vsWindowFrame.Show();
            }
        }
    }
}
