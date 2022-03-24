
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
            Console.WriteLine("Número inválido! Insira novamente!");
        
        else
            ok = true;
        

    } while (!ok);

    //Retorno de número validado.
    return num;
}

//Menu de Opções.
static int Menu()
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
    Console.WriteLine("8. Alterar Nota");

    Console.WriteLine("9. Sair");

    //Retorna o valor do operador.
    return ValidaNumero(1, 9, true);
}

//Declaração de variáveis.
float[] notas = new float[0]; //[0] ... [4]

int opcao; 

Console.WriteLine("Dimensão do Array é = {0}", notas.Length);
Console.ReadKey();
           

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

            Console.WriteLine("\nQuantas notas deseja adicionar? ");
            int notasAdicionais = ValidaNumero(1, 100, false);

            int tamanhoAtual = notas.Length;

            int novoTamanho = notasAdicionais + tamanhoAtual;

            Array.Resize(ref notas, novoTamanho);

            for (int i = tamanhoAtual; i < novoTamanho; i++)
            {
                Console.WriteLine($"\nInsira as nota(as) {i}: ");
                notas[i] = ValidaNumero(0, 20, false);
            }
                
            Console.ReadKey();
            Console.Clear();
            break;

        //Lista o array.
        case 2: 
            Console.Clear();
            Console.WriteLine("Listando as Notas..");

            for (int i = 0; i <= notas.Length; i++)
                Console.WriteLine(notas[i]);
            
            Console.ReadKey();
            Console.Clear();
            break;

        //Média
        case 3:
            float media = 0, soma = 0;

            Console.Clear();
            Console.WriteLine("MÉDIA");

            for (int i = 0; i <= 4; i++)
                soma += notas[i];

            media = soma / notas.Length;
            Console.WriteLine("\nMédia Notas:" + media.ToString("F2"));

            break;

        //Maior Nota
        case 4:

            Console.Clear();
            Console.WriteLine("MAIOR NOTA");
            
           float maiorNota = 0;

           for (int i = 0; i < notas.Length; i++)
            {
                if (i == 0)  
                    maiorNota = notas[i];

                if (notas[i] > maiorNota) 
                    maiorNota = notas[i];
             }
           Console.WriteLine($"A maior nota é = {maiorNota}");
   
            Console.ReadKey();
            Console.Clear();

            break;

         //Menor Nota
         case 5:
            Console.Clear();
            Console.WriteLine("MENOR NOTA");

            float menorNota = 0;
             
            for (int i = 0; i < notas.Length; i++)
            {
                if (i == 0) 
                    menorNota = notas[i];

                if (notas[i] < menorNota)
                    menorNota = notas[i];
            }
            
            Console.WriteLine($"A menor nota é = {menorNota}");
 
            Console.ReadKey();
            Console.Clear();
            break;

        //Aprovados e Reprovados
        case 6:       
            Console.WriteLine("\nAPROVADOS E REPROVADOS");
                        
            int numeroAprovados = 0, numeroReprovados = 0;                     
     
            for (int i = 0; i < notas.Length; i++)          
            {  
                if (notas[i] >= 10)          
                    numeroAprovados += 1;
                
                if (notas[i] < 10)   
                    numeroReprovados += 1;      
            }
                        
            Console.WriteLine($"Aprovados: {numeroAprovados}");
            Console.WriteLine($"Reprovdos: {numeroReprovados}");
                        
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

            break;

        case 8: 
            for (int i = 1; i <= notas.Length; i++)
                Console.WriteLine($"{i} * notas = {notas[i -1 ]}");
          
            Console.WriteLine($"Qual o índice da nota que deseja alterar? ");
            int indiceNota = ValidaNumero(1, notas.Length, true);

            notas[indiceNota - 1] = ValidaNumero(1, 20, true);

            break;

        default:
            System.Environment.Exit(0);
            break;
    }

} while (opcao != 9);
