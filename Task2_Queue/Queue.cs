using static System.Console;

namespace Task2;

internal class Program
{
    static void Main(string[] args)
    {
        MyQueue stack = new MyQueue(); // стек
        string commandLine = null; // пользовательская команда
        int pushNum; // добавляемое число

        do
        {
            Write(">> ");
            commandLine = ReadLine();

            switch (commandLine)
            {
                case "pop":
                    WriteLine(stack.Pop());
                    break;
                case "front":
                    WriteLine(stack.Peek());
                    break;
                case "size":
                    WriteLine(stack.Size());
                    break;
                case "clear":
                    WriteLine(stack.Clear());
                    break;
                case "exit":
                    WriteLine("bye");
                    break;
                default:
                    if (commandLine != null && commandLine.Length > 5
                        && commandLine.Substring(0, 5) == "push "
                        && int.TryParse(commandLine.Substring(5), out pushNum))
                    {
                        WriteLine(stack.Push(pushNum));
                    }
                    else
                    {
                        WriteLine("unsupported command");
                    }
                    break;
            }
        } while (commandLine != "exit");
    }
}

struct MyQueue
{
    private int[]? queue;
    private int length;

    // конструктор
    public MyQueue()
    {
        queue = new int[10];
        length = 0;
    }

    // изменить размер очереди
    private void Resize()
    {
        // если queue - не нулевой указатель
        if (queue != null)
        {
            Array.Resize(ref queue, queue.Length * 2);
        }
    }

    // добавить элемент в очередь
    public string Push(int value)
    {
        // если в очереди недостаточно места
        if (queue.Length == length)
        {
            Resize();
        }

        queue[length++] = value;
        return "ok";
    }

    // удалить крайний элемент из очереди
    public string Pop()
    {
        // если в очереди нет элементов
        if (length == 0)
        {
            return "error";
        }

        int retVal = queue[0];

        for (int i = 0; i < length - 1; i++)
        {
            queue[i] = queue[i + 1];
        }
        length--;

        return retVal.ToString();
    }

    // посмотреть крайний элемент очереди
    public string Peek()
    {
        // если в очереди нет элементов
        if (length == 0)
        {
            return "error";
        }

        return queue[0].ToString();
    }

    // получить размер очереди
    public string Size()
    {
        return length.ToString();
    }

    // очистить очередь
    public string Clear()
    {
        queue = new int[10];
        length = 0;

        return "ok";
    }
}