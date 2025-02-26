using System;

class Program
{
    static bool EhPrimo(int numero)
    {
        if (numero < 2)
            return false;

        for (int i = 2; i * i <= numero; i++)
        {
            if (numero % i == 0)
                return false;
        }
        return true;
    }

    static void Main()
    {
        int[] numeros = { 2, 34, 4, 5, 67, 1, 23, 35, 78, 10, 11, 65, 124, 78, 25 };

        // Inicializando arrays com tamanho dinâmico para armazenar primos e não primos
        int[] primos = new int[numeros.Length];
        int[] naoprimos = new int[numeros.Length];
        int[] valorU = new int[numeros.Length];
        int[] contagemO = new int[numeros.Length];

        int indicePrimos = 0;
        int indiceNaoPrimos = 0;
        int indiceOcorrencia = 0;

        for (int i = 0; i < numeros.Length; i++)
        {
            int numero = numeros[i];

            // Verificando se é primo ou não
            if (EhPrimo(numero))
            {
                primos[indicePrimos] = numero;
                indicePrimos++;
            }
            else
            {
                naoprimos[indiceNaoPrimos] = numero;
                indiceNaoPrimos++;
            }

            // Contagem de ocorrências
            bool encontrado = false;
            for (int j = 0; j < indiceOcorrencia; j++)
            {
                if (valorU[j] == numero)
                {
                    contagemO[j]++;
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                valorU[indiceOcorrencia] = numero;
                contagemO[indiceOcorrencia] = 1;
                indiceOcorrencia++;
            }
        }

        // Redimensionando os arrays para o tamanho real
        Array.Resize(ref primos, indicePrimos);
        Array.Resize(ref naoprimos, indiceNaoPrimos);
        Array.Resize(ref valorU, indiceOcorrencia);
        Array.Resize(ref contagemO, indiceOcorrencia);

        // Exibindo os resultados
        Console.WriteLine("Números primos: [" + string.Join(", ", primos) + "]");
        Console.WriteLine("Números não primos: [" + string.Join(", ", naoprimos) + "]");
        Console.WriteLine("Ocorrências:");
        for (int i = 0; i < valorU.Length; i++)
        {
            Console.WriteLine($"- {valorU[i]}: {contagemO[i]} vez(es)");
        }
    }
}

