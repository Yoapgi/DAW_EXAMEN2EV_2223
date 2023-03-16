using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería
    //
    public class LotoYAG2223
    {
        // definición de constantes
        public const int MAX_NUMEROS = 6;
        public const int NUMERO_MENOR = 1;
        public const int NUMERO_MAYOR = 49;
        
        private int[] _numeros = new int[MAX_NUMEROS];   // numeros de la combinación
        public bool ok = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)

        public int[] Numeros { 
            get => _numeros; 
            set => _numeros = value; 
        }

        // En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta
        /// <summary>
        /// Es un constructor donde genera una convinacion aleatoria de numeros
        /// </summary>
        public LotoYAG2223()
        {
            Random numeroAletorio = new Random();    // clase generadora de números aleatorios

            int i = 0;
            int j;
            int numero;
            const int Suma_NUMEROS = 1;

            do             // generamos la combinación
            {                       
                numero = numeroAletorio.Next(NUMERO_MENOR, NUMERO_MAYOR + Suma_NUMEROS);     // generamos un número aleatorio del 1 al 49
                for (j=0; j<i; j++)    // comprobamos que el número no está
                    if (Numeros[j]==numero)
                        break;
                if (i==j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    Numeros[i]=numero;
                    i++;
                }
            } while (i<MAX_NUMEROS);

            ok=true;
        }

        // La segunda forma de crear una combinación es pasando el conjunto de números
        // misnums es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)
        /// <summary>
        /// Es un constructor donde crea una conbinacion y le pasa un conjunto de numeros en un array con la conbinacion que se quiere crear
        /// </summary>
        /// <param name="misNumeros">Es una lista con los que queremos inicializar la clase</param>
        public LotoYAG2223(int[] misNumeros)  // misnumeros: combinación con la que queremos inicializar la clase
        {
            for (int i=0; i<MAX_NUMEROS; i++)
                if (misNumeros[i]>=NUMERO_MENOR && misNumeros[i]<=NUMERO_MAYOR) {
                    int j;
                    for (j=0; j<i; j++) 
                        if (misNumeros[i]==Numeros[j])
                            break;
                    if (i==j)
                        Numeros[i]=misNumeros[i]; // validamos la combinación
                    else {
                        ok=false;
                        return;
                    }
                }
                else
                {
                    ok=false;     // La combinación no es válida, terminamos
                    return;
                }
	        ok=true;
        }

        // Método que comprueba el número de aciertos
        // premi es un array con la combinación ganadora
        // se devuelve el número de aciertos
        /// <summary>
        /// Es un metodo hace un bucle donde va sacando el numero de aciertos
        /// </summary>
        /// <param name="premio">Es una lista donde se encunetra el numero ganador</param>
        /// <returns>Devuelve la variable de numeros de aciertos</returns>
        public int comprobar(int[] premio)
        {
            int numeroAcierto=0;                    // número de aciertos
            for (int i=0; i<MAX_NUMEROS; i++)
                for (int j=0; j<MAX_NUMEROS; j++)
                    if (premio[i]==Numeros[j]) numeroAcierto++;
            return numeroAcierto;
        }
    }

}
