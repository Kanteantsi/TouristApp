using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tourist__Office
{
    static class DataBank
    {
        public static ClientInterface Cl = new ClientInterface();
        public static ManagerInterface Man = new ManagerInterface();
        public static AdministratorInterface Adm = new AdministratorInterface();

        public static int CurrentUserID;

        public static int CurrentClientID;
        public static string CurrentClientFullname;
        public static string CurrentClientPhoneNumber;
        public static string CurrentClientDateOfBirth;
        public static string CurrentClientEmail;
        public static string CurrentClientPassport;
        public static string CurrentClientInternationalPassport;

        public static int CurrentManagerID;
        public static string CurrentManagerFullname;
        public static string CurrentManagerEmail;
        public static string CurrentManagerPhoneNumber;
        public static string CurrentManagerDateOfBirth;

        public static int CurrentAdministratorID;
        public static string CurrentAdministratorFullname;
        public static string CurrentAdministratorEmail;
        public static string CurrentAdministratorPhoneNumber;
        public static string CurrentAdministratorDateOfBirth;
    }
}
