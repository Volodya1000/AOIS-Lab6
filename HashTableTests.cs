using Lab6HashTable;
namespace HashTableTestProject
{
    public class HashTableTests
    {
        [Fact]
        public void InsertAndGet()
        {
            HashTable hashTable = new ();
            string key = "����";
            string value = "��������";

            hashTable.Insert(key, value);
            string retrievedValue = hashTable.Get(key);

            Assert.Equal(value, retrievedValue);
        }

        [Fact]
        public void InsertAndRemove()
        {
            HashTable hashTable = new ();
            string key = "����";
            string value = "��������";

            hashTable.Insert(key, value);
            hashTable.Remove(key);
            string retrievedValue = hashTable.Get(key);

            Assert.Null(retrievedValue);
        }

      

        [Fact]
        public void Insert_DuplicateKey()
        {
            HashTable hashTable = new ();
            string key = "����";
            string value1 = "��������1";
            string value2 = "��������2";

            hashTable.Insert(key, value1);
            hashTable.Insert(key, value2);
            string retrievedValue = hashTable.Get(key);

            Assert.Equal(value2, retrievedValue);
        }

        [Fact]
        public void Insert_many()
        {
            HashTable hashTable = new();
            hashTable.Insert("����1", "val");
            hashTable.Insert("����2", "val");
            hashTable.Insert("����3", "val");
            hashTable.Insert("����4", "val");

            string retrievedValue = hashTable.Get("����3");
            Assert.Equal("val", retrievedValue);
        }

        [Fact]
        public void Insert_many2()
        {
            HashTable hashTable = new();
            hashTable.Insert("��", "val");
            hashTable.Insert("��", "val");
            hashTable.Insert("��", "val");
            hashTable.Insert("��", "val");
            hashTable.Insert("��", "val");
            hashTable.Insert("��", "val");
            hashTable.Insert("��", "val");
            hashTable.Insert("��", "val");
            hashTable.Insert("��", "val");

            string retrievedValue = hashTable.Get("��");
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