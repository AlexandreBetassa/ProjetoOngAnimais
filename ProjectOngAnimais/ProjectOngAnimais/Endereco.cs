﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOngAnimais
{
    internal class Endereco
    {
        public String Logradouro { get; set; }
        public int Numero { get; set; }
        public String Bairro { get; set; }
        public String Complemento { get; set; }
        public String Cidade { get; set; }
        public String UF { get; set; }
        public String Cep { get; set; }

        public Endereco()
        {

        }

        public Endereco CadastrarEndereco()
        {
            Logradouro = Utils.ColetarString("Informe logradouro: ");
            Numero = Utils.ColetarValorInt("Informe número: ");
            Bairro = Utils.ColetarString("Informe o bairro: ");
            Console.Write("Informe complento (Opcional): ");
            Complemento = Console.ReadLine();
            Cidade = Utils.ColetarString("Informe a cidade onde reside: ");
            UF = Utils.ColetarString("Informe o estado onde reside: ");
            do
            {
                Cep = Utils.ColetarString("Informe o CEP (Somente numeros): ");
                if (Cep.Length != 8) Console.WriteLine("Cep inválido. Informe no formato indicado!");
                else break;
            } while (true);
            return (this);
        }

        public override string ToString()
        {
            return $"Rua/Av.: {Logradouro}, N°: {Numero}, Bairro: {Bairro}, Complemento: {Complemento}, Cidade: {Cidade} - {UF}, CEP: {Cep}".ToString();
        }
    }
}
