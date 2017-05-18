﻿using System.IO;

namespace Blu.core.common
{
    public static class IOHelper
    {
        public static void EmptyFolder(this string folderName)
        {
            DirectoryInfo dir = new DirectoryInfo(folderName);

            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            else
            {
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }

                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    EmptyFolder(di.FullName);
                    di.Delete();
                }
            }
        }

    }
}
