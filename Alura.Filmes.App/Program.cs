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

                BuscarFilmesSeparadosPorIdiomaFalado(contexto);

            }

            Console.ReadKey();
        }


        public static void BuscarAtores(AluraFilmesContexto contexto)
        {
            //buscar atores
            foreach (var ator in contexto.Atores)
            {
                Console.WriteLine(ator);
            }
        }

        public static void InserirAtores(AluraFilmesContexto contexto)
        {
            //Inserir ator
            var ator = new Ator();
            ator.PrimeiroNome = "Fernanda";
            ator.UltimoNome = "Montenegro";
            //definindo o valor da shadow properties:
            //contexto.Entry(ator).Property("last_update").CurrentValue = DateTime.Now;

            contexto.Atores.Add(ator);
            contexto.SaveChanges();

            foreach (var a in contexto.Atores)
            {
                Console.WriteLine(a);

            }
        }

        public static void ExibirShadowPropertiesDeAtor(AluraFilmesContexto contexto)
        {
            //exibir ator com shadow properties
            var ator = contexto.Atores.First();
            Console.WriteLine(ator);
            Console.WriteLine(contexto.Entry(ator).Property("last_update").CurrentValue);
        }

        public static void BuscarAtoresComUpdateRecente(AluraFilmesContexto contexto)
        {
            //recuperar os 10 atores com atualização mais recente
            var atores = contexto.Atores
                .OrderByDescending(a => EF.Property<DateTime>(a, "last_update"))
                .Take(10);
            foreach (var ator in atores)
            {
                Console.WriteLine(ator + " --- " + contexto.Entry(ator).Property("last_update").CurrentValue);
            }
        }


        public static void BuscarFilmes(AluraFilmesContexto contexto)
        {
            //buscar atores
            foreach (var filme in contexto.Filmes)
            {
                Console.WriteLine(filme);
            }
        }

        public static void BuscarIdFilmesAtores(AluraFilmesContexto contexto)
        {
            //buscar atores
            foreach (var item in contexto.Elenco)
            {
                Console.WriteLine($"Id do ator: { contexto.Entry(item).Property("actor_id").CurrentValue}, Id do filme: { contexto.Entry(item).Property("film_id").CurrentValue}");
                Console.WriteLine(item);
            }
        }

        public static void BuscarAtoresDeUmFilme(AluraFilmesContexto contexto)
        {
            var filme = contexto.Filmes
                .Include(f => f.Atores)
                .ThenInclude(fa => fa.Ator)
                .FirstOrDefault();

            Console.WriteLine(filme);
            Console.WriteLine("Elenco do filme:");

            //buscar atores
            foreach (var ator in filme.Atores)
            {
                Console.WriteLine(ator.Ator);
            }
        }

        public static void BuscarCategorias(AluraFilmesContexto contexto)
        {
            //buscar atores
            foreach (var item in contexto.Categorias)
            {
                Console.WriteLine(item);
            }
        }

        public static void BuscarFilmesDeUmaCategoria(AluraFilmesContexto contexto)
        {
            var categoria = contexto.Categorias
                .Include(c => c.Filmes)
                .ThenInclude(fc => fc.Filme)
                .FirstOrDefault();

            Console.WriteLine(categoria);
            Console.WriteLine("Filmes dessa categoria:");

            //buscar filmes
            foreach (var filme in categoria.Filmes)
            {
                Console.WriteLine(filme.Filme);
            }
        }

        public static void BuscarIdiomas(AluraFilmesContexto contexto)
        {
            foreach (var idioma in contexto.Idiomas)
            {
                Console.WriteLine(idioma);
            }
        }

        public static void BuscarFilmesPorIdiomaOriginal(AluraFilmesContexto contexto)
        {
            var idioma = contexto.Idiomas
                .Include(i => i.FilmesFalados)
                .FirstOrDefault();

            Console.WriteLine(idioma);
            Console.WriteLine("Filmes desse idioma falado:");

            //buscar filmes
            foreach (var filme in idioma.FilmesFalados)
            {
                Console.WriteLine(filme);
            }
        }

        public static void BuscarFilmesOriginaisJaponeses(AluraFilmesContexto contexto)
        {
            var idioma = contexto.Idiomas
                .Include(i => i.FilmesOriginais)
                .Where(i => i.Id == 3)
                .FirstOrDefault();

            Console.WriteLine(idioma);
            Console.WriteLine("Filmes desse idioma falado:");

            //buscar filmes
            foreach (var filme in idioma.FilmesOriginais)
            {
                Console.WriteLine(filme);
            }
        }

        public static void BuscarFilmesSeparadosPorIdiomaFalado(AluraFilmesContexto contexto)
        {
            var idiomas = contexto.Idiomas
                .Include(i => i.FilmesFalados);

            foreach(var idioma in idiomas)
            {
                Console.WriteLine(idioma);
                foreach (var filme in idioma.FilmesFalados)
                {
                    Console.WriteLine(filme);
                }
                Console.WriteLine("\n");

            }

        }
    }
}