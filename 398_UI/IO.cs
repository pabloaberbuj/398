using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;


namespace _398_UI
{
    public static class IO
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
            BindingList<T> lista = readJsonList<T>(file);
            lista.Add((T)theObj);
            writeObjectAsJson(file, lista);
        }
        /// <summary>
        /// Lee una lista desde un archiov Json
        /// </summary>
        /// <typeparam name="T">El tipo de la lista => List<T></typeparam>
        /// <param name="file">la ruta del archivo</param>
        /// <returns>Devuelve una lista del tipo indicado List<T></returns>
        public static BindingList<T> readJsonList<T>(string file)
        {
            try
            {
                BindingList<T> lista = JsonConvert.DeserializeObject<BindingList<T>>(File.ReadAllText(file));
                return lista;
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show("No existe el archivo: " + file);
                BindingList<T> lista = new BindingList<T>();
                return lista;
            }
        }
        /// <summary>
        /// Devuelve un string con un nombre único para un archivo
        /// </summary>
        /// <param name="path">La ruta a la carpeta</param>
        /// <param name="baseName">El nombre deseado</param>
        /// <param name="maxAttempts">el número máximo que se le concatenará al baseName</param>
        /// <returns></returns>
        public static string GetUniqueFilename(string path, string baseName, string extention = "txt", int maxAttempts = 128)
        {
            if (!File.Exists(string.Format("{0}{1}.{2}",path, baseName,extention)))
            {
                return string.Format("{0}{1}.{2}", path, baseName, extention);
            }
            else
            {
                for (int i = 1; i < maxAttempts; i++)
                {
                    if (!File.Exists(string.Format("{0}{1} ({2}).{3}", path, baseName, i, extention)))
                    {
                        return string.Format("{0}{1} ({2}).{3}", path, baseName, i, extention);
                    }
                }
            }
            return string.Format("{0}{1} - {2:yyyy-MM-dd_hh-mm-ss}.{3}", path, baseName, DateTime.Now, extention);
        }

        public static void tablaaString(string archivo, DataGridView tabla)
        {
            tabla.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            tabla.SelectAll();
            DataObject dataObject = tabla.GetClipboardContent();
            string aux = dataObject.GetText(TextDataFormat.CommaSeparatedValue);
            aux=aux.Replace(",", "\t");
            File.WriteAllText(archivo, aux);
            tabla.ClearSelection();
            MessageBox.Show("Se exportaron los datos a un archivo separado por tabulaciones");
        }
    
    }
}

