- # Explicacion de capas
Utilice una aplicacion Web con comandos asp.net, en el se implementaron 2 capas, 1 de ellas es la vista, la cual contiene los eventos que
van a la capa de negocios, el cargue de archivos txt y el mensaje que se le retornara al cliente. En la segunda capa se encuentra toda la
logica del negocio mas reglas y constantes utilizadas.

#Explicacion de clases
#Views
- #Index.aspx.cs: En ella se encuentran los eventos de cargar archivos, el evento generar resultados, el cual llama a la capa de negocios y 
el mensaje con la informacion que se le mostrara al usuario.
#Business
- #ProcessFile.cs: En ella leo la informacion cargada con el fin de definir la cantidad de testCase con sus respectivas matrices e iniciar
con su procesamiento, tambien se crea la matriz, se envian los datos a la clase Queries para actualizar dicha matriz y se retorna un 
DataTable con la informacion.
- #Queries.cs:En ella se actualiza la matriz o se retorna la suma de la consulta en cuestion.
- #ValidatorBusiness: Esta clase funciona como una especie de helper, en la cual podrian existir funciones comunes, las cuales pueden ser 
necesarias en diferentes funciones.
#Rules
- #RuleCases.cs: En ella se centralizan los condicionales, con el fin de no saturar las clases y solo retornar un bool el cual me dira si
cumple o no la peticion enviada.
- #RestrictionConstants.cs: Es una clase con variables constantes, esto con el fin de centralizar los posibles cambios en variables ya 
definidas a nivel general y no clase por clase donde se encuentren.



