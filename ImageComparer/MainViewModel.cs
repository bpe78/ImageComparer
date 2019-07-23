using System;
using System.IO;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;

namespace ImageComparer
{
    class MainViewModel : BindableBase
    {

        public MainViewModel()
        {

        }

        public string ReferenceImage { get; set; }

        public string Image11 { get; set; }
        public string Image12 { get; set; }
        public string Image13 { get; set; }

        public string Image21 { get; set; }
        public string Image23 { get; set; }

        public string Image31 { get; set; }
        public string Image32 { get; set; }
        public string Image33 { get; set; }

        #region BackCmd

        private ICommand _backCmd;
        public ICommand BackCmd
        {
            get
            {
                if (_backCmd == null)
                {
                    _backCmd = new DelegateCommand(GoBack, CanGoBack);
                }

                return _backCmd;
            }
        }

        private void GoBack()
        {
            System.Diagnostics.Debug.WriteLine("Going back...");
        }

        private bool CanGoBack() { return true; }

        #endregion
    }
}
