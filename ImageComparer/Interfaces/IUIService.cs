using System;

namespace ImageComparer.Interfaces
{
    public interface IUIService
    {
        string LoadFileDialog();
        string SelectFolderDialog();
    }
}
