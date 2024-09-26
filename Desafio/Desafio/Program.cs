using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        Questao1();
        //Insira no Questao2() o número que deseja verificar
        Questao2(13);

        //Insira entre os parenteses o caminho do arquivo json
        Questao3(@"");
        Questao4();

        //Insira entre os parenteses a palavra que deseja inverter
        Console.WriteLine(Questao5("palavra"));
        Console.ReadKey();

    }

    /*1) Observe o trecho de código abaixo: int INDICE = 13, SOMA = 0, K = 0;
    Enquanto K < INDICE faça { K = K + 1; SOMA = SOMA + K; }
    Imprimir(SOMA);
    Ao final do processamento, qual será o valor da variável SOMA?
    */
    private static void Questao1()
    {
        int indice = 13, soma = 0, k = 0;
        while(k < indice)
        {
            k = k + 1;
            soma = soma + k;
            
        }
        Console.WriteLine(soma);
    }

    /*2) Dado a sequência de Fibonacci, onde se inicia por 0 e 1 e o próximo valor sempre será a soma dos 2 valores anteriores (exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34...), 
     * escreva um programa na linguagem que desejar onde, informado um número, ele calcule a sequência de Fibonacci e retorne uma mensagem avisando
     * se o número informado pertence ou não a sequência.
    */

    private static void Questao2(int numero)
    {
        // 0 1 1 2 3
        int n0 = 0, n1 = 1;
        bool vez1 = false;

        while(n0 + n1 < numero)
        {
            if (vez1) n1 = n1 + n0;
            else n0 = n1 + n0;

            vez1 = !vez1;

            if(n0 + n1 == numero)
            {
                Console.WriteLine("Número pertence a sequência");
                return;
            }
        }

        Console.WriteLine("Número não pertence a sequência");
    }


    /* 3) Dado um vetor que guarda o valor de faturamento diário de uma distribuidora, faça um programa, na linguagem que desejar, que calcule e retorne:
    • O menor valor de faturamento ocorrido em um dia do mês;
    • O maior valor de faturamento ocorrido em um dia do mês;
    • Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.
    */

    private static void Questao3(string caminho)
    {

        string dataString = File.ReadAllText(caminho);
        var datas = JsonSerializer.Deserialize<double[]>(dataString);

        double min = datas.Where(d => d > 0).Min();
        double max = datas.Where(d => d > 0).Max();
        int qtdDiasMaior = datas.Where(d => d > datas.Sum()/datas.Where(e => e!= 0.0).Count()).Count();

        Console.WriteLine("Menor faturamento: " + min);
        Console.WriteLine("Maior faturamento: " + max);
        Console.WriteLine("Dias maiores que a média: " + qtdDiasMaior);

    }

    /*4) Dado o valor de faturamento mensal de uma distribuidora, detalhado por estado:
    • SP – R$67.836,43
    • RJ – R$36.678,66
    • MG – R$29.229,88
    • ES – R$27.165,48
    • Outros – R$19.849,53
    */


    public static void Questao4()
    {
        Dictionary<string, double> faturamento = new Dictionary<string, double>();
        faturamento.Add("SP", 67836.43);
        faturamento.Add("RJ", 36678.66);
        faturamento.Add("MG", 29229.88);
        faturamento.Add("ES", 27165.48);
        faturamento.Add("Outros", 19849.53);


        double total = faturamento.Values.Sum();

        
       foreach(var key in faturamento.Keys)
        {
            Console.WriteLine($"{key} - {(faturamento[key] * 100)/total}");
        }


    }

    //5) Escreva um programa que inverta os caracteres de um string.

    private static string Questao5(string palavra)
    {
        StringBuilder sb = new StringBuilder();
        for(int i = palavra.Length - 1; i >= 0; i--)
        {
            sb.Append(palavra[i]);
        }

        return sb.ToString();

    }
}