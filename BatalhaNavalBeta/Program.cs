namespace BatalhaNavalBeta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] grade = new string[10, 10];
            preencherMatriz(grade);
            listarMatriz(grade);

            //Jogar
            bool temVencedor = true;
            int qtdjogadas = 0;
            int pontos = 0;
            bool acertou = false;
            while ((qtdjogadas < 5) && (pontos < 3))
            {
                Console.WriteLine();
                Console.Write("Informe a linha do tiro: ");
                int linha = int.Parse(Console.ReadLine());
                Console.Write("Informe a coluna do tiro: ");
                int coluna = int.Parse(Console.ReadLine());
                //Testa se a posição escolhida já está marcada
                if (grade[linha, coluna] != " ")
                {
                    Console.WriteLine($"Você acertou um {grade[linha, coluna]}");
                    grade[linha, coluna] = "X";
                    pontos++;
                    qtdjogadas++;
                    Console.ReadKey();
                }
                else
                {
                    grade[linha, coluna] = "X";
                    qtdjogadas++;
                }

                Console.Clear();
                listarMatriz(grade);
            }
            Console.WriteLine();
            if (pontos == 3)
            {
                Console.WriteLine($"Você venceu!!!");
                Console.WriteLine($"Sua pontuação é: {pontos}");
            }
            else
            {
                Console.WriteLine($"Você esgotou todas as tentativas...");
                Console.WriteLine($"Sua pontuação é: {pontos}");
            }
            Console.ReadKey();
        }

        //Método para preencher a matriz
        static void preencherMatriz(string[,] matriz)
        {            
            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {                
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {                    
                    matriz[linha, coluna] = " ";
                }
            }
            //Defini posição do Navio 01
            Random lin = new Random();
            int linhaNavio = lin.Next(0, 10); //Cria um número entre 0 e 9
            Random col = new Random();
            int colunaNavio = col.Next(0, 10); //Cria um número entre 0 e 9
            matriz[linhaNavio, colunaNavio] = "N";
            //Defini posição do Navio 02
            lin = new Random();
            linhaNavio = lin.Next(0, 10); //Cria um número entre 0 e 9
            col = new Random();
            colunaNavio = col.Next(0, 10); //Cria um número entre 0 e 9
            matriz[linhaNavio, colunaNavio] = "N";
            //Defini posição do Avião
            lin = new Random();
            linhaNavio = lin.Next(0, 10); //Cria um número entre 0 e 9
            col = new Random();
            colunaNavio = col.Next(0, 10); //Cria um número entre 0 e 9
            matriz[linhaNavio, colunaNavio] = "A";
        }
        //Método para listar a matriz
        static void listarMatriz(string[,] matriz)
        {
            Console.WriteLine("  00  01  02  03  04  05  06  07  08  09");
            int cont = 0;
            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {                
                Console.WriteLine("==========================================");
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    if (coluna == 0)
                        Console.Write($"0{cont}");   
                    
                    if ((matriz[linha, coluna] == "N") || (matriz[linha, coluna] == "A"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(matriz[linha, coluna]);
                        Console.ResetColor();
                        Console.Write(" ||");
                    }
                    else if ((matriz[linha, coluna] == "X"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(matriz[linha, coluna]);
                        Console.ResetColor();
                        Console.Write(" ||");
                    }
                    else
                    Console.Write(matriz[linha, coluna] + " ||");

                }
                cont++;
                Console.WriteLine();
            }
            Console.WriteLine("==========================================");
        }
    }
}