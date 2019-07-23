using System;
using System.Windows.Input;
using ImageComparer.Interfaces;
using Prism.Commands;
using Prism.Mvvm;

namespace ImageComparer
{
    class SettingsViewModel : BindableBase
    {
        private readonly IUIService _uiService;

        public SettingsViewModel(IUIService uiService)
        {
            _uiService = uiService ?? throw new ArgumentNullException(nameof(uiService));

            UseSamePath = true;
        }

        private string _referenceImagesPath;
        public string ReferenceImagesPath
        {
            get => _referenceImagesPath;
            set
            {
                if (SetProperty(ref _referenceImagesPath, value))
                {
                    if (UseSamePath)
                        DuplicateImagesPath = ReferenceImagesPath;
                }
            }
        }

        private string _duplicateImagesPath;
        public string DuplicateImagesPath
        {
            get => _duplicateImagesPath;
            set => SetProperty(ref _duplicateImagesPath, value);
        }

        private bool _useSamePath;
        public bool UseSamePath
        {
            get => _useSamePath;
            set
            {
                if (SetProperty(ref _useSamePath, value))
                    RaisePropertyChanged(nameof(IsEnabledDuplicatePath));
            }
        }

        public bool IsEnabledDuplicatePath
        {
            get => !_useSamePath;
        }

        #region BrowseRefCmd

        private ICommand _browseRefCmd;
        public ICommand BrowseRefCmd
        {
            get => _browseRefCmd ?? (_browseRefCmd = new DelegateCommand(BrowseRef));
        }

        private void BrowseRef()
        {
            var selectedFolder = _uiService.SelectFolderDialog();
            if (!string.IsNullOrEmpty(selectedFolder))
            {
                ReferenceImagesPath = selectedFolder;
            }
        }

        #endregion

        #region BrowseDupCmd

        private ICommand _browseDupCmd;
        public ICommand BrowseDupCmd
        {
            get => _browseDupCmd ?? (_browseDupCmd = new DelegateCommand(BrowseDup, () => !UseSamePath).ObservesProperty(() => UseSamePath));
        }

        private void BrowseDup()
        {
            var selectedFolder = _uiService.SelectFolderDialog();
            if (!string.IsNullOrEmpty(selectedFolder))
            {
                ReferenceImagesPath = selectedFolder;
            }
        }

        #endregion

        public event EventHandler CloseWindow;

        #region SaveCmd

        private ICommand _saveCmd;
        public ICommand SaveCmd
        {
            get => _saveCmd ?? (_saveCmd = new DelegateCommand(Save));
        }

        private void Save()
        {
            // close associated window
            CloseWindow?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}
