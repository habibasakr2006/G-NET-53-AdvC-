using System;
using System.Collections.Generic;

namespace Adv1
{
    #region Q1

    //public class GenericClass<T>
    //{
    //    public T Value { get; set; }
    //}

    #endregion

    #region Q2

    //public class Container<T>
    //{
    //    private T value;

    //    public void Add(T item)
    //    {
    //        value = item;
    //    }

    //    public T Get()
    //    {
    //        return value;
    //    }
    //}

    #endregion

    #region Q3

    //public class Pair<TKey, TValue>
    //{
    //    public TKey Key { get; set; }
    //    public TValue Value { get; set; }

    //    public Pair(TKey key, TValue value)
    //    {
    //        Key = key;
    //        Value = value;
    //    }
    //}

    #endregion

    #region Q4

    //public class GenericMethods
    //{
    //    public static void Swap<T>(ref T first, ref T second)
    //    {
    //        T temp = first;
    //        first = second;
    //        second = temp;
    //    }
    //}

    #endregion

    #region Q5

    //public class MaxFinder
    //{
    //    public static T FindMax<T>(T first, T second) where T : IComparable<T>
    //    {
    //        return first.CompareTo(second) > 0 ? first : second;
    //    }
    //}

    #endregion

    #region Q6

    //public interface IRepository<T>
    //{
    //    void Add(T item);
    //    T Get(int id);
    //    void Update(T item);
    //    void Delete(int id);
    //}

    #endregion

    #region Q7

    //public class StructExample<T> where T : struct
    //{
    //    public T Value { get; set; }

    //    public StructExample(T value)
    //    {
    //        Value = value;
    //    }
    //}

    #endregion

    #region Q8

    //public class ClassExample<T> where T : class
    //{
    //    public T Value { get; set; }

    //    public ClassExample(T value)
    //    {
    //        Value = value;
    //    }
    //}

    #endregion

    #region Q9

    //public class NewConstraintExample<T> where T : new()
    //{
    //    public T Create()
    //    {
    //        return new T();
    //    }
    //}

    #endregion

    #region Q10

    //public interface IEntity
    //{
    //    int Id { get; set; }
    //}

    //public class Entity : IEntity
    //{
    //    public int Id { get; set; }
    //}

    //public class InterfaceConstraintExample<T> where T : IEntity
    //{
    //    public int GetId(T item)
    //    {
    //        return item.Id;
    //    }
    //}

    #endregion

    #region Q11

    //public class Animal
    //{
    //    public string Name { get; set; }
    //}

    //public class BaseClassConstraintExample<T> where T : Animal
    //{
    //    public string GetName(T animal)
    //    {
    //        return animal.Name;
    //    }
    //}

    #endregion

    #region Q12

    //public class MultipleConstraints<T> where T : class, IEntity, new()
    //{
    //    public T Create()
    //    {
    //        return new T();
    //    }

    //    public int GetId(T item)
    //    {
    //        return item.Id;
    //    }
    //}

    #endregion

    #region Q13

    public class DefaultExample<T>
    {
        public T GetDefault()
        {
            return default;
        }
    }

    #endregion

    #region Q14

    public class SafeList<T>
    {
        private readonly List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public T Get(int index)
        {
            if (index < 0 || index >= items.Count)
            {
                return default;
            }

            return items[index];
        }
    }

    #endregion

    #region Q15

    public interface IProducer<out T>
    {
        T Get();
    }

    public class AnimalProducer : IProducer<Animal>
    {
        public Animal Get()
        {
            return new Animal();
        }
    }

    #endregion

    #region Q16

    public interface IConsumer<in T>
    {
        void Consume(T item);
    }

    public class AnimalConsumer : IConsumer<Animal>
    {
        public void Consume(Animal item)
        {
            Console.WriteLine(item.Name);
        }
    }

    #endregion

    #region Q17

    public interface ICovariant<out T>
    {
        T Get();
    }

    public interface IContravariant<in T>
    {
        void Set(T item);
    }

    #endregion

    #region Q18

    public class GenericStatic<T>
    {
        public static int Counter;

        public void Increment()
        {
            Counter++;
        }
    }

    #endregion

    #region Q19

    public class GenericBase<T>
    {
        public T Value { get; set; }

        public GenericBase(T value)
        {
            Value = value;
        }
    }

    public class DerivedClass : GenericBase<int>
    {
        public DerivedClass(int value) : base(value)
        {
        }
    }

    #endregion

    #region Q20

    public class Cache<TKey, TValue>
    {
        private class CacheItem
        {
            public TValue Value { get; set; }
            public DateTime ExpirationTime { get; set; }
        }

        private readonly Dictionary<TKey, CacheItem> cache =
            new Dictionary<TKey, CacheItem>();

        public void Add(TKey key, TValue value, TimeSpan expiration)
        {
            cache[key] = new CacheItem
            {
                Value = value,
                ExpirationTime = DateTime.Now.Add(expiration)
            };
        }

        public TValue Get(TKey key)
        {
            if (!cache.ContainsKey(key))
            {
                return default;
            }

            CacheItem item = cache[key];

            if (DateTime.Now >= item.ExpirationTime)
            {
                cache.Remove(key);
                return default;
            }

            return item.Value;
        }

        public void Remove(TKey key)
        {
            cache.Remove(key);
        }

        public bool Contains(TKey key)
        {
            if (!cache.ContainsKey(key))
            {
                return false;
            }

            if (DateTime.Now >= cache[key].ExpirationTime)
            {
                cache.Remove(key);
                return false;
            }

            return true;
        }
    }

    #endregion
}