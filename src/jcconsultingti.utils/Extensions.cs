using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Globalization;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;
using OfficeOpenXml;

namespace jcconsultingti.utils
{
    public static class Extensions
    {
        /// <summary>
        /// Converte para data no Formato dd/mm/yyyy
        /// </summary>
        /// <param name="pObject">Objeto (this)</param>
        /// <returns>Data formatada</returns>
        public static string ToDateTimeString(this object pObject)
        {
            if (pObject == null || pObject == DBNull.Value) return DateTime.MinValue.ToString();

            DateTime lReturn;

            if (DateTime.TryParse(pObject.ToString(), out lReturn))
            {
                return lReturn.ToString("dd/MM/yyyy");
            }
            else
            {
                return DateTime.MinValue.ToString();
            }
        }

        /// <summary>
        /// Converte para data no Formato dd/mm/yyyy e depois converte parao formato desejado
        /// </summary>
        /// <param name="pObject">Objeto (this)</param>
        /// <returns>Data formatada</returns>
        public static string ToDateTimeString(this object pObject, string formato)
        {
            if (pObject == null || pObject == DBNull.Value) return DateTime.MinValue.ToString();

            DateTime lReturn;

            if (DateTime.TryParse(pObject.ToString(), out lReturn))
            {
                return lReturn.ToString(formato);
            }
            else
            {
                return new DateTime(1900, 1, 1).ToString(formato);
            }
        }

