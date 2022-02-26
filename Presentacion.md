Moogle! es una aplicación desarrollado con tecnología .NET Core 6.0 utilizando el lenguaje de programación
C#. Es un motor de búsqueda cuya finalidad, como su nombre lo indica, es buscar, pero de forma inteligente un
texto o una frase dada en un conjunto de documentos. El mismo cuenta con una interfaz gráfica en la cualpodemos apreciar el logotipo y el nombre de la aplicación, así como la barra de búsqueda que es donde debemos introducir la palabra o frase que deseamos buscar; y junto a esta el botón de "buscar".

Para realizar esta función aplica un sistema de recuperación de información. En este se utiliza un modelo vectorial, crea la matriz de un espacio vectorial donde cada vector representa un término del documento. A estos se les determina el peso "TF-IDF", luego al "query" también se le realiza esta operación y se calcula la distancia coseno entre los dos vectores, y esta sería igual al "score" de cada docuemnto.

Tambien se hace uso del algoritmo de "LevenshteinDistance" el cuan determina la cantidad de de operaciones(agrgar, quitar o cambiar) que se deben de ralizar para que dos palabras sean iguales, esto se puede utilizar entre otras cosas, para eliminar las faltas de otrografia que pueda tener el usuario

Otra de las principales características de este motor de búqueda es la "Suggestion" la cual en el caso de que el usuario escriba mal alguna palabra o haya tenido alguna falta de ortografía hace sugerencias de palabras o frases que quisaz el usuario quería decir.

!!!EJEMPLO!!!
![](Suggestion.png)
