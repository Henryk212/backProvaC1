using System;
using System.Collections.Generic;

namespace controleDeFuncionarios.Models;


    public class PessoaEnderecoRequest
    {
        public Pessoa Pessoa { get; set; }
        public Endereco Endereco { get; set; }
    }
