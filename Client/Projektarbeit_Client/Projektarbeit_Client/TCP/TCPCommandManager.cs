using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Security.Cryptography;

using Xamarin.Essentials;

using Newtonsoft.Json;
using Projektarbeit_Client.TCP.Commands;
using Projektarbeit_Client.TCP.Datatype;

namespace Projektarbeit_Client.TCP
{
    class TCPCommandManager
    {
        public static string EMAIL, HASH;
        public static int Login(string email, string passwordhash)
        {
            LoginCommand command = new LoginCommand();

            command.EMail = email;
            command.Hash = TCPManager.Hash(passwordhash);

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            if(result.statusCode == 201)
            {
                setLoginData(command.EMail, command.Hash);
                getLoginData();
            }

            return result.statusCode;
        }

        public static int Register(string firstName, string lastName, string email, string password, string gender)
        {
            RegisterCommand command = new RegisterCommand();

            command.FirstName = firstName;
            command.LastName = lastName;
            command.EMail = email;
            command.PasswordHash = TCPManager.Hash(password);
            command.Gender = gender;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int CreateTask(string Title,string Description, string EndDate)
        {
            NewTaskCommand command = new NewTaskCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.Title = Title;
            command.Description = Description;
            command.EndDate = EndDate;
            command.CreateDate = DateTime.Now.Date.ToString("de - DE");

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static UserData GetUserData()
        {
            GetUserDataCommand command = new GetUserDataCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            return JsonConvert.DeserializeObject<UserData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));
          
        }

        public static int CreateClass(string ClassName, string Description, string School, bool changeStundenplan, bool createAufgabe, bool deleteAufgabe, bool createTermin, bool deleteTermin)
        {
            CreateClassCommand command = new CreateClassCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.ClassName = ClassName;
            command.Description = Description;
            command.School = School;
            command.changeStundenplan = changeStundenplan;
            command.createAufgabe = createAufgabe;
            command.deleteAufgabe = deleteAufgabe;
            command.createTermin = createTermin;
            command.deleteTermin = deleteTermin;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int JoinClass(int Code)
        {
            JoinClassCommand command = new JoinClassCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.Code = Code;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int SendNewActivationCode()
        {
            SendNewActivationCodeCommand command = new SendNewActivationCodeCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            string test = TCPManager.SendRequest(JsonConvert.SerializeObject(command));

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(test);

            return result.statusCode;
        }

        public static int ActivateAccount(int Code)
        {
           ActivateAccountCommand command = new ActivateAccountCommand();


            command.EMail = EMAIL;
            command.Hash = HASH;

            command.Code = Code;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int SendNewPasswordCode(string EMail)
        {
            SendNewPasswordCodeCommand command = new SendNewPasswordCodeCommand();

            command.EMail = EMail;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int ResetPassword(string newPassword, int Code ,string Email)
        {
            ResetPasswordCommand command = new ResetPasswordCommand();

            command.EMail = Email;
            command.NewHash = TCPManager.Hash(newPassword);
            command.Code = Code;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static UserData DownloadUserData()
        {
            GetUserDataCommand command = new GetUserDataCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            return JsonConvert.DeserializeObject<UserData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));
        }

        private static async void setLoginData(string EMail, string Password)
        {
            await SecureStorage.SetAsync("email", EMail);
            await SecureStorage.SetAsync("password_hash", Password);
        }
        private static async void getLoginData()
        {
            EMAIL = await SecureStorage.GetAsync("email");
            HASH = await SecureStorage.GetAsync("password_hash");
        }
        public static void clearLoginData()
        {
            SecureStorage.RemoveAll();
        }

        public static ClassData DownloadClassData()
        {
            GetClassDataCommand command = new GetClassDataCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            return JsonConvert.DeserializeObject<ClassData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));
        }

        public static string getEMail()
        {
            return EMAIL;
        }

        public static int SetRechte(bool changeStundenplan, bool createAufgabe, bool deleteAufgabe, bool createTermin, bool deleteTermin)
        {
            SetRechteCommand command = new SetRechteCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.changeStundenplan = changeStundenplan;
            command.createAufgabe = createAufgabe;
            command.deleteAufgabe = deleteAufgabe;
            command.createTermin = createTermin;
            command.deleteTermin = deleteTermin;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int SetClassData(string ClassName,string Description, string School)
        {
            SetClassDataCommand command = new SetClassDataCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.ClassName = ClassName;
            command.Description = Description;
            command.School = School;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int SetStundenplan(string Stundenplan)
        {
            SetStundenplanCommand command = new SetStundenplanCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.Stundenplan = Stundenplan;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static string GetStundenplan()
        {
            SetStundenplanCommand command = new SetStundenplanCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

          
            return TCPManager.SendRequest(JsonConvert.SerializeObject(command));
        }

        public static int DeleteTask(int id)
        {
            DeleteTaskCommand command = new DeleteTaskCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.ID = id;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int DeleteTermin(int id)
        {
            DeleteTerminCommand command = new DeleteTerminCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.ID = id;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int CreateTermin(string Title, string Description, string EndDate)
        {
            NewTerminCommand command = new NewTerminCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.Title = Title;
            command.Description = Description;
            command.EndDate = EndDate;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int SendInvite(string EMail_target)
        {
            SendInviteCommand command = new SendInviteCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            command.EMail_Target = EMail_target;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

        public static int LeaveClass()
        {
            LeaveClassCommand command = new LeaveClassCommand();

            command.EMail = EMAIL;
            command.Hash = HASH;

            ResultWithNoData result = JsonConvert.DeserializeObject<ResultWithNoData>(TCPManager.SendRequest(JsonConvert.SerializeObject(command)));

            return result.statusCode;
        }

    }
}
