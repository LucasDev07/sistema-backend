using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoDoZero.Models
{
    public class BaseResult
    {
        public bool sucesso { get; set; }

        public string mensagem { get; set; }

        public Guid usuarioGuid { get; set; }

    }
}
