using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Projektarbeit_Client.TCP.Commands;
using Projektarbeit_Client.TCP.Datatype;
using MySql.Data.MySqlClient;

using Newtonsoft.Json;

using Projektarbeit_TCP_Server.TemporaryDataSafe;

using Projektarbeit_Client;

namespace Projektarbeit_TCP_Server.TCP
{
    class CommandProzessor
    {
        public static string ProzessCommand(string Command)
        {

            // Layout
            // <PAC> COMMAND <PAC> 


            if (Command.Contains("<PAC>Login<PAC>"))
            {
                return Login(Command);
            }

            if (Command.Contains("<PAC>Register<PAC>"))
            {
                return Register(Command);
            }
            if (Command.Contains("<PAC>ActivateAccount<PAC>"))
            {
                return ActivationAccount(Command);
            }
            if (Command.Contains("<PAC>CreateClass<PAC>"))
            {
                return CreateClass(Command);
            }
            if (Command.Contains("<PAC>JoinClass<PAC>"))
            {
                return JoinClass(Command);
            }
            if (Command.Contains("<PAC>ResetPassword<PAC>"))
            {
                return ResetPassword(Command);
            }
            if (Command.Contains("<PAC>SendNewActivationCode<PAC>"))
            {
                return SendActivationCode(Command);
            }
            if (Command.Contains("<PAC>SendNewPasswordCode<PAC>"))
            {
                return SendPasswordCode(Command);
            }
            if (Command.Contains("<PAC>GetUserData<PAC>"))
            {
                return GetUserData(Command);
            }
            if (Command.Contains("<PAC>GetClassData<PAC>"))
            {
                return GetClassData(Command);
            }
            
            if (Command.Contains("<PAC>SetRechte<PAC>"))
            {
                return SetRechte(Command);
            }
            if (Command.Contains("<PAC>SetClassData<PAC>"))
            {
                return SetClassData(Command);
            }
            if (Command.Contains("<PAC>SetStundenplan<PAC>"))
            {
                return SetStundenplan(Command);
            }
            if (Command.Contains("<PAC>NewTask<PAC>"))
            {
                return AddTask(Command);
            }
            if (Command.Contains("<PAC>DeleteTask<PAC>"))
            {
                return DeleteTask(Command);
            }
            if (Command.Contains("<PAC>NewTermin<PAC>"))
            {
                return AddTermin(Command);
            }
            if (Command.Contains("<PAC>DeleteTermin<PAC>"))
            {
                return DeleteTermin(Command);
            }
            if (Command.Contains("<PAC>SendInvite<PAC>"))
            {
                return SendInvite(Command);
            }
            if (Command.Contains("<PAC>LeaveClass<PAC>"))
            {
                return LeaveClass(Command);
            }



            return "";
        }
        
        private static string Login(string CommandPara)
        {
            SQLManager.Connection.Close();

            LoginCommand Command = new LoginCommand();
            Command = JsonConvert.DeserializeObject<LoginCommand>(CommandPara);

            ResultWithNoData result = new ResultWithNoData();

            if (CheckUserData(Command.EMail, Command.Hash))
            {
                result.statusCode = 201;
            }
            else
            {
                result.statusCode = 202;
            }

            return JsonConvert.SerializeObject(result);
        }

        private static string Register(string CommandPara)
        {
            SQLManager.Connection.Close();

            ResultWithNoData result = new ResultWithNoData();

            RegisterCommand Command = new RegisterCommand();
            Command = JsonConvert.DeserializeObject<RegisterCommand>(CommandPara);

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT EMail FROM users WHERE EMail='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    string MySQL_EMail = mysqlreader.GetString("EMail");

                    if (MySQL_EMail.Equals(Command.EMail, StringComparison.InvariantCultureIgnoreCase))
                    {
                        mysqlreader.Close();
                        SQLManager.Connection.Close();

                        result.statusCode = 301;
                        return JsonConvert.SerializeObject(result);
                    }
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "INSERT INTO users (Firstname,Lastname,Gender,EMail,Password) VALUES (?Firstname,?Lastname,?Gender,?EMail,?Password)";

                mysqlCommand.Parameters.AddWithValue("?Firstname", Command.FirstName);
                mysqlCommand.Parameters.AddWithValue("?LastName", Command.LastName);
                mysqlCommand.Parameters.AddWithValue("?Gender", Command.Gender);
                mysqlCommand.Parameters.AddWithValue("?EMail", Command.EMail);
                mysqlCommand.Parameters.AddWithValue("?Password", Command.PasswordHash);

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }

