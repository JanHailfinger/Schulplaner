using System;
using System.Collections.Generic;
using System.Text;

using Projektarbeit_Client.TCP;
using Projektarbeit_Client.TCP.Commands;
using Projektarbeit_Client.TCP.Datatype;

using Newtonsoft.Json;

namespace Projektarbeit_Client
{
    class ControllPanelData
    {

        public static void DownloadClassData()
        {
            ClassData tmpdata = TCPCommandManager.DownloadClassData();
            if (tmpdata.statusCode == 201)
            {
                ClassDataSafe.ClassName = tmpdata.ClassName;
                ClassDataSafe.Description = tmpdata.Description;
                ClassDataSafe.Creator = tmpdata.Creator;
                ClassDataSafe.School = tmpdata.School;
                ClassDataSafe.changeStundenplan = tmpdata.changeStundenplan;
                ClassDataSafe.createAufgabe = tmpdata.createAufgabe;
                ClassDataSafe.deleteAufgabe = tmpdata.deleteAufgabe;
                ClassDataSafe.createTermin = tmpdata.createTermin;
                ClassDataSafe.deleteTermin = tmpdata.deleteTermin;
                ClassDataSafe.Stundenplan = tmpdata.Stundenplan;
                ClassDataSafe.Aufgabe = tmpdata.Aufgabe;
                ClassDataSafe.Termin = tmpdata.Termin;
                
                if (ClassDataSafe.Aufgabe != "")
                {
                    Aufgaben tmp = JsonConvert.DeserializeObject<Aufgaben>(ClassDataSafe.Aufgabe);
                    Tasks.Clear();
                    foreach (AufgabenListViewItem aufgab in tmp.Tasks)
                    {
                        Tasks.Add(aufgab);
                    }
                }

                if (ClassDataSafe.Termin != "")
                {
                    Termine tmp = JsonConvert.DeserializeObject<Termine>(ClassDataSafe.Termin);
                    Termine.Clear();
                    foreach (TerminListViewItem aufgab in tmp.Tasks)
                    {
                        Termine.Add(aufgab);
                    }
                }



            }
            else
            {
                ClassDataSafe.ClassName = "";
                ClassDataSafe.Description = ""; ;
                ClassDataSafe.School = "";
                ClassDataSafe.changeStundenplan = false;
                ClassDataSafe.createAufgabe = false;
                ClassDataSafe.deleteAufgabe = false;
                ClassDataSafe.createTermin = false;
                ClassDataSafe.deleteTermin = false;
                ClassDataSafe.Stundenplan = "";
            }
        }

        public static void SaveData()
        {

        }

        public static void LoadData()
        {

        }

        public static void DownloadUserData()
        {
            UserData tmpdata = TCPCommandManager.DownloadUserData();
            UserDataSafe.Code = tmpdata.statusCode;
            if(tmpdata.statusCode == 201)
            {
                UserDataSafe.UID = tmpdata.UID;
                UserDataSafe.Firstname = tmpdata.Firstname;
                UserDataSafe.Lastname = tmpdata.Lastname;
                UserDataSafe.Gender = tmpdata.Gender;
                UserDataSafe.HasActivated = tmpdata.HasActivated;
                UserDataSafe.HasSelected = tmpdata.HasSelected;
            }
            else
            {
                UserDataSafe.UID = 0;
                UserDataSafe.Firstname = "";
                UserDataSafe.Lastname = "";
                UserDataSafe.Gender = "";
                UserDataSafe.HasActivated = false;
                UserDataSafe.HasSelected = false;
            }

        }

        public static List<AufgabenListViewItem> Tasks { get; set; } = new List<AufgabenListViewItem>();

        public static List<TerminListViewItem> Termine { get; set; } = new List<TerminListViewItem>();

        public static string[,] Stunden { get; set; } = new string[5, 8] ;

    }
}
