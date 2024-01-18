using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace agenda_telefonica.contatos
{

    [Serializable]
    public class Contato
    {
        public string Nome { get; set; }
        public string NumeroTelefone { get; set; }

        public override string ToString()
        {
            return $"NOME: {Nome} - TELEFONE: {NumeroTelefone}";
        }

        public void EditarContato()
        {
            Console.WriteLine($"Editando Contato: {Nome}");

            Console.WriteLine("\nNovo nome (ou pressione Enter para manter o mesmo):");
            string novoNome = Console.ReadLine();

            if (!string.IsNullOrEmpty(novoNome))
            {
                Nome = novoNome;
            }

            Console.WriteLine("\nNovo número de telefone (ou pressione Enter para manter o mesmo):");
            string novoNumeroTelefone = Console.ReadLine();

            if (!string.IsNullOrEmpty(novoNumeroTelefone))
            {
                NumeroTelefone = novoNumeroTelefone;
            }

            Console.WriteLine("Contato editado com sucesso!");

        }

        public void RemoverContato()
        {
            Console.WriteLine($"Removendo Contato: {Nome}");
            
        }
    }
}