        /// <summary>
        /// Converte para o type DateTime
        /// </summary>
        /// <param name="pObject">Objeto (this)</param>
        /// <returns>Data com type DateTime</returns>
        public static DateTime ToDateTime(this object pObject)
        {
            if (pObject == null || pObject == DBNull.Value) return DateTime.MinValue;

            DateTime lReturn;

            if (DateTime.TryParse(pObject.ToString(), out lReturn))
            {
                return lReturn;
            }
            else
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public static int ToInt32(this object pObject)
        {
            if (pObject == null || pObject == DBNull.Value) return int.MinValue;

            int lReturn;

            if (int.TryParse(pObject.ToString(), out lReturn))
            {
                return lReturn;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public static long ToLong(this object pObject)
        {
            if (pObject == null || pObject == DBNull.Value) return long.MinValue;

            long lReturn;

            if (long.TryParse(pObject.ToString(), out lReturn))
            {
                return lReturn;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// Converte bit/int 0 ou 1 para bool
        /// </summary>
        /// <param name="pObject"></param>
        /// <returns></returns>
        public static bool ToBoolean(this object pObject)
        {
            if (pObject == null || pObject == DBNull.Value) return false;

            if (pObject.ToInt32().Equals(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Converte para data no Formato dd/mm/yyyy
        /// </summary>
        /// <param name="pObject">objeto (this)</param>
        /// <returns>Data formatada</returns>
        public static string ToDateTime(this object pObject, string formato)
        {
            if (pObject == null || pObject == DBNull.Value) return DateTime.MinValue.ToString();

            DateTime lReturn;
            string sData = pObject.ToString();

            switch (formato)
            {
                case "yyyyMMdd":
                    {
                        pObject = (string.Format("{0}/{1}/{2}", sData.Substring(6, 2), sData.Substring(4, 2), sData.Substring(0, 4)));
                        break;
                    }
                case "ddMMyyyy":
                    {
                        pObject = (string.Format("{0}/{1}/{2}", sData.Substring(0, 2), sData.Substring(2, 2), sData.Substring(4, 4)));
                        break;
                    }
            }

            if (DateTime.TryParse(pObject.ToString(), out lReturn))
            {
                return lReturn.ToString("dd/MM/yyyy");
            }
            else
            {
                return DateTime.MinValue.ToString();
            }
        }

        /// <summary>
        /// Converte para formato decimal
        /// </summary>
        /// <param name="pObject">Objeto (this)</param>
        /// <returns>Valor formatado em decimal</returns>
        public static decimal ToDecimal(this object pObject)
        {
            if (pObject == null || pObject == DBNull.Value) return 0;

            decimal lReturn;

            if (pObject.GetType() == typeof(decimal))
            {
                return (decimal)pObject;
            }

            if (Decimal.TryParse(pObject.ToString(), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out lReturn))
            {
                return lReturn;
            }
            else
            {
                return 0;
            }
        }

        public static string RemoveCaracteresEspeciais(this object str)
        {
            Regex reg = new Regex("[^0-9A-Za-z]+");
            return reg.Replace(str.ToString(), " ");
        }

        public static string RemoveSomenteCaracteresEspeciais(this object str)
        {
            for (int v = 0; v < 31; v++)
            {
                char c = (char)v;
                str = str.ToString().Replace(c, ' ');
            }

            return str.ToString();
        }

        public static string RemoveAspasSimples(this object str)
        {
            Regex reg = new Regex("[']+");
            return reg.Replace(str.ToString(), " ");
        }

        public static string RemoverAcentosCaracteres(this object texto)
        {
            string s = texto.ToString().Normalize(NormalizationForm.FormKD);
            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc == UnicodeCategory.SpaceSeparator || uc == UnicodeCategory.UppercaseLetter ||
                    uc == UnicodeCategory.LowercaseLetter || uc == UnicodeCategory.DecimalDigitNumber)
                {
                    sb.Append(s[k]);
                }
            }

            return sb.ToString();
        }

        public static string toJSON(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static void RemoveAt<T>(this T[] arr, int index)
        {
            for (int a = index; a < arr.Length - 1; a++)
            {
                arr[a] = arr[a + 1];
            }

            Array.Resize(ref arr, arr.Length - 1);
        }

        public static Task<SqlDataReader> ExecuteReaderAsync(this SqlCommand source)
        {
            return Task<SqlDataReader>.Factory.FromAsync(
                new Func<AsyncCallback, object, IAsyncResult>(source.BeginExecuteReader),
                new Func<IAsyncResult, SqlDataReader>(source.EndExecuteReader),
                null
            );
        }

        public static Task<int> ExecuteNonQueryAsync(this SqlCommand source)
        {
            return Task<int>.Factory.FromAsync(
                new Func<AsyncCallback, object, IAsyncResult>(source.BeginExecuteNonQuery),
                new Func<IAsyncResult, int>(source.EndExecuteNonQuery),
                null
            );
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static bool IsXML(this string xml)
        {
            try
            {
                System.Xml.Linq.XDocument xDoc = System.Xml.Linq.XDocument.Parse(xml);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void WriteToCsvFile(this System.Data.DataTable dataTable, string filePath)
        {
            StringBuilder fileContent = new StringBuilder();

            foreach (var col in dataTable.Columns)
            {
                fileContent.Append(col.ToString() + ";");
            }

            fileContent.Replace(";", System.Environment.NewLine, fileContent.Length - 1, 1);

            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>
                  field.ToString().Replace("\"", "\"\""));

                fileContent.AppendLine(string.Join(";", fields));
            }

            System.IO.File.WriteAllText(filePath, fileContent.ToString());
        }

        /// <summary>
        /// Verifica se o valor informado é numerico ou nao
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        /// <summary>
        /// Gera um nome unico com sufixo ou prefixo (default)
        /// </summary>
        /// <param name="pObject"></param>
        /// <param name="sufixo">passar true para gerar nome unico como sufixo, se nao passar nada, sera gerado como prefixo</param>
        /// <returns></returns>
        public static string GerarNomeUnico(this object pObject, bool sufixo = false)
        {
            var prefixo = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var nomeOriginal = pObject.ToString().Split('.');

            var nomeArquivo = nomeOriginal[0].RemoveCaracteresEspeciais().RemoverAcentosCaracteres();
            nomeArquivo = nomeArquivo.Replace(" ", string.Empty);
            nomeArquivo = nomeArquivo.Replace("+", string.Empty);
            nomeArquivo = nomeArquivo.Replace("-", string.Empty);

            var novoNome = string.Empty;
            var extensao = string.Empty;

            if (nomeOriginal.Count() > 1)
            {
                extensao = nomeOriginal[nomeOriginal.Count() - 1];
                if (sufixo)
                    novoNome = string.Format("{1}_{0}.{2}", prefixo, nomeArquivo, extensao);
                else
                    novoNome = string.Format("{0}_{1}.{2}", prefixo, nomeArquivo, extensao);
            }
            else
            {
                if (sufixo)
                    novoNome = string.Format("{1}_{0}", prefixo, nomeArquivo);
                else
                    novoNome = string.Format("{0}_{1}", prefixo, nomeArquivo);
            }

            return novoNome;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObject"></param>
        /// <param name="tamanho">tamanho maximo da string</param>
        /// <param name="removeCaracteresEspeciais"></param>
        /// <param name="removeAcentos"></param>
        /// <returns>string truncada de acordo com o tamanho maximo</returns>
        public static string ToTruncate(this object pObject, int tamanho, bool removeCaracteresEspeciais = false, bool removeAcentos = true)
        {
            if (pObject == null || pObject == DBNull.Value) return string.Empty;

            var valor = pObject.ToString().Trim();

            if (removeCaracteresEspeciais)
                valor = valor.RemoveCaracteresEspeciais().Trim().Replace(" ", string.Empty);

            if (removeAcentos)
                valor = valor.RemoverAcentosCaracteres().Trim();

            if (valor.Length <= tamanho)
                return valor;

            else
                return valor.Substring(0, tamanho);
        }

        #region Enum
        /// <summary>
        /// Converte uma String para Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T StringToEnum<T>(string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }

        /// <summary>
        /// Recupera a Descriçao de um Enumerador
        /// </summary>
        /// <param name="value">Enumerador a ser recuperado a descriçao</param>
        /// <returns>Descriçao do Enum</returns>
        public static string ToDescriptionString(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString().Replace("_", " ");
        }

        /// <summary>
        /// Retorna todos os elementos de um Enumerador
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static IDictionary<int, string> GetAll<TEnum>() where TEnum : struct
        {
            var enumerationType = typeof(TEnum);

            if (!enumerationType.IsEnum)
                throw new ArgumentException("Enumeration type is expected.");

            var dictionary = new Dictionary<int, string>();

            foreach (int value in Enum.GetValues(enumerationType))
            {
                var name = Enum.GetName(enumerationType, value).Replace("_", " ");
                dictionary.Add(value, name);
            }

            return dictionary;
        }

        /// <summary>
        /// Dada uma descriçao, localiza o enum correspondente
        /// </summary>
        /// <typeparam name="T">Tipo de enumerador</typeparam>
        /// <param name="description">Descriçao como chave de busca do enum</param>
        /// <returns>Enumerador correspondente a descriçao</returns>
        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }
        #endregion

        public class EpplusIgnore : Attribute { }
        public static ExcelRangeBase LoadFromCollectionFiltered<T>(this ExcelRangeBase @this, IEnumerable<T> collection) where T : class
        {
            MemberInfo[] membersToInclude = typeof(T)
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => !Attribute.IsDefined(p, typeof(EpplusIgnore)))
                .ToArray();

            return @this.LoadFromCollection<T>(collection, false,
                OfficeOpenXml.Table.TableStyles.None,
                BindingFlags.Instance | BindingFlags.Public,
                membersToInclude);
        }
    }
}