            result.statusCode = 201;
            return JsonConvert.SerializeObject(result);
        }

        private static string GetUserData(string CommandPara)
        {
            SQLManager.Connection.Close();

            UserData Result = new UserData();
            GetUserDataCommand Command = new GetUserDataCommand();
            Command = JsonConvert.DeserializeObject<GetUserDataCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();
                mysqlCommand.CommandText = "SELECT UID, Firstname, Lastname, Gender, HasSelected, HasActivated FROM users WHERE EMail='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();


                if (mysqlreader.Read())
                {

                    Result.UID = mysqlreader.GetInt32("UID");
                    Result.Firstname = mysqlreader.GetString("Firstname");
                    Result.Lastname = mysqlreader.GetString("Lastname");
                    Result.Gender = mysqlreader.GetString("Gender");
                    Result.HasActivated = mysqlreader.GetBoolean("HasActivated");
                    Result.HasSelected = mysqlreader.GetBoolean("HasSelected");

                }

                mysqlreader.Close();

                SQLManager.Connection.Close();

                Result.statusCode = 201;

                return JsonConvert.SerializeObject(Result);
            }

        }

        private static bool CheckUserData(string EMail, string Password)
        {
            SQLManager.Connection.Close();
            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                mysqlCommand.CommandText = "SELECT EMail, Password FROM users WHERE EMail='" + EMail + "'";

                SQLManager.Connection.Open();
                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    string MySQL_EMail = mysqlreader.GetString("EMail");
                    string MySQL_Hash = mysqlreader.GetString("Password");
                    if (MySQL_EMail.Equals(EMail, StringComparison.InvariantCultureIgnoreCase) && MySQL_Hash.Equals(Password, StringComparison.InvariantCultureIgnoreCase))
                    {

                        mysqlreader.Close();

                        SQLManager.Connection.Close();
                        return true;
                    }
                    else
                    {

                        mysqlreader.Close();

                        SQLManager.Connection.Close();
                        return false;
                    }
                }
                else
                {

                    mysqlreader.Close();

                    SQLManager.Connection.Close();
                    return false;
                }
               
            }

        }
        public static string SendActivationCode(string CommandPara)
        {
            SQLManager.Connection.Close();

            SendNewActivationCodeCommand Command = new SendNewActivationCodeCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Random rand = new Random();

            Command = JsonConvert.DeserializeObject<SendNewActivationCodeCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;
                return JsonConvert.SerializeObject(Result);
            }

            int random = rand.Next(0, 999999);

            Mail_Server.sendActivationCode(random, Command.EMail);

            ActivationCodesSafe.addData(Command.EMail,random);

            Result.statusCode = 201;

            string test = JsonConvert.SerializeObject(Result);

            return test;
        }

        public static string ActivationAccount(string CommandPara)
        {
            SQLManager.Connection.Close();

            ActivateAccountCommand Command = new ActivateAccountCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Random rand = new Random();

            Command = JsonConvert.DeserializeObject<ActivateAccountCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;
                return JsonConvert.SerializeObject(Result);
            }

            CodeEmailSafe tmp = ActivationCodesSafe.getData(Command.EMail);
            
            if(Command.Code == tmp.Code)
            {
                ActivationCodesSafe.RemoveData(Command.EMail);
                Result.statusCode = 201;
                using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
                {
                    SQLManager.Connection.Open();
                    mysqlCommand.CommandText = "UPDATE `users` SET `HasActivated` = '1' WHERE `EMail` = '" + Command.EMail + "'";

                    mysqlCommand.ExecuteNonQuery();

                    SQLManager.Connection.Close();

                }

                 Result.statusCode = 201;
               
            }
            else
            {
                Result.statusCode = 202;
            }

            return JsonConvert.SerializeObject(Result);
        }
        public static string SendPasswordCode(string CommandPara)
        {
            SQLManager.Connection.Close();

            SendNewPasswordCodeCommand Command = new SendNewPasswordCodeCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Random rand = new Random();

            Command = JsonConvert.DeserializeObject<SendNewPasswordCodeCommand>(CommandPara);

            int random = rand.Next(0, 999999);

            Mail_Server.sendPasswordCode(random, Command.EMail);

            PasswordCodesSafe.addData(Command.EMail, random);

            Result.statusCode = 201;

            return JsonConvert.SerializeObject(Result);
        }

        public static string ResetPassword(string CommandPara)
        {
            SQLManager.Connection.Close();

            ResetPasswordCommand Command = new ResetPasswordCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Random rand = new Random();

            Command = JsonConvert.DeserializeObject<ResetPasswordCommand>(CommandPara);

            CodeEmailSafe tmp = PasswordCodesSafe.getData(Command.EMail);

            if (tmp == null)
            {
                Result.statusCode = 202;
                return JsonConvert.SerializeObject(Result);
            }

            if (Command.Code == tmp.Code)
            {
                PasswordCodesSafe.RemoveData(Command.EMail);
                using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
                {
                    SQLManager.Connection.Open();
                    mysqlCommand.CommandText = "UPDATE `users` SET `Password` = '"+ Command.NewHash +"' WHERE `EMail` = '" + Command.EMail + "'";

                    mysqlCommand.ExecuteNonQuery();

                    SQLManager.Connection.Close();

                }

                Result.statusCode = 201;

            }
            else
            {
                Result.statusCode = 202;
            }

            return JsonConvert.SerializeObject(Result);
        }

        public static string CreateClass(string CommandPara)
        {
            SQLManager.Connection.Close();

            CreateClassCommand Command = new CreateClassCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Random rand = new Random();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<CreateClassCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT Creator FROM classes WHERE Creator='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    string MySQL_EMail = mysqlreader.GetString("Creator");

                    if (MySQL_EMail.Equals(Command.EMail, StringComparison.InvariantCultureIgnoreCase))
                    {
                        mysqlreader.Close();
                        SQLManager.Connection.Close();

                        Result.statusCode = 301;
                        return JsonConvert.SerializeObject(Result);
                    }
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "INSERT INTO classes (Creator,Name,Description,School,Perm_changeStundenplan, Perm_createAufgabe, Perm_deleteAufgabe, Perm_createTermin, Perm_deleteTermin ) VALUES (?Creator,?ClassName,?Description,?School,?changeStundenplan, ?createAufgabe, ?deleteAufgabe, ?createTermin, ?deleteTermin )";

                
                mysqlCommand.Parameters.AddWithValue("?Creator", Command.EMail);
                mysqlCommand.Parameters.AddWithValue("?ClassName", Command.ClassName);
                mysqlCommand.Parameters.AddWithValue("?Description", Command.Description);
                mysqlCommand.Parameters.AddWithValue("?School", Command.School);
                mysqlCommand.Parameters.AddWithValue("?changeStundenplan", Command.changeStundenplan);
                mysqlCommand.Parameters.AddWithValue("?createAufgabe", Command.createAufgabe);
                mysqlCommand.Parameters.AddWithValue("?deleteAufgabe", Command.deleteAufgabe);
                mysqlCommand.Parameters.AddWithValue("?createTermin", Command.createTermin);
                mysqlCommand.Parameters.AddWithValue("?deleteTermin", Command.deleteTermin);

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM classes WHERE Creator='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE `users` SET `CID` = '" + cid + "' WHERE `EMail` = '" + Command.EMail + "'";

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();
                mysqlCommand.CommandText = "UPDATE `users` SET `HasSelected` = '1' WHERE `EMail` = '" + Command.EMail + "'";

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();

            }
            Result.statusCode = 201;
            return JsonConvert.SerializeObject(Result);
        }

        public static string JoinClass(string CommandPara) {
            SQLManager.Connection.Close();

            JoinClassCommand Command = new JoinClassCommand();
            ResultWithNoData Result = new ResultWithNoData();

            Command = JsonConvert.DeserializeObject<JoinClassCommand>(CommandPara);

            CodeEMailCIDSafe tmp = InviteCodesSafe.getData(Command.EMail);

            if(tmp == null)
            {
                Result.statusCode = 202;
                return JsonConvert.SerializeObject(Result);
            }

            if (Command.Code == tmp.Code)
            {
                InviteCodesSafe.RemoveData(Command.EMail);
                using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
                {
                    SQLManager.Connection.Open();
                    mysqlCommand.CommandText = "UPDATE `users` SET `CID` = '" + tmp.CID + "' WHERE `EMail` = '" + Command.EMail + "'";

                    mysqlCommand.ExecuteNonQuery();

                    SQLManager.Connection.Close();

                }

                using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
                {
                    SQLManager.Connection.Open();

                    mysqlCommand.CommandText = "UPDATE users SET HasSelected = 1 WHERE EMail = ?email";

                    mysqlCommand.Parameters.AddWithValue("?email", Command.EMail);

                    mysqlCommand.ExecuteNonQuery();

                    SQLManager.Connection.Close();
                }

                Result.statusCode = 201;

            }
            else
            {
                Result.statusCode = 202;
            }

            return JsonConvert.SerializeObject(Result);
        }

        private static string GetClassData(string CommandPara)
        {
            SQLManager.Connection.Close();

            ClassData Result = new ClassData();
            GetClassDataCommand Command = new GetClassDataCommand();
            Command = JsonConvert.DeserializeObject<GetClassDataCommand>(CommandPara);
            int cid = 0;

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM users WHERE EMail='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();
                mysqlCommand.CommandText = "SELECT Name,Description,School , Creator, Perm_changeStundenplan, Perm_createAufgabe, Perm_deleteAufgabe, Perm_createTermin, Perm_deleteTermin, Stundenplan, Aufgaben, Termine FROM classes WHERE CID='" + cid + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.Read())
                {

                    Result.ClassName = mysqlreader.GetString("Name");
                    Result.Description = mysqlreader.GetString("Description");
                    Result.School = mysqlreader.GetString("School");
                    Result.Creator = mysqlreader.GetString("Creator");
                    Result.changeStundenplan = mysqlreader.GetBoolean("Perm_changeStundenplan");
                    Result.createAufgabe = mysqlreader.GetBoolean("Perm_createAufgabe");
                    Result.deleteAufgabe = mysqlreader.GetBoolean("Perm_deleteAufgabe");
                    Result.createTermin = mysqlreader.GetBoolean("Perm_createTermin");
                    Result.deleteTermin = mysqlreader.GetBoolean("Perm_deleteTermin");
                    Result.Stundenplan = mysqlreader.GetString("Stundenplan");
                    Result.Aufgabe = mysqlreader.GetString("Aufgaben");
                    Result.Termin = mysqlreader.GetString("Termine");

                }

                mysqlreader.Close();

                SQLManager.Connection.Close();

                Result.statusCode = 201;

                return JsonConvert.SerializeObject(Result);
            }
        }

        private static string SetRechte(string CommandPara)
        {
            SQLManager.Connection.Close();

            SetRechteCommand Command = new SetRechteCommand();
            ResultWithNoData Result = new ResultWithNoData();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<SetRechteCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM classes WHERE Creator='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                   cid = mysqlreader.GetInt32("CID"); 
                }
                else
                {
                    Result.statusCode = 270;
                    return JsonConvert.SerializeObject(Result);
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();

                
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE classes SET Perm_changeStundenplan = ?changeStundenplan, Perm_createAufgabe = ?createAufgabe, Perm_deleteAufgabe = ?deleteAufgabe, Perm_createTermin = ?createTermin , Perm_deleteTermin = ?deleteTermin WHERE CID = ?CID";

                mysqlCommand.Parameters.AddWithValue("?CID", cid);

                mysqlCommand.Parameters.AddWithValue("?changeStundenplan", Command.changeStundenplan);
                mysqlCommand.Parameters.AddWithValue("?createAufgabe", Command.createAufgabe);
                mysqlCommand.Parameters.AddWithValue("?deleteAufgabe", Command.deleteAufgabe);
                mysqlCommand.Parameters.AddWithValue("?createTermin", Command.createTermin);
                mysqlCommand.Parameters.AddWithValue("?deleteTermin", Command.deleteTermin);

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }

            Result.statusCode = 201;
            return JsonConvert.SerializeObject(Result);
        }

        private static string SetClassData(string CommandPara)
        {
            SQLManager.Connection.Close();

            SetClassDataCommand Command = new SetClassDataCommand();
            ResultWithNoData Result = new ResultWithNoData();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<SetClassDataCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM classes WHERE Creator='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }
                else
                {
                    Result.statusCode = 270;
                    return JsonConvert.SerializeObject(Result);
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();


            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE classes SET Name = ?classname, Description = ?beschreibung, School = ?school  WHERE CID = ?CID";

                mysqlCommand.Parameters.AddWithValue("?CID", cid);

                mysqlCommand.Parameters.AddWithValue("?classname", Command.ClassName);
                mysqlCommand.Parameters.AddWithValue("?beschreibung", Command.Description);
                mysqlCommand.Parameters.AddWithValue("?school", Command.School);

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }

            Result.statusCode = 201;
            return JsonConvert.SerializeObject(Result);
        }



        private static string SetStundenplan(string CommandPara)
        {
            SQLManager.Connection.Close();

            SetStundenplanCommand Command = new SetStundenplanCommand();
            ResultWithNoData Result = new ResultWithNoData();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<SetStundenplanCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM users WHERE EMail='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }
                else
                {
                    Result.statusCode = 270;
                    return JsonConvert.SerializeObject(Result);
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();


            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE classes SET Stundenplan = ?Stundenplan WHERE CID = ?CID";

                mysqlCommand.Parameters.AddWithValue("?CID", cid);

                mysqlCommand.Parameters.AddWithValue("?Stundenplan", Command.Stundenplan);

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }

            Result.statusCode = 201;
            return JsonConvert.SerializeObject(Result);
        }

        private static string AddTask(string CommandPara)
        {
            SQLManager.Connection.Close();

            NewTaskCommand Command = new NewTaskCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Aufgaben auf = new Aufgaben();
            AufgabenListViewItem list = new AufgabenListViewItem();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<NewTaskCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM users WHERE EMail='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }
                else
                {
                    return JsonConvert.SerializeObject(Result);
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();


            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT Aufgaben FROM classes WHERE CID='" + cid + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();
                    string aufm = mysqlreader.GetString("Aufgaben");
                    if(aufm != "")
                    {
                        auf = JsonConvert.DeserializeObject<Aufgaben>(aufm);
                    }
                    

                }
                mysqlreader.Close();
                SQLManager.Connection.Close();

            }

            list.Title = Command.Title;
            list.Description = Command.Description;
            list.EndDate = Command.EndDate;
            list.StartDate = DateTime.Now.ToShortDateString();
            auf.Tasks.Add(list);

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE classes SET Aufgaben = ?aufgaben WHERE CID = ?CID";

                mysqlCommand.Parameters.AddWithValue("?CID", cid);

                mysqlCommand.Parameters.AddWithValue("?aufgaben", JsonConvert.SerializeObject(auf));

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }


            Result.statusCode = 201;

            return JsonConvert.SerializeObject(Result);

        }

        private static string DeleteTask(string CommandPara)
        {
            SQLManager.Connection.Close();

            DeleteTaskCommand Command = new DeleteTaskCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Aufgaben auf = new Aufgaben();
            AufgabenListViewItem list = new AufgabenListViewItem();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<DeleteTaskCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM users WHERE EMail='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }
                else
                {
                    return JsonConvert.SerializeObject(Result);
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();


            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT Aufgaben FROM classes WHERE CID='" + cid + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();
                    string aufm = mysqlreader.GetString("Aufgaben");
                    if (aufm != "")
                    {
                        auf = JsonConvert.DeserializeObject<Aufgaben>(aufm);
                    }


                }
                mysqlreader.Close();
                SQLManager.Connection.Close();

            }



             list = auf.Tasks.Find(x => x.Id.ToString().Contains(Command.ID.ToString()));
            auf.Tasks.Remove(list);

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE classes SET Aufgaben = ?aufgaben WHERE CID = ?CID";

                mysqlCommand.Parameters.AddWithValue("?CID", cid);

                mysqlCommand.Parameters.AddWithValue("?aufgaben", JsonConvert.SerializeObject(auf));

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }


            Result.statusCode = 201;

            return JsonConvert.SerializeObject(Result);

        }

        private static string AddTermin(string CommandPara)
        {
            SQLManager.Connection.Close();

            NewTerminCommand Command = new NewTerminCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Termine auf = new Termine();
            TerminListViewItem list = new TerminListViewItem();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<NewTerminCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM users WHERE EMail='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }
                else
                {
                    return JsonConvert.SerializeObject(Result);
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();


            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT Termine FROM classes WHERE CID='" + cid + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();
                    string aufm = mysqlreader.GetString("Termine");
                    if (aufm != "")
                    {
                        auf = JsonConvert.DeserializeObject<Termine>(aufm);
                    }


                }
                mysqlreader.Close();
                SQLManager.Connection.Close();

            }

            list.Title = Command.Title;
            list.Description = Command.Description;
            list.EndDate = Command.EndDate;
            auf.Tasks.Add(list);

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE classes SET Termine = ?termine WHERE CID = ?CID";

                mysqlCommand.Parameters.AddWithValue("?CID", cid);

                mysqlCommand.Parameters.AddWithValue("?termine", JsonConvert.SerializeObject(auf));

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }


            Result.statusCode = 201;

            return JsonConvert.SerializeObject(Result);

        }

        private static string DeleteTermin(string CommandPara)
        {
            SQLManager.Connection.Close();

            DeleteTerminCommand Command = new DeleteTerminCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Termine auf = new Termine();
            TerminListViewItem list = new TerminListViewItem();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<DeleteTerminCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM users WHERE EMail='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }
                else
                {
                    mysqlreader.Close();
                    SQLManager.Connection.Close();
                    return JsonConvert.SerializeObject(Result);
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();


            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT Termine FROM classes WHERE CID='" + cid + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();
                    string aufm = mysqlreader.GetString("Termine");
                    if (aufm != "")
                    {
                        auf = JsonConvert.DeserializeObject<Termine>(aufm);
                    }


                }
                mysqlreader.Close();
                SQLManager.Connection.Close();

            }



            list = auf.Tasks.Find(x => x.Id.ToString().Contains(Command.ID.ToString()));
            auf.Tasks.Remove(list);

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE classes SET Termine = ?termine WHERE CID = ?CID";

                mysqlCommand.Parameters.AddWithValue("?CID", cid);

                mysqlCommand.Parameters.AddWithValue("?termine", JsonConvert.SerializeObject(auf));

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }


            Result.statusCode = 201;

            return JsonConvert.SerializeObject(Result);

        }

        private static string SendInvite(string CommandPara){

            SQLManager.Connection.Close();

            SendInviteCommand Command = new SendInviteCommand();
            ResultWithNoData Result = new ResultWithNoData();
            Random rand = new Random();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<SendInviteCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;

                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM classes WHERE Creator='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }
                else
                {
                    mysqlreader.Close();
                    SQLManager.Connection.Close();
                    return JsonConvert.SerializeObject(Result);
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();


            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                mysqlCommand.CommandText = "SELECT EMail FROM users WHERE EMail='" + Command.EMail_Target + "'";

                SQLManager.Connection.Open();
                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    string MySQL_EMail = mysqlreader.GetString("EMail");
                    if (MySQL_EMail.Equals(Command.EMail_Target, StringComparison.InvariantCultureIgnoreCase))
                    {

                        mysqlreader.Close();
                        SQLManager.Connection.Close();
                        
                    }
                    else
                    {
                        mysqlreader.Close();
                        SQLManager.Connection.Close();
                        Result.statusCode = 202;
                        return JsonConvert.SerializeObject(Result);
                    }
                }
                else
                {
                    mysqlreader.Close();
                    SQLManager.Connection.Close();
                    Result.statusCode = 202;
                    return JsonConvert.SerializeObject(Result);

                }
                

            }

            int random = rand.Next(0, 999999);

            Mail_Server.sendClassInviteCode(random, Command.EMail_Target);

            InviteCodesSafe.addData(Command.EMail_Target, random, cid);

            Result.statusCode = 201;

            return JsonConvert.SerializeObject(Result);
        }

        private static string LeaveClass(string CommandPara)
        {
            SQLManager.Connection.Close();

            LeaveClassCommand Command = new LeaveClassCommand();
            ResultWithNoData Result = new ResultWithNoData();
            int cid = 0;

            Command = JsonConvert.DeserializeObject<LeaveClassCommand>(CommandPara);

            if (CheckUserData(Command.EMail, Command.Hash) == false)
            {
                Result.statusCode = 270;
                return JsonConvert.SerializeObject(Result);
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "SELECT CID FROM users WHERE EMail='" + Command.EMail + "'";

                MySqlDataReader mysqlreader;

                mysqlreader = mysqlCommand.ExecuteReader();

                if (mysqlreader.HasRows)
                {
                    mysqlreader.Read();

                    cid = mysqlreader.GetInt32("CID");
                }
                else
                {
                    mysqlreader.Close();
                    SQLManager.Connection.Close();
                    return JsonConvert.SerializeObject(Result);
                }

                mysqlreader.Close();
                SQLManager.Connection.Close();
            }

            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE users SET HasSelected = 0 WHERE EMail = ?email";

                mysqlCommand.Parameters.AddWithValue("?email", Command.EMail);

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }
            using (MySqlCommand mysqlCommand = SQLManager.Connection.CreateCommand())
            {
                SQLManager.Connection.Open();

                mysqlCommand.CommandText = "UPDATE users SET CID = 0 WHERE EMail = ?email";

                mysqlCommand.Parameters.AddWithValue("?email", Command.EMail);

                mysqlCommand.ExecuteNonQuery();

                SQLManager.Connection.Close();
            }

            Result.statusCode = 201;
            return JsonConvert.SerializeObject(Result);

        }

    }
}
