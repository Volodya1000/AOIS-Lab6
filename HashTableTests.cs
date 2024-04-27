using Lab6HashTable;
namespace HashTableTestProject
{
    public class HashTableTests
    {
        [Fact]
        public void InsertAndGet()
        {
            HashTable hashTable = new ();
            string key = "ключ";
            string value = "значение";

            hashTable.Insert(key, value);
            string retrievedValue = hashTable.Get(key);

            Assert.Equal(value, retrievedValue);
        }

        [Fact]
        public void InsertAndRemove()
        {
            HashTable hashTable = new ();
            string key = "ключ";
            string value = "значение";

            hashTable.Insert(key, value);
            hashTable.Remove(key);
            string retrievedValue = hashTable.Get(key);

            Assert.Null(retrievedValue);
        }

      

        [Fact]
        public void Insert_DuplicateKey()
        {
            HashTable hashTable = new ();
            string key = "ключ";
            string value1 = "значение1";
            string value2 = "значение2";

            hashTable.Insert(key, value1);
            hashTable.Insert(key, value2);
            string retrievedValue = hashTable.Get(key);

            Assert.Equal(value2, retrievedValue);
        }

        [Fact]
        public void Insert_many()
        {
            HashTable hashTable = new();
            hashTable.Insert("Ключ1", "val");
            hashTable.Insert("Ключ2", "val");
            hashTable.Insert("Ключ3", "val");
            hashTable.Insert("Ключ4", "val");

            string retrievedValue = hashTable.Get("Ключ3");
            Assert.Equal("val", retrievedValue);
        }

        [Fact]
        public void Insert_many2()
        {
            HashTable hashTable = new();
            hashTable.Insert("аб", "val");
            hashTable.Insert("ас", "val");
            hashTable.Insert("ад", "val");
            hashTable.Insert("аг", "val");
            hashTable.Insert("ае", "val");
            hashTable.Insert("аж", "val");
            hashTable.Insert("аз", "val");
            hashTable.Insert("аи", "val");
            hashTable.Insert("ал", "val");

            string retrievedValue = hashTable.Get("ас");
            Assert.Equal("val", retrievedValue);
        }

        [Fact]
        public void HashFunction_InvalidInput()
        {
            HashTable hashTable = new ();
            Assert.Throws<ArgumentException>(() => { hashTable.HashFunction("qq"); });
        }
    }
}