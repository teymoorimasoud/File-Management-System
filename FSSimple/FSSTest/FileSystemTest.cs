using System;
using Xunit;
using FSSimpleLib;

namespace FSSTest
{
    public class FileSystemTest
    {
        #region Folder

        #region Success

        [Fact]
        public void AddFolder_Success()
        {
            var user = "Admin";

            var volem = new Folder("C", user);

            var AddFolderResponse = volem.Add("NewFolder", user);

            Assert.Equal(string.Empty, AddFolderResponse);
        }

        #endregion

        #region Fials

        #endregion
        #endregion

        #region File

        #region Success

        [Fact]
        public void AddFile_Success()
        {
            var user = "Admin";

            var volem = new Folder("C", user);

            var AddFileResponse = volem.Add("File1", user, "txt", 10);

            Assert.Equal(string.Empty, AddFileResponse);
        }

        #endregion

        #region Fials

        #endregion
        #endregion

    }
}
