﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using Org.BouncyCastle.Utilities;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;


namespace Sistema_de_Gerenciamento_da_Rede_de_Catadores_do_Ceará__Versão_Teste_
{
    public class CriarDesktop
    {


        [DllImport("shell32.dll")]
        static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, [Out] StringBuilder lpszPath, int nFolder, bool fCreate);
        const int CSIDL_COMMON_DESKTOPDIRECTORY = 0x19;

        public void CreateDesktopShortcutForAllUsers()
        {


            StringBuilder allUserProfile = new StringBuilder(260);
            SHGetSpecialFolderPath(IntPtr.Zero, allUserProfile, CSIDL_COMMON_DESKTOPDIRECTORY, false);
            //The above API call returns: C:UsersPublicDesktop 
            string settingsLink = Path.Combine(allUserProfile.ToString(), "Sistema de Gerenciamento da Rede de Catadores de Resíduos Sólidos Recicláveis do Estado do Ceará.lnk");
            //Create All Users Desktop Shortcut for Application Settings
            WshShell shellClass = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shellClass.CreateShortcut(settingsLink);
            shortcut.TargetPath = System.Environment.CurrentDirectory + @"\SGRCRSREC.exe";
            shortcut.IconLocation = System.Environment.CurrentDirectory + @"\Rede_de_Catadores_do_Ceará-removebg-preview.ico";
            //shortcut.Arguments = "arg1 arg2";
            //shortcut.Description = "Atalho para o Sistema de Gerenciamento da Rede de Catadores de Resíduos Sólidos Recicláveis do Estado do Ceará";
            
            shortcut.Save();

            
        }


    }
}
