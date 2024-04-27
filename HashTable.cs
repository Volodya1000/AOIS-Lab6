using System.Diagnostics.CodeAnalysis;

namespace Lab6HashTable
{
    class Cell
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public Cell(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public class HashTable
    {
        private Cell[] table;
        private int capacity;
        private int size;

        private const int DefaultCapacity = 11;

        public HashTable()
        {
            table = new Cell[DefaultCapacity];
            capacity = DefaultCapacity;
            size = 0;
        }

        public int HashFunction(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 2 ||
                !IsRussianLetter(input[0]) || !IsRussianLetter(input[1]))
            {
                throw new ArgumentException("Ключ должен содержать как минимум две буквы русского алфавита в начале.");
            }

            int firstLetterIndex = char.ToLower(input[0]) - 'а';
            int secondLetterIndex = char.ToLower(input[1]) - 'а';

            return firstLetterIndex * 33 + secondLetterIndex ;
        }

        static bool IsRussianLetter(char c)
        {
            return (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я');
        }
       

        private int ProbeQuadratic(string key)
        {
            int hash = HashFunction(key) % capacity;
            int i = hash;
            int j = 1;

            while (table[i] != null&&!table[i].Key.Equals(key))
            {
                i = (hash + j * j) % capacity;
                j++;
            }

            return i;
        }

        public void Insert(string key, string value)
        {
            if (size >= capacity * 0.7)
            {
                ExpandTable();
            }

            int i = ProbeQuadratic(key);

            if (table[i] != null && table[i].Key.Equals(key))// Если элемент существует, заменяем его значение  
                table[i].Value = value;
            else
            {
                table[i] = new Cell(key, value);
                size++;
            }
        }

        public string Get(string key)
        {
            int i = ProbeQuadratic(key);

            if (table[i] != null && table[i].Key.Equals(key))
            {
                return table[i].Value;
            }

            return null;
        }

        public void Remove(string key)
        {
            int i = ProbeQuadratic(key);

            if (table[i] != null && table[i].Key.Equals(key))
            {
                table[i] = null;
                size--;
            }
        }
        private void ExpandTable()
        {
            int newCapacity = capacity * 2;
            Cell[] newTable = new Cell[newCapacity];

            for (int i = 0; i < capacity; i++)
            {
                if (table[i] != null)
                {
                    int hash = HashFunction(table[i].Key)% newCapacity;
                    int newIndex = hash;
                    int j = 1;

                    while (newTable[newIndex] != null)
                    {
                        newIndex = (hash + j * j) % newCapacity;
                        j++;
                    }
                    newTable[newIndex] = table[i];
                }
            }

            capacity = newCapacity;
            table = newTable;
        }

        [ExcludeFromCodeCoverage]
        public string PrintHashTable()
        {
            string ret ="";

            for (int i = 0; i < capacity; i++)
            {
                if (table[i] != null)
                {
                    ret +=$"Index {i}: Key = {table[i].Key}, Value = {table[i].Value} \n";
                }
                else
                {
                    ret += $"Index {i}: Empty\n";
                }
            }
            return ret;
        }
    }
}
