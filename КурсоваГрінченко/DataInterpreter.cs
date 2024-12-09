using System.Globalization;

namespace КурсоваГрінченко;

/// <summary>
/// Клас відповідальний за перетворення текстових 
/// данних у масив значень з палваючою точкою
/// </summary>
public class DataInterpreter
{
    /// <summary>
    /// Перетворює рядок зі значеннями розділеними комами у масив
    /// Поветрає істинну за успішного виконання
    /// </summary>
    /// <param name="csv"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool Read(string csv, out double[]? result) 
    {
        // Перевіряємо чи рядок пустий та має принаймні одну кому
        if (String.IsNullOrEmpty(csv) || !csv.Contains(",")) 
        { 
            result = null;
            return false; 
        }

        var valuesArr = csv.Split(',');         // Утворюємо масив рядків, розділяючи за комами
        List<double> resList = new();           // Утворюємо список числових значень

        // Перетворюємо кожне значення із рядка у число
        for (int i = 0; i < valuesArr.Length; i++)      
        {
            // Якщо введено пусте значення - йдемо далі
            if (String.IsNullOrEmpty(valuesArr[i]))     
                continue;
            
            if (!Double.TryParse(valuesArr[i], 
                                 NumberStyles.Number, 
                                 CultureInfo.InvariantCulture, 
                                 out double resItem)) 
            {
                result = null;
                return false;
            }
            resList.Add(resItem);
        }
        // Перетворюємо резулютуючий список у масив та присвоюємо вихідному значенню
        result = resList.ToArray();      
        return true;
    }
}