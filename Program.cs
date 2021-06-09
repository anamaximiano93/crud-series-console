using System;

namespace CRUD.SeriesDIO
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static void ListarSeries()
        {

            Console.WriteLine("Listar séries");

            var Lista = repositorio.Lista();

            if (Lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach (var serie in Lista)
            {

                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "** Excluido **" : ""));
            }
        }

        private static void InserirSerie()
        {

            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genêro entre as opções acima: *");
            int inGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo: ");
            string inTitulo = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Digite o Ano: ");
            int inAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição: ");
            string inDescricao = Convert.ToString(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)inGenero, titulo: inTitulo, ano: inAno, descricao: inDescricao);

            repositorio.Insere(novaSerie);

        }

        private static void AtualizarSerie()
        {

            Console.WriteLine("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.WriteLine("Digite o genêro entre as opções acima: *");
            int inGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Titulo: ");
            string inTitulo = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Digite o Ano: ");
            int inAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição: ");
            string inDescricao = Convert.ToString(Console.ReadLine());

            Serie novaSerie = new Serie(id: indice, genero: (Genero)inGenero, titulo: inTitulo, ano: inAno, descricao: inDescricao);

            repositorio.Atualiza(indice, novaSerie);

        }


        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());

            repositorio.Exclui(indice);


        }
        private static void VisualizarSerie()
        {

            Console.WriteLine("Digite o id da série: ");
            int indice = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indice);

            Console.WriteLine();
            Console.WriteLine(serie);

        }



        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("****** Menu Séries ******");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Lista séries");
            Console.WriteLine("2 - Insere nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            Console.Write("Opção: ");

            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }
    }
}
