using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            using(var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                //buscar atores
                //foreach(var ator in contexto.Atores)
                //{
                //    Console.WriteLine(ator);

                //}

                ////Inserir ator
                //var ator = new Ator();
                //ator.PrimeiroNome = "Fernanda";
                //ator.UltimoNome = "Montenegro";
                ////definindo o valor da shadow properties:
                ////contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;

                //contexto.Atores.Add(ator);
                //contexto.SaveChanges();

                //foreach (var a in contexto.Atores)
                //{
                //    Console.WriteLine(a);

                //}


                ////exibir ator com shadow properties
                //var ator = contexto.Atores.First();
                //Console.WriteLine(ator);
                //Console.WriteLine(contexto.Entry(ator).Property("last_update").CurrentValue);


                //recuperar os 10 atores com atualização mais recente
                var atores = contexto.Atores
                    .OrderByDescending(a => EF.Property<DateTime>(a, "last_update"))
                    .Take(10);
                foreach (var ator in atores)
                {
                    Console.WriteLine(ator + " --- " + contexto.Entry(ator).Property("last_update").CurrentValue);

                }

            }


            Console.ReadKey();
        }
    }
}