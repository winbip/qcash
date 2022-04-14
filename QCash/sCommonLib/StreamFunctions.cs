using System;
using System.IO;

namespace sCommonLib
{
    public class StreamFunctions : IDisposable
    {
        private string mFileDirectory;
        private string mFileName;
        private string mFileNameWithFullPath;


        //If Neither FileName nor Directory is supplied, then default directory and filename is used.
        public StreamFunctions()
        {
            mFileName = "ErrorLog.txt";
            mFileDirectory = Path.GetDirectoryName(typeof(StreamFunctions).Assembly.Location);
            mFileNameWithFullPath = mFileDirectory + "\\" + mFileName;
        }


        //If FileName supplied but directory is not supplied, then default directory is used.
        public StreamFunctions(string FileName)
        {
            mFileName = FileName;

            //'it returns full path with the .dll name
            //mFileDirectory = System.Reflection.Assembly.GetAssembly(Me.GetType()).Location

            //'it returns full path with the .dll name. Its an alternative of the above
            // mFileDirectory = GetType(ThisClassName).Assembly.Location 

            //'it returns full path of the .dll without the .dll name.
            //mFileDirectory = Path.GetDirectoryName(GetType(StreamOperation).Assembly.Location)

            mFileDirectory = Path.GetDirectoryName(typeof(StreamFunctions).Assembly.Location);
            mFileNameWithFullPath = mFileDirectory + "\\" + mFileName;
        }

        //If both File name and directory is supplied, use those directory and filename
        public StreamFunctions(string FileName, string FileDirectory)
        {
            mFileName = FileName;
            mFileDirectory = FileDirectory;
            mFileNameWithFullPath = mFileDirectory + "\\" + mFileName;
        }

