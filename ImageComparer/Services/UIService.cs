using System;
using ImageComparer.Interfaces;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ImageComparer.Services
{
    class UIService : IUIService
    {
        #region IUIService Members

        public string LoadFileDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                CheckPathExists = true,
                CheckFileExists = true,
                DefaultExt = "*",
                AddExtension = true,
                Multiselect = false
            };

            if (dlg.ShowDialog() == true)
                return dlg.FileName;

            return string.Empty;
        }

        public string SelectFolderDialog()
        {
            var dlg = new CommonOpenFileDialog
            {
                Title = "Select a folder",
                IsFolderPicker = true,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),

                AddToMostRecentlyUsedList = false,
                AllowNonFileSystemItems = false,
                DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer),
                EnsureFileExists = true,
                EnsurePathExists = true,
                EnsureReadOnly = false,
                EnsureValidNames = true,
                Multiselect = false,
                ShowPlacesList = true
            };

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
                return dlg.FileName;

            return string.Empty;
        }

        #endregion
    }
}
