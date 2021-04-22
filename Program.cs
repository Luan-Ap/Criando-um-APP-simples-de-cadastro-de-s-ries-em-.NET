using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X" )
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
                        Console.Write("Deseja realmente excluir uma série?\nDigite 1 para SIM ou Digite 0 para NÃO: ");
                        if(Console.ReadLine().Contains("1"))
                        {
                            ExcluirSerie();
                        }
                        break;
                    
                    case "5":
                        VisualizarSerie();
                        break;

                    default:
                        Console.WriteLine("Opção Inválida! Pressione ENTER para escolher novamente...");
                        Console.ReadLine();
                        break;
                        //throw new ArgumentOutOfRangeException();
                }
                Console.Clear();
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine("Pressione Enter para sair...");
            Console.ReadLine();
        }

        private static void VisualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("========= Visualizar série =========\n");

            if(VerificaLista() == false)
            {
                return;
            }

            Console.Write("Digite o id da série que deseja visualizar: ");
            int indiceSerie = ConverteId(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine();
            
            if(serie.retornaExcluido() == false)
            {
                Console.WriteLine(serie);
            }
            else
            {
                Console.WriteLine("Impossível exibir série solicitada.\nSérie excluída.");
            }
            

            Console.Write ("\n\nPressione Enter para continuar...");
            Console.ReadLine();
        }

        private static void ExcluirSerie()
        {
            Console.Clear();
            Console.WriteLine("========= Excluir série =========\n");

            if(VerificaLista() == false)
            {
                return;
            }

            Console.Write("Digite o id da série que deseja excluir: ");
            int indiceSerie = ConverteId(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Deseja realmente excluir essa série?\nDigite 1 para SIM ou Digite 0 para NÃO: ");
            if(Console.ReadLine().Contains("0"))
            {
                return;
            }
            else
            {
                var serie = repositorio.RetornaPorId(indiceSerie);

                if(serie.retornaExcluido() == false)
                {
                    repositorio.Exclui(indiceSerie);
                    Console.Write("\n\nSérie excluida com sucesso.\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    Console.Write("\n\nSérie já excluida.\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

        private static void AtualizarSerie()
        {
            Console.Clear();
            Console.WriteLine("========= Atualizar série =========\n");

            if(VerificaLista() == false)
            {
                return;
            }
            
            Console.Write("Digite o id da série que deseja atualizar: ");
            int indiceSerie = ConverteId(Console.ReadLine());
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\nDigite o genêro entre as opções acima: ");
            int entradaGenero = ConverteGenero(Console.ReadLine());

            Console.Write("\nDigite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("\nDigite o Ano de Início da Série: ");
            int entradaAno = ConverteAno(Console.ReadLine());

            Console.Write("\nDigite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

            Console.Write("\n\nSérie atualizada com sucesso.\nPressione Enter para continuar...");
            Console.ReadLine();
        }

        private static void InserirSerie()
        {
            Console.Clear();
            Console.WriteLine("========= Inserir nova série =========\n");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("\nDigite o genêro entre as opções acima: ");
            int entradaGenero = ConverteGenero(Console.ReadLine());

            Console.Write("\nDigite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("\nDigite o Ano de Início da Série: ");
            int entradaAno = ConverteAno(Console.ReadLine());

            Console.Write("\nDigite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.Proximo(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

            Console.Write("\n\nSérie inserida com sucesso.\nPressione Enter para continuar...");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.Clear();
            Console.WriteLine("========= Listar séries =========\n");

            if(VerificaLista() == false)
            {
                return;
            }
            
            var lista = repositorio.Lista();

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                if(excluido == false)
                {
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }
            }
            
            Console.Write("\n\nPressione Enter para continuar...");
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("========= DIO Séries a seu dispor =========");
            Console.WriteLine("\nInforme a opção desejada:\n");
            
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static int ConverteGenero(string a)
        {
            while(true)
            {
                if(Int32.TryParse(a, out int numGenero) && (numGenero >= 1 && numGenero <= 13))
                {
                    return numGenero;
                }
                Console.Write("\nValor inválido.\nDigite um dos valores listados acima: ");
                a = Console.ReadLine();
            } 
        }

        private static int ConverteAno(string a)
        {
            while(true)
            {
                if(Int32.TryParse(a, out int numGenero))
                {
                    return numGenero;
                }
                Console.Write("\nValor inválido.\nDigite o Ano de Início da Série: ");
                a = Console.ReadLine();
            }
        }

        private static int ConverteId(string a)
        {
            var lista = repositorio.Lista();
            while(true)
            {
                if(Int32.TryParse(a, out int numId) && (numId <= (lista.Count - 1) || numId == 0))
                {
                    return numId;
                }
                Console.Write("\nValor inválido.\nDigite o id da série que deseja atualizar: ");
                a = Console.ReadLine();
            }            
        }

        private static bool VerificaLista()
        {
            var list = repositorio.Lista();
            if(list.Count == 0)
            {
                Console.WriteLine("\nNenhuma série cadastrada. Cadastre ao menos uma série.\nPressione ENTER para retornar...");
                Console.ReadLine();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}  