        public bool IsFileExist()
        {
            if (File.Exists(mFileNameWithFullPath) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Create a new text file
        public void CreateFile()
        {
            if ((!File.Exists(mFileNameWithFullPath)))
            {
                FileStream fs = new FileStream(mFileNameWithFullPath, FileMode.Create, FileAccess.Write, FileShare.None);
                fs.Close();
                fs.Dispose();
                fs = null;
            }
        }

        //Delete a file
        public void DeleteFile()
        {
            if ((File.Exists(mFileNameWithFullPath)))
            {
                File.Delete(mFileNameWithFullPath);
            }
        }

        //Create a new text file. this is an alternative of the above function. Both do same work.
        //public bool CreateFileOpt()
        //{
        //    FileStream fs = null;
        //    if ((!File.Exists(mFileNameWithFullPath)))
        //    {
        //        fs = File.Create(mFileNameWithFullPath);
        //        using (fs)
        //        {

        //        }
        //    }
        //}

        //Write new text to the file and replace the existing text. 
        public void WriteText(string Text)
        {
            //It will automatically create the file specified, if not exists.
            using (StreamWriter Writer = new StreamWriter(mFileNameWithFullPath, false))
            {
                Writer.Write(Text);
            }
        }

        //Write new text to the file and replace the existing text.this is an alternative of the above method. Both do same work.
        public void WriteTextOpt(string Text)
        {
            if (File.Exists(mFileNameWithFullPath))
            {
                FileStream FS = new FileStream(mFileNameWithFullPath, FileMode.Open, FileAccess.Write, FileShare.None);
                StreamWriter Writer = new StreamWriter(FS);
                Writer.Write(Text);
                Writer.Close();
                Writer.Dispose();
                FS.Close();
                FS.Dispose();
            }
            else
            {
                CreateFile();
                WriteText(Text);
            }
        }

        //Append new text to the file
        public void AppendText(string Text)
        {
            //It will automatically create the file specified, if not exists.
            using (StreamWriter Writer = new StreamWriter(mFileNameWithFullPath, true))
            {
                Writer.WriteLine(Text);
            }
        }

        //Append new text to the file.this is an alternative of the above method. Both do same work.
        public void AppendTextOpt(string Text)
        {
            if (File.Exists(mFileNameWithFullPath))
            {
                FileStream FS = new FileStream(mFileNameWithFullPath, FileMode.Append, FileAccess.Write, FileShare.None);
                StreamWriter Writer = new StreamWriter(FS);
                Writer.Write(Text);
                Writer.Close();
                Writer.Dispose();
                FS.Close();
                FS.Dispose();
            }
            else
            {
                CreateFile();
                WriteText(Text);
            }
        }

        //Read only first line from the file
        public string ReadText()
        {
            string Text = string.Empty;
            if (File.Exists(mFileNameWithFullPath) == true)
            {
                using (StreamReader Reader = new StreamReader(mFileNameWithFullPath))
                {
                    Text = Reader.ReadLine();
                    if (Text == null)
                    {
                        Text = string.Empty;
                    }
                }
            }

            return Text;

        }

        //Read only first line from the file
        //public string ReadTextOpt()
        //{
        //    string Text = string.Empty;


        //    if (File.Exists(mFileNameWithFullPath) == true)
        //    {
        //        FileStream fs = new FileStream(mFileNameWithFullPath, FileMode.Open, FileAccess.Read, FileShare.None);
        //        StreamReader Reader = new StreamReader(fs);
        //        Text = Reader.ReadLine;
        //        Reader.Close();
        //        Reader.Dispose();
        //        fs.Close();
        //        fs.Dispose();
        //    }

        //    return Text;
        //}


        //Read the entire file
        public string ReadFile()
        {
            string Text = string.Empty;
            if (File.Exists(mFileNameWithFullPath) == true)
            {
                using (StreamReader Reader = new StreamReader(mFileNameWithFullPath))
                {
                    Text = Reader.ReadToEnd();
                }
            }

            return Text;

        }

        ////Read only first line from the file
        //public string ReadFileOpt()
        //{
        //    string Text = string.Empty;


        //    if (File.Exists(mFileNameWithFullPath) == true)
        //    {
        //        FileStream fs = new FileStream(mFileNameWithFullPath, FileMode.Open, FileAccess.Read, FileShare.None);
        //        StreamReader Reader = new StreamReader(fs);
        //        Text = Reader.ReadToEnd;
        //        Reader.Close();
        //        Reader.Dispose();
        //        fs.Close();
        //        fs.Dispose();
        //    }

        //    return Text;
        //}

        //Append new text to the file


        public static void CreateErrorLog(string ErrorMsg)
        {
            //string DefaultLogFileName = "ErrorLog.log";
            //string DefaultFileDirectory = Path.GetDirectoryName(typeof(StreamFunctions).Assembly.Location);
            //string LogFilePath = DefaultFileDirectory + "\\" + DefaultLogFileName;

            string MyDocumentsDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //TODO: Change Application Name
            string AppDataDirectoryPath = Path.Combine(MyDocumentsDirectoryPath, "QCash Accounting System V6");
            string LogFilePath = Path.Combine(AppDataDirectoryPath, "ErrorLog.log");

            //It will automatically create the file specified, if not exists.
            using (StreamWriter Writer = new StreamWriter(LogFilePath, true))
            {
                Writer.WriteLine(ErrorMsg);
            }
        }




        #region iDisposable_mthods

        private bool disposed = false;


        public void Dispose()
        {
            // Call our helper method.
            //Specifying "true" signifies that
            // the object user triggered the cleanup.
            CleanUp(true);

            // Now suppress finalization.
            GC.SuppressFinalize(this);
        }

        private void CleanUp(bool disposing)
        {
            // Be sure we have not already been disposed!
            if (!this.disposed)
            {
                // If disposing equals true, dispose all
                // managed resources.
                if (disposing)
                {
                    // Dispose managed resources.
                }
                // Clean up unmanaged resources here.
            }
            disposed = true;
        }

        ~StreamFunctions()
        {
            CleanUp(false);
        }

        #endregion


    }
}
