using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;


namespace _398_UI
{
    static class IO
    {
        /// <summary>
        /// Escribe un objeto como Json en un archivo
        /// </summary>
        /// <param name="file">la ruta del archivo</param>
        /// <param name="theObj">el objeto para escribir</param>
        public static void writeObjectAsJson(string file, object theObj)
        {
            File.WriteAllText(file, JsonConvert.SerializeObject(theObj));
        }
        /// <summary>
        /// Agrega un objeto en la última posición de una lista en Json
        /// 
        /// </summary>
        /// <typeparam name="T">El tipo de la lista => List<T></typeparam>
        /// <param name="file">la ruta del archivo</param>
        /// <param name="theObj">el objeto para agregar</param>
        public static void appendObjectAsJson<T>(string file, object theObj)
        {
            List<T> lista = readJsonList<T>(file);
            lista.Add((T)theObj);
            writeObjectAsJson(file, lista);
        }
        /// <summary>
        /// Lee una lista desde un archiov Json
        /// </summary>
        /// <typeparam name="T">El tipo de la lista => List<T></typeparam>
        /// <param name="file">la ruta del archivo</param>
        /// <returns>Devuelve una lista del tipo indicado List<T></returns>
        public static List<T> readJsonList<T>(string file)
        {
            try
            {
                List<T> lista = JsonConvert.DeserializeObject<List<T>>(File.ReadAllText(file));
                return lista;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("No existe el archivo" + file);
                List<T> lista = new List<T>();
                return lista;
            }
        }

    }
}

