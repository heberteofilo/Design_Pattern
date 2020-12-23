using Application._6___Validate._6._1___Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Application._6___Validate
{
    public class ValidatePorTipo : IValidatePorTipo
    {
        public List<ValidatePorTipo> ValidarPorTipos;
        public string ErrorMessage;

        public ValidatePorTipo()
        {
            ValidarPorTipos = new List<ValidatePorTipo>();
        }

        

        public bool ValidadorDeString(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                return false;
            }

            return true;
        }

        public bool ValidadorDeDouble(double tipo)
        {
            if (tipo <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
