using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using agenda_telefonica.contatos;

namespace agenda_telefonica.agenda
{
    public class Agenda
    {
        private List<Contato> contatos;

        public Agenda()
        {
            contatos = new List<Contato>();
        }

        public void AdicionarContato(Contato contato)
        {
            contatos.Add(contato);
            Console.WriteLine("\nContato adicionado com sucesso!");
        }

        public void MostrarContatos()
        {
            if (contatos.Count == 0)
            {
                Console.WriteLine("\nNenhum contato na agenda");
            }
            else
            {
                Console.WriteLine("\nLista de Contatos:\n");
                for (int i = 0; i < contatos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {contatos[i]}");
                }
            }
        }

        public void EditarContato(int indice)
        {
            if (indice >= 0 && indice < contatos.Count)
            {
                contatos[indice].EditarContato();
            }
            else
            {
                Console.WriteLine("Índice Inválido.");
            }
        }

        public void ExcluirContato(int indice)
        {
            if (indice >= 0 && indice < contatos.Count)
            {
                contatos.RemoveAt(indice);
                Console.WriteLine("Contato excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Índice Inválido");
            }
        }

        public void SalvarAgenda(string nomeArquivo)
        {
            try
            {
                using (FileStream fs = new FileStream(nomeArquivo, FileMode.Create))
                {
                    string json = JsonConvert.SerializeObject(contatos, Formatting.Indented);
                    File.WriteAllTex("C:\\Users\\Lucas\\Downloads\\projetos_back\\agenda_telefonica\\Arquivo", json);
                    Console.WriteLine("Agenda salva com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar agenda: {ex.Message}");
            }
        }

        public void CarregarAgenda(string nomeArquivo)
        {
            try
            {
                if (File.Exists(nomeArquivo))
                {
                    using (FileStream fs = new FileStream(nomeArquivo, FileMode.Open))
                    {
                        string json = File.ReadAllText(nomeArquivo);
                        contatos = JsonConvert.DeserializeObject<List<Contato>>(json);
                        Console.WriteLine("Agenda carregada com sucesso!");
                    }
                }
                else
                {
                    Console.WriteLine("O arquivo da agenda não existe. Uma nova agenda será criada.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar agenda: {ex.Message}");
            }
        }
    }
}