using static System.Console;

namespace Task3;

internal class Program
{
    static void Main(string[] args)
    {
        string? textStr;
        int res = 0;

        WriteLine("Введите текст для проверки: ");
        textStr = ReadLine();

        // завершение программы - ввести ^Z
        while (textStr != null)
        {
            res = ReviseText(textStr);

            switch (res)
            {
                case -2:
                    WriteLine("Некорректный ввод");
                    break;
                case -1:
                    WriteLine("Скобки расставлены правильно");
                    break;
                default:
                    WriteLine(res);
                    break;
            }

            WriteLine("Введите текст для проверки: ");
            textStr = ReadLine();
        }
    }

    static int ReviseText(string text)
    {
        // если передан указатель на null или пустая строка
        if (text == null || text.Length == 0)
        {
            return -2;
        }

        int leftParentheseIndex; // индекс открывающей скобки
        int rightParentheseIndex; // индекс закрывающей скобки
        int trimmedSymb = 0; // число отброшенных символов

        // выполнять цикл пока в тексте есть непроверенные скобки
        do
        {
            leftParentheseIndex = text.IndexOf('(');
            rightParentheseIndex = text.IndexOf(')');

            // если отсутствует открывающая скобка, но присутствует закрываюшая
            if (leftParentheseIndex == -1 && rightParentheseIndex != -1)
            {
                // вернуть индекс закрывающей скобки
                return rightParentheseIndex + trimmedSymb;
            }
            // если присутствует открывающая скобка но отсутствует закрывающая
            else if (leftParentheseIndex != -1 && rightParentheseIndex == -1)
            {
                // вернуть число открывающих скобок, начиная с позиции первой лишней открывающей скобки
                text = text.Substring(leftParentheseIndex);
                return text.Length - text.Replace("(", "").Length;
            }
            // если индекс открывающей скобки меньше индекса закрывающей
            else if (leftParentheseIndex < rightParentheseIndex)
            {
                // если из строки возможно выделить подстроку
                if (text.Length > rightParentheseIndex + 1)
                {
                    trimmedSymb += rightParentheseIndex + 1;
                    text = text.Substring(rightParentheseIndex + 1);
                    continue;
                }
                // если закрывающая скобка была последним символом строки
                break;
            }
            // если индекс открывающей скобки больше индекса закрывающей
            else if (leftParentheseIndex > rightParentheseIndex)
            {
                // вернуть индекс закрывающей скобки
                return rightParentheseIndex + trimmedSymb;
            }

        } while (leftParentheseIndex != -1 && rightParentheseIndex != -1);

        return -1;
    }
}