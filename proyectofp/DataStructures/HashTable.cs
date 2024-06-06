using System;
using System.Collections.Generic;
using proyectofp.DataStructures;

namespace proyectofp.DataStructures
{
    public class HashTable<TKey, TValue>
    {
        private System.Collections.Generic.LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
        private int size;

        public HashTable(int size)
        {
            this.size = size;
            buckets = new System.Collections.Generic.LinkedList<KeyValuePair<TKey, TValue>>[size];
            for (int i = 0; i < size; i++)
            {
                buckets[i] = new System.Collections.Generic.LinkedList<KeyValuePair<TKey, TValue>>();
            }
        }

        private int GetBucketIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()) % size;
        }

        public void Insert(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists");
                }
            }
            bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
        }

        public TValue Find(TKey key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];
            foreach (var pair in bucket)
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }
            return default(TValue);
        }

        public void Delete(TKey key)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];
            var node = bucket.First;
            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    bucket.Remove(node);
                    return;
                }
                node = node.Next;
            }
        }

        public void Update(TKey key, TValue value)
        {
            int index = GetBucketIndex(key);
            var bucket = buckets[index];
            var node = bucket.First;
            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    bucket.Remove(node);
                    bucket.AddLast(new KeyValuePair<TKey, TValue>(key, value));
                    return;
                }
                node = node.Next;
            }
            throw new KeyNotFoundException("Key not found");
        }

        public List<TValue> ToList()
        {
            List<TValue> list = new List<TValue>();
            foreach (var bucket in buckets)
            {
                foreach (var pair in bucket)
                {
                    list.Add(pair.Value);
                }
            }
            return list;
        }
    }
}
