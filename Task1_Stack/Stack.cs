using static System.Console;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStack stack = new MyStack(); // стек
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
                    case "back":
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

    struct MyStack
    {
        private int[]? stack;
        private int length;

        // конструктор
        public MyStack()
        {
            stack = new int[10];
            length = 0;
        }

        // изменить размер стека
        private void Resize()
        {
            // если stack - не нулевой указатель
            if (stack != null)
            {
                Array.Resize(ref stack, stack.Length * 2);
            }
        }

        // добавить элемент в стек
        public string Push(int value)
        {
            // если стек содержит 100 элементов
            if (length == 100)
            {
                return "stack overflow";
            }

            // если в стеке не осталось места под новый элемент
            if (stack.Length == length)
            {
                Resize();
            }

            stack[length++] = value;
            return "ok";
        }

        // удалить крайний элемент из стека
        public string Pop()
        {
            // если в стеке нет элементов
            if (length == 0)
            {
                return "stack is empty";
            }

            return stack[(length--) - 1].ToString();
        }

        // посмотреть крайний элемент стека
        public string Peek()
        {
            // если в стеке нет элементов
            if (length == 0)
            {
                return "stack is empty";
            }

            return stack[length - 1].ToString();
        }

        // посмотреть размер стека
        public string Size()
        {
            return length.ToString();
        }

        // очистить стек
        public string Clear()
        {
            stack = new int[10];
            length = 0;

            return "ok";
        }
    }
}