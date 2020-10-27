using System;

namespace ContosoUniversity.Framework
{
    public class Util
    {
        public static bool ValidarCpf(string cpf)
        {
            if (String.IsNullOrEmpty(cpf))
                return false;
            else
                return true;
        }
    }
}