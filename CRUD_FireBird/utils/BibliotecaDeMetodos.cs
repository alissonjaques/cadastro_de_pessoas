using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDePessoas.utils
{
    public class BibliotecaDeMetodos
    {
        public static bool ValidaSenhaLogin(string login, string senha)
        {
            if (login == "admin" && senha == "admin")
            {
                return true;
            }
            return false;
        }
    }
}
