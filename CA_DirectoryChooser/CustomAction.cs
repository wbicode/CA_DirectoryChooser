using System;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Deployment.WindowsInstaller;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace CA_DirectoryChooser
{
    public class CustomActions
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [CustomAction]
        public static ActionResult OpenFileChooser(Session session)
        {
            try
            {
                session.Log("Begin OpenFileChooser Custom Action");
                var task = new Thread(() => GetFile(session));
                task.SetApartmentState(ApartmentState.STA);
                task.Start();
                task.Join();
                session.Log("End OpenFileChooser Custom Action");
            }
            catch (Exception ex)
            {
                session.Log("Exception occurred as Message: {0}\r\n StackTrace: {1}", ex.Message, ex.StackTrace);
                return ActionResult.Failure;
            }
            return ActionResult.Success;
        }

        private static void GetFile(Session session)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };
            
            var openDir = session["CA_DC_OPEN_DIR"];
            if (openDir != null && !string.Empty.Equals(openDir))
            {
                dialog.InitialDirectory = openDir;
            }

            CommonFileDialogResult result = dialog.ShowDialog(GetForegroundWindow());

            if ("Ok".Equals(result.ToString()))
            {
                session["CHOSEN_DIRECTORY"] = dialog.FileName;
            }

        }
    }
}
