
//Ciclo de validação.
static int ValidaNumero(int menor, int maior, bool msg)
{
    //Função que valida o número num intervalo.
    int num = 0;
    string temp = "";
    bool testaStr, ok = false;

    do
    {
        if (msg)
           Console.Write($"\nEscreva um número entre {menor} e {maior}: ");

        //Ler do teclado com tipo de dados string.
        temp = Console.ReadLine(); 

        //Testa o conteúdo da variável e se INT passa valor de temp para num.
        testaStr = int.TryParse(temp, out num);

        if (!testaStr || num < menor || num > maior)
        {
            Console.WriteLine("Número inválido! Insira novamente!");
        }
        else {
            ok = true;
        }

    } while (!ok);

    //Retorno de número validado.
    return num;
}

//Menu de Opções.
int Menu()
{
    Console.Clear();
    Console.WriteLine("ARRAY de NOTAS");
    Console.WriteLine("\n1. Inserir Notas");
    Console.WriteLine("2. Listar Notas");
    Console.WriteLine("3. Média");
    Console.WriteLine("4. Maior Nota");
    Console.WriteLine("5. Menor Nota");
    Console.WriteLine("6. Aprovados e Reprovados");
    Console.WriteLine("7. Adicionar Nota");
    Console.WriteLine("8. Sair");

    //Retorna o valor do operador.
    return Convert.ToInt32("\n" + Console.ReadLine());
}


//Declaração de variáveis.
int[] notas = new int[0]; //[0] ... [4]

int opcao;

//Ciclo de repetição dos Menus.
do
{   //Seleção de opções.
    opcao = Menu();

    //Ação de acordo com a opção.
    switch (opcao)
    {
        //Insere array.
        case 1: 
            Console.Clear();
            Console.WriteLine("Inserindo Notas...");

            Console.Write("Quantas notas: ");
            int quantNotas = int.Parse(Console.ReadLine());

            notas[quantNotas];

            for (int i = 1; i <= notas.Length; i++)
            {
                Console.Write($"\nInsira a Nota {i}: ");
                notas[i - 1] = ValidaNumero(0, 20, false);
            }
            Console.ReadKey();
            Console.Clear();

            break;

        //Lista o array.
        case 2: 
            Console.Clear();
            Console.WriteLine("Listando as Notas..");

            for (int i = 0; i <= notas.Length; i++)
            {
                Console.WriteLine(notas[i]);
            }
            Console.ReadKey();
            Console.Clear();

            break;

        //Média
        case 3:
            int media = 0;
            int soma = 0;

            Console.Clear();
            Console.WriteLine("MÉDIA");

            for (int i = 0; i <= 4; i++)
                soma += notas[i];

            media = soma / 5;
            Console.WriteLine("\nMédia Notas:" + media.ToString("F2"));

            break;

        //Maior Nota
        case 4:
            Console.Clear();
            Console.WriteLine("MAIOR NOTA");

            int maiorNota = 0;

            for (int i = 0; i <= notas.Length; i++)
            {
                if (i == 0)
                    maiorNota = notas[i];

                if (notas[i] > maiorNota)
                    maiorNota = notas[i];
            }

            Console.WriteLine($"Maior Nota: {maiorNota}...");
            Console.ReadKey();
            Console.Clear();

            break;

         //Menor Nota
         case 5:
            Console.Clear();
            Console.WriteLine("MENOR NOTA");

            int menorNota = 0;

            for (int i = 0; i <= notas.Length; i++)
            {
                if (i == 0)
                    menorNota = notas[i];

                if (notas[i] < menorNota)
                    menorNota = notas[i];
            }
            Console.WriteLine($"Menor Nota: {menorNota}");
            Console.ReadKey();
            Console.Clear();
            break;

        //Adicionando uma nota.
        case 7:
            Console.Clear();
            Console.WriteLine("ADICIONANDO NOTA");
            
            //Redimensionar o array (para mais uma posição).
            Array.Resize(ref notas, notas.Length + 1);
            Console.Write("Dimensão: " + notas.Length);

            Console.Write($"Insira a {notas.Length}: ");
            notas[notas.Length - 1] = ValidaNumero(0, 20, false);

        default:
            System.Environment.Exit(0);
            break;
    }

} while (opcao != 8);
